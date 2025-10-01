using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.Core;
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

        var genero = await _repoGenero.DetalleAsync(id.Value);

        if (genero is null)
            return NotFound();

        return View("Upsert", genero);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(Genero genero)
    {
        /*if (!ModelState.IsValid)
        return View("Upsert", genero);*/

        //Preguntar si id es 0 o no ...
        if (genero.IdGenero == 0)
        {
            _repoGenero.Alta(genero);
            return RedirectToAction(nameof(Index));

        }
        else
        {
            await _repoGenero.ModificarAsync(genero);
            return RedirectToAction(nameof(Index));
        }
    }
}