USE [master]
GO
/****** Object:  Database [FIAS]    Script Date: 20.07.2015 22:37:31 ******/
CREATE DATABASE [FIAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FIAS', FILENAME = N'D:\FIAS_BD\FIAS.mdf' , SIZE = 1669KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FIAS_log', FILENAME = N'D:\FIAS_BD\FIAS_log.ldf' , SIZE = 2681KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FIAS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FIAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FIAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FIAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FIAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FIAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FIAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [FIAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FIAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FIAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FIAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FIAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FIAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FIAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FIAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FIAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FIAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FIAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FIAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FIAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FIAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FIAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FIAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FIAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FIAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FIAS] SET  MULTI_USER 
GO
ALTER DATABASE [FIAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FIAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FIAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FIAS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FIAS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FIAS', N'ON'
GO


USE [FIAS]
GO

/****** Object:  Table [dbo].[House]    Script Date: 20.07.2015 22:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	
	[HOUSENUM] [nvarchar](50) NULL,
	[BUILDNUM] [nvarchar](50) NULL,
	[STRUCNUM] [nvarchar](50) NULL,
	[STRSTATUS] [bit] NULL,
	[HOUSEID] [nvarchar](50) NOT NULL,
	[HOUSEGUID] [nvarchar](50) NOT NULL,
	[AOGUID] [nvarchar](50) NOT NULL,
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[Object]    Script Date: 20.07.2015 22:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[AOGUID] [nvarchar](50) NOT NULL,
	[FORMALNAME] [nvarchar](120) NOT NULL,
	[REGIONCODE] [nvarchar](50) NOT NULL,
	[CITYCODE] [nvarchar](50) NOT NULL,
	[STREETCODE] [nvarchar](50) NULL,
	[OFFNAME] [nvarchar](120) NULL,
	[SHORTNAME] [nvarchar](50) NOT NULL,
	[AOLEVEL] [bit] NOT NULL,
	[PARENTGUID] [nvarchar](50) NULL,
	[AOID] [nvarchar](50) NOT NULL,
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[House]  WITH NOCHECK ADD  CONSTRAINT [CK_House_BUILDNUM] CHECK  ((len([BUILDNUM])>=(0)))
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [CK_House_BUILDNUM]
GO
ALTER TABLE [dbo].[House]  WITH NOCHECK ADD  CONSTRAINT [CK_House_HOUSENUM] CHECK  ((len([HOUSENUM])>=(1)))
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [CK_House_HOUSENUM]
GO
ALTER TABLE [dbo].[House]  WITH NOCHECK ADD  CONSTRAINT [CK_House_STRUCNUM] CHECK  ((len([STRUCNUM])>=(0)))
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [CK_House_STRUCNUM]
GO
ALTER TABLE [dbo].[Object]  WITH NOCHECK ADD  CONSTRAINT [CK_Object_FORMALNAME] CHECK  ((len([FORMALNAME])>=(1)))
GO
ALTER TABLE [dbo].[Object] CHECK CONSTRAINT [CK_Object_FORMALNAME]
GO
ALTER TABLE [dbo].[Object]  WITH NOCHECK ADD  CONSTRAINT [CK_Object_OFFNAME] CHECK  ((len([OFFNAME])>=(1)))
GO
ALTER TABLE [dbo].[Object] CHECK CONSTRAINT [CK_Object_OFFNAME]
GO
ALTER TABLE [dbo].[Object]  WITH NOCHECK ADD  CONSTRAINT [CK_Object_SHORTNAME] CHECK  ((len([SHORTNAME])>=(1)))
GO
ALTER TABLE [dbo].[Object] CHECK CONSTRAINT [CK_Object_SHORTNAME]
GO