
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Planning.DataLayer;

namespace Planning.Service.InvoiceData
{
    public class InvoiceHandlerBase
    {
        public virtual void LoadFromXml(string FileName, Invoice invoice, string DeliveryTypeDefault)
        {

            try
            {

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                if (!IsXmlValid(xmlDocument))
                {
                    return;
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
                        case "RecipientCode": invoice.RecipientCode = elem.InnerText; break;
                        case "DeliveryType": invoice.DeliveryType = String.IsNullOrEmpty(elem.InnerText) ? DeliveryTypeDefault : elem.InnerText; break;
                        case "ContainerNumber": invoice.ContainerNumber = elem.InnerText; break;
                        case "TruckNumber": invoice.TruckNumber = elem.InnerText; break;
                        case "TrailerNumber": invoice.TrailerNumber = elem.InnerText; break;
                        case "Driver": invoice.Driver = elem.InnerText; break;
                        //case "SupplierCode": invoice.SupplierCode = elem.InnerText; break;
                        //case "CustomsCode": invoice.CustomsCode = elem.InnerText; break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



        }
        public virtual void Save(Invoice invoice, string connectionString)
        {
            ShipmentInvoiceRepository shipmentInvoiceRepository = new ShipmentInvoiceRepository(connectionString);
            ShipmentInvoice shipmentInvoice = new ShipmentInvoice();
            shipmentInvoice.ShpId = invoice.ShpId;
            shipmentInvoice.CreateDate = invoice.InvoiceDate;
            shipmentInvoice.ActualDate = invoice.ActualDate;
            shipmentInvoice.Number = invoice.InvoiceNumber;
            shipmentInvoice.InvoiceType = invoice.InvoiceType;
            shipmentInvoice.RecipientCode = invoice.RecipientCode;
            shipmentInvoice.DeliveryType = invoice.DeliveryType;
            shipmentInvoice.Status = invoice.Status;
            shipmentInvoice.Error = invoice.Error;
            shipmentInvoice.ContainerNumber = invoice.ContainerNumber;
            shipmentInvoice.TruckNumber = invoice.TruckNumber;
            shipmentInvoice.TrailerNumber = invoice.TrailerNumber;
            shipmentInvoice.Driver = invoice.Driver;

            if (invoice is InvoiceCustom)
            {
                shipmentInvoice.CustomsCode = (invoice as InvoiceCustom).CustomsCode;
            }
            else if (invoice is InvoiceProduction)
            {
                shipmentInvoice.SupplierCode = (invoice as InvoiceProduction).SupplierCode;
                shipmentInvoice.SupplierDeliveryDay = (invoice as InvoiceProduction).SupplierDeliveryDay;
            }

            shipmentInvoiceRepository.Save(shipmentInvoice);

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
         
    public class InvoiceHandlerEx
    {
        protected void LoadBase(string FileName, Invoice invoice)
        {
          
            try
            {

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                if (!IsXmlValid(xmlDocument))
                {
                    return;
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
                        case "RecipientCode": invoice.RecipientCode = elem.InnerText; break;
                        case "DeliveryType": invoice.DeliveryType = elem.InnerText; break;
                        case "ContainerNumber": invoice.ContainerNumber = elem.InnerText; break;
                        case "TruckNumber": invoice.TruckNumber = elem.InnerText; break;
                        case "TrailerNumber": invoice.TrailerNumber = elem.InnerText; break;
                        case "Driver": invoice.Driver = elem.InnerText; break;
                        //case "SupplierCode": invoice.SupplierCode = elem.InnerText; break;
                        //case "CustomsCode": invoice.CustomsCode = elem.InnerText; break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



        }
        public virtual void Load(string FileName, Invoice invoice)
        {

            try
            {

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(FileName);
                if (!IsXmlValid(xmlDocument))
                {
                    return;
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
                        case "RecipientCode": invoice.RecipientCode = elem.InnerText; break;
                        case "DeliveryType": invoice.DeliveryType = elem.InnerText; break;
                        case "ContainerNumber": invoice.ContainerNumber = elem.InnerText; break;
                        case "TruckNumber": invoice.TruckNumber = elem.InnerText; break;
                        case "TrailerNumber": invoice.TrailerNumber = elem.InnerText; break;
                        case "Driver": invoice.Driver = elem.InnerText; break;
                        //case "SupplierCode": invoice.SupplierCode = elem.InnerText; break;
                        //case "CustomsCode": invoice.CustomsCode = elem.InnerText; break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
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

    public class InvoiceHandler<T>
        where T:Invoice, new()
    {


        public virtual T LoadFromXml(string FileName)
        {
            T invoice = new T();
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
                        case "RecipientCode": invoice.RecipientCode = elem.InnerText; break;
                        case "DeliveryType": invoice.DeliveryType = elem.InnerText; break;
                        case "ContainerNumber": invoice.ContainerNumber = elem.InnerText; break;
                        case "TruckNumber": invoice.TruckNumber = elem.InnerText; break;
                        case "TrailerNumber": invoice.TrailerNumber = elem.InnerText; break;
                        case "Driver": invoice.Driver = elem.InnerText; break;
                        //case "SupplierCode": invoice.SupplierCode = elem.InnerText; break;
                        //case "CustomsCode": invoice.CustomsCode = elem.InnerText; break;
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
