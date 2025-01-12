using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Planning.Service;
using PlanningServiceTest.InvoiceData;
using Planning.DataLayer;


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
            if (!String.IsNullOrEmpty(settings.FileInvoiceCustomMask) && fileName.Contains(settings.FileInvoiceCustomMask))
                return InvoiceType.Custom;
            else if (!String.IsNullOrEmpty(settings.FileInvoiceProductionMask) && fileName.Contains(settings.FileInvoiceProductionMask))
                return InvoiceType.Product;
            else
                return InvoiceType.Unknown;
        }

        static void InsertToDict(string connectionString)
        {
            CustomPost customPost = new CustomPost();
            CustomPostRepository customPostRepository = new CustomPostRepository(connectionString);
            customPost.Code = "444";
            customPost.Name = "Test";
            customPostRepository.Save(customPost);
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

            //logger = new Logger(settings);
            string connetionString = @"Data Source=ZDV\MSSQL2017DEV;Initial Catalog=Planning;Integrated Security=False;User ID=sysadm;Password=sysadm";

            //InsertToDict(connetionString);
            //return;


            LogHandler log = new LogHandler(@"D:\Temp\PlanningServices\FileProcessLog.xml", true);
            log.Open();

            //Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            //loggerThread.Start();
            InvoiceHandlerBase invoiceHandler = null ;
            Invoice invoice = null;
            foreach (var file in Directory.GetFiles(settings.InputFileDirPath))
            {
                string fileName = Path.GetFileName(file);
                string status = "Успешно";
                string error = "";
                string fileLogPath = "Файл удален";
                switch (GetFileType(fileName,settings))
                {
                    case InvoiceType.Product:
                        invoiceHandler = new InvoiceHandlerProductionN();
                        invoice = new InvoiceProduction();
                        //InvoiceProduction invoiceProduction = invoiceHandlerProduct.LoadFromXml(file);
                        break;
                    case InvoiceType.Custom:
                        invoiceHandler = new InvoiceHandlerCustomN();
                        invoice = new InvoiceCustom();
                        //InvoiceCustom invoiceCustom = invoiceHandlerCustom.LoadFromXml(file);
                        break;
                    case InvoiceType.Unknown:
                        break;
                    default:
                        break;
                }
                if (invoiceHandler == null)
                {
                    status = "Ошибка";
                    error = "Неизвестный тип файла";
                }
                else
                {
                    try
                    {
                        invoiceHandler?.LoadFromXml(file, invoice);
                    }
                    catch (Exception ex)
                    {
                        status = "Ошибка";
                        error = ex.Message;

                    }
                    /*
                    finally
                    {
                        if (!String.IsNullOrEmpty(settings.LogDirPath))
                        {
                            fileLogPath = Path.Combine(settings.LogDirPath, Path.GetFileName(file));
                            File.Move(file, fileLogPath);
                        }
                        else
                        {
                            File.Delete(file);
                        }
                        log.AddRow(Path.GetFileName(file), DateTime.Now, status, error, fileLogPath, true);
                    }
                    */
                    invoiceHandler.Save(invoice, connetionString);

                }
                
                
                
            } 
            

            

            //log.AddRow("file1", DateTime.Now, "Успешно", "", @"D:\Temp\PlanningServices\FileLogStorage", true);
            //log.AddRow("file2", DateTime.Now, "Ошибка", "НЕ верный формат файла", @"D:\Temp\PlanningServices\FileLogStorage", true);
        }
    }
}
