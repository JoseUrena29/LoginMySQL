/*II Parcial Bases de Datos II
Estudiante: Jose Ureña Aguilar*/

CALL spRegistrarUsuario('207770863', 'Jose', 'Ureña', 86348555, 'joseurena2@gmail.com', 'Jose29%%');
SELECT * FROM usuarios

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spRegistrarUsuario`(
								 IN Cedula VARCHAR(50),
								 IN Nombre VARCHAR(50),
								 IN Apellido VARCHAR(50),
								 IN Telefono INT,
								 IN Email VARCHAR(50),
								 IN Password VARCHAR(50))
   
BEGIN
	INSERT INTO Usuarios (
    Cedula, 
    Nombre, 
    Apellido, 
    Telefono, 
    Email, 
    Password)

	VALUES (
			Cedula, 
			Nombre, 
			Apellido, 
			Telefono, 
			Email, 
            MD5(Password));
END$$
DELIMITER ;