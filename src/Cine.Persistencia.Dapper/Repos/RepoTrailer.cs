using Cine.Persistencia.Dapper.Repos;

namespace Cine.Persistencia.Dapper;

public class RepoTrailer : RepoBase, IRepoTrailer
{
    public RepoTrailer(IDbConnection conexion) : base(conexion)
    {
    }

    public void Alta(Trailer trailer)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidTrailer", direction: ParameterDirection.Output);
        parametros.Add("unidPelicula", trailer.IdPelicula);
        parametros.Add("unidGenero", trailer.IdGenero);
        parametros.Add("unnombre", trailer.Nombre);
        parametros.Add("unaduracion", trailer.Duracion);

        Conexion.Execute("InsTrailer", parametros);

        trailer.IdTrailer = parametros.Get<byte>("unidTrailer");
    }

    public IEnumerable<Trailer> TraerElementos()
    {
        var query = @"SELECT * FROM Trailer";
        var Trailer = Conexion.Query<Trailer>(query);
        return Trailer;
    }
}
