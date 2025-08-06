/*Triggers*/

Use 5to_Pelicula;

/*Prevenir el ingreso de presupuesto negativos*/


Delimiter $$
Drop trigger if EXISTS BefInsPresupuesto $$
Create trigger BefInsPresupuesto before insert on Produccion
FOR EACH ROW
begin
       IF(new.Presupuesto < 0)
       THEN
               SIGNAL SQLSTATE '45000'
               SET MESSAGE_TEXT = 'No se permiten presupuestos negativos';
       END IF;
END $$

/*evitar eliminar un estudio si cuenta con producciones*/

Delimiter $$
Drop trigger if EXISTS BefDelEstudio $$
CREATE TRIGGER BefDelEstudio BEFORE DELETE ON Estudio
FOR EACH ROW
       BEGIN
       IF ((SELECT COUNT(*) FROM Produccion WHERE idEstudio = OLD.idEstudio) > 0) THEN
               SIGNAL SQLSTATE '45000'
               SET MESSAGE_TEXT = 'No se puede eliminar el estudio porque tiene producciones asociadas.';
       END IF;
END $$