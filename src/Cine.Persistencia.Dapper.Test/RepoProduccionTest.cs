using Cine.Core;
using Cine.Core.Persistencia;
using Cine.Persistencia.Dapper.Repos;

namespace Cine.Persistencia.Dapper.Test;
public class RepoProduccionTest : TestBase
{
    readonly IRepoProduccion repo;
    public RepoProduccionTest() : base () 
       => repo = new RepoProduccion (Conexion);
       [Fact]
    public void TraerProduccionOK()
    {
        var repos = repo.TraerElementos();
        Assert.Contains(repos, prod => prod.IdProduccion == 1);
    }
    
    [Fact]
    public void AltaProduccionOK () {
        // star wars el despertar de la fuerza
        byte idestudio = 1;
        string productor = "Kathleen Kennedy";
        string director = "J.J. Abrams";
        string guion = "Lawrence Kasdan, J.J. Abrams, Michael Arndt";
        string vestuario = "Michael Kaplan";
        string sonido = "David Acord, Matthew Wood";
        string musica = "John Williams";
        decimal presupuesto = 245000000;

        var altaproStarwars7 = new Produccion (0, idestudio, productor, director, guion, vestuario, sonido, presupuesto, musica) 
        {
            IdEstudio = idestudio,
            Productor = productor,
            Director = director,
            Guion = guion,
            Vestuario = vestuario,
            Sonido = sonido,
            Musica = musica
        };    

        repo.Alta(altaproStarwars7);    
    }

    [Fact]
    public void AltaProduccion2OK () {
        // star wars the last jedi
        byte idestudio = 1;
        string productor = "Kathleen Kennedy";
        string director = "J.J. Abrams";
        string guion = "Lawrence Kasdan, J.J. Abrams, Michael Arndt";
        string vestuario = "Michael Kaplan";
        string sonido = "David Acord, Matthew Wood";
        string musica = "John Williams";
        decimal presupuesto = 317000000;

        var altaproStarwars8 = new Produccion (0, idestudio, productor, director, guion, vestuario, sonido, presupuesto, musica) 
        {
            IdEstudio = idestudio,
            Productor = productor,
            Director = director,
            Guion = guion,
            Vestuario = vestuario,
            Sonido = sonido,
            Musica = musica
        };    

        repo.Alta(altaproStarwars8);    
    
    }

    [Fact]
    public void ActualizacionProduc()
    {
        byte idestudio = 1;
        string productor = "";
        string director = "";
        string guion = "";
        string vestuario = "";
        string sonido = "";
        string musica = "";
        decimal presupuesto = 230000;

        var ActualizacionProduc = new Produccion(0, idestudio, productor, director, guion, vestuario, sonido, presupuesto, musica)
        {
            IdEstudio = idestudio,
            Productor = productor,
            Director = director,
            Guion = guion,
            Vestuario = vestuario,
            Sonido = sonido,
            Musica = musica
        };

        repo.DirectorActualiza(ActualizacionProduc, 0);
    }
}
