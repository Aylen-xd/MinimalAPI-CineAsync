namespace Cine.Core.Persistencia;

public interface IRepoAlta<T>
{
    void Alta(T elemento);
}
public interface IRepoAltaAsync<T>
{
    Task AltaAsync(T elemento);
}
public interface IRepoModificar<T>
{
    void Modificar(T elemento);
}
public interface IRepoModificarAsync<T>
{
    Task ModificarAsync(T elemento);
}

