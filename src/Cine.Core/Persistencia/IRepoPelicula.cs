namespace Cine.Core.Persistencia;

public interface IRepoPelicula :IRepoAlta<Pelicula>,
                                IListado<Pelicula>,
                                IRepoDetalleAsync<Pelicula, byte>,
                                IRepoAltaAsync<Pelicula>,
                                IListadoAsync<Pelicula>, 
			                    IRepoModificarAsync<Pelicula>

{
    IEnumerable<Actor> ActoresPelicula(byte idPelicula);    
    Task AltaAsync(Pelicula elemento);
    Task<IEnumerable<Pelicula>> TraerElementosAsync();
    Task<Pelicula?> DetalleAsync(byte id);
}

