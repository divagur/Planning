ALTER procedure [dbo].[SP_PL_GetMovementItems]
	@MovementID int
as
begin

	declare @t table
	(
		t_ID		int identity,
		t_LVBase	nvarchar(128)
	);

	declare @i			int = 1;
	declare @Cnt		int;
	declare @Sql		nvarchar(max) = N'';
	declare @LVBase		nvarchar(128);
	declare @Ret		T_PL_GetMovementItemsOutput;

	insert into @t(t_LVBase)
	select distinct d.lv_base
	from movement_item mi
	join depositors d on d.id = mi.depositor_id
	where mi.movement_id = @MovementID
	  and d.lv_base is not NULL;

	select @Cnt = count(*)
	from @t;

	while(@i <= @Cnt)
	begin

		select @LVBase = t_LVBase
		from @t
		where t_ID = @i;
		--, dep_LVID, dep_Code
		set @Sql = N'
			select distinct tkl_ID, tkl_Code, msg_Greek, NULL, N''BAXI'', tkl_CreateDate, lv_id, name
			from movement_item mi with(nolock)
			join depositors d with(nolock) on d.id = mi.depositor_id
			join ' + @LVBase + N'.dbo.LV_TaskList with(nolock) on tkl_ID = mi.TklLVID
			join ' + @LVBase + N'.dbo.LV_Task with(nolock) on tsk_TaskListID = tkl_ID
			join ' + @LVBase + N'.dbo.LV_ProgressStatus with(nolock) on pst_ID = tkl_StatusID
			left join ' + @LVBase + N'.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
			where mi.movement_id = @MovementID
			  and d.lv_base = N''' + @LVBase + N''';';

		insert into @Ret(LVID, LVCode, LVStatus, ExpDate, Company, InputDate, DepLVID, DepCode)
		exec sp_executesql @Sql, N'@MovementID int', @MovementID;

		set @i += 1;

	end

	select LVID, LVCode, LVStatus, ExpDate, Company, InputDate, DepLVID, DepCode
	from @Ret
	order by DepCode, LVCode;

	return 0;

end
