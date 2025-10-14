using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.Core;

namespace Cine.MVC.Controllers;

public class EstudioController : Controller
{
    IRepoEstudio _repoEstudio;

    public EstudioController(IRepoEstudio repoEstudio) => _repoEstudio = repoEstudio;

    public IActionResult Indedx() => View(_repoEstudio.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta() => View("Upsert");

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var estudio = await _repoEstudio.DetalleAsync(id.Value);

        if (estudio is null)
            return NotFound();

        return View("Upsert", estudio);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(Estudio estudio)
    {
        if (estudio.IdEstudio == 0)
        {
            _repoEstudio.Alta(estudio);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await _repoEstudio.ModificarAsync(estudio);
            return RedirectToAction(nameof(Index));
        }
    }
}
