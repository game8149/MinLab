use AnalisisClinico
go


create proc GET_CUENTA
@dni char(8)
as set nocount on
begin
select id,nombre,primerApellido,segundoApellido,especialidad,codigo,clave,nivel from cuenta where dni=@dni
end
go

create proc GET_CUENTA_EXISTE
@dni char(8)   
as set nocount on
begin
select count(*) as num from cuenta where dni=@dni
end
go

create proc GET_SEGURIDAD
@idCuenta int
as set nocount on
begin
select code from seguridad where idCuenta=@idCuenta
end
go

create proc GET_PLANTILLA_ALL
as set nocount on
begin
select
Plantilla.id,Plantilla.nombre,Plantilla.codigo,Plantilla.tieneGrupo,Plantilla.tieneItem,Plantilla.area
from Plantilla
end
go

create proc GET_PLANTILLA
@codigo char(10)
as set nocount on
begin
select
Plantilla.id,Plantilla.nombre,Plantilla.tieneItem,Plantilla.tieneGrupo, Plantilla.area
from Plantilla
where Plantilla.codigo=@codigo;
end
go

create proc GET_ITEM_BYPLANTILLA
@idPlantilla int
as set nocount on
begin
select 
	Item.id as id,
	Item.idTipoItem as idTipoItem,
	Item.idTipoCampo as idTipoCampo,
	Item.nombre as nombre,
	Item.PorDefault as porDefault,
	PlantillaItem.indice as indice,
	Item.tieneUnidad,
	Item.unidad
from Item 
inner join PlantillaItem on PlantillaItem.idItem=Item.id
inner join Plantilla on PlantillaItem.idPlantilla=Plantilla.id
where Plantilla.id=@idPlantilla
end
go

create proc GET_ITEM_BYGRUPO
@idGrupo int
as set nocount on
begin
select 
	Item.nombre as nombre, 
	Item.id,
	Item.idTipoItem,
	Item.idTipoCampo as idTipoCampo,
	Item.PorDefault as porDefault,
	GrupoItem.indice as indice,
	Item.tieneUnidad,
	Item.unidad
from Item 
inner join GrupoItem on Item.id=GrupoItem.idItem 
where GrupoItem.idGrupo=@idGrupo
end
go

create proc GET_GRUPO_BYPLANTILLA
@idPlantilla int
as set nocount on
begin
select 
	Grupo.id as id,Grupo.nombre as nombre,Grupo.indice
from Grupo 
where Grupo.idPlantilla=@idPlantilla
end
go

create proc GET_LISTA_BYITEM
@idItem int
as set nocount on
begin
select 
 ListaItem.id as id,ListaItem.nombre as nombre,ListaItem.indice
from ListaItem 
where ListaItem.idItem=@idItem order by ListaItem.indice
end
go

create proc GET_PLANTILLA_COD_BYPAQUETE
@idPaquete int
as set nocount on
begin
select 
	Plantilla.id as id
from PlantillaPaquete 
inner join Plantilla on PlantillaPaquete.idPlantilla=Plantilla.id
where PlantillaPaquete.idPaquete=@idPaquete
end
go

create proc GET_PAQUETE_ALL
as set nocount on
begin
select 
	Paquete.codigo,Paquete.nombre,Paquete.id,Paquete.tipo
from Paquete 
end
go

create proc GET_PACIENTE_BYHISTORIA
@historia varchar(15)
as set nocount on
begin
select 
	Paciente.id,Paciente.hclinica,Paciente.nombre,Paciente.apellido2,Paciente.apellido1,Paciente.fechaNacimiento,Paciente.dni,Paciente.direccion,Paciente.sexo
from Paciente where hclinica=@historia
end
go

create proc GET_PACIENTE_BYDNI
@dni varchar(8)
as set nocount on
begin
select 
	Paciente.id,Paciente.hclinica,Paciente.nombre,Paciente.apellido2,Paciente.apellido1,Paciente.fechaNacimiento,Paciente.dni,Paciente.direccion,Paciente.sexo,Paciente.idSector,Paciente.idDistrito
from Paciente where dni=@dni
end
go

