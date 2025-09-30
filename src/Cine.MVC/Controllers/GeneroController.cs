using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.MVC.VModels;
using System.Threading.Tasks;

namespace Cine.Core.Controllers;

public class GeneroController : Controller
{
    IRepoGenero _repoGenero;

    public GeneroController(IRepoGenero repoGenero) => _repoGenero = repoGenero;

    public IActionResult Index() => View(_repoGenero.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta() => View("Upsert");

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var genero = await _repoGenero.ModificarAsync();

        if (genero is null)
            return NotFound();

        return View("Upsert", genero);
    }

    [HttpPost]
    public IActionResult Upsert(Genero genero)
    {
        _repoGenero.Alta(genero);
        return RedirectToAction(nameof(Index));
    }
}