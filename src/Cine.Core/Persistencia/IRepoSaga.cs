namespace Cine.Core.Persistencia;

public interface IRepoSaga : IRepoAlta<Saga>, IListado<Saga>, IRepoModificarAsync<Saga>, IRepoDetalle<Saga, byte>
{
    Task AltaAsync(Saga elemento);
    Task<IEnumerable<Saga>> TraerElementosAsync();
    Task ModificarAsync(Saga elemento);
    Task<Saga?> DetalleAsync(byte id);
}

