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
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;

namespace Planning
{
    public partial class MainFormEx : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        List<string> hideCols;
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };
        ShipmentMainRepository shipmentMainRepository;
        List<ShipmentMain> _shipmentMainList;
        public MainFormEx()
        {
            InitializeComponent();
        }

        private void MainFormEx_Load(object sender, EventArgs e)
        {
            
            //.Width = Screen.PrimaryScreen.WorkingArea.Width;
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
            /*
            ConnectionParams.ServerName = @"ZDV\MS2019DVG";
            ConnectionParams.BaseName = "Planning";
            */
            


            Common.settingsHandle = new SettingsHandle("Settings.xml", Common.setting);
            Common.settingsHandle.Load();

            ConnectionParams.ServerName = Common.setting.ServerName;
            ConnectionParams.BaseName = Common.setting.BaseName;

            ConnectionParams.UserName = Common.setting.UserName;
            ConnectionParams.Pwd = Common.setting.Password;

            statusInfo.Text = $"База данных:[{DataService.setting.BaseName}] Пользователь: [{DataService.setting.UserName}]";


            shipmentMainRepository = new ShipmentMainRepository();
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

            ShipmentMain itemObject = GetCurrentRowObject();
            
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
           // ShipmentsLoad();
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
            //ShipmentMainRepository shipmentMainRepository = new ShipmentMainRepository();
            _shipmentMainList = shipmentMainRepository.GetAll(edCurrDay.Value, null, null, null);
            tblShipments.ClearObjects();
            tblShipments.SetObjects(_shipmentMainList);
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

            Common.settingsHandle = new SettingsHandle("Settings.xml", DataService.setting);
            Common.settingsHandle.Load();

            hideCols = Common.settingsHandle.GetParamStringValue("View\\HideColumns").Split(',').ToList();

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

        private void MaximideWindows()
        {
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }
        private void AddFormTab(Form frm, String Name)
        {
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tabForms.TabPages.Add(Name);
            tabForms.TabPages[tabForms.TabPages.Count - 1].Controls.Add(frm);            
            tabForms.SelectedTab = tabForms.TabPages[tabForms.TabPages.Count - 1];
        }

        private DataLayer.ShipmentMain GetCurrentRowObject()
        {
            return (ShipmentMain)tblShipments.GetItem(tblShipments.SelectedIndex).RowObject;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            (item.Tag as OLVColumn).IsVisible = item.CheckState == CheckState.Checked ? true : false;
            tblShipments.RebuildColumns();
            Common.settingsHandle.SetParamValue("View\\HideColumns", GetHideColumns());
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

        private void tabForms_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            RectangleF tabTextArea = RectangleF.Empty;
            for (int nIndex = 0; nIndex < tabForms.TabCount; nIndex++)
            {
                tabTextArea = (RectangleF)tabForms.GetTabRect(nIndex);
                if (nIndex > 0)
                {


                    if (nIndex != tabForms.SelectedIndex)
                    {
                        /*if not active draw ,inactive close button*/
                        

                        e.Graphics.DrawImage(Resources.TabClose,
                                tabTextArea.X + tabTextArea.Width - 16, 5, 13, 13);
                    }
                    else
                    {                        
                        LinearGradientBrush br = new LinearGradientBrush(tabTextArea,
                            SystemColors.ControlLightLight, SystemColors.Control,
                            LinearGradientMode.Vertical);
                        e.Graphics.FillRectangle(br, tabTextArea);

                        /*if active draw ,inactive close button*/
                        e.Graphics.DrawImage(Resources.TabCloseRed,
                            tabTextArea.X + tabTextArea.Width - 16, 5, 13, 13);
                        br.Dispose();
                    }
                }
                string str = tabForms.TabPages[nIndex].Text;
                StringFormat stringFormat = new StringFormat(); 
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                using (SolidBrush brush = new SolidBrush(tabForms.TabPages[nIndex].ForeColor))
                {
                    /*Draw the tab header text*/
                    e.Graphics.DrawString(str,this.Font, brush, tabTextArea,stringFormat);
                }
            }
        }

        private void panelFormHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelFormHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaximideWindows();
        }

        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizeWindow_Click(object sender, EventArgs e)
        {
            MaximideWindows();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs mevent)
        {
           
        }

        private void btnMainMenu_MouseDown(object sender, MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            if ( mevent.Button == MouseButtons.Left)
            {
                Point menuLocation;
                /*
                if (ShowMenuUnderCursor)
                {
                    menuLocation = mevent.Location;
                }
                else
                {*/
                    menuLocation = new Point(3, btnMainMenu.Height);
                //}

                contextMenuMain.Show(this, menuLocation);
            }
        }

        private void menuItemDictWarehouse_Click(object sender, EventArgs e)
        {
            var frmWarehouse = new Warehouses();
            //SetFormPrivalage(frmWarehouse, "Warehouse");
            AddFormTab(frmWarehouse, "Склады");
        }

        private void tabForms_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.tabForms.SelectedIndex == 0)
                return;
            Rectangle r = tabForms.GetTabRect(this.tabForms.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 13, 13);
            if (closeButton.Contains(e.Location))
            {
                (this.tabForms.SelectedTab.Controls[0] as Form).Close();
                this.tabForms.TabPages.Remove(this.tabForms.SelectedTab);
            }
        }

        private void menuItemDictCustomPosts_Click(object sender, EventArgs e)
        {
            var frmCustomPosts = new CustomPosts();
            //SetFormPrivalage(frmCustomPosts, "CustomPost");
            AddFormTab(frmCustomPosts, "Таможенные посты");
        }

        private void menuItemDictGates_Click(object sender, EventArgs e)
        {
            GateForm frmGate = new GateForm();
            //SetFormPrivalage(frmGate, "Gate");
            AddFormTab(frmGate, "Ворота");
            
        }

        private void panelFormHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuItemDictDepositor_Click(object sender, EventArgs e)
        {
            Depositors frmDepositors = new Depositors();
            //SetFormPrivalage(frmDepositors, "Depositor");
            AddFormTab(frmDepositors, "Депозиторы");
        }

        private void menuItemDictOpersType_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();
            dict.TableName = "opers_type";
            dict.Title = "Справочник: Типы операций";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 20 });

            //SimpleDict<DataLayer.OperTy, DataLayer.GatewayRepository> frmOperType = new SimpleDict(dict);
            //SetFormPrivalage(frmOperType, "OperType");
            //AddFormTab(frmOperType, "Типы операций");
        }

        private void menuItemDictTimeSlot_Click(object sender, EventArgs e)
        {
            var frmTimeSlot = new TimeSlots();
            //SetFormPrivalage(frmTimeSlot, "TimeSlot");
            AddFormTab(frmTimeSlot, "Тайм слоты");
        }

        private void menuItemDictTC_Click(object sender, EventArgs e)
        {

            TransportCompanyForm frmTransportCompany = new TransportCompanyForm();
            //SetFormPrivalage(frmTransportCompany, "TC");
            AddFormTab(frmTransportCompany, "Транспортные компании");
        }

        private void menuItemDictDelayReasons_Click(object sender, EventArgs e)
        {

            var frmDelayReasons = new DictDelayReasons();
            //SetFormPrivalage(frmDelayReasons, "DelayReasons");
            AddFormTab(frmDelayReasons, "Причины задержки");
        }

        private void menuItemDoctSupplier_Click(object sender, EventArgs e)
        {

            var frmSupplier = new Suppliers();
            //SetFormPrivalage(frmSupplier, "Supplier");
            AddFormTab(frmSupplier, "Поставщики");
        }

        private void menuItemDictAttributes_Click(object sender, EventArgs e)
        {
            var frmShimentElements = new ShipmentElements();

            //SetFormPrivalage(frmShimentElements, "Attr");
            AddFormTab(frmShimentElements, "Элементы отгрузки");
        }

        private void menuItemDictTransportType_Click(object sender, EventArgs e)
        {

            var frmTransporType = new TransportTypeForm();
            //SetFormPrivalage(frmTransporType, "TransporType");
            AddFormTab(frmTransporType, "Типы транспорта");
            
        }

        private void menuItemDictTransportView_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            ShipmentMain shipmentMain = GetCurrentRowObject();
            if (shipmentMain == null)
                return;

            SettingReport settingReport = DataService.setting.Reports.Find(r => r.Name == (shipmentMain.ShpIn == false ? "Лист отгрузки" : "Лист прихода"));
            if (settingReport == null || String.IsNullOrEmpty(settingReport.TemplatePath))
            {
                MessageBox.Show("Не задан шаблон печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (shipmentMain.ShpIn == false)
            {
                ReportHandler.PrintShipmentOut(shipmentMain, settingReport.TemplatePath);
            }
            else
            {
                ReportHandler.PrintShipmentIn(shipmentMain, settingReport.TemplatePath);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
