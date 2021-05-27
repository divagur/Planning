
-- =============================================
-- Version:	1.1
-- =============================================
CREATE TRIGGER [dbo].[t_is_movement_log] ON [dbo].[movement]
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
 	INSERT INTO movement_log
	( 
		 
		dml_type, dml_date, dml_user_name, dml_comp_name, 
		movement_id, m_date, time_slot_id, priority, comment, delay_reasons_id, 
		delay_comment, performer, def_customer, sp_condition, special_time
 	)
	SELECT 
		@OperType, CURRENT_TIMESTAMP, @sUser, @sHost,
		ins.id, ins.m_date, ins.time_slot_id, ins.priority, ins.comment, ins.delay_reasons_id, 
		ins.delay_comment, ins.performer, ins.def_customer, ins.sp_condition, ins.special_time
    FROM inserted ins
	END
ELSE
	BEGIN
 	INSERT INTO movement_log
	( 
		dml_type, dml_date, dml_user_name, dml_comp_name, 
		movement_id, m_date, time_slot_id, priority, comment, delay_reasons_id, 
		delay_comment, performer, def_customer, sp_condition, special_time
 	)
	SELECT 
         @OperType, CURRENT_TIMESTAMP, @sUser, @sHost,
		ins.id, ins.m_date, ins.time_slot_id, ins.priority, ins.comment, ins.delay_reasons_id, 
		ins.delay_comment, ins.performer, ins.def_customer, ins.sp_condition, ins.special_time
    FROM deleted ins

	END
END
GO

ALTER TABLE [dbo].[movement] ENABLE TRIGGER [t_is_movement_log]
GO


