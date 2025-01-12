using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class DeliveryPeriodDataAdapter : IDataAdaper
    {
        public string Table => "delivery_period";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (custom_post_id, warehouse_id, delivery_day) 
                                    values(
                                            @{nameof(DeliveryPeriod.CustPostId)},@{nameof(DeliveryPeriod.WarehouseId)},@{nameof(DeliveryPeriod.DeliveryDay)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set custom_post_id = @{nameof(DeliveryPeriod.CustPostId)},warehouse_id = @{nameof(DeliveryPeriod.WarehouseId)},
                                            delivery_day = @{nameof(DeliveryPeriod.DeliveryDay)}
                        where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
            return $@"
                    select 
	                    id as {nameof(DeliveryPeriod.Id)}, custom_post_id as {nameof(DeliveryPeriod.CustPostId)},warehouse_id as {nameof(DeliveryPeriod.WarehouseId)},
                        delivery_day as {nameof(DeliveryPeriod.DeliveryDay)}
                    from 
	                    {Table}
                    ";
        }
    }
}
