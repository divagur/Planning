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
        SettingsHandle settingsHandle = new SettingsHandle(Path.Combine(Environment.CurrentDirectory,"PlanningServiceConfig.xml"));

        public PlanningService()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            AddEventToLog("EVENT_START", "Запуск службы");
                LoadSettings();
                if (!ValidateSettings())
                {
                    AddEventToLog("EVENT", "Проверка настроек не пройдена");
                    Stop();
                    return;
                }
                if (!TryDBConnect(_settings.ServerName, _settings.PlanningBaseName, _settings.PlanningBaseLogin, _settings.PlanningBasePwd))
                {
                    AddEventToLog("ERROR", "Не удалось подключиться к базе данных. Проверте настройки соединения");
                    Stop();
                    return;
                }
                AddEventToLog("EVENT", "Проверки пройдены");
            
            try
            {
                AddEventToLog("EVENT", "Create Logger");
                logger = new Logger(_settings);
                AddEventToLog("EVENT", "Logger created");
                AddEventToLog("EVENT", "Create Thread");
                Thread loggerThread = new Thread(new ThreadStart(logger.Start));
                AddEventToLog("EVENT", "Thread start");
                loggerThread.Start();
                AddEventToLog("EVENT", "Thread started");
            }
            catch (Exception ex)
            {
                Stop();
                AddEventToLog("ERROR", ex.Message);
            }

            
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
            AddEventToLog("EVENT", "Служба остановлена");
        }

        private void LoadSettings()
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
            _settings.TimerInterval = settingsHandle.GetParamIntValue("TimerInterval",60) * 1000;
            
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
        private void AddEventToLog(string eventLog, string descr)
        {
            using (StreamWriter writer = new StreamWriter("D:\\Temp\\PlanningServices\\PlanningServieLog.txt", true))
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
    }
}
