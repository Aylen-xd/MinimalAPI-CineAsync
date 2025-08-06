using Cine.Core;
using Cine.Core.Persistencia;
using Cine.Persistencia.Dapper.Repos;

namespace Cine.Persistencia.Dapper.Test;
public class RepoGeneroTest : TestBase
{
    readonly IRepoGenero repo;
    public RepoGeneroTest() : base()
        => repo = new RepoGenero(Conexion);
    [Fact]
    public void TraerGenerosOK()
    {
        var repos = repo.TraerElementos();
        Assert.Contains(repos,gen => gen.Nombre == "Ficcion" && gen.IdGenero == 1);
    }

    [Fact]
    
    public void AltageneroOK () {
        string nombre = "Terror";

        var altageneroterror = new Genero () 
        {
            Nombre = nombre
        };

        repo.Alta(altageneroterror);
    }
}

