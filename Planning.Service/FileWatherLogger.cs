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
    enum FileSystemActionType
    {
        Renamed,
        Changed,
        Created,
        Deleted
    }

    class Logger
    {
        FileSystemWatcher watcher;
        System.Timers.Timer watchTimer;
        Settings _settings;
        string _connetionString;
        LogHandler log;
        object obj = new object();
        bool enabled = true;
        string[] extensions;
        public Logger(Settings Settings)
        {
            _settings = Settings;

            string settingVaildError = "";
            /*if (!IsSettingsValid(out settingVaildError))
            {
                MessageBox.Show(settingVaildError);
                //throw new Exception(settingVaildError);

            }*/
            if (_settings.FileType != "*")
                extensions = _settings.FileType.Split(new char[] { ';' });
            /*
            watcher = new FileSystemWatcher(_settings.RootDirPath);
            watcher.Filter = _settings.FileType;
            
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            */
            watchTimer = new System.Timers.Timer();
            watchTimer.Interval = _settings.TimerInterval;
            watchTimer.Elapsed += WatchTimer_Elapsed;

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = _settings.ServerName;
            sqlConnectionStringBuilder.InitialCatalog = _settings.PlanningBaseName;
            sqlConnectionStringBuilder.UserID = _settings.PlanningBaseLogin;
            sqlConnectionStringBuilder.Password = _settings.PlanningBasePwd;

            _connetionString = sqlConnectionStringBuilder.ToString();
            log = new LogHandler(Path.Combine(_settings.LogDirPath, "FileProcessLog.xml"), false);
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
            InvoiceHandlerBase invoiceHandler = null;
            Invoice invoice = null;
  
            foreach (var file in Directory.GetFiles(_settings.InputFileDirPath))
            {
                string fileName = Path.GetFileName(file);
                string status = "Успешно";
                string error = "";
                string fileLogPath = "Файл удален";
                switch (GetFileType(fileName, _settings))
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

                    invoiceHandler.Save(invoice, _connetionString);

                }



            }

        }
        

        public void Start()
        {
            /*
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
            */
            watchTimer.Start();
        }

        private bool IsFileMatching(string FileName)
        {
            
            string strFileExt = Path.GetExtension(FileName);
            FileInfo f = new FileInfo(FileName);
            return extensions.Contains(f.Extension);
            
        }
        public void Stop()
        {
            /*
            watcher.EnableRaisingEvents = false;
            enabled = false;
            */
            watchTimer.Stop();
        }

        private void WatcherAction(FileSystemActionType systemActionType, FileSystemEventArgs e)
        {
            if (!IsFileMatching(e.FullPath))
                return;
            string fileEvent = "";
            string filePath = e.FullPath;
            switch (systemActionType)
                {
                    case FileSystemActionType.Renamed:
                        fileEvent = "переименован в " + e.FullPath;
                        filePath =((RenamedEventArgs)e).OldFullPath;
                        break;
                    case FileSystemActionType.Changed:
                        fileEvent = "изменен";
                        break;
                    case FileSystemActionType.Created:
                        fileEvent = "создан";
                        break;
                    case FileSystemActionType.Deleted:
                        fileEvent = "удален";
                        break;
                    default:
                        break;
                }

            RecordEntry(fileEvent, filePath);
        }
        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            WatcherAction(FileSystemActionType.Renamed, e);
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            WatcherAction(FileSystemActionType.Changed, e);
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            WatcherAction(FileSystemActionType.Created, e);
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            WatcherAction(FileSystemActionType.Deleted, e);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(_settings.LogDirPath+"\\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
        /*
        private bool IsSettingsValid(out string ErrorMessage)
        {
            if (_settings.RootDirPath == String.Empty)
            {
                ErrorMessage =  "Не задан корневой каталог для отслеживания";
                return false;
            }

            if (_settings.LogDirPath == String.Empty)
            {
                ErrorMessage = "Не задан каталог для журнала";
                return false;
            }

            if (_settings.FileType == String.Empty)
            {
                ErrorMessage = "Не заданы типы файлов для отслеживания";
                return false;
            }


            ErrorMessage = string.Empty;
            return true;
        }
        */
    }
}
