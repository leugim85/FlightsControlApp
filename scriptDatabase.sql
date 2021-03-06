USE [master]
GO
/****** Object:  Database [DbFligths]    Script Date: 23/04/2022 12:44:19 a. m. ******/
CREATE DATABASE [DbFligths]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbFligths', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DbFligths.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbFligths_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DbFligths_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DbFligths] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbFligths].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbFligths] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbFligths] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbFligths] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbFligths] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbFligths] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbFligths] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbFligths] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbFligths] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbFligths] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbFligths] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbFligths] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbFligths] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbFligths] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbFligths] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbFligths] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbFligths] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbFligths] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbFligths] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbFligths] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbFligths] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbFligths] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbFligths] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbFligths] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbFligths] SET  MULTI_USER 
GO
ALTER DATABASE [DbFligths] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbFligths] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbFligths] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbFligths] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbFligths] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbFligths] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DbFligths] SET QUERY_STORE = OFF
GO
USE [DbFligths]
GO
/****** Object:  Table [dbo].[AirLines]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirLineName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AirLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fligths]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fligths](
	[FligthId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[DepartureTime] [datetime] NULL,
	[ArrivalTime] [datetime] NULL,
	[OriginCityId] [int] NOT NULL,
	[DestinationCityId] [int] NOT NULL,
	[AirlineId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Fligths] PRIMARY KEY CLUSTERED 
(
	[FligthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FligthStatus]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FligthStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FligthStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwfligths]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwfligths]
as
SELECT f.FligthId, f.Date, f.DepartureTime, f.ArrivalTime, a.AirLineName, dc.City as Destination, oc.City as Origin, fs.Status
  FROM [DbFligths].[dbo].[Fligths] as f
  inner join [dbo].[AirLines]  as a on a.Id = f.AirlineId
  inner join [dbo].[Cities] as dc on dc.Id = f.DestinationCityId
  inner join [dbo].[Cities] as oc on oc.Id = f.OriginCityId
  inner join [dbo].[FligthStatus] as fs on fs.Id= f.StatusId
GO
/****** Object:  View [dbo].[vwFlight]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwFlight] AS
SELECT f.FligthId, f.Date, f.DepartureTime, f.ArrivalTime, a.AirLineName, dc.City AS Destination, oc.City AS Origin, fs.Status
FROM            dbo.Fligths AS f INNER JOIN
                         dbo.AirLines AS a ON a.Id = f.AirlineId INNER JOIN
                         dbo.Cities AS dc ON dc.Id = f.DestinationCityId INNER JOIN
                         dbo.Cities AS oc ON oc.Id = f.OriginCityId INNER JOIN
                         dbo.FligthStatus AS fs ON fs.Id = f.StatusId
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/04/2022 12:44:19 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fligths]  WITH CHECK ADD  CONSTRAINT [FK_Airline] FOREIGN KEY([AirlineId])
REFERENCES [dbo].[AirLines] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fligths] CHECK CONSTRAINT [FK_Airline]
GO
ALTER TABLE [dbo].[Fligths]  WITH CHECK ADD  CONSTRAINT [FK_City_Origin] FOREIGN KEY([OriginCityId])
REFERENCES [dbo].[Cities] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fligths] CHECK CONSTRAINT [FK_City_Origin]
GO
ALTER TABLE [dbo].[Fligths]  WITH CHECK ADD  CONSTRAINT [FK_Destination] FOREIGN KEY([DestinationCityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Fligths] CHECK CONSTRAINT [FK_Destination]
GO
ALTER TABLE [dbo].[Fligths]  WITH CHECK ADD  CONSTRAINT [FK_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[FligthStatus] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fligths] CHECK CONSTRAINT [FK_Status]
GO
USE [master]
GO
ALTER DATABASE [DbFligths] SET  READ_WRITE 
GO
