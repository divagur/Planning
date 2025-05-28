using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentLogDataAdapter : IDataAdaper
    {
        public string Table => "shipments";

        public string GetSaveSql(EditState editState)
        {
            

            return String.Empty;
        }

        public string GetSelectItemSql()
        {
			return $@"	select
					s.dml_id as {nameof(ShipmentLog.Id)},s.dml_type as as {nameof(ShipmentLog.DmlType)}, 
					case s.dml_type when 'I' then 'Создание' when 'U' then 'Изменение' when 'D' then 'Удаление' end as {nameof(ShipmentLog.DmlTypeName)},
					s.dml_date, s.dml_user_name, s.dml_comp_name, s.shipment_id, 
					(case isnull(s.sp_condition, 0) when 0 then ts.slot_time else s.special_time end) slot_time, s.s_date,
					s.s_comment, s.o_comment, g.name gate_name, s.sp_condition, s.driver_phone, s.driver_fio,  
					s.vehicle_number, s.trailer_number, s.attorney_number, s.attorney_date,
					s.submission_time, s.start_time, s.end_time, s.leave_time, dr.name AS delay_reason_name, s.delay_comment,
					s.depositor_id dep_id, s.is_courier, s.forwarder_fio,
					s.stamp_number,s.attorney_issued, 
					s.s_in, s.is_add_lv, tc.name tc_name, tt.name transport_type_name,
					d.name, d.lv_id dep_lv_id, d.lv_base dep_lv_db,


					0 FontColor,0 BackgroundColor,ROW_NUMBER() OVER(PARTITION BY s.shipment_id ORDER BY s.shipment_id, s.dml_date) AS log_num, N'вход' InOut
				 FROM            dbo.shipments_log AS s
							 join dbo.depositors d on s.depositor_id = d.id
							LEFT OUTER JOIN dbo.time_slot AS ts ON s.time_slot_id = ts.id
							LEFT OUTER JOIN dbo.gateways AS g ON s.gate_id = g.id
							LEFT OUTER JOIN dbo.delay_reasons AS dr ON s.delay_reasons_id = dr.id
							LEFT OUTER JOIN dbo.transport_company tc on s.transport_company_id = tc.id
							LEFT OUTER JOIN dbo.transport_type tt on s.transport_type_id = tt.id
				where
					cast(s.dml_date as date) >= @From and cast(s.dml_date as date) <= @Till
					and(@In = 1 or @In is NULL)
					and s.s_in = 1
					and s.shipment_id = isnull(@ShpID, s.shipment_id)
					and s.dml_user_name = isnull(@UserId, s.dml_user_name)";

            return $@"
                    select 
	                    {Table}.id as {nameof(Shipment.Id)}, lv_id as {nameof(Shipment.LvId)},time_slot_id as {nameof(Shipment.TimeSlotId)},
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
