
use AnalisisClinico;

DROP proc UPD_ORDENCAB
go

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