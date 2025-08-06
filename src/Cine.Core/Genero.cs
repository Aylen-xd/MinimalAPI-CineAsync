namespace Cine.Core;

public class Genero
{
    public Genero(byte idGenero = 0, string nombre = "")
    {
        IdGenero = idGenero;
        Nombre = nombre;
    }

    public byte IdGenero { get ; set ; }
    public string Nombre { get ; set ; }
    
}
