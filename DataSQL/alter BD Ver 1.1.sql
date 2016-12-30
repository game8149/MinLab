use AnalisisClinico

-- eliminar PROC

 Declare @procName varchar(500) 
    Declare cur Cursor For Select [name] From sys.objects where type = 'p' 
    Open cur 
    Fetch Next From cur Into @procName 
    While @@fetch_status = 0 
    Begin 
     Exec('drop procedure ' + @procName) 
     Fetch Next From cur Into @procName 
    End
    Close cur 
    Deallocate cur 

create table Consultorio
(
id int identity(1,1),
nombre varchar(100) not null,
primary key(id)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
)
GO

create table Sector
(
id int identity(1,1),
nombre varchar(100) not null,
idDistrito int not null,
primary key(id)
)
GO

create table Distrito
(
id int identity(1,1),
nombre varchar(100) not null,
primary key(id)
)
go

create table TarifarioCab
(
id int identity(1,1),
ano int not null,
fechaReg date not null,
vigente bit not null default 0
primary key(id)
)
go

create table TarifarioDet
(
id int identity(1,1),
idTarifarioCab int not null,
idPaquete int not null,
precio float not null  default 0.0
primary key(id)
)
go

create table Medico
(
id int identity(1,1),
nombre varchar(100) not null,
primerApellido varchar(100) not null,
segundoApellido varchar(100) not null,
especialidad varchar(100) not null,
colegiatura char(20) not null,
habil bit not null default 1
primary key(id)
)
go

CREATE TYPE OTARIFARIODET AS TABLE
(
ID INT,
PRECIO float,
IDPAQUETE INT,
IDTARIFARIOCAB INT
)
GO

ALTER TABLE Paciente ADD idSector int not null default 1

ALTER TABLE Paciente ADD idDistrito int not null default 4

ALTER TABLE Orden ADD gestante bit not null default 0

ALTER TABLE Orden ADD idConsultorio int not null default 1

ALTER TABLE Orden ADD idMedico int not null default 1

ALTER TABLE Cuenta ADD estado int not null default 0
go

ALTER TABLE Cuenta ADD Especialidad varchar(100) not null default ''
go

ALTER TABLE Cuenta ADD Codigo varchar(100) not null default ''
go

sp_RENAME 'Cuenta.Apellidos', 'PrimerApellido' , 'COLUMN'
go

alter table Cuenta add SegundoApellido varchar(100) not null default ''
go

ALTER TABLE SECTOR ADD CONSTRAINT FK_SECTOR_DIST FOREIGN KEY(IDDISTRITO) REFERENCES DISTRITO(ID)
GO

ALTER TABLE TARIFARIODET ADD CONSTRAINT FK_TAR_DET_CAB FOREIGN KEY(IDTARIFARIOCAB) REFERENCES TARIFARIOCAB(ID) ON DELETE CASCADE
GO

ALTER TABLE TARIFARIODET ADD CONSTRAINT FK_TAR_DET_PAQ FOREIGN KEY (IDPAQUETE) REFERENCES PAQUETE(ID) ON DELETE CASCADE
GO

create proc ADD_ADMMIN
@nombre varchar(100),
@primerApellido varchar(100),
@segundoApellido varchar(100),
@dni char(8),
@clave char(16),
@nivel int,
@code char(8)
as set nocount on
begin
insert into cuenta(nombre,primerApellido,segundoApellido,dni,clave,nivel)
values(@nombre,@primerApellido,@segundoApellido,@dni,@clave,@nivel)

insert into Seguridad(idCuenta,code) values(@@IDENTITY,@code)
end
go

create proc ADD_CONSULTORIO
@nombre VARCHAR(100)
as set nocount on
begin
insert into CONSULTORIO(nombre) values (@nombre)
end
go

create proc ADD_DISTRITO
@nombre VARCHAR(100)
as set nocount on
begin
insert into Distrito(nombre) values (@nombre)
end
go

create proc ADD_SECTOR
@nombre VARCHAR(100),
@idDistrito int
as set nocount on
begin
insert into Sector(nombre,idDistrito) values (@nombre,@idDistrito)
end
go