create proc GET_PACIENTE_BYID
@idPaciente int
as set nocount on
begin
select 
	Paciente.id,Paciente.hclinica,Paciente.nombre,Paciente.apellido2,Paciente.apellido1,Paciente.fechaNacimiento,Paciente.dni,Paciente.direccion,Paciente.sexo,Paciente.idSector,Paciente.idDistrito
from Paciente where id=@idPaciente
end
go

create proc GET_ORDENCAB_ALL_BYPACIENTE
@idPaciente int
as set nocount on
begin
select id,numero,fechaRegistro,ultimaModificacion,estado,gestante,idConsultorio,idMedico from Orden where idPaciente=@idPaciente
end
go

create proc GET_ORDENCAB_ALL_BYPACIENTE_BYFECHA
@idPaciente int,
@fechaInit date,
@fechaEnd date
as set nocount on
begin
select id,numero,fechaRegistro,ultimaModificacion,estado,gestante,idConsultorio,idMedico from Orden where idPaciente=@idPaciente and CONVERT(date, fechaRegistro)>=CONVERT(date, @fechaInit) and CONVERT(date, fechaRegistro)<=CONVERT(date, @fechaEnd)
end
go

create proc GET_ORDENCAB_ALL_BYPACIENTE_BYFECHA_BYESTADO
@idPaciente int,
@fechaInit date,
@fechaEnd date,
@estado int
as set nocount on
begin
select id,idPaciente,numero,fechaRegistro,ultimaModificacion,estado,gestante,idConsultorio,idMedico from Orden where idPaciente=@idPaciente and estado=@estado and CONVERT(date, fechaRegistro)>=CONVERT(date, @fechaInit) and CONVERT(date, fechaRegistro)<=CONVERT(date, @fechaEnd)
end
go

create proc GET_ORDENCAB_ALL_BYFECHA_BYESTADO
@fechaInit date,
@fechaEnd date,
@estado int
as set nocount on
begin
select id,idPaciente,numero,fechaRegistro,ultimaModificacion,estado,gestante,idConsultorio,idMedico from Orden where estado=@estado and CONVERT(date, fechaRegistro)>=CONVERT(date, @fechaInit) and CONVERT(date, fechaRegistro)<=CONVERT(date, @fechaEnd)
end
go

create proc GET_ORDENCAB_BYID
@idOrden int
as set nocount on
begin
select id,idPaciente,numero,fechaRegistro,ultimaModificacion,estado,gestante,idConsultorio,idMedico from Orden where id=@idOrden
end
go

create proc GET_ORDENDET_BYORDENCAB
@idOrden int
as set nocount on
begin
select id,idPaquete,cobertura
from OrdenDetalle 
where idOrden=@idOrden
end
go

create proc GET_EXAMENCAB_BYORDENDET
@idOrden int
as set nocount on
begin
select id,idPlantilla,fechaRegistro,fechaModificacion,fechaFinalizacion,estado from Examen 
where idOrdenDetalle=@idOrden
end
go

create proc GET_EXAMENCAB_EXISTE
@idOrdenDetalle int
as set nocount on
begin
select count(*) as num from Examen 
where idOrdenDetalle=@idOrdenDetalle
end
go

create proc GET_EXAMENDET_BYEXAMENCAB
@idExamen int
as set nocount on
begin
select respuesta,idItem,id from ExamenDetalle
where idExamen=@idExamen
end
go

create proc GET_REPORTE_ACUMULADOMES 
@cobertura int,
@ano int,
@mes int
as set nocount on
begin
select paq.id as idPaquete,count(*) as cantidad from 
OrdenDetalle odi
join Paquete paq on odi.idPaquete=paq.id
join Orden oi on oi.id=odi.idOrden
where odi.cobertura=@cobertura and year(oi.fechaRegistro)=@ano and month(oi.fechaRegistro)<@mes group by paq.id
end
go

create proc GET_REPORTE_CANTIDADMES
@cobertura int,
@ano int,
@mes int
as set nocount on
begin

select 
paq.id as idPaquete, 
count(*) as cantidad
from OrdenDetalle od
full join Paquete paq on od.idPaquete=paq.id
full join Orden  o on o.id=od.idOrden
where od.cobertura=@cobertura and year(o.fechaRegistro)=@ano and month(o.fechaRegistro)=@mes group by paq.id 

end
go 

create proc GET_REPORTE_EDAD
@cobertura int,
@ano int,
@mes int
as set nocount on
begin

