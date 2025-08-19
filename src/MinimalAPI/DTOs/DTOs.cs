using Cine.Core;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace MinimalAPI.DTOs;

//-----------------------GET ACTOR-------------------------------------
public record struct ListadoActorDTO  //actor ya esta en el program API
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public string Apellido { get; init; }
    public string Rol { get; init; }
    public ListadoActorDTO(Actor actor) =>
        (Id, Nombre, Apellido, Rol) = (actor.idActor, actor.Nombre, actor.Apellido, actor.Rol);
}

//-----------------------GET DETALLE ACTOR-------------------------------------
public record struct DetalleActorDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public string Apellido { get; init; }
    public string Nacionalidad { get; init; }
    public DateTime Fecha_nacieminto { get; init; }
    public char Sexo { get; init; }
    public string Rol { get; init; }

    public DetalleActorDTO(Actor actor) =>
        (Id, Nombre, Apellido, Nacionalidad, Fecha_nacieminto, Sexo, Rol) = (actor.idActor, actor.Nombre, actor.Apellido, actor.Nacionalidad, actor.FNacimiento, actor.Sexo, actor.Rol);
}

//-----------------------POST ACTOR-------------------------------------
public record struct CrearActorDTO
{
    public string Nombre { get; init; }
    public string Apellido { get; init; }
    public string Nacionalidad { get; init; }
    public DateTime Fecha_naciemiento { get; init; }
    public char Sexo { get; init; }
    public string Rol { get; init; }

    public CrearActorDTO(Actor actor) =>
        (Nombre, Apellido, Nacionalidad, Fecha_naciemiento, Sexo, Rol) = (actor.Nombre, actor.Apellido, actor.Nacionalidad, actor.FNacimiento, actor.Sexo, actor.Rol);
}

//public record struct GeneroDTO(string nombre); //no se si hace falta este 

//-----------------------POST PELICULA-------------------------------------
public record struct ListadoPeliculaDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public string Descripcion { get; init; }
    public byte Calificacion { get; init; }
    public TimeSpan Duracion { get; set; }

    public ListadoPeliculaDTO(Pelicula pelicula) =>
        (Id, Nombre, Descripcion, Calificacion, Duracion) = (pelicula.IdPelicula, pelicula.Nombre, pelicula.Descripcion, pelicula.Calificacion, pelicula.Duracion);
}

//-----------------------GET DETALLE PELICULA-------------------------------------
public record struct DetallePeliculaDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public string Descripcion { get; init; }
    public TimeSpan Duracion { get; init; }
    public byte Calificacion { get; init; }
    public byte Restrincion { get; init; }
    public UInt64 Recaudado { get; init; }

    public DetallePeliculaDTO(Pelicula pelicula) =>
        (Id, Nombre, Descripcion, Duracion, Calificacion, Restrincion, Recaudado) = (pelicula.IdPelicula, pelicula.Nombre, pelicula.Descripcion, pelicula.Duracion, pelicula.Calificacion, pelicula.Restriccion, pelicula.Recaudado);
}

//-----------------------POST PELICULA-------------------------------------
public record struct CrearPeliculaDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public string Descripcion { get; init; }
    public TimeSpan Duracion { get; init; }
    public byte Calificacion { get; init; }
    public byte Restrincion { get; init; }
    public UInt64 Recaudado { get; init; }

    public CrearPeliculaDTO(Pelicula pelicula) =>
        (Id, Nombre, Descripcion, Duracion, Calificacion, Restrincion, Recaudado) = (pelicula.IdPelicula, pelicula.Nombre, pelicula.Descripcion, pelicula.Duracion, pelicula.Calificacion, pelicula.Restriccion, pelicula.Recaudado);
}



//-----------------------ESTAN EN LA API-------------------------------------

//---------------------------------------------------------------
public record struct ListadoEstudioDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }

    public ListadoEstudioDTO(Estudio estudio) =>
        (Id, Nombre) = (estudio.IdEstudio, estudio.Nombre);
}

public record struct ListadoProduccionDTO
{
    public byte Id { get; init; }
    public string Director_General { get; init; }
    public string Productor { get; init; }

    public ListadoProduccionDTO(Produccion produccion) =>
        (Id, Director_General, Productor) = (produccion.IdProduccion, produccion.Director, produccion.Productor);
}

public record struct ListadoSagaDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }

    public ListadoSagaDTO(Saga saga) =>
        (Id, Nombre) = (saga.IdSaga, saga.NombreSaga);
}

public record struct LisatdoTrailerDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public TimeSpan Duracion { get; init; }

    public LisatdoTrailerDTO(Trailer trailer) =>
        (Id, Nombre, Duracion) = (trailer.IdTrailer, trailer.Nombre, trailer.Duracion);
}

//---------------------------------------------------------------




