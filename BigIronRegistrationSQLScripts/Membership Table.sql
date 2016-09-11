/****** Object:  Table [dbo].[Memberships] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Memberships](
	[MembershipID] [int] IDENTITY(1,1) NOT NULL,
	[ExporterID] [int] NOT NULL,
	[ESPID] [int] NOT NULL,
	[MembershipAmount] [money] NOT NULL,
	[MembershipDate] [datetime] NULL,
	[PledgeAmount] [money] NOT NULL,
	[PledgeDate] [datetime] NULL,
	[MembershipStartDate] [datetime] NULL,
	[MembershipEndDate] [datetime] NULL,
	[RefferedCount] [int] NOT NULL,
	[SatisfactionScore] [int] NOT NULL,
 CONSTRAINT [PK_Memberships] PRIMARY KEY CLUSTERED 
(
	[MembershipID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


