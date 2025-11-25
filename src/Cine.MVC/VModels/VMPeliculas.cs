using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMPeliculas
{
    public SelectList ProduccionesList;

    public byte IdPelicula { get; set; }
    public byte IdProduccion { get; set; }
    public string? Nombre { get; set; }
    public DateTime Estreno { get; set; }
    public string? Descripcion { get; set; }
    public byte Calificacion { get; set; }
    public TimeSpan Duracion { get; set; }
    public byte Restriccion { get; set; }
    public ulong Recaudado { get; set; }
    public IEnumerable<Trailer> Trailers { get; set; }
    public IEnumerable<Actor> Actores { get; set; }
    public Produccion? Produccion { get; set; }

    public Pelicula Pelicula =>
        new Pelicula(IdPelicula, IdProduccion, Nombre ?? string.Empty, Estreno, Descripcion ?? string.Empty, Calificacion, Duracion, Restriccion, Recaudado);


    public VMPeliculas(Pelicula pelicula, IEnumerable<Produccion> producciones)
    {

        ProduccionesList = new(producciones,
                            dataTextField: nameof(Produccion.Productor),
                            dataValueField: nameof(Produccion.IdProduccion));

        IdPelicula = pelicula.IdPelicula;
        IdProduccion = pelicula.IdProduccion;
        Nombre = pelicula.Nombre;
        Estreno = pelicula.Estreno;
        Descripcion = pelicula.Descripcion;
        Calificacion = pelicula.Calificacion;
        Restriccion = pelicula.Restriccion;
        Recaudado = pelicula.Recaudado;
        Duracion = pelicula.Duracion;
    }

    public void Elegircosas(IEnumerable<Produccion> producciones)
    {
        ProduccionesList = new SelectList(Enumerable.Empty<Produccion>(),
        dataTextField: nameof(Produccion.Productor),
        dataValueField: nameof(Produccion.IdProduccion));
    }

    public VMPeliculas() { }
}
