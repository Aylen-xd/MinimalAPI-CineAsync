namespace Cine.Persistencia.Dapper.Repos;

public class RepoPelicula : RepoBase, IRepoPelicula
{
    public RepoPelicula(IDbConnection conexion) : base(conexion) { }

    static readonly string updatePe =
        @"UPDATE Pelicula
        SET idProduccion = @idProduccion,
            nombre = @nombre,
            estreno = @estreno,
            descripcion = @descripcion,
            calificacion = @calificacion,
            duracion = @duracion,
            restrincion = @restrincion,
            recaudado = @recaudado
        WHERE idPelicula = @idPelicula";
    private static DynamicParameters PeliculaParametros(Pelicula pelicula)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidPelicula", direction: ParameterDirection.Output);
        parametros.Add("unidProduccion", pelicula.IdProduccion);
        parametros.Add("unnombre", pelicula.Nombre);
        parametros.Add("unestreno", pelicula.Estreno);
        parametros.Add("unadescripcion", pelicula.Descripcion);
        parametros.Add("unacalificacion", pelicula.Calificacion);
        parametros.Add("unaduracion", pelicula.Duracion);
        parametros.Add("unarestrincion", pelicula.Restriccion);
        parametros.Add("unrecaudado", pelicula.Recaudado);

        //Conexion.Execute("InsPelicula", parametros);

        //pelicula.IdPelicula = parametros.Get<byte>("unidPelicula");

        return parametros;
    }

    public IEnumerable<Pelicula> TraerElementos()
    {
        var pelicula = Conexion.Query<Pelicula>(queryProduccion);
        return pelicula;
    }

    private static readonly string queryProduccion
    = @"Select DISTINCT Pelicula.idPelicula, Pelicula.idProduccion, Pelicula.nombre, Pelicula.estreno, Pelicula.descripcion, Pelicula.calificacion, Pelicula.duracion, Pelicula.restrincion, Pelicula.recaudado
        From Pelicula
        join Produccion using (idProduccion)
        ";

    public List<Pelicula> TraerPeliProdu()
    {
        var pelicula = Conexion.Query<Pelicula, Produccion, Pelicula>
            (queryProduccion,
            (pelicula, produccion) =>
            {
                pelicula.Produccion = produccion;
                return pelicula;
            },
            splitOn: "idProduccion").ToList();
        return pelicula;
    }

    private static readonly string queryActorPelicula
        = @"
        SELECT  Actor.idActor, Actor.Nombre, Actor.Apellido, Actor.fecha_nacimiento, Actor.Sexo, Actor.Nacionalidad, Actor.Rol
        FROM    Actor_Pelicula
        JOIN    Actor USING (idActor)
        JOIN    Pelicula USING (idPelicula)
        WHERE   idPelicula = @idPelicula;
        ";

    public IEnumerable<Actor> ActoresPelicula(byte idPelicula)
    {
        var ActoresPelicula = Conexion.Query<Actor>(queryActorPelicula, new { idPelicula = idPelicula });
        return ActoresPelicula;
    }

    public void Alta(Pelicula pelicula)
    {
        DynamicParameters parametros = PeliculaParametros(pelicula);
        Conexion.Execute("InsPelicula", parametros);
        pelicula.IdPelicula = parametros.Get<byte>("unidPelicula");
    }

    public Pelicula? Detalle(byte id)
    {
        var query = @"SELECT * FROM Pelicula WHERE idPelicula = @idPelicula";
        var peliculaID = Conexion.QuerySingleOrDefault<Pelicula>(query, new { idPelicula = id });
        return peliculaID;
    }

    public void Modificar(Pelicula pelicula)
    {
        {
            DynamicParameters parametros = PeliculaParametros(pelicula);
            Conexion.Execute(updatePe, parametros);
        }
    }
    //--------Metodos Asyncronicos de la interfaz----------

    public async Task AltaAsync(Pelicula elemento)
    {
        DynamicParameters parametros = PeliculaParametros(elemento);
        await Conexion.ExecuteAsync("InsPelicula", parametros);
        elemento.IdPelicula = parametros.Get<byte>("unidPelicula");
    }

    public async Task<IEnumerable<Pelicula>> TraerElementoAsync()
    {
        var query = @"SELECT * FROM Pelicula";
        var pelicula = await Conexion.QueryAsync<Pelicula>(query);
        return pelicula;
    }

    public async Task<Pelicula?> DetalleAsync(byte id)
    {
        var query = @"SELECT * FROM Pelicula WHERE idPelicula = @idPelicula";
        var peliculaID = await Conexion.QuerySingleOrDefaultAsync<Pelicula>(query, new { idPelicula = id });
        return peliculaID;
    }

    public Task<IEnumerable<Pelicula>> TraerElementosAsync()
    {
        var query = @"SELECT * FROM Pelicula";
        var pelicula = Conexion.QueryAsync<Pelicula>(query);
        return pelicula;
    }

    public async Task ModificarAsync(Pelicula pelicula)
    {
        var parametros = new
        {
            idPelicula = pelicula.IdPelicula,
            idProduccion = pelicula.IdProduccion,
            nombre = pelicula.Nombre,
            estreno = pelicula.Estreno,
            descripcion = pelicula.Descripcion,
            calificacion = pelicula.Calificacion,
            duracion = pelicula.Duracion,
            restrincion = pelicula.Restriccion,
            recaudado = pelicula.Recaudado
        };
        await Conexion.ExecuteAsync(updatePe, parametros);
    }
}
