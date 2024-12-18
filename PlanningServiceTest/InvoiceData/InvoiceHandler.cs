using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlanningServiceTest.InvoiceData
{
    public class InvoiceHandler
    //    where T:Invoice, new()
    {
        public InvoiceHandler()
        {

        }

        public virtual Invoice LoadFromXml(string FileName)
        {
            Invoice invoice = new Invoice();
            try
            {
               
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                if (!IsXmlValid(xmlDocument))
                {
                    return null;
                }

                XmlNode docElement = xmlDocument.GetElementsByTagName("Document").Item(0);
                invoice.InvoiceDate = DateTime.Parse(docElement.Attributes["Date"].Value);
                invoice.InvoiceType = docElement.Attributes["Type"].Value;
                invoice.InvoiceNumber = docElement.Attributes["Number"].Value;
                foreach (XmlElement elem in docElement.ChildNodes)
                {
                    switch (elem.Name)
                    {
                        case "Status": invoice.Status = elem.InnerText; break;
                        case "ActualDate": invoice.ActualDate = DateTime.Parse(elem.InnerText); break;
                        case "RecipientCode": invoice.RecipientCode = Int32.Parse(elem.InnerText); break;
                        case "DeliveryType": invoice.DeliveryType = elem.InnerText; break;
                        case "ContainerNumber": invoice.ContainerNumber = elem.InnerText; break;
                        case "TruckNumber": invoice.TruckNumber = elem.InnerText; break;
                        case "TrailerNumber": invoice.TrailerNumber = elem.InnerText; break;
                        case "Driver": invoice.Driver = elem.InnerText; break;
                        case "SupplierCode": invoice.SupplierCode = elem.InnerText; break;
                        case "CustomsCode": invoice.CustomsCode = elem.InnerText; break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            

            return invoice;
        }
        private bool IsXmlValid(XmlDocument xmlDoc)
        {
            bool result = true;
            XmlNode xmlNode = xmlDoc.DocumentElement;
            if (xmlNode.Name != "WarehouseDataExchange")
            {
                result = false;
            }
            return result;
        }
    }
}
