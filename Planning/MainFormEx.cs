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

        List<string> hideCols;
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };
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

            Init();

            ConnectionParams.ServerName = @"ZDV\MS2019DVG";
            ConnectionParams.BaseName = "Planning";
            ConnectionParams.UserName ="sysadm";
            ConnectionParams.Pwd = "sysadm";

            statusInfo.Text = $"База данных:[{DataService.setting.BaseName}] Пользователь: [{DataService.setting.UserName}]";
            
            SetupColumns();
            SetupButtons();

            ShipmentsLoad();
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

            ToolTip btnEditToolTip = new ToolTip();
            btnEditToolTip.SetToolTip(btnEdit, "Редактировать отгрузку");

            ToolTip btnDeleteToolTip = new ToolTip();
            btnDeleteToolTip.SetToolTip(btnDelete, "Удалить отгрузку");

            ToolTip btnRefreshToolTip = new ToolTip();
            btnRefreshToolTip.SetToolTip(btnRefresh, "Обновить");

            ToolTip btnShowLogToolTip = new ToolTip();
            btnShowLogToolTip.SetToolTip(btnShowLog, "Показать историю изменений");

            ToolTip btnPrintToolTip = new ToolTip();
            btnPrintToolTip.SetToolTip(btnPrint, "Печать");

            ToolTip btnColumnVisibleToolTip = new ToolTip();
            btnColumnVisibleToolTip.SetToolTip(btnColumnVisible, "Видимость колонок");
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
            ShipmentMainRepository shipmentMainRepository = new ShipmentMainRepository();
            List<ShipmentMain> shipmentMains = shipmentMainRepository.GetAll(edCurrDay.Value, null, null, null);
            tblShipments.ClearObjects();
            tblShipments.SetObjects(shipmentMains);
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
        private void Init()
        {

            CommonFuctions.settingsHandle = new SettingsHandle("Settings.xml", DataService.setting);
            CommonFuctions.settingsHandle.Load();

            hideCols = CommonFuctions.settingsHandle.GetParamStringValue("View\\HideColumns").Split(',').ToList();

            PopulateVisibleColumn();

        }
        private void PopulateVisibleColumn()
        {
            contextMenuColumns.Items.Clear();

            foreach (OLVColumn col in tblShipments.AllColumns)
            {
                
                
                if (col.IsVisible)
                {
                    string headerText = String.IsNullOrEmpty(col.Text) ? col.ToolTipText : col.Text;
                    ToolStripMenuItem item = (ToolStripMenuItem)contextMenuColumns.Items.Add(headerText);
                    item.CheckOnClick = true;
                    item.CheckState = hideCols.IndexOf(col.Name) < 0 ? CheckState.Checked : CheckState.Unchecked;
                    item.Tag = col;
                    item.Click += Item_Click;
                    col.IsVisible = hideCols.IndexOf(col.Name) < 0;
                }
                


            }
        }
        private string GetHideColumns()
        {

            List<string> result = new List<string>();
            foreach (OLVColumn col in tblShipments.AllColumns)
            {
                if (!col.IsVisible)
                {
                    result.Add(col.Name);
                }
            }
            return String.Join(",", result);
        }
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            (item.Tag as OLVColumn).IsVisible = item.CheckState == CheckState.Checked ? true : false;
            tblShipments.RebuildColumns();
            CommonFuctions.settingsHandle.SetParamValue("View\\HideColumns", GetHideColumns());
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
            e.Item.BackColor = item.RowNumberRange == null?Color.White: rowColors[(int)item.RowNumberRange % 2];
        }

        private void btnGetCurrentDay_Click(object sender, EventArgs e)
        {
            edCurrDay.Value = DateTime.Now;
        }

        private void btnGetLastDay_Click(object sender, EventArgs e)
        {
            edCurrDay.Value = edCurrDay.Value.AddDays(-1);
        }

        private void btnGetNextDay_Click(object sender, EventArgs e)
        {
            edCurrDay.Value = edCurrDay.Value.AddDays(1);    
        }

        private void edCurrDay_ValueChanged(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //tblShipments.AllColumns[4].IsVisible = false;
            List < OLVColumn > cols= tblShipments.AllColumns;
            bool v = colDate.IsVisible;
            List<OLVColumn> columns = tblShipments.GetFilteredColumns(tblShipments.View);
            //tblShipments.RebuildColumns();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }
    }
}
