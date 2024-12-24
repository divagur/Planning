using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks.DataLayer
{
	public class ShipmentMain : BaseObject
	{
		int? OrdID { get; set; }
		int? OrdLVID { get; set; }
		DateTime? ShpDate { get; set; }
		int? ShpSlotID { get; set; }
		TimeSpan? SlotTime { get; set; }
		bool? ShpIn { get; set; }
		string InOut { get; set; }
		string OrdLVCode { get; set; }
		string OrdPartLVCode { get; set; }
		int? ShpDepLVID { get; set; }
		string DepCode { get; set; }
		bool? ShpSpecialCond { get; set; }
		bool? ShpIsCourier { get; set; }
		int? ShpGateID { get; set; }
		string GateName { get; set; }
		string KlientName { get; set; }
		string OrderStatus { get; set; }
		string PrcReady { get; set; }
		decimal? DoneShare { get; set; }
		string ShpComment { get; set; }
		string OrdComment { get; set; }
		string ShpDriverPhone { get; set; }
		string ShpDriverFio { get; set; }
		string TransportCompanyName { get; set; }
		string TransportTypeName { get; set; }
		string ShpVehicleNumber { get; set; }
		string ShpTrailerNumber { get; set; }
		string ShpAttorneyNumber { get; set; }
		DateTime? ShpAttorneyDate { get; set; }
		DateTime? ShpSubmissionTime { get; set; }
		DateTime? ShpStartTime { get; set; }
		DateTime? ShpEndTimePlan { get; set; }
		DateTime? ShpEndTimeFact { get; set; }
		string ShpDelayReasonName { get; set; }
		string ShpDelayComment { get; set; }
		string ShpForwarderFio { get; set; }
		string OrdLVType { get; set; }
		string ShpStampNumber { get; set; }
		bool? IsAddLv { get; set; }
		int? ShippingPlacesNumber { get; set; }
		decimal? OrderWeight { get; set; }
		string ShpSupplierName { get; set; }
		int? FontColor { get; set; }
		int? BackgroundColor { get; set; }
		
    }
}
