namespace Cine.Core;

public class Pelicula
{
    public Pelicula(byte idPelicula, byte idProduccion, string? nombre, DateTime estreno, string? descripcion, byte calificacion, TimeSpan duracion, byte restriccion, ulong recaudado)
    {
        IdPelicula = idPelicula;
        IdProduccion = idProduccion;
        Nombre = nombre;
        Estreno = estreno;
        Descripcion = descripcion;
        Calificacion = calificacion;
        Duracion = duracion;
        Restriccion = restriccion;
        Recaudado = recaudado;
    }

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

    public Pelicula()
    {

    }
}
