using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningServiceTest.InvoiceData
{
    public class InvoiceProduction:Invoice
    {
        public string SupplierCode { get; set; }
        public int SupplierDeliveryDay { get; set; } = 0;
    }
}
