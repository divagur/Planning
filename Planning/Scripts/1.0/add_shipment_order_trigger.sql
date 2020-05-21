-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[t_is_shipment_order_log] ON [dbo].[shipment_orders]
FOR INSERT, UPDATE, DELETE AS
declare
	@OperType CHAR ( 1 ),
	@sUser VARCHAR(24),
	@sHost VARCHAR(16),
	@sQuestion CHAR ( 3 )
BEGIN
Set @sQuestion = '???'
SET @OperType = ''
 /* Тип операции DML */
 IF EXISTS ( SELECT * FROM deleted  ) AND EXISTS ( SELECT * FROM inserted  )
	BEGIN
		SET @OperType = 'U'
	END 
ELSE IF EXISTS ( SELECT * FROM deleted  ) 
	BEGIN
		SET @OperType = 'D'
	END 
ELSE IF EXISTS ( SELECT * FROM inserted  )
	BEGIN
		SET @OperType = 'I'
	END 

Set @sUser = SUBSTRING(SYSTEM_USER, 1, 24)
Set @sHost = SUBSTRING(HOST_NAME ( ), 1, 16)
 IF @sUser = '' 
	begin
		Set @sUser = @sQuestion 
	end
IF @sHost = ''
	begin
		Set @sHost = @sQuestion 
	end
 IF @OperType = 'I' OR @OperType = 'U'
	BEGIN
 	INSERT INTO shipment_orders_log
	( 
		 
		dml_type, dml_date, dml_user_name, dml_comp_name, 
		shipment_order_id, order_id, shipment_id, order_type, 
		comment, is_binding, manual_load, manual_unload, 
		pallet_amount, binding_id, lv_order_id, lv_order_code
 	)
	SELECT 
		@OperType, CURRENT_TIMESTAMP, @sUser, @sHost,
		ins.id, ins.order_id, ins.shipment_id, ins.order_type, 
		ins.comment, ins.is_binding, ins.manual_load, ins.manual_unload, 
		ins.pallet_amount, ins.binding_id, ins.lv_order_id, ins.lv_order_code
    FROM inserted ins
	
	END
ELSE
	BEGIN
 	INSERT INTO shipment_orders_log
	( 
		 
		dml_type, dml_date, dml_user_name, dml_comp_name, 
		shipment_order_id, order_id, shipment_id, order_type, 
		comment, is_binding, manual_load, manual_unload, 
		pallet_amount, binding_id, lv_order_id, lv_order_code
 	)
	SELECT 
		@OperType, CURRENT_TIMESTAMP, @sUser, @sHost,
		ins.id, ins.order_id, ins.shipment_id, ins.order_type, 
		ins.comment, ins.is_binding, ins.manual_load, ins.manual_unload, 
		ins.pallet_amount, ins.binding_id, ins.lv_order_id, ins.lv_order_code
          	FROM deleted ins

	END
END
GO
