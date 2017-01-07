
USE ANALISISCLINICO

go


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


create proc DEL_PACIENTE
@idPaciente int
as set nocount on
begin 
delete Paciente
	where id=@idPaciente
end
go

create proc DEL_ORDENCAB
@idOrden int
as set nocount on
begin 
delete Orden
	where id=@idOrden
end
go

create proc DEL_ORDENDET
@id int ,
@detalleDeleted OrdenDetalleObject readonly
as set nocount on
begin
declare @msg varchar(100)
Begin Tran Tadd
    Begin Try
		
		delete OrdenDetalle where id in (select idTemp from @detalleDeleted)
	
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
