-- 1. Verifica si la base de datos ya existe y la elimina si es necesario
IF DB_ID('Inventario') IS NOT NULL
BEGIN
    ALTER DATABASE Inventario SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Inventario;
END;
GO

-- 2. Crear la base de datos Inventario
CREATE DATABASE Inventario;
GO

-- 3. Usar la base de datos Inventario
USE Inventario;
GO

-- 4. Crear las tablas en la base de datos Inventario

-- Tabla CategoriasProductos
CREATE TABLE CategoriasProductos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Productos
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    CategoriaId INT FOREIGN KEY REFERENCES CategoriasProductos(Id)
);

-- Tabla Inventario
CREATE TABLE Inventario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id),
    Cantidad INT NOT NULL,
    FechaIngreso DATE NOT NULL
);

-- Tabla InventarioPorMes
CREATE TABLE InventarioPorMes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT FOREIGN KEY REFERENCES Productos(Id),
    Mes INT NOT NULL,
    Año INT NOT NULL,
    Cantidad INT NOT NULL
);

-- Tabla Ventas
CREATE TABLE Ventas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    Total DECIMAL(18, 2) NOT NULL
);

-- Tabla VentasDiarias
CREATE TABLE VentasDiarias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    Total DECIMAL(18, 2) NOT NULL
);

-- Tabla Empleados
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cargo NVARCHAR(50) NOT NULL
);

-- Tabla Mascotas
CREATE TABLE Mascotas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Raza NVARCHAR(50) NOT NULL
);

-- Tabla Citas
CREATE TABLE Citas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    MascotaId INT FOREIGN KEY REFERENCES Mascotas(Id),
    EmpleadoId INT FOREIGN KEY REFERENCES Empleados(Id)
);

-- Tabla Factura
CREATE TABLE Factura (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    VentaId INT FOREIGN KEY REFERENCES Ventas(Id),
    Total DECIMAL(18,2) NOT NULL
);

-- Tabla Roles
CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);

-- Tabla MetodoPago
CREATE TABLE MetodoPago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

-- Tabla Dueño
CREATE TABLE Dueño (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Veterinario
CREATE TABLE Veterinario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(50) NOT NULL
);

-- Tabla PetProfiles
CREATE TABLE PetProfiles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MascotaId INT FOREIGN KEY REFERENCES Mascotas(Id),
    FechaNacimiento DATE NOT NULL,
    Notas NVARCHAR(500) NULL
);

-- Tabla HistorialClinico
CREATE TABLE HistorialClinico (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MascotaId INT FOREIGN KEY REFERENCES Mascotas(Id),
    Fecha DATE NOT NULL,
    Descripcion NVARCHAR(500) NOT NULL
);

-- Registro de migraciones (si usas Entity Framework)
CREATE TABLE __EFMigrationsHistory (
    MigrationId NVARCHAR(150) NOT NULL PRIMARY KEY,
    ProductVersion NVARCHAR(32) NOT NULL
);
GO

-- Mensaje de confirmación
PRINT 'Base de datos y tablas creadas correctamente en Inventario.';
