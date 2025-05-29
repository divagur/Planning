using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class ShipmentOrderLogDataAdapter : IDataAdaper
    {
        public string Table => "shipment_orders_log";

        public string GetSaveSql(EditState editState)
        {
            /*
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (order_id, shipment_id, order_type, comment, is_binding, manual_load, manual_unload, pallet_amount, binding_id, 
                                                    lv_order_id, lv_order_code, shipping_places_number, order_weight, is_edm) 
                                    values(
                                            @{nameof(ShipmentOrder.OrderId)},@{nameof(ShipmentOrder.ShipmentId)},@{nameof(ShipmentOrder.OrderType)},@{nameof(ShipmentOrder.Comment)},
                                            @{nameof(ShipmentOrder.IsBinding)}, @{nameof(ShipmentOrder.ManualLoad)},@{nameof(ShipmentOrder.ManualUnload)},
                                            @{nameof(ShipmentOrder.PalletAmount)},@{nameof(ShipmentOrder.BindingId)}, @{nameof(ShipmentOrder.LvOrderId)},
                                            @{nameof(ShipmentOrder.LvOrderCode)},@{nameof(ShipmentOrder.ShippingPlacesNumber)},@{nameof(ShipmentOrder.OrderWeight)},
                                            @{nameof(ShipmentOrder.IsEdm)})";
                case EditState.Edit:
                    return $@"update {Table} set order_id = @{nameof(ShipmentOrder.OrderId)}, shipment_id = @{ nameof(ShipmentOrder.ShipmentId)}, 
                            order_type = @{ nameof(ShipmentOrder.OrderType)}, comment = @{ nameof(ShipmentOrder.Comment)}, is_binding = @{ nameof(ShipmentOrder.IsBinding)}, 
                            manual_load = @{ nameof(ShipmentOrder.ManualLoad)}, manual_unload = @{ nameof(ShipmentOrder.ManualUnload)}, pallet_amount = @{ nameof(ShipmentOrder.PalletAmount)}, 
                            binding_id = @{ nameof(ShipmentOrder.BindingId)}, lv_order_id = @{ nameof(ShipmentOrder.LvOrderId)}, lv_order_code = @{ nameof(ShipmentOrder.LvOrderCode)}, 
                            shipping_places_number = @{nameof(ShipmentOrder.ShippingPlacesNumber)}, order_weight = @{ nameof(ShipmentOrder.OrderWeight)}, 
                            is_edm = @{nameof(ShipmentOrder.IsEdm)}
                        where id = @Id";
                case EditState.Delete:
                    return $"delete from {Table} where id = @Id";
            }
            */
            return String.Empty;
        }

        public string GetSelectItemSql()
        {

            return $@"
                    select 
                            dml_id as { nameof(ShipmentOrderLog.Id)},dml_date as {nameof(ShipmentOrderLog.DmlDate)}, dml_user_name as {nameof(ShipmentOrderLog.DmlUserName)}, 
                            dml_comp_name as {nameof(ShipmentOrderLog.DmlCompName)}, shipment_order_id as {nameof(ShipmentOrderLog.ShipmentOrderId)},
                            order_id as { nameof(ShipmentOrderLog.OrderId)}, shipment_id as { nameof(ShipmentOrderLog.ShipmentId)}, 
                            order_type as { nameof(ShipmentOrderLog.OrderType)}, comment as { nameof(ShipmentOrderLog.Comment)}, is_binding as { nameof(ShipmentOrderLog.IsBinding)}, 
                            manual_load as { nameof(ShipmentOrderLog.ManualLoad)}, manual_unload as { nameof(ShipmentOrderLog.ManualUnload)}, 
                            pallet_amount as { nameof(ShipmentOrderLog.PalletAmount)}, 
                            binding_id as { nameof(ShipmentOrderLog.BindingId)}, lv_order_id as { nameof(ShipmentOrderLog.LvOrderId)}, 
                            lv_order_code as { nameof(ShipmentOrderLog.LvOrderCode)}, 
                            shipping_places_number as { nameof(ShipmentOrderLog.ShippingPlacesNumber)}, order_weight as { nameof(ShipmentOrderLog.OrderWeight)}, 
                            is_edm as {nameof(ShipmentOrderLog.IsEdm)}

            from 
	                    {Table}
                    ";
        }
    }
}
