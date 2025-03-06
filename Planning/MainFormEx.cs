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
using Planning.Kernel;

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
        private void ShipmentRowEdit()
        {
            if (tblShipments.SelectedIndex<0)
                return;

            ShipmentMain itemObject = (ShipmentMain)tblShipments.GetItem(tblShipments.SelectedIndex).RowObject;
            
            ShipmentParam shipmentAddResult = new ShipmentParam();
            if (itemObject.InOut != "перем")
            {
                ShipmentRepository shipmentRepository = new ShipmentRepository();

                shipmentAddResult.IsShipment = true;
                shipmentAddResult.Result = shipmentRepository.GetById(itemObject.ShpId);

            }
            else
            {
                MovementRepository movementRepository = new MovementRepository();
                shipmentAddResult.IsShipment = false;
                shipmentAddResult.Result = movementRepository.GetById(itemObject.ShpId);
            }

            ShipmentEdit(shipmentAddResult);
            ShipmentsLoad();
        }
        private void ShipmentEdit(ShipmentParam shipmentAddResult)
        {
            shipmen_edit frmShipmentEdit;
            frmShipmentEdit = shipmentAddResult.IsShipment == true ? new shipmen_edit((Planning.DataLayer.Shipment)shipmentAddResult.Result) : 
                new shipmen_edit((Planning.DataLayer.Movement)shipmentAddResult.Result);
            /*
            if (shipmentAddResult.IsShipment)
                frmShipmentEdit = new shipmen_edit((Shipment)shipmentAddResult.Result);
            else
                frmShipmentEdit = new shipmen_edit((Movement)shipmentAddResult.Result);
            */


            frmShipmentEdit.ClearFields();
            frmShipmentEdit.Populate();
            //frmShipmentEdit.LockField(new List<string>() { "btnOK", "btnCancel" }, mainFormAccess.IsEdit);


            if (frmShipmentEdit.ShowDialog() == DialogResult.OK)
            {
                DataService.context.SaveChanges();
                if (shipmentAddResult.IsShipment)
                {
                    Shipment shipment = (Shipment)shipmentAddResult.Result;

                    if (shipment.ShIn == true)
                    {
                        DataService.ForceMergeLVAttribute(shipment.Id);

                    }
                    /*
                    if (shipment.IsAddLv == true)
                    {
                        AddShToLV(shipment);
                    }
                    */
                }

                tblShipments.Refresh();
            }
        }
        private void ShipmentsLoad()
        {
            /*
            if (mainFormAccess != null && !mainFormAccess.IsView)
            {
                MessageBox.Show("Нет доступа на просмотр списка отгрузок", "Ошибка доступа", MessageBoxButtons.OK);
                return;
            }
            
            string rowShpId = "";
            string rowShpOrdId = "";
            bool restoreRow = false;
            
            if (tblShipments.CurrentCell != null)
            {
                rowShpId = tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
                rowShpOrdId = tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value.ToString();
                restoreRow = true;
            }

            tbMain.Enabled = false;
            miDicts.Enabled = false;
            var dataSet = GetShipment(edCurrDay.Value, null, null, null);
            if (dataSet == null)
            {
                return;
            }
            tbMain.Enabled = true;
            miDicts.Enabled = true;

            shipmentsDataTable.Clear();
            shipmentsDataTable = dataSet.Tables[0].Clone();
            shipmentsDataTable.Load(dataSet.Tables[0].CreateDataReader());
            

            tblShipments.AutoGenerateColumns = false;
            tblShipments.DataSource = shipmentsDataTable;// ds.Tables[0];
            foreach (var column in tblShipments.Columns)
            {
                if (column is DataGridViewImageColumn)
                    (column as DataGridViewImageColumn).DefaultCellStyle.NullValue = null;
            }
            if (restoreRow)
                SearchBy(true, i => tblShipments.Rows[i].Cells["colId"].Value.ToString() == rowShpId && tblShipments.Rows[i].Cells["colIdNakl"].Value.ToString() == rowShpOrdId);
            //this.Cursor = Cursors.Default;
            CalcRowColor();
            GetOrderWight();
            ShipmentsUIFilter();
            */
        }
        private void tblShipments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShipmentRowEdit();
        }

        private void tblShipments_FormatRow(object sender, FormatRowEventArgs e)
        {
            ShipmentMain item = (ShipmentMain)e.Item.RowObject;
            if (item.GateName == "127")
            {
                e.Item.BackColor = Color.AliceBlue;
            }
        }
    }
}
