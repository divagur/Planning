
/****** Object:  Table [dbo].[PL_MovementItem]    Script Date: 11.11.2020 21:11:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movement_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movement_id] [int] NOT NULL,
	[depositor_id] [int] NOT NULL,
	[TklLVID] [int] NOT NULL,
 CONSTRAINT [PK_movement_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[movement_item]  WITH CHECK ADD  CONSTRAINT [FK_MovementItem_DepID] FOREIGN KEY([depositor_id])
REFERENCES [dbo].[depositors] ([id])
GO

ALTER TABLE [dbo].[movement_item] CHECK CONSTRAINT [FK_MovementItem_DepID]
GO

ALTER TABLE [dbo].[movement_item]  WITH CHECK ADD  CONSTRAINT [FK_MovementItem_MovementID] FOREIGN KEY([movement_id])
REFERENCES [dbo].[movement] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[movement_item] CHECK CONSTRAINT [FK_MovementItem_MovementID]
GO


