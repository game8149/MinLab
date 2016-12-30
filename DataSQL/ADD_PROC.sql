-- ADD PROCEDURES

use AnalisisClinico
go

create proc ADD_CUENTA
@nombre varchar(100),
@primerApellido varchar(100),
@segundoApellido varchar(100),
@especialidad varchar(100),
@codigo varchar(100),
@dni char(8),
@clave char(16),
@nivel int
as set nocount on
begin
insert into cuenta(nombre,primerApellido,segundoApellido,especialidad,codigo,dni,clave,nivel)
values(@nombre,@primerApellido,@segundoApellido,@especialidad,@codigo,@dni,@clave,@nivel)
end
go

create proc ADD_SEGURIDAD
@idCuenta int,
@codigo varchar(8)
as set nocount on
begin
insert into seguridad(idCuenta,code)
values(@idCuenta,@codigo)
end
go

create proc ADD_ORDENDET
@id int ,
@detalleInsert OrdenDetalleObject readonly
as set nocount on
begin
declare @msg varchar(100)
Begin Tran Tadd
    Begin Try
		
		if((select count(*) from @detalleInsert) > 0)
		begin
			insert into OrdenDetalle(idPaquete,cobertura,idOrden) 
			(select idPaquete,cobertura,@id from @detalleInsert)
		end

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

create proc ADD_PLANTILLA
@codigo varchar(10),
@nombre varchar(100),
@tieneItem bit,
@tieneGrupo bit,
@area int
as set nocount on
begin
	insert into Plantilla(nombre,codigo,tieneItem,tieneGrupo,area) values
	(@nombre,@codigo,@tieneItem,@tieneGrupo,@area)
end
go

create proc ADD_ITEM
@nombre varchar(100),
@tipoItem int,
@tipoCampo int,
@PorDefault varchar(200),
@tieneUnidad bit,
@unidad varchar(20)
as set nocount on
begin
	insert into Item(nombre,idTipoItem,idTipoCampo,PorDefault,tieneUnidad,unidad) values
	(@nombre,@tipoItem,@tipoCampo,@PorDefault,@tieneUnidad,@unidad)
end
go

create proc ADD_GRUPO
@nombre varchar(100),
@idPlantilla int,
@indice int
as set nocount on
begin
	insert into Grupo(nombre,idPlantilla,indice) values
	(@nombre,@idPlantilla,@indice)
end
go

create proc ADD_GRUPOITEM
@idGrupo int,
@idItem int,
@indice int
as set nocount on
begin
	insert into GrupoItem(idItem,idGrupo,indice) values
	(@idItem,@idGrupo,@indice)
end
go

create proc ADD_PLANTILLA_ITEM
@idPlantilla int,
@idItem int,
@indice int
as set nocount on
begin
	insert into PlantillaItem (idPlantilla,idItem,indice ) values
	(@idPlantilla,@idItem,@indice)
end
go

create proc ADD_LISTAITEM
@idItem int,
@nombre varchar(50),
@indice int
as set nocount on
begin
	insert into ListaItem(idItem,nombre,indice) values
	(@idItem,@nombre,@indice)
end
go

create proc ADD_PACIENTE
@id int output,
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
	insert into Paciente(hclinica,nombre,apellido2,apellido1,fechaNacimiento,dni,direccion,sexo,idSector,idDistrito) values
	(@hc,@nombre,@apellidoM,@apellidoP, @fechaNac,@dni,@direccion,@sexo,@idSector,@idDistrito)

	SELECT @id = SCOPE_IDENTITY()
end
go

create proc ADD_ORDENCAB
@id int output,
@numero varchar(15),
@idPaciente int,
@fecha datetime,
@ultimaModificacion datetime,
@idMedico int,
@idConsultorio int,
@gestante bit,
@estado int,
@detalle OrdenDetalleObject readonly
as set nocount on
begin
declare @msg varchar(100)
Begin Tran Tadd
    Begin Try
		insert into Orden(numero,idPaciente,fechaRegistro,ultimaModificacion,estado,idMedico,idConsultorio,gestante) values
		(@numero,@idPaciente,@fecha,@ultimaModificacion,@estado,@idMedico,@idConsultorio,@gestante)
		SELECT @id = SCOPE_IDENTITY()
		insert into OrdenDetalle(idPaquete,idOrden,cobertura) 
		select idPaquete,@id,cobertura from @detalle 
		SET @msg = 'El Usuario se registro correctamente.'

		COMMIT TRAN Tadd
    End try
    Begin Catch
        SET @msg = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd;
		THROW 60000, @msg, 1;  
    End Catch
end
go

create proc ADD_PAQUETE
@nombre varchar(100),
@tipo int,
@codigo varchar(5)
as set nocount on
begin
	insert into Paquete(nombre,tipo,codigo) values
	(@nombre,@tipo,@codigo)
end
go

create proc ADD_PLANTILLAPAQUETE
@idPaquete int,
@idPlantilla int
as set nocount on
begin
	insert into PlantillaPaquete(idPaquete,idPlantilla) values
	(@idPaquete,@idPlantilla)
end
go

create proc ADD_EXAMEN
@examenes ExamenesObject readonly,
@detalles ExamenDetallesObject readonly
as set nocount on
begin
declare @total int
DECLARE @cnt INT = 1
DECLARE @msg varchar(100)
declare @idDefault int
set @total=(select count(*) from @examenes) + 1
Begin Tran Tadd
    Begin Try
		WHILE @cnt < @total
		BEGIN
		
		insert into Examen(idOrdenDetalle,idPlantilla,fechaRegistro,fechaModificacion,fechaFinalizacion,estado)
		(select idOrdenDetalle,idPlantilla,fechaRegistro,fechaModificacion,fechaFinalizacion,estado from @examenes where idTemp=@cnt)
		set @idDefault = SCOPE_IDENTITY()
		insert into ExamenDetalle(idExamen,idItem,respuesta) 
		(select @idDefault,idItem,respuesta from @detalles where idExamen=@cnt)
		
		SET @cnt = @cnt + 1;
		END

		SET @msg = 'El Usuario se registro correctamente.'

		COMMIT TRAN Tadd
    End try
    Begin Catch
        SET @msg = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd
		--THROW 60000, @msg, 1;  
    End Catch
end
go

use master
go