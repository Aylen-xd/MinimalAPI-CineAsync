using Cine.Core.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Cine.MVC.VModels;
using Cine.Core;

namespace Cine.MVC.Controllers;

public class ActorController : Controller
{
    IRepoActor _repoActor;
    IRepoPelicula _repoPeli;

    public ActorController(IRepoActor repoActor,IRepoPelicula repoPeli)
    => (_repoActor, _repoPeli) = (repoActor, repoPeli);

    public IActionResult Listado() => View(_repoActor.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta()
    {
        var pelis = await _repoPeli.TraerElementoAsync();
        VMActor vm = new VMActor(pelis);
        return View("Upsert", vm);
    }

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var actor = await _repoActor.DetalleAsync(id.Value);

        if (actor is null)
            return NotFound();

            var actorPelis = await _repoPeli.TraerElementoAsync();

            VMActor vmActor = new VMActor(actorPelis);

        return View("Upsert", actor);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(VMActor vmactor)
    {

        vmactor.Actor.Nombre = vmactor.Nombre;
        vmactor.Actor.Apellido = vmactor.Apellido;
        vmactor.Actor.FNacimiento = vmactor.Fecha_Nacimiento; 
        vmactor.Actor.Sexo = vmactor.Sexo;
        vmactor.Actor.Nacionalidad = vmactor.Nacionalidad;
        vmactor.Actor.Rol = vmactor.Rol;

        vmactor.Actor.idActor = vmactor.IdActor;
        //Preguntar si id es 0 o no ...
        if (vmactor.IdActor == 0)
        {
            _repoActor.Alta(vmactor.Actor);
            return RedirectToAction(nameof(Listado));

        }
        else 
        {
            vmactor.Actor.idActor = vmactor.IdActor;
            await _repoActor.ModificarAsync(vmactor.Actor);
            return RedirectToAction(nameof(Listado));
        }
    }
}
