using System.Numerics;
namespace Cine.Core.Persistencia;
/// <summary>
/// Interfaz que defini obtener un elemento por un indice simple
/// </summary>
/// <typeparam name="TE">Tipo de elemento a traer</typeparam>
/// <typeparam name="TI">Tipo del indice a filtrar, es numerico y simple</typeparam>
public interface IRepoDetalle<TE, TI> where TI: IBinaryNumber<TI>
{
    TE? Detalle(TI indiceSimple);
}
