using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using System.Threading.Tasks;
using Cine.MVC.VModels;

namespace Cine.Core.Controllers;

public class TrailerController : Controller
{
    //Trailer

    IRepoTrailer _repoTrailer;
    IRepoGenero _repoGenero;

    public TrailerController(IRepoTrailer repoTrailer, IRepoGenero repoGenero)
        => (_repoTrailer, _repoGenero) = (repoTrailer, repoGenero);

    [HttpGet]
    public async Task<IActionResult> Alta()
    {
        var generos = await _repoGenero.TraerElementosAsync();
        VMTrailer vm = new VMTrailer(generos);
        return View();
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

