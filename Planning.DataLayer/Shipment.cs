using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
    public class Shipment:BaseObject
    {
        public Nullable<int> LvId { get; set; }
        public Nullable<int> TimeSlotId { get; set; }
        public Nullable<System.DateTime> SDate { get; set; }
        public string SComment { get; set; }
        public string OComment { get; set; }
        public Nullable<int> GateId { get; set; }
        public Nullable<bool> SpCondition { get; set; }
        public string DriverPhone { get; set; }
        public string DriverFio { get; set; }
        public string VehicleNumber { get; set; }
        public string TrailerNumber { get; set; }
        public string AttorneyNumber { get; set; }
        public Nullable<System.DateTime> AttorneyDate { get; set; }
        public Nullable<System.DateTime> SubmissionTime { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<int> DelayReasonsId { get; set; }
        public string DelayComment { get; set; }
        public Nullable<int> DepositorId { get; set; }
        public Nullable<bool> IsCourier { get; set; }
        public string ForwarderFio { get; set; }
        public string StampNumber { get; set; }
        public string AttorneyIssued { get; set; }
        public Nullable<bool> ShIn { get; set; }
        public Nullable<System.TimeSpan> SpecialTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> LeaveTime { get; set; }
        public Nullable<bool> IsAddLv { get; set; }
        public Nullable<int> TransportCompanyId { get; set; }
        public Nullable<int> TransportTypeId { get; set; }
    }
}
