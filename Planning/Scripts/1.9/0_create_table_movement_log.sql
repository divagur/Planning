
CREATE TABLE [dbo].[movement_log](
	[dml_id] [int] IDENTITY(1,1) NOT NULL,
	[dml_type] [varchar](1) NOT NULL,
	[dml_date] [datetime] NOT NULL,
	[dml_user_name] [varchar](64) NOT NULL,
	[dml_comp_name] [varchar](64) NOT NULL,
	[movement_id] [int] NOT NULL,
	[m_date] [date] NOT NULL,
	[time_slot_id] [int] NULL,
	[priority] [int] NULL,
	[comment] [nvarchar](1024) NULL,
	[delay_reasons_id] [int] NULL,
	[delay_comment] [nvarchar](1024) NULL,
	[performer] [nvarchar](256) NULL,
	[def_customer] [bit] NOT NULL,
	[sp_condition] [bit] NOT NULL,
	[special_time] [time](0) NULL,
  CONSTRAINT [PK_movement_log] PRIMARY KEY CLUSTERED 
(
	[dml_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



