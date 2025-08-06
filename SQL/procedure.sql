-- Active: 1729186022063@@127.0.0.1@3306@5to_Pelicula
Use 5to_Pelicula ;
SELECT 'Creando SPs' Estado ;
/*Store procedure*/

-- Registar nuevo estudio
DELIMITER $$
Drop Procedure if EXISTS InsEstudio $$
Create Procedure InsEstudio (out xidEstudio tinyint unsigned, xnombre varchar (15), xfundacion date)
begin
    insert into `Estudio` (nombre, fundacion)
    values (xnombre, xfundacion);
    SET xidEstudio = LAST_INSERT_ID();
end $$

call InsEstudio  (@idEstudioDisney, 'Disney', '1923-10-23') $$
call InsEstudio  (@idEstudioDream, 'DreamWorld', '1994-10-12') $$
call InsEstudio  (@idEstudioWarner, 'Warner Bros', '1923-04-04') $$
call InsEstudio  (@idEstudioGhibli, 'Studio Ghibli', '1985-06-15') $$

-- Insert en Genero:
delimiter $$
drop procedure if exists InsGenero $$
create procedure InsGenero (out unidGenero tinyint unsigned,
ungenero varchar(30))
begin
 insert into Genero(Genero)
 values(ungenero);

 SET unidGenero = LAST_INSERT_ID();
end $$

call InsGenero  (@idGFiccion, 'Ficcion') $$
call InsGenero  (@idGFantasia, 'Fantasia') $$
call InsGenero  (@idGFamiliar, 'Familiar') $$
call InsGenero  (@idGAccion, 'Accion') $$
call InsGenero  (@idGAventura, 'Aventura infantil') $$

-- Insert en Produccion:
Delimiter $$
drop procedure if exists InsProduccion $$
create procedure InsProduccion (OUT     unidProduccion tinyint unsigned,
                                        unidEstudio tinyint unsigned,
                                        unDirector_General varchar (50),
                                        unGuion varchar (100),
                                        unProductor varchar(100),
                                        unVestuario varchar (100),
                                        unSonido varchar (100),
                                        unaMusica varchar (100),
                                        unPresupuesto decimal)
begin
    insert into Produccion(idEstudio, Director_General, Guion, Productor, Vestuario, Sonido, Musica, Presupuesto )
    values (unidEstudio, unDirector_General, unGuion, unProductor, unVestuario, unSonido, unaMusica, unPresupuesto );
    SET unidProduccion = LAST_INSERT_ID();
end $$

Call InsProduccion (@idProduFrozen, @idEstudioDisney, 'Chris Buck-Jennifer Lee', ' Peter Del Vecho - Jhon Lasseter', ' Edith Head - Hubert de Givenchy', 'Jennifer Lee', 'Odin Benitez', 'Christophe Beck - Armando Perez - Kristen Anderson Lopez', 150000000) $$
Call InsProduccion  (@idProduFrozen2, @idEstudioDisney, 'Chris Buck - Jennifer Lee', ' Peter Del Vecho', ' Edith Head - Hubert de Givenchy', 'Jennifer Lee', 'Aurora Aksnes', 'Kristen Anderson Lopez', 150000000) $$
Call InsProduccion  (@idProduInterestelar, @idEstudioWarner, 'Christopher Nolan', 'Emma Thomas-Christopher Nolan-Lynda Obst', 'Mary Zophres', 'Jonathan Nolan-Christopher Nolan', 'Hoyte van Hoytema', 'Hans Zimmer', 165000000) $$

DELIMITER $$
drop procedure if exists InsActor $$
Create procedure InsActor (out xidActor tinyint unsigned,
                            xNombre varchar(40),
                            xApellido varchar(40),
                            xfecha_nacimiento DATE,
                            xsexo char(1),
                            xnacionalidad varchar(40),
                            xrol varchar (40))
begin
 insert into Actor (Nombre, Apellido, fecha_nacimiento, sexo, nacionalidad, rol)
 VALUES(xNombre, xApellido, xfecha_nacimiento, xsexo, xnacionalidad, xrol);
 SET xidActor = LAST_INSERT_ID();