select 
paq.id as idPaquete, 
 
(select count(*) from OrdenDetalle odi 
join Orden oi on oi.id=odi.idOrden
join Paciente pa on pa.id=oi.idPaciente
where odi.cobertura=@cobertura and year(oi.fechaRegistro)=@ano and month(oi.fechaRegistro)=@mes and odi.idPaquete =paq.id and dbo.calcularEdad(pa.fechaNacimiento,oi.fechaRegistro)<1.0000) as c0, -- <1año

(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 1.0000 ) as c1, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 2.0000 ) as c2, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 3.0000 ) as c3, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 4.0000 ) as c4, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 5.0000 ) as c5, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 6.0000 ) as c6, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 7.0000 ) as c7, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 8.0000 ) as c8, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 9.0000 ) as c9, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 10.0000 ) as c10, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 11.0000 ) as c11, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 12.0000 ) as c12, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 13.0000 ) as c13, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 14.0000 ) as c14, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 15.0000 ) as c15, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 16.0000 ) as c16, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 17.0000 ) as c17, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 18.0000 ) as c18, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = 19.0000 ) as c19, 
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 20.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 24.0000) as c20,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 25.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 29.0000) as c25,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 30.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 34.0000) as c30,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 35.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 39.0000) as c35,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 40.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 44.0000) as c40,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 45.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 49.0000) as c45,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 50.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 54.0000) as c50,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 55.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 59.0000) as c55,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 60.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 64.0000) as c60,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 65.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 69.0000) as c65,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 70.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 74.0000) as c70,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and odi.idPaquete  = paq.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= 75.0000  and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= 79.0000) as c75,
(select count(*) from  OrdenDetalle odi  join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id=oi.idPaciente where odi.cobertura=@cobertura and year(oi.fechaRegistro)=@ano and month(oi.fechaRegistro)=@mes and odi.idPaquete =paq.id and dbo.calcularEdad(pa.fechaNacimiento,oi.fechaRegistro)>=80.0000) as c80

from Paquete paq group by paq.id 

end
go


create proc GET_REPORTE_MEDICO_ACUMULADOMES 
@idMedico int,
@cobertura int,
@ano int,
@mes int
as set nocount on
begin
select
paq.id as idPaquete,
(select count(*) from OrdenDetalle odi join Orden oi on oi.id=odi.idOrden where odi.idPaquete=paq.id and  odi.cobertura=@cobertura and year(oi.fechaRegistro)=@ano and month(oi.fechaRegistro)<@mes and oi.idMedico=@idMedico )  as cantidad
from Paquete paq group by paq.id
end
go

create proc GET_REPORTE_MEDICO_CANTIDADMES
@idMedico int,
@cobertura int,
@ano int,
@mes int
as set nocount on
begin

select 
paq.id as idPaquete, 
(select count(*) from  Orden  o full join  OrdenDetalle od on od.idOrden=o.id where od.idPaquete=paq.id and o.idMedico=@idMedico and od.cobertura=@cobertura and year(o.fechaRegistro)=@ano and month(o.fechaRegistro)=@mes) as cantidad
from Paquete paq
group by paq.id 

end
go 


create proc GET_REPORTE_RESULTADO
@ano int,
@mes int
as set nocount on
begin

select 
ex.idPlantilla as idPlantilla,
ex.estado as estado,
pac.dni,
pac.nombre,
pac.apellido1,
pac.apellido2,
dbo.calcularEdad(pac.fechaNacimiento,o.fechaRegistro) as edad,
pac.sexo,
o.gestante,
odet.cobertura as cobertura,
exdet.respuesta as respuesta,
itd.unidad 
from Examen ex join  ExamenDetalle exdet on ex.id = exdet.idExamen join OrdenDetalle odet on odet.id=ex.idOrdenDetalle join Item itd on itd.id=exdet.idItem join Orden o on o.id = odet.idOrden join Paciente pac on pac.id=o.idPaciente  
where
year(o.fechaRegistro)=@ano and 
month(o.fechaRegistro)=@mes and
(select count(*) from PlantillaItem pli join Plantilla pl on pl.id=pli.idPlantilla join Item it on it.id=pli.idItem  where pl.id=ex.idPlantilla and (it.idTipoCampo = 0))=1

end
go

use master