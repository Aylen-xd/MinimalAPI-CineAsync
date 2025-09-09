using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMTrailer
{
    SelectList listaGeneros;
    public byte IdTrailer { get; set; }
    public byte IdPelicula { get; set; }
    public byte IdGenero { get; set; }
    public string Nombre { get; set; }
    public TimeSpan Duracion { get; set; }

    public VMTrailer(IEnumerable<Genero> generos)
    {
        listaGeneros = new(generos,
                            dataTextField: nameof(Genero.Nombre),
                            dataValueField: nameof(Genero.IdGenero));
    }

    public Trailer Trailer =>
    
        new Trailer(IdTrailer, IdPelicula, IdGenero, Nombre, Duracion);

}
