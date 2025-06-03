using Planning.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.DataLayer
{
	public class ShipmentMain : BaseDataItem
	{
		public int? RowNumberRange { get; set; }
		public int? ShpId { get; set; }
		public int? OrdId { get; set; }
		public int? OrdLVID { get; set; }
		public DateTime? ShpDate { get; set; }
		public int? ShpSlotID { get; set; }
		public TimeSpan? SlotTime { get; set; }
		public bool? ShpIn { get; set; }
		public string InOut { get; set; }
		public string OrdLVCode { get; set; }
		public string OrdPartLVCode { get; set; }
		public int? ShpDepLVID { get; set; }
		public string DepCode { get; set; }
		public bool? ShpSpecialCond { get; set; }
		public bool? ShpIsCourier { get; set; } = false;
		public int? ShpGateID { get; set; }
		public string GateName { get; set; }
		public string KlientName { get; set; }
		public string OrderStatus { get; set; }
		public string PrcReady { get; set; }
		public decimal? DoneShare { get; set; }
		public string ShpComment { get; set; }
		public string OrdComment { get; set; }
		public string ShpDriverPhone { get; set; }
		public string ShpDriverFio { get; set; }
		public string TransportCompanyName { get; set; }
		public string TransportTypeName { get; set; }
        public string TransportViewName { get; set; }
        public string WarehouseName { get; set; }
        public string ShpVehicleNumber { get; set; }
		public string ShpTrailerNumber { get; set; }
		public string ShpAttorneyNumber { get; set; }
		public DateTime? ShpAttorneyDate { get; set; }
		public DateTime? ShpSubmissionTime { get; set; }
		public DateTime? ShpStartTime { get; set; }
		public DateTime? ShpEndTimePlan { get; set; }
		public DateTime? ShpEndTimeFact { get; set; }
		public string ShpDelayReasonName { get; set; }
		public string ShpDelayComment { get; set; }
		public string ShpForwarderFio { get; set; }
		public string OrdLVType { get; set; }
		public string ShpStampNumber { get; set; }
		public bool? IsAddLv { get; set; } = false;
		public bool? IsEdm { get; set; } = false;
		public int? ShippingPlacesNumber { get; set; }
		public decimal? OrderWeight { get; set; }
		public string ShpSupplierName { get; set; }
		public int? FontColor { get; set; }
		public int? BackgroundColor { get; set; }
		public string OrderDetailInit { get; set; } = "...";
		
    }
}