create proc ADD_MEDICO
@NOMBRE VARCHAR(100),
@PRIMERAPELLIDO VARCHAR(100),
@SEGUNDOAPELLIDO VARCHAR(100),
@ESPECIALIDAD VARCHAR(100),
@COLEGIATURA CHAR(20),
@habil bit
as set nocount on
begin
insert into MEDICO(nombre,primerApellido,segundoApellido,especialidad,colegiatura,habil) values (@NOMBRE,@PRIMERAPELLIDO,@SEGUNDOAPELLIDO,@ESPECIALIDAD,@COLEGIATURA,@habil)
end
go

CREATE PROC ADD_TARIFARIOCAB
@ANO int,
@FECHAREG DATE,
@VIGENTE BIT,
@DETALLE OTARIFARIODET READONLY
as set nocount on
begin
declare @msg varchar(100)
DECLARE @ID INT
Begin Tran Tadd
    Begin Try
		
		insert into TarifarioCab(ano,fechaReg,vigente) values (@ANO,@FECHAREG,@VIGENTE)
		SELECT @ID = SCOPE_IDENTITY()
		if((select count(*) from @DETALLE) > 0)
		begin
			insert into TarifarioDet(idPaquete,idTarifarioCab,precio) 
			(select IDPAQUETE,@ID,PRECIO from @DETALLE)
		end
		exec UPD_TARIFARIOCAB_VIGENTE @ID
		SET @msg = 'Se registraron datos correctamente.'

		COMMIT TRAN Tadd
    End try
    Begin Catch
        SET @msg = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd;
		THROW 60000, @msg, 1;  
    End Catch
end
GO

CREATE PROC UPD_CONSULTORIO
@ID INT,
@NOMBRE VARCHAR(100)
AS SET NOCOUNT ON
BEGIN
UPDATE CONSULTORIO SET nombre=@NOMBRE WHERE ID=@ID
END
GO

CREATE PROC UPD_DISTRITO
@ID INT,
@NOMBRE VARCHAR(100)
AS SET NOCOUNT ON
BEGIN
UPDATE DISTRITO SET nombre=@NOMBRE WHERE ID=@ID
END
GO

CREATE PROC UPD_SECTOR
@ID INT,
@NOMBRE VARCHAR(100),
@IDDISTRITO INT
AS SET NOCOUNT ON
BEGIN
UPDATE SECTOR SET nombre=@NOMBRE,idDistrito=@IDDISTRITO WHERE ID=@ID
END
GO

CREATE PROC UPD_MEDICO
@ID INT,
@NOMBRE VARCHAR(100),
@PRIMERAPELLIDO VARCHAR(100),
@SEGUNDOAPELLIDO VARCHAR(100),
@ESPECIALIDAD VARCHAR(100),
@COLEGIATURA CHAR(20),
@HABIL bit
AS SET NOCOUNT ON
BEGIN
UPDATE MEDICO SET nombre=@NOMBRE,primerApellido=@PRIMERAPELLIDO,segundoApellido=@SEGUNDOAPELLIDO,especialidad=@ESPECIALIDAD,colegiatura=@COLEGIATURA,habil=@habil WHERE ID=@ID
END
GO



CREATE PROC UPD_TARIFARIO
@ID int,
@ANO int,
@FECHAREG DATE,
@VIGENTE BIT,
@DETALLE OTARIFARIODET READONLY
as set nocount on
begin
declare @msg varchar(100)
Begin Tran Tadd
    Begin Try
		
		update TarifarioCab set vigente=@VIGENTE where id= @id
		update b Set b.precio=a.precio
		from @DETALLE a join TarifarioDet b on b.id=a.id

		SET @msg = 'Se registraron datos correctamente.'

		COMMIT TRAN Tadd
    End try
    Begin Catch
        SET @msg = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd;
		THROW 60000, @msg, 1;  
    End Catch
end
GO


