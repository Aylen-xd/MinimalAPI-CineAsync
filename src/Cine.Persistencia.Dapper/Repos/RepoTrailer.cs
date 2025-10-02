using Cine.Persistencia.Dapper.Repos;

namespace Cine.Persistencia.Dapper;

public class RepoTrailer : RepoBase, IRepoTrailer
{
    public RepoTrailer(IDbConnection conexion) : base(conexion)
    {
    }

    static readonly string updateTra =
        @"UPDATE Trailer
        SET idPelicula = @idPelicula,
            idGenero = @idGenero,
            nombre = @nombre,
            duracion = @duracion
        WHERE idTrailer = @idTrailer";

    //------------------------- Metodo Alta -----------------------------//

    public static DynamicParameters Trailerparametros(Trailer trailer)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidTrailer", direction: ParameterDirection.Output);
        parametros.Add("unidPelicula", trailer.IdPelicula);
        parametros.Add("unidGenero", trailer.IdGenero);
        parametros.Add("unnombre", trailer.Nombre);
        parametros.Add("unaduracion", trailer.Duracion);

        //Conexion.Execute("InsTrailer", parametros);

        //trailer.IdTrailer = parametros.Get<byte>("unidTrailer");

        return parametros;
    }

        public void Alta(Trailer trailer)
    {
        DynamicParameters parametros = Trailerparametros(trailer);
        Conexion.Execute("InsTrailer", parametros);
        trailer.IdTrailer = parametros.Get<byte>("unidTrailer");
    } 

    public IEnumerable<Trailer> TraerElementos()
    {
        var query = @"SELECT * FROM Trailer";
        var Trailer = Conexion.Query<Trailer>(query);
        return Trailer;
    }

    //------------------------- Metodo Modificar -----------------------------//

    public void Modificar(Trailer trailer)
    {
        DynamicParameters parametros = Trailerparametros(trailer);
        Conexion.Execute(updateTra, parametros);
    }

    //------------------------ Metodo Detalle -----------------------------
    public Trailer? Detalle(byte id)
    {
        var query = @"SELECT * FROM Trailer where idTrailer = @idTrailer";
        var trailerID = Conexion.QuerySingleOrDefault<Trailer>(query, new { idTrailer = id });
        return trailerID;
    }

    //------------------------ Metodo Async Alta -----------------------------
    public async Task AltaAsync(Trailer trailer)
    {
        DynamicParameters parametros = Trailerparametros(trailer);
        await Conexion.ExecuteAsync("InsTrailer", parametros);
        trailer.IdTrailer = parametros.Get<byte>("unidTrailer");
    }

    //------------------------ Metodo Async Modificar -----------------------------

    public async Task ModificarAsync(Trailer trailer)
    {
        var parametros = new
        {
            idTrailer = trailer.IdTrailer,
            idPelicula = trailer.IdPelicula,
            idGenero = trailer.IdGenero,
            nombre = trailer.Nombre,
            duracion = trailer.Duracion
        };
        await Conexion.ExecuteAsync(updateTra, parametros);
    }

    //------------------------ Metodo Async Detalle -----------------------------
    public async Task<Trailer?> DetalleAsync(byte id) //como devuleve un solo actor, es sin el IEnumearble
    {
        var query = @"SELECT * FROM Trailer where idTrailer = @idTrailer";
        var trailerID = await Conexion.QuerySingleOrDefaultAsync<Trailer>(query, new { idTrailer = id });
        return trailerID;
        //IRepoDetalle<Genero, byte>
    }

    //------------------------ Metodo Async tRAEReLEMENTOS -----------------------------
    public async Task<IEnumerable<Trailer>> TraerElementosAsync()
    {
        var query = @"SELECT * FROM Trailer";
        var trailer = await Conexion.QueryAsync<Trailer>(query);
        return trailer;
    }
}
