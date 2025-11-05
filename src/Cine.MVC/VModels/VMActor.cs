using Cine.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cine.MVC.VModels;

public class VMActor
{
    public SelectList listaProducciones;
    public int IdActor { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
    public byte Sexo { get; set; }
    public string? Nacionalidad { get; set; }
    public string? Rol { get; set; }

    //public Actor Actor { get; set; } = new Actor();

    /*
                public Actor Actor =>
                    new Actor(IdActor, Nombre, Apellido);
            */
    public VMActor() { }
}