CREATE PROC UPD_TARIFARIOCAB_VIGENTE
@ID int
AS SET NOCOUNT ON
BEGIN
UPDATE TarifarioCab SET vigente=0
UPDATE TarifarioCab SET vigente=1 where id=@ID

END
GO


CREATE PROC UPD_MEDICO_HABIL
@ID INT,
@HABIL BIT
AS SET NOCOUNT ON
BEGIN
UPDATE MEDICO SET habil=@HABIL WHERE ID=@ID
END
GO

CREATE PROC GET_MEDICO_ALL
AS SET NOCOUNT ON
BEGIN
SELECT ID,NOMBRE,PRIMERAPELLIDO,SEGUNDOAPELLIDO,COLEGIATURA,ESPECIALIDAD,HABIL FROM MEDICO
END
GO

CREATE PROC GET_MEDICO_ALL_HABIL
AS SET NOCOUNT ON
BEGIN
SELECT ID,NOMBRE,PRIMERAPELLIDO,SEGUNDOAPELLIDO,COLEGIATURA,ESPECIALIDAD,HABIL FROM MEDICO where HABIL=1
END
GO

CREATE PROC GET_MEDICO
@ID INT
AS SET NOCOUNT ON
BEGIN
SELECT ID,NOMBRE,PRIMERAPELLIDO,SEGUNDOAPELLIDO,COLEGIATURA,ESPECIALIDAD,HABIL FROM MEDICO WHERE MEDICO.ID=@ID
END
GO

CREATE PROC GET_TARIFARIOCAB_ALL
AS SET NOCOUNT ON
BEGIN 
SELECT ID,ANO,FECHAREG,VIGENTE FROM TARIFARIOCAB 
END 
GO

CREATE PROC GET_TARIFARIOCAB_HABIL
AS SET NOCOUNT ON
BEGIN 
SELECT ID,ANO,FECHAREG FROM TARIFARIOCAB WHERE VIGENTE=1
END 
GO

CREATE PROC GET_TARIFARIOCAB_BYANO
@ano int
AS SET NOCOUNT ON
BEGIN 
SELECT ID,ANO,FECHAREG FROM TARIFARIOCAB WHERE ano=@ano
END 
GO

CREATE PROC GET_TARIFARIOCAB_BYID
@ID INT
AS SET NOCOUNT ON
BEGIN 
SELECT ID,ANO,FECHAREG,VIGENTE FROM TARIFARIOCAB WHERE ID=@ID
END 
GO

CREATE PROC GET_TARIFARIOCAB_CHECK_BYYEAR
@YEAR INT
AS SET NOCOUNT ON
BEGIN 
SELECT count(*) as 'count' FROM TARIFARIOCAB WHERE ANO=@YEAR
END 
GO

CREATE PROC GET_TARIFARIODET_BYTARIFARIOCAB
@IDTARIFARIOCAB INT
AS SET NOCOUNT ON
BEGIN
SELECT ID,IDPAQUETE,PRECIO FROM TarifarioDet WHERE idTarifarioCab=@IDTARIFARIOCAB
END
GO

CREATE PROC GET_DISTRITO_ALL
AS SET NOCOUNT ON
BEGIN 
SELECT ID,NOMBRE FROM DISTRITO 
END 
GO

CREATE PROC GET_SECTOR_BYDISTRITO
@IDDISTRITO INT
AS SET NOCOUNT ON
BEGIN 
SELECT ID,NOMBRE,IDDISTRITO FROM SECTOR  WHERE IDDISTRITO=@IDDISTRITO
END 
GO

CREATE PROC GET_CONSULTORIO_ALL
AS SET NOCOUNT ON
BEGIN 
SELECT ID,NOMBRE FROM CONSULTORIO 
END 
GO

CREATE PROC DEL_TARIFARIOCAB
@ID INT
AS SET NOCOUNT ON
BEGIN
DELETE FROM TarifarioCab WHERE ID=@ID
END
GO

CREATE PROC DEL_MEDICO
@ID INT
AS SET NOCOUNT ON
BEGIN
DELETE FROM MEDICO WHERE ID=@ID
END
GO


