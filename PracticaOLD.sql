USE [master]
GO
/****** Object:  Database [Cerveceria]    Script Date: 7/11/2019 18:32:59 ******/
CREATE DATABASE [Cerveceria] ON  PRIMARY 
( NAME = N'Cerveceria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Cerveceria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cerveceria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Cerveceria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cerveceria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cerveceria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cerveceria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cerveceria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cerveceria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cerveceria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cerveceria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cerveceria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cerveceria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cerveceria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cerveceria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cerveceria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cerveceria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cerveceria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cerveceria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cerveceria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cerveceria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cerveceria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cerveceria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cerveceria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cerveceria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cerveceria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cerveceria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cerveceria] SET RECOVERY FULL 
GO
ALTER DATABASE [Cerveceria] SET  MULTI_USER 
GO
ALTER DATABASE [Cerveceria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cerveceria] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cerveceria', N'ON'
GO
USE [Cerveceria]
GO
/****** Object:  Table [dbo].[tb_cerveza]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_cerveza](
	[idcerveza] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [PK_tb_cerveza] PRIMARY KEY CLUSTERED 
(
	[idcerveza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Combo]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Combo](
	[idcombo] [int] NOT NULL,
	[idhamburguesa] [int] NULL,
	[idcerveza] [int] NULL,
	[precio] [float] NULL,
 CONSTRAINT [PK_tb_Combo] PRIMARY KEY CLUSTERED 
(
	[idcombo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_hamburguesa]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_hamburguesa](
	[idhamburguesa] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[detalle] [varchar](50) NULL,
	[baja] [bit] NULL,
 CONSTRAINT [PK_tb_hamburguesa] PRIMARY KEY CLUSTERED 
(
	[idhamburguesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_Combo]  WITH CHECK ADD  CONSTRAINT [FK_tb_Combo_tb_cerveza] FOREIGN KEY([idcerveza])
REFERENCES [dbo].[tb_cerveza] ([idcerveza])
GO
ALTER TABLE [dbo].[tb_Combo] CHECK CONSTRAINT [FK_tb_Combo_tb_cerveza]
GO
ALTER TABLE [dbo].[tb_Combo]  WITH CHECK ADD  CONSTRAINT [FK_tb_Combo_tb_hamburguesa] FOREIGN KEY([idhamburguesa])
REFERENCES [dbo].[tb_hamburguesa] ([idhamburguesa])
GO
ALTER TABLE [dbo].[tb_Combo] CHECK CONSTRAINT [FK_tb_Combo_tb_hamburguesa]
GO
/****** Object:  StoredProcedure [dbo].[editarCervez]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editarCervez]	
	-- Add the parameters for the stored procedure here
	 @idcerveza int, 
	 @nombre varchar(50),
	 @tipo varchar(50)
AS
BEGIN
	update tb_cerveza set
	nombre=@nombre,
	tipo=@tipo
	where idcerveza=@idcerveza

END
GO
/****** Object:  StoredProcedure [dbo].[editarCerveza]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editarCerveza]	
	-- Add the parameters for the stored procedure here
	 @idcerveza int, 
	 @nombre varchar(50),
	 @tipo varchar(50)
AS
BEGIN
	update tb_cerveza set
	nombre=@nombre,
	tipo=@tipo
	where idcerveza=@idcerveza

END
GO
/****** Object:  StoredProcedure [dbo].[editarHamburgresa]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editarHamburgresa]	
	-- Add the parameters for the stored procedure here
	 @idhamburguesa int, 
	 @nombre varchar(50),
	 @detalle varchar(50)
AS
BEGIN
	update tb_hamburguesa set
	nombre=@nombre,
	detalle=@detalle
	where idhamburguesa=@idhamburguesa

END
GO
/****** Object:  StoredProcedure [dbo].[eliminarCerveza]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarCerveza]
	-- Add the parameters for the stored procedure here
	 @idcerveza int
AS
BEGIN
		delete from tb_cerveza where @idcerveza = idcerveza
END
GO
/****** Object:  StoredProcedure [dbo].[insertarCerveza]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertarCerveza]
	-- Add the parameters for the stored procedure here
		@nombre varchar(50),
		@tipo varchar(50)
AS
BEGIN
		declare @id int
	set @id = (select isnull(max(idcerveza),0) from tb_cerveza) +1

	insert into tb_cerveza values(@id,@nombre,@tipo)
END
GO
/****** Object:  StoredProcedure [dbo].[insertarCombo]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertarCombo]
	-- Add the parameters for the stored procedure here
		@idhamburguesa int,
		@idcerveza int,
		@precio float
		
AS
BEGIN
		declare @id int
	set @id = (select isnull(max(idcombo),0) from tb_Combo) +1

	insert into tb_Combo values(@id,@idhamburguesa,@idcerveza,@precio)
END
GO
/****** Object:  StoredProcedure [dbo].[insertarHamburguesa]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertarHamburguesa]
	-- Add the parameters for the stored procedure here
		@nombre varchar(50),
		@detalle varchar(50),
		@baja bit
AS
BEGIN
		declare @id int
	set @id = (select isnull(max(idhamburguesa),0) from tb_hamburguesa) +1

	insert into tb_hamburguesa values(@id,@nombre,@detalle,@baja)
END
GO
/****** Object:  StoredProcedure [dbo].[listarCerveza]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listarCerveza]
	-- Add the parameters for the stored procedure here
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tb_cerveza
END
GO
/****** Object:  StoredProcedure [dbo].[listarCombo]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listarCombo]
	-- Add the parameters for the stored procedure here
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tb_Combo
END
GO
/****** Object:  StoredProcedure [dbo].[listarHamburguesa]    Script Date: 7/11/2019 18:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listarHamburguesa]
	-- Add the parameters for the stored procedure here
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tb_hamburguesa
END
GO
USE [master]
GO
ALTER DATABASE [Cerveceria] SET  READ_WRITE 
GO
