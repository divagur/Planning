using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{

    public class Shipment
    {
        public int id { get; set; }
        public int lv_id { get; set; }
        public int time_slot_id { get; set; }
        public DateTime s_date { get; set; }
        public string s_comment { get; set; }
        public string o_comment { get; set; }
	    public int gate_id { get; set; }
	    public bool sp_condition { get; set; }
    	public string driver_phone { get; set; }
        public string driver_fio { get; set; }
	    public string vehicle_number { get; set; }
	    public string trailer_number { get; set; }
	    public string attorney_number { get; set; }
        public string attorney_issued { get; set; }
        public DateTime attorney_date { get; set; }
	    public DateTime submission_time { get; set; }
        public DateTime	start_time { get; set; }
    	public DateTime end_time_plan { get; set; }
    	public DateTime end_time_fact { get; set; }
    	public int delay_reasons_id { get; set; }
    	public string delay_comment { get; set; }
        public int depositor_id { get; set; }
        public bool is_courier { get; set; }
        public string forwarder_fio { get; set; }
        public string stamp_number { get; set; }
    }
}
