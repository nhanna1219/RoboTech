USE [master]
GO
/****** Object:  Database [shoplaptop]    Script Date: 1/10/2023 5:58:49 PM ******/
CREATE DATABASE [shoplaptop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'shoplaptop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\shoplaptop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'shoplaptop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\shoplaptop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [shoplaptop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [shoplaptop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [shoplaptop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [shoplaptop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [shoplaptop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [shoplaptop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [shoplaptop] SET ARITHABORT OFF 
GO
ALTER DATABASE [shoplaptop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [shoplaptop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [shoplaptop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [shoplaptop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [shoplaptop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [shoplaptop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [shoplaptop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [shoplaptop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [shoplaptop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [shoplaptop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [shoplaptop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [shoplaptop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [shoplaptop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [shoplaptop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [shoplaptop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [shoplaptop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [shoplaptop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [shoplaptop] SET RECOVERY FULL 
GO
ALTER DATABASE [shoplaptop] SET  MULTI_USER 
GO
ALTER DATABASE [shoplaptop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [shoplaptop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [shoplaptop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [shoplaptop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [shoplaptop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [shoplaptop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'shoplaptop', N'ON'
GO
ALTER DATABASE [shoplaptop] SET QUERY_STORE = OFF
GO
USE [shoplaptop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Admin]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Admin](
	[ID] [int] NOT NULL,
	[NAME] [varchar](32) NULL,
	[username] [nchar](10) NOT NULL,
	[password] [nchar](10) NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_tb_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Brand]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Brand](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_tb_Brand] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Customers]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Birthday] [datetime] NULL,
	[Avatar] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nchar](50) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[CreateDate] [datetime] NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Salt] [nchar](10) NOT NULL,
	[LastLogin] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_tb_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Feedback]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Detail] [nvarchar](500) NULL,
 CONSTRAINT [PK_tb_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_OrderDetail]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Price] [int] NULL,
	[OrderNumber] [int] NULL,
	[Quantity] [int] NULL,
	[Amount] [int] NULL,
	[Discount] [int] NULL,
	[TotalMoney] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_tb_OrderDetail_1] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Orders]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[Status] [int] NULL,
	[DeliveryDate] [datetime] NULL,
	[CustomerId] [int] NULL,
	[TotalMoney] [int] NULL,
	[TransactStatusId] [int] NULL,
	[Deleted] [bit] NULL,
	[Note] [nchar](100) NULL,
	[Address] [nchar](100) NULL,
	[Paid] [bit] NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentID] [int] NULL,
	[ShipDate] [datetime] NULL,
 CONSTRAINT [PK_tb_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Product]    Script Date: 1/10/2023 5:58:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[Image] [nvarchar](250) NULL,
	[ListImages] [xml] NULL,
	[Price] [int] NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[Warranty] [int] NOT NULL,
	[Hot] [datetime] NULL,
	[Description] [nvarchar](500) NOT NULL,
	[ViewCount] [int] NULL,
	[CateID] [int] NULL,
	[BrandID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Thumb] [nvarchar](250) NULL,
	[Alias] [nvarchar](250) NULL,
	[Discount] [int] NULL,
 CONSTRAINT [PK_tb_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProductCategory]    Script Date: 1/10/2023 5:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ProductCategory](
	[CateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
	[ParentID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Alias] [nchar](10) NULL,
	[Ordering] [int] NULL,
	[Published] [bit] NOT NULL,
	[Thumb] [nvarchar](250) NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_ProductCategory] SET (LOCK_ESCALATION = DISABLE)
GO
/****** Object:  Table [dbo].[tb_Roles]    Script Date: 1/10/2023 5:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Slide]    Script Date: 1/10/2023 5:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tb_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_TransactStatus]    Script Date: 1/10/2023 5:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_TransactStatus](
	[TransactStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_TransactStatus] PRIMARY KEY CLUSTERED 
(
	[TransactStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_User]    Script Date: 1/10/2023 5:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Address] [nchar](10) NULL,
	[RoleID] [int] NULL,
	[LastLogin] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[Active] [bit] NULL,
	[Phone] [nvarchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[Salt] [nchar](10) NULL,
 CONSTRAINT [PK_tb_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_Admin] ADD  CONSTRAINT [DF_tb_Admin_NAME]  DEFAULT ('Admin') FOR [NAME]
GO
ALTER TABLE [dbo].[tb_Product] ADD  CONSTRAINT [DF_tb_Product_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[tb_Product] ADD  CONSTRAINT [DF_tb_Product_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[tb_Product] ADD  CONSTRAINT [DF_tb_Product_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[tb_Product] ADD  CONSTRAINT [DF_tb_Product_Warranty]  DEFAULT ((0)) FOR [Warranty]
GO
ALTER TABLE [dbo].[tb_ProductCategory] ADD  CONSTRAINT [DF_tb_ProductCategory_Status_1]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[tb_ProductCategory] ADD  CONSTRAINT [DF_tb_ProductCategory_Published]  DEFAULT ((0)) FOR [Published]
GO
ALTER TABLE [dbo].[tb_Admin]  WITH CHECK ADD  CONSTRAINT [FK_tb_Admin_tb_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[tb_Roles] ([RoleID])
GO
ALTER TABLE [dbo].[tb_Admin] CHECK CONSTRAINT [FK_tb_Admin_tb_Roles]
GO
ALTER TABLE [dbo].[tb_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tb_OrderDetail_tb_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[tb_Orders] ([Id])
GO
ALTER TABLE [dbo].[tb_OrderDetail] CHECK CONSTRAINT [FK_tb_OrderDetail_tb_Orders]
GO
ALTER TABLE [dbo].[tb_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tb_OrderDetail_tb_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tb_Product] ([ProductId])
GO
ALTER TABLE [dbo].[tb_OrderDetail] CHECK CONSTRAINT [FK_tb_OrderDetail_tb_Product]
GO
ALTER TABLE [dbo].[tb_Orders]  WITH CHECK ADD  CONSTRAINT [FK_tb_Orders_tb_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tb_Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[tb_Orders] CHECK CONSTRAINT [FK_tb_Orders_tb_Customers]
GO
ALTER TABLE [dbo].[tb_Orders]  WITH CHECK ADD  CONSTRAINT [FK_tb_Orders_tb_TransactStatus1] FOREIGN KEY([TransactStatusId])
REFERENCES [dbo].[tb_TransactStatus] ([TransactStatusId])
GO
ALTER TABLE [dbo].[tb_Orders] CHECK CONSTRAINT [FK_tb_Orders_tb_TransactStatus1]
GO
ALTER TABLE [dbo].[tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_tb_Product_tb_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[tb_Brand] ([ID])
GO
ALTER TABLE [dbo].[tb_Product] CHECK CONSTRAINT [FK_tb_Product_tb_Brand]
GO
ALTER TABLE [dbo].[tb_Product]  WITH CHECK ADD  CONSTRAINT [FK_tb_Product_tb_ProductCategory] FOREIGN KEY([CateID])
REFERENCES [dbo].[tb_ProductCategory] ([CateId])
GO
ALTER TABLE [dbo].[tb_Product] CHECK CONSTRAINT [FK_tb_Product_tb_ProductCategory]
GO
ALTER TABLE [dbo].[tb_User]  WITH CHECK ADD  CONSTRAINT [FK_tb_User_tb_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[tb_Roles] ([RoleID])
GO
ALTER TABLE [dbo].[tb_User] CHECK CONSTRAINT [FK_tb_User_tb_Roles]
GO
USE [master]
GO
ALTER DATABASE [shoplaptop] SET  READ_WRITE 
GO
