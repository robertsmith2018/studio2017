USE [master]
GO
/****** Object:  Database [dbcgodin]    Script Date: 2018-07-21 11:15:30 ******/
CREATE DATABASE [dbcgodin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbcgodin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbcgodin.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbcgodin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbcgodin_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbcgodin] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbcgodin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbcgodin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbcgodin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbcgodin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbcgodin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbcgodin] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbcgodin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbcgodin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbcgodin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbcgodin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbcgodin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbcgodin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbcgodin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbcgodin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbcgodin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbcgodin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbcgodin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbcgodin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbcgodin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbcgodin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbcgodin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbcgodin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbcgodin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbcgodin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbcgodin] SET  MULTI_USER 
GO
ALTER DATABASE [dbcgodin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbcgodin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbcgodin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbcgodin] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbcgodin] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbcgodin]
GO
/****** Object:  User [etudiant]    Script Date: 2018-07-21 11:15:30 ******/
CREATE USER [etudiant] FOR LOGIN [etudiant] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [etudiant]
GO
/****** Object:  Table [dbo].[tbl_customers]    Script Date: 2018-07-21 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nchar](50) NULL,
	[Country] [nchar](10) NULL,
	[CreationDate] [date] NULL,
 CONSTRAINT [PK_tbl_customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_orders]    Script Date: 2018-07-21 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [date] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_tbl_orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_students]    Script Date: 2018-07-21 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[notefinale] [decimal](4, 2) NULL,
 CONSTRAINT [PK_tbl_students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[orders_customers_Views]    Script Date: 2018-07-21 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[orders_customers_Views]
AS
SELECT        dbo.tbl_orders.OrderID, dbo.tbl_orders.CustomerID, dbo.tbl_orders.OrderDate, dbo.tbl_customers.CustomerName, dbo.tbl_customers.Country, 
                         dbo.tbl_orders.Amount
FROM            dbo.tbl_customers INNER JOIN
                         dbo.tbl_orders ON dbo.tbl_customers.CustomerID = dbo.tbl_orders.CustomerID

GO
ALTER TABLE [dbo].[tbl_orders]  WITH CHECK ADD  CONSTRAINT [FK_tbl_orders_tbl_customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tbl_customers] ([CustomerID])
GO
ALTER TABLE [dbo].[tbl_orders] CHECK CONSTRAINT [FK_tbl_orders_tbl_customers]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_all_customers]    Script Date: 2018-07-21 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_get_all_customers]
AS
BEGIN
 select * from tbl_customers
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_new_customers]    Script Date: 2018-07-21 11:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_new_customers]
AS
BEGIN
	DECLARE @currentDate as date
	SET @currentDate = GETDATE()

	SELECT * 
	FROM tbl_customers c
	WHERE (SELECT DATEDIFF(day,  c.CreationDate, @currentDate)) <= 365 
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_customers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_orders"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 135
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'orders_customers_Views'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'orders_customers_Views'
GO
USE [master]
GO
ALTER DATABASE [dbcgodin] SET  READ_WRITE 
GO
