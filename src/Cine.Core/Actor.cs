namespace Cine.Core;
public class Actor
{
    //A parameterless default constructor or one matching signature (System.String Nombre, System.String Apellido, System.DateTime fecha_nacimiento, System.String Sexo, System.String Nacionalidad, System.String Rol) is required for Cine.Core.Actor
    public Actor (byte idactor, string nombre, string apellido, DateTime fnacimiento, char sexo ,string nacionalidad ,string rol)
    {
        idActor = idactor;
        Nombre = nombre;
        Apellido = apellido;
        FNacimiento = fnacimiento;
        Sexo = sexo;
        Nacionalidad = nacionalidad;
        Rol = rol;
    }

    public byte idActor { get ; set ; }
    public string Nombre { get ; set ; }
    public string Apellido { get ; set ; }
    public DateTime FNacimiento { get ; set ; }
    public char Sexo { get ; set ; }
    public string Nacionalidad { get ; set ; }
    public string Rol { get ; set ; }
}