USE [Planning]
GO
/****** Object:  StoredProcedure [dbo].[SP_PL_BindAllConsignments]    Script Date: 01.06.2020 22:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_PL_BindAllOrders]
	@ShpID	int
as
begin

	declare @ShpIn		bit;
	declare @DepLVID	int;
	declare @LVBase		nvarchar(128);
	declare @Sql		nvarchar(max);
	declare @Updated	int;
	declare @Prefix		nchar(4);

	select @ShpIn = s.s_in, @DepLVID = d.lv_id, @LVBase = d.lv_base
	from shipments s with(nolock)
	join depositors d with(nolock) on s.depositor_id = d.id
	where s.id = @ShpID;
	
	if(@ShpIn is NULL)
		return 0;
	
	set @Prefix = (case @ShpIn when 0 then N'ord_' else N'rct_' end);
	
	if(@LVBase is not NULL)
	begin
	
		set @Sql = N'
			declare @IDs table(ID int);
		
			
			update shipment_orders
			set lv_order_id = ' + @Prefix + N'ID
			output inserted.lv_order_id into @IDs
			from ' + @LVBase + N'.dbo.LV_' + (case @ShpIn when 0 then N'Order' else N'Receipt' end) + N'
			where shipment_id = @ShpID
			  and ' + @Prefix + N'Code = lv_order_code
			  and ' + @Prefix + N'DepositorID = @DepLVID;
			
			select @Updated = count(*)
			from @IDs;';

		exec sp_executesql @Sql, N'@ShpID int, @DepLVID int, @Updated int out', @ShpID, @DepLVID, @Updated out;
		
	end

	if(@Updated > 0)
	begin
		update shipment_orders
		set is_binding = 1
		where
			shipment_id = @ShpID
			and lv_order_id is not null

		exec SP_PL_ForceMergeLVAttribute @ShpID;
	end
	return 0;

end
