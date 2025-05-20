using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class ShipmentOrderPartDataAdapter : IDataAdaper
    {
        public string Table => "shipment_order_parts";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (sh_order_id, os_lvid, os_lvcode, is_binding, manual_load, manual_unload, pallet_amount, shipping_places_number, order_part_weight) 
                                    values(
                                            @{nameof(ShipmentOrderPart.ShOrderId)},@{nameof(ShipmentOrderPart.OsLvId)},@{nameof(ShipmentOrderPart.OsLvCode)},
                                            @{nameof(ShipmentOrderPart.IsBinding)}, @{nameof(ShipmentOrderPart.ManualLoad)},@{nameof(ShipmentOrderPart.ManualUnload)},
                                            @{nameof(ShipmentOrderPart.PalletAmount)},@{nameof(ShipmentOrderPart.ShippingPlacesNumber)},@{nameof(ShipmentOrderPart.OrderPartWeight)})";
                case EditState.Edit:
                    return $@"update {Table} set sh_order_id = @{nameof(ShipmentOrderPart.ShOrderId)}, os_lvid = @{nameof(ShipmentOrderPart.OsLvId)}, 
                            os_lvcode = @{ nameof(ShipmentOrderPart.OsLvCode)}, is_binding = @{ nameof(ShipmentOrderPart.IsBinding)}, 
                            manual_load = @{ nameof(ShipmentOrderPart.ManualLoad)}, manual_unload = @{ nameof(ShipmentOrderPart.ManualUnload)}, pallet_amount = @{ nameof(ShipmentOrderPart.PalletAmount)},                             
                            shipping_places_number = @{nameof(ShipmentOrderPart.ShippingPlacesNumber)}, order_part_weight = @{ nameof(ShipmentOrderPart.OrderPartWeight)}
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
                            id as { nameof(ShipmentOrderPart.Id)}, sh_order_id as {nameof(ShipmentOrderPart.ShOrderId)}, os_lvid as { nameof(ShipmentOrderPart.OsLvId)}, 
                            os_lvcode as { nameof(ShipmentOrderPart.OsLvCode)}, is_binding as { nameof(ShipmentOrderPart.IsBinding)}, 
                            manual_load as { nameof(ShipmentOrderPart.ManualLoad)}, manual_unload as { nameof(ShipmentOrderPart.ManualUnload)}, pallet_amount as { nameof(ShipmentOrderPart.PalletAmount)},                             
                            shipping_places_number as { nameof(ShipmentOrderPart.ShippingPlacesNumber)}, order_weight as { nameof(ShipmentOrderPart.OrderPartWeight)}
            from 
	                    {Table}
                    ";
        }
    }
}
