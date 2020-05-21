USE [Planning]
GO

/****** Object:  Table [dbo].[shipments]    Script Date: 19.05.2020 23:39:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shipments_log](
	dml_id int  IDENTITY(1,1) NOT NULL, 
	dml_type varchar(1) not null, 
	dml_date datetime not null, 
	dml_user_name varchar(64) not null, 
	dml_comp_name varchar(64) not null,
	[shipment_id] [int] NOT NULL,
	[lv_id] [int] NULL,
	[time_slot_id] [int] NULL,
	[s_date] [date] NULL,
	[s_comment] [varchar](500) NULL,
	[o_comment] [varchar](500) NULL,
	[gate_id] [int] NULL,
	[sp_condition] [bit] NULL,
	[driver_phone] [varchar](30) NULL,
	[driver_fio] [varchar](80) NULL,
	[vehicle_number] [varchar](10) NULL,
	[trailer_number] [varchar](10) NULL,
	[attorney_number] [varchar](30) NULL,
	[attorney_date] [date] NULL,
	[submission_time] [datetime] NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[leave_time] [datetime] NULL,
	[delay_reasons_id] [int] NULL,
	[delay_comment] [varchar](200) NULL,
	[depositor_id] [int] NULL,
	[is_courier] [bit] NULL,
	[forwarder_fio] [varchar](80) NULL,
	[stamp_number] [varchar](25) NULL,
	[attorney_issued] [varchar](150) NULL,
	[s_in] [bit] NULL,
	[special_time] [time](0) NULL,
 CONSTRAINT [PK_shipments_log] PRIMARY KEY CLUSTERED 
(
	dml_id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

GO


