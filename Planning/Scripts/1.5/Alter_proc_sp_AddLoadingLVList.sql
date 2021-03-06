USE [Planning]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddLoadingLVList]    Script Date: 30.09.2020 16:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_AddLoadingLVList] 
	@Split		bit,
	@In			bit,
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
						  and rct_DepositorID = @DepLVID
						  and not exists(
											select 1 
											from 
												shipments s
												inner join shipment_orders so on s.id = so.shipment_id 
												inner join depositors d on d.id = s.depositor_id
											where s_in = @In and d.lv_id = @DepLVID and lv_order_id = rct_ID
										);';
						 -- and not exists(select 1 from PL_Con inner join PL_Ldg on ldg_ID = con_LdgID where ldg_In = @In and ldg_DepLVID = @DepLVID and con_LVID = rct_ID);';

				insert into @Ret(LVID, LVCode, LVStatus, ExpDate, Company, InputDate, DepLVID)
				exec sp_executesql @Sql, N'@In bit, @DepLVID int', @In, @DepLVID;

		end

	end


	select LVID, LVCode, LVStatus, ExpDate, Company, DepLVID
	from @Ret
	order by InputDate;

END
