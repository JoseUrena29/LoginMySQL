/*II Parcial Bases de Datos II
Estudiante: Jose Ureña Aguilar*/

CREATE DATABASE IIParcialDB
USE IIParcialDB
show tables

CREATE TABLE Usuarios (
	ID INT auto_increment NOT NULL,
    Cedula VARCHAR(50),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
	Telefono INT,
    Email VARCHAR(50) UNIQUE,
    Password VARCHAR(50),
    primary key(Id)
)

ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'[A-Z]')
ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'upper[A-Z]')
ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'[0-9]')
ALTER TABLE usuarios ADD CONSTRAINT CK_PASSWORD CHECK (Password LIKE'[#,$,%,&,=,?,¡,¿,!]')

INSERT INTO Usuarios (Cedula, Nombre, Apellido, Telefono, Email, Password)
VALUES ('207770863', 'Jose', 'Ureña', 86348555, 'joseurena@gmail.com', MD5('Jose29%%'))	

SELECT 
	Cedula,
	nombre,
    Apellido,
    Telefono,
    Email,
    Password
 FROM Usuarios 




