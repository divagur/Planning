using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Planning.Service;
using PlanningServiceTest.InvoiceData;

namespace PlanningServiceTest
{
    class Program
    {
        enum InvoiceType
        {
            Product,
            Custom,
            Unknown
        }
        static InvoiceType GetFileType(string fileName, Settings settings)
        {
            if (fileName.Contains(settings.FileInvoiceCustomMask))
                return InvoiceType.Custom;
            else if (fileName.Contains(settings.FileInvoiceProductionMask))
                return InvoiceType.Product;
            else
                return InvoiceType.Unknown;
        }
        static void Main(string[] args)
        {
            Logger logger;
            Settings settings;
            SettingsHandle settingsHandle = new SettingsHandle("config.xml");

            settings = new Settings();
            settings.InputFileDirPath = settingsHandle.GetParamStringValue("InputFileDirPath");
            settings.LogDirPath = settingsHandle.GetParamStringValue("LogDirPath");
            settings.FileInvoiceCustomMask = settingsHandle.GetParamStringValue("FileInvoiceCustomMask");
            settings.FileInvoiceProductionMask = settingsHandle.GetParamStringValue("FileInvoiceProductionMask");
            logger = new Logger(settings);
            //Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            //loggerThread.Start();
            InvoiceHandler invoiceHandler = new InvoiceHandler();
            foreach (var file in Directory.GetFiles(settings.InputFileDirPath))
            {
                string fileName = Path.GetFileName(file);

                switch (GetFileType(fileName,settings))
                {
                    case InvoiceType.Product:
                        break;
                    case InvoiceType.Custom:
                        break;
                    case InvoiceType.Unknown:
                        break;
                    default:
                        break;
                }
                Invoice invoice = invoiceHandler.LoadFromXml(file);

                LogHandler log = new LogHandler(@"D:\Temp\PlanningServices",true);
            } 
            
        }
    }
}
