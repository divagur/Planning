USE [Planning]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddLoadingLVList]    Script Date: 16.11.2020 22:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_AddLoadingLVList] 
	@Split		bit,
	@In			bit = null,
	@DepID	int	= NULL, -- normal and movement parameter
	@LVID		int	= NULL -- split and movement parameter
AS
BEGIN

declare @Ret table
	(
		LVID		int,
		LVCode		nvarchar(32),
		LVStatus	nvarchar(255),
		ExpDate		datetime,
		Company		nvarchar(30),
		InputDate	datetime,
		DepLVID		int
	);


	declare @Sql	nvarchar(max),
	 @LVBase	nvarchar(128) = NULL,
	 @DepLVID int;
	
	select @LVBase = lv_base, @DepLVID = lv_id
	from depositors with(nolock)
	where id = @DepID;

	if (@LVBase is not null)
	begin

		if(@In is not NULL)
		begin

				-- normal
				if(@In = 0)
					set @Sql = N'
						select distinct ord_ID, ord_Code, msg_Greek, ord_ExpShipDate, cmp_ShortName, ord_InputDate, @DepLVID
						from ' + @LVBase + N'.dbo.LV_Order with(nolock)
						left join ' + @LVBase + N'.dbo.LV_Customer with(nolock) on cus_ID = ord_CustomerID
						left join ' + @LVBase + N'.dbo.LV_Company with (nolock) on cmp_ID = cus_CompanyID
						left join ' + @LVBase + N'.dbo.LV_ProgressStatus with(nolock) on pst_ID = ord_StatusID
						left join ' + @LVBase + N'.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
						where ord_StatusID not in (3, 4)
						  and ord_DepositorID = @DepLVID;';
						  --and not exists(select 1 from PL_Con inner join PL_Ldg on ldg_ID = con_LdgID where ldg_In = @In and ldg_DepLVID = @DepLVID and con_LVID = ord_ID)
				else
					set @Sql = N'
						select distinct rct_ID, rct_Code, msg_Greek, rct_ExpectedDate, cmp_ShortName Comp, rct_InputDate, @DepLVID
						from ' + @LVBase + N'.dbo.LV_Receipt with(nolock)
						left join ' + @LVBase + N'.dbo.LV_Supplier with(nolock) on spl_ID = rct_SupplierID
						left join ' + @LVBase + N'.dbo.LV_Company with (nolock) on cmp_ID = spl_CompanyID
						left join ' + @LVBase + N'.dbo.LV_ProgressStatus with(nolock) on pst_ID = rct_ProgressID
						left join ' + @LVBase + N'.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
						where rct_ProgressID not in (3, 4)
						  and rct_DepositorID = @DepLVID;';
						  --and not exists(select 1 from PL_Con inner join PL_Ldg on ldg_ID = con_LdgID where ldg_In = @In and ldg_DepLVID = @DepLVID and con_LVID = rct_ID);';

				insert into @Ret(LVID, LVCode, LVStatus, ExpDate, Company, InputDate, DepLVID)
				exec sp_executesql @Sql, N'@In bit, @DepLVID int', @In, @DepLVID;

		end
		else -- Movement
		begin

			set @Sql = N'
				select distinct tkl_ID, tkl_Code, msg_Greek, NULL, N''BAXI'', tkl_CreateDate, @DepLVID
				from ' + @LVBase + N'.dbo.LV_TaskList with(nolock)
				join ' + @LVBase + N'.dbo.LV_Task with(nolock) on tsk_TaskListID = tkl_ID
				join ' + @LVBase + N'.dbo.LV_ProgressStatus with(nolock) on pst_ID = tkl_StatusID
				left join ' + @LVBase + N'.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
				where tkl_TransactionTypeID not in(1 /*Receipt*/, 4 /*ReceiptChange*/, 3 /*Picking*/, 27 /*CancelPick*/, 10 /*Loading*/, 25 /*Unloading*/)
				  and tsk_DepositorID = @DepLVID
				--and tkl_StatusID = 1 /*Pending*/
				  and not exists(
									select 1 
									from 
										movement_item with(nolock) inner join depositors on (movement_item.depositor_id = depositors.id)
									where depositors.lv_id = tsk_DepositorID and TklLVID = tkl_ID and movement_id <> isnull(@LVID, 0))
				  --and tkl_ID not in (select til_LVID from @Inserted where til_DepLVID = @DepLVID);';

			insert into @Ret(LVID, LVCode, LVStatus, ExpDate, Company, InputDate, DepLVID)
			exec sp_executesql @Sql, N'@DepLVID int, @LVID int', @DepLVID, @LVID;

		end --Movement
	end


	select LVID, LVCode, LVStatus, ExpDate, Company, DepLVID
	from @Ret
	order by InputDate;

END
