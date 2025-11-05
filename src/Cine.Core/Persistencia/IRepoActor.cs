namespace Cine.Core.Persistencia;

public interface IRepoActor : IRepoAlta<Actor>,
                                IListado<Actor>,
                                IRepoDetalle<Actor, byte>,
                                IRepoDetalleAsync<Actor, byte>,
                                IRepoAltaAsync<Actor>,
                                IRepoModificarAsync<Actor>
{
    Task<IEnumerable<Actor>> TraerElementosAsync();
    Task ModificarAsync(Actor elemento);
}
