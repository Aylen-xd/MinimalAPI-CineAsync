-- Active: 1729186022063@@127.0.0.1@3306@5to_Pelicula
Use 5to_Pelicula;

-- Cuanto dinero ganaron las peliculas (presupuesto - recaudación). Mostrar solo el nombre y dinero ganado de las películas que superen los 100,000,000. Ordenar de mayor a menor
SELECT nombre, (recaudado - Presupuesto) AS ganancia 
FROM Pelicula
INNER JOIN Produccion ON Pelicula.idProduccion = Produccion.idProduccion
WHERE (recaudado - Presupuesto) >  100000000
ORDER BY ganancia DESC;


-- Mostrar el nombre de la película junto con su trailer siendo del género fantasía y sus duraciones
SELECT p.nombre AS 'Titulo Pelicula',p.duracion AS 'Duracion Pelicula', t.nombre AS 'Titulo Trailer Pelicula', t.duracion AS 'Duracion Trailer'
FROM Trailer t
JOIN Pelicula p ON p.idPelicula = t.idPelicula 
JOIN Genero g ON g.idGenero = t.idGenero
WHERE g.Genero = 'Fantasia';

-- Mostrar nombre y fecha de nacimiento de los actores nacidos a partir del año 2000
SELECT concat(nombre, apellido) 'Actrices', fecha_nacimiento 'Nacimineto'
FROM actor
WHERE YEAR(fecha_nacimiento) >= 2000; 

-- Mostrar de mayor a menor el presupuesto de cada película junto con su nombre
SELECT p.nombre AS 'Nombre Pelicula', pr.presupuesto AS 'Presupuesto Produccion'
FROM Produccion pr
INNER JOIN Pelicula p ON pr.idProduccion = p.idProduccion
ORDER BY pr.presupuesto DESC;

-- Mostrar el nombre del actor que se repita en más de una película
SELECT concat(nombre,  apellido) AS 'Nombre Completo', COUNT(*) AS 'pelis'
FROM Actor
GROUP BY nombre
HAVING COUNT(*) > 1;

-- Consultas propias

-- Promedio de edad de las distintas peliculas de los elencos mas viejo a la mas joven. 

SELECT pelicula.nombre AS Pelicula, AVG(YEAR(CURDATE()) - YEAR(actor.fecha_nacimiento)) AS PromedioEdad
FROM pelicula
INNER JOIN actor ON pelicula.idPelicula = actor.idPelicula
GROUP BY pelicula.nombre 
order by PromedioEdad DESC;

-- Presupuesto de peliculas por estudios

SELECT Estudio.Nombre AS Estudio, AVG(Produccion.Presupuesto) AS Presupuesto_Promedio
FROM Estudio
LEFT JOIN Produccion ON Estudio.idEstudio = Produccion.idEstudio
GROUP BY Estudio.Nombre
ORDER BY Presupuesto_Promedio DESC;

SELECT  Actor.idActor, Actor.Nombre, Actor.Apellido, Actor.fecha_nacimiento, Actor.Sexo, Actor.Nacionalidad, Actor.Rol
FROM    Actor_Pelicula
JOIN    Actor USING (idActor)
JOIN    Pelicula USING (idPelicula)
WHERE   idPelicula = 1;

-- query de prueba

select Pelicula.nombre, restrincion, descripcion, Pelicula.duracion, Director_General 
from Produccion
join Pelicula using (idProduccion)
join Trailer using (idPelicula)
join Genero using (idGenero)
join Estudio using (idEstudio)
where genero = "Familiar" and Estudio.nombre = "Disney";