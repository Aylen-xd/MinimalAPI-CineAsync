using System.Data;
using Cine.Core;
using Cine.Core.Persistencia;
using Cine.Persistencia.Dapper.Repos;

namespace Cine.Persistencia.Dapper.Test;

public class RepoEstudioTest : TestBase
{
    readonly IRepoEstudio repo;
    public RepoEstudioTest() : base() => repo = new RepoEstudio(Conexion);
    [Fact]

    public void TraerEstudiosOK()
    {
        var repos = repo.TraerElementos();
        Assert.Contains(repos, est => est.Nombre == "Disney" && est.IdEstudio == 1);
    }

    /*[Fact]
    public void AltaEstudioOK()
    {
        string nombre = "Pixar";
        DateTime fundacion = new DateTime(1986, 02, 13);

        var altaestudiopixar = new Estudio(0, nombre, fundacion)
        {
            Nombre = nombre,
            Fundacion = fundacion
        };

        repo.Alta(altaestudiopixar);
    }*/

    [Fact]
    public void BorrarEstudioExcep()
    {
        byte idestudio = 3;

        /*Al saberse que va a dar error, se almacena dentro de la var excep, que esto va a dar error, 
        <ConstraintException> alamacena la restriccion del try/catch, y se le pasa el metodo que se va a ejecutar
        Por ultimo se asegura que la excepcion contenga el mensaje :)*/
        var excep = Assert.Throws<ConstraintException>(() => repo.Borrar(idestudio));
        Assert.Contains("No se puede eliminar", excep.Message);
    }
}

