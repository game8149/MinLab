use AnalisisClinico
go

CREATE PROC CONTAR_EXAMEN(@OPER CHAR(2),@PL_ID INT,@COBERTURA INT,@YEAR INT,@MES INT, @EDAD FLOAT,@COUNT INT OUTPUT)
AS SET NOCOUNT ON
BEGIN
	IF(@OPER='=')
	BEGIN
		select @COUNT=count(*) from Examen ex
		join OrdenDetalle odi on odi.id=ex.idOrdenDetalle
		join Orden oi on oi.id=odi.idOrden
		join Paciente pa on pa.id=oi.idPaciente
		where 
			odi.cobertura=@cobertura and 
			year(oi.fechaRegistro)=@YEAR and 
			month(oi.fechaRegistro)=@MES and 
			ex.idPlantilla=@PL_ID and 
			dbo.calcularEdad(pa.fechaNacimiento,oi.fechaRegistro)=@EDAD 
	END

	ELSE IF(@OPER='<')
	BEGIN
		select @COUNT=count(*) from Examen ex
		join OrdenDetalle odi on odi.id=ex.idOrdenDetalle
		join Orden oi on oi.id=odi.idOrden
		join Paciente pa on pa.id=oi.idPaciente
		where 
			odi.cobertura=@cobertura and 
			year(oi.fechaRegistro)=@YEAR and 
			month(oi.fechaRegistro)=@MES and 
			ex.idPlantilla=@PL_ID and 
			dbo.calcularEdad(pa.fechaNacimiento,oi.fechaRegistro)<@EDAD 
	END

	ELSE IF(@OPER='>')
	BEGIN
		select @COUNT=count(*) from Examen ex
		join OrdenDetalle odi on odi.id=ex.idOrdenDetalle
		join Orden oi on oi.id=odi.idOrden
		join Paciente pa on pa.id=oi.idPaciente
		where 
			odi.cobertura=@cobertura and 
			year(oi.fechaRegistro)=@YEAR and 
			month(oi.fechaRegistro)=@MES and 
			ex.idPlantilla=@PL_ID and 
			dbo.calcularEdad(pa.fechaNacimiento,oi.fechaRegistro)>@EDAD 
	END

	PRINT @COUNT

END
GO


CREATE function calcularEdad(@fechaNacimiento date, @actual date) 
RETURNS DECIMAL(18,4)
AS
BEGIN  
    
	DECLARE @tiempo DATE;

	DECLARE @anos INT;
	DECLARE @meses INT;
	DECLARE @dias INT;

	DECLARE @DiasAno INT;
	DECLARE @DiasMes INT;

	SET @anos = (Year(@actual) - Year(@fechaNacimiento));
	SET @meses = (Month(@actual) - Month(@fechaNacimiento));
	SET @dias = (Day(@actual) - Day(@fechaNacimiento));

	if @meses < 0
	begin
		SET @anos -= 1;
		SET @meses += 12;
	end

	if @dias < 0
	begin
		SET @meses -= 1;
		SET @DiasAno = YEAR(@actual);
		SET @DiasMes = MONTH(@actual);

		IF ((MONTH(@actual) - 1) = 0)
		BEGIN
			SET @DiasAno = @DiasAno - 1;
			SET @DiasMes = 12;
		END
		ELSE 
		begin
			SET @DiasMes = @DiasMes - 1;
		end

		DECLARE @date VARCHAR(255) = concat('03/',@DiasMes,'/',@DiasAno);  
		
		SET @tiempo= (SELECT EOMONTH ( @date ));
		

		SET @dias += Day(EOMONTH(@tiempo));
	end
      
	DECLARE @total DECIMAL(18,4); --12,1412

	set @total = cast(@dias as DECIMAL(18,4))/10000+ cast(@meses as DECIMAL(18,4))/100 + cast(@anos as DECIMAL(18,4)) +0.0000;
	
	return @total;
end

--select ((dbo.calcularEdad('01/08/2014',getdate())*100)%1)*100 --dias
--go 
	
--select ((dbo.calcularEdad('01/08/2014',getdate()))%1)*100 --meses
--go 
		
--select dbo.calcularEdad('01/08/2014',getdate())--anos
go