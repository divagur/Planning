using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using PlanningServiceTest.InvoiceData;

namespace Planning.Service
{
    enum FileSystemActionType
    {
        Renamed,
        Changed,
        Created,
        Deleted
    }
    enum InvoiceType
    {
        Product,
        Custom,
        Unknown
    }
    class Logger
    {
        FileSystemWatcher watcher;
        Settings _settings;
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

            watcher = new FileSystemWatcher(_settings.InputFileDirPath);
            watcher.Filter = _settings.FileType;
            
            //watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            //watcher.Changed += Watcher_Changed;
            //watcher.Renamed += Watcher_Renamed;
            
        }
        private InvoiceType GetFileType(string fileName)
        {
            if (fileName.Contains(_settings.FileInvoiceCustomMask))
                return InvoiceType.Custom;
            else if (fileName.Contains(_settings.FileInvoiceProductionMask))
                return InvoiceType.Product;
            else
                return InvoiceType.Unknown;
        }
        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        private bool IsFileMatching(string FileName)
        {
            
            string strFileExt = Path.GetExtension(FileName);
            FileInfo f = new FileInfo(FileName);
            return extensions.Contains(f.Extension);
            
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
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
            /*
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);*/
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            WatcherAction(FileSystemActionType.Changed, e);
            /*
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            
            RecordEntry(fileEvent, filePath);*/
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            WatcherAction(FileSystemActionType.Created,  e);
            InvoiceType invoiceType = GetFileType(e.Name);
            string status = "Успешно";
            string error = "";
            try
            {/*
                switch (invoiceType)
                {
                    case InvoiceType.Product:
                        InvoiceHandlerProduction invoiceHandlerProduct = new InvoiceHandlerProduction();
                        //InvoiceProduction invoiceProduction = invoiceHandlerProduct.LoadFromXml(e.Name);
                        break;
                    case InvoiceType.Custom:
                        InvoiceHandlerCustom invoiceHandlerCustom = new InvoiceHandlerCustom();
                        //InvoiceCustom invoiceCustom = invoiceHandlerCustom.LoadFromXml(e.Name);
                        break;
                    case InvoiceType.Unknown:
                        break;
                    default:
                        break;
                }*/
            }
            catch (Exception ex)
            {
                status = "Ошибка";
                error = ex.Message;
                throw;
            }


            byte[] body = File.ReadAllBytes(e.FullPath);
            AddFileToLog(e.Name, status, error, Convert.ToBase64String(body));

            //invoiceHandler.LoadFromXml(e.Name);

            //InvoiceHandler invoiceHandler = new InvoiceHandler();
            //invoiceHandler.Load(e.FullPath)

            /*
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);*/
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            WatcherAction(FileSystemActionType.Deleted, e);
            /*
            string fileEvent = "удален";
            string filePath = e.FullPath;
            
            File.Copy(filePath, _settings.LogDirPath+"\\"+e.Name, true);
            RecordEntry(fileEvent, filePath);*/

        }

        private void AddFileToLog(string FileName, string Status, string Error,string body )
        {
             
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

        private bool IsSettingsValid(out string ErrorMessage)
        {
            if (_settings.InputFileDirPath == String.Empty)
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
    }
}
