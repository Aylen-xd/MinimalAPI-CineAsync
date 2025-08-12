using Cine.Core;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace MinimalAPI.DTOs;

public record struct ListadoActorDTO
{
    public byte Id { get; init; }
    public string Nombre { get; init; }
    public string Apellido { get; init; }
    public string Rol { get; init; }
    public ListadoActorDTO(Actor actor) =>
        (Id, Nombre, Apellido, Rol) = (actor.idActor, actor.Nombre, actor.Apellido, actor.Rol);
}

public record struct GeneroDTO(string nombre); //no se si hace falta este 

public record struct EstudioDTO(string nombre);

public record struct ProduccionDTO(string Director_General, string Productor);

