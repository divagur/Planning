using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlanningServiceTest.InvoiceData
{
    public class InvoiceHandlerCustomN:InvoiceHandlerBase
    {
        public override void LoadFromXml(string FileName, Invoice invoice)
        {
            try
            {
                base.LoadFromXml(FileName, invoice);
            }
            catch (Exception)
            {
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            ((InvoiceCustom)invoice).CustomsCode = xmlDoc.GetElementsByTagName("CustomsCode").Item(0).InnerText;

        }
        public override void Save(Invoice invoice)
        {
            base.Save(invoice);
        }
    }
    public class InvoiceHandlerCustomEx : InvoiceHandlerEx,  IInvoiceHandler<InvoiceCustom>
    {
        public void LoadFromXml(string FileName, InvoiceCustom invoice)

        {
            //InvoiceCustom invoice = base.LoadFromXml(FileName);
            //InvoiceCustom invoice = new InvoiceCustom();
            try
            {
                LoadBase(FileName, invoice);
            }
            catch (Exception)
            {
                return;                
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode docElement = xmlDoc.GetElementsByTagName("Document").Item(0);
            invoice.CustomsCode = xmlDoc.GetElementsByTagName("CustomsCode").Item(0).InnerText;

            //return invoice;
        }

        public void Save(InvoiceCustom invoice)
        {
            throw new NotImplementedException();
        }
    }
   public class InvoiceHandlerCustom:InvoiceHandler<InvoiceCustom>
    {
        public override InvoiceCustom LoadFromXml(string FileName)
            
        {
            InvoiceCustom invoice = base.LoadFromXml(FileName);
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
