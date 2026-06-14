CREATE DATABASE ModelAlumnos;

USE ModelAlumnos;

CREATE TABLE Ciudad (
    Id       INT PRIMARY KEY IDENTITY(1,1),
    Nombre   NVARCHAR(50) NOT NULL
);

CREATE TABLE Alumno (
    Id            INT PRIMARY KEY IDENTITY(1,1),
    Nombres       NVARCHAR(250) NOT NULL,
    Apellidos     NVARCHAR(250) NOT NULL,
    Sexo          CHAR(1) NULL,           -- 'M' o 'F'
    Edad          INT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    CodCiudad     INT NULL,
    
    CONSTRAINT FK_Alumno_Ciudad 
        FOREIGN KEY (CodCiudad) REFERENCES Ciudad(Id)
);

CREATE INDEX IX_Alumno_CodCiudad ON Alumno(CodCiudad);
CREATE INDEX IX_Alumno_Apellidos ON Alumno(Apellidos);

SELECT 
    a.Id AS CodAlumno,
    a.Nombres,
    a.Apellidos,
    a.Edad,
    a.Sexo,
    a.FechaRegistro,
    c.Nombre AS Ciudad
FROM Alumno a
INNER JOIN Ciudad c ON a.CodCiudad = c.Id;