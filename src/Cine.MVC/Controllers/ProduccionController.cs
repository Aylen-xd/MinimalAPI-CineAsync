using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;
using Cine.Core;

namespace Cine.MVC.Controllers;

public class ProduccionController : Controller
{
    IRepoProduccion _repoProduccion;
    IRepoEstudio _repoEstudio;

    public ProduccionController(IRepoProduccion repoProduccion) => _repoProduccion = repoProduccion;

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

        if (produccion is null)
            return NotFound();

        return View("Upsert", produccion);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(Produccion produccion)
    {
        /*if (!ModelState.IsValid)
        return View("Upsert", produccion);*/

        //Preguntar si id es 0 o no ...
        if (produccion.IdProduccion == 0)
        {
            _repoProduccion.Alta(produccion);
            return RedirectToAction(nameof(Index));

        }
        else
        {
            await _repoProduccion.ModificarAsync(produccion);
            return RedirectToAction(nameof(Index));
        }
    }
}
