using System.Data;
using Cine.Core.Persistencia;
using Cine.Persistencia.Dapper.Repos;
using MySqlConnector;
using Scalar.AspNetCore;
using Cine.Core;
using Microsoft.VisualBasic;
using MinimalAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);

//  Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MySQL");

//  Registrando IDbConnection para que se inyecte como dependencia
//  Cada vez que se inyecte, se creará una nueva instancia con la cadena de conexión
builder.Services.AddScoped<IDbConnection>(sp => new MySqlConnection(connectionString));

//Cada vez que necesite la interfaz, se va a instanciar automaticamente AdoDapper y se va a pasar al metodo de la API

//estos dos no tiene dependencia de nadie
builder.Services.AddScoped<IRepoGenero, RepoGenero>();
builder.Services.AddScoped<IRepoActor, RepoActor>();



/*
//los que tiene dependencia 
builder.Services.AddScoped<IRepoTrailer, RepoTrailer>();
builder.Services.AddScoped<IRepoSaga, RepoSaga>();
builder.Services.AddScoped<IRepoEstudio, RepoEstudio>();
builder.Services.AddScoped<IRepoPelicula, RepoPelicula>();
builder.Services.AddScoped<IRepoProduccion, RepoProduccion>();
*/


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}

//Para un GET en la ruta "/todoitems", 

//no tiene dependencia------------------------------------
app.MapGet("/generos", async (IRepoGenero repo) =>
    await repo.TraerElementosAsync());

app.MapGet("/actores", async (IRepoActor repo) =>
    {
        var actores = await repo.TraerElementosAsync();
        return Results.Ok(actores.Select(a => new ListadoActorDTO(a)));
    });  //aparece el async

//----------------------------------------------

app.MapGet("/generosPorID/{id}", async (byte id,  IRepoGenero repo) =>
    await repo.DetalleAsync(id) //el metodo no acepta parametros
        is Genero xgenero
            ? Results.Ok(xgenero)
            : Results.NotFound());


app.MapGet("/actores/{id}", async (byte id, IRepoActor repo) =>
{
    var actor = await repo.DetalleAsync(id);
    return actor is not null ?
            Results.Ok(new DetalleActorDTO(actor)) :
            Results.NotFound();
});

//----------------------------------------------

app.MapPost("/genero", async (Genero xgenero, IRepoGenero repo) =>
{
    await repo.AltaAsync(xgenero);

    return Results.Created($"/genero/{xgenero.IdGenero}", xgenero);
});

app.MapPost("/actor", async (CrearActorDTO dto, IRepoActor repo) =>
{
    Actor actor
        = new(0, dto.Nombre, dto.Apellido, dto.Fecha_naciemiento, dto.Sexo, dto.Nacionalidad, dto.Rol);

    await repo.AltaAsync(actor);

    var actorDTO = new CrearActorDTO(actor);

    return Results.Created($"/actor/{actor.idActor}", dto);     
});

//-----------------------------AGREGANDO PELICULA--------------------------------------




//-----------------------------si tiene dependencia--------------------------------------
/*

app.MapGet("/estudio", (IRepoEstudio repo) =>
    repo.TraerElementos());

app.MapGet("/trailers", (IRepoTrailer repo) =>
    repo.TraerElementos());

app.MapGet("/saga", (IRepoSaga repo) =>
    repo.TraerElementos());

app.MapGet("/pelicula", (IRepoPelicula repo) =>
    repo.TraerElementos());

app.MapGet("/produccion", (IRepoProduccion repo) =>
    repo.TraerElementos());

*/
//-----------------------------------------------------------

app.Run();








//----------------------------------------------

//Actuializa todo el genero, pero no usamos put en este caso
/*app.MapPut("/genero/{id}", async (int id, Genero inputxgenero, IRepoGenero repo) =>
{
    var xgenero = repo.ObtenerTodoPorId(id);

    if (xgenero is null) return Results.NotFound();

    xgenero.Nombre = inputxgenero.Nombre;
    //xgenero.IsComplete = inputTodo.IsComplete;

    repo.ActualizarTodo(xgenero);

    return Results.NoContent();
});
*/

/* 
app.MapDelete("/genero/{id}", (int id, IRepoGenero repo) =>
{
    if (repo.ObtenerTodoPorId(id) is Genero xgenero)
    {
        await repo.EliminarTodo(xgenero);
        return Results.NoContent();
    }

    return Results.NotFound();
});
*/
