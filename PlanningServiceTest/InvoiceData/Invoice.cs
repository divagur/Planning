using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningServiceTest.InvoiceData
{
    public class Invoice
    {
        public string InvoiceType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime ActualDate { get; set; }
        public string RecipientCode { get; set; }
        public string DeliveryType { get; set; }
        public string ContainerNumber { get; set; }
        public string TruckNumber { get; set; }
        public string TrailerNumber { get; set; }
        public string Driver { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public int? ShpId { get; set; }
        //public string SupplierCode { get; set; }
        //public string CustomsCode { get; set; }
    }
}
