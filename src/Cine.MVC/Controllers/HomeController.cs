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


    /*private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }*/   