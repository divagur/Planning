using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentDataAdapter : IDataAdaper
    {
        public string Table => "shipments";

        public string GetSaveSql(EditState editState)
        {
            switch (editState)
            {
                case EditState.New:
                    return $@"INSERT INTO {Table} (lv_id, time_slot_id, s_date, s_comment, o_comment, gate_id, sp_condition, driver_phone, driver_fio,
                                                    vehicle_number, trailer_number, attorney_number,attorney_date, submission_time, start_time, end_time,
                                                    leave_time, delay_reasons_id, delay_comment, depositor_id, is_courier, forwarder_fio, stamp_number, 
                                                    attorney_issued, s_in, special_time, is_add_lv,transport_company_id, transport_type_id,supplier_id, custom_post_id,
                                                    warehouse_id, transport_view_id) 
                                    values(
                                            @{nameof(Shipment.LvId)},@{nameof(Shipment.TimeSlotId)},@{nameof(Shipment.SDate)},@{nameof(Shipment.SComment)},@{nameof(Shipment.OComment)},
                                            @{nameof(Shipment.GateId)},@{nameof(Shipment.SpCondition)},@{nameof(Shipment.DriverPhone)},@{nameof(Shipment.DriverFio)},
                                            @{nameof(Shipment.VehicleNumber)},@{nameof(Shipment.TrailerNumber)},@{nameof(Shipment.AttorneyNumber)},@{nameof(Shipment.AttorneyDate)},
                                            @{nameof(Shipment.SubmissionTime)},@{nameof(Shipment.StartTime)},@{nameof(Shipment.EndTime)},@{nameof(Shipment.LeaveTime)},
                                            @{nameof(Shipment.DelayReasonsId)},@{nameof(Shipment.DelayComment)},@{nameof(Shipment.DepositorId)},@{nameof(Shipment.IsCourier)},
                                            @{nameof(Shipment.ForwarderFio)},@{nameof(Shipment.StampNumber)},@{nameof(Shipment.AttorneyIssued)},@{nameof(Shipment.ShIn)},
                                            @{nameof(Shipment.SpecialTime)},@{nameof(Shipment.IsAddLv)},@{nameof(Shipment.TransportCompanyId)},@{nameof(Shipment.TransportTypeId)},
                                            @{nameof(Shipment.SupplierId)},@{nameof(Shipment.CustomPostId)},@{nameof(Shipment.WarehouseId)},@{nameof(Shipment.TransportViewId)}
                                        )";
                case EditState.Edit:
                    return $@"update {Table} set lv_id = @{nameof(Shipment.LvId)},time_slot_id = @{nameof(Shipment.TimeSlotId)},
                                            s_date = @{nameof(Shipment.SDate)},s_comment = @{nameof(Shipment.SComment)},o_comment = @{nameof(Shipment.OComment)},
                                            gate_id = @{nameof(Shipment.GateId)},sp_condition = @{nameof(Shipment.SpCondition)},driver_phone = @{nameof(Shipment.DriverPhone)},
                                            driver_fio = @{nameof(Shipment.DriverFio)},vehicle_number = @{nameof(Shipment.VehicleNumber)},trailer_number = @{nameof(Shipment.TrailerNumber)},
                                            attorney_number = @{nameof(Shipment.AttorneyNumber)},attorney_date = @{nameof(Shipment.AttorneyDate)},
                                            submission_time = @{nameof(Shipment.SubmissionTime)},start_time = @{nameof(Shipment.StartTime)},end_time = @{nameof(Shipment.EndTime)},
                                            leave_time = @{nameof(Shipment.LeaveTime)},delay_reasons_id = @{nameof(Shipment.DelayReasonsId)},delay_comment = @{nameof(Shipment.DelayComment)},
                                            depositor_id = @{nameof(Shipment.DepositorId)},is_courier = @{nameof(Shipment.IsCourier)},forwarder_fio = @{nameof(Shipment.ForwarderFio)},
                                            stamp_number = @{nameof(Shipment.StampNumber)},attorney_issued = @{nameof(Shipment.AttorneyIssued)},s_in = @{nameof(Shipment.ShIn)},
                                            special_time = @{nameof(Shipment.SpecialTime)},is_add_lv = @{nameof(Shipment.IsAddLv)},transport_company_id = @{nameof(Shipment.TransportCompanyId)},
                                            transport_type_id = @{nameof(Shipment.TransportTypeId)},supplier_id = @{nameof(Shipment.SupplierId)}, custom_post_id = @{nameof(Shipment.CustomPostId)}
                                            , warehouse_id = @{nameof(Shipment.WarehouseId)}, transport_view_id = @{nameof(Shipment.TransportViewId)}
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
	                    id as {nameof(Shipment.Id)}, lv_id as {nameof(Shipment.LvId)},time_slot_id as {nameof(Shipment.TimeSlotId)},
                        s_date as {nameof(Shipment.SDate)},s_comment as {nameof(Shipment.SComment)},o_comment as {nameof(Shipment.OComment)},
                        gate_id as {nameof(Shipment.GateId)},sp_condition as {nameof(Shipment.SpCondition)},
                        driver_phone as {nameof(Shipment.DriverPhone)},driver_fio as {nameof(Shipment.DriverFio)},vehicle_number as {nameof(Shipment.VehicleNumber)},
                        trailer_number as {nameof(Shipment.TrailerNumber)},attorney_number as {nameof(Shipment.AttorneyNumber)},attorney_date as {nameof(Shipment.AttorneyDate)},
                        submission_time as {nameof(Shipment.SubmissionTime)},start_time as {nameof(Shipment.StartTime)},end_time as {nameof(Shipment.EndTime)},
                        leave_time as {nameof(Shipment.LeaveTime)},delay_reasons_id as {nameof(Shipment.DelayReasonsId)},delay_comment as {nameof(Shipment.DelayComment)},
                        depositor_id as {nameof(Shipment.DepositorId)},is_courier as {nameof(Shipment.IsCourier)},forwarder_fio as {nameof(Shipment.ForwarderFio)},
                        stamp_number as {nameof(Shipment.StampNumber)},attorney_issued as {nameof(Shipment.AttorneyIssued)},s_in as {nameof(Shipment.ShIn)},
                        special_time as {nameof(Shipment.SpecialTime)},is_add_lv as {nameof(Shipment.IsAddLv)},transport_company_id as {nameof(Shipment.TransportCompanyId)},
                        transport_type_id as {nameof(Shipment.TransportTypeId)},supplier_id as {nameof(Shipment.SupplierId)},
                        custom_post_id as {nameof(Shipment.CustomPostId)},warehouse_id as {nameof(Shipment.WarehouseId)}, transport_view_id as {nameof(Shipment.TransportViewId)}
                    from 
	                    {Table}
                    ";
        }
    }
}
