USE [master]
GO
/****** Object:  Database [NewDb]    Script Date: 03.04.2020 14:02:16 ******/
CREATE DATABASE [NewDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\NewDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\NewDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NewDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NewDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NewDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NewDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NewDb] SET  MULTI_USER 
GO
ALTER DATABASE [NewDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NewDb] SET QUERY_STORE = OFF
GO
USE [NewDb]
GO
/****** Object:  Table [dbo].[AppointmentHistory]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentHistory](
	[OrderId] [int] NOT NULL,
	[StaffId] [int] NULL,
	[датаПриема] [date] NULL,
	[датаУвольнения] [date] NULL,
	[PositionId] [int] NULL,
	[SubdivisionId] [int] NULL,
 CONSTRAINT [PK_AppointmentHistory] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] NOT NULL,
	[PositionName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[SecondName] [nvarchar](255) NOT NULL,
	[Gender] [nvarchar](1) NULL,
	[DateOfBirth] [nvarchar](50) NOT NULL,
	[EducationLevel] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NOT NULL,
	[Status] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffCount]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffCount](
	[PositionId] [int] NOT NULL,
	[SubdivisionId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_StaffCount] PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC,
	[SubdivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subdivision]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subdivision](
	[SubdivisionId] [int] NOT NULL,
	[SubdivisionName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Subdivision] PRIMARY KEY CLUSTERED 
(
	[SubdivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (165, 3, CAST(N'2005-12-01' AS Date), NULL, 51, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (325, 13, CAST(N'2007-11-26' AS Date), NULL, 11, 1)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (378, 14, CAST(N'2003-02-17' AS Date), NULL, 12, 1)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (396, 9, CAST(N'2002-01-01' AS Date), NULL, 34, 3)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (704, 11, CAST(N'2002-03-10' AS Date), NULL, 52, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (768, 12, CAST(N'2007-11-26' AS Date), NULL, 51, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (774, 18, CAST(N'2003-02-18' AS Date), CAST(N'2019-02-19' AS Date), 24, 2)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (817, 19, CAST(N'2003-02-18' AS Date), NULL, 23, 2)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (860, 20, CAST(N'2003-02-19' AS Date), NULL, 22, 2)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (928, 16, CAST(N'2003-02-17' AS Date), NULL, 41, 4)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (1005, 15, CAST(N'2003-02-17' AS Date), NULL, 51, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (1173, 17, CAST(N'2003-02-18' AS Date), NULL, 51, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (1533, 21, CAST(N'2008-01-19' AS Date), NULL, 51, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (1725, 23, CAST(N'2005-11-05' AS Date), CAST(N'2019-11-05' AS Date), 51, 5)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (1789, 24, NULL, NULL, 13, 1)
INSERT [dbo].[AppointmentHistory] ([OrderId], [StaffId], [датаПриема], [датаУвольнения], [PositionId], [SubdivisionId]) VALUES (1853, 25, NULL, NULL, 15, 1)
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (11, N'директор            ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (12, N'зам дир по уч работе')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (13, N'зам дир по УПР')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (14, N'зам дир по вос  раб ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (15, N'заведующий факультет')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (21, N'Гл бух              ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (22, N'Ст бух              ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (23, N'Бух                 ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (24, N'Кассир              ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (31, N'Нач отд кадров      ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (32, N'ст инспектор        ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (33, N'Инструктор ВУС      ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (34, N'Архивариус          ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (35, N'Делопроизводитель   ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (36, N'Машинистка')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (37, N'Секретарь-референт  ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (41, N'Завуч               ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (42, N'Секретарь')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (51, N'Основной препод     ')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (52, N'Совместитель        ')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (1, N'Ярослав', N'Фуфаев', N'Станиславович', N'м', N'1990-03-01', N'высшее', N'3955889', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (3, N'Дмитрий', N'Нагаев', N'Иванович', N'м', N'1985-09-20', N'высшее', N'4231112', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (9, N'Галина', N'Дубова', N'Ивановна', N'ж', N'1960-02-14', N'высшее', N'3465789', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (11, N'Ольга', N'Семенова', N'Евгеньевна', N'ж', N'1960-06-12', N'средее', N'2357890', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (12, N'Павел', N'Сидоров', N'Петрович', N'м', N'1960-02-07', N'высшее', N'2346578', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (13, N'Аким', N'Акимов', N'Акимович', N'м', N'1960-02-17', N'высшее', N'2354678', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (14, N'Василий', N'Пронин', N'Вадимович', N'м', N'1975-07-20', N'среднее', N'5358946', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (15, N'Евгений', N'Овдиенко', N'Павлович', N'м', N'1980-02-02', N'среднее', N'4387298', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (16, N'Евгений', N'Бабичев', N'Иванович', N'м', N'1960-06-12', N'средее', N'2356789', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (17, N'Василий', N'Кузнецов', N'Петрович', N'м', N'1950-01-01', N'высшее', N'3230000', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (18, N'Петр', N'Петров', N'Петрович', N'м', N'1982-01-02', N'высшее', N'3230326', N'уволен')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (19, N'Петр', N'Петренко', N'Иванович', N'м', N'1982-01-02', N'высшее', N'3230326', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (20, N'Иван', N'Петренко', N'Иванович', N'м', N'1982-01-02', N'высшее', N'3230326', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (21, N'Александр', N'Ильенко', N'Иванович', N'м', N'1982-01-02', N'высшее', N'3230326', N'работает')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (23, N'Дмитрий', N'Ильенко', N'Иванович', N'м', N'1982-01-02', N'высшее', N'3230326', N'уволен')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (24, N'Nikita', N'Alexashenkov', N'Petrovich', N'м', N'2020-03-21', N'Average', N'88005553535', N'рассматривается')
INSERT [dbo].[Staff] ([StaffId], [Name], [LastName], [SecondName], [Gender], [DateOfBirth], [EducationLevel], [PhoneNumber], [Status]) VALUES (25, N'Иван', N'Петров', N'Иванович', N'м', N'2020-03-22', N'Среднее профессиональное', N'89192463467', N'рассматривается')
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (11, 1, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (12, 1, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (13, 1, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (14, 1, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (15, 1, 4)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (21, 2, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (22, 2, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (23, 2, 3)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (24, 2, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (31, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (32, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (33, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (34, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (35, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (36, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (37, 3, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (41, 4, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (42, 4, 1)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (51, 5, 37)
INSERT [dbo].[StaffCount] ([PositionId], [SubdivisionId], [Quantity]) VALUES (52, 5, 19)
INSERT [dbo].[Subdivision] ([SubdivisionId], [SubdivisionName]) VALUES (1, N'Административно-управленческий персонал')
INSERT [dbo].[Subdivision] ([SubdivisionId], [SubdivisionName]) VALUES (2, N'Бухгалтерия')
INSERT [dbo].[Subdivision] ([SubdivisionId], [SubdivisionName]) VALUES (3, N'Отдел кадров')
INSERT [dbo].[Subdivision] ([SubdivisionId], [SubdivisionName]) VALUES (4, N'Учебная часть')
INSERT [dbo].[Subdivision] ([SubdivisionId], [SubdivisionName]) VALUES (5, N'Штат преподавателей')
ALTER TABLE [dbo].[AppointmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentHistory_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[AppointmentHistory] CHECK CONSTRAINT [FK_AppointmentHistory_Position]
GO
ALTER TABLE [dbo].[AppointmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentHistory_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[AppointmentHistory] CHECK CONSTRAINT [FK_AppointmentHistory_Staff]
GO
ALTER TABLE [dbo].[AppointmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentHistory_Subdivision] FOREIGN KEY([SubdivisionId])
REFERENCES [dbo].[Subdivision] ([SubdivisionId])
GO
ALTER TABLE [dbo].[AppointmentHistory] CHECK CONSTRAINT [FK_AppointmentHistory_Subdivision]
GO
ALTER TABLE [dbo].[StaffCount]  WITH CHECK ADD  CONSTRAINT [FK_StaffCount_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[StaffCount] CHECK CONSTRAINT [FK_StaffCount_Position]
GO
ALTER TABLE [dbo].[StaffCount]  WITH CHECK ADD  CONSTRAINT [FK_StaffCount_Subdivision] FOREIGN KEY([SubdivisionId])
REFERENCES [dbo].[Subdivision] ([SubdivisionId])
GO
ALTER TABLE [dbo].[StaffCount] CHECK CONSTRAINT [FK_StaffCount_Subdivision]
GO
/****** Object:  StoredProcedure [dbo].[AddCandidate]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[AddCandidate](
  @staffId as int,
  @name as nvarchar(40),
  @lName as nvarchar(40),
  @sName as nvarchar(40),
  @gender as nvarchar(1),
  @dateOfBirth as date,
  @edLevel as nvarchar(60),
  @phoneNum as nvarchar(13),
  @subId as int,
  @posId as int)
  as
  begin tran
  insert into Staff
  values(
	@staffId,
	@name,
	@lName,
	@sName,
	@gender,
	@dateOfBirth,
	@edLevel,
	@phoneNum,
	'рассматривается')

  insert into AppointmentHistory(OrderId, StaffId, PositionId, SubdivisionId)
  values(
	(select MAX(OrderId) + 64
	from AppointmentHistory),
	@staffId,
	@posId,
	@subId)
	
	if @posId < 0 and @subId < 0
	rollback
	else
	commit
GO
/****** Object:  StoredProcedure [dbo].[AppointCandidate]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[AppointCandidate](
  @staffId as int)
  as
  begin tran
  if not exists(select StaffId from Staff where StaffId = @staffId)
	rollback
  else
	update AppointmentHistory
	set датаПриема = GETDATE()
	where StaffId = @staffId
	commit
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllForOne]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[DeleteAllForOne](
  @num as int,
  @logical as int)
  as
  begin tran
  delete 
  from AppointmentHistory
  where Staffid =  @num
  if @logical = 0
  rollback
  else
  commit
  select *
  from AppointmentHistory
GO
/****** Object:  StoredProcedure [dbo].[FindVacancies]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[FindVacancies]
  as
  begin
  select Subdivision.SubdivisionName, Position.PositionName, StaffCount.Quantity - Count(AppointmentHistory.StaffId) as 'Free'
  from AppointmentHistory inner join Staff
  on AppointmentHistory.StaffId = Staff.StaffId
  right join StaffCount
  on StaffCount.PositionId = AppointmentHistory.PositionId
  inner join Position
  on Position.PositionId = StaffCount.PositionId
   inner join Subdivision
  on Subdivision.SubdivisionId = StaffCount.SubdivisionId
  group by StaffCount.PositionId, StaffCount.SubdivisionId, StaffCount.Quantity, Subdivision.SubdivisionName, Position.PositionName
  having StaffCount.Quantity - Count(AppointmentHistory.StaffId) > 0
  end
GO
/****** Object:  StoredProcedure [dbo].[GetCandidates]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[GetCandidates]
  as
  begin
  select Staff.StaffId, LastName, [Name], SecondName, Gender, DateOfBirth, EducationLevel, PhoneNumber, SubdivisionName, PositionName
  from Staff inner join AppointmentHistory
  on Staff.StaffId = AppointmentHistory.StaffId
  inner join Subdivision
  on AppointmentHistory.SubdivisionId = Subdivision.SubdivisionId
  inner join Position
  on AppointmentHistory.PositionId = Position.PositionId
  where AppointmentHistory.датаПриема is null
  end
GO
/****** Object:  StoredProcedure [dbo].[GetPositionId]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[GetPositionId](
  @posName as nvarchar(40))
  as
  begin
	select PositionId
	from Position
	where PositionName = @posName
  end
GO
/****** Object:  StoredProcedure [dbo].[GetSubdivisionId]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[GetSubdivisionId](
  @subName as nvarchar(40))
  as
  begin
	select SubdivisionId
	from Subdivision
	where SubdivisionName = @subName
  end
GO
/****** Object:  StoredProcedure [dbo].[SelectStaffByNames]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SelectStaffByNames]
@subdiv nvarchar(30),
@pos nvarchar(30)
as
begin
	select [Name], LastName, SecondName
	from Staff inner join AppointmentHistory
	on Staff.StaffId = AppointmentHistory.StaffId
	inner join Position on Position.PositionId = AppointmentHistory.PositionId
	inner join Subdivision on Subdivision.SubdivisionId = AppointmentHistory.SubdivisionId
	where PositionName = @pos
	and SubdivisionName = @subdiv
	and [Status] = 'работает'
end
GO
/****** Object:  StoredProcedure [dbo].[SelectStaffByNums]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectStaffByNums]
@subdivId int,
@posId int
as
begin
	select [Name], LastName, SecondName
	from Staff inner join AppointmentHistory
	on Staff.StaffId = AppointmentHistory.StaffId
	where [Status] = 'работает' 
	and PositionId = @posId
	and SubdivisionId = @subdivId
end
GO
/****** Object:  StoredProcedure [dbo].[SelectSubdivision]    Script Date: 03.04.2020 14:02:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SelectSubdivision]
@staffQt int
as
begin
	select Subdivision.SubdivisionName 
	from Subdivision inner join StaffCount
	on Subdivision.SubdivisionId = StaffCount.SubdivisionId
	group by StaffCount.SubdivisionId, Subdivision.SubdivisionName
	having SUM(StaffCount.Quantity) = @staffQt
end
GO
USE [master]
GO
ALTER DATABASE [NewDb] SET  READ_WRITE 
GO
