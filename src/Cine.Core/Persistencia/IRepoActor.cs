namespace Cine.Core.Persistencia;

public interface IRepoActor : IRepoAlta<Actor>, IListado<Actor>, IRepoDetalle<Actor, byte>, IRepoDetalleAsync<Actor, byte>
{
    Task<IEnumerable<Actor>> TraerElementosAsync();
    Task AltaAsync(Actor elemento);
}
