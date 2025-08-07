namespace Cine.Core.Persistencia;

public interface IListado<T>
{
    IEnumerable<T> TraerElementos();
}

public interface IListadoAsync<T>
{
    Task<IEnumerable<T>> TraerElementoAsync();
}

