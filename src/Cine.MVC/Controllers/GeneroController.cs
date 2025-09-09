using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cine.Core;
using Cine.Core.Persistencia;

namespace Cine.Core.Controllers;

public class GeneroController : Controller
{
    IRepoGenero _repoGenero;

    public GeneroController(IRepoGenero repoGenero) => _repoGenero = repoGenero;

    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult Genero() => View(_repoGenero.TraerElementos());

}