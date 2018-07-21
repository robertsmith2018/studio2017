USE [master]
GO
/****** Object:  Database [db_school]    Script Date: 2018-07-21 11:11:32 ******/
CREATE DATABASE [db_school]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_school', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\db_school.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_school_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\db_school_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_school] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_school].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_school] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_school] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_school] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_school] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_school] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_school] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_school] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_school] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_school] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_school] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_school] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_school] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_school] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_school] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_school] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_school] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_school] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_school] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_school] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_school] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_school] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [db_school] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_school] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_school] SET  MULTI_USER 
GO
ALTER DATABASE [db_school] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_school] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_school] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_school] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_school] SET DELAYED_DURABILITY = DISABLED 
GO
USE [db_school]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2018-07-21 11:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Credits] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 2018-07-21 11:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [nvarchar](450) NULL,
	[StudentID] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 2018-07-21 11:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstMidName] [nvarchar](max) NULL,
	[EnrollmentDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Enrollment_CourseID]    Script Date: 2018-07-21 11:11:32 ******/
CREATE NONCLUSTERED INDEX [IX_Enrollment_CourseID] ON [dbo].[Enrollment]
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollment_StudentID]    Script Date: 2018-07-21 11:11:32 ******/
CREATE NONCLUSTERED INDEX [IX_Enrollment_StudentID] ON [dbo].[Enrollment]
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Course_CourseID]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Student_StudentID]
GO
USE [master]
GO
ALTER DATABASE [db_school] SET  READ_WRITE 
GO
