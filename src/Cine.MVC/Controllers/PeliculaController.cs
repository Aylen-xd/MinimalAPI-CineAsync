using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.Core;
using System.Threading.Tasks;


namespace Cine.Core.Controllers;

public class PeliculaController : Controller
{
    IRepoPelicula _repoPelicula;
    IRepoProduccion _repoProduccion;
    public PeliculaController(IRepoPelicula repoPelicula, IRepoProduccion repoProduccion) => (_repoPelicula, _repoProduccion) = (repoPelicula, repoProduccion);

    public IActionResult Listado() => View(_repoPelicula.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta() => View("Upsert");

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var pelicula= await _repoPelicula.DetalleAsync(id.Value);

        if (pelicula is null)
            return NotFound();

        return View("Upsert", pelicula);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(Pelicula pelicula)
    {
        /*if (!ModelState.IsValid)
        return View("Upsert", pelicula);*/

        //Preguntar si id es 0 o no ...
        if (pelicula.IdPelicula == 0)
        {
            _repoPelicula.Alta(pelicula);
            return RedirectToAction(nameof(Listado));

        }
        else
        {
            await _repoPelicula.ModificarAsync(pelicula);
            return RedirectToAction(nameof(Listado));
        }
    }
}

