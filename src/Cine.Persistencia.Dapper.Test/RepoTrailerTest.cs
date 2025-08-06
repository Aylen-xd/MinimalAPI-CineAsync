using Cine.Core;
using Cine.Core.Persistencia;
using Cine.Persistencia.Dapper.Test;

namespace Cine.Persistencia.Dapper;

public class RepoTrailerTest : TestBase
{
    readonly IRepoTrailer repo;

    public RepoTrailerTest () : base () => repo = new RepoTrailer (Conexion);
    
    [Fact]

    public void TraerElementosOK ()
    {
        var repos = repo.TraerElementos();
        Assert.Contains(repos, trai => trai.IdPelicula == 1);
    }

    [Fact]
    public void AltaTrailersw7 ()
    {
        byte idPelicula = 1 ;
        byte idGenero = 1 ;
        string nombre = "Trailer Star Wars el despertar de la fuerza" ;
        TimeSpan duracion = new TimeSpan (00,01,38) ;

        var AltaTrailersw7 = new Trailer (0,idPelicula,idGenero,nombre,duracion)
        {
            IdPelicula = idPelicula,
            IdGenero = idGenero,
            Nombre = nombre,
            Duracion = duracion
        };

        repo.Alta(AltaTrailersw7);
    }

    [Fact]
    public void AltaTrailersw8 ()
    {
        byte idPelicula = 2 ;
        byte idGenero = 1 ;
        string nombre = "Trailer Star Wars: Los ultimos jedi" ;
        TimeSpan duracion = new TimeSpan (00,02,28) ;

        var AltaTrailersw8 = new Trailer (0,idPelicula,idGenero,nombre,duracion)
        {
            IdPelicula = idPelicula,
            IdGenero = idGenero,
            Nombre = nombre,
            Duracion = duracion
        };

        repo.Alta(AltaTrailersw8);
    }
}
