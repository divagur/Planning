using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlanningServiceTest.InvoiceData
{
    public class InvoiceHandlerCustom:InvoiceHandler
    {
        public override Invoice LoadFromXml(string FileName)
            
        {
            Invoice invoice = base.LoadFromXml(FileName);
            //InvoiceCustom invoiceCustom = (InvoiceCustom)invoice;
            if (invoice != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);
                XmlNode docElement = xmlDoc.GetElementsByTagName("Document").Item(0);
                invoice.CustomsCode = xmlDoc.GetElementsByTagName("CustomsCode").Item(0).InnerText;

            }
            
            return invoice;
        }
    }
}