END $$

-- Frozen 1
CALL InsActor (@idActorKristen,   'Kristen ', 'Bell', '1980-07-18', 'F', 'Estadounidense', 'Actriz de voz') $$
CALL InsActor (@idActorIdina, 'Idina ', 'Menzel', '1971-05-30', 'F', 'Estadounidense', 'Actriz de voz') $$
CALL InsActor (@idActorJonathan, 'Jonathan ', 'Groff', '1995-03-26', 'M', 'Estadounidense', 'Actor de voz') $$
CALL InsActor (@idActorJosh, 'Josh ', 'Gad', '1981-02-23', 'M', 'Estadounidense', 'Actor de voz') $$
CALL InsActor (@idActorAlan, 'Alan ', 'Tudyk', '1971-03-16', 'M', 'Estadounidense', 'Actor de voz') $$
CALL InsActor (@idActorEva, 'Eva ', 'Bella', '2002-06-04', 'F', 'Estadounidense', 'Actriz de voz') $$
CALL InsActor (@idActorLivy, 'Livy ', 'Stubenraunch', '2005-04-18', 'F', 'Estadounidense', 'Actriz de voz') $$
CALL InsActor (@idActorSantino, 'Santino ', 'Fontana', '1982-03-21', 'M', 'Estadounidense', 'Actor de voz') $$
 -- Fronzen 2
 CALL InsActor(@idActorSterling, 'Sterling ', 'Brown', '1976-04-05', 'M', 'Estadounidense', 'Actor de voz') $$
 CALL InsActor(@idActorEvan, 'Evan ', 'Wood', '1987-09-07', 'F', 'Estadounidense', 'Actriz de voz') $$
 CALL InsActor(@idActorMartha, 'Martha ', 'Plimpton', '1970-11-16', 'F', 'Estadounidense', 'Actriz de voz') $$
 CALL InsActor(@idActorRachel, 'Rachel ', 'Matthews', '1993-10-25', 'F', 'Estadounidense', 'Actriz de voz') $$
 -- Interestelar
 CALL InsActor(@idActorMatthew, 'Matthew ', 'McConaughey', '1969-11-04', 'M', 'Estadounidense', 'Actor Live action') $$
 CALL InsActor(@idActorAnne, 'Anne ', 'Hathaway', '1982-11-12', 'F', 'Estadounidense', 'Actriz Live action') $$
 CALL InsActor(@idActorFoy, 'Mackenzie ', 'Foy', '2000-11-10', 'F', 'Estadounidense', 'Actriz Live action') $$
 CALL InsActor(@idActorJessica, 'Jessica ', 'Chastain', '1977-03-24', 'F', 'Estadounidense', 'Actriz Live action') $$
 CALL InsActor(@idActorMichael, 'Michael ', 'Caine', '1933-03-14', 'M', 'Británico', 'Actor Live Action') $$
 CALL InsActor(@idActorCasey, 'Casey', 'Affleck', '1975-08-12', 'M', 'Estadounidense', 'Actor Live Action') $$
 CALL InsActor(@idActorMatt, 'Matt', 'Damon', '1970-10-08', 'M', 'Estadounidense', 'Actor Live Action') $$
 CALL InsActor(@idActorLithgow, 'John', 'Lithgow', '1945-10-19', 'M', 'Estadounidense', 'Actor Live Action') $$
 CALL InsActor(@idActorEllen, 'Ellen', 'Burstyn', '1932-12-07', 'F', 'Estadounidense', 'Actriz Live action') $$
 CALL InsActor(@idActorDavid, 'David', 'Gyasi', '1980-01-02', 'M', 'Británica', 'Actor Live Action') $$
 CALL InsActor(@idActorTopher, 'Topher', 'Grace', '1978-07-12', 'M', 'Estadounidense', 'Actor Live Action') $$
 CALL InsActor(@idActorChalamet,'Timothée', 'Chalamet', '1995-12-27', 'M', 'Estadounidense', 'Actor Live Action') $$
 CALL InsActor(@idActorStewart, 'Josh', 'Stewart', '1977-02-06', 'M', 'Estadounidense', 'Actor de voz') $$

