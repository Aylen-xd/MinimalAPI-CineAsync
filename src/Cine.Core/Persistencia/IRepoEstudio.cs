namespace Cine.Core.Persistencia;

public interface IRepoEstudio : IRepoAlta<Estudio>, IListado<Estudio>, IRepoDetalle<Estudio, byte>, IRepoModificar<Estudio>, IRepoModificarAsync<Estudio>
{
    /*Metodo que implementa el repo para Borrar.*/
    void Borrar(byte idestudio);
    Task AltaAsync(Estudio elemento);
    Task<IEnumerable<Estudio>> TraerElementosAsync();
    Task<Estudio?> DetalleAsync(byte id);
}
