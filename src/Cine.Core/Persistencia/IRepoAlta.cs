namespace Cine.Core.Persistencia;

public interface IRepoAlta<T>
{
    void Alta(T elemento);
}
public interface IRepoAltaAsync<T>
{
    Task AltaAsync(T elemento);
}

