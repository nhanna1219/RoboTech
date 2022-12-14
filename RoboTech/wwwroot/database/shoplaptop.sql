USE [master]
GO
/****** Object:  Database [shoplaptop]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_Admin]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_Brand]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_Customers]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_Feedback]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_OrderDetail]    Script Date: 12/17/2022 5:49:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_OrderDetail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tb_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Orders]    Script Date: 12/17/2022 5:49:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[Status] [int] NULL,
	[DeliveryDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[TotalMoney] [int] NULL,
 CONSTRAINT [PK_tb_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Product]    Script Date: 12/17/2022 5:49:14 PM ******/
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
	[Thumb] [nchar](100) NULL,
	[Alias] [nchar](100) NULL,
	[Discount] [int] NULL,
 CONSTRAINT [PK_tb_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ProductCategory]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_Roles]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_Slide]    Script Date: 12/17/2022 5:49:14 PM ******/
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
/****** Object:  Table [dbo].[tb_User]    Script Date: 12/17/2022 5:49:14 PM ******/
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
SET IDENTITY_INSERT [dbo].[tb_Customers] ON 

INSERT [dbo].[tb_Customers] ([CustomerId], [FullName], [Birthday], [Avatar], [Address], [Email], [Phone], [CreateDate], [Password], [Salt], [LastLogin], [Active]) VALUES (14, N'Nguyễn Quốc Khánh', NULL, NULL, NULL, N'nqkdeveloper@gmail.com                            ', N'0392697777', CAST(N'2022-12-09T12:18:14.960' AS DateTime), N'558c3368ac0574dfb8275e7c1991c487', N'&rn#~     ', NULL, 1)
SET IDENTITY_INSERT [dbo].[tb_Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Product] ON 

INSERT [dbo].[tb_Product] ([ProductId], [Name], [Status], [Image], [ListImages], [Price], [PromotionPrice], [Quantity], [Warranty], [Hot], [Description], [ViewCount], [CateID], [BrandID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Thumb], [Alias], [Discount]) VALUES (1, N'Laptop ', NULL, NULL, NULL, 1000777, NULL, 0, 0, NULL, N'Asus', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_Product] ([ProductId], [Name], [Status], [Image], [ListImages], [Price], [PromotionPrice], [Quantity], [Warranty], [Hot], [Description], [ViewCount], [CateID], [BrandID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Thumb], [Alias], [Discount]) VALUES (3, N'Case Asus', 1, NULL, NULL, 9999999, NULL, 9999999, 0, NULL, N'Case PC VIP PRO', NULL, 2, NULL, NULL, NULL, NULL, NULL, N'case-asus.jpg                                                                                       ', N'case-asus                                                                                           ', NULL)
INSERT [dbo].[tb_Product] ([ProductId], [Name], [Status], [Image], [ListImages], [Price], [PromotionPrice], [Quantity], [Warranty], [Hot], [Description], [ViewCount], [CateID], [BrandID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Thumb], [Alias], [Discount]) VALUES (4, N'DELL GAMMING VIP PRO', 1, NULL, NULL, 999, NULL, 0, 0, NULL, N'DELL GAMMING', NULL, 1, NULL, NULL, NULL, NULL, NULL, N'dell-gamming-vip-pro.jpg                                                                            ', N'dell-gamming-vip-pro                                                                                ', NULL)
INSERT [dbo].[tb_Product] ([ProductId], [Name], [Status], [Image], [ListImages], [Price], [PromotionPrice], [Quantity], [Warranty], [Hot], [Description], [ViewCount], [CateID], [BrandID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Thumb], [Alias], [Discount]) VALUES (5, N'Laptop Dell', 1, NULL, NULL, 123123, NULL, 123, 0, NULL, N'dell vip ', NULL, 1, NULL, NULL, NULL, NULL, NULL, N'laptop-dell.jpg                                                                                     ', N'laptop-dell                                                                                         ', NULL)
SET IDENTITY_INSERT [dbo].[tb_Product] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_ProductCategory] ON 

INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (1, N'Laptop', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'laptop.jpg', NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (2, N'Case PC', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (3, N'PC', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (4, N'Screen ', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (5, N'Keyboard', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (6, N'Mouse', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (7, N'Headphone', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[tb_ProductCategory] ([CateId], [Name], [Status], [ParentID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Alias], [Ordering], [Published], [Thumb], [Title], [Description]) VALUES (11, N'TestCate01', 1, NULL, NULL, NULL, NULL, NULL, N'testcate01', NULL, 0, N'testcate01.jpg', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Roles] ON 

INSERT [dbo].[tb_Roles] ([RoleID], [RoleName], [Description]) VALUES (1, N'Admin', N'Adminndsad')
INSERT [dbo].[tb_Roles] ([RoleID], [RoleName], [Description]) VALUES (2, N'Customer', N'Khách Hàng')
INSERT [dbo].[tb_Roles] ([RoleID], [RoleName], [Description]) VALUES (6, N'ádsa', N'ádasd')
SET IDENTITY_INSERT [dbo].[tb_Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_User] ON 

INSERT [dbo].[tb_User] ([ID], [FullName], [Username], [Password], [Address], [RoleID], [LastLogin], [CreateDate], [Active], [Phone], [Email], [Salt]) VALUES (3, N'Nguyễn Quốc Khánh', NULL, NULL, NULL, 1, NULL, NULL, NULL, N'0392697777', N'20521452@gm.uit.edu.vn', NULL)
INSERT [dbo].[tb_User] ([ID], [FullName], [Username], [Password], [Address], [RoleID], [LastLogin], [CreateDate], [Active], [Phone], [Email], [Salt]) VALUES (4, N'Nguyễn Quốc Khánh', NULL, N'123456', NULL, 1, NULL, NULL, NULL, N'0392697777', N'khanh1234ptdtnttn@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[tb_User] OFF
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
ALTER TABLE [dbo].[tb_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tb_OrderDetail_tb_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tb_Orders] ([Id])
GO
ALTER TABLE [dbo].[tb_OrderDetail] CHECK CONSTRAINT [FK_tb_OrderDetail_tb_Orders]
GO
ALTER TABLE [dbo].[tb_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tb_OrderDetail_tb_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[tb_Product] ([ProductId])
GO
ALTER TABLE [dbo].[tb_OrderDetail] CHECK CONSTRAINT [FK_tb_OrderDetail_tb_Product]
GO
ALTER TABLE [dbo].[tb_Orders]  WITH CHECK ADD  CONSTRAINT [FK_tb_Orders_tb_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tb_Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[tb_Orders] CHECK CONSTRAINT [FK_tb_Orders_tb_Customers]
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
