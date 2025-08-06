using Cine.Core;
using Cine.Core.Persistencia;
using Cine.Persistencia.Dapper.Repos;
using Xunit.Sdk;

namespace Cine.Persistencia.Dapper.Test;

public class RepoPeliculaTest : TestBase
{
    readonly IRepoPelicula repo;

    public RepoPeliculaTest () : base () => repo = new RepoPelicula(Conexion);

    [Fact]
    public void TraerPelisOK()
    {
        var repos = repo.TraerElementos();
        Assert.Contains(repos, peli => peli.IdPelicula == 1);
    }

    [Fact]
    public void TraerActoresDePelisOK()
    {
        var actores = repo.ActoresPelicula(1);
        Assert.Contains(actores, a => a.idActor == 1);
        // nos tendria que traer a Bell (Elsa) de frozen 1
    }

    [Fact]
    public void AltaPeliculaST7 ()
    {
        byte idproduccion = 1; 
        string Nombre = "star wars el despertar de la fuerza";
        DateTime Estreno = new DateTime(2015-12-14);
        string Descripcion = "Treinta años después de haber derrotado al Imperio, una nueva amenaza se cierne sobre la República. ";
        byte Calificacion = 6;
        TimeSpan Duracion = new TimeSpan(2, 16, 00);
        byte Restriccion = 12;
        UInt32 recaudado = 2071310218;
    
        var altaStarWars7 = new Pelicula (0, idproduccion, Nombre, Estreno, Descripcion, Calificacion,Duracion, Restriccion, recaudado)
        {
            IdProduccion = idproduccion,
            Nombre = Nombre,
            Estreno = Estreno,
            Descripcion = Descripcion,
            Calificacion = Calificacion,
            Restriccion = Restriccion,
            Recaudado = recaudado
        };

        repo.Alta(altaStarWars7);
    }

    [Fact]
    public void AltaPeliculaST8 ()
    {
        byte idproduccion = 2; 
        string Nombre = "star wars el ultimo jedi";
        DateTime Estreno = new DateTime(2015-12-15);
        string Descripcion = "Los últimos Jedi sigue a Rey mientras busca la ayuda de Luke Skywalker con la esperanza de cambiar el rumbo de la galaxia";
        byte Calificacion = 5;
        TimeSpan Duracion = new TimeSpan(2, 32, 00);
        byte Restriccion = 12;
        UInt32 recaudado =  1332539889;
    
        var altaStarWars8 = new Pelicula (0, idproduccion, Nombre, Estreno, Descripcion, Calificacion,Duracion, Restriccion, recaudado)
        {
            IdProduccion = idproduccion,
            Nombre = Nombre,
            Estreno = Estreno,
            Descripcion = Descripcion,
            Calificacion = Calificacion,
            Restriccion = Restriccion,
            Recaudado = recaudado
        };

        repo.Alta(altaStarWars8);
    }
}
