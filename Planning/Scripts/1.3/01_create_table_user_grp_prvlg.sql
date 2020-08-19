USE [Planning]
GO

CREATE TABLE [dbo].[user_grp_prvlg](
	[grp_id] [int] NOT NULL,
	[func_id] [varchar](32) NOT NULL,
	[is_view] [bit] NULL,
	[is_append] [bit] NULL,
	[is_edit] [bit] NULL,
	[is_delete] [bit] NULL,
 CONSTRAINT [PK_user_grp_prvlg] PRIMARY KEY CLUSTERED 
(
	[grp_id] ASC,
	[func_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


