using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Planning.DataLayer;

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
        public override void Save(Invoice invoice, string connectionString)
        {
            InvoiceCustom invoiceCustom = (InvoiceCustom)invoice;

            ShipmentRepository shipmentRepository = new ShipmentRepository(connectionString);
            Shipment shipment = null;

            ShipmentOrderRepository shipmentOrderRepository = new ShipmentOrderRepository(connectionString);
            ShipmentOrder shipmentOrder = shipmentOrderRepository.GetByLvCode(invoiceCustom.InvoiceNumber);

            if (shipmentOrder == null)
            {
                shipment = new Shipment();
                shipmentOrder = new ShipmentOrder();
            }
            else
            {
                shipment = shipmentRepository.GetById((int)shipmentOrder.ShipmentId);
            }

            CustomPost customPost = GetCustomPostByCode(invoiceCustom.CustomsCode, connectionString);
            if (customPost == null)
            {
                invoice.Status = "Ошибка";
                invoice.Error = "Не найден код таможенного поста";
            }
            else
            {
                shipment.CustomPostId = customPost.Id;
                DeliveryPeriodRepository deliveryPeriodRepository = new DeliveryPeriodRepository(connectionString);
                DeliveryPeriod deliveryPeriod = deliveryPeriodRepository.GetByCode(invoiceCustom.CustomsCode, invoiceCustom.RecipientCode);
                if (deliveryPeriod == null)
                {
                    invoice.Status = "Ошибка";
                    invoice.Error = $"Не задан срок доставки от таможенного поста [{customPost.Name}] до склада";
                }
                else
                {
                    shipment.SDate = invoiceCustom.ActualDate.AddDays(deliveryPeriod.DeliveryDay);
                }
                
                
            }
            
            shipment.TrailerNumber = invoiceCustom.TrailerNumber;
            shipment.VehicleNumber = invoiceCustom.TruckNumber;
            shipment.DriverFio = invoiceCustom.Driver;
            

            shipmentRepository.Save(shipment);



            shipmentOrder.ShipmentId = shipment.Id;
            shipmentOrder.LvOrderCode = invoice.InvoiceNumber;
            var lvId = shipmentOrderRepository.GetLvIdByCode(invoice.InvoiceNumber);
            if (lvId != null)
            {
                shipmentOrder.LvOrderId = lvId;
                shipmentOrder.IsBinding = true;
            }

            shipmentOrderRepository.Save(shipmentOrder);

            invoice.ShpId = shipment.Id;
            base.Save(invoice, connectionString);
        }

        private CustomPost GetCustomPostByCode(string CustomPostCode, string connectionString)
        {
            CustomPostRepository customPostRepository = new CustomPostRepository(connectionString);
            CustomPost customPost = customPostRepository.GetByCode(CustomPostCode);
            return customPost;
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
