using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;

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

    [HttpPost]
    public IActionResult Upsert(VMTrailer vmtrailer)
    {
        _repoTrailer.Alta(vmtrailer.Trailer);
        return RedirectToAction(nameof(Index)); 
    }
}







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