using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Cine.Core.Controllers;

public class TrailerController : Controller
{
    //Trailer

    IRepoTrailer _repoTrailer;
    IRepoGenero _repoGenero;
    IRepoPelicula _repoPeli;

    public TrailerController(IRepoTrailer repoTrailer, IRepoGenero repoGenero, IRepoPelicula repoPeli)
        => (_repoTrailer, _repoGenero, _repoPeli) = (repoTrailer, repoGenero, repoPeli);

    public IActionResult Index() => View("Listado", _repoTrailer.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta()
    {
        var generos = await _repoGenero.TraerElementosAsync();
        var pelis = await _repoPeli.TraerElementoAsync();
        VMTrailer vm = new VMTrailer(generos, pelis);
        return View("Upsert", vm);
    }

    /*[HttpPost]
    public IActionResult Upsert(VMTrailer vmtrailer)
    {
        _repoTrailer.Alta(vmtrailer.Trailer);
        return RedirectToAction(nameof(Index));
    }*/

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var trailer = await _repoTrailer.DetalleAsync(id.Value);

        if (trailer is null)
            return NotFound();

        //VMTrailer vmTrailer = new VMTrailer();

        var generos = await _repoGenero.TraerElementosAsync();
        var pelis = await _repoPeli.TraerElementoAsync();

        VMTrailer vmTrailer = new VMTrailer(generos, pelis);

        vmTrailer.Trailer = trailer;

        vmTrailer.IdTrailer = trailer.IdTrailer;
        vmTrailer.IdPelicula = trailer.IdPelicula;
        vmTrailer.IdGenero = trailer.IdGenero;
        vmTrailer.Nombre = trailer.Nombre;
        vmTrailer.Duracion = trailer.Duracion;

        return View("Upsert", vmTrailer);
    }


    /*[HttpPost]
    public async Task<IActionResult> Upsert(Trailer trailer)
    {
        //Preguntar si id es 0 o no ...
        if (trailer.IdTrailer == 0)
        {
            _repoTrailer.Alta(trailer);
            return RedirectToAction(nameof(Index));

        }
        else
        {
            await _repoTrailer.ModificarAsync(trailer);
            return RedirectToAction(nameof(Index));
        }
    }*/

    [HttpPost]
    public async Task<IActionResult> Upsert(VMTrailer vmtrailer)
    {
        if (vmtrailer.IdTrailer == 0)
        {
            _repoTrailer.Alta(vmtrailer.Trailer);
            return RedirectToAction(nameof(Index));

        }
        else
        {
            vmtrailer.Trailer.IdTrailer = vmtrailer.IdTrailer;

            await _repoTrailer.ModificarAsync(vmtrailer.Trailer);
            return RedirectToAction(nameof(Index));
        }
    }
}


        /*if (!ModelState.IsValid)
        return View("Upsert", genero);*/


/*
    [HttpPost]
    public IActionResult Alta(Trailer trailer)
    {
        _repoTrailer.Alta(trailer);
        return RedirectToAction("Index", "Home");
    }
    */

/*
 [HttpPost]
    public async Task<IActionResult> Upsert(VMLiga vmLiga)
    {
        if (!ModelState.IsValid)
            return View("Upsert", vmLiga);

        if (vmLiga.IdLiga == 0)
        {
            var pais = await _unidad.RepoPais.ObtenerPorIdAsync(vmLiga.IdPais);
            var liga = new Liga(vmLiga.NombreLiga!, pais!);
            liga.Equipos = new List<Equipo>();
            await _unidad.RepoLiga.AltaAsync(liga);
        }

        try
        {
            await _unidad.GuardarAsync();
        }
        catch (EntidadDuplicadaException)
        {
            return NotFound();
        }

        return RedirectToAction("Index", "Home");
    }
*/