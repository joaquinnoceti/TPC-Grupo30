create database TPC_Taller


CREATE TABLE CLIENTES
(
Codigo int IDENTITY (1,1) NOT NULL,
Nombre varchar(30),
Apellido varchar(30),
Email varchar(50),
DNI int,
Telefono varchar(15),
FechaNac datetime,
Direccion varchar(30)
)



CREATE TABLE USUARIO
(
Codigo int IDENTITY (1,1) NOT NULL,
Nombre varchar(30),
Apellido varchar(30),
Email varchar(50),
DNI int,
Telefono varchar(15),
FechaNac datetime,
Direccion varchar(30),
Usuario varchar(20),
Contrasenia varchar(20),
CodigoRol int,
Estado bit
)

CREATE TABLE ROL
(
CodigoRol int IDENTITY (1,1) NOT NULL,
NombreRol varchar(15)
)


CREATE TABLE EMPLEADOS
(
Codigo int IDENTITY (1,1) NOT NULL,
Nombre varchar(30),
Apellido varchar(30),
Email varchar(50),
DNI int,
FechaRegisto datetime,
Categoria varchar(20),
CodigoEspecialidad int,
CodigoRol int
)

CREATE TABLE ESPECIALIDAD
(
Codigo int IDENTITY (1,1) NOT NULL,
NombreEspecialidad varchar(20)
)


CREATE TABLE VEHICULO
(
Codigo int IDENTITY (1,1) NOT NULL,
Marca varchar(20),
Modelo varchar(20),
Anio int,
Patente varchar(10),
TipoVehiculo varchar(15),
CodigoCliente int
)

CREATE TABLE ORDEN_TRABAJO
(
Codigo int IDENTITY (1,1) NOT NULL,
FechaInicio datetime,
CodigoCliente int,
CodigoVehiculo int,
CodigoServicios int,
HorasTeoricas decimal,
HorasTrabajadas decimal,
FechaFin datetime,
Observaciones varchar(200),
Total decimal,
Cobrado bit,
CodigoEmpleado int,
Estado bit,
CreadoPor varchar(30)
)

CREATE TABLE SERVICIO
(
Codigo int IDENTITY (1,1) NOT NULL,
NombreServicio varchar(20),
Descripcion varchar(100),
Precio decimal
)


CREATE TABLE ESTADO_ORDEN
(
Codigo int IDENTITY (1,1) NOT NULL,
Descripcion varchar(50)
)


CREATE procedure [dbo].[spAltaCliente]
@Nombre varchar(30),
@Apellido varchar(30),
@Email varchar(50),
@DNI int,
@Telefono varchar(15),
@FechaNac datetime,
@Direccion varchar(30)
as
insert into CLIENTES VALUES (@Nombre,@Apellido,@Email,@DNI,@Telefono,@FechaNac,@Direccion)




























