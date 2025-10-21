namespace Cine.Core.Persistencia;

public interface IRepoProduccion : IRepoAlta<Produccion>, IListado<Produccion>, IRepoDetalle<Produccion, byte>, IRepoModificar<Produccion>, IRepoModificarAsync<Produccion>
{
    IEnumerable<Produccion> DirectorActualiza(Produccion actualizacionProduc, byte unidProduccion);
    Task AltaAsync(Produccion elemento);
    Task<IEnumerable<Produccion>> TraerElementosAsync();
    Task<Produccion?> DetalleAsync(byte id);
}
