USE master
GO
DROP DATABASE IF EXISTS [dbSMART_STAR]
GO
CREATE DATABASE [dbSMART_STAR]
GO
USE [dbSMART_STAR]
GO
/****** Object:  Table [dbo].[DimCustomers]    Script Date: 2/28/2024 3:45:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimCustomers](
	[CustomerID] [nvarchar](300) NOT NULL,
	[CustomerName] [nvarchar](300) NULL,
	[Segment] [nvarchar](300) NULL,
 CONSTRAINT [PK_DimCustomers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DimLocations]    Script Date: 2/28/2024 3:45:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimLocations](
	[LocationID] [int] NOT NULL,
	[Market] [nvarchar](500) NULL,
	[Region] [nvarchar](500) NULL,
	[Country] [nvarchar](500) NULL,
	[State] [nvarchar](500) NULL,
	[City] [nvarchar](500) NULL,
	[PostalCode] [nvarchar](500) NULL,
 CONSTRAINT [PK_DimLocations] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DimProducts]    Script Date: 2/28/2024 3:45:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimProducts](
	[ProductID] [nvarchar](300) NOT NULL,
	[ProductName] [nvarchar](300) NULL,
	[SubCategory] [nvarchar](300) NULL,
	[Category] [nvarchar](300) NULL,
 CONSTRAINT [PK_DimProducts] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DimTime]    Script Date: 2/28/2024 3:45:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimTime](
	[TimeID] [int] NOT NULL,
	[OrderYear] [int] NULL,
	[OrderQuarter] [int] NULL,
	[OrderMonth] [int] NULL,
	[OrderDay] [int] NULL,
	[ShipYear] [int] NULL,
	[ShipQuarter] [int] NULL,
	[ShipMonth] [int] NULL,
	[ShipDay] [int] NULL,
 CONSTRAINT [PK_DimTime] PRIMARY KEY CLUSTERED 
(
	[TimeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FactOders]    Script Date: 2/28/2024 3:45:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactOders](
	[Row ID] [numeric](18, 0) NOT NULL,
	[Order ID] [nvarchar](300) NULL,
	[CustomerID] [nvarchar](300) NULL,
	[ProductID] [nvarchar](300) NULL,
	[TimeID] [int] NULL,
	[LocationID] [int] NULL,
	[Sales] [numeric](18, 0) NULL,
	[Quantity] [numeric](18, 0) NULL,
	[Discount] [numeric](18, 0) NULL,
	[Profit] [numeric](18, 0) NULL,
	[Shipping Cost] [numeric](18, 0) NULL,
	[Order Priority] [nvarchar](300) NULL,
	[Ship Mode] [nvarchar](300) NULL,
 CONSTRAINT [PK_FactOders] PRIMARY KEY CLUSTERED 
(
	[Row ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FactOders]  WITH CHECK ADD  CONSTRAINT [FK_FactOders_DimCustomers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[DimCustomers] ([CustomerID])
GO
ALTER TABLE [dbo].[FactOders] CHECK CONSTRAINT [FK_FactOders_DimCustomers]
GO
ALTER TABLE [dbo].[FactOders]  WITH CHECK ADD  CONSTRAINT [FK_FactOders_DimLocations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[DimLocations] ([LocationID])
GO
ALTER TABLE [dbo].[FactOders] CHECK CONSTRAINT [FK_FactOders_DimLocations]
GO
ALTER TABLE [dbo].[FactOders]  WITH CHECK ADD  CONSTRAINT [FK_FactOders_DimProducts] FOREIGN KEY([ProductID])
REFERENCES [dbo].[DimProducts] ([ProductID])
GO
ALTER TABLE [dbo].[FactOders] CHECK CONSTRAINT [FK_FactOders_DimProducts]
GO
ALTER TABLE [dbo].[FactOders]  WITH CHECK ADD  CONSTRAINT [FK_FactOders_DimTime] FOREIGN KEY([TimeID])
REFERENCES [dbo].[DimTime] ([TimeID])
GO
ALTER TABLE [dbo].[FactOders] CHECK CONSTRAINT [FK_FactOders_DimTime]
GO
