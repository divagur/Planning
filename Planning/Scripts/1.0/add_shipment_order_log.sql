USE [Planning]
GO

/****** Object:  Table [dbo].[shipment_orders]    Script Date: 20.05.2020 0:01:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shipment_orders_log]
(
	dml_id int  IDENTITY(1,1) NOT NULL, 
	dml_type varchar(1) not null, 
	dml_date datetime not null, 
	dml_user_name varchar(64) not null, 
	dml_comp_name varchar(64) not null,
	[shipment_order_id] [int] NOT NULL,
	[order_id] [varchar](32) NULL,
	[shipment_id] [int] NULL,
	[order_type] [varchar](64) NULL,
	[comment] [varchar](500) NULL,
	[is_binding] [bit] NULL,
	[manual_load] [int] NULL,
	[manual_unload] [int] NULL,
	[pallet_amount] [int] NULL,
	[binding_id] [int] NULL,
	[lv_order_id] [int] NULL,
	[lv_order_code] [varchar](32) NULL,
 CONSTRAINT [PK_shipment_orders_log] PRIMARY KEY CLUSTERED 
(
	dml_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


