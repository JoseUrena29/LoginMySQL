/*II Parcial Bases de Datos II
Estudiante: Jose Ureña Aguilar*/

USE IIParcialDB
CALL spValidarUsuario('joseurena@gmail.com', 'Jose2998%$#');
CALL spValidarUsuario('joseurena@gmail.com', 'ce27b49397f7ed9a6421699da46c4ab0');
SELECT * FROM usuarios

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spValidarUsuario`(
								 IN pEmail VARCHAR(50),
								 IN pPassword VARCHAR(50))
BEGIN

	SELECT 
    Cedula, 
    Nombre, 
    Apellido, 
    Telefono, 
    Email, 
    Password
	FROM usuarios
    WHERE Email = pEmail
    AND Password = pPassword;
END$$
DELIMITER ;