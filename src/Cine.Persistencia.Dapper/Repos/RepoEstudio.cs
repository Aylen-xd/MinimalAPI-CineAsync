namespace Cine.Persistencia.Dapper.Repos;

public class RepoEstudio:RepoBase, IRepoEstudio
{
    //private string queryEstudio;

    public RepoEstudio(IDbConnection conexion)
        : base(conexion) { }

    public static DynamicParameters EstudioParametros(Estudio estudio)
    {
        var parametros = new DynamicParameters();
        parametros.Add("xidEstudio", direction: ParameterDirection.Output);
        parametros.Add("xnombre", estudio.Nombre);
        parametros.Add("xfundacion", estudio.Fundacion);

        //Conexion.Execute("InsEstudio", parametros);

        //estudio.IdEstudio = parametros.Get<byte>("xidEstudio");
        return parametros;
    }

    public IEnumerable<Estudio> TraerElementos()
    {
        var query = @"SELECT * FROM Estudio";
        var estudios = Conexion.Query<Estudio>(query);
        return estudios;    
    }

    public Estudio? Detalle(byte id)
    {
        var query = @"SELECT * FROM Estudio WHERE IdEstudio = @IdEstudio";
        var estudio = Conexion.QuerySingleOrDefault<Estudio>(query, new { IdEstudio = id });
        return estudio;
    }

    /*mtd query de peliculas segun estudio y genero*/
    public List<Pelicula> mtdPeliculaEstudio (string elgenero, string elestudio)
    {
        var query = @"select Pelicula.nombre, restrincion, descripcion, Pelicula.duracion, Director_General 
                        from Produccion
                        join Pelicula using (idProduccion)
                        join Trailer using (idPelicula)
                        join Genero using (idGenero)
                        join Estudio using (idEstudio)
                        where genero = @genero and Estudio.nombre = @nombre";
        
        try
        {
            Conexion.Execute(query, new {genero = elgenero, nombre = elestudio});
            var peliEstudioGenero = Conexion.Query<Pelicula>(query);
            return (List<Pelicula>)peliEstudioGenero;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public void Borrar(byte idEstudio)
    {
        var query = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";
        /*try ejecuta la query*/
        try
        {
            Conexion.Execute(query, new { IdEstudio = idEstudio });
        }
        /*Se consulta si la excepcion contiene el mensaje del trigger y se lo alamacena en la ConstraintException ese mensaje.*/
        catch (Exception e)
        {
            if (e.Message.Contains("No se puede eliminar el estudio"))
                throw new ConstraintException(e.Message, e);
        }
    }
    public void Alta(Estudio elemento)
    {
        var parametros = EstudioParametros(elemento);
        Conexion.Execute("InsEstudio", parametros, commandType: CommandType.StoredProcedure);
        elemento.IdEstudio = parametros.Get<byte>("xidEstudio");
    }

    public void Modificar(Estudio elemento)
    {
        DynamicParameters parametros = EstudioParametros(elemento);
        //var query = @"UPDATE Estudio SET nombre = @nombre, fundacion = @fundacion WHERE idEstudio = @idEstudio";
        Conexion.Execute("UpdEstudio", elemento);
    }

    //-----------------------------------------Metodos Asincronicos-----------------------------------------//

    public async Task ModificarAsync(Estudio elemento)
    {
        var parametros = new
        {
            elemento.IdEstudio,
            elemento.Nombre,
            elemento.Fundacion
        };
        await Conexion.ExecuteAsync("UpdEstudio", parametros);
    
    }

    public async Task<IEnumerable<Estudio>> TraerElementosAsync()
    {
        var query = @"SELECT * FROM Estudio";
        var estudios = await Conexion.QueryAsync<Estudio>(query);
        return estudios;
    }
    public async Task<Estudio?> DetalleAsync(byte id)
    {
        var query = @"SELECT * FROM Estudio WHERE IdEstudio = @IdEstudio";
        var estudio = await Conexion.QuerySingleOrDefaultAsync<Estudio>(query, new { IdEstudio = id });
        return estudio;
    }
    public async Task AltaAsync(Estudio elemento)
    {
        var parametros = EstudioParametros(elemento);
        await Conexion.ExecuteAsync("InsEstudio", parametros);
        elemento.IdEstudio = parametros.Get<byte>("xidEstudio");
    }
}


