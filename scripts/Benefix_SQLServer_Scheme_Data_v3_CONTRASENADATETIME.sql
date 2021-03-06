USE [master]
GO
/****** Object:  Database [Benefix]    Script Date: 22/10/2018 2:37:35 ******/
CREATE DATABASE [Benefix]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Benefix', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Benefix.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Benefix_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Benefix_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Benefix] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Benefix].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Benefix] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Benefix] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Benefix] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Benefix] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Benefix] SET ARITHABORT OFF 
GO
ALTER DATABASE [Benefix] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Benefix] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Benefix] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Benefix] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Benefix] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Benefix] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Benefix] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Benefix] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Benefix] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Benefix] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Benefix] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Benefix] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Benefix] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Benefix] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Benefix] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Benefix] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Benefix] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Benefix] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Benefix] SET  MULTI_USER 
GO
ALTER DATABASE [Benefix] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Benefix] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Benefix] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Benefix] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Benefix] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Benefix] SET QUERY_STORE = OFF
GO
USE [Benefix]
GO
/****** Object:  Table [dbo].[beneficio]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[beneficio](
	[idBeneficio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](256) NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[puntaje] [int] NOT NULL,
	[habilitado] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_beneficio_idBeneficio] PRIMARY KEY CLUSTERED 
(
	[idBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[idBitacora] [int] IDENTITY(1,1) NOT NULL,
	[criticidad] [int] NOT NULL,
	[descripcion] [nvarchar](256) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[funcionalidad] [nvarchar](45) NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_bitacora_idBitacora] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[digitoverificadorvertical]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[digitoverificadorvertical](
	[idDigitoVerificadorVertical] [int] IDENTITY(1,1) NOT NULL,
	[tabla] [nvarchar](45) NOT NULL,
	[digitoVerificador] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_digitoverificadorvertical_idDigitoVerificadorVertical] PRIMARY KEY CLUSTERED 
(
	[idDigitoVerificadorVertical] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipo]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipo](
	[idEquipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[coordinador] [int] NOT NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_equipo_idEquipo] PRIMARY KEY CLUSTERED 
(
	[idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipogrupo]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipogrupo](
	[idEquipoGrupo] [int] IDENTITY(1,1) NOT NULL,
	[periodoFin] [int] NULL,
	[periodoInicio] [int] NOT NULL,
	[Grupo_idGrupo] [int] NOT NULL,
	[Equipo_idEquipo] [int] NOT NULL,
 CONSTRAINT [PK_equipogrupo_idEquipoGrupo] PRIMARY KEY CLUSTERED 
(
	[idEquipoGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipoobjetivo]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipoobjetivo](
	[idEquipoObjetivo] [int] IDENTITY(1,1) NOT NULL,
	[periodoFin] [int] NULL,
	[periodoInicio] [int] NOT NULL,
	[Equipo_idEquipo] [int] NOT NULL,
	[Objetivo_idObjetivo] [int] NOT NULL,
 CONSTRAINT [PK_equipoobjetivo_idEquipoObjetivo] PRIMARY KEY CLUSTERED 
(
	[idEquipoObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[evaluacion]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evaluacion](
	[idEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[puntaje] [int] NOT NULL,
	[periodo] [int] NOT NULL,
	[EquipoObjetivo_idEquipoObjetivo] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_evaluacion_idEvaluacion] PRIMARY KEY CLUSTERED 
(
	[idEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familia](
	[idFamilia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_familia_idFamilia] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familiapatente]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familiapatente](
	[idFamiliaPatente] [int] IDENTITY(1,1) NOT NULL,
	[Patente_idPatente] [int] NOT NULL,
	[Familia_idFamilia] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_familiapatente_idFamiliaPatente] PRIMARY KEY CLUSTERED 
(
	[idFamiliaPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familiausuario]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[familiausuario](
	[idFamiliaUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Familia_idFamilia] [int] NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_familiausuario_idFamiliaUsuario] PRIMARY KEY CLUSTERED 
(
	[idFamiliaUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo](
	[idGrupo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_grupo_idGrupo] PRIMARY KEY CLUSTERED 
(
	[idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupobeneficio]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupobeneficio](
	[idGrupoBeneficio] [int] IDENTITY(1,1) NOT NULL,
	[periodoFin] [int] NULL,
	[periodoInicio] [int] NOT NULL,
	[Grupo_idGrupo] [int] NOT NULL,
	[Beneficio_idBeneficio] [int] NOT NULL,
 CONSTRAINT [PK_grupobeneficio_idGrupoBeneficio] PRIMARY KEY CLUSTERED 
(
	[idGrupoBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idioma]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma](
	[idIdioma] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_idioma_idIdioma] PRIMARY KEY CLUSTERED 
(
	[idIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objetivo]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objetivo](
	[idObjetivo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[puntaje] [int] NOT NULL,
	[descripcion] [nvarchar](45) NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_objetivo_idObjetivo] PRIMARY KEY CLUSTERED 
(
	[idObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patente]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patente](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_patente_idPatente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patenteusuario]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patenteusuario](
	[idPatente] [int] IDENTITY(1,1) NOT NULL,
	[esPermisiva] [smallint] NOT NULL,
	[Patente_idPatente] [int] NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_patenteusuario_idPatente] PRIMARY KEY CLUSTERED 
(
	[idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 22/10/2018 2:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [nvarchar](256) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
	[apellido] [nvarchar](45) NOT NULL,
	[email] [nvarchar](45) NOT NULL,
	[contrasena] [nvarchar](256) NOT NULL,
	[Idioma_idIdioma] [int] NOT NULL,
	[Equipo_idEquipo] [int] NULL,
	[habilitado] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_usuario_idUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bitacora] ON 

INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (4, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'LOGdIN', 1, N'607E66EBF1EBD4564857DCF878D2C572')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (5, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'LOGIN', 1, N'607E66EBF1EBD4564857DCF878D2C572')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (6, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'LOGIN', 1, N'607E66EBF1EBD4564857DCF878D2C572')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (7, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T00:12:32.000' AS DateTime), N'LOGIN', 1, N'84CAEF9BA7177F2B1F94A555B3F5F966')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (8, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T02:21:40.000' AS DateTime), N'LOGIN', 1, N'412BFD7C2F3F61FE7CA439334CFFDAF4')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (9, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T02:22:14.000' AS DateTime), N'LOGIN', 1, N'9D20174F388628EDC0CD0C31E61030E4')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (10, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T02:25:37.000' AS DateTime), N'LOGIN', 1, N'FF2C1B4B803806E80736C48501E00007')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (11, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T02:33:48.000' AS DateTime), N'LOGIN', 1, N'E3A1B7EC6EE89A03106C34EE7B178278')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (12, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T02:46:47.000' AS DateTime), N'LOGIN', 1, N'2447CD7E3F90FAD4F3DB5FDE7D56F173')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (13, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T02:53:08.000' AS DateTime), N'LOGIN', 1, N'A125F5061E8DE52916DDBB00062CCFC5')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (14, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:01:21.000' AS DateTime), N'LOGIN', 1, N'B4635BDA55E3C2E43B262FEFC226ECC3')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (15, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:02:43.000' AS DateTime), N'LOGIN', 1, N'F80CFB24A32A1EC76C611B852B0B7758')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (16, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:05:40.000' AS DateTime), N'LOGIN', 1, N'6805B05A23871004C685427300CD511A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (17, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:11:14.000' AS DateTime), N'LOGIN', 1, N'5A5E2AEF1D6D16E55673BF38E5DF111B')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (18, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:20:08.000' AS DateTime), N'LOGIN', 1, N'4837F3E372650A77DE7473405C6F179B')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (19, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:38:26.000' AS DateTime), N'LOGIN', 1, N'0BD4DDABAFD95019DA134AEF82837AFA')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (20, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:46:11.000' AS DateTime), N'LOGIN', 1, N'344A32D4DB612779ED0BC892433D8211')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (21, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:47:07.000' AS DateTime), N'LOGIN', 1, N'0F87966CB97F29B3DFB5C736A654D4C6')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (22, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:48:15.000' AS DateTime), N'LOGIN', 1, N'3EB2A01FA650C510CC79504F480D8122')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (23, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:51:44.000' AS DateTime), N'LOGIN', 1, N'07FE89F42BAE9598ECF5EE3BE59F0191')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (24, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:53:48.000' AS DateTime), N'LOGIN', 1, N'6CCD0D84E8C2989C7BB4DEE9C8F572C0')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (25, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:56:16.000' AS DateTime), N'LOGIN', 1, N'7A826F478D4D7F2770B7DA71B43FA117')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (26, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T12:57:31.000' AS DateTime), N'LOGIN', 1, N'0CF86017790D7F9CF8367A32A60018CD')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (27, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:01:35.000' AS DateTime), N'LOGIN', 1, N'E58F68990F4F4CD7129016D347F8D6C8')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (28, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:04:08.000' AS DateTime), N'LOGIN', 1, N'3E87572CD5F9CBAE51E2F3F585F50B0F')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (29, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:05:51.000' AS DateTime), N'LOGIN', 1, N'907E3586FCDB9972F5FD80C03B177D0B')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (30, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:11:10.000' AS DateTime), N'LOGIN', 1, N'C6AA9770BD0B55417666DCE54046D35A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (31, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:13:11.000' AS DateTime), N'LOGIN', 1, N'1802EF56E49D65575AA58B8253E659DE')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (32, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:16:01.000' AS DateTime), N'LOGIN', 1, N'F08A37F5694835C4B8BD5A7B8D63B770')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (33, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:18:48.000' AS DateTime), N'LOGIN', 1, N'CDAD98E347B4ADA395C5BD00FB407219')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (34, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:21:20.000' AS DateTime), N'LOGIN', 1, N'2AE6660517F800CFADEAAF6A4AE3E431')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (35, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-21T13:23:26.000' AS DateTime), N'LOGIN', 1, N'2AB72D66A92FB8DDD4035D503AE805E7')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (36, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:13:56.000' AS DateTime), N'LOGIN', 1, N'CBA134CDC1454F86A3704BE35804A21A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (37, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:15:58.000' AS DateTime), N'LOGIN', 1, N'7480A3852C0F295A2BE47F1D21B57FCE')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (38, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:18:38.000' AS DateTime), N'LOGIN', 1, N'10CB7230D1A77CBB0F14CE6FA3B22F01')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (39, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:20:17.000' AS DateTime), N'LOGIN', 1, N'B43192E9DB06AF3C38D2B91693245CE4')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (40, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:24:24.000' AS DateTime), N'LOGIN', 1, N'2C408686D13A9DF75F1D8B7410A30BB3')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (41, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:27:26.000' AS DateTime), N'LOGIN', 1, N'A113FD58FB7B1145B0BA326F03ECEE65')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (42, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:34:09.000' AS DateTime), N'LOGIN', 1, N'B3F675ACB44FDC0E395BD02973FBC7CC')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (43, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:39:23.000' AS DateTime), N'LOGIN', 1, N'58A0AD4D206092F0D3050E302F4B9382')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (44, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:55:19.000' AS DateTime), N'LOGIN', 1, N'74B57AC596A448B01609928D25D72C8E')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (45, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T00:58:57.000' AS DateTime), N'LOGIN', 1, N'6B7C5BA1DC1A3EECB5DAFC4E309F6B77')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (46, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:03:32.000' AS DateTime), N'LOGIN', 1, N'164628D9D5A5FCB3ADA798D8F4695091')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (47, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:05:27.000' AS DateTime), N'LOGIN', 1, N'27511F76E08F0845C43AD0269AE1A58C')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (48, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:10:00.000' AS DateTime), N'LOGIN', 1, N'93EC4F31302FF1E1C0DDB66794FF45FD')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (49, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:12:50.000' AS DateTime), N'LOGIN', 1, N'10F75CE2EF937938CA3CFABC93DE7638')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (50, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:18:43.000' AS DateTime), N'LOGIN', 1, N'AEA44E47739549DEB6CB56790DAE9DCF')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (51, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:24:40.000' AS DateTime), N'LOGIN', 1, N'814CC08E3DCAFE5A2694E6BF593E8B87')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (52, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:31:01.000' AS DateTime), N'LOGIN', 1, N'08E2FF8EE7A2BA1FBEDB128E313D764A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (53, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:32:59.000' AS DateTime), N'LOGIN', 1, N'37663C14B435D63042440BCD4F902771')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (54, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:33:40.000' AS DateTime), N'LOGIN', 1, N'713378DB42F3A5498F6F86720B9FF226')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (55, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:41:07.000' AS DateTime), N'LOGIN', 1, N'E1A87D319A9FDFF3D5ADD1497455F704')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (56, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:44:14.000' AS DateTime), N'LOGIN', 1, N'6168033E0BBD4D93536C35AF0EE8B61B')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (57, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:46:39.000' AS DateTime), N'LOGIN', 1, N'C76978461755EE94BB0B08EFC5ED145D')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (58, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:51:18.000' AS DateTime), N'LOGIN', 1, N'E84140DADDADF09C0F996114265A00D3')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (59, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:53:13.000' AS DateTime), N'LOGIN', 1, N'D1D6356B7B5221FA55E41E8F750A3A5E')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (60, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:56:35.000' AS DateTime), N'LOGIN', 1, N'CDF2C7DD523302A94A322777B459C0C6')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (61, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T01:58:45.000' AS DateTime), N'LOGIN', 1, N'AB3187C283EFB229F78387141DD1A5CC')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (62, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T02:01:56.000' AS DateTime), N'LOGIN', 1, N'E62FC15DD276915983FE7102B0373DD4')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (63, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T02:27:33.000' AS DateTime), N'LOGIN', 1, N'4E8AB48B13BAC0808C1F7DC28A5F4914')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (64, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T02:28:43.000' AS DateTime), N'LOGIN', 1, N'55B354A9CBA331C112A39D577314C70A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (65, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-10-22T02:35:09.000' AS DateTime), N'LOGIN', 1, N'801049632B97F4F72DCE17943EE24269')
SET IDENTITY_INSERT [dbo].[bitacora] OFF
SET IDENTITY_INSERT [dbo].[digitoverificadorvertical] ON 

INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (1, N'BITACORA', N'A2C24A1ADF26D5B35C3CA95FD0C718CA')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (2, N'USUARIO', N'372A01A64F6A8BEFA4130EA45C6B5710')
SET IDENTITY_INSERT [dbo].[digitoverificadorvertical] OFF
SET IDENTITY_INSERT [dbo].[idioma] ON 

INSERT [dbo].[idioma] ([idIdioma], [nombre]) VALUES (1, N'Español')
INSERT [dbo].[idioma] ([idIdioma], [nombre]) VALUES (2, N'Ingles')
SET IDENTITY_INSERT [dbo].[idioma] OFF
SET IDENTITY_INSERT [dbo].[patente] ON 

INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (1, N'A')
SET IDENTITY_INSERT [dbo].[patente] OFF
SET IDENTITY_INSERT [dbo].[patenteusuario] ON 

INSERT [dbo].[patenteusuario] ([idPatente], [esPermisiva], [Patente_idPatente], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (1, 0, 1, 1, N'h')
SET IDENTITY_INSERT [dbo].[patenteusuario] OFF
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [Idioma_idIdioma], [Equipo_idEquipo], [habilitado], [digitoVerificadorH]) VALUES (1, N'NW6gz2WOsE9Es6uGIgh+gg==', N'facundoB', N'vazquez', N'facundo@gmail.com', N'A7D2CBD3D86F3D3C3215E728B247DAEF', 2, NULL, 1, N'3FB3205D286B99017F6A725528A9101E')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [Idioma_idIdioma], [Equipo_idEquipo], [habilitado], [digitoVerificadorH]) VALUES (2, N'NW6gz2WOsE9Es6uGIgh+gg==', N'carlos', N'sanchez', N'carls@mail.com', N'E7E906A5B23EFE64AFD456CB5E625B14', 1, NULL, 1, N'A93C9F3365A5FF17DC08562D71903635')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [Idioma_idIdioma], [Equipo_idEquipo], [habilitado], [digitoVerificadorH]) VALUES (3, N'MMP7ALnD+9ZjnvJsuJ7k9w==', N'facundo', N'vazquez', N'f@mail.com', N'3F5D4E86F68B8D8A388971469D2D1287', 1, NULL, 1, N'6677843EA75DC9120DA0100BC966057D')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [Idioma_idIdioma], [Equipo_idEquipo], [habilitado], [digitoVerificadorH]) VALUES (4, N'UqQihHueAIrPdte7dbUqJyMzT67vFYKvb3QsNM9bHE0=', N'mauricio', N'fernandez', N'mauricio23@mail.com', N'3FB865A7DD8957E52CA6ECCAA02298E5', 1, NULL, 0, N'3B7B628F20D4A183CE674DB92F8B094C')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [Idioma_idIdioma], [Equipo_idEquipo], [habilitado], [digitoVerificadorH]) VALUES (5, N'XzsUXrRDw7cn7Js/zCkn9TDMLoI0BzY9RGWqFARk6oo=', N'facundo', N'vazquez', N'fo@mail.com', N'4785EAB16C5FC229366E14E4D8059E1C', 1, NULL, 1, N'74E67BF310DC3C168963A9A27AE2896C')
SET IDENTITY_INSERT [dbo].[usuario] OFF
/****** Object:  Index [fk_Bitacora_Usuario1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_Bitacora_Usuario1_idx] ON [dbo].[bitacora]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Equipo_Usuario1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_Equipo_Usuario1_idx] ON [dbo].[equipo]
(
	[coordinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoGrupo_Equipo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoGrupo_Equipo1_idx] ON [dbo].[equipogrupo]
(
	[Equipo_idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoGrupo_Grupo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoGrupo_Grupo1_idx] ON [dbo].[equipogrupo]
(
	[Grupo_idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoObjetivo_Equipo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoObjetivo_Equipo1_idx] ON [dbo].[equipoobjetivo]
(
	[Equipo_idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoObjetivo_Objetivo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoObjetivo_Objetivo1_idx] ON [dbo].[equipoobjetivo]
(
	[Objetivo_idObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Evaluacion_EquipoObjetivo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_Evaluacion_EquipoObjetivo1_idx] ON [dbo].[evaluacion]
(
	[EquipoObjetivo_idEquipoObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaPatente_Familia1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaPatente_Familia1_idx] ON [dbo].[familiapatente]
(
	[Familia_idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaPatente_Patente_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaPatente_Patente_idx] ON [dbo].[familiapatente]
(
	[Patente_idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaUsuario_Familia1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaUsuario_Familia1_idx] ON [dbo].[familiausuario]
(
	[Familia_idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaUsuario_Usuario1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaUsuario_Usuario1_idx] ON [dbo].[familiausuario]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_GrupoBeneficio_Beneficio1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_GrupoBeneficio_Beneficio1_idx] ON [dbo].[grupobeneficio]
(
	[Beneficio_idBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_GrupoBeneficio_Grupo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_GrupoBeneficio_Grupo1_idx] ON [dbo].[grupobeneficio]
(
	[Grupo_idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PatenteUsuario_Patente1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_PatenteUsuario_Patente1_idx] ON [dbo].[patenteusuario]
(
	[Patente_idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PatenteUsuario_Usuario1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_PatenteUsuario_Usuario1_idx] ON [dbo].[patenteusuario]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Usuario_Equipo1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_Usuario_Equipo1_idx] ON [dbo].[usuario]
(
	[Equipo_idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Usuario_Idioma1_idx]    Script Date: 22/10/2018 2:37:37 ******/
