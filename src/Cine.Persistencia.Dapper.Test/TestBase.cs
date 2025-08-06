using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Cine.Persistencia.Dapper.Test;
public abstract class TestBase
{
    protected readonly IDbConnection Conexion;
    public TestBase() : this ("MySQL") { }
    public TestBase(string nombreConexion)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
            .Build();
        string cadena = config.GetConnectionString(nombreConexion)!;
        Conexion = new MySqlConnection(cadena);
    }
}
