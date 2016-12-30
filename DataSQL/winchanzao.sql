create database AnalisisClinico
go

use AnalisisClinico
go

create table Seguridad(
id int identity(1,1) not null,
idCuenta int not null,
code varchar(8) not null,
primary key(id),
unique(idCuenta)
)
go

create table Cuenta(
id int identity(1,1) not null,
nombre varchar(100) not null,
apellidos varchar(100) not null,
dni char(8)not null,
clave char(16) not null,
nivel int not null,
primary key(id),
unique(dni)
)
go

create table Item(
id int identity(1,1) not null,
nombre varchar(100) not null,
idTipoItem int not null,
idTipoCampo int not null,
PorDefault varchar(200) not null,
tieneUnidad bit not null,
unidad varchar(20),
primary key(id)
)
go
create table ListaItem(
id int identity(1,1),
nombre varchar(50),
idItem int not null,
indice int not null,
primary key(id)
)
go

create table Grupo(
id int identity(1,1) not null,
nombre varchar(100) not null,
idPlantilla int not null,
indice int not null,
primary key(id)
)
go

create table GrupoItem(
id int identity(1,1),
idItem int not null,
idGrupo int not null,
indice int not null,
primary key(id)
)
go


create table Paciente(
id int identity(1,1) not null,
hclinica varchar(100) not null,
nombre varchar(100) not null,
apellido1 varchar(100) not null,
apellido2 varchar(100) not null,
fechaNacimiento date not null,
dni char(8) not null,
direccion varchar(100) not null,
sexo bit not null,
primary key(id),
unique(dni)
)
go

create table Plantilla(
id int identity(1,1),
nombre varchar(100) not null,
codigo char(5) not null,
tieneItem bit default 0 not null,
tieneGrupo bit default 0 not null,
area int not null,
primary key(id),
unique(codigo)
)
go


create table PlantillaItem(
id int identity(1,1),
idItem int not null,
idPlantilla int not null,
indice int not null,
primary key(id)
)
go

create table Paquete(
id int identity(1,1),
codigo char(5) not null,
nombre varchar(100) not null,
tipo int not null,
primary key(id),
unique(codigo)
)
go

create table PlantillaPaquete(
id int identity(1,1),
idPaquete int not null,
idPlantilla int not null,
primary key(id)
)
go


create table Orden(
id int identity(1,1),
numero varchar(10),
idPaciente int not null,
fechaRegistro datetime not null,
ultimaModificacion datetime not null,
estado int default 0 not null
primary key(id)
)
go

create table OrdenDetalle(
id int identity(1,1),
idPaquete int not null,
idOrden int not null,
cobertura int not null
primary key(id)
)
go

create type OrdenDetalleObject as table(
idTemp int,
idPaquete int,
cobertura int
)

create table Examen(
id int identity(1,1) not null,
idPlantilla int not null,
idOrdenDetalle int not null,
fechaRegistro datetime not null,
fechaModificacion datetime null,
fechaFinalizacion datetime null,
estado int not null,
primary key(id)
)
go

create table ExamenDetalle(
id int identity(1,1) not null,
idItem int not null,
idExamen int not null,
respuesta varchar(200) not null,
primary key(id)
)

--Tipos de Datos;
create type ExamenesObject as table(
idTemp int,
idOrdenDetalle int,
idPlantilla int,
fechaRegistro datetime,
fechaModificacion datetime,
fechaFinalizacion datetime,
estado int
)


create type ExamenDetallesObject as table(
id int,
idExamen int,
idItem int,
respuesta varchar(200)
)
go

create type Edad as Table(
	anos int,
	meses int,
	dias int
)

go

use master
go