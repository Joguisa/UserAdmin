-- Crear la base de datos 'prueba'
CREATE DATABASE prueba;
GO

-- Usar la base de datos 'prueba'
USE prueba;
GO

-- Crear la tabla 'departamentos'
CREATE TABLE departamentos (
    id INT PRIMARY KEY IDENTITY,
    codigo NVARCHAR(50) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    activo BIT DEFAULT 1,
    idUsuarioCreacion INT
);
GO

-- Crear la tabla 'cargos'
CREATE TABLE cargos (
    id INT PRIMARY KEY IDENTITY,
    codigo NVARCHAR(50) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    activo BIT DEFAULT 1,
    idUsuarioCreacion INT
);
GO

-- Crear la tabla 'users'
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY,
    usuario NVARCHAR(50) NOT NULL,
    primerNombre NVARCHAR(50) NOT NULL,
    segundoNombre NVARCHAR(50),
    primerApellido NVARCHAR(50) NOT NULL,
    segundoApellido NVARCHAR(50),
    idDepartamento INT NOT NULL,
    idCargo INT NOT NULL,
    CONSTRAINT FK_users_departamentos FOREIGN KEY (idDepartamento) REFERENCES departamentos(id),
    CONSTRAINT FK_users_cargos FOREIGN KEY (idCargo) REFERENCES cargos(id)
);
GO
