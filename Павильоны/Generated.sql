USE [master]
GO
/****** Object:  Database [PavilionsDb]    Script Date: 30.05.2020 14:19:58 ******/
CREATE DATABASE [PavilionsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PavilionsDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PavilionsDb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PavilionsDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PavilionsDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PavilionsDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PavilionsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PavilionsDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PavilionsDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PavilionsDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PavilionsDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PavilionsDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PavilionsDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PavilionsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PavilionsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PavilionsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PavilionsDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PavilionsDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PavilionsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PavilionsDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PavilionsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PavilionsDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PavilionsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PavilionsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PavilionsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PavilionsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PavilionsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PavilionsDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PavilionsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PavilionsDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PavilionsDb] SET  MULTI_USER 
GO
ALTER DATABASE [PavilionsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PavilionsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PavilionsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PavilionsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PavilionsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PavilionsDb] SET QUERY_STORE = OFF
GO
USE [PavilionsDb]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [Cities_PK] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[SecondName] [nvarchar](20) NOT NULL,
	[Photo] [varbinary](max) NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [Employees_PK] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesRoles]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesRoles](
	[RoleId] [int] NOT NULL,
	[Role] [nvarchar](20) NULL,
 CONSTRAINT [EmployeesRoles_PK] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pavilions]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pavilions](
	[PavilionId] [int] NOT NULL,
	[CenterId] [int] NOT NULL,
	[PavilionNumber] [nvarchar](3) NOT NULL,
	[Floor] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Square] [decimal](18, 0) NOT NULL,
	[CostPerSquare] [decimal](18, 0) NOT NULL,
	[ValueFactor] [decimal](18, 0) NOT NULL,
 CONSTRAINT [Pavilions_PK] PRIMARY KEY CLUSTERED 
