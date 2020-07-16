USE [Planning]
GO

/****** Object:  UserDefinedTableType [dbo].[T_PL_MainQueryOutput]    Script Date: 22.05.2020 0:19:20 ******/
DROP TYPE [dbo].[T_PL_MainQueryOutput]
GO

/****** Object:  UserDefinedTableType [dbo].[T_PL_MainQueryOutput]    Script Date: 22.05.2020 0:19:20 ******/
CREATE TYPE [dbo].[T_PL_MainQueryOutput] AS TABLE(
	[ShpID] [int] NULL,
	[OrdID] [int] NULL,
	[OrdLVID] [int] NULL,
	[ShpDate] [date] NULL,
	[ShpSlotID] [int] NULL,
	[SlotTime] [time](0) NULL,
	[ShpIn] [bit] NULL,
	[InOut] [nvarchar](8) NULL,
	[OrdLVCode] [nvarchar](32) NULL,
	[ShpDepLVID] [int] NULL,
	[DepCode] [nvarchar](10) NULL,
	[ShpSpecialCond] [bit] NULL,
	[ShpIsCourier] [bit] NULL,
	[ShpGateID] [int] NULL,
	[GateName] [varchar](8) NULL,
	[KlientName] [varchar](64) NULL,
	[OrderStatus] [varchar](30) NULL,
	[PrcReady] [varchar](7) NULL,
	[DoneShare] [decimal](28, 7) NULL,
	[ShpComment] [varchar](500) NULL,
	[OrdComment] [varchar](500) NULL,
	[ShpDriverPhone] [varchar](30) NULL,
	[ShpDriverFio] [varchar](80) NULL,
	[TransportCompanyName] [varchar](80) NULL,
	[TransportTypeName] [varchar](80) NULL,
	[ShpVehicleNumber] [varchar](10) NULL,
	[ShpTrailerNumber] [varchar](10) NULL,
	[ShpAttorneyNumber] [varchar](30) NULL,
	[ShpAttorneyDate] [date] NULL,
	[ShpSubmissionTime] [datetime] NULL,
	[ShpStartTime] [datetime] NULL,
	[ShpEndTimePlan] [datetime] NULL,
	[ShpEndTimeFact] [datetime] NULL,
	[ShpDelayReasonName] [varchar](254) NULL,
	[ShpDelayComment] [varchar](200) NULL,
	[ShpForwarderFio] [varchar](80) NULL,
	[OrdLVType] [varchar](77) NULL,
	[ShpStampNumber] [varchar](25) NULL,
	[IsAddLv] [bit] NULL,
	[FontColor] [int] NULL,
	[BackgroundColor] [int] NULL
	
)
GO


