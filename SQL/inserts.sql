-- Active: 1700068523370@@127.0.0.1@3306@5to_Pelicula

Use 5to_Pelicula;

START TRANSACTION ;
 SET time_zone ='-03:00';
 
 insert into Genero (idGenero, Genero)
 values (@idGFiccion, 'Ficcion'),
        (@idGFantasia, 'Fantasia'),
        (@idGFamiliar, 'Familiar'),
        (@idGAccion, 'Accion'),
        (@idGAventura, 'Aventura infantil')
 ;
 
 insert into Estudio (idEstudio, Nombre, fundacion)
 values (@idEstudioDisney, 'Disney', '1923-10-23'),
 (@idEstudioDream, 'DreamWorld', '1994-10-12'),
 (@idEstudioWarner, 'Warner Bros', '1923-04-04'),
 (@idEstudioGhibli, 'Studio Ghibli', '1985-06-15')
 ;
 
 insert into Produccion (idProduccion, idEstudio, Director_General, Productor, Vestuario, Guion, Sonido, Musica, Presupuesto)
 values
 (@idProduFrozen, @idEstudioDisney, 'Chris Buck-Jennifer Lee', ' Peter Del Vecho - Jhon Lasseter', ' Edith Head - Hubert de Givenchy', 'Jennifer Lee', 'Odin Benitez', 'Christophe Beck - Armando Perez - Kristen Anderson Lopez', 150000000),
 (@idProduFrozen2, @idEstudioDisney, 'Chris Buck - Jennifer Lee', ' Peter Del Vecho', ' Edith Head - Hubert de Givenchy', 'Jennifer Lee', 'Aurora Aksnes', 'Kristen Anderson Lopez', 150000000),
 (@idProduInterestelar, @idEstudioWarner, 'Christopher Nolan', 'Emma Thomas-Christopher Nolan-Lynda Obst', 'Mary Zophres', 'Jonathan Nolan-Christopher Nolan', 'Hoyte van Hoytema', 'Hans Zimmer', 165000000)
;
 
 insert into Pelicula (idPelicula, idProduccion, nombre, estreno, descripcion, calificacion, duracion, restrincion, recaudado)
 values
 -- Sagas
(@idPeliFrozen, @idProduFrozen ,'Frozen una aventura congelada', '2013-11-27', 'Anna y Kristoff desafían la naturaleza en una carrera para salvar a Elsa y al reino', 7.9, '01:42:00', 0, 1284219009),
(@idPeliFrozen2, @idProduFrozen2 ,'Frozen 2', '2019-01-02', 'Elsa se aventura en lo desconocido para descubrir verdades del pasado', 8.0, '01:48:00', 0, 1453683476),
 
 -- Películas comunes
(@idPeliInterestelar, @idProduInterestelar,'Interestelar', '2014-11-06', 'Un equipo de exploradores viaja más allá de esta galaxia a través de un reciente descubierto agujero para descubrir si la humanidad tiene un futuro entre las estrellas', 9.0, '02:49:00', 13, 708000000)
;

 
 insert into Actor (idActor, Nombre, Apellido, fecha_nacimiento, sexo, nacionalidad, Rol)
 Values -- Frozen 1
 (@idActorKristen, 'Kristen ', 'Bell', '1980-07-18', 'F', 'Estadounidense', 'Actriz de voz'),
 (@idActorIdina, 'Idina ', 'Menzel', '1971-05-30', 'F', 'Estadounidense', 'Actriz de voz'),
 (@idActorJonathan, 'Jonathan ', 'Groff', '1995-03-26', 'M', 'Estadounidense', 'Actor de voz'),
 (@idActorJosh,  'Josh ', 'Gad', '1981-02-23', 'M', 'Estadounidense', 'Actor de voz', 'Olaf'),
 (@idActorAlan, 'Alan ', 'Tudyk', '1971-03-16', 'M', 'Estadounidense', 'Actor de voz'),
 (@idActorEva, 'Eva ', 'Bella', '2002-06-04', 'F', 'Estadounidense', 'Actriz de voz'),
 (@idActorLivy, 'Livy ', 'Stubenraunch', '2005-04-18', 'F', 'Estadounidense', 'Actriz de voz'),
 (@idActorSantino, 'Santino ', 'Fontana', '1982-03-21', 'M', 'Estadounidense', 'Actor de voz'),
 -- Fronzen 2
 (@idActorSterling, 'Sterling ', 'Brown', '1976-04-05', 'M', 'Estadounidense', 'Actor de voz'),
 (@idActorEvan, 'Evan ', 'Wood', '1987-09-07', 'F', 'Estadounidense', 'Actriz de voz'),
 (@idActorMartha, 'Martha ', 'Plimpton', '1970-11-16', 'F', 'Estadounidense', 'Actriz de voz'),
 (@idActorRachel, 'Rachel ', 'Matthews', '1993-10-25', 'F', 'Estadounidense', 'Actriz de voz'),
 -- Interestelar
 (@idActorMatthew, 'Matthew ', 'McConaughey', '1969-11-04', 'M', 'Estadounidense', 'Actor Live action'),
 (@idActorAnne, 'Anne ', 'Hathaway', '1982-11-12', 'F', 'Estadounidense', 'Actriz Live action'),
 (@idActorFoy, 'Mackenzie ', 'Foy', '2000-11-10', 'F', 'Estadounidense', 'Actriz Live action'),
 (@idActorJessica, 'Jessica ', 'Chastain', '1977-03-24', 'F', 'Estadounidense', 'Actriz Live action'),
 (@idActorMichael, 'Michael ', 'Caine', '1933-03-14', 'M', 'Británico', 'Actor Live Action'),
 (@idActorCasey, 'Casey', 'Affleck', '1975-08-12', 'M', 'Estadounidense', 'Actor Live Action'),
 (@idActorMatt, 'Matt', 'Damon', '1970-10-08', 'M', 'Estadounidense', 'Actor Live Action'),
 (@idActorLithgow, 'John', 'Lithgow', '1945-10-19', 'M', 'Estadounidense', 'Actor Live Action'),
 (@idActorEllen, 'Ellen', 'Burstyn', '1932-12-07', 'F', 'Estadounidense', 'Actriz Live action'),
 (@idActorDavid, 'David', 'Gyasi', '1980-01-02', 'M', 'Británica', 'Actor Live Action'),
 (@idActorTopher, 'Topher', 'Grace', '1978-07-12', 'M', 'Estadounidense', 'Actor Live Action'),
 (@idActorChalamet, 'Timothée', 'Chalamet', '1995-12-27', 'M', 'Estadounidense', 'Actor Live Action'),
 (@idActorStewart, 'Josh', 'Stewart', '1977-02-06', 'M', 'Estadounidense', 'Actor de voz') -- Fijarse en ponerle la coma una vez verificado el Full test
 ;

 
 insert into Saga(idSaga, Numero_Saga, idPelicula, Nombre)
 values
 (@idSagaFrozen_1, 1 ,@idPeliFrozen, 'Frozen una aventura congelada'),
 (@idSagaFrozen_2, 1 ,@idPeliFrozen2, 'Frozen 2')
