use AnalisisClinico
go


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


create proc UPD_ORDENCAB
@id int,
@numero varchar(15),
@fecha datetime,
@ultimaModificacion datetime,
@estado int,
@idConsultorio int,
@idMedico int,
@gestante bit
as set nocount on
begin 
update Orden
		set numero=@numero,fechaRegistro=@fecha,ultimaModificacion=@ultimaModificacion,estado=@estado,gestante=@gestante,idMedico=@idMedico,idConsultorio=@idConsultorio
		where id=@id
end
go

create proc UPD_EXAMEN_SINGLE
@examenes ExamenesObject readonly,
@detalles ExamenDetallesObject readonly
as set nocount on
begin
Begin Tran Tadd
    Begin Try
		BEGIN
		update b Set b.fechaModificacion=a.fechaModificacion,b.fechaFinalizacion=a.fechaFinalizacion,b.estado=a.estado,b.idCuenta=a.idCuenta
		from @examenes a join Examen b on b.id=a.idTemp

		update b Set b.respuesta=a.respuesta
		from @detalles a join ExamenDetalle b on b.id=a.id

		END
		COMMIT TRAN Tadd
    End try
    Begin Catch
        Rollback TRAN Tadd
		--THROW 60000, @msg, 1;  
    End Catch
end
go

create proc UPD_EXAMEN
@idOrden int,
@estado int,
@examenes ExamenesObject readonly,
@detalles ExamenDetallesObject readonly
as set nocount on
begin
Begin Tran Tadd
    Begin Try
		BEGIN
		update Orden set  estado=@estado where id=@idOrden

		update b Set b.fechaModificacion=a.fechaModificacion,b.fechaFinalizacion=a.fechaFinalizacion,b.estado=a.estado,b.idCuenta=a.idCuenta
		from @examenes a join Examen b on b.id=a.idTemp

		update b Set b.respuesta=a.respuesta
		from @detalles a join ExamenDetalle b on b.id=a.id

		END
		COMMIT TRAN Tadd
    End try
    Begin Catch
        Rollback TRAN Tadd
		--THROW 60000, @msg, 1;  
    End Catch
end
go

create proc UPD_ORDENDET
@id int ,
@detalleUpdate OrdenDetalleObject readonly
as set nocount on
begin
declare @msg varchar(100)
Begin Tran Tadd
    Begin Try

		update b Set b.cobertura=a.cobertura
			from @detalleUpdate a join OrdenDetalle b on b.id=a.idTemp
		
		SET @msg = 'Se registraron datos correctamente.'

		COMMIT TRAN Tadd
    End try
    Begin Catch
        SET @msg = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd;
		THROW 60000, @msg, 1;  
    End Catch
end
go

create proc UPD_PACIENTE
@id int ,
@hc varchar(15),
@dni char(8),
@nombre varchar(50),
@apellidoP varchar(50),
@apellidoM varchar(50),
@direccion varchar(50),
@sexo int,
@fechaNac date,
@idSector int,
@idDistrito int
as set nocount on
begin
	update Paciente
	set hclinica=@hc,nombre=@nombre,apellido2=@apellidoM,apellido1=@apellidoP,fechaNacimiento=@fechaNac,dni=@dni,direccion=@direccion,sexo=@sexo,idDistrito=@idDistrito,idSector=@idSector
	where id=@id
end
go

create proc UPD_SEGURIDAD
@idCuenta int,
@codigo varchar(8)
as set nocount on
begin
update seguridad set code=@codigo where idCuenta=@idCuenta
end
go


create proc UPD_CUENTA
@IDCUENTA INT,
@NOMBRE VARCHAR(100),
@PRIMERAPELLIDO VARCHAR(100),
@SEGUNDOAPELLIDO VARCHAR(100),
@ESPECIALIDAD VARCHAR(100),
@codigo varchar(100),
@DNI CHAR(8)
as set nocount on
begin
update CUENTA set NOMBRE=@NOMBRE,DNI=@DNI,PRIMERAPELLIDO=@PRIMERAPELLIDO,SEGUNDOAPELLIDO=@SEGUNDOAPELLIDO,ESPECIALIDAD=@ESPECIALIDAD,codigo=@codigo where ID=@IDCUENTA
end
go

create proc UPD_CUENTA_CLAVE
@IDCUENTA INT,
@CLAVE CHAR(16)
as set nocount on
begin
update CUENTA set CLAVE=@CLAVE where ID=@IDCUENTA
end
go
