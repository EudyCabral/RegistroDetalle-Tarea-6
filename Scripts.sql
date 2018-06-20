CREATE DATABASE PersonasDb
go 
use PersonasDb
go
create table Personas
(
			PersonaId int primary key identity(1,1),
            Fecha datetime,
            Nombres varchar(30),
            Cedula varchar(13),
            Telefono varchar(12),
            Direccion varchar(max)

			          
);

go
create Table Articulos
(
			ArticuloId int primary key identity(1,1),
            Fecha  DateTime,
            Nombre varchar(30),
            Descripcion  varchar(max),
            Cantidad  int
);
go
