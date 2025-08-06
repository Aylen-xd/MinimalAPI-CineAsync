namespace Cine.Core.Persistencia;
public interface IListado<T>
{
    IEnumerable<T> TraerElementos();
}
