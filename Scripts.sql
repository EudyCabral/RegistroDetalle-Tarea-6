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

go
create Table CotizacionArticulos
(
		 CotizacionArticulosId int primary key identity(1,1),
         Fecha DateTime  ,
         Observaciones  varchar(max)
);
go

go
create Table CotizacionArticulosDetalle
(
			Id int primary key identity(1,1),
            CotizacionArticulosId  int,
            PersonaId int,
            ArticuloId int,
            Cantidad int,
            Precio money,
            Importe money
);
go



