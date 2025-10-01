namespace Cine.Core.Persistencia;

public interface IRepoGenero : IRepoAlta<Genero>, IListado<Genero>, IRepoDetalle<Genero, byte>, IRepoModificarAsync<Genero>
{
    Task AltaAsync(Genero elemento);
    Task<IEnumerable<Genero>> TraerElementosAsync();
    Task<Genero?> DetalleAsync(byte id);
}
