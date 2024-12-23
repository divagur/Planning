﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlanningServiceTest.InvoiceData
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
            ((InvoiceProduction)invoice).RecipientCode = xmlDoc.GetElementsByTagName("RecipientCode").Item(0).InnerText;

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