(
	[PavilionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PavilionsStatuses]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PavilionsStatuses](
	[StatusId] [int] NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
 CONSTRAINT [PavilionsStatuses_PK] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rent]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rent](
	[RentId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[CenterId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[PavilionId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[RentalStart] [datetimeoffset](7) NOT NULL,
	[RentalEnd] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [Rent_PK] PRIMARY KEY CLUSTERED 
(
	[RentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentStatuses]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentStatuses](
	[StatusId] [int] NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
 CONSTRAINT [RentStatuses_PK] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sh]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sh](
	[ID Аренды] [float] NULL,
	[ID Арендатора] [float] NULL,
	[Название ТЦ] [nvarchar](255) NULL,
	[ID Сотрудник] [float] NULL,
	[№ Павильона] [nvarchar](255) NULL,
	[Статус] [nvarchar](255) NULL,
	[Начало Аренды] [datetime] NULL,
	[Окончание Аренды] [datetime] NULL,
	[F9] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sh1]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sh1](
	[Логин] [nvarchar](255) NULL,
	[Пароль] [nvarchar](255) NULL,
	[Роль] [nvarchar](255) NULL,
	[Номер телефона] [nvarchar](255) NULL,
	[Пол] [nvarchar](255) NULL,
	[ID] [float] NULL,
	[Фото] [varbinary](max) NULL,
	[a1] [nvarchar](255) NULL,
	[a2] [nvarchar](255) NULL,
	[a3] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sh2]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sh2](
	[Код] [float] NULL,
	[Название ТЦ] [nvarchar](255) NULL,
	[№ Павильона] [nvarchar](255) NULL,
	[Этаж] [float] NULL,
	[Статус] [nvarchar](255) NULL,
	[Площадь] [float] NULL,
	[Стоимость за кв#м] [float] NULL,
	[Кооф# Добавочной стоимости] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sh3]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sh3](
	[ID Арендатора] [float] NULL,
	[Название ] [nvarchar](255) NULL,
	[Номер] [nvarchar](255) NULL,
	[Адрес] [nvarchar](255) NULL,
	[F5] [nvarchar](255) NULL,
	[F6] [nvarchar](255) NULL,
	[F7] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sh4]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sh4](
	[ID Аренды] [float] NULL,
	[ID Арендатора] [float] NULL,
	[Название ТЦ] [nvarchar](255) NULL,
	[ID Сотрудник] [float] NULL,
	[№ Павильона] [nvarchar](255) NULL,
	[Статус] [nvarchar](255) NULL,
	[Начало Аренды] [datetime] NULL,
	[Окончание Аренды] [datetime] NULL,
	[F9] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCenters]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCenters](
	[CenterId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[StatusId] [int] NOT NULL,
	[PavilionsQuantity] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Cost] [money] NOT NULL,
	[ValueFactor] [decimal](18, 0) NOT NULL,
	[FloorsQuantity] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [ShoppingCenters_PK] PRIMARY KEY CLUSTERED 
(
	[CenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCentersStatuses]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCentersStatuses](
	[StatusId] [int] NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
 CONSTRAINT [ShoppingCentersStatuses_PK] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 30.05.2020 14:19:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantId] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Phone] [nvarchar](16) NOT NULL,
	[Adress] [nvarchar](50) NOT NULL,
 CONSTRAINT [Tenants_PK] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (1, N'Москва')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (2, N'Санкт-Петербург')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (3, N'Новосибирск')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (4, N'Екатеринбург')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (5, N'Нижний Новгород')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (6, N'Казань')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (7, N'Челябинск')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (8, N'Самара')
INSERT [dbo].[Cities] ([CityId], [Name]) VALUES (9, N'Ростов-на-Дону')
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (1, N'М', N' +7(1070)628 29 16', N'yntiRS', N'Elizor@gmail.com', N'Чашин', N'Елизар', N'Михеевич', NULL, 1)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (2, N'Ж', N' +7(334)1460151', N'07i7Lb', N'Vladlena@gmail.com', N'Филенкова', N'Владлена', N'Олеговна', NULL, 2)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (3, N'М', N'+7(8560)519-32-99', N'7SP9CV', N'Adam@gmail.com', N'Ломовцев', N'Адам', N'Владимирович', NULL, 3)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (4, N'М', N'+7(824)893-24-03', N'6QF1WB', N'Kar@gmail.com', N'Тепляков', N'Кир', N'Федосиевич', NULL, 4)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (5, N'М', N'+7(6402)701-31-09', N'GwffgE', N'Yli@gmail.com', N'Рюриков', N'Юлий', N'Глебович', NULL, 1)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (6, N'Ж', N'+7(92)920-74-47', N'd7iKKV', N'Vasilisa@gmail.com', N'Беломестина', N'Василиса', N'Тимофеевна', NULL, 1)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (7, N'Ж', N' +7 (405) 088 73 89', N'8KC7wJ', N'Galina@gmail.com', N'Панькива', N'Галина', N'Якововна', NULL, 2)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (8, N'М', N'+7(6010)195-02-09', N'x58OAN', N'Miron@gmail.com', N'Зарубин', N'Мирон', N'Мечиславович', NULL, 1)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (9, N'Ж', N'+7(078)429-57-86', N'fhDSBf', N'Vseslava@gmail.com', N'Веточкина', N'Всеслава', N'Андрияновна', NULL, 3)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (10, N'Ж', N'+7(6394)904-01-61', N'9mlPQJ', N'Victoria@gmail.com', N'Рябова', N'Виктория', N'Елизаровна', NULL, 4)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (11, N'М', N' +7(22)3264959', N'Wh4OYm', N'Anisa@gmail.com', N'Федотов', N'Леон', N'Фёдорович', NULL, 2)
INSERT [dbo].[Employees] ([EmployeeId], [Gender], [Phone], [Password], [Login], [LastName], [Name], [SecondName], [Photo], [RoleId]) VALUES (12, N'М', N'+7(789)762-30-28', N'Kc1PeS', N'Feafan@gmail.com', N'Шарапов', N'Феофан', N'Кириллович', NULL, 3)
INSERT [dbo].[EmployeesRoles] ([RoleId], [Role]) VALUES (1, N'Администратор')
INSERT [dbo].[EmployeesRoles] ([RoleId], [Role]) VALUES (2, N'Менеджер А')
INSERT [dbo].[EmployeesRoles] ([RoleId], [Role]) VALUES (3, N'Менеджер С')
INSERT [dbo].[EmployeesRoles] ([RoleId], [Role]) VALUES (4, N'Удален')
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (1, 3, N'88А', 1, 1, CAST(75 AS Decimal(18, 0)), CAST(3308 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (2, 2, N'40А', 3, 2, CAST(96 AS Decimal(18, 0)), CAST(690 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (3, 3, N'76Б', 2, 3, CAST(199 AS Decimal(18, 0)), CAST(4938 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (4, 4, N'61А', 1, 4, CAST(186 AS Decimal(18, 0)), CAST(2115 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (5, 10, N'58В', 4, 4, CAST(98 AS Decimal(18, 0)), CAST(1306 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (6, 6, N'7А', 2, 2, CAST(187 AS Decimal(18, 0)), CAST(2046 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (7, 7, N'12Б', 1, 2, CAST(141 AS Decimal(18, 0)), CAST(1131 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (8, 8, N'60В', 2, 2, CAST(94 AS Decimal(18, 0)), CAST(361 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (9, 10, N'56А', 1, 4, CAST(148 AS Decimal(18, 0)), CAST(1163 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (10, 10, N'63Г', 2, 2, CAST(153 AS Decimal(18, 0)), CAST(3486 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (11, 11, N'8Г', 1, 4, CAST(122 AS Decimal(18, 0)), CAST(2451 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (12, 10, N'94В', 3, 1, CAST(132 AS Decimal(18, 0)), CAST(4825 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (13, 13, N'87Г', 1, 2, CAST(174 AS Decimal(18, 0)), CAST(793 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (14, 14, N'93В', 1, 4, CAST(165 AS Decimal(18, 0)), CAST(4937 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (15, 15, N'10А', 3, 2, CAST(168 AS Decimal(18, 0)), CAST(1353 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (16, 23, N'53Г', 1, 4, CAST(99 AS Decimal(18, 0)), CAST(3924 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (17, 23, N'73В', 2, 1, CAST(116 AS Decimal(18, 0)), CAST(3418 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (18, 18, N'89Б', 1, 1, CAST(92 AS Decimal(18, 0)), CAST(562 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (19, 19, N'44Г', 2, 2, CAST(67 AS Decimal(18, 0)), CAST(870 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (20, 20, N'65А', 2, 2, CAST(95 AS Decimal(18, 0)), CAST(1381 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (21, 21, N'15Г', 2, 3, CAST(150 AS Decimal(18, 0)), CAST(747 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (22, 22, N'61Б', 1, 1, CAST(58 AS Decimal(18, 0)), CAST(1032 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (23, 23, N'34Б', 4, 2, CAST(102 AS Decimal(18, 0)), CAST(4715 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (24, 23, N'91Г', 3, 4, CAST(171 AS Decimal(18, 0)), CAST(1021 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (25, 25, N'70Г', 1, 2, CAST(83 AS Decimal(18, 0)), CAST(2246 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (26, 26, N'11А', 1, 2, CAST(187 AS Decimal(18, 0)), CAST(2067 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (27, 27, N'80Г', 1, 2, CAST(117 AS Decimal(18, 0)), CAST(1049 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (28, 28, N'2Б', 1, 3, CAST(176 AS Decimal(18, 0)), CAST(1673 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (29, 29, N'41А', 1, 1, CAST(108 AS Decimal(18, 0)), CAST(344 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (30, 30, N'16Г', 2, 4, CAST(125 AS Decimal(18, 0)), CAST(1037 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (31, 22, N'13Б', 2, 1, CAST(162 AS Decimal(18, 0)), CAST(2776 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (32, 32, N'83Г', 2, 4, CAST(86 AS Decimal(18, 0)), CAST(4584 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (33, 33, N'9Г', 1, 2, CAST(131 AS Decimal(18, 0)), CAST(2477 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (34, 34, N'49Г', 1, 4, CAST(164 AS Decimal(18, 0)), CAST(2728 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (35, 35, N'1Г', 1, 3, CAST(157 AS Decimal(18, 0)), CAST(1963 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (36, 22, N'37А', 3, 4, CAST(187 AS Decimal(18, 0)), CAST(3173 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (37, 22, N'38Г', 4, 4, CAST(97 AS Decimal(18, 0)), CAST(1364 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (38, 38, N'27В', 1, 2, CAST(96 AS Decimal(18, 0)), CAST(3134 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (39, 39, N'67Б', 1, 3, CAST(55 AS Decimal(18, 0)), CAST(4442 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (40, 40, N'86Г', 1, 1, CAST(58 AS Decimal(18, 0)), CAST(3707 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (41, 41, N'98А', 3, 2, CAST(173 AS Decimal(18, 0)), CAST(4951 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (42, 42, N'11Г', 2, 4, CAST(194 AS Decimal(18, 0)), CAST(827 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (43, 48, N'42В', 1, 1, CAST(166 AS Decimal(18, 0)), CAST(4216 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (44, 44, N'55А', 2, 2, CAST(127 AS Decimal(18, 0)), CAST(703 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (45, 48, N'6Б', 2, 1, CAST(119 AS Decimal(18, 0)), CAST(3262 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (46, 46, N'15А', 1, 2, CAST(90 AS Decimal(18, 0)), CAST(1569 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (47, 48, N'27Б', 3, 4, CAST(132 AS Decimal(18, 0)), CAST(627 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (48, 48, N'65Б', 4, 3, CAST(60 AS Decimal(18, 0)), CAST(3052 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (49, 49, N'26А', 1, 1, CAST(95 AS Decimal(18, 0)), CAST(670 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[Pavilions] ([PavilionId], [CenterId], [PavilionNumber], [Floor], [StatusId], [Square], [CostPerSquare], [ValueFactor]) VALUES (50, 49, N'53В', 3, 4, CAST(132 AS Decimal(18, 0)), CAST(510 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[PavilionsStatuses] ([StatusId], [Status]) VALUES (1, N'Свободен')
INSERT [dbo].[PavilionsStatuses] ([StatusId], [Status]) VALUES (2, N'Забронировано')
INSERT [dbo].[PavilionsStatuses] ([StatusId], [Status]) VALUES (3, N'Удален')
INSERT [dbo].[PavilionsStatuses] ([StatusId], [Status]) VALUES (4, N'Арендован')
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (1, 2, 3, 2, 1, 1, CAST(N'2019-01-24T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-11-17T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (2, 2, 2, 7, 2, 2, CAST(N'2019-11-21T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-04-18T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (3, 5, 4, 11, 4, 3, CAST(N'2018-11-12T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-06-28T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (4, 1, 10, 2, 5, 3, CAST(N'2018-10-18T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-09-16T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (5, 5, 6, 7, 6, 2, CAST(N'2019-12-19T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-06-26T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (6, 2, 7, 11, 31, 2, CAST(N'2019-12-16T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-05-12T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (7, 4, 8, 2, 8, 2, CAST(N'2019-12-06T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-10-16T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (8, 2, 10, 11, 9, 3, CAST(N'2018-09-03T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-02-10T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (9, 2, 10, 2, 10, 2, CAST(N'2019-11-04T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-06-27T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (10, 4, 11, 7, 11, 3, CAST(N'2018-11-08T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-01-16T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (11, 1, 10, 2, 12, 1, CAST(N'2019-06-07T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-03-18T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (12, 1, 13, 2, 13, 2, CAST(N'2019-11-15T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-06-20T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (13, 5, 14, 11, 14, 3, CAST(N'2018-10-09T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-09-22T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (14, 5, 15, 7, 15, 2, CAST(N'2019-11-24T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-07-17T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (15, 1, 23, 7, 16, 3, CAST(N'2018-07-20T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-06-07T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (16, 3, 23, 11, 17, 1, CAST(N'2019-02-04T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-08-06T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (17, 2, 18, 2, 18, 1, CAST(N'2019-08-06T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-08-20T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (18, 1, 22, 7, 22, 1, CAST(N'2019-05-23T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-05-13T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (19, 3, 23, 2, 23, 2, CAST(N'2019-12-16T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-03-16T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (20, 3, 23, 11, 24, 3, CAST(N'2018-08-24T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-08-04T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (21, 5, 25, 2, 25, 2, CAST(N'2019-11-09T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-08-17T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (22, 4, 15, 7, 15, 2, CAST(N'2019-12-02T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-07-24T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (23, 2, 27, 11, 27, 2, CAST(N'2019-11-23T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-08-06T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (24, 4, 29, 7, 29, 1, CAST(N'2019-05-02T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-06-24T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (25, 3, 7, 2, 31, 2, CAST(N'2019-12-08T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-08-17T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (26, 3, 32, 7, 32, 3, CAST(N'2018-11-14T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-04-19T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (27, 4, 33, 11, 33, 2, CAST(N'2019-12-26T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-09-13T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (28, 1, 34, 2, 34, 3, CAST(N'2018-09-16T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-02-12T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (29, 3, 22, 2, 36, 3, CAST(N'2018-10-18T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-06-22T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (30, 4, 22, 2, 37, 3, CAST(N'2018-06-23T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-08-26T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (31, 3, 38, 11, 38, 2, CAST(N'2019-12-18T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-05-23T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (32, 5, 40, 7, 40, 1, CAST(N'2019-04-01T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-12-19T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (33, 4, 41, 11, 41, 2, CAST(N'2019-11-22T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-08-15T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (34, 3, 42, 11, 42, 3, CAST(N'2018-10-08T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-07-21T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (35, 2, 48, 2, 43, 1, CAST(N'2019-04-07T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-03-05T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (36, 1, 44, 7, 44, 2, CAST(N'2019-11-07T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-03-08T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (37, 3, 48, 2, 45, 1, CAST(N'2019-07-15T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-04-25T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (38, 1, 46, 2, 46, 2, CAST(N'2021-07-03T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-12-02T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (39, 4, 48, 11, 47, 3, CAST(N'2018-08-05T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-06-14T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (40, 2, 49, 11, 49, 1, CAST(N'2019-08-19T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2020-09-02T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Rent] ([RentId], [TenantId], [CenterId], [EmployeeId], [PavilionId], [StatusId], [RentalStart], [RentalEnd]) VALUES (41, 4, 49, 7, 50, 3, CAST(N'2018-09-20T00:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2019-02-12T00:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[RentStatuses] ([StatusId], [Status]) VALUES (1, N'Открыт')
INSERT [dbo].[RentStatuses] ([StatusId], [Status]) VALUES (2, N'Ожидание')
INSERT [dbo].[RentStatuses] ([StatusId], [Status]) VALUES (3, N'Закрыт')
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (1, 2, N'Мега Белая Дача', 2, N'88А', N'1', CAST(N'2019-01-24T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (2, 2, N'Авиапарк', 7, N'40А', N'2', CAST(N'2019-11-21T00:00:00.000' AS DateTime), CAST(N'2020-04-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (3, 5, N'Рио', 11, N'61А', N'3', CAST(N'2018-11-12T00:00:00.000' AS DateTime), CAST(N'2019-06-28T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (4, 1, N'Гранд', 2, N'58В', N'3', CAST(N'2018-10-18T00:00:00.000' AS DateTime), CAST(N'2019-09-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (5, 5, N'Лужайка', 7, N'7А', N'2', CAST(N'2019-12-19T00:00:00.000' AS DateTime), CAST(N'2020-06-26T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (6, 2, N'Кунцево Плаза', 11, N'13Б', N'2', CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-05-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (7, 4, N'Мозаика', 2, N'60В', N'2', CAST(N'2019-12-06T00:00:00.000' AS DateTime), CAST(N'2020-10-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (8, 2, N'Гранд', 11, N'56А', N'3', NULL, CAST(N'2019-02-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (9, 2, N'Гранд', 2, N'63Г', N'2', CAST(N'2019-11-04T00:00:00.000' AS DateTime), CAST(N'2020-06-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (10, 4, N'Бутово Молл', 7, N'8Г', N'3', CAST(N'2018-11-08T00:00:00.000' AS DateTime), CAST(N'2019-01-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (11, 1, N'Гранд', 2, N'94В', N'1', CAST(N'2019-06-07T00:00:00.000' AS DateTime), CAST(N'2020-03-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (12, 1, N'Шоколад', 2, N'87Г', N'2', CAST(N'2019-11-15T00:00:00.000' AS DateTime), CAST(N'2020-06-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (13, 5, N'АфиМолл Сити', 11, N'93В', N'3', CAST(N'2018-10-09T00:00:00.000' AS DateTime), CAST(N'2019-09-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (14, 5, N'Европейский', 7, N'10А', N'2', CAST(N'2019-11-24T00:00:00.000' AS DateTime), CAST(N'2020-07-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (15, 1, N'Шереметьевский', 7, N'53Г', N'3', CAST(N'2018-07-20T00:00:00.000' AS DateTime), CAST(N'2019-06-07T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (16, 3, N'Шереметьевский', 11, N'73В', N'1', CAST(N'2019-02-04T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (17, 2, N'Мега Химки', 2, N'89Б', N'1', CAST(N'2019-08-06T00:00:00.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (18, 1, N'Золотой Вавилон Ростокино', 7, N'61Б', N'1', CAST(N'2019-05-23T00:00:00.000' AS DateTime), CAST(N'2020-05-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (19, 3, N'Шереметьевский', 2, N'34Б', N'2', CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-03-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (20, 3, N'Шереметьевский', 11, N'91Г', N'3', CAST(N'2018-08-24T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (21, 5, N'Ашан Сити Капитолий', 2, N'70Г', N'2', CAST(N'2019-11-09T00:00:00.000' AS DateTime), CAST(N'2020-08-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (22, 4, N'Европейский', 7, N'10А', N'2', CAST(N'2019-12-02T00:00:00.000' AS DateTime), CAST(N'2020-07-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (23, 2, N'Филион', 11, N'80Г', N'2', CAST(N'2019-11-23T00:00:00.000' AS DateTime), CAST(N'2020-08-06T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (24, 4, N'Гудзон', 7, N'41А', N'1', CAST(N'2019-05-02T00:00:00.000' AS DateTime), CAST(N'2020-06-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (25, 3, N'Кунцево Плаза', 2, N'13Б', N'2', CAST(N'2019-12-08T00:00:00.000' AS DateTime), CAST(N'2020-08-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (26, 3, N'Хорошо', 7, N'83Г', N'3', CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-04-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (27, 4, N'Щука', 11, N'9Г', N'2', CAST(N'2019-12-26T00:00:00.000' AS DateTime), CAST(N'2020-09-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (28, 1, N'Атриум', 2, N'49Г', N'3', CAST(N'2018-09-16T00:00:00.000' AS DateTime), CAST(N'2019-02-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (29, 3, N'Золотой Вавилон Ростокино', 2, N'37А', N'3', CAST(N'2018-10-18T00:00:00.000' AS DateTime), CAST(N'2019-06-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (30, 4, N'Золотой Вавилон Ростокино', 2, N'38Г', N'3', CAST(N'2018-06-23T00:00:00.000' AS DateTime), CAST(N'2019-08-26T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (31, 3, N'Реутов Парк', 11, N'27В', N'2', CAST(N'2019-12-18T00:00:00.000' AS DateTime), CAST(N'2020-05-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (32, 5, N'ГУМ', 7, N'86Г', N'1', CAST(N'2019-04-01T00:00:00.000' AS DateTime), CAST(N'2020-12-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (33, 4, N'Райкин Плаза', 11, N'98А', N'2', CAST(N'2019-11-22T00:00:00.000' AS DateTime), CAST(N'2020-08-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (34, 3, N'Новинский пассаж', 11, N'11Г', N'3', CAST(N'2018-10-08T00:00:00.000' AS DateTime), CAST(N'2019-07-21T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (35, 2, N'Фестиваль', 2, N'42В', N'1', CAST(N'2019-04-07T00:00:00.000' AS DateTime), CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (36, 1, N'Красный Кит', 7, N'55А', N'2', CAST(N'2019-11-07T00:00:00.000' AS DateTime), CAST(N'2020-03-08T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (37, 3, N'Фестиваль', 2, N'6Б', N'1', CAST(N'2019-07-15T00:00:00.000' AS DateTime), CAST(N'2020-04-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (38, 1, N'Отрада', 2, N'15А', N'2', NULL, CAST(N'2020-12-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (39, 4, N'Фестиваль', 11, N'27Б', N'3', CAST(N'2018-08-05T00:00:00.000' AS DateTime), CAST(N'2019-06-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (40, 2, N'Времена Года', 11, N'26А', N'1', CAST(N'2019-08-19T00:00:00.000' AS DateTime), CAST(N'2020-09-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (41, 4, N'Времена Года', 7, N'53В', N'3', CAST(N'2018-09-20T00:00:00.000' AS DateTime), CAST(N'2019-02-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Elizor@gmail.com', N'yntiRS', N'1', N' +7(1070)628 29 16', N'М', 1, NULL, N'Чашин', N'Елизар', N'Михеевич')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Vladlena@gmail.com', N'07i7Lb', N'2', N' +7(334)1460151', N'Ж', 2, NULL, N'Филенкова', N'Владлена', N'Олеговна')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Adam@gmail.com', N'7SP9CV', N'3', N'+7(8560)519-32-99', N'М', 3, NULL, N'Ломовцев', N'Адам', N'Владимирович')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Kar@gmail.com', N'6QF1WB', N'4', N'+7(824)893-24-03', N'М', 4, NULL, N'Тепляков', N'Кир', N'Федосиевич')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Yli@gmail.com', N'GwffgE', N'1', N'+7(6402)701-31-09', N'М', 5, NULL, N'Рюриков', N'Юлий', N'Глебович')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Vasilisa@gmail.com', N'd7iKKV', N'1', N'+7(92)920-74-47', N'Ж', 6, NULL, N'Беломестина', N'Василиса', N'Тимофеевна')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Galina@gmail.com', N'8KC7wJ', N'2', N' +7 (405) 088 73 89', N'Ж', 7, NULL, N'Панькива', N'Галина', N'Якововна')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Miron@gmail.com', N'x58OAN', N'1', N'+7(6010)195-02-09', N'М', 8, NULL, N'Зарубин', N'Мирон', N'Мечиславович')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Vseslava@gmail.com', N'fhDSBf', N'3', N'+7(078)429-57-86', N'Ж', 9, NULL, N'Веточкина', N'Всеслава', N'Андрияновна')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Victoria@gmail.com', N'9mlPQJ', N'4', N'+7(6394)904-01-61', N'Ж', 10, NULL, N'Рябова', N'Виктория', N'Елизаровна')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Anisa@gmail.com', N'Wh4OYm', N'2', N' +7(22)3264959', N'М', 11, NULL, N'Федотов', N'Леон', N'Фёдорович')
INSERT [dbo].[Sh1] ([Логин], [Пароль], [Роль], [Номер телефона], [Пол], [ID], [Фото], [a1], [a2], [a3]) VALUES (N'Feafan@gmail.com', N'Kc1PeS', N'3', N'+7(789)762-30-28', N'М', 12, NULL, N'Шарапов', N'Феофан', N'Кириллович')
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (1, N'3', N'88А', 1, N'1', 75, 3307.7, 0.1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (2, N'2', N'40А', 3, N'2', 96, 690, 1.1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (3, N'3', N'76Б', 2, N'3', 199, 4938, 0.9)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (4, N'4', N'61А', 1, N'4', 186, 2115, 0.9)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (5, N'10', N'58В', 4, N'4', 98, 1306, 1.9)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (6, N'6', N'7А', 2, N'2', 187, 2046, 1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (7, N'7', N'13Б', 1, N'2', 141, 1131, 0.1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (8, N'8', N'60В', 2, N'2', 94, 361, 0.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (9, N'10', N'56А', 1, N'4', 148, 1163, 0.6)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (10, N'10', N'63Г', 2, N'2', 153, 3486, 0.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (11, N'11', N'8Г', 1, N'4', 122, 2451, 1.5)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (12, N'10', N'94В', 3, N'1', 132, 4825, 2)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (13, N'13', N'87Г', 1, N'2', 174, 793, 1.5)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (14, N'14', N'93В', 1, N'4', 165, 4937, 0.8)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (15, N'15', N'10А', 3, N'2', 168, 1353, 1.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (16, N'23', N'53Г', 1, N'4', 99, 3924, 1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (17, N'23', N'73В', 2, N'1', 116, 3418, 0)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (18, N'18', N'89Б', 1, N'1', 92, 562, 0.4)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (19, N'19', N'44Г', 2, N'2', 66.6, 870.3, 1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (20, N'20', N'65А', 2, N'2', 95, 1381, 1.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (21, N'21', N'16Г', 2, N'3', 150, 747, 0.8)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (22, N'22', N'61Б', 1, N'1', 58, 1032, 1.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (23, N'23', N'34Б', 4, N'2', 102, 4715, 0.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (24, N'23', N'91Г', 3, N'4', 171, 1021, 1.2)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (25, N'25', N'70Г', 1, N'2', 83, 2246, 1.4)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (26, N'26', N'10А', 1, N'2', 187, 2067, 0)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (27, N'27', N'80Г', 1, N'2', 117, 1049, 1.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (28, N'28', N'2Б', 1, N'3', 176, 1673, 1.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (29, N'29', N'41А', 1, N'1', 108, 344, 0)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (30, N'30', N'16Г', 2, N'4', 125, 1037, 1.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (31, N'22', N'13Б', 2, N'1', 161.5, 2775.7, 0.4)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (32, N'32', N'83Г', 2, N'4', 85.5, 4584, 0.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (33, N'33', N'9Г', 1, N'2', 131, 2477, 1.5)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (34, N'34', N'49Г', 1, N'4', 164, 2728, 0.9)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (35, N'35', N'1Г', 1, N'3', 157, 1963, 1.6)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (36, N'22', N'37А', 3, N'4', 187, 3173, 0.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (37, N'22', N'38Г', 4, N'4', 97, 1364, 0.5)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (38, N'38', N'27В', 1, N'2', 96, 3134, 0.1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (39, N'39', N'67Б', 1, N'3', 55, 4442, 0.8)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (40, N'40', N'86Г', 1, N'1', 58, 3707, 0.5)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (41, N'41', N'98А', 3, N'2', 172.5, 4951, 1.1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (42, N'42', N'11Г', 2, N'4', 194, 827, 0.6)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (43, N'48', N'42В', 1, N'1', 166, 4216, 0.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (44, N'44', N'55А', 2, N'2', 127, 703.1, 1)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (45, N'48', N'6Б', 2, N'1', 119, 3262, 1.9)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (46, N'46', N'15А', 1, N'2', 90, 1569, 1.3)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (47, N'48', N'27Б', 3, N'4', 132, 627, 0.4)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (48, N'48', N'65Б', 4, N'3', 60, 3052, 0.6)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (49, N'49', N'26А', 1, N'1', 95, 670, 1.7)
INSERT [dbo].[Sh2] ([Код], [Название ТЦ], [№ Павильона], [Этаж], [Статус], [Площадь], [Стоимость за кв#м], [Кооф# Добавочной стоимости]) VALUES (50, N'49', N'53В', 3, N'4', 132, 510, 1.2)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (1, N'AG Marine', N'+7(495)526-14-53', N'Москва, Бабаевская улица д.16', N'Москва, Бабаевская улица д.16', NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (2, N'Art-elle', N'+7(495)250-58-94', N'Санкт-Петербург, Амбарная улица д.25 корп.1', N'Санкт-Петербург, Амбарная улица д.25 корп.1', NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (3, N'Atlantis', N'+7(495)424-11-65', N'Новосибирск, Улица Каменская д.16', N'Новосибирск, Улица Каменская д.16', NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (4, N'Corporate Travel', N'+7(495)245-39-05', N'Екатеринбург, Улица Антона Валека д.56', N'Екатеринбург, Улица Антона Валека д.56', NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (5, N'GallaDance', N'+7(495)316-77-94', N'Нижний Новгород, Улица Ларина д. 34', N'Нижний Новгород, Улица Ларина д. 34', NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh3] ([ID Арендатора], [Название ], [Номер], [Адрес], [F5], [F6], [F7]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (1, 2, N'3', 2, N'1', N'1', CAST(N'2019-01-24T00:00:00.000' AS DateTime), CAST(N'2020-11-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (2, 2, N'2', 7, N'2', N'2', CAST(N'2019-11-21T00:00:00.000' AS DateTime), CAST(N'2020-04-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (3, 5, N'4', 11, N'4', N'3', CAST(N'2018-11-12T00:00:00.000' AS DateTime), CAST(N'2019-06-28T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (4, 1, N'10', 2, N'5', N'3', CAST(N'2018-10-18T00:00:00.000' AS DateTime), CAST(N'2019-09-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (5, 5, N'6', 7, N'6', N'2', CAST(N'2019-12-19T00:00:00.000' AS DateTime), CAST(N'2020-06-26T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (6, 2, N'7', 11, N'31', N'2', CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-05-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (7, 4, N'8', 2, N'8', N'2', CAST(N'2019-12-06T00:00:00.000' AS DateTime), CAST(N'2020-10-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (8, 2, N'10', 11, N'9', N'3', CAST(N'2018-09-03T00:00:00.000' AS DateTime), CAST(N'2019-02-10T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (9, 2, N'10', 2, N'10', N'2', CAST(N'2019-11-04T00:00:00.000' AS DateTime), CAST(N'2020-06-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (10, 4, N'11', 7, N'11', N'3', CAST(N'2018-11-08T00:00:00.000' AS DateTime), CAST(N'2019-01-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (11, 1, N'10', 2, N'12', N'1', CAST(N'2019-06-07T00:00:00.000' AS DateTime), CAST(N'2020-03-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (12, 1, N'13', 2, N'13', N'2', CAST(N'2019-11-15T00:00:00.000' AS DateTime), CAST(N'2020-06-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (13, 5, N'14', 11, N'14', N'3', CAST(N'2018-10-09T00:00:00.000' AS DateTime), CAST(N'2019-09-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (14, 5, N'15', 7, N'15', N'2', CAST(N'2019-11-24T00:00:00.000' AS DateTime), CAST(N'2020-07-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (15, 1, N'23', 7, N'16', N'3', CAST(N'2018-07-20T00:00:00.000' AS DateTime), CAST(N'2019-06-07T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (16, 3, N'23', 11, N'17', N'1', CAST(N'2019-02-04T00:00:00.000' AS DateTime), CAST(N'2020-08-06T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (17, 2, N'18', 2, N'18', N'1', CAST(N'2019-08-06T00:00:00.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (18, 1, N'22', 7, N'22', N'1', CAST(N'2019-05-23T00:00:00.000' AS DateTime), CAST(N'2020-05-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (19, 3, N'23', 2, N'23', N'2', CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-03-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (20, 3, N'23', 11, N'24', N'3', CAST(N'2018-08-24T00:00:00.000' AS DateTime), CAST(N'2019-08-04T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (21, 5, N'25', 2, N'25', N'2', CAST(N'2019-11-09T00:00:00.000' AS DateTime), CAST(N'2020-08-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (22, 4, N'15', 7, N'15', N'2', CAST(N'2019-12-02T00:00:00.000' AS DateTime), CAST(N'2020-07-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (23, 2, N'27', 11, N'27', N'2', CAST(N'2019-11-23T00:00:00.000' AS DateTime), CAST(N'2020-08-06T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (24, 4, N'29', 7, N'29', N'1', CAST(N'2019-05-02T00:00:00.000' AS DateTime), CAST(N'2020-06-24T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (25, 3, N'7', 2, N'31', N'2', CAST(N'2019-12-08T00:00:00.000' AS DateTime), CAST(N'2020-08-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (26, 3, N'32', 7, N'32', N'3', CAST(N'2018-11-14T00:00:00.000' AS DateTime), CAST(N'2019-04-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (27, 4, N'33', 11, N'33', N'2', CAST(N'2019-12-26T00:00:00.000' AS DateTime), CAST(N'2020-09-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (28, 1, N'34', 2, N'34', N'3', CAST(N'2018-09-16T00:00:00.000' AS DateTime), CAST(N'2019-02-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (29, 3, N'22', 2, N'36', N'3', CAST(N'2018-10-18T00:00:00.000' AS DateTime), CAST(N'2019-06-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (30, 4, N'22', 2, N'37', N'3', CAST(N'2018-06-23T00:00:00.000' AS DateTime), CAST(N'2019-08-26T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (31, 3, N'38', 11, N'38', N'2', CAST(N'2019-12-18T00:00:00.000' AS DateTime), CAST(N'2020-05-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (32, 5, N'40', 7, N'40', N'1', CAST(N'2019-04-01T00:00:00.000' AS DateTime), CAST(N'2020-12-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (33, 4, N'41', 11, N'41', N'2', CAST(N'2019-11-22T00:00:00.000' AS DateTime), CAST(N'2020-08-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (34, 3, N'42', 11, N'42', N'3', CAST(N'2018-10-08T00:00:00.000' AS DateTime), CAST(N'2019-07-21T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (35, 2, N'48', 2, N'43', N'1', CAST(N'2019-04-07T00:00:00.000' AS DateTime), CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (36, 1, N'44', 7, N'44', N'2', CAST(N'2019-11-07T00:00:00.000' AS DateTime), CAST(N'2020-03-08T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (37, 3, N'48', 2, N'45', N'1', CAST(N'2019-07-15T00:00:00.000' AS DateTime), CAST(N'2020-04-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (38, 1, N'46', 2, N'46', N'2', CAST(N'2021-07-03T00:00:00.000' AS DateTime), CAST(N'2020-12-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (39, 4, N'48', 11, N'47', N'3', CAST(N'2018-08-05T00:00:00.000' AS DateTime), CAST(N'2019-06-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (40, 2, N'49', 11, N'49', N'1', CAST(N'2019-08-19T00:00:00.000' AS DateTime), CAST(N'2020-09-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (41, 4, N'49', 7, N'50', N'3', CAST(N'2018-09-20T00:00:00.000' AS DateTime), CAST(N'2019-02-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sh4] ([ID Аренды], [ID Арендатора], [Название ТЦ], [ID Сотрудник], [№ Павильона], [Статус], [Начало Аренды], [Окончание Аренды], [F9]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (1, N'Ривьера', 1, 0, 1, 8260042.0000, CAST(1 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (2, N'Авиапарк', 2, 9, 2, 3297976.0000, CAST(0 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (3, N'Мега Белая Дача', 3, 16, 3, 9006645.0000, CAST(2 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (4, N'Рио', 4, 5, 4, 1888653.0000, CAST(1 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (5, N'Вегас', 1, 0, 5, 7567411.0000, CAST(0 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (6, N'Лужайка', 2, 10, 6, 4603336.0000, CAST(1 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (7, N'Кунцево Плаза', 2, 8, 7, 6797653.0000, CAST(1 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (8, N'Мозаика', 2, 20, 8, 1429419.0000, CAST(0 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (9, N'Океания', 1, 0, 8, 5192089.0000, CAST(2 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (10, N'Гранд', 2, 20, 9, 2573981.0000, CAST(0 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (11, N'Бутово Молл', 1, 0, 1, 5327641.0000, CAST(2 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (12, N'Рига Молл', 1, 0, 9, 9788316.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (13, N'Шоколад', 2, 12, 7, 2217279.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (14, N'АфиМолл Сити', 4, 9, 2, 8729160.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (15, N'Европейский', 2, 9, 1, 5690500.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (16, N'Гагаринский', 1, 0, 4, 1508807.0000, CAST(2 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (17, N'Метрополис', 1, 0, 2, 8117913.0000, CAST(0 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (18, N'Мега Химки', 4, 3, 5, 3373234.0000, CAST(0 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (19, N'Москва', 4, 12, 1, 4226505.0000, CAST(0 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (20, N'Вегас Кунцево', 4, 12, 1, 3878254.0000, CAST(0 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (21, N'Город Лефортово', 3, 12, 3, 1966214.0000, CAST(2 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (22, N'Золотой Вавилон Ростокино', 4, 16, 4, 1632702.0000, CAST(2 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (23, N'Шереметьевский', 2, 16, 3, 2941379.0000, CAST(1 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (24, N'Ханой-Москва', 1, 0, 8, 9580221.0000, CAST(0 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (25, N'Ашан Сити Капитолий', 2, 4, 4, 5309117.0000, CAST(2 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (26, N'Черемушки', 4, 15, 3, 7344604.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (27, N'Филион', 2, 8, 1, 5343904.0000, CAST(0 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (28, N' Весна', 3, 3, 5, 4687701.0000, CAST(1 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (29, N' Гудзон', 4, 3, 4, 7414460.0000, CAST(0 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (30, N'Калейдоскоп', 4, 10, 3, 7847659.0000, CAST(1 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (31, N'Новомосковский', 1, 0, 6, 7161962.8500, CAST(0 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (32, N'Хорошо', 4, -20, 9, 8306576.0000, CAST(2 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (33, N'Щука', 2, 5, 5, 5428485.0000, CAST(0 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (34, N'Атриум', 4, 4, 6, 5059779.0000, CAST(0 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (35, N'Принц Плаза', 4, 8, 8, 1786688.0000, CAST(2 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (36, N'Облака', 1, 0, 2, 1688905.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (37, N'Три Кита', 1, 0, 6, 3089700.0000, CAST(2 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (38, N'Реутов Парк', 2, 4, 9, 1995904.0000, CAST(2 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (39, N'ЕвроПарк', 3, 20, 3, 9391338.0000, CAST(1 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (40, N'ГУМ', 4, 5, 2, 6731491.0000, CAST(2 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (41, N'Райкин Плаза', 2, 12, 2, 8498470.0000, CAST(2 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (42, N'Новинский пассаж', 4, 8, 4, 3158957.0000, CAST(2 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (43, N'Наш Гипермаркет', 1, 0, 9, 1088735.0000, CAST(1 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (44, N'Красный Кит', 2, 9, 6, 1912149.0000, CAST(1 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (45, N'Мегаполис', 1, 0, 7, 2175218.5000, CAST(1 AS Decimal(18, 0)), 2, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (46, N'Отрада', 2, 4, 2, 6760316.0000, CAST(1 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (47, N'Твой дом', 1, 0, 7, 6810865.0000, CAST(2 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (48, N'Фестиваль', 3, 16, 3, 1828013.0000, CAST(0 AS Decimal(18, 0)), 4, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (49, N'Времена Года', 4, 15, 4, 2650484.0000, CAST(2 AS Decimal(18, 0)), 3, NULL)
INSERT [dbo].[ShoppingCenters] ([CenterId], [Name], [StatusId], [PavilionsQuantity], [CityId], [Cost], [ValueFactor], [FloorsQuantity], [Image]) VALUES (50, N' Армада', 1, 0, 9, 9172489.0000, CAST(1 AS Decimal(18, 0)), 1, NULL)
INSERT [dbo].[ShoppingCentersStatuses] ([StatusId], [Status]) VALUES (1, N'План')
INSERT [dbo].[ShoppingCentersStatuses] ([StatusId], [Status]) VALUES (2, N'Строительство')
INSERT [dbo].[ShoppingCentersStatuses] ([StatusId], [Status]) VALUES (3, N'Удален')
INSERT [dbo].[ShoppingCentersStatuses] ([StatusId], [Status]) VALUES (4, N'Реализация')
INSERT [dbo].[Tenants] ([TenantId], [Name], [Phone], [Adress]) VALUES (1, N'AG Marine', N'+7(495)526-14-53', N'Москва, Бабаевская улица д.16')
INSERT [dbo].[Tenants] ([TenantId], [Name], [Phone], [Adress]) VALUES (2, N'Art-elle', N'+7(495)250-58-94', N'Санкт-Петербург, Амбарная улица д.25 корп.1')
INSERT [dbo].[Tenants] ([TenantId], [Name], [Phone], [Adress]) VALUES (3, N'Atlantis', N'+7(495)424-11-65', N'Новосибирск, Улица Каменская д.16')
INSERT [dbo].[Tenants] ([TenantId], [Name], [Phone], [Adress]) VALUES (4, N'Corporate Travel', N'+7(495)245-39-05', N'Екатеринбург, Улица Антона Валека д.56')
INSERT [dbo].[Tenants] ([TenantId], [Name], [Phone], [Adress]) VALUES (5, N'GallaDance', N'+7(495)316-77-94', N'Нижний Новгород, Улица Ларина д. 34')
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [Employees_EmployeesRoles_FK] FOREIGN KEY([RoleId])
REFERENCES [dbo].[EmployeesRoles] ([RoleId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [Employees_EmployeesRoles_FK]
GO
ALTER TABLE [dbo].[Pavilions]  WITH CHECK ADD  CONSTRAINT [Pavilions_PavilionsStatuses_FK] FOREIGN KEY([StatusId])
REFERENCES [dbo].[PavilionsStatuses] ([StatusId])
GO
ALTER TABLE [dbo].[Pavilions] CHECK CONSTRAINT [Pavilions_PavilionsStatuses_FK]
GO
ALTER TABLE [dbo].[Pavilions]  WITH CHECK ADD  CONSTRAINT [Pavilions_ShoppingCenters_FK] FOREIGN KEY([CenterId])
REFERENCES [dbo].[ShoppingCenters] ([CenterId])
GO
ALTER TABLE [dbo].[Pavilions] CHECK CONSTRAINT [Pavilions_ShoppingCenters_FK]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [Rent_Employees_FK] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [Rent_Employees_FK]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [Rent_Pavilions_FK] FOREIGN KEY([PavilionId])
REFERENCES [dbo].[Pavilions] ([PavilionId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [Rent_Pavilions_FK]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [Rent_RentStatuses_FK] FOREIGN KEY([StatusId])
REFERENCES [dbo].[RentStatuses] ([StatusId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [Rent_RentStatuses_FK]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [Rent_ShoppingCenters_FK] FOREIGN KEY([CenterId])
REFERENCES [dbo].[ShoppingCenters] ([CenterId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [Rent_ShoppingCenters_FK]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [Rent_Tenants_FK] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenants] ([TenantId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [Rent_Tenants_FK]
GO
ALTER TABLE [dbo].[ShoppingCenters]  WITH CHECK ADD  CONSTRAINT [SHoppingCenters_Cities_FK] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[ShoppingCenters] CHECK CONSTRAINT [SHoppingCenters_Cities_FK]
GO
ALTER TABLE [dbo].[ShoppingCenters]  WITH CHECK ADD  CONSTRAINT [ShoppingCenters_ShoppingCentersStatuses_FK] FOREIGN KEY([StatusId])
REFERENCES [dbo].[ShoppingCentersStatuses] ([StatusId])
GO
ALTER TABLE [dbo].[ShoppingCenters] CHECK CONSTRAINT [ShoppingCenters_ShoppingCentersStatuses_FK]
GO
USE [master]
GO
ALTER DATABASE [PavilionsDb] SET  READ_WRITE 
GO
