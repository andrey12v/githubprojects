USE [DivaDB]
GO
/****** Object:  Table [dbo].[StockLocation]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockLocation](
	[StockLocationIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](50) NOT NULL,
	[LocationDescription] [nvarchar](150) NULL,
 CONSTRAINT [PK_StockLocation] PRIMARY KEY CLUSTERED 
(
	[StockLocationIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingMethods]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingMethods](
	[ShippingMethodIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[ShippingMethod] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_ShippingMethods] PRIMARY KEY CLUSTERED 
(
	[ShippingMethodIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sets]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sets](
	[SetIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[SetName] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Discontinued] [bit] NULL,
	[OzShipping] [int] NULL,
	[MAP] [money] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sets] PRIMARY KEY CLUSTERED 
(
	[SetIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnCode]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnCode](
	[ReturnCodeIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Action] [nvarchar](100) NULL,
	[ReturnToStock] [bit] NOT NULL,
	[RemoveFromCurSold] [bit] NOT NULL,
 CONSTRAINT [PK_ReturnCode] PRIMARY KEY CLUSTERED 
(
	[ReturnCodeIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[PaymentMethodIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMethod] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[AccountLocation] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CoIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[CoName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](14) NULL,
	[Fax] [nvarchar](14) NULL,
	[Email] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[Zip] [nvarchar](10) NULL,
	[Contact] [nvarchar](50) NULL,
	[Notes] [nvarchar](max) NULL,
	[Prefix] [nvarchar](3) NULL,
	[MinimumOrder] [money] NULL,
	[PaymentMethodIndexFK] [int] NULL,
	[ShippingMethodIndexFK] [int] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CoIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[OrderHistoryIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[CoIndexFK] [int] NOT NULL,
	[PONumber] [nvarchar](12) NOT NULL,
	[DateOrdered] [date] NOT NULL,
 CONSTRAINT [PK_OrderHistory] PRIMARY KEY CLUSTERED 
(
	[OrderHistoryIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[ItemNumber] [nvarchar](50) NOT NULL,
	[SKU] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Location] [nvarchar](15) NULL,
	[OOSStatus] [nvarchar](50) NULL,
	[Discontinued] [bit] NULL,
	[QuantityControlled] [bit] NULL,
	[OzShipping] [int] NULL,
	[Cost] [money] NULL,
	[MAP] [money] NULL,
	[notes] [nvarchar](max) NULL,
	[CaseQTY] [int] NULL,
	[NewPar] [int] NOT NULL,
	[ParCorrection] [int] NOT NULL,
	[OnOrder] [int] NOT NULL,
	[LastOrdered] [nvarchar](12) NULL,
	[CoIndexFK] [int] NULL,
	[SubItem] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SetList]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetList](
	[SetIndexFK] [int] NOT NULL,
	[ItemIndexFK] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_SetList] PRIMARY KEY CLUSTERED 
(
	[SetIndexFK] ASC,
	[ItemIndexFK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesHistory]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesHistory](
	[SalesHistoryIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[ItemIndexFK] [int] NULL,
	[SetIndexFK] [int] NULL,
	[AccountIndexFK] [int] NOT NULL,
	[WeekDate] [date] NOT NULL,
	[TotalSold] [int] NOT NULL,
 CONSTRAINT [PK_SalesHistory] PRIMARY KEY CLUSTERED 
(
	[SalesHistoryIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Returns]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Returns](
	[ReturnsIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[ItemIndexFK] [int] NOT NULL,
	[AccountIndexFK] [int] NOT NULL,
	[ReturnCodeFK] [int] NOT NULL,
	[SaleID] [nvarchar](50) NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL,
	[ReturnDate] [date] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Returns] PRIMARY KEY CLUSTERED 
(
	[ReturnsIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemAlias]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemAlias](
	[AliasName] [nvarchar](75) NOT NULL,
	[ItemIndexFK] [int] NULL,
	[SetIndexFK] [int] NULL,
 CONSTRAINT [PK_ItemAlias] PRIMARY KEY CLUSTERED 
(
	[AliasName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InStock]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InStock](
	[InStockIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[ItemIndexFK] [int] NOT NULL,
	[StockLocationIndexFK] [int] NOT NULL,
	[AmountInStock] [int] NOT NULL,
 CONSTRAINT [PK_InStock] PRIMARY KEY CLUSTERED 
(
	[InStockIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentSold]    Script Date: 08/10/2009 18:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentSold](
	[CurrentSoldIndexPK] [int] IDENTITY(1,1) NOT NULL,
	[ItemIndexFK] [int] NULL,
	[SetIndexFK] [int] NULL,
	[AccountIndexFK] [int] NOT NULL,
	[CurSold] [int] NOT NULL,
 CONSTRAINT [PK_CurrentSold] PRIMARY KEY CLUSTERED 
(
	[CurrentSoldIndexPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Company_PaymentMethods]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_PaymentMethods] FOREIGN KEY([PaymentMethodIndexFK])
REFERENCES [dbo].[PaymentMethods] ([PaymentMethodIndexPK])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_PaymentMethods]
GO
/****** Object:  ForeignKey [FK_Company_ShippingMethods]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_ShippingMethods] FOREIGN KEY([ShippingMethodIndexFK])
REFERENCES [dbo].[ShippingMethods] ([ShippingMethodIndexPK])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_ShippingMethods]
GO
/****** Object:  ForeignKey [FK_CurrentSold_Accounts]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[CurrentSold]  WITH CHECK ADD  CONSTRAINT [FK_CurrentSold_Accounts] FOREIGN KEY([AccountIndexFK])
REFERENCES [dbo].[Accounts] ([AccountIndexPK])
GO
ALTER TABLE [dbo].[CurrentSold] CHECK CONSTRAINT [FK_CurrentSold_Accounts]
GO
/****** Object:  ForeignKey [FK_CurrentSold_Items]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[CurrentSold]  WITH CHECK ADD  CONSTRAINT [FK_CurrentSold_Items] FOREIGN KEY([ItemIndexFK])
REFERENCES [dbo].[Items] ([ItemIndexPK])
GO
ALTER TABLE [dbo].[CurrentSold] CHECK CONSTRAINT [FK_CurrentSold_Items]
GO
/****** Object:  ForeignKey [FK_CurrentSold_Sets]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[CurrentSold]  WITH CHECK ADD  CONSTRAINT [FK_CurrentSold_Sets] FOREIGN KEY([SetIndexFK])
REFERENCES [dbo].[Sets] ([SetIndexPK])
GO
ALTER TABLE [dbo].[CurrentSold] CHECK CONSTRAINT [FK_CurrentSold_Sets]
GO
/****** Object:  ForeignKey [FK_InStock_Items]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[InStock]  WITH CHECK ADD  CONSTRAINT [FK_InStock_Items] FOREIGN KEY([ItemIndexFK])
REFERENCES [dbo].[Items] ([ItemIndexPK])
GO
ALTER TABLE [dbo].[InStock] CHECK CONSTRAINT [FK_InStock_Items]
GO
/****** Object:  ForeignKey [FK_InStock_StockLocation]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[InStock]  WITH CHECK ADD  CONSTRAINT [FK_InStock_StockLocation] FOREIGN KEY([StockLocationIndexFK])
REFERENCES [dbo].[StockLocation] ([StockLocationIndexPK])
GO
ALTER TABLE [dbo].[InStock] CHECK CONSTRAINT [FK_InStock_StockLocation]
GO
/****** Object:  ForeignKey [FK_ItemAlias_Items]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[ItemAlias]  WITH CHECK ADD  CONSTRAINT [FK_ItemAlias_Items] FOREIGN KEY([ItemIndexFK])
REFERENCES [dbo].[Items] ([ItemIndexPK])
GO
ALTER TABLE [dbo].[ItemAlias] CHECK CONSTRAINT [FK_ItemAlias_Items]
GO
/****** Object:  ForeignKey [FK_Items_Company]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Company] FOREIGN KEY([CoIndexFK])
REFERENCES [dbo].[Company] ([CoIndexPK])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Company]
GO
/****** Object:  ForeignKey [FK_OrderHistory_Company]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrderHistory_Company] FOREIGN KEY([CoIndexFK])
REFERENCES [dbo].[Company] ([CoIndexPK])
GO
ALTER TABLE [dbo].[OrderHistory] CHECK CONSTRAINT [FK_OrderHistory_Company]
GO
/****** Object:  ForeignKey [FK_Returns_Accounts]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_Accounts] FOREIGN KEY([AccountIndexFK])
REFERENCES [dbo].[Accounts] ([AccountIndexPK])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_Accounts]
GO
/****** Object:  ForeignKey [FK_Returns_Items]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_Items] FOREIGN KEY([ItemIndexFK])
REFERENCES [dbo].[Items] ([ItemIndexPK])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_Items]
GO
/****** Object:  ForeignKey [FK_Returns_ReturnCode]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_ReturnCode] FOREIGN KEY([ReturnCodeFK])
REFERENCES [dbo].[ReturnCode] ([ReturnCodeIndexPK])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_ReturnCode]
GO
/****** Object:  ForeignKey [FK_SalesHistory_Accounts]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[SalesHistory]  WITH CHECK ADD  CONSTRAINT [FK_SalesHistory_Accounts] FOREIGN KEY([AccountIndexFK])
REFERENCES [dbo].[Accounts] ([AccountIndexPK])
GO
ALTER TABLE [dbo].[SalesHistory] CHECK CONSTRAINT [FK_SalesHistory_Accounts]
GO
/****** Object:  ForeignKey [FK_SalesHistory_Items]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[SalesHistory]  WITH CHECK ADD  CONSTRAINT [FK_SalesHistory_Items] FOREIGN KEY([ItemIndexFK])
REFERENCES [dbo].[Items] ([ItemIndexPK])
GO
ALTER TABLE [dbo].[SalesHistory] CHECK CONSTRAINT [FK_SalesHistory_Items]
GO
/****** Object:  ForeignKey [FK_SalesHistory_Sets]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[SalesHistory]  WITH CHECK ADD  CONSTRAINT [FK_SalesHistory_Sets] FOREIGN KEY([SetIndexFK])
REFERENCES [dbo].[Sets] ([SetIndexPK])
GO
ALTER TABLE [dbo].[SalesHistory] CHECK CONSTRAINT [FK_SalesHistory_Sets]
GO
/****** Object:  ForeignKey [FK_SetList_Items2]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[SetList]  WITH CHECK ADD  CONSTRAINT [FK_SetList_Items2] FOREIGN KEY([ItemIndexFK])
REFERENCES [dbo].[Items] ([ItemIndexPK])
GO
ALTER TABLE [dbo].[SetList] CHECK CONSTRAINT [FK_SetList_Items2]
GO
/****** Object:  ForeignKey [FK_SetList_Sets]    Script Date: 08/10/2009 18:06:51 ******/
ALTER TABLE [dbo].[SetList]  WITH CHECK ADD  CONSTRAINT [FK_SetList_Sets] FOREIGN KEY([SetIndexFK])
REFERENCES [dbo].[Sets] ([SetIndexPK])
GO
ALTER TABLE [dbo].[SetList] CHECK CONSTRAINT [FK_SetList_Sets]
GO
