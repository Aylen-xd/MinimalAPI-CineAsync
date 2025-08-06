DROP DATABASE IF EXISTS 5to_Pelicula;
CREATE DATABASE 5to_Pelicula;
SELECT 'Creando Pelis' Estado;
USE 5to_Pelicula;

CREATE TABLE Genero (
  idGenero TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
  genero VARCHAR(30) NOT NULL
);

CREATE TABLE Estudio (
  idEstudio TINYINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(15) NOT NULL,
  fundacion DATE NOT NULL,
  CONSTRAINT UQ_Estudio UNIQUE (nombre)
);

CREATE TABLE Produccion (
  idProduccion TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
  idEstudio TINYINT UNSIGNED,
  Director_General VARCHAR(50) NOT NULL,
  Guion VARCHAR(100),
  Productor VARCHAR(100),
  Vestuario VARCHAR(100),
  Sonido VARCHAR(100),
  Presupuesto DECIMAL(15, 2) NOT NULL,
  Musica VARCHAR(100),
  CONSTRAINT FK_Produccion_Estudio FOREIGN KEY (idEstudio)
    REFERENCES Estudio (idEstudio)
);

CREATE TABLE Pelicula (
  idPelicula TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
  idProduccion TINYINT UNSIGNED,
  nombre VARCHAR(40) NOT NULL,
  estreno DATE NOT NULL,
  descripcion VARCHAR(300),
  calificacion TINYINT UNSIGNED,
  duracion TIME NOT NULL,
  restrincion TINYINT UNSIGNED,
  recaudado BIGINT UNSIGNED,
  CONSTRAINT FK_Pelicula_Produccion FOREIGN KEY (idProduccion)
    REFERENCES Produccion (idProduccion)
);

CREATE TABLE Actor (
  idActor TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
  Nombre VARCHAR(40) NOT NULL,
  Apellido VARCHAR(40) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  sexo CHAR(1) NOT NULL,
  nacionalidad VARCHAR(40) NOT NULL,
  rol VARCHAR(40) NULL
);

CREATE TABLE Actor_Pelicula (
  idActor TINYINT UNSIGNED,
  idPelicula TINYINT UNSIGNED,
  personaje VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Actor_Pelicula PRIMARY KEY (idActor, idPelicula, personaje),
  CONSTRAINT FK_Actor_Pelicula_Actor FOREIGN KEY (idActor)
    REFERENCES Actor (idActor),
  CONSTRAINT FK_Actor_Pelicula_Pelicula FOREIGN KEY (idPelicula)
    REFERENCES Pelicula (idPelicula)
);

CREATE TABLE Saga (
  idSaga TINYINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
  Numero_Saga TINYINT UNSIGNED,
  idPelicula TINYINT UNSIGNED,
  Nombre VARCHAR(50) NOT NULL,
  CONSTRAINT FK_Saga_Pelicula FOREIGN KEY (idPelicula)
    REFERENCES Pelicula (idPelicula)
);

CREATE TABLE Trailer (
  idTrailer TINYINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
  idPelicula TINYINT UNSIGNED,
  idGenero TINYINT UNSIGNED,
  nombre VARCHAR(50) NOT NULL,
  duracion TIME NOT NULL,
  CONSTRAINT FK_Trailer_Genero FOREIGN KEY (idGenero)
    REFERENCES Genero (idGenero),
  CONSTRAINT FK_Trailer_Pelicula FOREIGN KEY (idPelicula)
    REFERENCES Pelicula (idPelicula)
);
