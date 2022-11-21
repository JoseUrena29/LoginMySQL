/*II Parcial Bases de Datos II
Estudiante: Jose Ureña Aguilar*/

CALL spEmailUsuario('joseurena2@gmail.com');
SELECT * FROM usuarios

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEmailUsuario`(
								 IN pEmail VARCHAR(50))
BEGIN

	SELECT 
    Cedula, 
    Nombre, 
    Apellido, 
    Telefono, 
    Email, 
    Password
	FROM usuarios
    WHERE Email = pEmail;
END$$
DELIMITER ;