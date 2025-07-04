﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
   public class LVOrder
    {
		public int LVID { get; set; }
		public string LVCode { get; set; }
		public string LVStatus { get; set; }
		public DateTime? ExpDate { get; set; }
		public string Company { get; set; }
		public DateTime? InputDate { get; set; }
		public int? DepLVID { get; set; }
		public int? OstID { get; set; }
		public string OstCode { get; set; }
		public int LVShipmentID { get; set; }
		public bool? IsEdm { get; set; }
		public string OperatorComment { get; set; }
		public string WarehouseComment { get; set; }

	}
}
