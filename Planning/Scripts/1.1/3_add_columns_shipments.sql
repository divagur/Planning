USE [Planning]
GO

alter table dbo.shipments add transport_company_id int null
go
alter table dbo.shipments_log add transport_company_id int null
go

ALTER TABLE [dbo].[shipments]  WITH CHECK ADD  CONSTRAINT [FK_shipments_tc] FOREIGN KEY([transport_company_id])
REFERENCES [dbo].[transport_company] ([id])
GO

ALTER TABLE [dbo].[shipments] CHECK CONSTRAINT [FK_shipments_tc]
GO

alter table dbo.shipments add transport_type_id int null
go
alter table dbo.shipments_log add transport_type_id int null
go 
ALTER TABLE [dbo].[shipments]  WITH CHECK ADD  CONSTRAINT [FK_shipments_transport_type] FOREIGN KEY([transport_type_id])
REFERENCES [dbo].[transport_type] ([id])
GO

ALTER TABLE [dbo].[shipments] CHECK CONSTRAINT [FK_shipments_transport_type]
GO