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
using DocumentFormat.OpenXml.Packaging;



namespace Planning
{
    public partial class MainFormEx : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        const int REPORT_PERIOD = 101;
        const int REPORT_STATISTIC = 102;
        const int REPORT_TC = 103;
        const int REPORT_PERIOD_V2 = 104;
        const int REPORT_RATING_CARRIER = 105;

        bool isWindowMaximized = false;
        Point offset;
        Size _normalWindowSize;
        Point _normalWindowLocation = Point.Empty;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        string CR = Environment.NewLine;
        List<string> hideCols;
        List<ShipmentColumn> shipmentColumns = new List<ShipmentColumn>();
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };
        ShipmentMainRepository shipmentMainRepository;
        List<ShipmentMain> _shipmentMainList;
        List<UserFunctionPrvlg> UserPrvlgs= new List<UserFunctionPrvlg>();
        UserFunctionPrvlg mainFormPrvlg = new UserFunctionPrvlg();
        bool isPaint = true;
        bool IsFormLoad = false;
        bool IsBuilded = false;
        CellBorderDecoration standardDecoration = new CellBorderDecoration();
        string pathConfig = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Planning\";
        public MainFormEx()
        {
            InitializeComponent();
        }

        private void MainFormEx_Load(object sender, EventArgs e)
        {

            IsFormLoad = true;
            Init();
            Connect();
            

            //GetUserPrvlg();
           // SetMainFormPrvlg();

            shipmentMainRepository = new ShipmentMainRepository();
            SetupColumns();
            SetupButtons();
            PopulateWarehouseFilter();
            ShipmentsLoad();
            SetColumnsParam();
            //tblShipments.DrawSubItem += TblShipments_DrawSubItem;
            //tblShipments.DrawItem += TblShipments_DrawItem;
            
            cbPaint.Checked = isPaint;
            IsFormLoad = false;

        }

        private void TblShipments_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TblShipments_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = false;
            Pen p = new Pen(Color.Red);
            e.Graphics.DrawRectangle(p, e.Bounds);
            e.DrawText();
        }

        private void SetColumnsParam()
        {
            shipmentColumns = Common.settingsHandle.GetParamList<ShipmentColumn>("View\\ShipmentColumns");
            if (shipmentColumns.Count == 0)
            {
                foreach (ColumnHeader col in tblShipments.Columns)
                {
                    
                    shipmentColumns.Add(new ShipmentColumn() { Id = col.Name, Order = col.DisplayIndex });
                }
            }

            foreach (ColumnHeader col in tblShipments.Columns)
            {
                if (col.DisplayIndex < 0) continue;
                var shpCol = shipmentColumns.FirstOrDefault(c => c.Id == col.Name);
                if (col.Name == "colOrderDetail")
                {
                    col.DisplayIndex = 0;
                }
                else if (col.Name == "col")
                {
                    col.DisplayIndex = 1;
                }

                else if (shpCol != null)
                {
                    if (shpCol.Order < tblShipments.Columns.Count)
                        col.DisplayIndex = shpCol.Order;
                    if (shpCol.Width > 0)
                        col.Width = shpCol.Width;
                }
                
            }

        }
        private void SetupColumns()
        {
            standardDecoration.BorderPen = new Pen(Color.FromArgb(130,130,130));
           // standardDecoration.BorderPen = new Pen(Color.FromArgb(91, 94, 199));
            standardDecoration.FillBrush = null;
            standardDecoration.BoundsPadding = Size.Empty;
            standardDecoration.CornerRounding = 0;

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
            BarRendererEx barRendererEx = new BarRendererEx();
            barRendererEx.MaximumValue = 1D;

            Color progressBarColor = Color.LightGreen; //Color.FromArgb(53,162,62);
            //barRendererEx.BackgroundColor = Color.Green;
            barRendererEx.UseStandardBar = false;
            barRendererEx.GradientStartColor = progressBarColor;
            barRendererEx.GradientEndColor = progressBarColor;
            barRendererEx.TextBrush = new SolidBrush(Color.Black);

            //this.colDate.Renderer = new GridRender();
            colDoneShare.Renderer = barRendererEx;
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
            ShipmentsLoad();
        }
        private void ShipmentEdit(ShipmentParam shipmentAddResult)
        {
            ShipmenEdit frmShipmentEdit;
            frmShipmentEdit = shipmentAddResult.IsShipment == true ? new ShipmenEdit((Shipment)shipmentAddResult.Result) : 
                new ShipmenEdit((Movement)shipmentAddResult.Result);
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
                    Shipment shipment = (Shipment)shipmentAddResult.Result;

                    ShipmentRepository shipmentRepository = new ShipmentRepository();

                    if (shipment.ShIn == true)
                    {
                        Common.ForceMergeLVAttribute(shipment.Id);

                    }
                    
                    if (shipment.IsAddLv == true)
                    {
                        AddShToLV(shipment);
                        //Common.AddShipmentToLV(shipment.Id);
                    }
                    
                }
                UpdateDataSource(_shipmentMainList);
                tblShipments.Refresh();
            }
        }
        void AddShToLV(Shipment shipment)
        {
            if (shipment.ShIn == false)
            {
                Common.AddShipmentToLV(shipment.Id);
            }

            //DataService.AddShipmentToLV(shipment.Id);
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
            IsBuilded = true;
            tblShipments.BeginUpdate();
            tblShipments.ClearObjects();
            tblShipments.SetObjects(listDataSource);
            tblShipments.EndUpdate();
            IsBuilded = false;
        }
        private void Init()
        {

            PlanningConfigHandle planningConfigHandle = new PlanningConfigHandle("PlanningConfig.xml", Common.PlanningConfig);
            planningConfigHandle.Load();

            if (!Directory.Exists(pathConfig))
            {
                Directory.CreateDirectory(pathConfig);
            }
            //"Settings.xml"
            Common.settingsHandle = new PlanningSettingsHandle(Path.Combine(pathConfig, "Settings.xml"), Common.setting);
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
        private bool LoginUser(bool isReconnect)
        {
            FormLogin frmLogin = new FormLogin(isReconnect);
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
        private void Connect(bool isReconnect = false)
        {

            
            if (!LoginUser(isReconnect) && !isReconnect)
            {
                Environment.Exit(0);
                this.Close();
                return;
            }
            if (Common.CurrentUser != null)
            {
                GetUserPrvlg();
                SetMainFormPrvlg();
                statusInfo.Text = $"База данных:[{Common.PlanningConfig.BaseName}] Пользователь: [{Common.CurrentUser.Login}]";
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
            tblShipments.RebuildColumns();
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
            //MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            if (isWindowMaximized)
            {
                this.Location = _normalWindowLocation;
                this.Size = _normalWindowSize;
                //toolTip1.SetToolTip(_MaxButton, "Maximize");
                //_MaxButton.CFormState = MinMaxButton.CustomFormState.Normal;
                isWindowMaximized = false;
            }
            else
            {
                _normalWindowSize = this.Size;
                _normalWindowLocation = this.Location;
                Screen[] screens = Screen.AllScreens;
                Screen screen = Screen.FromControl(this);
                Rectangle rect = screen.WorkingArea;
                this.Location = new Point(screen.Bounds.X, screen.Bounds.Y);

                this.Size = new System.Drawing.Size(rect.Width, rect.Height);
                //toolTip1.SetToolTip(_MaxButton, "Restore Down");
                //_MaxButton.CFormState = MinMaxButton.CustomFormState.Maximize;
                isWindowMaximized = true;
            }
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

        private ShipmentMain GetCurrentRowObject()
        {
            return (ShipmentMain)tblShipments.GetItem(tblShipments.SelectedIndex).RowObject;
        }
        private List<ShipmentMain> GetShipmentRows(int? ShpId)
        {
            List<ShipmentMain> result = new List<ShipmentMain>();



            result = ((List<ShipmentMain>)tblShipments.Objects).Where(o => o.ShpId == ShpId).ToList();
            return result;
        }
        private bool SearchBy(bool FromBegin,string SearchText)//,  Predicate<int> condition)
        {
            int startRow = FromBegin ? 0 : tblShipments.SelectedIndex + 1;
            tblShipments.SelectedObjects = null;
            //var item = tblShipments.Objects.FirstOrDefault(o => ((ShipmentMain)o).OrdLVCode == SearchText);
            ShipmentMain findRow = _shipmentMainList.FirstOrDefault(o => o.OrdLVCode == SearchText);
            if (findRow != null) 
            {
                tblShipments.EnsureModelVisible(findRow);

                //tblShipments.SelectObject(findRow, true);
                var item = tblShipments.SelectedItem;
         
                tblShipments.SelectedObject = findRow;
                tblShipments.Focus();
                tblShipments.Invalidate();
                tblShipments.Refresh();
            }

             ListViewItem listViewItem = tblShipments.FindItemWithText(SearchText, true, startRow);
            if (listViewItem != null)
            {
                Font selectFont = new Font(listViewItem.Font.FontFamily, listViewItem.Font.Size,FontStyle.Bold);
               
                listViewItem.ForeColor = Color.Red;
                listViewItem.Font = selectFont;
            }
                /*if (listViewItem !=null)
               {

                   listViewItem.Selected = true;
                   tblShipments.SelectObject(listViewItem,true);
                   tblShipments.FocusedItem = listViewItem;
                   tblShipments.SelectedObject = listViewItem;
                   tblShipments.SelectedObjects.Add(listViewItem);
                   tblShipments.Invalidate();
                   tblShipments.Refresh();

                   return true;
               }*/

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
            var frmTransportView = new TransportViewForm();
            SetFormPrivalage(frmTransportView, "TransportView");
            AddFormTab(frmTransportView, "Виды транспорта");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if ( !SearchBy(true, edSearch.Text))
            {
                ShipmentRepository shipmentRepository = new ShipmentRepository();
                Shipment shipment = shipmentRepository.GetByLvOrderCode(edSearch.Text);
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
                if (shipment == null)
                {
                    return;
                }
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
            List<ShipmentMain> shipmentOrders =  GetShipmentRows(shipmentMain.ShpId);
            SettingReport settingReport = Common.setting.Reports.Find(r => r.Name == (shipmentMain.ShpIn == false ? "Лист отгрузки" : "Лист прихода"));
            if (settingReport == null || String.IsNullOrEmpty(settingReport.TemplatePath))
            {
                MessageBox.Show("Не задан шаблон печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (shipmentMain.ShpIn == false)
            {
                ReportHandler.PrintShipmentOut(shipmentMain, shipmentOrders, settingReport.TemplatePath);
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
            Connect(true);
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
                case REPORT_PERIOD_V2:
                    ShowReportPeriodV2(reportParams);
                    break;
                case REPORT_RATING_CARRIER:
                    ShowReportRatingCarriers(reportParams);
                    break;
                default:
                    break;
            }
        }

        private void ShowReportRatingCarriers(ReportParams reportParams)
        {

            SettingReport settingReport = GetReportSetting("Рейтинг перевозчиков");
            if (settingReport == null)
            {
                MessageBox.Show("Не задан шаблон", "Ошибка при формировании отчета", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DepositorRepository depositorRepository = new DepositorRepository();
            Depositor depositor = depositorRepository.GetById(1);
            if (depositor == null || String.IsNullOrEmpty(depositor.LvBase))
            {
                Common.ShowInformation("Не найдена база данных депозитора", "Предупреждение");
                return;
            }

            List<String> queryOut = new List<string>();


            DateTime periodBegin = DateTime.Parse(reportParams["PeriodBegin"]);
            DateTime periodEnd = String.IsNullOrEmpty(reportParams["PeriodEnd"]) ? periodBegin : DateTime.Parse(reportParams["PeriodEnd"]);
            int ShpType = int.Parse(reportParams["ShpType"]);

            #region Запросы

            queryOut.Add(String.Format(@"select distinct isnull(cmp_ShortName,'') KlientName, N'выход' InOut, vs.s_date ShpDate, vs.tc_name TransportCompanyName,vs.shp_id ShpId,
				cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime) PlanDate,
				vs.submission_time ShpSubmissionTime,vs.start_time ShpStartTime,
				vs.end_time ShpEndTimePlan, vs.leave_time ShpEndTimeFact,
				DATEDIFF(minute, vs.submission_time, cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime)) DelayMinutes,
				(select  kpi
					from
					(
					select 
							case when prev_minutes_delay is null then -1000000 else prev_minutes_delay end prev_minutes_delay,
							minutes_delay, kpi
					from
					(
					select lag(minutes_delay, 1) OVER (ORDER BY minutes_delay) AS prev_minutes_delay,
					minutes_delay, kpi
					from 
                            (
			                    select minutes_delay, kpi
			                    from transport_company_kpi_delay
			                    union all
			                    select 100000, 10
		                    )transport_company_kpi_delay

                    )t 
					)tt
					where
						DATEDIFF(minute, vs.submission_time, cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime)) > prev_minutes_delay 
						and DATEDIFF(minute, vs.submission_time, cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime))<= minutes_delay 
	            ) kpi
		        from 
			        v_shipments vs with(nolock)
			        left join shipment_orders so on (vs.shp_id = so.shipment_id) 
			        left join shipment_order_parts sop on sop.sh_order_id = so.id
			        left join {0}.dbo.LV_Order with(nolock) on ord_ID = so.lv_order_id 
	                left join {0}.dbo.LV_Customer with(nolock) on cus_ID = ord_CustomerID
	                left join {0}.dbo.LV_Company with (nolock) on cmp_ID = cus_CompanyID
	                where 
		                vs.s_in =0
                        and vs.tc_name is not null
		                and vs.s_date between '{1}' and '{2}'", depositor.LvBase, periodBegin, periodEnd));


            queryOut.Add(String.Format(@"select distinct isnull(cmp_ShortName,'') KlientName, N'выход' InOut, vs.s_date ShpDate, vs.tc_name TransportCompanyName,vs.shp_id ShpId,
				cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime) PlanDate,
				vs.submission_time ShpSubmissionTime,vs.start_time ShpStartTime,
				vs.end_time ShpEndTimePlan, vs.leave_time ShpEndTimeFact,
				DATEDIFF(minute, vs.submission_time, cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime)) DelayMinutes,
				(select  kpi
					from
					(
					select 
							case when prev_minutes_delay is null then -1000000 else prev_minutes_delay end prev_minutes_delay,
							minutes_delay, kpi
					from
					(
					select lag(minutes_delay, 1) OVER (ORDER BY minutes_delay) AS prev_minutes_delay,
					minutes_delay, kpi
					from 
                            (
			                    select minutes_delay, kpi
			                    from transport_company_kpi_delay
			                    union all
			                    select 100000, 10
		                    )transport_company_kpi_delay

                    )t 
					)tt
					where
						DATEDIFF(minute, vs.submission_time, cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime)) > prev_minutes_delay 
						and DATEDIFF(minute, vs.submission_time, cast(vs.s_date as datetime)+ cast(vs.slot_time as datetime))<= minutes_delay 
	            ) kpi
		        from 
			        v_shipments vs with(nolock)
			        left join shipment_orders so on (vs.shp_id = so.shipment_id) 
			        left join shipment_order_parts sop on sop.sh_order_id = so.id
			        left join {0}.dbo.LV_Receipt with(nolock) on rct_ID = so.lv_order_id
			        left join {0}.dbo.LV_Supplier with(nolock) on spl_ID = rct_SupplierID
			        left join {0}.dbo.LV_Company with (nolock) on cmp_ID = spl_CompanyID
	                where 
		                vs.s_in =1
		                and vs.s_date between '{1}' and '{2}'", depositor.LvBase, periodBegin, periodEnd));


            

            queryOut.Add(String.Concat(queryOut[0], " union all ", Environment.NewLine,queryOut[1]));

            #endregion


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
            sql.SqlStatement = queryOut[ShpType];
            sql.Connect();
            sql.IsResultSet = true;

            bool success = sql.Execute();

            if (!success)
            {
                Common.ShowError(sql.LastError, "Ошибка");
                return;
            }



            if (!sql.HasRows())
            {
                MessageBox.Show("Нет данных для формирования отчета", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            excel.SetValue(1, 1, 4, "Данные по за период с " + reportParams["PeriodBegin"] + " по " + reportParams["PeriodEnd"] );

       

            wait.SetRange(0, sql.DataSet.Tables[0].Rows.Count);
            wait.SetPosition(1);
            wait.SetText("Формирование отчета: вывод данных....");

            DataTable kpiTable = new DataTable();
            kpiTable.Columns.Add("TransportCompany", Type.GetType("System.String"));
            kpiTable.Columns.Add("Kpi_tc", Type.GetType("System.Decimal")).DefaultValue = 0;
            kpiTable.Columns.Add("Kpi_Count", Type.GetType("System.Int32")).DefaultValue = 0;
            
            TransportCompanyKpiDelayRepository companyKpiDelayRepository = new TransportCompanyKpiDelayRepository();
            List<TransportCompanyKpiDelay> transportCompanyKpiDelays = companyKpiDelayRepository.GetAll();
            foreach (var item in transportCompanyKpiDelays)
            {
                kpiTable.Columns.Add($"Col_{item.Kpi}", Type.GetType("System.Int32")).DefaultValue = 0;
            }
            kpiTable.Columns.Add($"Col_10", Type.GetType("System.Int32")).DefaultValue = 0;


            int rowIdx = 8;
            Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string[,] printRow = new string[1, sql.DataSet.Tables[0].Columns.Count-1];
            foreach (DataRow r in sql.DataSet.Tables[0].Rows)
            {
                
                for (int colIdx = 0; colIdx < sql.DataSet.Tables[0].Columns.Count-1; colIdx++)
                {
                    Type type =  sql.DataSet.Tables[0].Columns[colIdx].DataType;
                    object obValue = r[colIdx];
                    string value = r[colIdx].ToString();
                    if (colIdx == 10 && !String.IsNullOrEmpty(value))
                    {
                        value = Common.MinutesToTimeSpan(int.Parse(value));
                    }
                    printRow[0, colIdx] = value;
                }
                excel.SetRowValues(1, rowIdx + 1, sql.DataSet.Tables[0].Columns.Count-1, printRow);
                excel.SetValue(1, 12, rowIdx + 1, String.IsNullOrEmpty(r[11].ToString())?0:int.Parse(r[11].ToString()));

                rowIdx++;
                string tc = r["TransportCompanyName"].ToString();
                DataRow[] findRows = kpiTable.Select($"TransportCompany = '{r["TransportCompanyName"].ToString()}'");

                DataRow kpiTableRow = null;// findRows.Count() == 0? kpiTable.NewRow(): findRows;

                if (findRows.Count() == 0)
                {
                    kpiTableRow = kpiTable.NewRow();
                    kpiTableRow["TransportCompany"] = r["TransportCompanyName"].ToString();
                    kpiTableRow["Kpi_tc"] = 0;
                    kpiTableRow["Kpi_Count"] = 1;
                    kpiTable.Rows.Add(kpiTableRow);

                }
                else
                {
                    kpiTableRow = findRows[0];
                }
                if (!String.IsNullOrEmpty(r["kpi"].ToString()))
                {
                    string colName = $"Col_{r["kpi"].ToString()}";
                    int kpiValue = kpiTableRow[colName] == null?0:(int)kpiTableRow[colName];
                    kpiTableRow[colName] = ++kpiValue;
                    kpiTableRow["Kpi_Count"] = (int)kpiTableRow["Kpi_Count"] + kpiValue;

                    decimal rowPrcSum = 0;
                    for (int i = 3; i < kpiTable.Columns.Count;i++)
                    {
                        string s = kpiTable.Columns[i].ColumnName.Substring(4, kpiTable.Columns[i].ColumnName.Length - 4);
                        decimal prct = decimal.Parse(kpiTable.Columns[i].ColumnName.Substring(4, kpiTable.Columns[i].ColumnName.Length - 4))/100;
                        rowPrcSum = rowPrcSum + (int)kpiTableRow[i] * prct;
                    }
                    
                    kpiTableRow["Kpi_tc"] = rowPrcSum / (int)kpiTableRow["Kpi_Count"];
                }


                wait.SetPosition(rowIdx);
            }


            range = excel.SelectCells(1, 1, 8, sql.DataSet.Tables[0].Columns.Count+1, rowIdx);
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
            range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
            excel.SetCellsFormat(1, 12, 8, 12, rowIdx, "0;%");
            int colKpiIdx = 3;
            foreach (var item in transportCompanyKpiDelays)
            {
                //excel.SetValue(2, colKpiIdx + 1, 1, $"{item.Kpi.ToString()}%");
                excel.SetValue(2, colKpiIdx + 1, 1, (decimal)item.Kpi/100);              
                excel.SetValue(2, colKpiIdx + 1, 2, Common.MinutesToTimeSpan((int)item.MinutesDelay));

                
                colKpiIdx++;
            }
            excel.SetValue(2, colKpiIdx + 1, 1, (decimal)10 / 100);
            
            excel.SetValue(2, colKpiIdx + 1, 2, Common.MinutesToTimeSpan(1440));
            colKpiIdx++;

            excel.SetCellsFormat(2, 4, 1, colKpiIdx , 1, "0%");
            excel.SetCellsBgColor(2,1,1, colKpiIdx, 2, 12611584);
            //excel.SetCellBgColor(2, colKpiIdx + 1, 2, 12611584);
            object[,] printRowKpi = new object[1, kpiTable.Columns.Count];
            rowIdx = 2;
            
            foreach (DataRow r in kpiTable.Rows)
            {
                for (int colIdx = 0; colIdx < kpiTable.Columns.Count; colIdx++)
                {
                    /*
                    if (colIdx ==0)
                    {
                        printRowKpi[0, colIdx] = r[colIdx].ToString();
                    }*/
                    
                    printRowKpi[0, colIdx] = r[colIdx];
                }
                excel.SetRowValues(2, rowIdx + 1, kpiTable.Columns.Count, printRowKpi);                

                rowIdx++;
            }
            
            excel.SetCellsFormat(2, 4, 2, 4 + transportCompanyKpiDelays.Count,2, "h:mm;@");
            excel.SetCellsFormat(2, 3, 3, transportCompanyKpiDelays.Count+2, rowIdx, "0");
            excel.SetCellsFormat(2, 2, 3, 2, rowIdx, "0.00%");

            excel.SetCellsBorder(2, 1, 1, transportCompanyKpiDelays.Count + 4, rowIdx, XlBorderWeight.xlThin);
            excel.SetCellsBorder(2, 1, 1, transportCompanyKpiDelays.Count + 4, 2, XlBorderWeight.xlMedium);
            

            excel.Visible = true;
            wait.Close();
            miRepTC.Enabled = true;

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

        private void ShowReportPeriodV2(ReportParams reportParams)
        {


            List<string> columnOrder = new List<string> {"ShpId","OrdId","ShpDate","SlotTime","InOut","OrdLVCode","OrdLVType",
                "KlientName","OrderStatus","PrcReady","ShpComment","OrdComment","GateName","ShpSpecialCond","ShpDriverPhone",
                "ShpDriverFio","TransportCompanyName","TransportTypeName","ShpVehicleNumber","ShpTrailerNumber","ShpAttorneyNumber",
                "ShpAttorneyDate","ShpSubmissionTime","ShpStartTime", "ShpEndTimePlan","ShpEndTimeFact","CALC:CONCAT(ShpDate,SlotTime)",
                "CALC:DIFFTIME(ShpSubmissionTime,ShpStartTime)","CALC:DIFFTIME({26},ShpStartTime)","CALC:DIFFTIME({26},ShpSubmissionTime)",
                "ShpDelayReasonName", "ShpDelayComment",  "ShpStampNumber","ShpSupplierName" };
            //"DepCode",

            DepositorRepository depositorRepository = new DepositorRepository();
            Depositor depositor = depositorRepository.GetById(1);
            if (depositor == null || String.IsNullOrEmpty(depositor.LvBase))
            {
                Common.ShowInformation("Не найдена база данных депозитора", "Предупреждение");
                return;
            }
            List<String> queryOut = new List<string>();

            DateTime periodBegin = DateTime.Parse(reportParams["PeriodBegin"]);
            DateTime periodEnd = String.IsNullOrEmpty(reportParams["PeriodEnd"])?periodBegin:DateTime.Parse(reportParams["PeriodEnd"]);
            


            #region Запросы

            queryOut.Add(String.Format(@"select vs.shp_id ShpId, so.id OrdId, so.lv_order_id, vs.s_date ShpDate, 
				vs.slot_time SlotTime,
				vs.s_in, N'выход' InOut, so.lv_order_code OrdLVCode, vs.sp_condition ShpSpecialCond,
				vs.gate_name GateName,cmp_ShortName KlientName,
				cast(ord_StatusID as nvarchar(11)) + N' - ' + isnull(msg_Greek, N'') OrderStatus,
				(
					case when ActPcs <> 0 then cast(cast(round(cast(ActPcs as numeric(10, 2)) / ExpPcs * 100, 2) as numeric(10, 2)) as varchar(7)) + N'%' end
				) PrcReady,
				(case when ActPcs <> 0 then cast(ActPcs as numeric(10, 2)) / ExpPcs end) DoneShare,
				vs.s_comment ShpComment, so.comment OrdComment,
				vs.driver_phone ShpDriverPhone,vs.driver_fio ShpDriverFio,vs.tc_name TransportCompanyName, 
                vs.transport_type_name TransportTypeName,
				vs.vehicle_number ShpVehicleNumber, vs.trailer_number ShpTrailerNumber,
				vs.attorney_number ShpAttorneyNumber, vs.attorney_date ShpAttorneyDate,
				vs.submission_time ShpSubmissionTime, 
				vs.start_time ShpStartTime, vs.end_time ShpEndTimePlan, vs.leave_time ShpEndTimeFact,
				vs.delay_reason_name ShpDelayReasonName, vs.delay_comment ShpDelayComment,
				vs.forwarder_fio,ort_Code + N' - ' + ort_Description OrdLVType,
				vs.stamp_number ShpStampNumber,			
				vs.supplier_name ShpSupplierName
				
		from 
			v_shipments vs with(nolock)
			left join shipment_orders so on (vs.shp_id = so.shipment_id) 
			left join shipment_order_parts sop on sop.sh_order_id = so.id
			left join {0}.dbo.LV_Order with(nolock) on ord_ID = so.lv_order_id
			outer apply
		(
		 select
			  sum(
					cast(
							case 
								when oia_PickListQty = 0 then isnull(osi_Quantity * ExpPcs.iuc_Conversion, osi_Quantity)
								else isnull(oia_PickListQty * ActPcs.iuc_Conversion, oia_PickListQty) 
							end
						/ Box.iuc_Conversion as int)
				) ExpBox,
			  sum(cast((
			   case when oia_PickListQty = 0 then isnull(osi_Quantity * ExpPcs.iuc_Conversion, osi_Quantity)
			   else isnull(oia_PickListQty * ActPcs.iuc_Conversion, oia_PickListQty) end
			  % Pal.iuc_Conversion) / Box.iuc_Conversion as int)) ExpBoxMix,
			  ceiling(sum(
			   case when oia_PickListQty = 0 then isnull(osi_Quantity * ExpPcs.iuc_Conversion, osi_Quantity)
			   else isnull(oia_PickListQty * ActPcs.iuc_Conversion, oia_PickListQty) end
			  / Pal.iuc_Conversion)) ExpPal,
			  sum(cast(floor(
			   case when oia_PickListQty = 0 then isnull(osi_Quantity * ExpPcs.iuc_Conversion, osi_Quantity)
			   else isnull(oia_PickListQty * ActPcs.iuc_Conversion, oia_PickListQty) end
			  / Pal.iuc_Conversion) as int)) ExpPalMon,
			  sum(cast(
			   case when oia_PickListQty = 0 then isnull(osi_Quantity * ExpPcs.iuc_Conversion, osi_Quantity)
			   else isnull(oia_PickListQty * ActPcs.iuc_Conversion, oia_PickListQty) end
			  as int)) ExpPcs,
			  sum(cast(isnull(oia_PickedQty * ActPcs.iuc_Conversion, oia_PickedQty) as int)) ActPcs,
			  count(distinct ori_ID) NumOfLines,
			  sum(cast(isnull(oia_PackedQty * ActPcs.iuc_Conversion, oia_PackedQty) as int)) PackedPcs
		 from 
				{0}.dbo.LV_OrderItem with(nolock)
				join {0}.dbo.LV_OrderShipItem with(nolock) on osi_OrderItemID = ori_ID and osi_StatusID <> 11 /*calcelled*/
				join {0}.dbo.LV_ItemUnit ExpIU with(nolock) on ExpIU.itu_ID = ori_ItemUnitID
				join {0}.dbo.LV_OrderShipItemAnalysis with(nolock) on oia_OrderShipItemID = osi_ID
				join {0}.dbo.LV_ItemUnitConversion ExpPcs with(nolock) on ExpPcs.iuc_ProductID = ori_ProductID and ExpPcs.iuc_ConvertedUnitID = ExpIU.itu_UnitID and ExpPcs.iuc_ReferenceUnitID = 5
				join {0}.dbo.LV_ItemUnitConversion Box with(nolock) on Box.iuc_ProductID = ori_ProductID and Box.iuc_ConvertedUnitID = 6 and Box.iuc_ReferenceUnitID = 5
				join {0}.dbo.LV_ItemUnitConversion Pal with(nolock) on Pal.iuc_ProductID = ori_ProductID and Pal.iuc_ConvertedUnitID = 24 and Pal.iuc_ReferenceUnitID = 5
				join {0}.dbo.LV_ItemUnit ActIU with(nolock) on ActIU.itu_ID = oia_ItemUnitID
				join {0}.dbo.LV_ItemUnitConversion ActPcs with(nolock) on ActPcs.iuc_ProductID = ori_ProductID and ActPcs.iuc_ConvertedUnitID = ActIU.itu_UnitID and ActPcs.iuc_ReferenceUnitID = 5
		 where ori_OrderID = lv_order_id
	        ) a1 
	        left join {0}.dbo.LV_Customer with(nolock) on cus_ID = ord_CustomerID
	        left join {0}.dbo.LV_Company with (nolock) on cmp_ID = cus_CompanyID
	        left join {0}.dbo.LV_OrderType with (nolock) on ort_ID = ord_TypeID
	        left join {0}.dbo.LV_ProgressStatus with(nolock) on pst_ID = ord_StatusID
	        left join {0}.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and  msg_languageID = 4
	        where 
		        vs.s_in = 0
		        and vs.s_date between '{1}' and '{2}'", depositor.LvBase, periodBegin, periodEnd));


            queryOut.Add(String.Format(@"	select 
				vs.shp_id ShpId, so.id OrdId, so.lv_order_id,  vs.s_date ShpDate, 
				vs.slot_time SlotTime,
				vs.s_in, N'вход' InOut, so.lv_order_code OrdLVCode, vs.sp_condition ShpSpecialCond, 
				vs.gate_name GateName,cmp_ShortName KlientName,
				cast(rct_ProgressID as nvarchar(11)) + N' - ' + isnull(msg_Greek, N'') OrderStatus,
				(       case         when a1.lsk_CUQuantity <> 0 then cast(cast(round(cast(a1.lsk_CUQuantity as numeric(10, 2)) / rci_ExpQuantity * 100, 2) as numeric(10, 2)) as varchar(7)) + N'%'        end       ) PrcReady,      
				(       case         when a1.lsk_CUQuantity <> 0 then cast(a1.lsk_CUQuantity as numeric(10, 2)) / rci_ExpQuantity        end      ) DoneShare,      
				vs.s_comment ShpComment, so.comment OrdComment,
				vs.driver_phone ShpDriverPhone,vs.driver_fio ShpDriverFio,vs.tc_name TransportCompanyName, 
                vs.transport_type_name TransportTypeName,
				vs.vehicle_number ShpVehicleNumber, vs.trailer_number ShpTrailerNumber,
				vs.attorney_number ShpAttorneyNumber, vs.attorney_date ShpAttorneyDate,
				vs.submission_time ShpSubmissionTime, 
				vs.start_time ShpStartTime, vs.end_time ShpEndTimePlan, vs.leave_time ShpEndTimeFact,
				vs.delay_reason_name ShpDelayReasonName, vs.delay_comment ShpDelayComment,
				vs.forwarder_fio,
				 rtt_Code + N' - ' + rtt_Description OrdLVType,
				 vs.stamp_number ShpStampNumber, 
                vs.supplier_name ShpSupplierName
	        from 
			v_shipments vs with(nolock)
			left join shipment_orders so on (vs.shp_id = so.shipment_id) 
			left join {0}.dbo.LV_Receipt with(nolock) on rct_ID = so.lv_order_id
			left join {0}.dbo.LV_Supplier with(nolock) on spl_ID = rct_SupplierID
			left join {0}.dbo.LV_Company with (nolock) on cmp_ID = spl_CompanyID
			left join {0}.dbo.LV_ReceiptType with (nolock) on rtt_ID = rct_TypeID
			left join {0}.dbo.LV_ProgressStatus with(nolock) on pst_ID = rct_ProgressID
			left join {0}.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
			left join (
					    select 
						    rct_id		
						    ,sum(rci_ExpQuantity) as rci_ExpQuantity
						    ,sum(rci_ActQuantity) as rci_ActQuantity
						    ,a.lsk_CUQuantity
					    from {0}.dbo.LV_Receipt with(nolock)
					    inner join {0}.dbo.LV_ReceiptItem with (nolock) on rci_ReceiptID = rct_ID 
					    inner join (  
									    SELECT log_ReceiptID, sum(lsk_CUQuantity) as lsk_CUQuantity
									    FROM 
											    {0}.[dbo].[LV_LogStock]
											    inner join {0}.dbo.LV_Log  on  log_ID = lsk_LogID  
									    group by log_ReceiptID
								    ) a on log_ReceiptID = rci_ReceiptID 
					    group by rct_id,lsk_CUQuantity 
		            ) a1 on a1.rct_id = LV_Receipt.rct_ID
	        where 
            vs.s_in = 1
            and vs.s_date between '{1}' and '{2}'", depositor.LvBase, periodBegin, periodEnd));


            queryOut.Add(String.Format(@"select m.id ShpId, mi.id OrdId, mi.TklLVID lv_order_id, m.m_date ShpDate,
				(case m.sp_condition when 0 then ts.slot_time else m.special_time end) SlotTime,
				cast(NULL as bit) s_in, N'перем' InOut, tkl_Code OrdLVCode, m.sp_condition ShpSpecialCond, 
				cast(NULL as nvarchar(8)) GateName,
				(case when m.def_customer = 0 then d.name else N'BAXI' end) KlientName,
				isnull(pst_Code, N'') + N' - ' + isnull(msg_Greek, N'') OrderStatus,
				(case when CntDone <> 0 then cast(cast(round(cast(CntDone as numeric(10, 2)) / CntOverall * 100, 2) as numeric(10, 2)) as varchar(6)) + N'%' end) PrcReady,
				(case when CntDone <> 0 then cast(CntDone as numeric(10, 2)) / CntOverall end) DoneShare,    
				m.comment ShpComment, cast(NULL as varchar(500)) OrdComment,
				cast(NULL as varchar(30)) ShpDriverPhone,m.performer ShpDriverFio,cast(NULL as varchar(80)) TransportCompanyName, 
				cast(NULL as varchar(80)) TransportTypeName, cast(NULL as varchar(20)) ShpVehicleNumber, 
				cast(NULL as varchar(20)) ShpTrailerNumber,cast(NULL as varchar(30)) ShpAttorneyNumber, cast(NULL as date) ShpAttorneyDate,
				cast(NULL as datetime) ShpSubmissionTime, cast(NULL as datetime) ShpStartTime, cast(NULL as datetime) ShpEndTimePlan, 
				cast(NULL as datetime) ShpEndTimeFact,cast(NULL as varchar(254)) ShpDelayReasonName, cast(NULL as varchar(200)) ShpDelayComment,
				cast(NULL as varchar(80)) forwarder_fio, cast(NULL as varchar(77)) OrdLVType, cast(NULL as varchar(25)) ShpStampNumber,
				null ShpSupplierName
            from movement m with(nolock)
            left join movement_item mi with(nolock) on mi.movement_id = m.id
            left join depositors d with(nolock) on d.id = mi.depositor_id
            left join time_slot ts with(nolock) on ts.id = m.time_slot_id
            left join delay_reasons dr with(nolock) on dr.id = m.delay_reasons_id
            left join {0}.dbo.LV_TaskList with(nolock) on tkl_ID = mi.TklLVID
            left join {0}.dbo.LV_ProgressStatus with(nolock) on pst_ID = tkl_StatusID
            left join {0}.dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
            outer apply
            (
	            select cast(min(tsk_ActualTime) as smalldatetime) ldg_Began, cast(max(tsk_ActualTime) as smalldatetime) ldg_Ended,
	            sum(case when tsk_StatusID in (3, 4) then 1 else 0 end) CntDone, count(*) CntOverall
	            from {0}.dbo.LV_Task with(nolock)
	            where tsk_TaskListID = mi.TklLVID
            ) a1

            where 
               m.m_date between '{1}' and '{2}'", depositor.LvBase, periodBegin, periodEnd));

            queryOut.Add(String.Concat(queryOut[0]," union all ", Environment.NewLine,
                queryOut[1], " union all ", Environment.NewLine,
                queryOut[2]));

            #endregion

            int[] colNumber = new int[columnOrder.Count];

            SettingReport settingReport = GetReportSetting("Отгрузки за период");
            if (settingReport == null)
            {               
                Common.ShowError("Не задан шаблон", "Ошибка при формировании отчета");
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
            int ShpType = int.Parse(reportParams["ShpType"]);



            //DataSet dataSet = GetShipment(DateTime.Parse(reportParams["PeriodBegin"]), DateTime.Parse(reportParams["PeriodEnd"]), null, null, ShpType);


            SqlHandle sql = new SqlHandle(Common.BuildConnectionString(ConnectionParams.ServerName, ConnectionParams.BaseName, ConnectionParams.UserName, ConnectionParams.Pwd));
            sql.SqlStatement = queryOut[ShpType];
            sql.Connect();
            sql.IsResultSet = true;

            bool success = sql.Execute();

            if (!success)
            {
                Common.ShowError(sql.LastError, "Ошибка");
                return;
            }

            //GetOrderDetailCount();

            DataSet dataSet = sql.DataSet;

            excel.SetValue(1, 6, 2, "Данные за период с " + periodBegin + " по " + periodEnd);


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

        private void lbMainFormCaption_Click(object sender, EventArgs e)
        {

        }

        private void tblShipments_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            if (IsFormLoad)
                return;
            ColumnHeader columnHeader = e.Header;
            ColumnHeader column = tblShipments.Columns[e.OldDisplayIndex];
            ColumnHeader column1 = tblShipments.Columns[e.NewDisplayIndex];
            var col = shipmentColumns.Find(c => c.Id == e.Header.Name);
            if (col == null)
            {
                col = new ShipmentColumn() { Id = column.Name, Visible = true };
                shipmentColumns.Add(col);
            }
            
            col.Order = e.NewDisplayIndex;
           
           Common.settingsHandle.SetParamList<ShipmentColumn>("View\\ShipmentColumns", "ShipmentColumns", shipmentColumns);
        }

        private void tblShipments_FormatCell(object sender, FormatCellEventArgs e)
        {
           // if (e.Column.IsVisible)
            {
                e.SubItem.Decoration = standardDecoration;
            }
            if (e.Column.Name == "colDate")
            {
                e.SubItem.Text =((DateTime)e.CellValue).ToShortDateString();
            }
            else if (e.Column.Name == "colOrderWeight")
            {
                decimal? weight = (decimal?)e.CellValue;
                e.SubItem.Text = weight == null? "":Math.Round(weight.Value, 2).ToString();
            }

        }

        private void tblShipments_AfterSorting(object sender, AfterSortingEventArgs e)
        {

        }

        private void tblShipments_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!IsBuilded)
                CalcRowColor();
        }

        private void mciOrderDetail_Click(object sender, EventArgs e)
        {
            ShipmentMain shipmentMain = GetCurrentRowObject();
            ShowOrderDetail(shipmentMain);
        }

        private void tblShipments_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (IsFormLoad || Common.settingsHandle ==null || shipmentColumns == null)
                return;
            ColumnHeader column = tblShipments.Columns[e.ColumnIndex];
            var col = shipmentColumns.Find(c => c.Id == column.Name);
            if (col == null)
            {
                col = new ShipmentColumn() { Id = column.Name, Visible = true };
                shipmentColumns.Add(col);
            }

            col.Width = column.Width;
            Common.settingsHandle.SetParamList<ShipmentColumn>("View\\ShipmentColumns", "ShipmentColumns", shipmentColumns);
        }

        private void menuItemReportPeriodV2_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepPeriod repPeriod = new RepPeriod(reportParams);



            if (repPeriod.ShowDialog() == DialogResult.OK)
            {

                ShowReport(REPORT_PERIOD_V2, reportParams);
            }
        }

        private void contextMenuMain_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuItemRatingCarriers_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepPeriod frmRepParam = new RepPeriod(reportParams);
            frmRepParam.cbType.Items.RemoveAt(2);

            if (frmRepParam.ShowDialog() == DialogResult.OK)
            {
                ShowReport(REPORT_RATING_CARRIER, reportParams);
            }
        }

        private void menuItemDictTimeDelayKPI_Click(object sender, EventArgs e)
        {
            TransportCompanyKpiDelayForm frmTransportCompanyKpiDelay = new TransportCompanyKpiDelayForm();
            SetFormPrivalage(frmTransportCompanyKpiDelay, "TC");
            AddFormTab(frmTransportCompanyKpiDelay, "Критерии KPI ТК");

        }
    }
}