DELIMITER $$

Drop Procedure if EXISTS `InsPelicula` $$
Create Procedure InsPelicula ( out unidPelicula TINYINT UNSIGNED,
                                unidProduccion tinyint unsigned,
                                unnombre varchar(40),
                                unestreno date,
                                unadescripcion varchar (300),
                                unacalificacion tinyint unsigned,
                                unaduracion Time,
                                unarestrincion tinyint unsigned ,
                                unrecaudado bigint unsigned)
Begin
        insert into Pelicula (idProduccion, nombre, estreno, descripcion, calificacion, duracion, restrincion, recaudado)
                VALUES (unidProduccion, unnombre, unestreno, unadescripcion,
                unacalificacion, unaduracion, unarestrincion, unrecaudado) ;
 SET unidPelicula = LAST_INSERT_ID();
END $$

call InsPelicula(@idPeliFrozen, @idProduFrozen, 'Frozen una aventura congelada', '2013-11-27', 'Anna y Kristoff desafían la naturaleza en una carrera para salvar a Elsa y al reino', 7.9, '01:42:00', 0, 1284219009) $$
 call InsPelicula(@idPeliFrozen2, @idProduFrozen2, 'Frozen 2', '2019-01-02', 'Elsa se aventura en lo desconocido para descubrir verdades del pasado', 8.0, '01:48:00', 0, 1453683476) $$
 
 -- Películas comunes
 call InsPelicula(@idPeliInterestelar, @idProduInterestelar, 'Interestelar', '2014-11-06', 'Un equipo de exploradores viaja más allá de esta galaxia a través de un reciente descubierto agujero para descubrir si la humanidad tiene un futuro entre las estrellas', 9.0, '02:49:00', 13, 708000000) $$

-- Insert en Trailer:
delimiter $$
drop procedure if exists InsTrailer $$
create procedure InsTrailer ( out unidTrailer tinyint unsigned,
                                unidPelicula tinyint unsigned,
                                unidGenero tinyint unsigned,
                                unnombre varchar(50),
                                unaduracion time)
begin
    insert into Trailer( idPelicula, idGenero, nombre, duracion)
    values(unidPelicula, unidGenero, unnombre, unaduracion);
    SET unidTrailer = LAST_INSERT_ID();
end $$

    CALL InsTrailer (@idTrFrozen1,  @idPeliFrozen,@idGFamiliar, 'Frozen una aventura congelada', '00:01:30') $$
    CALL InsTrailer (@idTrFrozen1_2,  @idPeliFrozen,@idGFamiliar, 'Frozen una aventura congelada', '00:02:25') $$
    CALL InsTrailer (@idTrInterestelar_4,  @idPeliInterestelar, @idGFiccion,'Interestelar', '00:02:19') $$


DELIMITER $$
/*procedure de saga */
 drop procedure if exists insSaga $$
 Create procedure insSaga(out   unidsaga TINYINT UNSIGNED,
                                unNumero_Saga TINYINT UNSIGNED,
                                unidpelicula MEDIUMINT unsigned,
                                unnombre varchar (50) )
begin
 insert into Saga(Numero_Saga,idpelicula,nombre)
 VALUES(unNumero_Saga,unidpelicula,unnombre);
 set unidsaga = LAST_INSERT_ID();

END $$

CALL insSaga (@idSagaFrozen_1, 1 ,@idPeliFrozen, 'Frozen una aventura congelada') $$
CALL insSAga (@idSagaFrozen_2, 1 ,@idPeliFrozen2, 'Frozen 2') $$

delimiter $$
drop procedure if exists InsActPeli $$
create PROCEDURE InsActPeli (unidActor TINYINT UNSIGNED, unidPelicula TINYINT UNSIGNED, unRol VARCHAR(50))
begin
    insert into Actor_Pelicula(idActor, idPelicula, personaje)
    values (unidActor, unidPelicula, unRol);
