namespace Cine.Core;

public class Trailer
{
    public Trailer( byte idTrailer , byte idPelicula , byte idGenero , string nombre , TimeSpan duracion )
    {
        IdTrailer = IdTrailer;
        IdPelicula = idPelicula;
        IdGenero = idGenero ;
        Nombre = nombre ;
        Duracion = duracion ;
    }

    public byte IdTrailer { get ; set ; }
    public byte IdPelicula { get ; set ; }
    public byte IdGenero { get ; set ; }
    public string Nombre { get ; set ; }
    public TimeSpan Duracion { get ; set ; }
}
