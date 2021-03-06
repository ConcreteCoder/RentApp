USE [master]
GO
/****** Object:  Database [DB_Bondora]    Script Date: 5/5/2019 3:45:20 PM ******/
CREATE DATABASE [DB_Bondora] ON  PRIMARY 
( NAME = N'DB_Bondora', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB_Bondora.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Bondora_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB_Bondora_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_Bondora] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Bondora].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Bondora] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Bondora] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Bondora] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Bondora] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Bondora] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Bondora] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Bondora] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Bondora] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Bondora] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Bondora] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Bondora] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Bondora] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Bondora] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Bondora] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Bondora] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Bondora] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Bondora] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Bondora] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Bondora] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Bondora] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Bondora] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DB_Bondora] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Bondora] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Bondora] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Bondora] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Bondora] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Bondora', N'ON'
GO
USE [DB_Bondora]
GO
/****** Object:  Table [dbo].[Bondora_Cart]    Script Date: 5/5/2019 3:45:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bondora_Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Inventory_id] [int] NULL,
	[Days] [int] NULL,
	[Status] [int] NULL,
	[Token] [nvarchar](300) NULL,
 CONSTRAINT [PK_Bondora_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bondora_Customer]    Script Date: 5/5/2019 3:45:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bondora_Customer](
	[Customer_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bondora_Customers] PRIMARY KEY CLUSTERED 
(
	[Customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bondora_Inventory]    Script Date: 5/5/2019 3:45:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bondora_Inventory](
	[Inventory_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type_id] [int] NULL,
 CONSTRAINT [PK_Bondora_Inventory] PRIMARY KEY CLUSTERED 
(
	[Inventory_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bondora_Inventory_Types]    Script Date: 5/5/2019 3:45:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bondora_Inventory_Types](
	[Type_id] [int] IDENTITY(1,1) NOT NULL,
	[Type_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bondora_Inventory_Types] PRIMARY KEY CLUSTERED 
(
	[Type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bondora_Order]    Script Date: 5/5/2019 3:45:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bondora_Order](
	[Order_id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](300) NULL,
	[Date_order] [datetime] NULL,
	[Customer_id] [int] NULL,
 CONSTRAINT [PK_Bondora_Order] PRIMARY KEY CLUSTERED 
(
	[Order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bondora_Inventory] ON 

INSERT [dbo].[Bondora_Inventory] ([Inventory_id], [Name], [Type_id]) VALUES (1, N'Caterpillar bulldozer', 1)
INSERT [dbo].[Bondora_Inventory] ([Inventory_id], [Name], [Type_id]) VALUES (2, N'KamAZ truck', 2)
INSERT [dbo].[Bondora_Inventory] ([Inventory_id], [Name], [Type_id]) VALUES (3, N'Komatsu crane', 1)
INSERT [dbo].[Bondora_Inventory] ([Inventory_id], [Name], [Type_id]) VALUES (4, N'Volvo steamroller', 2)
INSERT [dbo].[Bondora_Inventory] ([Inventory_id], [Name], [Type_id]) VALUES (5, N'Bosch jackhammer', 3)
SET IDENTITY_INSERT [dbo].[Bondora_Inventory] OFF
SET IDENTITY_INSERT [dbo].[Bondora_Inventory_Types] ON 

INSERT [dbo].[Bondora_Inventory_Types] ([Type_id], [Type_name]) VALUES (1, N'Heavy')
INSERT [dbo].[Bondora_Inventory_Types] ([Type_id], [Type_name]) VALUES (2, N'Regular')
INSERT [dbo].[Bondora_Inventory_Types] ([Type_id], [Type_name]) VALUES (3, N'Specialized')
SET IDENTITY_INSERT [dbo].[Bondora_Inventory_Types] OFF
USE [master]
GO
ALTER DATABASE [DB_Bondora] SET  READ_WRITE 
GO
