using Planning.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public static class Common
    {

        public static Settings setting = new Settings();
        public static SettingsHandle settingsHandle;
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

    }
}
