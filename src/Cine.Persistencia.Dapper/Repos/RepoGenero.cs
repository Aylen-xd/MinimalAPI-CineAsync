namespace Cine.Persistencia.Dapper.Repos;

public class RepoGenero : RepoBase, IRepoGenero
{
    public RepoGenero(IDbConnection conexion)
        : base(conexion) { }

    private static DynamicParameters ConfigurarParamestrosAltaActor(Genero elemento)
    {
        //Vamos a declara la lista de params
        var parametros = new DynamicParameters();
        parametros.Add("unidGenero", direction: ParameterDirection.Output);
        parametros.Add("ungenero", elemento.Nombre);

        //Conexion.Execute("InsGenero", parametros);

        //Voy a tomar el valor output
        //genero.IdGenero = parametros.Get<byte>("unidGenero");

        return parametros;
    }

    public void Alta(Genero elemento)
    {
        DynamicParameters parametros = ConfigurarParamestrosAltaActor(elemento);

        Conexion.Execute("InsGenero", parametros);

        elemento.IdGenero = parametros.Get<byte>("xidGenero");
    }


    public Genero? Detalle(byte id)
    {
        var query = @"SELECT idGenero, genero 'nombre' FROM Genero where idGenero = @idGenero";
        var generosID = Conexion.QuerySingleOrDefault<Genero>(query, new { idGenero = id });
        return generosID;
        //IRepoDetalle<Genero, byte>
    }

    public IEnumerable<Genero> TraerElementos()
    {
        var query = @"SELECT idGenero, genero 'nombre' FROM Genero";
        var generos = Conexion.Query<Genero>(query);
        return generos;
    }

    //-------------------------------------------Metodo async traerelementos----------------------------------------------
    public async Task<IEnumerable<Genero>> TraerElementosAsync()
    {
        var query = @"SELECT idGenero, genero 'nombre' FROM Genero";
        var genero = await Conexion.QueryAsync<Genero>(query);
        return genero;
    }

    //------------------------ Metodo Async Detalle -----------------------------
    public async Task<Genero?> DetalleAsync(byte id) //como devuleve un solo actor, es sin el IEnumearble
    {
        var query = @"SELECT idGenero, genero 'nombre' FROM Genero where idGenero = @idGenero";
        var generosID = await Conexion.QuerySingleOrDefaultAsync<Genero>(query, new { idActor = id });
        return generosID;
        //IRepoDetalle<Genero, byte>
    }

    //------------------------ Metodo Async Alta -----------------------------
        public async Task AltaAsync(Genero elemento)
    {
        DynamicParameters parametros = ConfigurarParamestrosAltaActor(elemento);

        await Conexion.ExecuteAsync("InsGenero", parametros);

        elemento.IdGenero = parametros.Get<byte>("xidGenero");
    }


}