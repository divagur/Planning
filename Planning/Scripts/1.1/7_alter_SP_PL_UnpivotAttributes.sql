USE [Planning]
GO

ALTER procedure [dbo].[SP_PL_UnpivotAttributes]
	@LdgIDs	T_PL_ID readonly
/*
Version: 1.3
*/
as
begin

	select distinct lv_base, lv_order_id,s_in,lva_use_ord_attr,lva_attr_lv_id, attr_value, so.id
	from 

(
	select
		shp_id,s_in, dep_lv_id,
		convert(varchar(64),s_date, 104) s_date,
		convert(varchar(64),slot_time,108) slot_time,
		cast(klient as varchar(64)) klient, 
		cast(order_status as varchar(64)) order_status, 
		cast(s_comment as varchar(64)) s_comment, 
		cast(o_comment as varchar(64)) o_comment,
		cast(gate_name as varchar(64)) gate_name, 
		cast(driver_fio as varchar(64)) driver_fio, 
		cast(driver_phone as varchar(64)) driver_phone,
		cast(transport_company as varchar(64)) transport_company, 
		cast(vehicle_number as varchar(64)) vehicle_number, 
		cast(trailer_number as varchar(64)) trailer_number, 
		cast(attorney_number as varchar(64)) attorney_number, 
		convert(varchar(64),attorney_date, 104) attorney_date, 
		cast(attorney_issued as varchar(64)) attorney_issued,
		cast(stamp_number as varchar(64)) stamp_number,
		convert(varchar(64),submission_time,108) submission_time,  
		convert(varchar(64),start_time,108) start_time,
		convert(varchar(64),end_time,108) end_time,
		convert(varchar(64),leave_time,108) leave_time,
		cast(delay_reason_name as varchar(64)) delay_reason_name,
		cast(delay_comment as varchar(64)) delay_comment,
		cast(forwarder_fio as varchar(64)) forwarder_fio,
		cast(tc_name as varchar(64)) tc_name,
		cast(transport_type_name as varchar(64)) transport_type_name
	from  v_shipments
	where
		shp_id in (select ID from @LdgIDs)
) sh
unpivot
	(
		attr_value for attr_name in (
		s_date,
		slot_time, 
		klient, order_status, s_comment, o_comment, gate_name, driver_fio, driver_phone,
		transport_company, vehicle_number, trailer_number, attorney_number, attorney_date,attorney_issued,stamp_number, submission_time, start_time,
		end_time, leave_time,delay_reason_name,delay_comment,forwarder_fio,tc_name,transport_type_name )
	) as attr_unpivot
	join shipment_orders so on so.shipment_id = shp_id and so.lv_order_id is not null 
	join depositors d on d.lv_id = dep_lv_id and d.lv_base is not NULL
	join (lv_attr lva join shipment_element se on (lva.pl_elem_id = se.id)) 
	on (se.field_db_name = attr_name and pl_dep_id = d.id and lva_In = s_in)
	--join lv_attr lva on lva.lva_field = attr_name and lva_DB = lv_base and lva_In = s_in;


	return 0;

end
