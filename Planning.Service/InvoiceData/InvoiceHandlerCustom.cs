using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Planning.DataLayer;

namespace Planning.Service.InvoiceData
{
    public class InvoiceHandlerCustom:InvoiceHandlerBase
    {
        public override void LoadFromXml(string FileName, Invoice invoice, string DeliveryTypeDefault)
        {
            try
            {
                base.LoadFromXml(FileName, invoice, DeliveryTypeDefault);
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

            shipment.SDate = invoiceCustom.ActualDate;

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
                    shipment.SDate = invoiceCustom.ActualDate.AddHours(deliveryPeriod.DeliveryDay);
                }
                
                
            }
            
            shipment.ShIn = true;
            shipment.DepositorId = 1;
            shipment.IsAddLv = false;
            shipment.TrailerNumber = invoiceCustom.TrailerNumber;
            shipment.VehicleNumber = invoiceCustom.TruckNumber;
            shipment.DriverFio = invoiceCustom.Driver;
            shipment.WarehouseId = Common.GetWarehouseId(invoiceCustom.RecipientCode, connectionString);
            shipment.TransportViewId = Common.GetTransportViewId(invoiceCustom.DeliveryType, connectionString);

            var lvId = shipmentOrderRepository.GetLvIdByCode(invoice.InvoiceNumber);
            if (lvId != null)
            {
                shipmentOrder.LvOrderId = lvId;
                shipmentOrder.IsBinding = true;
                shipment.IsAddLv = true;
            }

            shipmentRepository.Save(shipment);



            shipmentOrder.ShipmentId = shipment.Id;
            shipmentOrder.LvOrderCode = invoice.InvoiceNumber;
            shipmentOrder.OrderId = invoice.InvoiceNumber;
            

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

  
}
