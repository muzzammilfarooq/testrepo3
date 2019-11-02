USE [master]
GO
/****** Object:  Database [SlotPOS]    Script Date: 12/08/2016 21:48:15 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SlotPOS')
BEGIN
CREATE DATABASE [SlotPOS] ON  PRIMARY 
( NAME = N'SlotPOS', FILENAME = N'D:\SQL CURRENT DIRECTORY\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SlotPOS.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SlotPOS_log', FILENAME = N'D:\SQL CURRENT DIRECTORY\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SlotPOS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [SlotPOS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SlotPOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SlotPOS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SlotPOS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SlotPOS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SlotPOS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SlotPOS] SET ARITHABORT OFF
GO
ALTER DATABASE [SlotPOS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SlotPOS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SlotPOS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SlotPOS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SlotPOS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SlotPOS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SlotPOS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SlotPOS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SlotPOS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SlotPOS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SlotPOS] SET  DISABLE_BROKER
GO
ALTER DATABASE [SlotPOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SlotPOS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SlotPOS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SlotPOS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SlotPOS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SlotPOS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SlotPOS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SlotPOS] SET  READ_WRITE
GO
ALTER DATABASE [SlotPOS] SET RECOVERY FULL
GO
ALTER DATABASE [SlotPOS] SET  MULTI_USER
GO
ALTER DATABASE [SlotPOS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SlotPOS] SET DB_CHAINING OFF
GO
USE [SlotPOS]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailyActivityEventFooterReport]    Script Date: 12/08/2016 21:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDailyActivityEventFooterReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetDailyActivityEventFooterReport]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailyActivityFooterReport]    Script Date: 12/08/2016 21:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDailyActivityFooterReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetDailyActivityFooterReport]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailyActivityReport]    Script Date: 12/08/2016 21:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDailyActivityReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_GetDailyActivityReport]
GO
/****** Object:  StoredProcedure [dbo].[sp_getNoOfEventFooterReport]    Script Date: 12/08/2016 21:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNoOfEventFooterReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_getNoOfEventFooterReport]
GO
/****** Object:  StoredProcedure [dbo].[sp_getPrintBill]    Script Date: 12/08/2016 21:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getPrintBill]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_getPrintBill]
GO
/****** Object:  StoredProcedure [dbo].[sp_getSaleByPaymentMethodReport]    Script Date: 12/08/2016 21:48:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getSaleByPaymentMethodReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_getSaleByPaymentMethodReport]
GO
/****** Object:  Table [dbo].[tblCounter]    Script Date: 12/08/2016 21:48:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCounter]') AND type in (N'U'))
DROP TABLE [dbo].[tblCounter]
GO
/****** Object:  Table [dbo].[tblEvent]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEvent]') AND type in (N'U'))
DROP TABLE [dbo].[tblEvent]
GO
/****** Object:  Table [dbo].[tblEventDetail]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEventDetail]') AND type in (N'U'))
DROP TABLE [dbo].[tblEventDetail]
GO
/****** Object:  Table [dbo].[tblItem]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblItem]') AND type in (N'U'))
DROP TABLE [dbo].[tblItem]
GO
/****** Object:  Table [dbo].[tblItemCategory]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblItemCategory]') AND type in (N'U'))
DROP TABLE [dbo].[tblItemCategory]
GO
/****** Object:  Table [dbo].[tblLotSetup]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLotSetup]') AND type in (N'U'))
DROP TABLE [dbo].[tblLotSetup]
GO
/****** Object:  Table [dbo].[tblOpeningClosing]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblOpeningClosing]') AND type in (N'U'))
DROP TABLE [dbo].[tblOpeningClosing]
GO
/****** Object:  Table [dbo].[tblPOS]    Script Date: 12/08/2016 21:48:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPOS]') AND type in (N'U'))
DROP TABLE [dbo].[tblPOS]
GO
/****** Object:  Table [dbo].[tblPOSDetail]    Script Date: 12/08/2016 21:48:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPOSDetail]') AND type in (N'U'))
DROP TABLE [dbo].[tblPOSDetail]
GO
/****** Object:  Table [dbo].[tblSlot]    Script Date: 12/08/2016 21:48:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSlot]') AND type in (N'U'))
DROP TABLE [dbo].[tblSlot]
GO
/****** Object:  Table [dbo].[tblTicketIssue]    Script Date: 12/08/2016 21:48:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTicketIssue]') AND type in (N'U'))
DROP TABLE [dbo].[tblTicketIssue]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 12/08/2016 21:48:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
DROP TABLE [dbo].[tblUser]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 12/08/2016 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblUser](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[CounterID] [bigint] NULL,
	[Username] [nvarchar](150) NULL,
	[UserPassword] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[InsertedDate] [datetime] NULL,
	[UserSetup] [bit] NULL,
	[ItemCategorySetup] [bit] NULL,
	[ItemSetup] [bit] NULL,
	[LOTSetup] [bit] NULL,
	[TicketIssuance] [bit] NULL,
	[PointOfSale] [bit] NULL,
	[SlotScreen] [bit] NULL,
	[EventSetup] [bit] NULL,
	[EventTransaction] [bit] NULL,
	[Reports] [bit] NULL,
	[IsPrint] [bit] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON
INSERT [dbo].[tblUser] ([UserID], [CounterID], [Username], [UserPassword], [IsActive], [InsertedDate], [UserSetup], [ItemCategorySetup], [ItemSetup], [LOTSetup], [TicketIssuance], [PointOfSale], [SlotScreen], [EventSetup], [EventTransaction], [Reports], [IsPrint]) VALUES (1, 1, N'manager', N'beegees', 1, CAST(0x0000A6D600000000 AS DateTime), 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[tblUser] ([UserID], [CounterID], [Username], [UserPassword], [IsActive], [InsertedDate], [UserSetup], [ItemCategorySetup], [ItemSetup], [LOTSetup], [TicketIssuance], [PointOfSale], [SlotScreen], [EventSetup], [EventTransaction], [Reports], [IsPrint]) VALUES (2, 2, N'counter1', N'c12345', 1, CAST(0x0000A6D600000000 AS DateTime), 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0)
INSERT [dbo].[tblUser] ([UserID], [CounterID], [Username], [UserPassword], [IsActive], [InsertedDate], [UserSetup], [ItemCategorySetup], [ItemSetup], [LOTSetup], [TicketIssuance], [PointOfSale], [SlotScreen], [EventSetup], [EventTransaction], [Reports], [IsPrint]) VALUES (3, 3, N'slotScreen', N'sc12345', 1, CAST(0x0000A6D600000000 AS DateTime), 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[tblUser] OFF
/****** Object:  Table [dbo].[tblTicketIssue]    Script Date: 12/08/2016 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblTicketIssue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblTicketIssue](
	[TicketIssueID] [bigint] IDENTITY(1,1) NOT NULL,
	[IssueDate] [date] NULL,
	[LOTID] [bigint] NULL,
	[CategoryID] [bigint] NULL,
	[FromTicket] [bigint] NULL,
	[ToTicket] [bigint] NULL,
	[BalanceTicket] [bigint] NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblTicketIssue] PRIMARY KEY CLUSTERED 
(
	[TicketIssueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblSlot]    Script Date: 12/08/2016 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSlot]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblSlot](
	[SlotSetupID] [bigint] IDENTITY(1,1) NOT NULL,
	[SlotNo] [nvarchar](50) NULL,
	[ItemCategoryID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[Status] [nvarchar](50) NULL,
	[FromTime] [time](7) NULL,
	[ToTime] [time](7) NULL,
 CONSTRAINT [PK_tblSlot] PRIMARY KEY CLUSTERED 
(
	[SlotSetupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblSlot] ON
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (1, N'SLOT 1', 1, 1, N'Done', CAST(0x070048F9F66C0000 AS Time), CAST(0x0700964C40730000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (2, N'SLOT 2', 1, 2, N'Done', CAST(0x0700F41CF3730000 AS Time), CAST(0x070042703C7A0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (3, N'SLOT 3', 1, 3, N'Done', CAST(0x0700A040EF7A0000 AS Time), CAST(0x0700EE9338810000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (4, N'SLOT 4', 1, 4, N'Done', CAST(0x07004C64EB810000 AS Time), CAST(0x07009AB734880000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (5, N'SLOT 5', 1, 5, N'Done', CAST(0x0700F887E7880000 AS Time), CAST(0x070046DB308F0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (6, N'SLOT 6', 1, 6, N'Done', CAST(0x0700A4ABE38F0000 AS Time), CAST(0x0700F2FE2C960000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (7, N'SLOT 7', 1, 7, N'Done', CAST(0x070050CFDF960000 AS Time), CAST(0x07009E22299D0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (8, N'SLOT 8', 1, 8, N'Done', CAST(0x0700FCF2DB9D0000 AS Time), CAST(0x07004A4625A40000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (9, N'SLOT 9', 1, 9, N'Done', CAST(0x0700A816D8A40000 AS Time), CAST(0x0700F66921AB0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (10, N'SLOT 10', 1, 10, NULL, CAST(0x0700543AD4AB0000 AS Time), CAST(0x0700A28D1DB20000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (11, N'SLOT 11', 1, 11, N'Reserved', CAST(0x0700005ED0B20000 AS Time), CAST(0x07004EB119B90000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (12, N'SLOT 12', 1, 12, NULL, CAST(0x0700AC81CCB90000 AS Time), CAST(0x0700FAD415C00000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (13, N'SLOT 1', 2, 13, N'Done', CAST(0x0700E03495640000 AS Time), CAST(0x07002E88DE6A0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (14, N'SLOT 2', 2, 14, N'Done', CAST(0x07008C58916B0000 AS Time), CAST(0x0700DAABDA710000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (15, N'SLOT 3', 2, 15, N'Done', CAST(0x0700387C8D720000 AS Time), CAST(0x070086CFD6780000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (16, N'SLOT 4', 2, 16, N'Done', CAST(0x0700E49F89790000 AS Time), CAST(0x070032F3D27F0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (17, N'SLOT 5', 2, 17, N'Done', CAST(0x070090C385800000 AS Time), CAST(0x0700DE16CF860000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (18, N'SLOT 6', 2, 18, N'Done', CAST(0x07003CE781870000 AS Time), CAST(0x07008A3ACB8D0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (19, N'SLOT 7', 2, 19, N'Done', CAST(0x0700E80A7E8E0000 AS Time), CAST(0x0700365EC7940000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (20, N'SLOT 8', 2, 20, N'Done', CAST(0x0700942E7A950000 AS Time), CAST(0x0700E281C39B0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (21, N'SLOT 9', 2, 21, N'Done', CAST(0x07004052769C0000 AS Time), CAST(0x07008EA5BFA20000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (22, N'SLOT 10', 2, 22, N'Done', CAST(0x0700EC7572A30000 AS Time), CAST(0x07003AC9BBA90000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (23, N'SLOT 11', 2, 23, NULL, CAST(0x070098996EAA0000 AS Time), CAST(0x0700E6ECB7B00000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (24, N'SLOT 12', 2, 24, NULL, CAST(0x070044BD6AB10000 AS Time), CAST(0x07009210B4B70000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (25, N'SLOT 13', 2, 25, NULL, CAST(0x0700F0E066B80000 AS Time), CAST(0x07003E34B0BE0000 AS Time))
INSERT [dbo].[tblSlot] ([SlotSetupID], [SlotNo], [ItemCategoryID], [ItemID], [Status], [FromTime], [ToTime]) VALUES (26, N'SLOT 14', 2, 26, NULL, CAST(0x07009C0463BF0000 AS Time), CAST(0x0700EA57ACC50000 AS Time))
SET IDENTITY_INSERT [dbo].[tblSlot] OFF
/****** Object:  Table [dbo].[tblPOSDetail]    Script Date: 12/08/2016 21:48:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPOSDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblPOSDetail](
	[POSDetail] [bigint] IDENTITY(1,1) NOT NULL,
	[POSID] [bigint] NULL,
	[ItemCategoryID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[Quantity] [int] NULL,
	[Price] [nvarchar](50) NULL,
	[NetAmount] [nvarchar](50) NULL,
	[TicketIssueID] [bigint] NULL,
 CONSTRAINT [PK_tblPOSDetail] PRIMARY KEY CLUSTERED 
(
	[POSDetail] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblPOS]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPOS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblPOS](
	[POSID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[CounterID] [bigint] NULL,
	[SaleDate] [datetime] NULL,
	[PaymentType] [nvarchar](50) NULL,
	[TotalAmount] [nvarchar](50) NULL,
	[PaidAmount] [nvarchar](50) NULL,
	[BalanceAmount] [nvarchar](50) NULL,
	[Status] [nvarchar](10) NULL,
	[InsertedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblPOS] PRIMARY KEY CLUSTERED 
(
	[POSID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblOpeningClosing]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblOpeningClosing]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblOpeningClosing](
	[OpeningClosingID] [bigint] IDENTITY(1,1) NOT NULL,
	[OpeningDate] [smalldatetime] NOT NULL,
	[ClosingDate] [smalldatetime] NULL,
 CONSTRAINT [PK_tblOpeningClosing] PRIMARY KEY CLUSTERED 
(
	[OpeningClosingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblOpeningClosing] ON
INSERT [dbo].[tblOpeningClosing] ([OpeningClosingID], [OpeningDate], [ClosingDate]) VALUES (1, CAST(0xA6D60000 AS SmallDateTime), NULL)
SET IDENTITY_INSERT [dbo].[tblOpeningClosing] OFF
/****** Object:  Table [dbo].[tblLotSetup]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLotSetup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblLotSetup](
	[LOTID] [bigint] IDENTITY(1,1) NOT NULL,
	[LOTName] [nvarchar](50) NULL,
	[FromTicket] [bigint] NULL,
	[ToTicket] [bigint] NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblLotSetup] PRIMARY KEY CLUSTERED 
(
	[LOTID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblItemCategory]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblItemCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblItemCategory](
	[ItemCategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemCategory] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[IsSlotCategory] [bit] NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblItemCategory] PRIMARY KEY CLUSTERED 
(
	[ItemCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblItemCategory] ON
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (1, N'WeekDay', 1, 1, CAST(0x0000A6D6011684A8 AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (2, N'WeekEnd', 1, 1, CAST(0x0000A6D601168B07 AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (3, N'Socks', 1, 0, CAST(0x0000A6D6011697EB AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (4, N'Beverages', 1, 0, CAST(0x0000A6D60116F3D3 AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (5, N'Discount JumpPass', 1, 1, CAST(0x0000A6D60117AF76 AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (6, N'Bounce Staff', 1, 0, CAST(0x0000A6D60117E495 AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (7, N'Dodge Ball Tournement', 1, 0, CAST(0x0000A6D60117FF7C AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (8, N'Others', 1, 0, CAST(0x0000A6D6011C4819 AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (9, N'Snack / Tuc', 1, 0, CAST(0x0000A6D60123F2CF AS DateTime))
INSERT [dbo].[tblItemCategory] ([ItemCategoryID], [ItemCategory], [IsActive], [IsSlotCategory], [InsertedDate]) VALUES (10, N'Happy Hour', 1, 1, CAST(0x0000A6D60165A4DC AS DateTime))
SET IDENTITY_INSERT [dbo].[tblItemCategory] OFF
/****** Object:  Table [dbo].[tblItem]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblItem](
	[ItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemCategoryID] [bigint] NULL,
	[ItemName] [nvarchar](150) NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblItem] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblItem] ON
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (1, 1, N'JumpPass Slot 1', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60118E4E9 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (2, 1, N'JumpPass Slot 2', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60118FF22 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (3, 1, N'JumpPass Slot 3', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601190841 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (4, 1, N'JumpPass Slot 4', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601191197 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (5, 1, N'JumpPass Slot 5', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601191B89 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (6, 1, N'JumpPass Slot 6', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011924B5 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (7, 1, N'JumpPass Slot 7', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601193141 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (8, 1, N'JumpPass Slot 8', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011938C7 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (9, 1, N'JumpPass Slot 9', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601195419 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (10, 1, N'JumpPass Slot 10', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011966D0 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (11, 1, N'JumpPass Slot 11', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601197226 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (12, 1, N'JumpPass Slot 12', N'Ticket', CAST(350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601198E46 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (13, 2, N'JumpPass Slot 1', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60119A9D5 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (14, 2, N'JumpPass Slot 2', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60119B611 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (15, 2, N'JumpPass Slot 3', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60119C8B0 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (16, 2, N'JumpPass Slot 4', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60119DEC1 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (17, 2, N'JumpPass Slot 5', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60119EB35 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (18, 2, N'JumpPass Slot 6', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60119F8E2 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (19, 2, N'JumpPass Slot 7', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A0441 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (20, 2, N'JumpPass Slot 8', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A1617 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (21, 2, N'JumpPass Slot 9', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A2689 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (22, 2, N'JumpPass Slot 10', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A3CC4 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (23, 2, N'JumpPass Slot 11', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A4580 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (24, 2, N'JumpPass Slot 12', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A590A AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (25, 2, N'JumpPass Slot 13', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A8937 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (26, 2, N'JumpPass Slot 14', N'Ticket', CAST(450.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011A9C5A AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (27, 4, N'Can', N'Pcs', CAST(70.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011AD1FA AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (28, 4, N'Slice Juice', N'Pcs', CAST(50.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011AE1E9 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (29, 4, N'Red Bull', N'Pcs', CAST(200.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011AF8ED AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (30, 4, N'Sting Bottle', N'Pcs', CAST(80.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011B0DDB AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (31, 4, N'Nestle Juice', N'Pcs', CAST(50.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011B377F AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (32, 4, N'MW.Large', N'Pcs', CAST(90.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011B4F93 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (33, 4, N'MW.Small', N'Pcs', CAST(50.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011B607F AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (34, 3, N'Grip Socks', N'Pcs', CAST(50.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011B82EC AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (35, 5, N'Telemart Discount Rs.350 (15%)', N'Ticket', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011D40C4 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (36, 5, N'Telemart Discount Rs.450 (15%)', N'Ticket', CAST(385.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011DE0AE AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (37, 5, N'Bogo Pass Discount Rs.175', N'Ticket', CAST(175.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011E4B4F AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (38, 5, N'Family WeekDay Offer (4 Person)', N'Ticket', CAST(1050.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011EE7E3 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (39, 5, N'Family WeekEnd Offer (4 Person)', N'Ticket', CAST(1350.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011F0705 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (40, 5, N'PEC Card Discount WeekDay', N'Ticket', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011F559C AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (41, 5, N'SCB WeekDay (20%)', N'Ticket', CAST(280.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011F8A0E AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (42, 5, N'SCB WeekEnd (20%)', N'Ticket', CAST(360.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011FAD2D AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (43, 5, N'Discount WeekDay (20%)', N'Ticket', CAST(280.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6011FF099 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (44, 5, N'Discount WeekEnd (20%)', N'Ticket', CAST(360.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6012009C7 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (45, 5, N'UBL WeekDay (20%)', N'Ticket', CAST(280.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601205376 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (46, 5, N'UBL WeekEnd (20%)', N'Ticket', CAST(360.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601206506 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (47, 5, N'UBL WeekDay (25%)', N'Ticket', CAST(260.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6012072DE AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (48, 5, N'UBL WeekEnd (25%)', N'Ticket', CAST(340.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601208168 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (49, 7, N'D.Ball Tournement Team Reg Fee', N'Ticket', CAST(2000.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6012168A4 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (50, 7, N'D.Ball Tournement Individual Reg Fee', N'Ticket', CAST(500.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60121940A AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (51, 6, N'Can Staff', N'Pcs', CAST(45.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60122285D AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (52, 6, N'Tea Staff', N'Pcs', CAST(20.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601224291 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (53, 6, N'Coffee Staff', N'Pcs', CAST(40.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601228088 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (54, 6, N'Sting Staff', N'Pcs', CAST(60.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601228EF2 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (55, 6, N'MW.Large Staff', N'Pcs', CAST(55.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60122CB68 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (56, 6, N'MW.Small Staff', N'Pcs', CAST(30.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60122DDA6 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (57, 6, N'Half Roll Staff', N'Pcs', CAST(20.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60122F320 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (58, 6, N'Nestle Juice Staff', N'Pcs', CAST(30.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D6012313C2 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (59, 6, N'Chips Large Staff', N'Pcs', CAST(30.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601232AFE AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (60, 6, N'Chips Medium Staff', N'Pcs', CAST(20.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601233772 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (61, 6, N'Chips Extra Large Staff', N'Pcs', CAST(50.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601236991 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (62, 6, N'Green Tea Staff', N'Pcs', CAST(20.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601237C93 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (63, 6, N'Redbull Staff', N'Pcs', CAST(150.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601239C9E AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (64, 9, N'Chips Extra Large', N'Pcs', CAST(70.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601243593 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (65, 9, N'Chips Large', N'Pcs', CAST(50.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601244099 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (66, 9, N'Chips Medium', N'Pcs', CAST(30.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601244D7D AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (67, 9, N'Half Roll', N'Pcs', CAST(30.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60124B398 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (68, 9, N'Tea', N'Pcs', CAST(100.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601253E94 AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (69, 9, N'Coffee', N'Pcs', CAST(120.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D601254BBA AS DateTime))
INSERT [dbo].[tblItem] ([ItemID], [ItemCategoryID], [ItemName], [Unit], [Price], [IsActive], [InsertedDate]) VALUES (70, 10, N'Happy Hour Rs.200', N'Ticket', CAST(200.00 AS Decimal(18, 2)), 1, CAST(0x0000A6D60165FB72 AS DateTime))
SET IDENTITY_INSERT [dbo].[tblItem] OFF
/****** Object:  Table [dbo].[tblEventDetail]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEventDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblEventDetail](
	[EventDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[EventID] [bigint] NULL,
	[AdvanceAmount] [decimal](18, 2) NULL,
	[PaymentType] [nvarchar](50) NULL,
	[BalanceAmount] [decimal](18, 2) NULL,
	[BalanceAmountRec] [decimal](18, 2) NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblEventDetail] PRIMARY KEY CLUSTERED 
(
	[EventDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblEvent]    Script Date: 12/08/2016 21:48:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblEvent](
	[EventID] [bigint] IDENTITY(1,1) NOT NULL,
	[EventDate] [date] NULL,
	[EventName] [nvarchar](250) NULL,
	[CustomerName] [nvarchar](150) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](150) NULL,
	[SlotTime] [nvarchar](50) NULL,
	[NoOfGuest] [int] NULL,
	[TotalPlanAmount] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblEvent] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblCounter]    Script Date: 12/08/2016 21:48:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCounter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCounter](
	[CounterID] [bigint] IDENTITY(1,1) NOT NULL,
	[CounterName] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[InsertedDate] [datetime] NULL,
 CONSTRAINT [PK_tblCounter] PRIMARY KEY CLUSTERED 
(
	[CounterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tblCounter] ON
INSERT [dbo].[tblCounter] ([CounterID], [CounterName], [IsActive], [InsertedDate]) VALUES (1, N'Counter 1', 1, CAST(0x0000A6D600000000 AS DateTime))
INSERT [dbo].[tblCounter] ([CounterID], [CounterName], [IsActive], [InsertedDate]) VALUES (2, N'Bounce Counter 1', 1, CAST(0x0000A6D600000000 AS DateTime))
INSERT [dbo].[tblCounter] ([CounterID], [CounterName], [IsActive], [InsertedDate]) VALUES (3, N'Slot Screen', 1, CAST(0x0000A6D600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[tblCounter] OFF
/****** Object:  StoredProcedure [dbo].[sp_getSaleByPaymentMethodReport]    Script Date: 12/08/2016 21:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getSaleByPaymentMethodReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getSaleByPaymentMethodReport]
	@FromDate		date,
	@ToDate			date,
	@Counter		bigint = 0,
	@PaymentType	nvarchar(50) = null
	--@CounterID		bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

Select	 tblCounter.CounterName, tblPOS.SaleDate, tblPOSDetail.POSID, tblItem.ItemName, tblPOSDetail.Quantity, tblPOSDetail.Price, 
		 tblPOSDetail.NetAmount Amount, tblPOS.PaymentType
From	 tblPOS
		 INNER JOIN tblPOSDetail ON tblPOS.POSID = tblPOSDetail.POSID
		 INNER JOIN tblCounter ON tblPOS.CounterID = tblCounter.CounterID
		 INNER JOIN tblItem ON tblPOSDetail.ItemID = tblItem.ItemID
Where	 tblPOS.Status = ''Done''
		 AND (CAST(tblPOS.SaleDate as date) >= @FromDate AND CAST(tblPOS.SaleDate as date) <= @ToDate)
		 AND (tblPOS.CounterID = @Counter OR @Counter IS NULL OR @Counter = 0)
		 AND (tblPOS.PaymentType = @PaymentType OR @PaymentType IS NULL)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getPrintBill]    Script Date: 12/08/2016 21:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getPrintBill]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_getPrintBill]
	@POSId	bigint
AS
BEGIN
	
	SELECT p.SaleDate, d.POSID, c.CounterName, p.TotalAmount, p.PaidAmount, p.BalanceAmount, i.ItemName, d.Quantity, d.Price, d.NetAmount Amount
	FROM tblPOS p
	INNER JOIN tblPOSDetail d ON p.POSID = d.POSID
	INNER JOIN tblItem i ON d.ItemID = i.ItemID
	INNER JOIN tblUser u ON p.UserID = u.UserID
	INNER JOIN tblCounter c ON u.CounterID = c.CounterID
	WHERE p.POSID = @POSId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getNoOfEventFooterReport]    Script Date: 12/08/2016 21:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNoOfEventFooterReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getNoOfEventFooterReport]
	@FromDate		date,
	@ToDate			date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
Select	 COUNT(tblEventDetail.EventID) NoOfEvent
From	 tblEvent
		 INNER JOIN tblEventDetail on tblEvent.EventID = tblEventDetail.EventID
Where	 (CAST(tblEventDetail.InsertedDate as date) >=  @FromDate AND CAST(tblEventDetail.InsertedDate as date) <= @ToDate)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailyActivityReport]    Script Date: 12/08/2016 21:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDailyActivityReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDailyActivityReport]
	@FromDate		date,
	@ToDate			date,
	@CounterID		bigint = 0,
	@ItemID			bigint = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		Select Distinct tblItemCategory.ItemCategory, tblItem.ItemName, tblCounter.CounterName,
			SUM(tblPOSDetail.Quantity) Quantity, tblPOSDetail.Price, SUM(Cast(tblPOSDetail.NetAmount as decimal(18,2))) Amount
		From tblPOSDetail
		Inner Join tblPOS ON tblPOSDetail.POSID = tblPOS.POSID
		Inner Join tblItem ON tblPOSDetail.ItemID = tblItem.ItemID
		Inner JOIn tblItemCategory ON tblPOSDetail.ItemCategoryID = tblItemCategory.ItemCategoryID
		Inner JOin tblCounter ON tblPOS.CounterID = tblCounter.CounterID
		Where (CAST(tblPOS.SaleDate as date) >= @FromDate AND CAST(tblPOS.SaleDate as date) <= @ToDate)
			  AND (tblCounter.CounterID = @CounterID OR @CounterID IS NULL OR @CounterID = 0)
			  AND (tblItem.ItemID = @ItemID OR @ItemID IS NULL OR @ItemID = 0)
			  AND tblPOS.Status = ''Done''
		Group By ItemCategory,ItemName,tblPOSDetail.Price, tblCounter.CounterName

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailyActivityFooterReport]    Script Date: 12/08/2016 21:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDailyActivityFooterReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDailyActivityFooterReport]
	@FromDate		date,
	@ToDate			date,
	@CounterID		bigint = 0,
	@ItemID			bigint = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select	 CashTransaction = CASE tblPOS.PaymentType WHEN ''Cash'' THEN SUM(CAST(tblPOSDetail.NetAmount AS float)) ELSE 0  END,
		 CreditCard = CASE tblPOS.PaymentType WHEN ''Credit Card'' THEN SUM(CAST(tblPOSDetail.NetAmount as float)) ELSE 0 END
From	 tblPOS
		 Inner Join tblPOSDetail ON tblPOSDetail.POSID = tblPOS.POSID
Where	 (CAST(tblPOS.SaleDate as date) >=  @FromDate AND CAST(tblPOS.SaleDate as date) <=  @ToDate)
		 AND (tblPOS.CounterID = @CounterID OR @CounterID IS NULL OR @CounterID = 0)
		 AND (tblPOSDetail.ItemID = @ItemID OR @ItemID IS NULL OR @ItemID = 0)
		 AND tblpos.Status = ''Done''
Group by tblPOS.PaymentType


END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailyActivityEventFooterReport]    Script Date: 12/08/2016 21:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetDailyActivityEventFooterReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDailyActivityEventFooterReport]
	@FromDate		date,
	@ToDate			date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


Select	 EventCashTransaction = CASE tblEventDetail.PaymentType WHEN ''Cash'' THEN CAST(tblEventDetail.AdvanceAmount AS float) + SUM(CAST(tblEventDetail.BalanceAmountRec AS float)) ELSE 0  END,
		 EventCreditCard = CASE tblEventDetail.PaymentType WHEN ''Credit Card'' THEN SUM(CAST(tblEventDetail.BalanceAmountRec as float)) ELSE 0 END
		 
From	 tblEventDetail
		 Inner Join tblEvent ON tblEventDetail.EventID = tblEvent.EventID
Where	 (CAST(tblEventDetail.InsertedDate as date) >=  @FromDate AND CAST(tblEventDetail.InsertedDate as date) <= @ToDate)
Group by tblEventDetail.PaymentType,AdvanceAmount


END
' 
END
GO
