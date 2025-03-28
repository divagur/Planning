﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Planning.DataLayer;

namespace Planning.Service.InvoiceData
{
    public class InvoiceHandlerProductionN : InvoiceHandlerBase
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
            ((InvoiceProduction)invoice).SupplierCode = xmlDoc.GetElementsByTagName("SupplierCode").Item(0).InnerText;
            ((InvoiceProduction)invoice).SupplierDeliveryDay = Int32.Parse(xmlDoc.GetElementsByTagName("SupplierDeliveryDay").Item(0).InnerText);
            ((InvoiceProduction)invoice).ShippingСompany = Int32.Parse(xmlDoc.GetElementsByTagName("ShippingСompany").Item(0).InnerText);
        }

        public override void Save(Invoice invoice, String connectionString)
        {
           
            InvoiceProduction invoiceProduction = (InvoiceProduction)invoice;

            ShipmentRepository shipmentRepository = new ShipmentRepository(connectionString);
            Shipment shipment = null;

            ShipmentOrderRepository shipmentOrderRepository = new ShipmentOrderRepository(connectionString);
            ShipmentOrder shipmentOrder = shipmentOrderRepository.GetByLvCode(invoiceProduction.InvoiceNumber);

            if (shipmentOrder == null)
            {
                shipment = new Shipment();
                shipmentOrder = new ShipmentOrder();
            }
            else
            {
                shipment = shipmentRepository.GetById((int)shipmentOrder.ShipmentId);
            }
            shipment.SDate = invoiceProduction.ActualDate.AddDays(invoiceProduction.SupplierDeliveryDay);
            shipment.ShIn = true;
            shipment.DepositorId = 1;
            shipment.IsAddLv = false;
            shipment.TrailerNumber = invoiceProduction.TrailerNumber;
            shipment.VehicleNumber = invoiceProduction.TruckNumber;
            shipment.DriverFio = invoiceProduction.Driver;           
            shipment.WarehouseId = Common.GetWarehouseId(invoiceProduction.RecipientCode, connectionString);
            shipment.TransportViewId = Common.GetTransportViewId(invoiceProduction.DeliveryType, connectionString);
            shipment.TransportCompanyId = Common.GetTransportCompanyId(invoiceProduction.ShippingСompany, connectionString);


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

            invoice.ShpId = (int)shipment.Id;
            base.Save(invoice, connectionString);

        }

        

    }

    

    public class InvoiceHandlerProductionEx : InvoiceHandlerCustomEx,  IInvoiceHandler<InvoiceProduction>
    {

        public void LoadFromXml(string FileName, InvoiceProduction Invoice)
        {
            InvoiceProduction invoiceProduction = new InvoiceProduction();
            try
            {
                LoadBase(FileName, invoiceProduction);
            }
            catch (Exception)
            {
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FileName);
            XmlNode docElement = xmlDoc.GetElementsByTagName("Document").Item(0);
            invoiceProduction.RecipientCode = xmlDoc.GetElementsByTagName("RecipientCode").Item(0).InnerText;


            //return invoiceProduction;
        }

        public void Save(InvoiceProduction Invoice)
        {
            throw new NotImplementedException();
        }
    }
}
