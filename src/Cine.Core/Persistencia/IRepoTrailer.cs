namespace Cine.Core.Persistencia;

public interface IRepoTrailer : IRepoAlta<Trailer>, IListado<Trailer>, IRepoModificarAsync<Trailer>, IRepoDetalle<Trailer, byte>
{
    Task AltaAsync(Trailer elemento);
    Task<IEnumerable<Trailer>> TraerElementosAsync();
    Task ModificarAsync(Trailer elemento);
    Task<Trailer?> DetalleAsync(byte id);
}
