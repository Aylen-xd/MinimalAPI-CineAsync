namespace Cine.Core.Persistencia;

public interface IRepoPelicula :IRepoAlta<Pelicula>,
                                IListado<Pelicula>,
                                IRepoDetalleAsync<Pelicula, byte>,
                                IRepoAltaAsync<Pelicula>,
                                IListadoAsync<Pelicula>
{
    IEnumerable<Actor> ActoresPelicula(byte idPelicula);    
}
