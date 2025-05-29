using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Kernel;

namespace Planning.DataLayer
{
    public class ShipmentLogViewDataAdapter : IDataAdaper
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
					s.dml_date as {nameof(ShipmentLog.DmlDate)}, s.dml_user_name as {nameof(ShipmentLog.DmlUserName)}, s.dml_comp_name as {nameof(ShipmentLog.DmlCompName)}, 
					s.shipment_id as {nameof(ShipmentLog.ShipmentId)},
					(case isnull(s.sp_condition, 0) when 0 then ts.slot_time else s.special_time end) slot_time as {nameof(ShipmentLog.TimeSlot)}, 
					s.s_date as {nameof(ShipmentLog.DmlTypeName)}, s.s_comment as {nameof(ShipmentLog.SComment)}, s.o_comment as {nameof(ShipmentLog.OComment)}, 
					g.name gate_name as {nameof(ShipmentLog.GateName)}, s.sp_condition  as {nameof(ShipmentLog.SpCondition)}, s.driver_phone as {nameof(ShipmentLog.DriverPhone)}, 
					s.driver_fio as {nameof(ShipmentLog.DriverFio)}, s.vehicle_number as {nameof(ShipmentLog.VehicleNumber)}, s.trailer_number as {nameof(ShipmentLog.TrailerNumber)}, 
					s.attorney_number as {nameof(ShipmentLog.AttorneyNumber)}, s.attorney_date as {nameof(ShipmentLog.AttorneyDate)},
					s.submission_time as {nameof(ShipmentLog.SubmissionTime)}, s.start_time as {nameof(ShipmentLog.StartTime)}, s.end_time as {nameof(ShipmentLog.EndTime)}, 
					s.leave_time as {nameof(ShipmentLog.LeaveTime)}, dr.name as {nameof(ShipmentLog.DelayReasonName)}, s.delay_comment as {nameof(ShipmentLog.DelayComment)},
					s.depositor_id dep_id as {nameof(ShipmentLog.DepositorId)}, s.is_courier as {nameof(ShipmentLog.IsCourier)}, s.forwarder_fio as {nameof(ShipmentLog.ForwarderFio)},
					s.stamp_number as {nameof(ShipmentLog.StampNumber)},s.attorney_issued as {nameof(ShipmentLog.AttorneyIssued)}, 
					s.s_in as {nameof(ShipmentLog.ShIn)}, s.is_add_lv as {nameof(ShipmentLog.IsAddLv)}, tc.name  as {nameof(ShipmentLog.TcName)}, 
					tt.name as {nameof(ShipmentLog.TransportTypeName)},	d.name as {nameof(ShipmentLog.DepositorName)}, 
					d.lv_id as {nameof(ShipmentLog.LvId)}, d.lv_base dep_lv_db as {nameof(ShipmentLog.DepLvDB)},
					splr.Name as {nameof(ShipmentLog.SupplierName)},cpst.Name as {nameof(ShipmentLog.CustomPostName)},
					wh.Name as {nameof(ShipmentLog.WarehouseName)},tw.Name as {nameof(ShipmentLog.TransportViewName)}


					0 FontColor,0 BackgroundColor,ROW_NUMBER() OVER(PARTITION BY s.shipment_id ORDER BY s.shipment_id, s.dml_date) AS log_num, N'вход' InOut
				 FROM            
							dbo.shipments_log AS s
							join dbo.depositors d on s.depositor_id = d.id
							LEFT OUTER JOIN dbo.time_slot AS ts ON s.time_slot_id = ts.id
							LEFT OUTER JOIN dbo.gateways AS g ON s.gate_id = g.id
							LEFT OUTER JOIN dbo.delay_reasons AS dr ON s.delay_reasons_id = dr.id
							LEFT OUTER JOIN dbo.transport_company tc on s.transport_company_id = tc.id
							LEFT OUTER JOIN dbo.transport_type tt on s.transport_type_id = tt.id
							LEFT OUTER JOIN dbo.suppliers splr on s.supplier_id = splr.id
							LEFT OUTER JOIN dbo.custom_posts cpst on s.custom_post_id = cpst.id
							LEFT OUTER JOIN dbo.warehouses wh on s.warehouse_id = wh.id
							LEFT OUTER JOIN dbo.transport_view tw wh on s.transport_view_id = tw.id";
        }
    }
}
