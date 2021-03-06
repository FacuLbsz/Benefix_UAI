USE [master]
GO
/****** Object:  Database [Benefix]    Script Date: 26/11/2018 7:46:35 ******/
CREATE DATABASE [Benefix]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Benefix3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Benefix3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Benefix3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Benefix3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[beneficio]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[beneficio](
	[idBeneficio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](256) NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[puntaje] [nvarchar](256) NOT NULL,
	[habilitado] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_beneficio_idBeneficio] PRIMARY KEY CLUSTERED 
(
	[idBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 26/11/2018 7:46:35 ******/
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
	[Usuario_idUsuario] [int] NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_bitacora_idBitacora] PRIMARY KEY CLUSTERED 
(
	[idBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[digitoverificadorvertical]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[equipo]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipo](
	[idEquipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NULL,
	[coordinador] [int] NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_equipo_idEquipo] PRIMARY KEY CLUSTERED 
(
	[idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipoempleado]    Script Date: 26/11/2018 7:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipoempleado](
	[idEquipoEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[periodoFin] [int] NULL,
	[periodoInicio] [int] NOT NULL,
	[Equipo_idEquipo] [int] NOT NULL,
	[Usuario_idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_equipoempleado_idEquipoEmpleado] PRIMARY KEY CLUSTERED 
(
	[idEquipoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipogrupo]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[equipoobjetivo]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[evaluacion]    Script Date: 26/11/2018 7:46:35 ******/
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
	[Usuario_idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_evaluacion_idEvaluacion] PRIMARY KEY CLUSTERED 
(
	[idEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[familia]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[familiapatente]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[familiausuario]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[grupo]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[grupobeneficio]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[idioma]    Script Date: 26/11/2018 7:46:35 ******/
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
/****** Object:  Table [dbo].[objetivo]    Script Date: 26/11/2018 7:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objetivo](
	[idObjetivo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](256) NOT NULL,
	[puntaje] [nvarchar](256) NOT NULL,
	[descripcion] [nvarchar](45) NULL,
	[habilitado] [int] NOT NULL,
 CONSTRAINT [PK_objetivo_idObjetivo] PRIMARY KEY CLUSTERED 
(
	[idObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patente]    Script Date: 26/11/2018 7:46:36 ******/
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
/****** Object:  Table [dbo].[patenteusuario]    Script Date: 26/11/2018 7:46:36 ******/
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
/****** Object:  Table [dbo].[usuario]    Script Date: 26/11/2018 7:46:36 ******/
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
	[cantidadDeIntentos] [int] NOT NULL,
	[digitoVerificadorH] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_usuario_idUsuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [fk_Bitacora_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_Bitacora_Usuario1_idx] ON [dbo].[bitacora]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Equipo_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_Equipo_Usuario1_idx] ON [dbo].[equipo]
(
	[coordinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoGrupo_Equipo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoGrupo_Equipo1_idx] ON [dbo].[equipogrupo]
(
	[Equipo_idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoGrupo_Grupo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoGrupo_Grupo1_idx] ON [dbo].[equipogrupo]
(
	[Grupo_idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoObjetivo_Equipo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoObjetivo_Equipo1_idx] ON [dbo].[equipoobjetivo]
(
	[Equipo_idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_EquipoObjetivo_Objetivo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_EquipoObjetivo_Objetivo1_idx] ON [dbo].[equipoobjetivo]
(
	[Objetivo_idObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Evaluacion_EquipoObjetivo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_Evaluacion_EquipoObjetivo1_idx] ON [dbo].[evaluacion]
(
	[EquipoObjetivo_idEquipoObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaPatente_Familia1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaPatente_Familia1_idx] ON [dbo].[familiapatente]
(
	[Familia_idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaPatente_Patente_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaPatente_Patente_idx] ON [dbo].[familiapatente]
(
	[Patente_idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaUsuario_Familia1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaUsuario_Familia1_idx] ON [dbo].[familiausuario]
(
	[Familia_idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_FamiliaUsuario_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_FamiliaUsuario_Usuario1_idx] ON [dbo].[familiausuario]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_GrupoBeneficio_Beneficio1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_GrupoBeneficio_Beneficio1_idx] ON [dbo].[grupobeneficio]
(
	[Beneficio_idBeneficio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_GrupoBeneficio_Grupo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_GrupoBeneficio_Grupo1_idx] ON [dbo].[grupobeneficio]
(
	[Grupo_idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PatenteUsuario_Patente1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_PatenteUsuario_Patente1_idx] ON [dbo].[patenteusuario]
(
	[Patente_idPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PatenteUsuario_Usuario1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_PatenteUsuario_Usuario1_idx] ON [dbo].[patenteusuario]
(
	[Usuario_idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Usuario_Equipo1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_Usuario_Equipo1_idx] ON [dbo].[usuario]
(
	[Equipo_idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_Usuario_Idioma1_idx]    Script Date: 26/11/2018 7:46:36 ******/
CREATE NONCLUSTERED INDEX [fk_Usuario_Idioma1_idx] ON [dbo].[usuario]
(
	[Idioma_idIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[beneficio] ADD  DEFAULT (NULL) FOR [descripcion]
GO
ALTER TABLE [dbo].[equipo] ADD  CONSTRAINT [DF__equipo__nombre__5812160E]  DEFAULT (NULL) FOR [nombre]
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
ALTER TABLE [dbo].[usuario] ADD  DEFAULT ((0)) FOR [cantidadDeIntentos]
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
ALTER TABLE [dbo].[equipoempleado]  WITH CHECK ADD  CONSTRAINT [FK_equipoempleado_equipo] FOREIGN KEY([Equipo_idEquipo])
REFERENCES [dbo].[equipo] ([idEquipo])
GO
ALTER TABLE [dbo].[equipoempleado] CHECK CONSTRAINT [FK_equipoempleado_equipo]
GO
ALTER TABLE [dbo].[equipoempleado]  WITH CHECK ADD  CONSTRAINT [FK_equipoempleado_usuario] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[equipoempleado] CHECK CONSTRAINT [FK_equipoempleado_usuario]
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
ALTER TABLE [dbo].[evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_evaluacion_usuario] FOREIGN KEY([Usuario_idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[evaluacion] CHECK CONSTRAINT [FK_evaluacion_usuario]
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
