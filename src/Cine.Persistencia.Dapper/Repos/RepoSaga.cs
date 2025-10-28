using System.Diagnostics.CodeAnalysis;

namespace Cine.Persistencia.Dapper.Repos;

public class RepoSaga : RepoBase, IRepoSaga
{
    public RepoSaga(IDbConnection conexion) : base(conexion)
    {
    }
    static readonly string UpdSaga =
        @"UPDATE Saga
        SET Numero_Saga = @unNumero_Saga,
            idPelicula = @unidPelicula,
            Nombre = @unnombre
        WHERE idSaga = @unidsaga";
    public static DynamicParameters SagaParametros(Saga saga)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidsaga", direction: ParameterDirection.Output);
        parametros.Add("unNumero_Saga", saga.NSaga);
        parametros.Add("unidpelicula", saga.IdPelicula);
        parametros.Add("unnombre", saga.NombreSaga);

        //Conexion.Execute("insSaga", parametros);

        //saga.IdSaga = parametros.Get<byte>("unidsaga");

        return parametros;
    }

    public IEnumerable<Saga> TraerElementos()
    {
        var query = @"SELECT * FROM Saga";
        var saga = Conexion.Query<Saga>(query);
        return saga;
    }

    public Saga? Detalle(byte id)
    {
        var query = @"Select * FROM Saga WHERE idSaga = @unidsaga";
        var saga = Conexion.QuerySingleOrDefault<Saga>(query, new { idSaga = id });
        return saga;
    }

    public void Modifiar(Saga saga)
    {
        DynamicParameters parametros = SagaParametros(saga);
        Conexion.Execute(UpdSaga, parametros);
    }

    public void Alta(Saga saga)
    {
        DynamicParameters parametros = SagaParametros(saga);
        Conexion.Execute("InsSaga", parametros);
        saga.IdSaga = parametros.Get<byte>("unidsaga");
    }

    //---------------------Metodos Async----------------------------

    public async Task ModificarAsync(Saga saga)
    {
        var parametros = new
        {
            unidsaga = saga.IdSaga,
            unNumero_Saga = saga.NSaga,
            unidPelicula = saga.IdPelicula,
            unnombre = saga.NombreSaga
        };
        await Conexion.ExecuteAsync(UpdSaga, parametros);
    }

    public async Task<Saga?> DetalleAsync(byte id)
    {
        var Query = @"SELECT * FROM Saga where IdSaga = @unidsaga";
        var SagaID = await Conexion.QuerySingleOrDefaultAsync<Saga>(Query, new { idSaga = id });
        return SagaID;
    }

    public async Task<IEnumerable<Saga>> TraerElementosAsync()
    {
        var query = @"SELECT * FROM Saga";
        var saga = await Conexion.QueryAsync<Saga>(query);
        return saga; 
    }

    public async Task AltaAsync(Saga saga)
    {
        DynamicParameters parametros = SagaParametros(saga);
        await Conexion.ExecuteAsync("InsSaga", parametros);
        saga.IdSaga = parametros.Get<byte>("unidsaga");
    }
}
