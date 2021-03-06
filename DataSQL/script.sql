USE [master]
GO
/****** Object:  Database [AnalisisClinico]    Script Date: 20/10/2016 18:33:26 ******/
CREATE DATABASE [AnalisisClinico]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AnalisisClinico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AnalisisClinico.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AnalisisClinico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AnalisisClinico_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AnalisisClinico] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnalisisClinico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnalisisClinico] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AnalisisClinico] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AnalisisClinico] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AnalisisClinico] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AnalisisClinico] SET ARITHABORT OFF 
GO
ALTER DATABASE [AnalisisClinico] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AnalisisClinico] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AnalisisClinico] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AnalisisClinico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AnalisisClinico] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AnalisisClinico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AnalisisClinico] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AnalisisClinico] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AnalisisClinico] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AnalisisClinico] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AnalisisClinico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AnalisisClinico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AnalisisClinico] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AnalisisClinico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AnalisisClinico] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AnalisisClinico] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AnalisisClinico] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AnalisisClinico] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AnalisisClinico] SET  MULTI_USER 
GO
ALTER DATABASE [AnalisisClinico] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AnalisisClinico] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AnalisisClinico] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AnalisisClinico] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AnalisisClinico] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AnalisisClinico]
GO
/****** Object:  UserDefinedTableType [dbo].[ExamenDetallesObject]    Script Date: 20/10/2016 18:33:27 ******/
CREATE TYPE [dbo].[ExamenDetallesObject] AS TABLE(
	[id] [int] NULL,
	[idExamen] [int] NULL,
	[idItem] [int] NULL,
	[respuesta] [varchar](200) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[ExamenesObject]    Script Date: 20/10/2016 18:33:27 ******/
CREATE TYPE [dbo].[ExamenesObject] AS TABLE(
	[idTemp] [int] NULL,
	[idOrdenDetalle] [int] NULL,
	[idPlantilla] [int] NULL,
	[fechaRegistro] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
	[fechaFinalizacion] [datetime] NULL,
	[estado] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[OrdenDetalleObject]    Script Date: 20/10/2016 18:33:27 ******/
CREATE TYPE [dbo].[OrdenDetalleObject] AS TABLE(
	[idTarifa] [int] NULL,
	[cobertura] [int] NULL,
	[total] [money] NULL
)
GO
/****** Object:  Table [dbo].[Area]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[codigo] [char](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuenta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellidos] [varchar](100) NOT NULL,
	[dni] [char](8) NOT NULL,
	[clave] [char](16) NOT NULL,
	[nivel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Examen]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPlantilla] [int] NOT NULL,
	[idOrdenDetalle] [int] NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[fechaModificacion] [datetime] NULL,
	[fechaFinalizacion] [datetime] NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamenDetalle]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExamenDetalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idItem] [int] NOT NULL,
	[idExamen] [int] NOT NULL,
	[respuesta] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[idPlantilla] [int] NOT NULL,
	[indice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoItem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idItem] [int] NOT NULL,
	[idGrupo] [int] NOT NULL,
	[indice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[idTipoItem] [int] NOT NULL,
	[idTipoCampo] [int] NOT NULL,
	[PorDefault] [varchar](200) NOT NULL,
	[tieneUnidad] [bit] NOT NULL,
	[unidad] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ListaItem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListaItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[idItem] [int] NOT NULL,
	[indice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orden](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](10) NULL,
	[idPaciente] [int] NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[ultimaModificacion] [date] NOT NULL,
	[estado] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenDetalle]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenDetalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTarifa] [int] NOT NULL,
	[idOrden] [int] NOT NULL,
	[cobertura] [int] NOT NULL,
	[total] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paciente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hclinica] [varchar](100) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellidoMat] [varchar](100) NOT NULL,
	[apellidoPat] [varchar](100) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[dni] [char](8) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[sexo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Plantilla]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plantilla](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[codigo] [char](5) NOT NULL,
	[tieneItem] [bit] NOT NULL DEFAULT ((0)),
	[tieneGrupo] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlantillaItem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantillaItem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idItem] [int] NOT NULL,
	[idPlantilla] [int] NOT NULL,
	[indice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlantillaTarifa]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantillaTarifa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTarifa] [int] NOT NULL,
	[idPlantilla] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seguridad]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seguridad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCuenta] [int] NOT NULL,
	[code] [varchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tarifa]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarifa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [char](5) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[idArea] [int] NOT NULL,
	[precio] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoCampo]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoCampo](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoItem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoItem](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Examen]  WITH CHECK ADD  CONSTRAINT [FK_ORDEN_RP] FOREIGN KEY([idOrdenDetalle])
REFERENCES [dbo].[OrdenDetalle] ([id])
GO
ALTER TABLE [dbo].[Examen] CHECK CONSTRAINT [FK_ORDEN_RP]
GO
ALTER TABLE [dbo].[Examen]  WITH CHECK ADD  CONSTRAINT [FK_Plantilla_RP] FOREIGN KEY([idPlantilla])
REFERENCES [dbo].[Plantilla] ([id])
GO
ALTER TABLE [dbo].[Examen] CHECK CONSTRAINT [FK_Plantilla_RP]
GO
ALTER TABLE [dbo].[ExamenDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PDETALLE_RPD] FOREIGN KEY([idItem])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[ExamenDetalle] CHECK CONSTRAINT [FK_PDETALLE_RPD]
GO
ALTER TABLE [dbo].[ExamenDetalle]  WITH CHECK ADD  CONSTRAINT [FK_REGISTRO_RPD] FOREIGN KEY([idExamen])
REFERENCES [dbo].[Examen] ([id])
GO
ALTER TABLE [dbo].[ExamenDetalle] CHECK CONSTRAINT [FK_REGISTRO_RPD]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Plantilla_G] FOREIGN KEY([idPlantilla])
REFERENCES [dbo].[Plantilla] ([id])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Plantilla_G]
GO
ALTER TABLE [dbo].[GrupoItem]  WITH CHECK ADD  CONSTRAINT [FK_GRUPO_IGI] FOREIGN KEY([idGrupo])
REFERENCES [dbo].[Grupo] ([id])
GO
ALTER TABLE [dbo].[GrupoItem] CHECK CONSTRAINT [FK_GRUPO_IGI]
GO
ALTER TABLE [dbo].[GrupoItem]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_IGI] FOREIGN KEY([idItem])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[GrupoItem] CHECK CONSTRAINT [FK_ITEM_IGI]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_TIPO_CAMPO_I] FOREIGN KEY([idTipoCampo])
REFERENCES [dbo].[TipoCampo] ([id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_TIPO_CAMPO_I]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_TIPO_I] FOREIGN KEY([idTipoItem])
REFERENCES [dbo].[TipoItem] ([id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_TIPO_I]
GO
ALTER TABLE [dbo].[ListaItem]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_LI] FOREIGN KEY([idItem])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[ListaItem] CHECK CONSTRAINT [FK_ITEM_LI]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_PACIENTE_OP] FOREIGN KEY([idPaciente])
REFERENCES [dbo].[Paciente] ([id])
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_PACIENTE_OP]
GO
ALTER TABLE [dbo].[OrdenDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ORDEN_OT] FOREIGN KEY([idOrden])
REFERENCES [dbo].[Orden] ([id])
GO
ALTER TABLE [dbo].[OrdenDetalle] CHECK CONSTRAINT [FK_ORDEN_OT]
GO
ALTER TABLE [dbo].[OrdenDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TARIFA_OT] FOREIGN KEY([idTarifa])
REFERENCES [dbo].[Tarifa] ([id])
GO
ALTER TABLE [dbo].[OrdenDetalle] CHECK CONSTRAINT [FK_TARIFA_OT]
GO
ALTER TABLE [dbo].[PlantillaItem]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_EI] FOREIGN KEY([idItem])
REFERENCES [dbo].[Item] ([id])
GO
ALTER TABLE [dbo].[PlantillaItem] CHECK CONSTRAINT [FK_ITEM_EI]
GO
ALTER TABLE [dbo].[PlantillaItem]  WITH CHECK ADD  CONSTRAINT [FK_Plantilla_EI] FOREIGN KEY([idPlantilla])
REFERENCES [dbo].[Plantilla] ([id])
GO
ALTER TABLE [dbo].[PlantillaItem] CHECK CONSTRAINT [FK_Plantilla_EI]
GO
ALTER TABLE [dbo].[PlantillaTarifa]  WITH CHECK ADD  CONSTRAINT [FK_Plantilla_PT] FOREIGN KEY([idPlantilla])
REFERENCES [dbo].[Plantilla] ([id])
GO
ALTER TABLE [dbo].[PlantillaTarifa] CHECK CONSTRAINT [FK_Plantilla_PT]
GO
ALTER TABLE [dbo].[PlantillaTarifa]  WITH CHECK ADD  CONSTRAINT [FK_TARIFA_PT] FOREIGN KEY([idTarifa])
REFERENCES [dbo].[Tarifa] ([id])
GO
ALTER TABLE [dbo].[PlantillaTarifa] CHECK CONSTRAINT [FK_TARIFA_PT]
GO
ALTER TABLE [dbo].[Seguridad]  WITH CHECK ADD  CONSTRAINT [FK_SEGURIDAD_CUENTA] FOREIGN KEY([idCuenta])
REFERENCES [dbo].[Cuenta] ([id])
GO
ALTER TABLE [dbo].[Seguridad] CHECK CONSTRAINT [FK_SEGURIDAD_CUENTA]
GO
ALTER TABLE [dbo].[Tarifa]  WITH CHECK ADD  CONSTRAINT [FK_AREA_GT] FOREIGN KEY([idArea])
REFERENCES [dbo].[Area] ([id])
GO
ALTER TABLE [dbo].[Tarifa] CHECK CONSTRAINT [FK_AREA_GT]
GO
/****** Object:  StoredProcedure [dbo].[add_area]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--delete from ExamenDetalle 
--delete from Examen
--delete from ordenDetalle 
--delete from Orden


create proc [dbo].[add_area]
@nombre varchar(100),
@codigo varchar(10)
as set nocount on
begin
	insert into Area(nombre,codigo) values
	(@nombre,@codigo)
end

GO
/****** Object:  StoredProcedure [dbo].[add_cuenta]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_cuenta]
@nombre varchar(100),
@apellidos varchar(100),
@dni char(8),
@clave char(16),
@nivel int
as set nocount on
begin
insert into cuenta(nombre,apellidos,dni,clave,nivel)
values(@nombre,@apellidos,@dni,@clave,@nivel)
end

GO
/****** Object:  StoredProcedure [dbo].[add_examen]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_examen]
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

GO
/****** Object:  StoredProcedure [dbo].[add_grupo]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_grupo]
@nombre varchar(100),
@idPlantilla int,
@indice int
as set nocount on
begin
	insert into Grupo(nombre,idPlantilla,indice) values
	(@nombre,@idPlantilla,@indice)
end

GO
/****** Object:  StoredProcedure [dbo].[add_grupo_item]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_grupo_item]
@idGrupo int,
@idItem int,
@indice int
as set nocount on
begin
	insert into GrupoItem(idItem,idGrupo,indice) values
	(@idItem,@idGrupo,@indice)
end

GO
/****** Object:  StoredProcedure [dbo].[add_item]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_item]
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

GO
/****** Object:  StoredProcedure [dbo].[add_listaitem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[add_listaitem]
@idItem int,
@nombre varchar(50),
@indice int
as set nocount on
begin
	insert into ListaItem(idItem,nombre,indice) values
	(@idItem,@nombre,@indice)
end

GO
/****** Object:  StoredProcedure [dbo].[add_orden]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_orden]
@id int output,
@numero varchar(15),
@idPaciente int,
@fecha date,
@ultimaModificacion date,
@estado int,
@detalle OrdenDetalleObject readonly
as set nocount on
begin
declare @msg varchar(100)
Begin Tran Tadd
    Begin Try
		insert into Orden(numero,idPaciente,fechaRegistro,ultimaModificacion,estado) values
		(@numero,@idPaciente,@fecha,@ultimaModificacion,@estado)
		SELECT @id = SCOPE_IDENTITY()
		insert into OrdenDetalle(idTarifa,idOrden,cobertura,total) 
		select idTarifa,@id,cobertura,total from @detalle 
		SET @msg = 'El Usuario se registro correctamente.'

		COMMIT TRAN Tadd
    End try
    Begin Catch
        SET @msg = 'Ocurrio un Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
        Rollback TRAN Tadd
		--THROW 60000, @msg, 1;  
    End Catch
end

GO
/****** Object:  StoredProcedure [dbo].[add_paciente]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_paciente]
@id int output,
@hc varchar(15),
@dni char(8),
@nombre varchar(50),
@apellidoP varchar(50),
@apellidoM varchar(50),
@direccion varchar(50),
@sexo int,
@fechaNac date
as set nocount on
begin
	insert into Paciente(hclinica,nombre,apellidoMat,apellidoPat,fechaNacimiento,dni,direccion,sexo) values
	(@hc,@nombre,@apellidoM,@apellidoP, @fechaNac,@dni,@direccion,@sexo)

	SELECT @id = SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[add_plantilla]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[add_plantilla]
@codigo varchar(10),
@nombre varchar(100),
@tieneItem bit,
@tieneGrupo bit
as set nocount on
begin
	insert into Plantilla(nombre,codigo,tieneItem,tieneGrupo) values
	(@nombre,@codigo,@tieneItem,@tieneGrupo)
end

GO
/****** Object:  StoredProcedure [dbo].[add_plantilla_item]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_plantilla_item]
@idPlantilla int,
@idItem int,
@indice int
as set nocount on
begin
	insert into PlantillaItem (idPlantilla,idItem,indice ) values
	(@idPlantilla,@idItem,@indice)
end

GO
/****** Object:  StoredProcedure [dbo].[add_plantillaTarifa]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_plantillaTarifa]
@idTarifa int,
@idPlantilla int
as set nocount on
begin
	insert into PlantillaTarifa(idTarifa,idPlantilla) values
	(@idTarifa,@idPlantilla)
end

GO
/****** Object:  StoredProcedure [dbo].[add_seguridad]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[add_seguridad]
@idCuenta int,
@codigo varchar(8)
as set nocount on
begin
insert into seguridad(idCuenta,code)
values(@idCuenta,@codigo)
end

GO
/****** Object:  StoredProcedure [dbo].[add_tarifa]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[add_tarifa]
@nombre varchar(100),
@idArea int,
@precio float,
@codigo varchar(5)
as set nocount on
begin
	insert into Tarifa(nombre,idArea,precio,codigo) values
	(@nombre,@idArea,@precio,@codigo)
end

GO
/****** Object:  StoredProcedure [dbo].[add_tipocampo]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[add_tipocampo]
@nombre varchar(50)
as set nocount on
begin
insert into TipoCampo(nombre) values
(@nombre)
end

GO
/****** Object:  StoredProcedure [dbo].[add_tipoitem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[add_tipoitem]
@nombre varchar(50)
as set nocount on
begin
insert into TipoItem(nombre) values
(@nombre)
end

GO
/****** Object:  StoredProcedure [dbo].[get_all_plantilla]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_all_plantilla]
as set nocount on
begin
select
Plantilla.id,Plantilla.nombre,Plantilla.codigo,tieneGrupo,tieneItem
from Plantilla
end

GO
/****** Object:  StoredProcedure [dbo].[get_all_tipoCampo]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_all_tipoCampo]
as set nocount on
begin
select 
 TipoCampo.id as id,TipoCampo.nombre as nombre
from TipoCampo
end

GO
/****** Object:  StoredProcedure [dbo].[get_all_tipoItem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec get_listaByItem 57
--delete from ListaItem
create proc [dbo].[get_all_tipoItem]
as set nocount on
begin
select 
 TipoItem.id as id,TipoItem.nombre as nombre
from TipoItem
end

GO
/****** Object:  StoredProcedure [dbo].[get_allOrdenByFechaByEstado]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_allOrdenByFechaByEstado]
@fechaInit date,
@fechaEnd date,
@estado int
as set nocount on
begin
select id,idPaciente,numero,fechaRegistro,ultimaModificacion,estado from Orden where estado=@estado and CONVERT(date, fechaRegistro)>=CONVERT(date, @fechaInit) and CONVERT(date, fechaRegistro)<=CONVERT(date, @fechaEnd)
end

GO
/****** Object:  StoredProcedure [dbo].[get_allOrdenByPaciente]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_allOrdenByPaciente]
@idPaciente int
as set nocount on
begin
select id,numero,fechaRegistro,ultimaModificacion,estado from Orden where idPaciente=@idPaciente
end

GO
/****** Object:  StoredProcedure [dbo].[get_allOrdenByPacienteByFecha]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[get_allOrdenByPacienteByFecha]
@idPaciente int,
@fechaInit date,
@fechaEnd date
as set nocount on
begin
select id,numero,fechaRegistro,ultimaModificacion,estado from Orden where idPaciente=@idPaciente and CONVERT(date, fechaRegistro)>=CONVERT(date, @fechaInit) and CONVERT(date, fechaRegistro)<=CONVERT(date, @fechaEnd)
end

GO
/****** Object:  StoredProcedure [dbo].[get_allOrdenByPacienteByFechaByEstado]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_allOrdenByPacienteByFechaByEstado]
@idPaciente int,
@fechaInit date,
@fechaEnd date,
@estado int
as set nocount on
begin
select id,idPaciente,numero,fechaRegistro,ultimaModificacion,estado from Orden where idPaciente=@idPaciente and estado=@estado and CONVERT(date, fechaRegistro)>=CONVERT(date, @fechaInit) and CONVERT(date, fechaRegistro)<=CONVERT(date, @fechaEnd)
end

GO
/****** Object:  StoredProcedure [dbo].[get_codPlantillaByTarifa]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[get_codPlantillaByTarifa]
@idTarifa int
as set nocount on
begin
select 
	Plantilla.id as id
from PlantillaTarifa 
inner join Plantilla on PlantillaTarifa.idPlantilla=Plantilla.id
where PlantillaTarifa.idTarifa=@idTarifa
end

GO
/****** Object:  StoredProcedure [dbo].[get_cuenta]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_cuenta]
@dni char(8)
as set nocount on
begin
select id,nombre,apellidos,clave,nivel from cuenta where dni=@dni
end

GO
/****** Object:  StoredProcedure [dbo].[get_examenByOrdenDetalle]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_examenByOrdenDetalle]
@idOrden int
as set nocount on
begin
select id,idPlantilla,fechaRegistro,fechaModificacion,fechaFinalizacion,estado from Examen 
where idOrdenDetalle=@idOrden
end

GO
/****** Object:  StoredProcedure [dbo].[get_examenDetalleByExamen]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_examenDetalleByExamen]
@idExamen int
as set nocount on
begin
select respuesta,idItem,id from ExamenDetalle
where idExamen=@idExamen
end

GO
/****** Object:  StoredProcedure [dbo].[get_exist]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[get_exist]
@dni char(8)   
as set nocount on
begin
select count(*) as num from cuenta where dni=@dni
end

GO
/****** Object:  StoredProcedure [dbo].[get_grupoByPlantilla]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[get_grupoByPlantilla]
@idPlantilla int
as set nocount on
begin
select 
	Grupo.id as id,Grupo.nombre as nombre,Grupo.indice
from Grupo 
where Grupo.idPlantilla=@idPlantilla
end

GO
/****** Object:  StoredProcedure [dbo].[get_itemByGrupo]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[get_itemByGrupo]
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

GO
/****** Object:  StoredProcedure [dbo].[get_itemByPlantilla]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_itemByPlantilla]
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

GO
/****** Object:  StoredProcedure [dbo].[get_listaByItem]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_listaByItem]
@idItem int
as set nocount on
begin
select 
 ListaItem.id as id,ListaItem.nombre as nombre,ListaItem.indice
from ListaItem 
where ListaItem.idItem=@idItem order by ListaItem.indice
end

GO
/****** Object:  StoredProcedure [dbo].[get_ordenByAreaByYearByMes]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--create proc get_ordenPendienteByPaciente
--@idPaciente int
--as set nocount on
--begin
--select id,numero,fechaRegistro,ultimaModificacion,estado from Orden where idPaciente=@idPaciente and estado=0
--end
--go

create proc [dbo].[get_ordenByAreaByYearByMes]
@idArea int,
@ano int,
@mes int
as set nocount on
begin 

SELECT OrdenDetalle.idTarifa,OrdenDetalle.total,OrdenDetalle.cobertura
FROM OrdenDetalle 
join Orden on Orden.id=OrdenDetalle.idOrden
join Tarifa on Tarifa.id=OrdenDetalle.idTarifa
join Area on Area.id= Tarifa.idArea
WHERE idArea=@idArea and MONTH(Orden.fechaRegistro)=@mes and YEAR(Orden.fechaRegistro)=@ano 
end

GO
/****** Object:  StoredProcedure [dbo].[get_ordenDetalleByOrden]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_ordenDetalleByOrden]
@idOrden int
as set nocount on
begin
select id,idTarifa,cobertura,total
from OrdenDetalle 
where idOrden=@idOrden
end

GO
/****** Object:  StoredProcedure [dbo].[get_ordenTerminadas]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[get_ordenTerminadas]
@fecha date
as set nocount on
begin
select id,numero,fechaRegistro,ultimaModificacion,estado,idPaciente from Orden where estado=3 and orden.fechaRegistro=@fecha;
end

GO
/****** Object:  StoredProcedure [dbo].[get_pacienteByDni]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_pacienteByDni]
@dni varchar(8)
as set nocount on
begin
select 
	Paciente.id,Paciente.hclinica,Paciente.nombre,Paciente.apellidoMat,Paciente.apellidoPat,Paciente.fechaNacimiento,Paciente.dni,Paciente.direccion,Paciente.sexo
from Paciente where dni=@dni
end

GO
/****** Object:  StoredProcedure [dbo].[get_pacienteByHistoria]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_pacienteByHistoria]
@historia varchar(15)
as set nocount on
begin
select 
	Paciente.id,Paciente.hclinica,Paciente.nombre,Paciente.apellidoMat,Paciente.apellidoPat,Paciente.fechaNacimiento,Paciente.dni,Paciente.direccion,Paciente.sexo
from Paciente where hclinica=@historia
end

GO
/****** Object:  StoredProcedure [dbo].[get_pacienteById]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_pacienteById]
@idPaciente int
as set nocount on
begin
select 
	Paciente.id,Paciente.hclinica,Paciente.nombre,Paciente.apellidoMat,Paciente.apellidoPat,Paciente.fechaNacimiento,Paciente.dni,Paciente.direccion,Paciente.sexo
from Paciente where id=@idPaciente
end

GO
/****** Object:  StoredProcedure [dbo].[get_plantilla]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_plantilla]
@codigo char(10)
as set nocount on
begin
select
Plantilla.id,Plantilla.nombre,Plantilla.tieneItem,Plantilla.tieneGrupo
from Plantilla
where Plantilla.codigo=@codigo;
end

GO
/****** Object:  StoredProcedure [dbo].[get_reporteByAreaByYear]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_reporteByAreaByYear]
@idArea int,
@ano int
as set nocount on
begin 
SELECT mes,numPar,totalPar,numSis,numExo
FROM Reporte
WHERE idArea=@idArea and ano=@ano 
end

GO
/****** Object:  StoredProcedure [dbo].[get_reporteMes]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_reporteMes]
@idArea int,
@cobertura int,
@ano int,
@mes int
as set nocount on
begin

--declare @idArea int=0
--declare  @cobertura int=0
--declare  @ano int=2016
--declare @mes int=8

select 
t.id, 
sum(t.precio) as Total,
count(*) as Cantidad, 
(select count(*) from OrdenDetalle odi
join Orden oi on oi.id=odi.idOrden
join Tarifa ti on ti.id=odi.idTarifa
where cobertura=@cobertura and year(oi.fechaRegistro)=@ano and month(oi.fechaRegistro)<@mes and ti.id=t.id) as acumuladoMesAnterior
from OrdenDetalle od
join Orden  o on o.id=od.idOrden
join Tarifa t on t.id=od.idTarifa
where t.idArea=@idArea and cobertura=@cobertura and year(o.fechaRegistro)=@ano and month(o.fechaRegistro)=@mes group by t.id 

end



GO
/****** Object:  StoredProcedure [dbo].[get_seguridad]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_seguridad]
@idCuenta int
as set nocount on
begin
select code from seguridad where idCuenta=@idCuenta
end

GO
/****** Object:  StoredProcedure [dbo].[get_tarifario]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[get_tarifario]
as set nocount on
begin
select 
	Tarifa.codigo,Tarifa.nombre,Tarifa.precio,Tarifa.id,Area.codigo as codArea,Area.id as idArea
from Tarifa 
inner join Area on Area.id=Tarifa.idArea
end

GO
/****** Object:  StoredProcedure [dbo].[update_examen]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[update_examen]
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

		update b Set b.fechaModificacion=a.fechaModificacion,b.fechaFinalizacion=a.fechaFinalizacion,b.estado=a.estado
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

GO
/****** Object:  StoredProcedure [dbo].[update_examen_single]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[update_examen_single]
@examenes ExamenesObject readonly,
@detalles ExamenDetallesObject readonly
as set nocount on
begin
Begin Tran Tadd
    Begin Try
		BEGIN
		update b Set b.fechaModificacion=a.fechaModificacion,b.fechaFinalizacion=a.fechaFinalizacion,b.estado=a.estado
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

GO
/****** Object:  StoredProcedure [dbo].[update_ordenByEstado]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[update_ordenByEstado]
@idOrden int,
@estado int
as set nocount on
begin 
update Orden set  estado=@estado where id=@idOrden
end

GO
/****** Object:  StoredProcedure [dbo].[update_seguridad]    Script Date: 20/10/2016 18:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[update_seguridad]
@idCuenta int,
@codigo varchar(8)
as set nocount on
begin
update seguridad set code=@codigo where idCuenta=@idCuenta
end

GO
USE [master]
GO
ALTER DATABASE [AnalisisClinico] SET  READ_WRITE 
GO
