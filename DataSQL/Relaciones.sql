use AnalisisClinico
go

alter table ListaItem add constraint FK_ITEM_LI foreign key(idItem) references Item(id)
go

alter table GrupoItem add constraint FK_ITEM_IGI foreign key(idItem) references Item(id)
go

alter table GrupoItem add constraint FK_GRUPO_IGI foreign key(idGrupo) references Grupo(id)
go

alter table PlantillaItem add constraint FK_ITEM_EI foreign key(idItem) references Item(id)
go

alter table PlantillaItem add constraint FK_Plantilla_EI foreign key(idPlantilla) references Plantilla(id)
go

alter table Grupo add constraint FK_Plantilla_G foreign key(idPlantilla) references Plantilla(id)
go

alter table PlantillaPaquete add constraint FK_Plantilla_PT foreign key(idPlantilla) references Plantilla(id)
go

alter table PlantillaPaquete add constraint FK_Paquete_PT foreign key(idPaquete) references Paquete(id)
go

alter table OrdenDetalle add constraint FK_Paquete_OT foreign key(idPaquete) references Paquete(id)
go

alter table OrdenDetalle add constraint FK_ORDEN_OT foreign key(idOrden) references Orden(id) on delete cascade
go

alter table Orden add constraint FK_PACIENTE_OP foreign key(idPaciente) references Paciente(id) on delete cascade
go

alter table Examen add constraint FK_ORDEN_RP foreign key(idOrdenDetalle) references OrdenDetalle(id) on delete cascade
go

alter table Examen add constraint FK_Plantilla_RP foreign key(idPlantilla) references Plantilla(id)
go

alter table ExamenDetalle add constraint FK_PDETALLE_RPD foreign key(idItem) references Item(id) 
go

alter table ExamenDetalle add constraint FK_REGISTRO_RPD foreign key(idExamen) references Examen(id) on delete cascade
go

alter table seguridad add constraint FK_SEGURIDAD_CUENTA foreign key(idCuenta) references Cuenta(id)
go


