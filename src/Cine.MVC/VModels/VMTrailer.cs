using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMTrailer
{
    public SelectList listaGeneros;
    public SelectList listaPelicula;
    public byte IdTrailer { get; set; }
    public byte IdPelicula { get; set; }
    public byte IdGenero { get; set; }
    public string? Nombre { get; set; }
    public TimeSpan Duracion { get; set; }
    public Trailer Trailer { get; set; } = new Trailer();

    //public Cine.Core.Trailer Trailer { get; set; }

    public VMTrailer(IEnumerable<Genero> generos, IEnumerable<Pelicula> peliculas)
    {
        listaGeneros = new(generos,
                            dataTextField: nameof(Genero.Nombre),
                            dataValueField: nameof(Genero.IdGenero));

        listaPelicula = new(peliculas,
                            dataTextField: nameof(Pelicula.Nombre),
                            dataValueField: nameof(Pelicula.IdPelicula));
    }

    //public Trailer Trailer =>
     //   new Trailer(IdTrailer, IdPelicula, IdGenero, Nombre, Duracion);


    /// Lista de opciones de generos Y PELICULAS para trailer
    public void Elegircosas(IEnumerable<Genero> generos, IEnumerable<Pelicula> peliculas)
    {
        listaGeneros = new SelectList(Enumerable.Empty<Genero>(),
                            dataTextField: nameof(Genero.Nombre),
                            dataValueField: nameof(Genero.IdGenero));

        listaPelicula = new SelectList(Enumerable.Empty<Pelicula>(),
                            dataTextField: nameof(Pelicula.Nombre),
                            dataValueField: nameof(Pelicula));
    }



    public VMTrailer(IEnumerable<Genero> generos, Trailer? trailer)
    {
        listaGeneros = new(generos,
                            dataTextField: nameof(Genero.Nombre),
                            dataValueField: nameof(Genero.IdGenero));
        IdTrailer = Trailer.IdTrailer;
        IdPelicula = Trailer.IdPelicula;
        IdGenero = Trailer.IdGenero;
        Nombre = Trailer.Nombre;
        Duracion = Trailer.Duracion;
    }

    public VMTrailer() { }

}
