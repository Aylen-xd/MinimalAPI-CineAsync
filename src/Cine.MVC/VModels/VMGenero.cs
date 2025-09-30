using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMGenero
{
    public SelectList listaGeneros;
    public byte IdGenero { get; set; }
    public string? Nombre { get; set; }

    public VMGenero(IEnumerable<Genero> generos)
    {
        listaGeneros = new(generos,
                            dataTextField: nameof(Genero.Nombre),
                            dataValueField: nameof(Genero.IdGenero));
    }

    public Genero Genero =>
        new Genero(IdGenero, Nombre);

    public VMGenero() { }
}
