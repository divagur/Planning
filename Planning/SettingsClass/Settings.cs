using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<SettingReport> Reports = new List<SettingReport>();
        public List<CurrTaskColumn> CurrentTaskColumns = new List<CurrTaskColumn>();

        public List<VolumeCalcConstant> VolumeCalcTemplate = new List<VolumeCalcConstant>();

      

        public decimal TaskUpdateInterval { get; set; }
        public decimal TaskViewFonSize { get; set; }

        public VolumeCalcParams volumeCalcParams = new VolumeCalcParams();
        

    }

}
