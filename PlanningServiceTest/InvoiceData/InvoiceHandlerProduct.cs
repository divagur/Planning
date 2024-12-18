using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningServiceTest.InvoiceData
{
    public class InvoiceHandlerProduct: InvoiceHandler
    {

        public override Invoice LoadFromXml(string FileName)
        {

            return base.LoadFromXml(FileName);
        }
    }
}
