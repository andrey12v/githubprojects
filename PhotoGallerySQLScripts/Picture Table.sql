/****** Object:  Table [dbo].[Picture]******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Picture](
	[GalleryID] [int] NOT NULL,
	[PictureID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NULL,
	[PictureDescription] [varchar](450) NULL,
	[FrontImage] [int] NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[PictureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Picture] ADD  CONSTRAINT [DF_Picture_frontImage]  DEFAULT ((0)) FOR [FrontImage]
GO


