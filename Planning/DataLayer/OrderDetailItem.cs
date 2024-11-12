using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class OrderDetailItem
    {
        public int ID { get; set; }
        public string PrimaryCode { get; set; }
        public string ShortDescription { get; set; }
        public decimal Quantity { get; set; }
        public int DetailType { get; set; }
    }
}