EXEC ADD_DISTRITO 'LA ESPERANZA' 
EXEC ADD_DISTRITO 'TRUJILLO' 
EXEC ADD_DISTRITO 'HUANCHACO' 
EXEC ADD_DISTRITO 'OTROS' 


EXEC ADD_SECTOR 'OTROS' ,4
EXEC ADD_SECTOR 'EL TRIUNFO' ,1
EXEC ADD_SECTOR 'LOS PINOS' ,1
EXEC ADD_SECTOR 'SANTA ROSA' ,1
EXEC ADD_SECTOR 'VIRGEN DEL SOCORRO' ,1
EXEC ADD_SECTOR 'SOL NACIENTE' ,1
EXEC ADD_SECTOR '4 SUYOS' ,1
EXEC ADD_SECTOR 'PRIMAVERA I' ,1
EXEC ADD_SECTOR 'PRIMAVERA II' ,1
EXEC ADD_SECTOR 'PRIMAVERA III' ,1
EXEC ADD_SECTOR 'RAMIRO PRIALE' ,1
EXEC ADD_SECTOR 'WICHANZAO' ,1
EXEC ADD_SECTOR 'CLEMENTINA PERALTA' ,1
EXEC ADD_SECTOR 'MARIA E. MOYANO' ,1
EXEC ADD_SECTOR 'LAS LOMAS DE WICHANZAO' ,1
EXEC ADD_SECTOR 'LOS HUERTOS' ,1
EXEC ADD_SECTOR 'TACABAMBA' ,1
EXEC ADD_SECTOR 'RICHARD ACUÑA' ,1
EXEC ADD_SECTOR 'NUEVO HORIZONTE' ,1
EXEC ADD_SECTOR 'PUEBLO LIBRE' ,1
EXEC ADD_SECTOR 'JERUSALEN' ,1
EXEC ADD_SECTOR 'SAN MARTIN' ,1
EXEC ADD_SECTOR 'BELLAVISTA' ,1
EXEC ADD_SECTOR 'SANTISIMO SACRAMENTO' ,1
EXEC ADD_SECTOR 'MANUEL AREVALO' ,1
EXEC ADD_SECTOR 'LOS BRILLANTES' ,1
EXEC ADD_SECTOR 'EL MILAGRO' ,3
EXEC ADD_SECTOR 'OTROS' ,1
EXEC ADD_SECTOR 'OTROS' ,2
EXEC ADD_SECTOR 'OTROS' ,3
EXEC ADD_SECTOR 'PARQUE INDUSTRIAL' ,1
EXEC ADD_SECTOR 'SANTA VERONICA' ,1

exec ADD_MEDICO 'OTROS','OTROS','OTROS','NINGUNA','00000000',1

EXEC ADD_CONSULTORIO 'MEDICINA'
EXEC ADD_CONSULTORIO 'OBSTETRICIA'
EXEC ADD_CONSULTORIO 'CRECIMIENTO Y DESARROLLO'
EXEC ADD_CONSULTORIO 'SALUD DEL ESCOLAR'
EXEC ADD_CONSULTORIO 'NUTRICION'
EXEC ADD_CONSULTORIO 'NO TRANSMISIBLES'
EXEC ADD_CONSULTORIO 'ODONTOLOGIA'
EXEC ADD_CONSULTORIO 'EMERGENCIA'
EXEC ADD_CONSULTORIO 'HOSPITALIZACION'
EXEC ADD_CONSULTORIO 'OTROS'


alter table Paciente add constraint fk_paciente_sector foreign key(idSector) references Sector(id)
alter table Paciente add constraint fk_paciente_distrito foreign key(idDistrito) references Distrito(id)

alter table orden add constraint fk_orden_medico foreign key(idMedico) references Medico(id)
alter table orden add constraint fk_orden_consultorio foreign key(idConsultorio) references Consultorio(id)


exec ADD_ADMMIN 'Alexis','Gavidia','Meza','70189004','alexis81',0,'alexis81'
go
