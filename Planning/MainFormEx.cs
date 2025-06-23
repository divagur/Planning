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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;
using Point = System.Drawing.Point;
using SpreadsheetLight;


namespace Planning
{
    public partial class MainFormEx : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        const int REPORT_PERIOD = 101;
        const int REPORT_STATISTIC = 102;
        const int REPORT_TC = 103;

        
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        string CR = Environment.NewLine;
        List<string> hideCols;
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };
        ShipmentMainRepository shipmentMainRepository;
        List<ShipmentMain> _shipmentMainList;
        List<UserFunctionPrvlg> UserPrvlgs= new List<UserFunctionPrvlg>();
        UserFunctionPrvlg mainFormPrvlg = new UserFunctionPrvlg();
        private bool isPaint = true;

        public MainFormEx()
        {
            InitializeComponent();
        }

        private void MainFormEx_Load(object sender, EventArgs e)
        {
            

            Init();
            Connect();
            statusInfo.Text = $"База данных:[{Common.PlanningConfig.BaseName}] Пользователь: [{Common.setting.LastLogin}]";

            GetUserPrvlg();
            SetMainFormPrvlg();

            shipmentMainRepository = new ShipmentMainRepository();
            SetupColumns();
            SetupButtons();
            PopulateWarehouseFilter();
            ShipmentsLoad();
            tblShipments.DrawSubItem += TblShipments_DrawSubItem;
            cbPaint.Checked = isPaint;


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

            ToolTip btnActionFilterToolTip = new ToolTip();
            btnActionFilterToolTip.SetToolTip(btnActionFilter, "Отображаемые действия");

            ToolTip btnWarehouseFilterToolTip = new ToolTip();
            btnWarehouseFilterToolTip.SetToolTip(btnWarehouseFilter, "Фильтр по складам");

            ToolTip btnSerachToolTip = new ToolTip();
            btnSerachToolTip.SetToolTip(btnSearch, "Найти по коду заказа");

            ToolTip btnSerachNextToolTip = new ToolTip();
            btnSerachNextToolTip.SetToolTip(btnSearchNext, "Найти далее");


            ToolTip btnGetLastDayToolTip = new ToolTip();
            btnGetLastDayToolTip.SetToolTip(btnGetLastDay, "Предыдущий день");

            ToolTip btnGetCurrentDayToolTip = new ToolTip();
            btnGetCurrentDayToolTip.SetToolTip(btnGetCurrentDay, "Текущий день");

            ToolTip btnGetNextDayToolTip = new ToolTip();
            btnGetNextDayToolTip.SetToolTip(btnGetNextDay, "Следующий день");

            ToolTip btnSearchExToolTip = new ToolTip();
            btnSearchExToolTip.SetToolTip(btnSearchEx, "Поиск по параметрам");
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
            //ShipmentsLoad();
        }
        private void ShipmentEdit(ShipmentParam shipmentAddResult)
        {
            ShipmenEdit frmShipmentEdit;
            frmShipmentEdit = shipmentAddResult.IsShipment == true ? new ShipmenEdit((DataLayer.Shipment)shipmentAddResult.Result) : 
                new ShipmenEdit((DataLayer.Movement)shipmentAddResult.Result);
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
                if (shipmentAddResult.IsShipment)
                {
                    DataLayer.Shipment shipment = (DataLayer.Shipment)shipmentAddResult.Result;

                    ShipmentRepository shipmentRepository = new ShipmentRepository();

                    if (shipment.ShIn == true)
                    {
                        Common.ForceMergeLVAttribute(shipment.Id);

                    }
                    /*
                    if (shipment.IsAddLv == true)
                    {
                        AddShToLV(shipment);
                    }
                    */
                }
                UpdateDataSource(_shipmentMainList);
               // tblShipments.Refresh();
            }
        }
        private void GetOrderWight()
        {

            SqlProcExecutor sqlProcExecutor = new SqlProcExecutor();
            SqlProcParam sqlProcParams = new SqlProcParam();
            sqlProcParams.Add("@ShpID", null);
            sqlProcParams.Add("@OrdID", null);
            sqlProcParams.Add("@DepId", null);
            try
            {
                sqlProcExecutor.ProcExecute("SP_PL_GetOrderWight", sqlProcParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании отгрузки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ShipmentsLoad()
        {
            //ShipmentMainRepository shipmentMainRepository = new ShipmentMainRepository();
            try
            {
                _shipmentMainList = shipmentMainRepository.GetAll(edCurrDay.Value, null, null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            UpdateDataSource(_shipmentMainList);
            GetOrderWight();
            ShipmentsUIFilter();
            CalcRowColor();
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
        private void CalcRowColor()
        {
            int? cellShpId;
            int? cellLastShpId = 0;
            int currColorIdx = 0;
            
            for (int i = 0; i < tblShipments.GetItemCount(); i++)
            {               
                ShipmentMain shipmentMain = (ShipmentMain)tblShipments.GetItem(i).RowObject;
                cellShpId = shipmentMain.ShpId;
                if (cellLastShpId != cellShpId)
                {
                    cellLastShpId = cellShpId;
                    currColorIdx = currColorIdx == 0 ? 1 : 0;
                }
                shipmentMain.RowNumberRange = currColorIdx;
            }

            tblShipments.BuildList();
            /*
            foreach (ShipmentMain item in _shipmentMainList)
            {
                cellShpId = item.ShpId;
                if (cellLastShpId != cellShpId)
                {
                    cellLastShpId = cellShpId;
                    currColorIdx = currColorIdx == 0 ? 1 : 0;
                }
                item.RowNumberRange = currColorIdx;
            }
            */
        }
        private void UpdateDataSource(List<ShipmentMain> listDataSource)
        {
            tblShipments.BeginUpdate();
            tblShipments.ClearObjects();
            tblShipments.SetObjects(listDataSource);
            tblShipments.EndUpdate();
        }
        private void Init()
        {

            PlanningConfigHandle planningConfigHandle = new PlanningConfigHandle("PlanningConfig.xml", Common.PlanningConfig);
            planningConfigHandle.Load();


            Common.settingsHandle = new PlanningSettingsHandle("Settings.xml", Common.setting);
            Common.settingsHandle.Load();



            ConnectionParams.ServerName = Common.PlanningConfig.ServerName;
            ConnectionParams.BaseName = Common.PlanningConfig.BaseName;
            ConnectionParams.UserName = Common.PlanningConfig.UserName;
            ConnectionParams.Pwd = Common.PlanningConfig.Password;

            if (String.IsNullOrEmpty(ConnectionParams.ServerName) || String.IsNullOrEmpty(ConnectionParams.BaseName))
            {
                MessageBox.Show("Не указаны параметры подключения к базе данных, проверте настройки подключения");
            }

            hideCols = Common.settingsHandle.GetParamStringValue("View\\HideColumns").Split(',').ToList();

            PopulateVisibleColumn();




        }

        private void CloseAllTabs()
        {
            foreach (TabPage pg in tabForms.TabPages)
            {
                if (pg.Name != "tabMain")
                    tabForms.TabPages.Remove(pg);
            }
        }
        private bool LoginUser()
        {
            FormLogin frmLogin = new FormLogin();
            if (frmLogin.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }
            CloseAllTabs();

            Common.settingsHandle.SetParamValue("Connection\\LastLogin", Common.setting.LastLogin);

            return true;
        }
        private void GetUserPrvlg()
        {
            FunctionRepository functionRepository = new FunctionRepository();
            List<Function> functions = functionRepository.GetAll();

            foreach (var item in functions)
            {
                UserFunctionPrvlg userFunctionPrvlg = new UserFunctionPrvlg();
                userFunctionPrvlg.FunctionId = item.Id;
                userFunctionPrvlg.FunctionCode = item.Code;
                userFunctionPrvlg.FunctionName = item.Name;
                UserPrvlgs.Add(userFunctionPrvlg);
            }

            UserGroupLnkRepository groupLnkRepository = new UserGroupLnkRepository();
            List<UserGroupLnk> userGroups = groupLnkRepository.GetByUserId(Common.CurrentUser.Id);
            if (userGroups == null)
            {
                return;
            }

            UserGrpPrvlgRepository userGrpPrvlgRepository = new UserGrpPrvlgRepository();
            foreach (var item in userGroups)
            {
                List<UserGrpPrvlg> userGrpPrvlg = userGrpPrvlgRepository.GetByGrpId(item.GroupId);
                foreach (var function in UserPrvlgs)
                {
                    DataLayer.UserGrpPrvlg grpFuncPrvlg = userGrpPrvlg.FirstOrDefault(p => p.FuncId == function.FunctionId);
                    if (grpFuncPrvlg == null)
                    {
                        continue;
                    }

                    function.IsAppend = function.IsAppend || (bool)grpFuncPrvlg.IsAppend;
                    function.IsDelete = function.IsDelete || (bool)grpFuncPrvlg.IsDelete;
                    function.IsEdit = function.IsEdit || (bool)grpFuncPrvlg.IsEdit;
                    function.IsView = function.IsView || (bool)grpFuncPrvlg.IsView;
                }
            }

        }
        private void Connect()
        {

            
            if (!LoginUser())
            {
                Environment.Exit(0);
                this.Close();
                return;
            }
            
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
            tblShipments.BeginUpdate();
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            tblShipments.EndUpdate();
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
        private void SetMainFormPrvlg()
        {

            mainFormPrvlg = UserPrvlgs.Find(i => i.FunctionCode == "MainForm");
            if (mainFormPrvlg != null)
            {
                btnAdd.Enabled = mainFormPrvlg.IsAppend;
                btnDelete.Enabled = mainFormPrvlg.IsDelete;
                btnRefresh.Enabled = mainFormPrvlg.IsView;
            }

            btnEdit.Image = mainFormPrvlg.IsEdit ? Properties.Resources.Edit : Properties.Resources.EditView;

            bool isShowAdmin = false;
            foreach (UserFunctionPrvlg item in UserPrvlgs)
            {
                ToolStripItem mi = FindMenuItem(menuMain.Items, item.FunctionCode);
                if (item.FunctionCode == "Attr" || item.FunctionCode == "OperType")
                {
                    mi.Visible = false;
                    continue;
                }
                if (item.FunctionCode == "UserGrp" || item.FunctionCode == "Users")
                {
                    isShowAdmin = isShowAdmin || item.IsView;
                }
                if (mi != null)
                    mi.Visible = item.IsView;

            }
            toolStripMenuItemAdmin.Visible = isShowAdmin;
        }

        private void SetFormPrivalage(IItemPrivilege form, string FunctionId)
        {
            UserFunctionPrvlg userFunctionPrvlg = UserPrvlgs.Find(i => i.FunctionCode == FunctionId);
            if (userFunctionPrvlg != null)
            {
                form.SetPrivilege(userFunctionPrvlg.IsAppend, userFunctionPrvlg.IsEdit, userFunctionPrvlg.IsDelete);
            }
        }
        public void ShipmentsUIFilter()
        {
            List<string> actionFilter = GetFilterActionList();
            List<string> warehouseFilter = GetFilterWarehouseList();

            tblShipments.UseFiltering = true;
            tblShipments.ModelFilter = new ModelFilter(delegate (object x) {
                return actionFilter.Contains(((ShipmentMain)x).InOut) && warehouseFilter.Contains(((ShipmentMain)x).WarehouseName);
                //
            }
            );
            CalcRowColor();
            /*
            List<ShipmentMain> listDataSource = _shipmentMainList.Where(r => actionFilter.Contains(r.InOut) && warehouseFilter.Contains(r.WarehouseName)).ToList();
            UpdateDataSource(listDataSource);
            
            if (rows.Count() > 0)
            {
                DataTable dt = rows.CopyToDataTable();
                tblShipments.DataSource = dt;
                CalcRowColor();
            }
            else
            {
                tblShipments.DataSource = null;
            }
            */
        }
        public void PopulateWarehouseFilter()
        {
            WarehouseRepository warehouseRepository = new WarehouseRepository();
            List<DataLayer.Warehouse> warehouses = warehouseRepository.GetAll();

            List<string> action = Common.settingsHandle.GetParamStringValue("View\\WarehouseFilter").Split(',').ToList();
            contextMenuWarehouse.Items.Clear();
            foreach (var item in warehouses)
            {                
                ToolStripMenuItem btnWarehouseItem = (ToolStripMenuItem)contextMenuWarehouse.Items.Add(item.Name);
                btnWarehouseItem.CheckOnClick = true;
                btnWarehouseItem.CheckState = action.Contains(item.Name) ? CheckState.Checked : CheckState.Unchecked;

                btnWarehouseItem.Click += BtnWarehouseItem_Click;
            }
        }
        private List<String> GetFilterActionList()
        {
            List<String> result = new List<string>();
            foreach (ToolStripMenuItem item in contextMenuActionType.Items)
            {
                if (item.Checked)
                    result.Add(item.Text);
            }
            return result;
        }
        private List<String> GetFilterWarehouseList()
        {
            List<String> result = new List<string>();
            foreach (ToolStripMenuItem item in contextMenuWarehouse.Items)
            {
                if (item.Checked)
                    result.Add(item.Text);
            }
            return result;
        }

        private void ShowOrderDetail(ShipmentMain shipmentMain)
        {
            if (shipmentMain == null)
            {
                return;
            }
            //ShipmentMain shipmentMain = GetCurrentRowObject();
            if (shipmentMain.InOut == "перем")
            {
                return; 
            }

            int inOut = shipmentMain.InOut == "вход" ? 1 : 0;

            DepositorRepository depositorRepository = new DepositorRepository();
            DataLayer.Depositor depositor = depositorRepository.GetByName(shipmentMain.DepCode);
            if (depositor == null)
            {
                return ;
            }


            frmOrderDetail frmOrderDetail = new frmOrderDetail(shipmentMain.OrdLVCode, shipmentMain.OrdLVID, inOut, depositor.Id);
            frmOrderDetail.ShowDialog();

        }

        private void BtnWarehouseItem_Click(object sender, EventArgs e)
        {
            ShipmentsUIFilter();
            Common.settingsHandle.SetParamValue("View\\WarehouseFilter", String.Join(",", GetFilterWarehouseList().ToArray()));
        }

        private ToolStripItem FindMenuItem(ToolStripItemCollection items, string Tag)
        {
            foreach (ToolStripMenuItem mi in items)
            {
                if ((string)mi.Tag == Tag)
                {
                    return mi;
                }
                else if (mi.DropDownItems.Count > 0)
                {
                    ToolStripItem miResult = FindMenuItem(mi.DropDownItems, Tag);
                    if (miResult != null)
                        return miResult;
                }

            }

            return null;
        }

        private DataLayer.ShipmentMain GetCurrentRowObject()
        {
            return (ShipmentMain)tblShipments.GetItem(tblShipments.SelectedIndex).RowObject;
        }

        private bool SearchBy(bool FromBegin,string SearchText)//,  Predicate<int> condition)
        {
            int startRow = FromBegin ? 0 : tblShipments.SelectedIndex + 1;
            tblShipments.SelectedObjects = null;
            ListViewItem listViewItem = tblShipments.FindItemWithText(SearchText, true, startRow);
            if (listViewItem !=null)
            {
                listViewItem.Selected = true;
                return true;
            }
            
            /*
            for (int i = startRow; i <= tblShipments.Rows.Count - 1; i++)
                if (condition(i))
                {

                    tblShipments.CurrentRow.Selected = false;
                    DataGridViewCell cell = tblShipments.Rows[i].Cells["colOrderId"];
                    tblShipments.CurrentCell = cell;
                    tblShipments.Rows[i].Selected = true;

                    return true;
                }
            */
            return false;
            

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
            if (!isPaint)
            {
                return;
            }
            ShipmentMain item = (ShipmentMain)e.Item.RowObject;
            if ( item.RowNumberRange != null)
            {
                e.Item.BackColor = rowColors[(int)item.RowNumberRange];
            }
            bool isDone = false;
            if (!String.IsNullOrEmpty(item.OrderStatus))
            {

                isDone = item.OrderStatus.Contains("Выполнен");
            }
            if (isDone)
            {
                e.Item.ForeColor = Color.DarkGray;
            }
            else if (item.IsAddLv != true)
            {
                e.Item.ForeColor = Color.Blue;
            }
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

            ShipmentParam shipmentAddResult = new ShipmentParam();
            ShipmentAdd frmShipmentAdd = new ShipmentAdd(shipmentAddResult);
            DialogResult result = frmShipmentAdd.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {


                if (result == DialogResult.Retry)
                {
                    ShipmentEdit(shipmentAddResult);
                }
                ShipmentsLoad();
            }

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
            SetFormPrivalage(frmWarehouse, "Warehouse");
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
            SetFormPrivalage(frmCustomPosts, "CustomPost");
            AddFormTab(frmCustomPosts, "Таможенные посты");
        }

        private void menuItemDictGates_Click(object sender, EventArgs e)
        {
            GateForm frmGate = new GateForm();
            SetFormPrivalage(frmGate, "Gate");
            AddFormTab(frmGate, "Ворота");
            
        }

        private void panelFormHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuItemDictDepositor_Click(object sender, EventArgs e)
        {
            Depositors frmDepositors = new Depositors();
            SetFormPrivalage(frmDepositors, "Depositor");
            AddFormTab(frmDepositors, "Депозиторы");
        }

        private void menuItemDictOpersType_Click(object sender, EventArgs e)
        {
            /*
            DictSimple dict = new DictSimple();
            dict.TableName = "opers_type";
            dict.Title = "Справочник: Типы операций";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 20 });
            */
            //SimpleDict<DataLayer.OperTy, DataLayer.GatewayRepository> frmOperType = new SimpleDict(dict);
            //SetFormPrivalage(frmOperType, "OperType");
            //AddFormTab(frmOperType, "Типы операций");
        }

        private void menuItemDictTimeSlot_Click(object sender, EventArgs e)
        {
            var frmTimeSlot = new TimeSlots();
            SetFormPrivalage(frmTimeSlot, "TimeSlot");
            AddFormTab(frmTimeSlot, "Тайм слоты");
        }

        private void menuItemDictTC_Click(object sender, EventArgs e)
        {

            TransportCompanyForm frmTransportCompany = new TransportCompanyForm();
            SetFormPrivalage(frmTransportCompany, "TC");
            AddFormTab(frmTransportCompany, "Транспортные компании");
        }

        private void menuItemDictDelayReasons_Click(object sender, EventArgs e)
        {

            var frmDelayReasons = new DictDelayReasons();
            SetFormPrivalage(frmDelayReasons, "DelayReasons");
            AddFormTab(frmDelayReasons, "Причины задержки");
        }

        private void menuItemDoctSupplier_Click(object sender, EventArgs e)
        {

            var frmSupplier = new Suppliers();
            SetFormPrivalage(frmSupplier, "Supplier");
            AddFormTab(frmSupplier, "Поставщики");
        }

        private void menuItemDictAttributes_Click(object sender, EventArgs e)
        {
            var frmShimentElements = new ShipmentElements();
            SetFormPrivalage(frmShimentElements, "Attr");
            AddFormTab(frmShimentElements, "Элементы отгрузки");
        }

        private void menuItemDictTransportType_Click(object sender, EventArgs e)
        {
            var frmTransporType = new TransportTypeForm();
            SetFormPrivalage(frmTransporType, "TransporType");
            AddFormTab(frmTransporType, "Типы транспорта");
            
        }

        private void menuItemDictTransportView_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if ( !SearchBy(true, edSearch.Text))
            {
                ShipmentRepository shipmentRepository = new ShipmentRepository();
                DataLayer.Shipment shipment = shipmentRepository.GetByLvOrderCode(edSearch.Text);
                if(shipment != null)
                {
                    edCurrDay.Value = (DateTime)shipment.SDate;
                    SearchBy(true, edSearch.Text);
                }
            }
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            frmShipmentHistory frmShipment_History = new frmShipmentHistory(-1, false);
            AddFormTab(frmShipment_History, "История изменений");
            frmShipment_History.Populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ShipmentMain shipmentMain = GetCurrentRowObject();
            if (MessageBox.Show("Удалить запись?", "Подверждение", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (shipmentMain.InOut != "перем")
            {
                ShipmentRepository shipmentRepository = new ShipmentRepository();
                DataLayer.Shipment shipment = shipmentRepository.GetById(shipmentMain.ShpId);
                shipment?.Delete();
                try
                {
                    if (shipmentRepository.Save(shipment))
                    {
                        _shipmentMainList.Remove(shipmentMain);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении строки: {ex.Message}");

                }
            }
            else
            {
                MovementRepository movementRepository = new MovementRepository();

                DataLayer.Movement movement = movementRepository.GetById(shipmentMain.ShpId);
                movement?.Delete();
                try
                {
                    if (movementRepository.Save(movement))
                    {
                        _shipmentMainList.Remove(shipmentMain);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении строки: {ex.Message}");
                } 


            }
            UpdateDataSource(_shipmentMainList);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            ShipmentMain shipmentMain = GetCurrentRowObject();
            if (shipmentMain == null)
                return;

            SettingReport settingReport = Common.setting.Reports.Find(r => r.Name == (shipmentMain.ShpIn == false ? "Лист отгрузки" : "Лист прихода"));
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

        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            SearchBy(false, edSearch.Text);
        }

        private void edSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                btnSearch_Click(sender, e);
            }
        }

        private void menuItemDictUserGroups_Click(object sender, EventArgs e)
        {
            var frmUserGroups = new UserGroups();
            SetFormPrivalage(frmUserGroups, "UserGrp");
            AddFormTab(frmUserGroups, "Группы пользователей");
        }

        private void menuItemDictUsers_Click(object sender, EventArgs e)
        {
            var frmUsers = new Users();
            SetFormPrivalage(frmUsers, "Users");
            AddFormTab(frmUsers, "Пользователи");
        }

        private void tblShipments_DoubleClick(object sender, EventArgs e)
        {
            ShipmentRowEdit();
        }

        private void menuItemConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsWizard frmSettingsWizard = new SettingsWizard(Common.setting);
            if (frmSettingsWizard.ShowDialog() == DialogResult.OK)
            {
                Common.settingsHandle.Save();
                return;
            }
        }

        private void menuItemReportPeriod_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepPeriod repPeriod = new RepPeriod(reportParams);



            if (repPeriod.ShowDialog() == DialogResult.OK)
            {

                ShowReport(REPORT_PERIOD, reportParams);
            }
        }


        #region Reports

        private SettingReport GetReportSetting(string reportName)
        {
            return Common.setting.Reports.Find(r => r.Name == reportName);

        }
        private void ShowReport(int ReportId, ReportParams reportParams)
        {
            switch (ReportId)
            {
                case REPORT_PERIOD:
                    ShowReportPeriod(reportParams);
                    break;
                case REPORT_STATISTIC:
                    ShowReportStatistic(reportParams);
                    break;
                case REPORT_TC:
                    ShowReportTC(reportParams);
                    break;
                default:
                    break;
            }
        }

        private void ShowReportTC(ReportParams reportParams)
        {
            
            SettingReport settingReport = GetReportSetting("Отчет по ТС");
            if (settingReport == null)
            {
                MessageBox.Show("Не задан шаблон", "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExcelPrint excel;
            Excel.Range range;
            try
            {

                excel = new ExcelPrint(settingReport.TemplatePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            miRepTC.Enabled = false;
            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();
            wait.SetText("Формирование отчета: получение данных....");


            SqlHandle sql = new SqlHandle(Common.BuildConnectionString(ConnectionParams.ServerName, ConnectionParams.BaseName, ConnectionParams.UserName, ConnectionParams.Pwd));
            sql.SqlStatement = "SP_PL_ReportTC";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;

            DateTime beginDate;
            DateTime endDate;

            DateTime? beginDateN = null;
            DateTime? endDateN = null;


            if (DateTime.TryParse(reportParams["PeriodBegin"], out beginDate))
                beginDateN = (DateTime?)beginDate;

            if (DateTime.TryParse(reportParams["PeriodEnd"], out endDate))
                endDateN = (DateTime?)endDate;


            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = beginDateN });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = endDateN });
            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка при выборке данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!sql.HasRows())
            {
                MessageBox.Show("Нет данных для формирования отчета", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            excel.SetValue(1, 1, 2, "Данные по ТС за период с " + reportParams["PeriodBegin"] + " по " + reportParams["PeriodEnd"] + ". Опоздание (часы, минуты), с учетом допуска +20 мин");
            wait.SetRange(0, sql.DataSet.Tables[0].Rows.Count);
            wait.SetPosition(1);
            wait.SetText("Формирование отчета: вывод данных....");




            int rowIdx = 0;
            Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string[,] printRow = new string[1, sql.DataSet.Tables[0].Columns.Count];
            foreach (DataRow r in sql.DataSet.Tables[0].Rows)
            {

                for (int colIdx = 0; colIdx < sql.DataSet.Tables[0].Columns.Count; colIdx++)
                {
                    string value = r[colIdx].ToString();
                    if (colIdx == 8)
                    {

                        value = value == "" ? "" : Decimal.Parse(r[colIdx].ToString().Replace(',', separator)).ToString().Replace(separator, ',');
                    }

                    printRow[0, colIdx] = value;
                }
                excel.SetRowValues(1, rowIdx + 5, sql.DataSet.Tables[0].Columns.Count, printRow);
                rowIdx++;
                wait.SetPosition(rowIdx);
            }


            range = excel.SelectCells(1, 1, 5, sql.DataSet.Tables[0].Columns.Count, rowIdx + 4);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            excel.Visible = true;
            wait.Close();
            miRepTC.Enabled = true;
            
        }

        private void ShowReportStatistic(ReportParams reportParams)
        {
            
            SettingReport settingReport = GetReportSetting("Статистика за период");
            if (settingReport == null)
            {
                MessageBox.Show("Не задан шаблон", "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ExcelPrint excel;
            Excel.Range range;
            try
            {

                excel = new ExcelPrint(settingReport.TemplatePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            miRepStatistic.Enabled = false;
            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();
            wait.SetText("Формирование отчета: получение данных....");

            string year = reportParams["Year"];
            string monthBegin = reportParams["MonthBegin"];
            string monthEnd = reportParams["MonthEnd"];
            string admCoef = reportParams["AdmCoeff"];

            string dateBegin = String.Format("01.{0}.{1}", monthBegin, year);
            string dateEnd = String.Format("{0}.{1}.{2}", DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(monthEnd)), monthEnd, year);

            SqlHandle sql = new SqlHandle(Common.BuildConnectionString(ConnectionParams.ServerName, ConnectionParams.BaseName, ConnectionParams.UserName, ConnectionParams.Pwd));
            sql.SqlStatement =
                string.Format(@"select m.m_name,'' div_kpi,
                    (
			            select count(so1.id) so_count 
			            from shipments s1			
				            join shipment_orders so1 on s1.id = so1.shipment_id
			            where 
				            s1.submission_time is not null
				            and YEAR(s_date) = t.s_year
				            and MONTH(s_date) =t.s_month		
		            ) s_count, 
                    count(distinct t.s_id) tc_count, 
		            sum(in_before_plan) in_before_plan,
		            sum(in_after_plan) in_after_plan,
		            sum(in_plan) in_plan,
		            sum(out_before_plan) out_before_plan,
		            sum(out_after_plan) out_after_plan,
		            sum(out_plan) out_plan
                from
	                (select 1 m_id, 'Январь' m_name
	                union
	                select 2, 'Февраль'
	                union
	                select 3, 'Март'
	                union
	                select 4, 'Апрель'
	                union
	                select 5, 'Май'
	                union
	                select 6, 'Июнь'
	                union
	                select 7, 'Июль'
	                union
	                select 8, 'Август'
	                union
	                select 9, 'Сентябрь'
	                union
	                select 10, 'Октябрь'
	                union
	                select 11, 'Ноябрь'
	                union
	                select 12, 'Декабрь'
                )m
                left join
                (
                    select YEAR(s_date) s_year, MONTH(s_date) s_month,  s.s_date,s.id s_id,

                    case when s_in = 1 and s.submission_time < dateadd(minute,-{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast(ts.slot_time as varchar),104)) then 1 else 0 end in_before_plan,
                    case when s_in = 1 and s.submission_time > dateadd(minute,{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast(ts.slot_time as varchar),104)) then 1 else 0 end in_after_plan,
                    case when s_in = 1 and dateadd(minute,-{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast( ts.slot_time as varchar),104))
				                    <=s.submission_time and s.submission_time <=dateadd(minute,{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast( ts.slot_time as varchar),104)) then 1 else 0 end in_plan,

                    case when s_in = 0 and s.submission_time < dateadd(minute,-{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast( ts.slot_time as varchar),104)) then 1 else 0 end out_before_plan,
                    case when s_in = 0 and s.submission_time > dateadd(minute,{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast( ts.slot_time as varchar),104)) then 1 else 0 end out_after_plan,
                    case when s_in = 0 and dateadd(minute,-{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast( ts.slot_time as varchar),104))
				                    <=s.submission_time and s.submission_time <=dateadd(minute,{0},convert(datetime,convert(varchar,s_date,103)+ ' '+cast( ts.slot_time as varchar),104)) then 1 else 0 end out_plan

                    from shipments s
	                    join time_slot ts on s.time_slot_id = ts.id
                    where 
                        s.submission_time is not null
	                    and s_date >= convert(datetime,'{1}', 104)
	                    and s_date <=convert(datetime,'{2}', 104)
                ) t on t.s_month = m.m_id
                group by t.s_year,m.m_id, m.m_name,t.s_month
                order by m.m_id", admCoef, dateBegin, dateEnd);
            sql.Connect();
            sql.TypeCommand = CommandType.Text;
            sql.IsResultSet = true;

            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка при выборке данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            excel.SetValue(1, 1, 2, "Статистика за " + year + " год ");
            wait.SetRange(0, sql.DataSet.Tables[0].Rows.Count);
            wait.SetPosition(1);
            wait.SetText("Формирование отчета: вывод данных....");
            int rowIdx = 0;
            string[,] printRow = new string[1, sql.DataSet.Tables[0].Columns.Count];
            foreach (DataRow r in sql.DataSet.Tables[0].Rows)
            {

                for (int colIdx = 0; colIdx < sql.DataSet.Tables[0].Columns.Count; colIdx++)
                {
                    printRow[0, colIdx] = r[colIdx].ToString();
                }
                excel.SetRowValues(1, rowIdx + 5, sql.DataSet.Tables[0].Columns.Count, printRow);
                rowIdx++;
                wait.SetPosition(rowIdx);
            }

            range = excel.SelectCells(1, 1, 5, sql.DataSet.Tables[0].Columns.Count, rowIdx + 4);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            excel.Visible = true;
            wait.Close();
            miRepStatistic.Enabled = true;
            
        }
        
        private void ShowReportPeriod(ReportParams reportParams)
        {
            //bwProgress.RunWorkerAsync(reportParams);





            List<string> columnOrder = new List<string> {"ShpId","OrdId","ShpDate","SlotTime","InOut","OrdLVCode","OrdLVType",
                "KlientName","OrderStatus","PrcReady","ShpComment","OrdComment","GateName","ShpSpecialCond","ShpDriverPhone",
                "ShpDriverFio","TransportCompanyName","TransportTypeName","ShpVehicleNumber","ShpTrailerNumber","ShpAttorneyNumber",
                "ShpAttorneyDate","ShpSubmissionTime","ShpStartTime", "ShpEndTimePlan","ShpEndTimeFact","CALC:CONCAT(ShpDate,SlotTime)",
                "CALC:DIFFTIME(ShpSubmissionTime,ShpStartTime)","CALC:DIFFTIME({26},ShpStartTime)","CALC:DIFFTIME({26},ShpSubmissionTime)",
                "ShpDelayReasonName", "ShpDelayComment",  "ShpStampNumber","ShpSupplierName" };
            //"DepCode",
            int[] colNumber = new int[columnOrder.Count];

            SettingReport settingReport = GetReportSetting("Отгрузки за период");
            if (settingReport == null)
            {
                MessageBox.Show("Не задан шаблон", "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExcelPrint excel;
            try
            {

                excel = new ExcelPrint(settingReport.TemplatePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            miRepPeriod.Enabled = false;
            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();
            wait.SetText("Формирование отчета: получение данных....");

            Excel.Range range;
            int ShpType = int.Parse(reportParams["ShpType"]) - 1;



            //DataSet dataSet = GetShipment(DateTime.Parse(reportParams["PeriodBegin"]), DateTime.Parse(reportParams["PeriodEnd"]), null, null, ShpType);


            SqlHandle sql = new SqlHandle(Common.BuildConnectionString(ConnectionParams.ServerName, ConnectionParams.BaseName, ConnectionParams.UserName, ConnectionParams.Pwd));
            sql.SqlStatement = "SP_PL_MainQueryP";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            object shpType = null;
            if (ShpType >= 0)
                shpType = ShpType;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateTime.Parse(reportParams["PeriodBegin"]) });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTime.Parse(reportParams["PeriodEnd"]) });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = shpType });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ShpId", Value = null });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@OrdID", Value = null });

            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //GetOrderDetailCount();

            DataSet dataSet = sql.DataSet;


            //SqlDataReader dataRows = GetShipment(edCurrDay.Value, null, null, null);


            excel.SetValue(1, 6, 2, "Данные за период с " + reportParams["PeriodBegin"] + " по " + reportParams["PeriodEnd"]);


            wait.SetRange(0, dataSet.Tables[0].Rows.Count);
            wait.SetPosition(1);
            wait.SetText("Формирование отчета: вывод данных....");

            //Получим индексы колонок в резалсете

            int rowIdx = 0;

            string[,] printRow = new string[1, columnOrder.Count];
            foreach (DataRow r in dataSet.Tables[0].Rows)
            {
                string cellValue;

                for (int colIdx = 0; colIdx < columnOrder.Count; colIdx++)
                {
                    cellValue = "";
                    if (!columnOrder[colIdx].StartsWith("CALC"))
                    {

                        cellValue = r[columnOrder[colIdx]].ToString();
                    }
                    else
                    {
                        cellValue = CalculateColumnValue(r, printRow, columnOrder[colIdx].Substring(5));
                    }
                    if (columnOrder[colIdx] == "ShpDate")
                    {
                        //columnOrder[colIdx]
                        cellValue = r[columnOrder[colIdx]].ToString().Substring(0, 10);
                    }
                    printRow[0, colIdx] = cellValue;

                    //excel.SetValue(1, colIdx + 1, rowIdx, cellValue);
                    // 

                }
                //excel.SetValues(1, 1, rowIdx + 5, columnOrder.Count, rowIdx + 5, printRow);
                excel.SetRowValues(1, rowIdx + 5, columnOrder.Count, printRow);
                rowIdx++;
                wait.SetPosition(rowIdx);
            }

            range = excel.SelectCells(1, 1, 5, columnOrder.Count, rowIdx + 4);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            excel.Visible = true;
            wait.Close();
            miRepPeriod.Enabled = true;
        }
        
        
        /*private void ShowReportPeriod(ReportParams reportParams)
        {
            //bwProgress.RunWorkerAsync(reportParams);





            List<string> columnOrder = new List<string> {"ShpId","OrdId","ShpDate","SlotTime","InOut","OrdLVCode","OrdLVType",
                "KlientName","OrderStatus","PrcReady","ShpComment","OrdComment","GateName","ShpSpecialCond","ShpDriverPhone",
                "ShpDriverFio","TransportCompanyName","TransportTypeName","ShpVehicleNumber","ShpTrailerNumber","ShpAttorneyNumber",
                "ShpAttorneyDate","ShpSubmissionTime","ShpStartTime", "ShpEndTimePlan","ShpEndTimeFact","CALC:CONCAT(ShpDate,SlotTime)",
                "CALC:DIFFTIME(ShpSubmissionTime,ShpStartTime)","CALC:DIFFTIME({26},ShpStartTime)","CALC:DIFFTIME({26},ShpSubmissionTime)",
                "ShpDelayReasonName", "ShpDelayComment",  "ShpStampNumber","ShpSupplierName" };
            //"DepCode",
            int[] colNumber = new int[columnOrder.Count];

            SettingReport settingReport = GetReportSetting("Отгрузки за период");
            if (settingReport == null)
            {
                MessageBox.Show("Не задан шаблон", "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExcelPrint excel;
            try
            {

                excel = new ExcelPrint(settingReport.TemplatePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            miRepPeriod.Enabled = false;
            frmProgressBar wait = new frmProgressBar(0, 100);
            wait.TopLevel = true;
            wait.TopMost = true;
            wait.Show();
            wait.SetText("Формирование отчета: получение данных....");
            
            SLDocument report = new SLDocument(settingReport.TemplatePath);

            //Excel.Range range;
            int ShpType = int.Parse(reportParams["ShpType"]) - 1;

            //DataSet dataSet = GetShipment(DateTime.Parse(reportParams["PeriodBegin"]), DateTime.Parse(reportParams["PeriodEnd"]), null, null, ShpType);
            List<ShipmentMain> _shipmentMainPeriod = new List<ShipmentMain>();
            try
            {
               _shipmentMainPeriod = shipmentMainRepository.GetAll(DateTime.Parse(reportParams["PeriodBegin"]), DateTime.Parse(reportParams["PeriodEnd"]), null, null, ShpType);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //DataSet dataSet = new DataSet();
            



            report.SetCellValue(2, 6, "Данные за период с " + reportParams["PeriodBegin"] + " по " + reportParams["PeriodEnd"]);
            //excel.SetValue(1, 6, 2, "Данные за период с " + reportParams["PeriodBegin"] + " по " + reportParams["PeriodEnd"]);


            wait.SetRange(0, _shipmentMainPeriod.Count);
            wait.SetPosition(1);
            wait.SetText("Формирование отчета: вывод данных....");

            //Получим индексы колонок в резалсете
            
             //List<string> columnOrder = new List<string> {"ShpId","OrdId","ShpDate","SlotTime","InOut","OrdLVCode","OrdLVType",
             //   "KlientName","OrderStatus","PrcReady","ShpComment","OrdComment","GateName","ShpSpecialCond","ShpDriverPhone",
             //   "ShpDriverFio","TransportCompanyName","TransportTypeName","ShpVehicleNumber","ShpTrailerNumber","ShpAttorneyNumber",
             //   "ShpAttorneyDate","ShpSubmissionTime","ShpStartTime", "ShpEndTimePlan","ShpEndTimeFact","CALC:CONCAT(ShpDate,SlotTime)",
             //   "CALC:DIFFTIME(ShpSubmissionTime,ShpStartTime)","CALC:DIFFTIME({26},ShpStartTime)","CALC:DIFFTIME({26},ShpSubmissionTime)",
             //   "ShpDelayReasonName", "ShpDelayComment",  "ShpStampNumber","ShpSupplierName" };
            
            int rowIdx = 0;
            foreach (var item in _shipmentMainPeriod)
            {
                report.SetCellValue(rowIdx + 5, 1, (int)item.ShpId);
                report.SetCellValue(rowIdx + 5, 2, (int)item.OrdId);
                report.SetCellValue(rowIdx + 5, 3, (DateTime)item.ShpDate);
                report.SetCellValue(rowIdx + 5, 4, item.SlotTime.ToString());
                report.SetCellValue(rowIdx + 5, 5, item.InOut);
                report.SetCellValue(rowIdx + 5, 6, item.OrdLVCode);
                report.SetCellValue(rowIdx + 5, 7, item.OrdLVType);
                report.SetCellValue(rowIdx + 5, 8, item.KlientName);
                report.SetCellValue(rowIdx + 5, 9, item.OrderStatus);
                report.SetCellValue(rowIdx + 5, 10, item.PrcReady);
                report.SetCellValue(rowIdx + 5, 11, item.ShpComment);
                report.SetCellValue(rowIdx + 5, 12, item.OrdComment);
                report.SetCellValue(rowIdx + 5, 13, item.GateName);
                report.SetCellValue(rowIdx + 5, 14, (bool)item.ShpSpecialCond);
                report.SetCellValue(rowIdx + 5, 15, item.ShpDriverPhone);
                report.SetCellValue(rowIdx + 5, 16, item.ShpDriverFio);
                report.SetCellValue(rowIdx + 5, 17, item.TransportCompanyName);
                report.SetCellValue(rowIdx + 5, 18, item.TransportTypeName);
                report.SetCellValue(rowIdx + 5, 19, item.ShpVehicleNumber);
                report.SetCellValue(rowIdx + 5, 20, item.ShpTrailerNumber);
                report.SetCellValue(rowIdx + 5, 21, item.ShpAttorneyNumber);
                report.SetCellValue(rowIdx + 5, 22, (DateTime)item.ShpAttorneyDate);
                report.SetCellValue(rowIdx + 5, 23, (DateTime)item.ShpSubmissionTime);
                report.SetCellValue(rowIdx + 5, 24, (DateTime)item.ShpStartTime);
                report.SetCellValue(rowIdx + 5, 25, (DateTime)item.ShpEndTimePlan);
                report.SetCellValue(rowIdx + 5, 26, (DateTime)item.ShpEndTimeFact);
                DateTime planDateTime = ((DateTime)item.ShpDate).Add((TimeSpan)item.SlotTime);
                report.SetCellValue(rowIdx + 5, 27, planDateTime.ToString());
                
                //TimeSpan diff;
                //if (item.ShpDate != null && item.SlotTime !=null)
                //{
                //    DateTime SlotTime = DateTime.Parse(item.SlotTime.ToString());
                //    diff = (DateTime)item.ShpDate - SlotTime;
                //    report.SetCellValue(rowIdx + 5, 28, diff.ToString());
                //}
                
                if (item.ShpSubmissionTime !=null && item.ShpStartTime !=null)
                {
                    TimeSpan diffTime = (DateTime)item.ShpSubmissionTime - (DateTime)item.ShpStartTime;
                    report.SetCellValue(rowIdx + 5, 27, diffTime.ToString(@"hh\:mm\:ss"));
                }
                if (item.ShpStartTime != null)
                {
                    TimeSpan diffTime = (DateTime)planDateTime - (DateTime)item.ShpStartTime;
                    report.SetCellValue(rowIdx + 5, 28, diffTime.ToString(@"hh\:mm\:ss"));
                }
                if (item.ShpSubmissionTime != null)
                {
                    TimeSpan diffTime = (DateTime)planDateTime - (DateTime)item.ShpSubmissionTime;
                    report.SetCellValue(rowIdx + 5, 29, diffTime.ToString(@"hh\:mm\:ss"));
                }
                report.SetCellValue(rowIdx + 5, 30, item.OrdLVCode);
                report.SetCellValue(rowIdx + 5, 31, item.ShpDelayReasonName);
                report.SetCellValue(rowIdx + 5, 32, item.ShpDelayComment);
                report.SetCellValue(rowIdx + 5, 33, item.ShpStampNumber);
                report.SetCellValue(rowIdx + 5, 34, item.ShpSupplierName);


            }

            
            //string[,] printRow = new string[1, columnOrder.Count];
            //foreach (DataRow r in dataSet.Tables[0].Rows)
            //{
            //    string cellValue;

            //    for (int colIdx = 0; colIdx < columnOrder.Count; colIdx++)
            //    {
            //        cellValue = "";
            //        if (!columnOrder[colIdx].StartsWith("CALC"))
            //        {

            //            cellValue = r[columnOrder[colIdx]].ToString();
            //        }
            //        else
            //        {
            //            cellValue = CalculateColumnValue(r, printRow, columnOrder[colIdx].Substring(5));
            //        }
            //        if (columnOrder[colIdx] == "ShpDate")
            //        {                        
            //            cellValue = r[columnOrder[colIdx]].ToString().Substring(0, 10);
            //        }
            //        printRow[0, colIdx] = cellValue;

            //    }
                
            //    excel.SetRowValues(1, rowIdx + 5, columnOrder.Count, printRow);
            //    rowIdx++;
            //    wait.SetPosition(rowIdx);
            //}

            //range = excel.SelectCells(1, 1, 5, columnOrder.Count, rowIdx + 4);
            //range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            //range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            //range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            //range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            //range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            
            //excel.Visible = true;
            report.SaveAs(System.IO.Path.GetTempPath()+"1.xlsx");
            wait.Close();
            miRepPeriod.Enabled = true;
        }
        */
        private string CalculateColumnValue(DataRow context, string[,] currentPrintRow, string Expr)
        {
            string result = "";

            var m = Regex.Match(Expr, @"^\s*(\w+)\s*\((.*)\)");
            string[] param = null;
            if (m.Groups.Count > 2)
            {
                if (m.Groups[2].Value.IndexOf(',') > 0)
                    param = m.Groups[2].Value.Split(new char[] { ',' });
                else
                    param = new string[] { m.Groups[2].Value };

            }

            for (int i = 0; i < param.Length; i++)
            {
                if (param[i].StartsWith("[") && param[i].EndsWith("]"))
                    param[i] = param[i].Trim(new char[] { '[', ']' });
                else
                {

                    if (param[i].StartsWith("{") && param[i].EndsWith("}"))
                    {
                        param[i] = currentPrintRow[0, Int32.Parse(param[i].Trim('{', '}'))];
                    }
                    if (context.Table.Columns.Contains(param[i]))
                    {
                        if (param[i] == "ShpDate")
                            param[i] = context[param[i]].ToString().Substring(0, 10);
                        else
                            param[i] = context[param[i]].ToString();
                    }

                }
            }

            switch (m.Groups[1].Value)
            {
                case "CONCAT":
                    result = String.Join(" ", param);
                    break;
                case "DIFFTIME":
                    DateTime dateTime1;
                    DateTime dateTime2;
                    if (!DateTime.TryParse(param[0], out dateTime1))
                        return "";
                    if (!DateTime.TryParse(param[1], out dateTime2))
                        return "";
                    TimeSpan diff = dateTime1 - dateTime2;
                    return diff.ToString(@"hh\:mm\:ss");
                default:
                    break;
            }


            foreach (Group item in m.Groups)
            {
                Console.WriteLine(item.Value);
            }

            return result;
        }

        #endregion

        private void menuItemReportStatistic_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepStatistic repStatistic = new RepStatistic(reportParams);
            if (repStatistic.ShowDialog() == DialogResult.OK)
            {
                ShowReport(REPORT_STATISTIC, reportParams);
            }
        }

        private void menuItemReportTC_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepTC repTC = new RepTC(reportParams);
            if (repTC.ShowDialog() == DialogResult.OK)
            {
                ShowReport(REPORT_TC, reportParams);
            }
        }

        private void toolStripMenuItemFilterIn_Click(object sender, EventArgs e)
        {
            ShipmentsUIFilter();
            Common.settingsHandle.SetParamValue("View\\ActionFilter", String.Join(",", GetFilterActionList().ToArray()));
        }

        private void tblShipments_ButtonClick(object sender, CellClickEventArgs e)
        {
            
            ShowOrderDetail((ShipmentMain)e.Item.RowObject);
        }

        private void cbPaint_CheckedChanged(object sender, EventArgs e)
        {
            isPaint = cbPaint.Checked;
            tblShipments.BuildList();
        }

        private void tmUpdate_Tick(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }

        private void cbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            tmUpdate.Interval = (int)edInterval.Value * 1000;
            tmUpdate.Enabled = cbUpdate.Checked;
        }

        private void edInterval_ValueChanged(object sender, EventArgs e)
        {
            tmUpdate.Interval = (int)edInterval.Value;
        }

        private void menuItemCalcOrderVolume_Click(object sender, EventArgs e)
        {
            frmVolumeCalc frmVolumeCalc = new frmVolumeCalc(Common.setting);
            AddFormTab(frmVolumeCalc, "Расчет объема заказа");
        }

        private void menuItemCurrentTask_Click(object sender, EventArgs e)
        {
            frmCurrentTask frmCurrentTask = new frmCurrentTask();
            frmCurrentTask.ShowDialog();
        }

        private void btnSearchEx_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch(edCurrDay.Value);
            AddFormTab(frmSearch, "Расширенный поиск");
        }
    }
}
