/*II Parcial Bases de Datos II
Estudiante: Jose Ureña Aguilar*/

CREATE TABLE HistoricoPassword (
    IDHistorico INT AUTO_INCREMENT PRIMARY KEY,
    Cedula VARCHAR(50),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
	Telefono INT,
    Email VARCHAR(50),
    Password VARCHAR(50),
    Fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

drop table historicopassword
drop trigger TrPassword

DELIMITER $$
create trigger TRPassword after update on usuarios
for each row 
begin
insert into historicopassword (Cedula, Nombre, Apellido, Telefono, Email, Password) value (old.Cedula, old.Nombre, old.Apellido, old.Telefono, old.Email, old.Password);
END$$
DELIMITER ;

CALL spResetPassword('joseurena@gmail.com', 'Jose985%$');
    
select * from usuarios
select * from historicopassword
select * from historicopassword where Email = 'joseurena@gmail.com' and Password = '56b192da45dd0c48eb588a3a57959048' limit 7 