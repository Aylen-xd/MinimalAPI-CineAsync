namespace Cine.Core.Persistencia;

public interface IRepoGenero : IRepoAlta<Genero>, IListado<Genero>, IRepoDetalle<Genero, byte>, IRepoModificar<Genero>
{
    Task AltaAsync(Genero elemento);
    Task<IEnumerable<Genero>> TraerElementosAsync();
    Task<Genero?> DetalleAsync(byte id);

    //void Modificar(Genero elemento);
    Task ModificarAsync(Genero elemento);
    
}
