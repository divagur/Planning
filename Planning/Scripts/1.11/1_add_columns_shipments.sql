USE [Planning]
GO

alter table dbo.shipment_orders add shipping_places_number int null
go
alter table dbo.shipment_orders_log add shipping_places_number int null
go

alter table dbo.shipment_orders add order_weight decimal(19,6) null
go
alter table dbo.shipment_orders_log add order_weight decimal(19,6) null
go
