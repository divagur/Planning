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
        SettingsHandle settingsHandle = new SettingsHandle("PlanningServiceConfig.xml");

        public PlanningService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
            try
            {
                LoadSettings();
                if (!ValidateSettings())
                {
                    Stop();
                    return;
                }
                if (!TryDBConnect(_settings.ServerName, _settings.PlanningBaseName, _settings.PlanningBaseLogin, _settings.PlanningBasePwd))
                {
                    AddEventToLog("ERROR", "Не удалось подключиться к базе данных. Проверте настройки соединения");
                    Stop();
                    return;
                }
                logger = new Logger(_settings);
                Thread loggerThread = new Thread(new ThreadStart(logger.Start));
                loggerThread.Start();
            }
            catch (Exception ex)
            {

                AddEventToLog("ERROR", ex.Message);
            }
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
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
            using (StreamWriter writer = new StreamWriter("PlanningServieLog.txt", true))
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