;

 insert into Trailer(idTrailer, idGenero, idPelicula, Nombre, Duracion)
 values
 (@idTrFrozen1, @idGFamiliar, @idPeliFrozen, 'Frozen una aventura congelada', '00:01:30'), -- trailer 1
 -- (@idTrFrozen1_2, @idGFamiliar, @idPeliFrozen, 'Frozen una aventura congelada', '00:02:25'), -- trailer 2
 (@idTrFrozen2, @idGFamiliar, @idPeliFrozen2, 'Frozen 2', '00:02:01'),
 -- (@idTrInterestelar_1, @idGFiccion, @idPeliInterestelar, 'Interestelar', '00:01:39'), -- trailer 1
 -- (@idTrInterestelar_2, @idGFiccion, @idPeliInterestelar, 'Interestelar', '00:02:20'), -- trailer 2
 -- (@idTrInterestelar_3, @idGFiccion, @idPeliInterestelar, 'Interestelar', '00:02:26'), -- trailer 3
 (@idTrInterestelar_4, @idGFiccion, @idPeliInterestelar, 'Interestelar', '00:02:19') -- tailer 4 Fijarse en ponerle la coma una vez verificado el Full test
;

SELECT 'Ingresando ActoresPel'

 -- Test1
 (@idActorIdina, @idPeliFrozen, "Elsa"),
 (@idActorJonathan, @idPeliFrozen, "Kristoff"),
 (@idActorJosh, @idPeliFrozen, "Olaf"),
 (@idActorAlan, @idPeliFrozen, "Duque Weselton"),
 (@idActorEva, @idPeliFrozen, "Joven Elsa"),
 (@idActorLivy, @idPeliFrozen, "Joven Anna"),
 (@idActorSantino, @idPeliFrozen, "Hans"),
 -- Frozen 2
 (@idActorKristen, @idPeliFrozen2, "Anna"),
 (@idActorIdina, @idPeliFrozen2, "Elsa"),
 (@idActorJonathan, @idPeliFrozen2, "Kristoff"),
 (@idActorJosh, @idPeliFrozen2, "Olaf"),
 (@idActorSterling, @idPeliFrozen2, "Matthias"),
 (@idActorEvan, @idPeliFrozen2, "Iduna"),
 (@idActorMartha, @idPeliFrozen2, "Yelana"),
 (@idActorRachel, @idPeliFrozen2, "Honeymaren"),
 -- Interesellar
 (@idActorMatthew, @idPeliInterestelar, "Joseph Coope"),
 (@idActorAnne, @idPeliInterestelar, "Amelia Brand"),
 (@idActorFoy, @idPeliInterestelar, "Murph joven"),
 (@idActorJessica, @idPeliInterestelar, "Murph adulta"),
 (@idActorMichael, @idPeliInterestelar, "Profesor Brand"),
 (@idActorCasey, @idPeliInterestelar, "Tom"),
 (@idActorMatt, @idPeliInterestelar, "Dr. Mann"),
 (@idActorLithgow, @idPeliInterestelar, "Donald"),
 (@idActorEllen, @idPeliInterestelar, "Murph anciana"),
 (@idActorDavid, @idPeliInterestelar, "Romilly"),
 (@idActorTopher, @idPeliInterestelar, "Getty"),
 (@idActorChalamet, @idPeliInterestelar, "Tom joven"),
 (@idActorStewart, @idPeliInterestelar, "CASE")
;

commit;