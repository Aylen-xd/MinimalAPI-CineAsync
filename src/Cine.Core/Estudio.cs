namespace Cine.Core;
public class Estudio
{
    public Estudio(byte idEstudio, string nombre, DateTime fundacion)
    {
        IdEstudio = idEstudio;
        Nombre = nombre;
        Fundacion = fundacion;        
    }

    public byte IdEstudio { get ; set ; }
    public string Nombre { get ; set ; } = string.Empty;
    public DateTime Fundacion { get ; set ; }
    public IEnumerable<Produccion> Producciones { get; set; } = [];
    
}