end $$

 call InsActPeli(@idActorIdina, @idPeliFrozen, "Elsa") $$
 call InsActPeli(@idActorKristen, @idPeliFrozen, "Anna") $$
 call InsActPeli(@idActorJonathan, @idPeliFrozen, "Kristoff") $$
 call InsActPeli(@idActorJosh, @idPeliFrozen, "Olaf") $$
 call InsActPeli(@idActorAlan, @idPeliFrozen, "Duque Weselton") $$
 call InsActPeli(@idActorEva, @idPeliFrozen, "Joven Elsa") $$
 call InsActPeli(@idActorLivy, @idPeliFrozen, "Joven Anna") $$
 call InsActPeli(@idActorSantino, @idPeliFrozen, "Hans") $$
 -- Frozen 2
 call InsActPeli(@idActorKristen, @idPeliFrozen2, "Anna") $$
 call InsActPeli(@idActorIdina, @idPeliFrozen2, "Elsa") $$
 call InsActPeli(@idActorJonathan, @idPeliFrozen2, "Kristoff") $$
 call InsActPeli(@idActorJosh, @idPeliFrozen2, "Olaf") $$
 call InsActPeli(@idActorSterling, @idPeliFrozen2, "Matthias") $$
 call InsActPeli(@idActorEvan, @idPeliFrozen2, "Iduna") $$
 call InsActPeli(@idActorMartha, @idPeliFrozen2, "Yelana") $$
 call InsActPeli(@idActorRachel, @idPeliFrozen2, "Honeymaren") $$
  -- Interesellar
 call InsActPeli(@idActorMatthew, @idPeliInterestelar, "Joseph Coope") $$
 call InsActPeli(@idActorAnne, @idPeliInterestelar, "Amelia Brand") $$
 call InsActPeli(@idActorFoy, @idPeliInterestelar, "Murph joven") $$
 call InsActPeli(@idActorJessica, @idPeliInterestelar, "Murph adulta") $$
 call InsActPeli(@idActorMichael, @idPeliInterestelar, "Profesor Brand") $$
 call InsActPeli(@idActorCasey, @idPeliInterestelar, "Tom") $$
 call InsActPeli(@idActorMatt, @idPeliInterestelar, "Dr. Mann") $$
 call InsActPeli(@idActorLithgow, @idPeliInterestelar, "Donald") $$
 call InsActPeli(@idActorEllen, @idPeliInterestelar, "Murph anciana") $$
 call InsActPeli(@idActorDavid, @idPeliInterestelar, "Romilly") $$
 call InsActPeli(@idActorTopher, @idPeliInterestelar, "Getty") $$
 call InsActPeli(@idActorChalamet, @idPeliInterestelar, "Tom joven") $$
 call InsActPeli(@idActorStewart, @idPeliInterestelar, "CASE") $$


-- Incrementa el presupuesto
DELIMITER $$
Drop Procedure if EXISTS `IncPresupuesto` $$
Create Procedure IncPresupuesto (unidProduccion tinyint unsigned, Cantidad tinyint unsigned )
begin
    START TRANSACTION;
        update Produccion
        set Presupuesto = Presupuesto + Cantidad
        where idProduccion = unidProduccion ;
    COMMIT;
END $$

-- Eliminar Actor
DELIMITER $$
Drop Procedure if EXISTS DelActor $$
CREATE PROCEDURE DelActor (xidActor tinyint unsigned)
begin
    START TRANSACTION;
        DELETE from Actor
        where idActor = xidActor;
    COMMIT;
end $$


-- Actualizacion de produccion, desde el usuario de Director
DELIMITER $$
drop procedure if EXISTS New_Actualizacion $$
create procedure New_Actualizacion (unidProduccion tinyint unsigned, unDirector VARCHAR(50), unProductor VARCHAR(50), unGuion varchar(100), unaMusica varchar(100), unPresupuesto decimal, unSonido varchar(100), unVestuario varchar(100))
begin 
    START TRANSACTION;
    UPDATE Produccion
    set Director_General = unDirector,
        Productor = unProductor,
        Guion = unGuion, Musica = unaMusica,
        Presupuesto = unPresuppuesto,
        Sonido = unSonido,
        Vestuario = unVestuario
    WHERE idProduccion = unidProduccion;
    COMMIT;
END $$




	
