namespace Cine.Core.Persistencia;

public interface IRepoPelicula : IRepoAlta<Pelicula>, IListado<Pelicula>, IRepoDetalleAsync<Pelicula, byte>
{
    IEnumerable<Actor> ActoresPelicula(byte idPelicula);
    
    Task AltaAsync(Pelicula elemento);
}
