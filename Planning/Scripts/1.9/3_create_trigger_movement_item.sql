-- =============================================
-- Version:	1.1
-- =============================================
CREATE TRIGGER [dbo].[t_is_movement_item_log] ON [dbo].[movement_item]
FOR INSERT, UPDATE, DELETE AS
declare
	@OperType CHAR ( 1 ),
	@sUser VARCHAR(128),
	@sHost VARCHAR(128),
	@sQuestion CHAR ( 3 )
BEGIN
Set @sQuestion = '???'
SET @OperType = ''

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

Set @sUser = SUBSTRING(SYSTEM_USER, 1, 128)
Set @sHost = SUBSTRING(HOST_NAME ( ), 1, 128)
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
 	INSERT INTO movement_item_log
	( 
		 
		dml_type, dml_date, dml_user_name, dml_comp_name, 
		movement_item_id, movement_id, depositor_id, TklLVID
 	)
	SELECT 
		@OperType, CURRENT_TIMESTAMP, @sUser, @sHost,
		ins.id, ins.movement_id, ins.depositor_id, ins.TklLVID
    FROM inserted ins
	END
ELSE
	BEGIN
 	INSERT INTO movement_item_log
	( 
		dml_type, dml_date, dml_user_name, dml_comp_name, 
		movement_item_id, movement_id, depositor_id, TklLVID
 	)
	SELECT 
         @OperType, CURRENT_TIMESTAMP, @sUser, @sHost,
		ins.id, ins.movement_id, ins.depositor_id, ins.TklLVID
    FROM deleted ins

	END
END
GO

ALTER TABLE [dbo].[movement_item] ENABLE TRIGGER [t_is_movement_item_log]
GO


