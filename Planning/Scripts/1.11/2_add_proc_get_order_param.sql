
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Create date: 17.02.2023
-- Description:	Запись количества отгрузочных мест и веса заказа 
-- =============================================
ALTER PROCEDURE SP_PL_GetOrderWight
	@ShpId int = null, 
	@OrdId int = null,
	@DepId int = NULL
AS
BEGIN
	declare @Sql	nvarchar(max),
	 @LVBase	nvarchar(128) = NULL,
	 @DepLVID int


	 select @LVBase = lv_base, @DepLVID = lv_id
	from depositors with(nolock)
	where id = 1;

	select distinct lv_order_id
	into #OrdList
	from shipment_orders
	where
		@OrdId is null or id = @OrdId

	if (@LVBase is not null)
	begin


		set @Sql = N'update shipment_orders set shipping_places_number = t_u.ShpPlaceNumber, order_weight = t_u.OrderWight
					from (

							select ord_id,sum(GrossWight) OrderWight, count (distinct stc_SSCC) ShpPlaceNumber
							from (
									select 
										cast(SUM(ISNULL(isnull(ipt_NetWeight,0)* unt_Conversion,0)*spt_Quantity )as numeric(18,2)) + sdp_DeadWeight as GrossWight,
										stc_SSCC, ord_id 
									from ' + @LVBase + N'.dbo.LV_StockContainer with(nolock)
									left join ' + @LVBase + N'.dbo.LV_Stock with(nolock) on stk_ContainerID = stc_ID
									left join ' + @LVBase + N'.dbo.LV_StockPackType with(nolock) on spt_StockID = stk_ID
									left join ' + @LVBase + N'.dbo.LV_ItemPackType with(nolock) on ipt_ItemUnitID = spt_ItemUnitID and spt_ParentID is null
									left join ' + @LVBase + N'.dbo.LV_Unit with(nolock) on unt_ID = ipt_WeightUnitID 
									left join ' + @LVBase + N'.dbo.LV_OrderShipItemStock with(nolock) on stk_ID= oss_StockID 
									left join ' + @LVBase + N'.dbo.LV_OrderShipItem with(nolock) on osi_ID = oss_OrderShipItemID 
									left join ' + @LVBase + N'.dbo.LV_OrderItem  with(nolock) on osi_OrderItemID = ori_ID
									left join ' + @LVBase + N'.dbo.LV_Order with(nolock)on ord_ID=ori_OrderID 
									join ' + @LVBase + N'.dbo.V_StandardPackType  with(nolock) on  sdp_UnitID = stc_UnitID
									where ord_id in (select lv_order_id from #OrdList)
									group by ord_id,ord_Code, stc_SSCC ,sdp_DeadWeight
							)t
							group by ord_id
					) t_u
					where 
						lv_order_id = t_u.ord_id';

		


		
				exec sp_executesql @Sql, N'@OrdId int',  @OrdId;

	end
	drop table #OrdList
END
GO
