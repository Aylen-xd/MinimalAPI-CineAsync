using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMActor
{
    //public SelectList listaProducciones;
    public SelectList listaPelicula;
    public SelectList listaSexo;
    public byte IdPelicula { get; set; }
    public byte IdActor { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
    public char Sexo { get; set; }
    public string? Nacionalidad { get; set; }
    public string? Rol { get; set; }

    //public Actor Actor { get; set; } = new Actor();

    public Actor Actor =>
        new Actor(IdActor, Nombre, Apellido, Fecha_Nacimiento, Sexo, Nacionalidad, Rol);

    public VMActor(IEnumerable<Pelicula> peliculas, byte? idPelicula = null, char? sexo = null)
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
        listaSexo = new SelectList(new[]
        {
            new { Value = 'M', Text = "Masculino" },
            new { Value = 'F', Text = "Femenino" },
            new { Value = 'O', Text = "Otro" }
    });
    }

    public void Elegircosas(IEnumerable<Pelicula> peliculas)
    {
        listaPelicula = new SelectList(Enumerable.Empty<Pelicula>(),
        dataTextField: nameof(Pelicula.Nombre),
        dataValueField: nameof(Pelicula.IdPelicula));
    }
    public VMActor() { }
}
