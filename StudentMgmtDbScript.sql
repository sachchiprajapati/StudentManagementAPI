USE [master]
GO
/****** Object:  Database [StudentSystem]    Script Date: 8/4/2023 8:00:02 PM ******/
CREATE DATABASE [StudentSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\StudentSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\StudentSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StudentSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentSystem] SET  MULTI_USER 
GO
ALTER DATABASE [StudentSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentSystem] SET QUERY_STORE = OFF
GO
USE [StudentSystem]
GO
/****** Object:  Table [dbo].[tblAPIVersion]    Script Date: 8/4/2023 8:00:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAPIVersion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[APIVersion] [int] NULL,
 CONSTRAINT [PK_tblAPIVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStandard]    Script Date: 8/4/2023 8:00:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStandard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Standard] [varchar](100) NULL,
 CONSTRAINT [PK_tblStandard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 8/4/2023 8:00:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [int] NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[BirthDate] [date] NULL,
	[Gender] [varchar](30) NULL,
	[Standard] [int] NULL,
	[Address] [varchar](1000) NULL,
	[Photo] [varchar](100) NULL,
	[FatherOccupation] [varchar](100) NULL,
	[MotherOcuupation] [varchar](100) NULL,
	[ContactNo] [varchar](30) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserType]    Script Date: 8/4/2023 8:00:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](100) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblAPIVersion] ON 
GO
INSERT [dbo].[tblAPIVersion] ([Id], [APIVersion]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[tblAPIVersion] OFF
GO
SET IDENTITY_INSERT [dbo].[tblStandard] ON 
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (1, N'First')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (2, N'Second')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (3, N'Third')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (4, N'Fourth')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (5, N'Fifth')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (6, N'Sixth')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (7, N'Seventh')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (8, N'Eighth')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (9, N'Ninth')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (10, N'Tenth')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (11, N'Eleventh')
GO
INSERT [dbo].[tblStandard] ([Id], [Standard]) VALUES (12, N'Twelvth')
GO
SET IDENTITY_INSERT [dbo].[tblStandard] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUsers] ON 
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, N'admin@gmail.com', N'admin', N'Anil', N'Test', N'Prajapati', NULL, N'Male', NULL, NULL, N'admin.jpg', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, 2, N'principal@gmail.com', N'principal', N'Sachchi', N'Dipakbhai', N'Prajapati', NULL, N'Female', NULL, NULL, N'principal.jpg', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, 3, N'teacher1@gmail.com', N'teacher1', N'Teacher1', N'Ashokbhai', N'Patel', CAST(N'1990-11-29' AS Date), N'Male', 5, N'Ahmedabad', N'teacher1.jpg', NULL, NULL, N'1234567896', 0, 2, NULL, NULL, NULL)
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (14, 4, NULL, NULL, N'Sachchi', N'Dipakbhai', N'Prajapati', CAST(N'1992-10-09' AS Date), N'Female', 6, N'Ahmedabad', N'fc67ef79-9c3d-40c2-b767-4b2b281f6c60_236.jpg', N'Businessman', N'Housewife', N'1236547896', 0, 3, CAST(N'2022-11-28T10:59:58.963' AS DateTime), 2, CAST(N'2023-01-13T17:12:00.530' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (15, 4, NULL, NULL, N'Dhaval', N'Hardikbhai', N'Parmar', CAST(N'2022-11-22' AS Date), N'Male', 1, N'Chandkheda', N'3b79951d-4b3a-4639-baef-ca00d5456ee1_123.jpg', N'Business', N'Job', N'4556212356', 0, 3, CAST(N'2022-11-28T15:16:05.290' AS DateTime), 2, CAST(N'2023-03-02T17:23:58.160' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (16, 4, NULL, NULL, N'Anil', N'Laxmanbhai', N'Prajapati', CAST(N'1990-11-03' AS Date), N'Male', 12, N'Bangalore', N'c313f808-ffc6-4ee8-bab4-6a67d2d967c9_images2.jpg', N'Business', N'Job', N'5489561265', 0, 3, CAST(N'2022-11-28T15:38:18.493' AS DateTime), 2, CAST(N'2023-03-02T17:22:30.140' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (17, 4, NULL, NULL, N'Nishita', N'Rameshbhai', N'Soni', CAST(N'2022-11-22' AS Date), N'Female', 4, N'Jamnagar', N'40a6da67-b619-47e8-8b16-8a7a4d026688_236.jpg', N'Job', N'Housewife', N'1256875621', 0, 3, CAST(N'2022-11-28T16:18:12.957' AS DateTime), 3, CAST(N'2022-11-30T11:07:57.133' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (19, 4, NULL, NULL, N'Nirali', N'Rohitbhai', N'Gohil', CAST(N'2022-11-23' AS Date), N'Female', 11, N'India', N'050d5473-647e-45ce-ad11-d93de123e824_236.jpg', N'Job', N'Job', N'1236547864', 0, 3, CAST(N'2022-11-28T17:37:24.227' AS DateTime), 2, CAST(N'2023-03-02T17:24:31.477' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (20, 4, NULL, NULL, N'Jimmy', N'Chiragbhai', N'Prajapati', CAST(N'2002-11-23' AS Date), N'Male', 2, N'Naroda', N'bc67fbc6-4603-4672-ac11-d8b43678868d_123.jpg', N'business', N'business', N'5421568756', 0, 3, CAST(N'2022-11-28T17:43:51.367' AS DateTime), 3, CAST(N'2022-11-30T11:08:10.810' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (21, 4, NULL, NULL, N'Mansi', N'Pareshbhai', N'Shah', CAST(N'2022-11-23' AS Date), N'Female', 4, N'dgdf', N'1cfc7b81-bca1-4568-ad7b-a612563b14d8_236.jpg', N'dfgdg', N'dg', N'1236547864', 0, 3, CAST(N'2022-11-29T11:18:09.043' AS DateTime), 2, CAST(N'2022-11-30T13:05:31.973' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (22, 4, NULL, NULL, N'AAAA', N'BBBB', N'CCCC', CAST(N'2002-11-23' AS Date), N'Male', 1, N'Ladakh', N'395f18e2-6e8e-4b32-b9cd-1c07cd2c09d5_123.jpg', N'Job', N'Job', N'1236547864', 0, 3, CAST(N'2022-11-29T11:18:45.010' AS DateTime), 3, CAST(N'2022-12-13T11:57:39.277' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (23, 4, NULL, NULL, N'Ankita', N'Bhaveshbhai', N'Dave', CAST(N'2022-11-23' AS Date), N'Female', 4, N'dgdf', N'584002cd-4e85-4736-a341-07ed621f010f_236.jpg', N'dfgdg', N'dg', N'1236547864', 0, 0, CAST(N'2022-11-29T11:25:38.177' AS DateTime), 2, CAST(N'2023-03-02T17:25:02.310' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (24, 4, NULL, NULL, N'Krishna', N'MaheshBhai', N'Dubey', CAST(N'2022-11-23' AS Date), N'Female', 4, N'dgdf', N'd33de62b-5b3c-49e2-bfee-c4743c0ed6aa_236.jpg', N'dfgdg', N'dg', N'1236547864', 0, 0, CAST(N'2022-11-29T11:30:25.313' AS DateTime), 2, CAST(N'2023-03-02T17:26:56.603' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (25, 3, N'rahul@gmail.com', N'rahul', N'Rahul', N'Dipakbhai', N'Prajapati', CAST(N'1994-07-18' AS Date), N'Male', 5, N'Ahmedabad', N'8e56f751-9409-4234-aebd-cf9c83f8c34e_123.jpg', NULL, NULL, N'2165875621', 0, 2, CAST(N'2022-11-30T12:34:02.800' AS DateTime), 2, CAST(N'2022-11-30T13:05:18.283' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (26, 3, N'krishti@gmail.com', N'krishti', N'Krishti', N'Pareshbhai', N'Patel', CAST(N'2002-11-23' AS Date), N'Female', 8, N'Jodhpur', N'077a1d18-8ec4-4fae-8564-b72499867f00_236.jpg', NULL, NULL, N'2156872354', 0, 2, CAST(N'2022-11-30T13:07:07.387' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (27, 4, NULL, NULL, N'Vaibhavi', N'Dineshbhai', N'Patel', CAST(N'1994-01-18' AS Date), N'Female', 12, N'Surat', N'e8814322-e6ee-440c-9f55-bd2eacbb72ce_236.jpg', N'Business', N'Job', N'2123565487', 0, 2, CAST(N'2022-11-30T15:17:23.490' AS DateTime), 2, CAST(N'2022-12-16T11:52:01.013' AS DateTime))
GO
INSERT [dbo].[tblUsers] ([Id], [UserType], [Email], [Password], [FirstName], [MiddleName], [LastName], [BirthDate], [Gender], [Standard], [Address], [Photo], [FatherOccupation], [MotherOcuupation], [ContactNo], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (28, 3, N'vishal@gmail.com', N'vishal', N'Vishal', N'Kiritbhai', N'Shah', CAST(N'1994-10-09' AS Date), N'Male', 2, N'Bhavnagar', N'29e2a9e5-f9bf-43cb-8227-0d15851c5608_123.jpg', NULL, NULL, N'8756215623', 0, 2, CAST(N'2022-11-30T15:18:44.720' AS DateTime), 2, CAST(N'2022-12-16T12:25:42.707' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUserType] ON 
GO
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (1, N'Admin')
GO
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (2, N'Principal')
GO
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (3, N'Teacher')
GO
INSERT [dbo].[tblUserType] ([Id], [UserType]) VALUES (4, N'Student')
GO
SET IDENTITY_INSERT [dbo].[tblUserType] OFF
GO
ALTER TABLE [dbo].[tblUsers] ADD  CONSTRAINT [DF_tblUsers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblStandard] FOREIGN KEY([Standard])
REFERENCES [dbo].[tblStandard] ([Id])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblStandard]
GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblUserType] FOREIGN KEY([UserType])
REFERENCES [dbo].[tblUserType] ([Id])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblUserType]
GO
USE [master]
GO
ALTER DATABASE [StudentSystem] SET  READ_WRITE 
GO
