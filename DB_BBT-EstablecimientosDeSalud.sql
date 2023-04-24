CREATE DATABASE BBT_EstablecimientosDeSalud;
GO

USE BBT_EstablecimientosDeSalud;
GO
-- Crear la tabla Usuarios
CREATE TABLE Usuario (
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    contrasena VARCHAR(50) NOT NULL,
    imagen VARCHAR(255)
);

-- Crear la tabla Establecimientos de Salud
CREATE TABLE EstablecimientoDeSalud (
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    codigo_renaes INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    ciudad VARCHAR(50) NOT NULL,
    red VARCHAR(50) NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    longitud DECIMAL(12, 8) NOT NULL,
    latitud DECIMAL(12, 8) NOT NULL,
    descripcion VARCHAR(255),
    imagen VARCHAR(255),
);

-- Crear la tabla Valoraciones
CREATE TABLE Valoracion (
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    establecimiento_id INT NOT NULL,
    usuario_id INT NOT NULL,
    comentario VARCHAR(255),
    valoracion INT,
    FOREIGN KEY (establecimiento_id) REFERENCES EstablecimientoDeSalud(id),
    FOREIGN KEY (usuario_id) REFERENCES Usuario(id)
);

-- Crear la tabla Busquedas
CREATE TABLE Busqueda (
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    usuario_id INT NOT NULL,
    establecimiento_id INT NOT NULL,
    termino_busqueda VARCHAR(255) NOT NULL,
    fecha DATETIME NOT NULL,
    FOREIGN KEY (usuario_id) REFERENCES Usuario(id),
    FOREIGN KEY (establecimiento_id) REFERENCES EstablecimientoDeSalud(id)
);