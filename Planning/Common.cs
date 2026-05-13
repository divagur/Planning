using Planning.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planning.Kernel;
using System.Text.RegularExpressions;
namespace Planning
{
    public static class Common
    {

        public static Settings setting = new Settings();
        public static PlanningSettingsHandle settingsHandle;

        public static PlanningConfig PlanningConfig = new PlanningConfig();
        
        public static DataLayer.User CurrentUser;

        public static void WaitBegin(ref object Param)
        {
            Cursor cur = (Cursor)Param;
            cur = Cursors.AppStarting;
        }

        public static void WaitEnd(ref object Param)
        {
            Cursor cur = (Cursor)Param;
            cur = Cursors.Default;
        }

        public static string CalculateHashGOST(string message)
        {
            GOST G = new GOST(256);
            byte[] messageByte = Encoding.UTF8.GetBytes(message);
            byte[] res = G.GetHash(messageByte);
            return BitConverter.ToString(res).Replace("-","");
        }
        public static string EncryptString(string Str)
        {
            return Str;
        }
        public static string DecryptString(string Str)
        {
            return Str;
        }
        public static bool AddShipmentToLV(int? ShipmentId)
        {
            SqlProcExecutor sqlProcExecutor = new SqlProcExecutor();
            SqlProcParam sqlProcParams = new SqlProcParam();
            sqlProcParams.Add("@ShID", ShipmentId);

            try
            {
                sqlProcExecutor.ProcExecute("SP_PL_CreateShipmentInLV", sqlProcParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании отгрузки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool ForceMergeLVAttribute(int? ShpId)
        {
            SqlProcExecutor sqlProcExecutor = new SqlProcExecutor();
            SqlProcParam sqlProcParams = new SqlProcParam();
            sqlProcParams.Add("@ShpID", ShpId);
            try
            {
                sqlProcExecutor.ProcExecute("SP_PL_ForceMergeLVAttribute", sqlProcParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании отгрузки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static string BuildConnectionString(string Server, string DB, string Login, string Pswd)
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = Server;
            connectionString.InitialCatalog = DB;
            connectionString.IntegratedSecurity = false;
            connectionString.UserID = Login;
            connectionString.Password = Pswd;

            return connectionString.ToString();
        }

        public static void ShowInformation(string Text, string Caption)
        {
            MessageBox.Show(Text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowError(string Text, string Caption)
        {
            MessageBox.Show(Text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string MinutesToTimeSpan(int minutes)
        {
            TimeSpan spWorkMin = TimeSpan.FromMinutes(minutes);
            //return string.Format("{0}:{1}", (int)spWorkMin.TotalHours == 0 ? "00" : spWorkMin.TotalHours.ToString(), spWorkMin.Minutes == 0 ? "00" : spWorkMin.Minutes.ToString());
            int hoursResult = Math.Abs(minutes) / 60;
            int minutesResult = Math.Abs(minutes) % 60;
            return string.Format("{2}{0}:{1}", hoursResult < 10 ? $"0{hoursResult.ToString()}" : hoursResult.ToString(), minutesResult < 10 ? $"0{minutesResult.ToString()}" : minutesResult.ToString(),
                minutes<0?"-":"");
        }

        public static int TimeSpanToMinutes(string timeSpan)
        {
            if (!Regex.IsMatch(timeSpan, "^\\d{1,4}:\\d{1,2}"))
            {
                return 0;
            }

            string[] splitTime = timeSpan.Split(':');

            return int.Parse(splitTime[0]) * 60 + int.Parse(splitTime[1]);
        }

    }
}
