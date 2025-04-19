using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Planning.Service.InvoiceData;

namespace Planning.Service
{
    class Logger
    {
        System.Timers.Timer watchTimer;
        Settings _settings;
        string _connetionString;
        LogHandler log;
        object obj = new object();
        string[] extensions;
        public Logger(Settings Settings)
        {
            _settings = Settings;

            string settingVaildError = "";

            if (_settings.FileType != "*")
                extensions = _settings.FileType.Split(new char[] { ';' });

            watchTimer = new System.Timers.Timer();
            watchTimer.Interval = _settings.TimerInterval;
            watchTimer.Elapsed += WatchTimer_Elapsed;

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = _settings.ServerName;
            sqlConnectionStringBuilder.InitialCatalog = _settings.PlanningBaseName;
            sqlConnectionStringBuilder.UserID = _settings.PlanningBaseLogin;
            sqlConnectionStringBuilder.Password = _settings.PlanningBasePwd;

            _connetionString = sqlConnectionStringBuilder.ToString();
            AddEventToLog("EVENT Logger", "Подключение к файлу лога");
            log = new LogHandler(Path.Combine(_settings.RootPath, "FileProcessLog.xml"), false);
            log.Open();
        }

        private InvoiceType GetFileType(string fileName, Settings settings)
        {
            if (!String.IsNullOrEmpty(settings.FileInvoiceCustomMask) && fileName.Contains(settings.FileInvoiceCustomMask))
                return InvoiceType.Custom;
            else if (!String.IsNullOrEmpty(settings.FileInvoiceProductionMask) && fileName.Contains(settings.FileInvoiceProductionMask))
                return InvoiceType.Product;
            else
                return InvoiceType.Unknown;
        }
        private void WatchTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

  
            foreach (var file in Directory.GetFiles(_settings.InputFileDirPath))
            {
                string fileName = Path.GetFileName(file);
                string status = "Успешно";
                string error = "";
                string fileLogPath = "Файл удален";
                InvoiceHandlerBase invoiceHandler = null;
                Invoice invoice = null;
                string invoiceType = "";
                switch (GetFileType(fileName, _settings))
                {
                    case InvoiceType.Product:
                        invoiceHandler = new InvoiceHandlerProduction();
                        invoice = new InvoiceProduction();
                        invoiceType = "InvoiceTimeSlot";
                        //InvoiceProduction invoiceProduction = invoiceHandlerProduct.LoadFromXml(file);
                        break;
                    case InvoiceType.Custom:
                        invoiceHandler = new InvoiceHandlerCustom();
                        invoice = new InvoiceCustom();
                        invoiceType = "InvoiceCustom";
                        //InvoiceCustom invoiceCustom = invoiceHandlerCustom.LoadFromXml(file);
                        break;
                    case InvoiceType.Unknown:
                        continue;
                    default:
                        break;
                }
                if (invoiceHandler == null)
                {
                    status = "Ошибка";
                    error = "Неизвестный тип файла";
                    AddDebugEvent($"Ошибка при обработке файла {file}  - {error}");

                }
                else
                {
                    try
                    {

                        AddDebugEvent($"Обработка файла {file}  с типом {invoiceType}");
                        invoiceHandler?.LoadFromXml(file, invoice, _settings.DeliveryTypeDefault);
                    }
                    catch (Exception ex)
                    {
                        status = "Ошибка";
                        error = ex.Message;
                        AddDebugEvent($"Ошибка при обработке файла {file} - {ex.Message}");

                    }

                    finally
                    {
                        if (!String.IsNullOrEmpty(_settings.LogDirPath))
                        {
                            fileLogPath = Path.Combine(_settings.LogDirPath,String.Format("{0}_{1}{2}",
                                        Path.GetFileNameWithoutExtension(file), DateTime.Now.ToString("ddMMyyyyhhmmss"), Path.GetExtension(file)));
                            AddDebugEvent($"Перемещение файла {file} в каталог {fileLogPath}");
                            try
                            {
                                File.Move(file, fileLogPath);
                                //File.Copy(file, fileLogPath, true);
                            }
                            catch (Exception ex)
                            {

                                AddDebugEvent($"Ошибка при перемещении файла {file} - {ex.Message}");
                            }
                            
                            AddDebugEvent($"Файла {file} перемещен");
                        }
                        else
                        {
                            AddDebugEvent($"Удаление файла {file} из входящего каталога каталога");
                            try
                            {
                                File.Delete(file);
                            }
                            catch (Exception ex)
                            {

                                AddDebugEvent($"Ошибка при удалении файла {file} - {ex.Message}");
                            }
                            
                            AddDebugEvent($"Файла {file} удален");
                        }
                        log.AddRow(Path.GetFileName(file), DateTime.Now, status, error, fileLogPath, true);
                    }
                    AddDebugEvent($"Сохранение инвойса из файла {file} в базу данных");
                    invoiceHandler.Save(invoice, _connetionString);
                    AddDebugEvent($"Инвойса из файла {file} сохранен");
                }



            }

        }
        
        private void AddDebugEvent(string eventMessage)
        {
            if (_settings.DebugFileProcessing != 1)
            {
                return;

            }
            Common.AddEventToLog("EVENT_FILE_PROSEEING", eventMessage);
        }
        public void Start()
        {
            
            watchTimer.Start();
        }

        public void Stop()
        {
            
          
            watchTimer.Stop();
        }

       
       
        private void AddEventToLog(string eventLog, string descr)
        {
            
            using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory,"PlanningServieLog.txt"), true))
            {
                writer.WriteLine(String.Format("[{0}][{1}]: {2}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), eventLog, descr));
                writer.Flush();
            }
        }
       
    }
}
