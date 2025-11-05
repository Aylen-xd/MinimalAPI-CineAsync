using Cine.Core.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;
using Cine.Core;

namespace Cine.MVC.Controllers;

public class ActorController : Controller
{
    IRepoActor _repoActor;

    public ActorController(IRepoActor repoActor)
    => _repoActor = repoActor;

    public IActionResult Listado() => View(_repoActor.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta() => View("Upsert");

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var actor = await _repoActor.DetalleAsync(id.Value);

        if (actor is null)
            return NotFound();

        return View("Upsert", actor);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(Actor actor)
    {
        //Preguntar si id es 0 o no ...
        if (actor.idActor == 0)
        {
            _repoActor.Alta(actor);
            return RedirectToAction(nameof(Index));

        }
        else
        {
            await _repoActor.ModificarAsync(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
