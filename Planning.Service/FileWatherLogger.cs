using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

            watcher = new FileSystemWatcher(_settings.RootDirPath);
            watcher.Filter = _settings.FileType;
            
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            
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
            WatcherAction(FileSystemActionType.Created, e);
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
    }
}
