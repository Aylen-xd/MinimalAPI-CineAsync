using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;
public class VMProduccion
{
    public SelectList listaEstudios;
    public byte IdProduccion { get; set; }
    public byte IdEstudio { get; set; }
    public string? Director_General { get; set; }
    public string? Productor { get; set; }
    public string? Guion { get; set; }
    public string? Musica { get; set; }
    public string? Sonido { get; set; }
    public string? Vestuario { get; set; }
    public decimal Presupuesto { get; set; }

    //public Produccion produccion { get; set; } = new Produccion();

    public Produccion produccion =>
    new Produccion(IdProduccion, IdEstudio, Director_General, Guion, Productor, Vestuario, Sonido, Presupuesto, Musica);

    public VMProduccion(IEnumerable<Estudio> estudios)
    {
        listaEstudios = new(estudios,
                            dataTextField: nameof(Estudio.Nombre),
                            dataValueField: nameof(Estudio.IdEstudio));
    }

    public void Elegircosas(IEnumerable<Estudio> estudios)
    {
        listaEstudios = new SelectList(Enumerable.Empty<Estudio>(),
                            dataTextField: nameof(Estudio.Nombre),
                            dataValueField: nameof(Estudio.IdEstudio));
    }

    public VMProduccion() { } 

}
