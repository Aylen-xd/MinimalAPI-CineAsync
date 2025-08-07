namespace Cine.Core.Persistencia;

public interface IRepoGenero : IRepoAlta<Genero>, IListado<Genero>, IRepoDetalle<Genero, byte>
{
    Task AltaAsync(Genero elemento);
    Task<IEnumerable<Genero>> TraerElementosAsync();
    Task<Genero?> DetalleAsync(byte id);
    
}
