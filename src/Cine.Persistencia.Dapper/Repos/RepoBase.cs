using System.Data;
namespace Cine.Persistencia.Dapper.Repos;

public abstract class RepoBase
{
    protected readonly IDbConnection Conexion;
    protected RepoBase(IDbConnection conexion) => Conexion = conexion;
}
