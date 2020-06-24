USE [Planning]
GO

/****** Object:  Table [dbo].[transport_company]    Script Date: 11.06.2020 8:02:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[transport_company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](254) NULL,
	[is_active] [bit] NULL,
 CONSTRAINT [PK_transport_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