CREATE NONCLUSTERED INDEX [fk_Usuario_Idioma1_idx] ON [dbo].[usuario]
(
	[Idioma_idIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[beneficio] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[equipo] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[equipogrupo] ADD  DEFAULT (NULL) FOR [periodoFin]
GO
ALTER TABLE [dbo].[equipoobjetivo] ADD  DEFAULT (NULL) FOR [periodoFin]
GO
ALTER TABLE [dbo].[grupo] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[grupobeneficio] ADD  DEFAULT (NULL) FOR [periodoFin]
GO
ALTER TABLE [dbo].[objetivo] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT (NULL) FOR [Equipo_idEquipo]
GO
ALTER TABLE [dbo].[bitacora]  WITH CHECK ADD  CONSTRAINT [bitacora$fk_Bitacora_Usuario1] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[bitacora] CHECK CONSTRAINT [bitacora$fk_Bitacora_Usuario1]
GO
ALTER TABLE [dbo].[equipo]  WITH CHECK ADD  CONSTRAINT [equipo$fk_Equipo_Usuario1] FOREIGN KEY([coordinador])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[equipo] CHECK CONSTRAINT [equipo$fk_Equipo_Usuario1]
GO
ALTER TABLE [dbo].[equipogrupo]  WITH CHECK ADD  CONSTRAINT [equipogrupo$fk_EquipoGrupo_Equipo1] FOREIGN KEY([Equipo_idEquipo])
REFERENCES [dbo].[equipo] ([idEquipo])
GO
ALTER TABLE [dbo].[equipogrupo] CHECK CONSTRAINT [equipogrupo$fk_EquipoGrupo_Equipo1]
GO
ALTER TABLE [dbo].[equipogrupo]  WITH CHECK ADD  CONSTRAINT [equipogrupo$fk_EquipoGrupo_Grupo1] FOREIGN KEY([Grupo_idGrupo])
REFERENCES [dbo].[grupo] ([idGrupo])
GO
ALTER TABLE [dbo].[equipogrupo] CHECK CONSTRAINT [equipogrupo$fk_EquipoGrupo_Grupo1]
GO
ALTER TABLE [dbo].[equipoobjetivo]  WITH CHECK ADD  CONSTRAINT [equipoobjetivo$fk_EquipoObjetivo_Equipo1] FOREIGN KEY([Equipo_idEquipo])
REFERENCES [dbo].[equipo] ([idEquipo])
GO
ALTER TABLE [dbo].[equipoobjetivo] CHECK CONSTRAINT [equipoobjetivo$fk_EquipoObjetivo_Equipo1]
GO
ALTER TABLE [dbo].[equipoobjetivo]  WITH CHECK ADD  CONSTRAINT [equipoobjetivo$fk_EquipoObjetivo_Objetivo1] FOREIGN KEY([Objetivo_idObjetivo])
REFERENCES [dbo].[objetivo] ([idObjetivo])
GO
ALTER TABLE [dbo].[equipoobjetivo] CHECK CONSTRAINT [equipoobjetivo$fk_EquipoObjetivo_Objetivo1]
GO
ALTER TABLE [dbo].[evaluacion]  WITH CHECK ADD  CONSTRAINT [evaluacion$fk_Evaluacion_EquipoObjetivo1] FOREIGN KEY([EquipoObjetivo_idEquipoObjetivo])
REFERENCES [dbo].[equipoobjetivo] ([idEquipoObjetivo])
GO
ALTER TABLE [dbo].[evaluacion] CHECK CONSTRAINT [evaluacion$fk_Evaluacion_EquipoObjetivo1]
GO
ALTER TABLE [dbo].[familiapatente]  WITH CHECK ADD  CONSTRAINT [familiapatente$fk_FamiliaPatente_Familia1] FOREIGN KEY([Familia_idFamilia])
REFERENCES [dbo].[familia] ([idFamilia])
GO
ALTER TABLE [dbo].[familiapatente] CHECK CONSTRAINT [familiapatente$fk_FamiliaPatente_Familia1]
GO
ALTER TABLE [dbo].[familiapatente]  WITH CHECK ADD  CONSTRAINT [familiapatente$fk_FamiliaPatente_Patente] FOREIGN KEY([Patente_idPatente])
REFERENCES [dbo].[patente] ([idPatente])
GO
ALTER TABLE [dbo].[familiapatente] CHECK CONSTRAINT [familiapatente$fk_FamiliaPatente_Patente]
GO
ALTER TABLE [dbo].[familiausuario]  WITH CHECK ADD  CONSTRAINT [familiausuario$fk_FamiliaUsuario_Familia1] FOREIGN KEY([Familia_idFamilia])
REFERENCES [dbo].[familia] ([idFamilia])
GO
ALTER TABLE [dbo].[familiausuario] CHECK CONSTRAINT [familiausuario$fk_FamiliaUsuario_Familia1]
GO
ALTER TABLE [dbo].[familiausuario]  WITH CHECK ADD  CONSTRAINT [familiausuario$fk_FamiliaUsuario_Usuario1] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[familiausuario] CHECK CONSTRAINT [familiausuario$fk_FamiliaUsuario_Usuario1]
GO
ALTER TABLE [dbo].[grupobeneficio]  WITH CHECK ADD  CONSTRAINT [grupobeneficio$fk_GrupoBeneficio_Beneficio1] FOREIGN KEY([Beneficio_idBeneficio])
REFERENCES [dbo].[beneficio] ([idBeneficio])
GO
ALTER TABLE [dbo].[grupobeneficio] CHECK CONSTRAINT [grupobeneficio$fk_GrupoBeneficio_Beneficio1]
GO
ALTER TABLE [dbo].[grupobeneficio]  WITH CHECK ADD  CONSTRAINT [grupobeneficio$fk_GrupoBeneficio_Grupo1] FOREIGN KEY([Grupo_idGrupo])
REFERENCES [dbo].[grupo] ([idGrupo])
GO
ALTER TABLE [dbo].[grupobeneficio] CHECK CONSTRAINT [grupobeneficio$fk_GrupoBeneficio_Grupo1]
GO
ALTER TABLE [dbo].[patenteusuario]  WITH CHECK ADD  CONSTRAINT [patenteusuario$fk_PatenteUsuario_Patente1] FOREIGN KEY([Patente_idPatente])
REFERENCES [dbo].[patente] ([idPatente])
GO
ALTER TABLE [dbo].[patenteusuario] CHECK CONSTRAINT [patenteusuario$fk_PatenteUsuario_Patente1]
GO
ALTER TABLE [dbo].[patenteusuario]  WITH CHECK ADD  CONSTRAINT [patenteusuario$fk_PatenteUsuario_Usuario1] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[patenteusuario] CHECK CONSTRAINT [patenteusuario$fk_PatenteUsuario_Usuario1]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [usuario$fk_Usuario_Equipo1] FOREIGN KEY([Equipo_idEquipo])
REFERENCES [dbo].[equipo] ([idEquipo])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [usuario$fk_Usuario_Equipo1]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [usuario$fk_Usuario_Idioma1] FOREIGN KEY([Idioma_idIdioma])
REFERENCES [dbo].[idioma] ([idIdioma])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [usuario$fk_Usuario_Idioma1]
GO
USE [master]
GO
ALTER DATABASE [Benefix] SET  READ_WRITE 
GO
