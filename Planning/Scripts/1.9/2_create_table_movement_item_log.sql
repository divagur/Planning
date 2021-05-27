
CREATE TABLE [dbo].[movement_item_log](
	[dml_id] [int] IDENTITY(1,1) NOT NULL,
	[dml_type] [varchar](1) NOT NULL,
	[dml_date] [datetime] NOT NULL,
	[dml_user_name] [varchar](64) NOT NULL,
	[dml_comp_name] [varchar](64) NOT NULL,
	[movement_item_id] [int] NOT NULL,
	[movement_id] [int] NOT NULL,
	[depositor_id] [int] NOT NULL,
	[TklLVID] [int] NOT NULL,
 CONSTRAINT [PK_movement_item_log] PRIMARY KEY CLUSTERED 
(
	[dml_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]




