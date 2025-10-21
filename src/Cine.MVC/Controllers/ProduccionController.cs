using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;
using Cine.Core;

namespace Cine.MVC.Controllers;

public class ProduccionController : Controller
{
    IRepoProduccion _repoProduccion;
    IRepoEstudio _repoEstudio;

    public ProduccionController(IRepoProduccion repoProduccion, IRepoEstudio repoEstudio)
    {
        _repoProduccion = repoProduccion;
        _repoEstudio = repoEstudio;
    }

    public IActionResult Listado() => View(_repoProduccion.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta()
    {
        var estudios = await _repoEstudio.TraerElementosAsync();
        VMProduccion vmProduccion = new VMProduccion(estudios);
        return View("Upsert", vmProduccion);
    }

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var produccion = await _repoProduccion.DetalleAsync(id.Value);

        var estudios = await _repoEstudio.TraerElementosAsync();

        if (produccion is null)
            return NotFound();

        VMProduccion vmProduccion = new VMProduccion(estudios);

        vmProduccion.IdProduccion = produccion.IdProduccion;

        vmProduccion.IdEstudio = produccion.IdEstudio;
        vmProduccion.Director_General = produccion.Director_General;
        vmProduccion.Productor = produccion.Productor;
        vmProduccion.Guion = produccion.Guion;
        vmProduccion.Musica = produccion.Musica;
        vmProduccion.Sonido = produccion.Sonido;
        vmProduccion.Vestuario = produccion.Vestuario;
        vmProduccion.Presupuesto = produccion.Presupuesto;

        return View("Upsert", vmProduccion);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(VMProduccion vmproduccion)
    {
        /*if (!ModelState.IsValid)
        return View("Upsert", produccion);*/

        //Preguntar si id es 0 o no ...
        if (vmproduccion.IdProduccion == 0)
        {
            _repoProduccion.Alta(vmproduccion.produccion);
            return RedirectToAction(nameof(Listado));

        }
        else
        {
            vmproduccion.produccion.IdProduccion = vmproduccion.IdProduccion;

            await _repoProduccion.ModificarAsync(vmproduccion.produccion);
            return RedirectToAction(nameof(Listado));
        }
    }
}
