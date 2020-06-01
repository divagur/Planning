USE [Planning]
GO

CREATE VIEW [dbo].[v_shipment_elements]
AS
SELECT        id, field_name, field_db_name, field_type, 
				CASE 
					WHEN field_type = 1 THEN '������' 
					WHEN field_type = 2 THEN '�����' 
					WHEN field_type = 3 THEN '����'
					WHEN field_type = 4 THEN '���������'
					WHEN field_type = 5 THEN '����������' 
				END AS field_type_name
FROM            dbo.shipment_element
GO


