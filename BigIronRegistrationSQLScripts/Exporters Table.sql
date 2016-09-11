/****** Object:  Table [dbo].[Exporters] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Exporters](
	[ExporterID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[RegionID] [int] NOT NULL,
	[AccountManagerUserID] [int] NOT NULL,
	[AccountStatusID] [int] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[DOCAccountNumber] [varchar](50) NOT NULL,
	[Website] [varchar](200) NOT NULL,
	[ProductDescription] [varchar](500) NOT NULL,
	[UDF1] [varchar](500) NOT NULL,
	[UDF2] [varchar](500) NOT NULL,
	[UDF3] [varchar](500) NOT NULL,
	[PreviousGKDate] [datetime] NULL,
	[USEACLocation] [varchar](50) NOT NULL,
	[USEACSpecialistName] [varchar](50) NOT NULL,
	[IsSeekingExclusiveRepresentation] [bit] NOT NULL,
	[ProspectQualifications] [varchar](1000) NOT NULL,
	[SpecialFeatures] [varchar](1000) NOT NULL,
	[RequestedCompanies] [varchar](500) NOT NULL,
	[IsCurrentlyRepresented] [bit] NOT NULL,
	[IsCurrentDistributerAwareOfAdditionalRepresentation] [bit] NOT NULL,
	[DesiredLocations] [varchar](500) NOT NULL,
	[DesiredGKStartDate] [datetime] NULL,
	[DesiredGKEndDate] [datetime] NULL,
	[AlternateGKStartDate] [datetime] NULL,
	[AlternateGKEndDate] [datetime] NULL,
	[IsFeatured] [bit] NOT NULL,
	[SpecialistName] [varchar](150) NOT NULL,
	[SpecialistLocation] [varchar](150) NOT NULL,
	[Location] [varchar](250) NULL,
 CONSTRAINT [PK_Exporters] PRIMARY KEY CLUSTERED 
(
	[ExporterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Exporters] ADD  CONSTRAINT [DF_Exporters_IsFeatured]  DEFAULT ((0)) FOR [IsFeatured]
GO

ALTER TABLE [dbo].[Exporters] ADD  CONSTRAINT [DF_Exporters_SpecialistName]  DEFAULT ('') FOR [SpecialistName]
GO

ALTER TABLE [dbo].[Exporters] ADD  CONSTRAINT [DF_Exporters_SpecialistLocation]  DEFAULT ('') FOR [SpecialistLocation]
GO


