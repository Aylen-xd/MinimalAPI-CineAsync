
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace Cine.Persistencia.Dapper.Repos;

public class RepoActor : RepoBase, IRepoActor
{
    public RepoActor(IDbConnection conexion) : base(conexion) { }

    private static DynamicParameters ConfigurarParamestrosAltaActor(Actor elemento)
    {
        var parametros = new DynamicParameters();
        parametros.Add("xidActor", direction: ParameterDirection.Output);
        parametros.Add("xNombre", elemento.Nombre);
        parametros.Add("xApellido", elemento.Apellido);
        parametros.Add("xfecha_nacimiento", elemento.FNacimiento);
        parametros.Add("xsexo", elemento.Sexo);
        parametros.Add("xnacionalidad", elemento.Nacionalidad);
        parametros.Add("xrol", elemento.Rol);

        //elemento.idActor = parametros.Get<byte>("xidActor");

        return parametros;
    }

    public void Alta(Actor elemento)
    {
        {
        //Es una clase Dapper para parametros o procedmientos almacenados
        DynamicParameters parametros = ConfigurarParamestrosAltaActor(elemento); //Este metodo llena los parametros que necesita cuando se ingresa un actor

        Conexion.Execute("InsActor", parametros); //Ejecuta el proceso almacenado en la base de datos InsActor (se encuentra en MySQL)

        elemento.idActor = parametros.Get<byte>("xidActor");
    }

    }

    public IEnumerable<Actor> TraerElementos()
    {
        //Hacer la query de select actores.
        var query = @"SELECT idActor, Nombre, Apellido, fecha_nacimiento 'fnacimiento', sexo, nacionalidad, rol  FROM Actor";
        var Actor = Conexion.Query<Actor>(query);
        return Actor;
    }

    public Actor? Detalle(byte id)
    {
        var query = @"SELECT idActor, Nombre, Apellido, fecha_nacimiento 'fnacimiento', sexo, nacionalidad, rol FROM Actor where idActor = @idActor";
        var actorID = Conexion.QuerySingleOrDefault<Actor>(query, new { idActor = id });
        return actorID;
        //IRepoDetalle<Genero, byte>
    }

    /*Filtrar las peliculas que participo x artor/actriz*/
    /*ELiminar una pelicula (lo que conyeva a borrar todo)*/
    /*Update de calificacion de clientes*/
    /*Hacer algo que el cliente no pueda hacer y que salte error pero que no salga error.*/
    /*Lo mismo que el anterior pero con director con estudio*/

    //-------------------------------------------Metodo async----------------------------------------------
    public async Task AltaAsync(Actor elemento)
    {
        //throw new NotImplementedException();
        DynamicParameters parametros = ConfigurarParamestrosAltaActor(elemento);
        //este metodo privado que prepara los elementos que insActor necesita
        //elemetos: son los valores de xnombre, xapellido, etc

        await Conexion.ExecuteAsync("InsActor", parametros);

        //Cuando termina la tarea, recupera el valor de salida de xidActor y lo guarda en <elementos>  
        elemento.idActor = parametros.Get<byte>("xidActor");
    }


    //se declara como variable para ser usada despues por los metodos que la necesitan

    //------------------------ Metodo Async TraerElementos -----------------------------
    public async Task<IEnumerable<Actor>> TraerElementosAsync()
    {
        var query = @"SELECT idActor, Nombre, Apellido, fecha_nacimiento 'fnacimiento', sexo, nacionalidad, rol FROM Actor where idActor = @idActor";
        var Actor = await Conexion.QueryAsync<Actor>(query);
        return Actor;
    }

    //------------------------ Metodo Async Detalle -----------------------------
    public async Task<Actor?> DetalleAsync(byte id) //como devuleve un solo actor, es sin el IEnumearble
    {
        var query = @"SELECT idActor, Nombre, Apellido, fecha_nacimiento 'fnacimiento', sexo, nacionalidad, rol FROM Actor where idActor = @idActor";
        var actorID = await Conexion.QuerySingleOrDefaultAsync<Actor>(query, new { idActor = id });
        return actorID;
        //IRepoDetalle<Genero, byte>
    }
}
