using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;
using System.Threading.Tasks;

namespace Cine.Core.Controllers;

public class TrailerController : Controller
{
    //Trailer

    IRepoTrailer _repoTrailer;
    IRepoGenero _repoGenero;

    public TrailerController(IRepoTrailer repoTrailer, IRepoGenero repoGenero)
        => (_repoTrailer, _repoGenero) = (repoTrailer, repoGenero);

    public IActionResult Index() => View("Listado", _repoTrailer.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta()
    {
        var generos = await _repoGenero.TraerElementosAsync();
        VMTrailer vm = new VMTrailer(generos);
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Alta(VMTrailer vmtrailer)
    {
        if (vmtrailer.IdTrailer == 0)
        {
            var generos =  _repoGenero.TraerElementos();
            VMTrailer vm = new VMTrailer(generos);
            return View(vm);
        }
        
        _repoTrailer.Alta(vmtrailer.Trailer);
        return RedirectToAction("Trailer"); 
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