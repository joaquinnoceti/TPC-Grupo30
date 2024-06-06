CREATE DATABASE TPC_Taller
USE TPC_Taller
GO
CREATE TABLE Clientes
(
    ID int IDENTITY (1,1) NOT NULL,
    Nombre varchar(30),
    Apellido varchar(30),
    Email varchar(50),
    DNI int,
    Telefono varchar(20),		
    FechaNac datetime,
    Direccion varchar(50),
    IDVehiculo int

);



CREATE TABLE Usuarios
(
    ID int IDENTITY (1,1) NOT NULL,
    Nombre varchar(50),
    Apellido varchar(50),
    DNI int,
    FechaNac datetime,
    Email varchar(50),
    Telefono varchar(20),
    Direccion varchar(50),
    FechaRegistro datetime,
    IdEspecialidad varchar(50),
    Categoria varchar(50),
    Contrasenia varchar(20),
    IdRol int,
    Estado bit
)

CREATE TABLE Roles
(
    ID int IDENTITY (1,1) NOT NULL,
    NombreRol varchar(50)
);


CREATE TABLE Especialidades
(
    ID int IDENTITY (1,1) NOT NULL,
    NombreEspecialidad varchar(20)
);


CREATE TABLE Vehiculos
(
    ID int IDENTITY (1,1) NOT NULL,
	NombreVehiculo varchar(100),
    IDMarca int,
    IDModelo int,
    Anio int,
    Patente varchar(10),
    TipoVehiculo varchar(15),
    IdCliente int
);

GO

CREATE TABLE OrdenDeTrabajo (
    ID INT IDENTITY(1,1),
    FechaCreacion DATETIME,
    IdCliente INT,
    IdVehiculo INT,
    HorasTeoricas INT, 
    HorasReales INT, 
    FechaFinalizacion DATETIME,
    Observaciones VARCHAR(200),
    Total DECIMAL,
    Cobrado BIT,
    IdEmpleado INT,
    Estado INT,
    CreadoPor INT,
);

CREATE TABLE Servicios (
    ID INT IDENTITY(1,1),
    Nombre VARCHAR(100),
    Descripción VARCHAR(200),
    Precio DECIMAL
);

CREATE TABLE OrdenServicio (
    IdOrden INT,
    IdServicio INT,
);

CREATE TABLE EstadoOrden (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100)
);
GO

CREATE TABLE Marcas  
(
    ID int IDENTITY (1,1) NOT NULL,
    NombreMarca varchar(50)
);

GO

CREATE TABLE Modelos  
(
    ID int IDENTITY (1,1) NOT NULL,
    IDMarca int,
    NombreModelo varchar(50)
);

go

CREATE procedure [dbo].[spAltaCliente]
@Nombre varchar(50),
@Apellido varchar(50),
@Email varchar(50),
@DNI int,
@Telefono varchar(20),
@FechaNac datetime,
@Direccion varchar(50)
as
insert into CLIENTES VALUES (@Nombre,@Apellido,@Email,@DNI,@Telefono,@FechaNac,@Direccion)

GO

Insert into Clientes(Nombre,Apellido,Email,DNI,Telefono,FechaNac,Direccion) Values ('Maria','Perez','maria@gmail.com',24156896,'4444-5555',28/01/1979,'Gral Paz 1500')
Insert into Clientes(Nombre,Apellido,Email,DNI,Telefono,FechaNac,Direccion) Values ('Luis','Marquez','luis@gmail.com',25748963,'5555-8888',27037,'San Martin 180')
Insert into Clientes(Nombre,Apellido,Email,DNI,Telefono,FechaNac,Direccion) Values ('Marcelo','Mas','marcelo@gmail.com',27859365,'7777-1141',27614,'Talcahuano 852')
