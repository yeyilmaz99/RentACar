USE [master]
GO
/****** Object:  Database [MyDatabase]    Script Date: 19.10.2022 22:06:02 ******/
CREATE DATABASE [MyDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyDatabase', FILENAME = N'C:\Users\yunus\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MyDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyDatabase_log', FILENAME = N'C:\Users\yunus\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MyDatabase.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyDatabase] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MyDatabase] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MyDatabase] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MyDatabase] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MyDatabase] SET ARITHABORT ON 
GO
ALTER DATABASE [MyDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyDatabase] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MyDatabase] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MyDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyDatabase] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MyDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [MyDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MyDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyDatabase] SET QUERY_STORE = OFF
GO
USE [MyDatabase]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImageName] [varchar](255) NULL,
	[Image] [varbinary](max) NULL,
	[ImagePath] [varchar](255) NULL,
	[Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[CarName] [varchar](255) NOT NULL,
	[ModelYear] [int] NOT NULL,
	[DailyPrice] [float] NOT NULL,
	[Description] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardName] [varchar](500) NOT NULL,
	[CardNumber] [varchar](500) NOT NULL,
	[ExpirationDate] [varchar](500) NOT NULL,
	[SecurityCode] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[UserId] [int] NOT NULL,
	[RentDate] [datetime2](7) NOT NULL,
	[ReturnDate] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19.10.2022 22:06:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarImages] ADD  DEFAULT (NULL) FOR [Date]
GO
ALTER TABLE [dbo].[Rentals] ADD  DEFAULT (NULL) FOR [ReturnDate]
GO
USE [master]
GO
ALTER DATABASE [MyDatabase] SET  READ_WRITE 
GO
