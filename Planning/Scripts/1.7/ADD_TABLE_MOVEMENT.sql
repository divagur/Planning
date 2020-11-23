
/****** Object:  Table [dbo].[PL_Movement]    Script Date: 11.11.2020 20:08:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movement](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_movement] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[movement] ADD  DEFAULT ((1)) FOR [def_customer]
GO

ALTER TABLE [dbo].[movement]  WITH CHECK ADD  CONSTRAINT [FK_movement_DelayReasonID] FOREIGN KEY([delay_reasons_id])
REFERENCES [dbo].[delay_reasons] ([id])
GO

ALTER TABLE [dbo].[movement] CHECK CONSTRAINT [FK_movement_DelayReasonID]
GO

ALTER TABLE [dbo].[movement]  WITH CHECK ADD  CONSTRAINT [FK_movement_SlotID] FOREIGN KEY([time_slot_id])
REFERENCES [dbo].[time_slot] ([id])
GO

ALTER TABLE [dbo].[movement] CHECK CONSTRAINT [FK_movement_SlotID]
GO

