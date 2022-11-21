/*II Parcial Bases de Datos II
Estudiante: Jose Ureña Aguilar*/

ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'[A-Z]')
ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'upper[A-Z]')
ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'[0-9]')
ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'[#,$,%,&,=,?,¡,¿,!]')

CALL spResetPassword('joseurena@gmail.com', 'Jose9829#$%');
SELECT * FROM Usuarios

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spResetPassword`(
								 IN pEmail VARCHAR(50),
								 IN pPassword VARCHAR(50))
BEGIN
IF EXISTS(SELECT * FROM Usuarios WHERE pEmail=Email) then
	UPDATE Usuarios SET Password = MD5(pPassword)
    WHERE Email = pEmail;							
  else
  CALL spEmail();
  end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spResetPassword`(
								 IN pEmail VARCHAR(50),
								 IN pPassword VARCHAR(50))
BEGIN
IF EXISTS(SELECT * FROM Usuarios WHERE pEmail=Email) and EXISTS(SELECT * FROM  historicopassword WHERE pEmail=Email and pPassword=Password limit 7) then
	UPDATE Usuarios SET Password = MD5(pPassword)
    WHERE Email = pEmail;							
  else
  CALL spEmail();
  end if;
END$$
DELIMITER ;