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
