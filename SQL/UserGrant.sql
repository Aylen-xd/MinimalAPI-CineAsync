-- Active: 1729186022063@@127.0.0.1@3306@5to_Pelicula
USE 5to_Pelicula;

-- create user [if not exists]'nomrbreuser'@'terminal' identified by 'password';
-- Drop user [if exists]...;

-- Drop de usuarios
DROP USER IF EXISTS 'UserDirector'@'localhost';
DROP USER IF EXISTS 'UserCliente'@'%';

-- Creacion de usuarios
CREATE USER if NOT EXISTS 'UserDirector'@'localhost' IDENTIFIED BY 'Director123!';
CREATE USER if NOT EXISTS 'UserCliente'@'%' IDENTIFIED BY 'Cliente456!';

/*Permisos de clintes*/
-- Cliente tiene acceso a 
--  Actualizar la calificacion de la pelicula seleccionada
--  Ver Pelicula, trailer, y saga de la pelicula.

GRANT SELECT, UPDATE(calificacion) on `5to_Pelicula`.`Pelicula` to  'UserCliente'@'%';
GRANT SELECT on `5to_Pelicula`.`Trailer` to  'UserCliente'@'%';
GRANT SELECT on `5to_Pelicula`.`Saga` to  'UserCliente'@'%';

/*Permisos para Director*/

/*Director tiene acceso a todo excepto a estudio*/

GRANT ALL on 5to_Pelicula.`Produccion` to 'UserDirector'@'localhost';
GRANT ALL on 5to_Pelicula.`Actor` to 'UserDirector'@'localhost';
GRANT ALL on 5to_Pelicula.`Genero` to 'UserDirector'@'localhost';
GRANT ALL on 5to_Pelicula.`Trailer` to 'UserDirector'@'localhost';
GRANT ALL on 5to_Pelicula.`Saga` to 'UserDirector'@'localhost';
GRANT ALL on 5to_Pelicula.`Pelicula` to 'UserDirector'@'localhost';