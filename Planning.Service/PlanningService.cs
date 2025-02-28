using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Planning.Service
{
    public partial class PlanningService : ServiceBase
    {
        Logger logger;
        Settings _settings;
        SettingsHandle settingsHandle;
        string _servicePath;
        public PlanningService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _servicePath = System.AppDomain.CurrentDomain.BaseDirectory;
            Common.AddEventToLog("EVENT", "Запуск службы");
            string configPath = Path.Combine(Common.ServicePath, "PlanningServiceConfig.xml");
            Common.AddEventToLog("EVENT", $"Загрузка настроек из файла {configPath}") ;
            settingsHandle = new SettingsHandle(configPath);
            LoadSettings();
                if (!ValidateSettings())
                {
                    Common.AddEventToLog("EVENT", "Проверка настроек не пройдена");
                    Stop();
                    return;
                }
                if (!TryDBConnect(_settings.ServerName, _settings.PlanningBaseName, _settings.PlanningBaseLogin, _settings.PlanningBasePwd))
                {
                    Common.AddEventToLog("ERROR", "Не удалось подключиться к базе данных. Проверте настройки соединения");
                    Stop();
                    return;
                }
                Common.AddEventToLog("EVENT", "Проверки пройдены");
            
            try
            {
                Common.AddEventToLog("EVENT", "Создание объекта Logger");
                logger = new Logger(_settings);
                Common.AddEventToLog("EVENT", "Создание потока выполнения");
                Thread loggerThread = new Thread(new ThreadStart(logger.Start));
                Common.AddEventToLog("EVENT", "Запуск потока выполнения");
                loggerThread.Start();
                Common.AddEventToLog("EVENT", "Поток запущен");
            }
            catch (Exception ex)
            {
                Stop();
                Common.AddEventToLog("ERROR", ex.Message);
            }

            
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
            Common.AddEventToLog("EVENT", "Служба остановлена");
        }

        private void LoadSettings()
        {
            _settings = new Settings();
            _settings.InputFileDirPath = settingsHandle.GetParamStringValue("InputFileDirPath");
            _settings.LogDirPath = settingsHandle.GetParamStringValue("LogDirPath");
            _settings.RootPath = settingsHandle.GetParamStringValue("RootPath", Common.ServicePath);
            _settings.FileInvoiceCustomMask = settingsHandle.GetParamStringValue("FileInvoiceCustomMask");
            _settings.FileInvoiceProductionMask = settingsHandle.GetParamStringValue("FileInvoiceProductionMask");
            _settings.ServerName = settingsHandle.GetParamStringValue("ServerName");
            _settings.PlanningBaseName = settingsHandle.GetParamStringValue("PlanningBaseName");
            _settings.PlanningBaseLogin = settingsHandle.GetParamStringValue("PlanningBaseLogin");
            _settings.PlanningBasePwd = settingsHandle.GetParamStringValue("PlanningBasePwd");
            _settings.TimerInterval = settingsHandle.GetParamIntValue("TimerInterval",60) * 1000;
            _settings.DebugFileProcessing = settingsHandle.GetParamIntValue("DebugFileProcessing", 0);
        }

        private bool TryDBConnect(string Server, string DB, string Login, string Pwd)
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
        private void AddEventToLogs(string eventLog, string descr)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(_servicePath,"PlanningServieLog.txt"), true))
            {
                writer.WriteLine(String.Format("[{0}][{1}]: {2}",
                    DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), eventLog, descr));
                writer.Flush();
            }
        }
        private bool ValidateSettings()
        {
            string error = "";
            if (String.IsNullOrEmpty(_settings.InputFileDirPath))
            {

                Common.AddEventToLog("ERROR", "Не задан каталог входящих файлов");
                return false;
            }
            if (String.IsNullOrEmpty(_settings.FileInvoiceCustomMask) || String.IsNullOrEmpty(_settings.FileInvoiceProductionMask))
            {

                Common.AddEventToLog("ERROR", "Не заданы шаблоны для поиска файлов инвойсов");
                return false;
            }
            if (String.IsNullOrEmpty(_settings.ServerName) || String.IsNullOrEmpty(_settings.PlanningBaseName) ||
                 String.IsNullOrEmpty(_settings.PlanningBaseLogin))
            {

                Common.AddEventToLog("ERROR", "Не заданы параметры доступа к базе данных");
                return false;
            }
            return true;
        }
    }
}
