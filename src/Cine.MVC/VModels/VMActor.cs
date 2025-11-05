using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMActor
{
    //public SelectList listaProducciones;
    public SelectList listaPelicula;
    public byte IdPelicula { get; set; }
    public int IdActor { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
    public byte Sexo { get; set; }
    public string? Nacionalidad { get; set; }
    public string? Rol { get; set; }

    public Actor Actor { get; set; } = new Actor();

    public VMActor(IEnumerable<Pelicula> peliculas , byte? idPelicula = null)
    {
        listaPelicula = idPelicula is null ?
            new SelectList(peliculas,
                dataTextField: nameof(Pelicula.Nombre),
                dataValueField: nameof(Pelicula.IdPelicula)) :
            new SelectList(peliculas,
                dataTextField: nameof(Pelicula.Nombre),
                dataValueField: nameof(Pelicula.IdPelicula),
                selectedValue: idPelicula)
                ;     
    }

    public void Elegircosas(IEnumerable<Pelicula> peliculas)
    {
        listaPelicula = new SelectList(Enumerable.Empty<Pelicula>(),
        dataTextField: nameof(Pelicula.Nombre),
        dataValueField: nameof(Pelicula.IdPelicula));
    }
    /*
                public Actor Actor =>
                    new Actor(IdActor, Nombre, Apellido);
            */
    public VMActor() { }
}
