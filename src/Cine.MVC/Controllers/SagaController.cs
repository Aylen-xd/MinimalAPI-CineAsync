using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;

namespace Cine.Core.Controllers;

public class SagaController : Controller
{
    IRepoSaga _repoSaga;
    IRepoPelicula _repoPeli;

    public SagaController(IRepoSaga repoSaga, IRepoPelicula repoPelicula)
    => (_repoSaga, _repoPeli) = (repoSaga, repoPelicula);

    public IActionResult Listado() => View(_repoSaga.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta()
    {
        var peliculas = await _repoPeli.TraerElementoAsync();
        VMSaga vm = new VMSaga(peliculas);
        return View("Upsert", vm);
    }

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var saga = await _repoSaga.DetalleAsync(id.Value);

        if (saga is null)
            return NotFound();

        var peliculas = await _repoPeli.TraerElementoAsync();

        VMSaga vmSaga = new VMSaga(peliculas); 

        vmSaga.IdSaga = saga.IdSaga;
        vmSaga.IdPelicula = saga.IdPelicula;
        vmSaga.Nombre = saga.NombreSaga;
        vmSaga.NSaga = saga.NSaga;

        return View("Upsert", vmSaga);
    }
    
    [HttpPost]
    public async Task<IActionResult> Upsert (VMSaga vmsaga)
    {
        vmsaga.Saga.IdPelicula = vmsaga.IdPelicula;
        
        if (vmsaga.IdSaga == 0)
        {
            _repoSaga.Alta(vmsaga.Saga);
            return RedirectToAction(nameof(Listado));
        }

        else
        {
            vmsaga.Saga.IdSaga = vmsaga.IdSaga;
            await _repoSaga.ModificarAsync(vmsaga.Saga);
            return RedirectToAction(nameof(Listado));
        }
    }
}
