public IEnumerable<(string Estudio, decimal PresupuestoPromedio)> CPresuxEstudio()
{
    var query = @"
        SELECT Estudio.Nombre AS Estudio, AVG(Produccion.Presupuesto) AS Presupuesto_Promedio
        FROM Estudio
        LEFT JOIN Produccion ON Estudio.idEstudio = Produccion.idEstudio
        GROUP BY Estudio.Nombre
        ORDER BY Presupuesto_Promedio DESC";

    var resultados = Conexion.Query<(string Estudio, decimal PresupuestoPromedio)>(query);
    return resultados;
}


[Fact]
public void TraerPresupuestoPromedioPorEstudioOK()
{
    var repos = repo.CPresuxEstudio();
    Assert.Contains(repos, r => r.Estudio == "Disney" && r.PresupuestoPromedio > 0);
}

/*---------------------------------------------------------------------------------*/

public IEnumerable<Actor> ConsultaActores()
{
    var query = @"
        SELECT CONCAT(nombre, ' ', apellido) AS NombreCompleto, fecha_nacimiento
        FROM Actor
        WHERE YEAR(fecha_nacimiento) >= 2000";
    
    var actores = Conexion.Query<Actor>(query);
    return actores;
}

[Fact]
public void ConsultaActoresOK()
{
    var repos = repo.TraerActoresNacidosDesde2000();
    
    Assert.Contains(repos, act => act.Nombre == "Mackenzie" && act.fecha_nacimiento.Year >= 2000);
}

/*------------------------------------------------------------------------------*/
/*Este */
    [Fact]
    public void BorrarEstudioOK()
    {
        repo.Borrar(idestudio);

        var repos = repo.TraerElementos();
        Assert.DoesNotContain(repos, est => est.IdEstudio == idestudio);
    }


    public void Borrar(byte idEstudio)
    {
        using var conexion = ObtenerConexion();
        var query = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";
        conexion.Execute(query, new { IdEstudio = idEstudio });
    }

/*------------------------------------------------------------------------------*/

public void ActualizarPresupuesto(byte idPelicula, decimal nuevoPresupuesto)
{
    var parametros = new DynamicParameters();
    parametros.Add("unidPelicula", idPelicula);
    parametros.Add("unrecaudado", nuevoPresupuesto);

    Conexion.Execute("procedure", parametros);
}


[Fact]
public void ActualizarPresupuestoOK()
{
    byte idPelicula = 1; 
    decimal nuevoPresupuesto = 100000000; 
    repo.ActualizarPresupuesto(idPelicula, nuevoPresupuesto);

    var repos = repo.TraerElementos();
    Assert.Contains(repos, peli => peli.IdPelicula == idPelicula && peli.Recaudado == nuevoPresupuesto);

}