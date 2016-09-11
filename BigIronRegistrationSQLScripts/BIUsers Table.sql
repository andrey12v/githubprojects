/****** Object:  Table [dbo].[BIUsers] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BIUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[JobTitle] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[UserAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateProvince] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[ProductInterest] [varchar](50) NULL,
	[OtherProductInterest] [varchar](150) NULL,
	[VisitorStatus] [varchar](50) NULL,
	[OtherVisitorStatus] [varchar](50) NULL,
	[PurposeVisit] [varchar](50) NULL,
	[OtherPurposeVisit] [varchar](50) NULL,
	[CropInterest] [varchar](50) NULL,
	[OtherCropInterest] [varchar](50) NULL,
	[Interpreter] [int] NULL,
	[UserLanguage] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


