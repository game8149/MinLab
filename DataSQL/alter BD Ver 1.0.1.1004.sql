
use AnalisisClinico;


ALTER TABLE Examen ADD idCuenta int not null default 3; -- todos a senor jorge

alter  TABLE Examen add constraint FK_Examen_cuenta foreign key(idCuenta) references Cuenta(id)

Drop type examenesObject

--Tipos de Datos;
create type ExamenesObject as table(
idTemp int,
idOrdenDetalle int,
idPlantilla int,
fechaRegistro datetime,
fechaModificacion datetime,
fechaFinalizacion datetime,
idCuenta int,
estado int
)


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

go
