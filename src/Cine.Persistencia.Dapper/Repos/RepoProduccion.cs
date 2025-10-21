

namespace Cine.Persistencia.Dapper.Repos;

public class RepoProduccion : RepoBase, IRepoProduccion
{
    public RepoProduccion(IDbConnection conexion) : base(conexion)
    {
    }
    static readonly string updateProd =
        @"UPDATE Produccion
        SET Director_General = @director,
            Guion = @guion,
            Productor = @productor,
            Vestuario = @vestuario,
            Sonido = @sonido,
            Presupuesto = @presupuesto,
            Musica = @musica
        WHERE idProduccion = @idProduccion";

    private static DynamicParameters ConfigurarParametrosProdu(Produccion produccion)
    {
        var parametros = new DynamicParameters();
        parametros.Add("unidProduccion", direction: ParameterDirection.Output);
        parametros.Add("unidEstudio", produccion.IdEstudio);
        parametros.Add("unDirector_General", produccion.Director);
        parametros.Add("unGuion", produccion.Guion);
        parametros.Add("unProductor", produccion.Productor);
        parametros.Add("unVestuario", produccion.Vestuario);
        parametros.Add("unSonido", produccion.Sonido);
        parametros.Add("unPresupuesto", produccion.Presupuesto);
        parametros.Add("unaMusica", produccion.Musica);

        return parametros;
        //Conexion.Execute("InsProduccion", parametros);

        //produccion.IdProduccion = parametros.Get<byte>("unidProduccion");
    }

    public IEnumerable<Produccion> TraerElementos()
    {
        var query = @"SELECT * FROM Produccion";
        var producciones = Conexion.Query<Produccion>(query);
        return producciones;
    }

    public IEnumerable<Produccion> DirectorActualiza(Produccion produccion, byte unidProduccion)
    {
        var Query = @"UPDATE Produccion
                    set Director_General = unDirector, Productor = unProductor, Guion = unGuion, Musica = unaMusica, Presupuesto = unPresuppuesto, Sonido = unSonido, Vestuario = unVestuario
                    WHERE idProduccion = @idProduccion";

        var actualizaciones = Conexion.Query<Produccion>(Query, new { idProduccion = produccion });
        return actualizaciones;
    }

    public void Alta(Produccion produccion)
    {
        DynamicParameters parametros = ConfigurarParametrosProdu(produccion);

        Conexion.Execute("InsProduccion", parametros);

        produccion.IdProduccion = parametros.Get<byte>("unidProduccion");
    }

    public void Modificar(Produccion produccion)
    {
        DynamicParameters parametros = ConfigurarParametrosProdu(produccion);
        Conexion.Execute("UpdProduccion", parametros);

    }

    public Produccion? Detalle(byte id)
    {
        var query = @"SELECT * FROM Produccion where idProduccion = @idProduccion";
        var produccionesID = Conexion.QuerySingleOrDefault<Produccion>(query, new { idProduccion = id });
        return produccionesID;
    }
    //-------------------------------------------Metodo async traerelementos----------------------------------------------
    public async Task<IEnumerable<Produccion>> TraerElementosAsync()
    {
        var query = @"SELECT * FROM Produccion";
        var produccion = await Conexion.QueryAsync<Produccion>(query);
        return produccion;
    }

    public async Task<Produccion?> DetalleAsync(byte id)
    {
        var query = @"SELECT * FROM Produccion where idProduccion = @idProduccion";
        var produccionesID = await Conexion.QuerySingleOrDefaultAsync<Produccion>(query, new { idProduccion = id });
        return produccionesID;
    }

    public async Task AltaAsync(Produccion produccion)
    {
        DynamicParameters parametros = ConfigurarParametrosProdu(produccion);

        await Conexion.ExecuteAsync("InsProduccion", parametros);

        produccion.IdProduccion = parametros.Get<byte>("unidProduccion");
    }

    public async Task ModificarAsync(Produccion produccion)
    {
        var parametros = new
        {
            idProduccion = produccion.IdProduccion,
            director = produccion.Director,
            guion = produccion.Guion,
            productor = produccion.Productor,
            vestuario = produccion.Vestuario,
            sonido = produccion.Sonido,
            presupuesto = produccion.Presupuesto,
            musica = produccion.Musica
        };
        await Conexion.ExecuteAsync(updateProd, parametros);
    }
}
