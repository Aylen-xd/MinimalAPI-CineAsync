namespace Cine.Core.Persistencia;

public interface IRepoPelicula: IRepoAlta<Pelicula>, IListado<Pelicula>
{
    IEnumerable<Actor> ActoresPelicula (byte idPelicula);
}
