
using System.Reflection.Metadata.Ecma335;

namespace Cine.Persistencia.Dapper.Repos;

public class RepoActor : RepoBase, IRepoActor
{
    public RepoActor(IDbConnection conexion) : base(conexion) { }

    public void Alta(Actor elemento)
    {
        var parametros = new DynamicParameters();
        parametros.Add("xidActor", direction: ParameterDirection.Output);
        parametros.Add("xNombre", elemento.Nombre);
        parametros.Add("xApellido", elemento.Apellido);
        parametros.Add("xfecha_nacimiento", elemento.FNacimiento);
        parametros.Add("xsexo", elemento.Sexo);
        parametros.Add("xnacionalidad", elemento.Nacionalidad);
        parametros.Add("xrol", elemento.Rol);

        Conexion.Execute("InsActor", parametros);

        elemento.idActor = parametros.Get<byte>("xidActor");
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


}
