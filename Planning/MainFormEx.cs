using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Planning.DataLayer;
using Planning.Properties;
using Planning.Controls;
namespace Planning
{
    public partial class MainFormEx : Form
    {

        public MainFormEx()
        {
            InitializeComponent();
        }

        private void MainFormEx_Load(object sender, EventArgs e)
        {
            /*
            DataService.settingsHandle = new SettingsHandle("Settings.xml", DataService.setting);
            DataService.settingsHandle.Load();
            //Если нет сервера или базы, то выдадим окно настройки
            if (DataService.setting.BaseName == "" || DataService.setting.ServerName == "")
            {
                DataService.setting = new Settings();

                SettingsWizard frmSettingsWizard = new SettingsWizard(DataService.setting);



                if (frmSettingsWizard.ShowDialog() == DialogResult.OK)
                {
                    DataService.settingsHandle.Save();
                }
                else
                    this.Close();
            }
            */
            ConnectionParams.ServerName = "DZHURAVLEV";
            ConnectionParams.BaseName = "Planning_test";
            ConnectionParams.UserName ="sysadm";
            ConnectionParams.Pwd = "sysadm";

            statusInfo.Text = $"База данных:[{DataService.setting.BaseName}] Пользователь: [{DataService.setting.UserName}]";
            
            SetupColumns();
            SetupButtons();

            ShipmentMainRepository shipmentMainRepository = new ShipmentMainRepository();
            List<ShipmentMain> shipmentMains = shipmentMainRepository.GetAll(DateTime.Now, null, null, null);
            tblShipments.SetObjects(shipmentMains);
            tblShipments.DrawSubItem += TblShipments_DrawSubItem;
        }

        private void TblShipments_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = false;
            Pen p = new Pen(Color.Gray);
            e.Graphics.DrawRectangle(p, e.Bounds);
            e.DrawText();
        }

        private void SetupColumns()
        {

            

            colDirection.AspectGetter = delegate (object row) {
                if (((ShipmentMain)row).InOut == "вход")
                    return "In";
                if (((ShipmentMain)row).InOut == "выход")
                    return "Out";
                return "Move";
            };

            this.colDirection.Renderer = new MappedImageRenderer(new Object[] {
                "In", Resources.ShpIn,
                "Out", Resources.ShpOut,
                "Move", Resources.ShpMove
            });

        }
        private void SetupButtons()
        {
            MenuButton menuButton = new MenuButton();

            ToolTip btnAddToolTip = new ToolTip();
            btnAddToolTip.SetToolTip(btnAdd, "Добавить отгрузку");
        }
        private void tblShipments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
