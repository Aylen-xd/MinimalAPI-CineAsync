using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMSaga
{
    public SelectList listaPelicula;

    public byte IdSaga { get; set; }
    public byte IdPelicula { get; set; }
    public string? Nombre { get; set; }
    public byte NSaga { get; set; }

    public Saga Saga { get; set; } = new Saga();
    
/*
        public Saga Saga =>
        new Saga(IdSaga, IdPelicula, NSaga, Nombre);
    */
    public VMSaga(IEnumerable<Pelicula> peliculas)
    {
        listaPelicula = new(peliculas,
                            dataTextField: nameof(Pelicula.Nombre),
                            dataValueField: nameof(Pelicula.IdPelicula));
    }

    public void Elegircosas(IEnumerable<Pelicula> peliculas)
    {
        listaPelicula = new SelectList(Enumerable.Empty<Pelicula>(),
        dataTextField: nameof(Pelicula.Nombre),
        dataValueField: nameof(Pelicula.IdPelicula));
    }

    public VMSaga() { }
}
