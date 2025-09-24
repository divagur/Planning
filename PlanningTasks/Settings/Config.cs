using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTasks
{
    public static class Config
    {
        private static string _password;
        private static string fileName;
        public static string Server { get; set; }
        public static string DataBase { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static decimal UpdateInterval { get; set; }
        public static List<CurrentTaskColumn> VisibleColumns { get; set; } = new List<CurrentTaskColumn>();
        public static List<RuleRowColor> RulesRowColor { get; set; }
        public static string OrderColums { get; set; }
        public static string InOutFilter { get; set; }
        public static decimal TaskViewFonSize { get; set; }
        public static string ConnectionString
            { 
                get {
                    SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

                    connectionString.DataSource = Server;
                    connectionString.InitialCatalog = DataBase;
                    connectionString.UserID = Login;
                    connectionString.Password = Password;
                    return connectionString.ToString();
                } 
            }

        public static void Save()
        {
            SettingsHandle settingsHandle = new SettingsHandle(fileName);
            settingsHandle.SetParamValue("Connection\\Server", Server);
            settingsHandle.SetParamValue("Connection\\DataBase", DataBase);
            settingsHandle.SetParamValue("Connection\\Login", Login);
            settingsHandle.SetParamValue("Connection\\Password", SettingsHandle.Encode(Password));
            settingsHandle.SetParamList<CurrentTaskColumn>("CurrentTaskColumns", "Column",VisibleColumns);
        }

        public static void Load(string FileName)
        {
            
            SettingsHandle settingsHandle = new SettingsHandle(FileName);
            fileName = FileName;
            Server = settingsHandle.GetParamStringValue("Connection\\Server");
            DataBase = settingsHandle.GetParamStringValue("Connection\\DataBase");
            Login = settingsHandle.GetParamStringValue("Connection\\Login");
            Password = SettingsHandle.Decode(settingsHandle.GetParamStringValue("Connection\\Password"));
            UpdateInterval = settingsHandle.GetParamDecimalCheckValue("UpdateInterval", 1, 1);
            VisibleColumns = settingsHandle.GetParamList<CurrentTaskColumn>("CurrentTaskColumns");
            string timePeriodColor = settingsHandle.GetParamStringValue("TimePeriodColor");
            RulesRowColor = ParseRules(timePeriodColor);
            OrderColums = settingsHandle.GetParamStringValue("OrderColums");
            InOutFilter = settingsHandle.GetParamStringValue("InOutFilter");
            TaskViewFonSize = settingsHandle.GetParamDecimalCheckValue("TaskViewFonSize", 0, 5);


        }

        private static List<RuleRowColor> ParseRules(string RulesString)
        {
            List<RuleRowColor> ruleRowColors = new List<RuleRowColor>();

            if(!String.IsNullOrEmpty(RulesString))
            {
                string[] colorConditions = RulesString.Split(new char[] { ';' });

                foreach (string item in colorConditions)
                {
                    string[] rule = item.Split(new char[] { ':' });
                    if (rule.Length < 5)
                        continue;
                    RuleRowColor ruleRowColor = new RuleRowColor();
                    ruleRowColor.Operation = rule[0];
                    int value;
                    if (Int32.TryParse(rule[1], out value))
                        ruleRowColor.Param1 = value;
                    if (Int32.TryParse(rule[2], out value))
                        ruleRowColor.Param2 = value;
                    ruleRowColor.FontColorRGB = Color.Black;
                    ruleRowColor.BackgroundColorRGB = Color.White;
                    if (!string.IsNullOrEmpty(rule[4]) && rule[4] != "0")
                        ruleRowColor.BackgroundColorRGB = ColorTranslator.FromHtml(rule[3]);

                    if (rule.Length >= 5 && !string.IsNullOrEmpty(rule[4]) && rule[4] !="0")
                    {
                        ruleRowColor.FontColorRGB = ColorTranslator.FromHtml(rule[4]);
                    }
                    ruleRowColors.Add(ruleRowColor);
                }
            }    


            return ruleRowColors;
        }
    }
}
