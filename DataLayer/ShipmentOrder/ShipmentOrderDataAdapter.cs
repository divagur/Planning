using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class ShipmentOrderDataAdapter : IDataAdaper
    {
        public string Table => "shipment_orders";

        public string GetSaveSql(EditState editState)
        {
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
                            is_edm = @{ nameof(ShipmentOrder.IsEdm)}
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
                            id as { nameof(ShipmentOrder.Id)}, order_id as { nameof(ShipmentOrder.OrderId)}, shipment_id as { nameof(ShipmentOrder.ShipmentId)}, 
                            order_type as { nameof(ShipmentOrder.OrderType)}, comment as { nameof(ShipmentOrder.Comment)}, is_binding as { nameof(ShipmentOrder.IsBinding)}, 
                            manual_load as { nameof(ShipmentOrder.ManualLoad)}, manual_unload as { nameof(ShipmentOrder.ManualUnload)}, pallet_amount as { nameof(ShipmentOrder.PalletAmount)}, 
                            binding_id as { nameof(ShipmentOrder.BindingId)}, lv_order_id as { nameof(ShipmentOrder.LvOrderId)}, lv_order_code as { nameof(ShipmentOrder.LvOrderCode)}, 
                            shipping_places_number as { nameof(ShipmentOrder.ShippingPlacesNumber)}, order_weight as { nameof(ShipmentOrder.OrderWeight)}, 
                            is_edm as { nameof(ShipmentOrder.IsEdm)}

            from 
	                    {Table}
                    ";
        }
    }
}
