namespace Cine.Core;

public class Saga
{
    public Saga(byte idSaga , byte Numero_Saga ,
                byte idPelicula , string Nombre)
    {
        IdSaga = idSaga ;
        NSaga = Numero_Saga ;
        IdPelicula = idPelicula ;
        NombreSaga = Nombre ;
        Peliculas = [] ;
    }   

    public byte IdSaga { get ; set ; }
    public byte IdPelicula { get ; set ; }
    public byte NSaga { get ; set ; }
    public string NombreSaga { get ; set ; } 
    public IEnumerable<Pelicula> Peliculas { get ; set ; }
}
