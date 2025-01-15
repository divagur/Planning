using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Planning.Service;
using PlanningServiceTest.InvoiceData;
using Planning.DataLayer;
using System.Data.SqlClient;

namespace PlanningServiceTest
{
    class Program
    {
        static Logger logger;
        static Settings _settings;
        static SettingsHandle settingsHandle = new SettingsHandle("PlanningServiceConfig.xml");

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
        protected static bool OnStart()
        {

            try
            {
                LoadSettings();
                if (!ValidateSettings())
                {                    
                    return false;
                }
                if (!TryDBConnect(_settings.ServerName, _settings.PlanningBaseName, _settings.PlanningBaseLogin, _settings.PlanningBasePwd))
                {
                    AddEventToLog("ERROR", "Не удалось подключиться к базе данных. Проверте настройки соединения");
                    return false;
                }
                logger = new Logger(_settings);
                Thread loggerThread = new Thread(new ThreadStart(logger.Start));
                loggerThread.Start();
                Console.WriteLine("Служба запущена");
                
            }
            catch (Exception ex)
            {

                AddEventToLog("ERROR", ex.Message);
            }
            return true;
        }

        protected static void OnStop()
        {
            logger.Stop();
            Console.WriteLine("Служба остановлена");
            Thread.Sleep(1000);
            
        }

        private static void LoadSettings()
        {
            _settings = new Settings();
            _settings.InputFileDirPath = settingsHandle.GetParamStringValue("InputFileDirPath");
            _settings.LogDirPath = settingsHandle.GetParamStringValue("LogDirPath");

            _settings.FileInvoiceCustomMask = settingsHandle.GetParamStringValue("FileInvoiceCustomMask");
            _settings.FileInvoiceProductionMask = settingsHandle.GetParamStringValue("FileInvoiceProductionMask");
            _settings.ServerName = settingsHandle.GetParamStringValue("ServerName");
            _settings.PlanningBaseName = settingsHandle.GetParamStringValue("PlanningBaseName");
            _settings.PlanningBaseLogin = settingsHandle.GetParamStringValue("PlanningBaseLogin");
            _settings.PlanningBasePwd = settingsHandle.GetParamStringValue("PlanningBasePwd");
            _settings.TimerInterval = settingsHandle.GetParamIntValue("TimerInterval", 60) * 1000;

        }

        private static bool TryDBConnect(string Server, string DB, string Login, string Pwd)
        {
            if (Server == null || DB == null || Login == null)
                return false;
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = Server;
            sqlConnectionStringBuilder.InitialCatalog = DB;
            sqlConnectionStringBuilder.UserID = Login;
            sqlConnectionStringBuilder.Password = Pwd;

            using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ToString()))
            {
                try
                {
                    connection.Open();

                }
                catch (SqlException ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }

            }
            return true;
        }
        private static void AddEventToLog(string eventLog, string descr)
        {
            using (StreamWriter writer = new StreamWriter("PlanningServieLog.txt", true))
            {
                writer.WriteLine(String.Format("[{0}][{1}]: {2}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), eventLog, descr));
                writer.Flush();
            }
        }
        private static bool ValidateSettings()
        {
            string error = "";
            if (String.IsNullOrEmpty(_settings.InputFileDirPath))
            {

                AddEventToLog("ERROR", "Не задан каталог входящих файлов");
                return false;
            }
            if (String.IsNullOrEmpty(_settings.FileInvoiceCustomMask) || String.IsNullOrEmpty(_settings.FileInvoiceProductionMask))
            {

                AddEventToLog("ERROR", "Не заданы шаблоны для поиска файлов инвойсов");
                return false;
            }
            if (String.IsNullOrEmpty(_settings.ServerName) || String.IsNullOrEmpty(_settings.PlanningBaseName) ||
                 String.IsNullOrEmpty(_settings.PlanningBaseLogin))
            {

                AddEventToLog("ERROR", "Не заданы параметры доступа к базе данных");
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            if (!OnStart())
                return;
            Console.ReadLine();
            OnStop();

/*
            _settings = new Settings();
            _settings.InputFileDirPath = settingsHandle.GetParamStringValue("InputFileDirPath");
            _settings.LogDirPath = settingsHandle.GetParamStringValue("LogDirPath");
            
            _settings.FileInvoiceCustomMask = settingsHandle.GetParamStringValue("FileInvoiceCustomMask");
            _settings.FileInvoiceProductionMask = settingsHandle.GetParamStringValue("FileInvoiceProductionMask");
            _settings.ServerName = settingsHandle.GetParamStringValue("ServerName");
            _settings.PlanningBaseName = settingsHandle.GetParamStringValue("PlanningBaseName");
            _settings.PlanningBaseLogin = settingsHandle.GetParamStringValue("PlanningBaseLogin");
            _settings.PlanningBasePwd = settingsHandle.GetParamStringValue("PlanningBasePwd");
            _settings.TimerInterval= settingsHandle.GetParamIntValue("TimerInterval")*1000;


            
            logger = new Logger(_settings);
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();

            
            string connetionString = @"Data Source=DZHURAVLEV;Initial Catalog=Planning_curr;Integrated Security=False;User ID=sysadm;Password=sysadm";
            LogHandler log = new LogHandler(@"D:\Temp\PlanningServices\FileProcessLog.xml", true);
            log.Open();

            InvoiceHandlerBase invoiceHandler = null ;
            Invoice invoice = null;
            
            foreach (var file in Directory.GetFiles(_settings.InputFileDirPath))
            {
                string fileName = Path.GetFileName(file);
                string status = "Успешно";
                string error = "";
                string fileLogPath = "Файл удален";
                switch (GetFileType(fileName,_settings))
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
                    
                    finally
                    {
                        if (!String.IsNullOrEmpty(_settings.LogDirPath))
                        {
                            fileLogPath = Path.Combine(_settings.LogDirPath, Path.GetFileName(file));
                            File.Move(file, fileLogPath);
                        }
                        else
                        {
                            File.Delete(file);
                        }
                        log.AddRow(Path.GetFileName(file), DateTime.Now, status, error, fileLogPath, true);
                    }
                    
                    invoiceHandler.Save(invoice, connetionString);

                }
                
                
                
            } 
            
    */


            //log.AddRow("file1", DateTime.Now, "Успешно", "", @"D:\Temp\PlanningServices\FileLogStorage", true);
            //log.AddRow("file2", DateTime.Now, "Ошибка", "НЕ верный формат файла", @"D:\Temp\PlanningServices\FileLogStorage", true);
        }
    }
}
