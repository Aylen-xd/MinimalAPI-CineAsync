using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cine.Core;
using Cine.Core.Persistencia;

namespace Cine.Core.Controllers;

public class HomeController : Controller
{
    IRepoGenero _repoGenero;

    public HomeController(IRepoGenero repoGenero) => _repoGenero = repoGenero;

    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult Genero() => View(_repoGenero.TraerElementos());
}