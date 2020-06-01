USE [Planning]
GO

CREATE VIEW [dbo].[v_shipment_elements]
AS
SELECT        id, field_name, field_db_name, field_type, 
				CASE 
					WHEN field_type = 1 THEN 'Строка' 
					WHEN field_type = 2 THEN 'Число' 
					WHEN field_type = 3 THEN 'Дата'
					WHEN field_type = 4 THEN 'ДатаВремя'
					WHEN field_type = 5 THEN 'Логический' 
				END AS field_type_name
FROM            dbo.shipment_element
GO


