using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Planning
{

    [Serializable]
    public class CurrTaskColumn
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }
        public int BgColor { get; set; }
        public int FontColor { get; set; }
        


        public CurrTaskColumn()
        {

        }
        public CurrTaskColumn(string id, string title, bool isVisible, int width)
        {
            Id = id;
            Title = title;
            Visible = isVisible;
            Width = width;
        }

    }

    [Serializable]
    public class Settings
    {
        public string ServerName { get; set; }
        public string BaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ShipmentReport { get; set; }
        public string ReceiptReport { get; set; }
        public string PeriodReport { get; set; }
        public int IsGetLogin { get; set; }
        public bool IsWnd { get; set; }
        public List<CurrTaskColumn> CurrentTaskColumns = new List<CurrTaskColumn>();
        public decimal TaskUpdateInterval { get; set; }
        public decimal TaskViewFonSize { get; set; }
    }
/*
    public static class SettingsHandle
    {
        //Settings _settings;


        public static bool Save(Settings settings)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Settings));

            using (FileStream fs = new FileStream("Planning.config", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, settings);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения настроек", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                
            }

            return true;
        }

        public static Settings Load()
        {
            using (FileStream fs = new FileStream("Planning.config", FileMode.OpenOrCreate))
            {
                Settings settings;
                XmlSerializer formatter = new XmlSerializer(typeof(Settings));
                try
                {
                    settings = (Settings)formatter.Deserialize(fs);
                }
                catch (InvalidOperationException ex)
                {
                    return null;
                }

                return settings;

            }
            
        }
    }
    */
}
