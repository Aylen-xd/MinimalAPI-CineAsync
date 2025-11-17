using Microsoft.AspNetCore.Mvc;
using Cine.Core.Persistencia;
using Cine.Core;
using System.Threading.Tasks;
using Cine.MVC.VModels;


namespace Cine.Core.Controllers;

public class PeliculaController : Controller
{
    IRepoPelicula _repoPelicula;
    IRepoProduccion _repoProduccion;
    public PeliculaController(IRepoPelicula repoPelicula, IRepoProduccion repoProduccion) => (_repoPelicula, _repoProduccion) = (repoPelicula, repoProduccion);

    public IActionResult Listado() => View(_repoPelicula.TraerElementos());

    [HttpGet]
    public async Task<IActionResult> Alta() => View("Upsert");

    [HttpGet]
    public async Task<IActionResult> Modificar(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var pelicula = await _repoPelicula.DetalleAsync(id.Value);

        if (pelicula is null)
            return NotFound();

        var peliculass = await _repoPelicula.TraerElementoAsync();

        VMPeliculas vmPelicula = new VMPeliculas(peliculass);

        return View("Upsert", pelicula);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(VMPeliculas vmPelicula)
    {
        var pelicula = vmPelicula.Pelicula;

        //vmPelicula.Trailers = vmPelicula.Trailers;
        //vmPelicula.Actores = vmPelicula.Actores;
        //vmPelicula.Produccion = vmPelicula.Produccion;
        vmPelicula.Pelicula.IdProduccion = vmPelicula.IdProduccion;
        vmPelicula.Pelicula.Nombre = vmPelicula.Nombre;
        vmPelicula.Pelicula.Estreno = vmPelicula.Estreno;
        vmPelicula.Pelicula.Calificacion = vmPelicula.Calificacion;
        vmPelicula.Pelicula.Duracion = vmPelicula.Duracion;
        vmPelicula.Pelicula.Calificacion = vmPelicula.Calificacion;
        vmPelicula.Pelicula.Descripcion = vmPelicula.Descripcion;
        vmPelicula.Pelicula.Restriccion = vmPelicula.Restriccion;
        vmPelicula.Pelicula.Recaudado = vmPelicula.Recaudado;
        
        vmPelicula.Pelicula.IdPelicula = vmPelicula.IdPelicula;


        //vmPelicula.Produccion = pelicula.Produccion;
        /*vmPelicula.IdProduccion = pelicula.IdProduccion;
        vmPelicula.IdPelicula = pelicula.IdPelicula;
        vmPelicula.Nombre = pelicula.Nombre;
        vmPelicula.Estreno = pelicula.Estreno;
        vmPelicula.Calificacion = pelicula.Calificacion;
        vmPelicula.Duracion = pelicula.Duracion;
        vmPelicula.Calificacion = pelicula.Calificacion;
        vmPelicula.Descripcion = pelicula.Descripcion;
        vmPelicula.Restriccion = pelicula.Restriccion;
        vmPelicula.Recaudado = pelicula.Recaudado;*/
        /*if (!ModelState.IsValid)
        return View("Upsert", pelicula);*/

        //Preguntar si id es 0 o no ...
        if (vmPelicula.IdPelicula == 0)
        {
            _repoPelicula.Alta(vmPelicula.Pelicula);
            return RedirectToAction(nameof(Listado));

        }
        else
        {
            await _repoPelicula.ModificarAsync(vmPelicula.Pelicula);
            return RedirectToAction(nameof(Listado));
        }
    }
}

