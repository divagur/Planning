using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MDIWindowManager;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;
using System.Text.RegularExpressions;
//using System.Windows;

namespace Planning
{
    
    public partial class frmMain : Form
    {
        const int REPORT_PERIOD = 101;
        const int REPORT_STATISTIC = 102;
        const int REPORT_TC = 103;

        private string CR = Environment.NewLine;

        //DataService dataService = new DataService();
        // = new PlanningDbContext();

        private int Xwid = 6;//координаты ширины по диагонали крестика
        private const int tab_margin = 5;//координаты по высоте крестика
        public WaitHandler waitCur;
        DataTable shipmentsDataTable = new DataTable();
        List<UserAccessItem> UserPrvlg = new List<UserAccessItem>();
        public List<ShipmentColumn> shipmentColumns = new List<ShipmentColumn>();
        UserAccessItem mainFormAccess =new UserAccessItem();
        SqlConnection LVConnect;
        private int currShpId = 0;
        private int currColorIdx = 0;
        bool IsFormLoad = false;
        bool isPaint = true;
        frmProgressBar wait;
        private List<Color> rowColors = new List<Color>()
        {
          Color.FromArgb(220, 220, 220),
          Color.FromArgb(220, 230, 241)
        };

        List<OrderDetailItem> orderDetailCount = new List<OrderDetailItem>();
        public frmMain()
        {
            InitializeComponent();
            SqlHandle.OnExecuteBeforeCommon += OnSqlExecureBeforeCommon;
            SqlHandle.OnExecuteAfterCommon += OnSqlExecureAfterCommon;
            waitCur = new WaitHandler(this);
        }

        public void OnSqlExecureBeforeCommon(string Param)
        {
            //this.Cursor = Cursors.AppStarting;
        }

        public void OnSqlExecureAfterCommon(string Param)
        {
           // this.Cursor = Cursors.Default;
        }

        private void tblShipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0) return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "colOrderDetail")
            {
                ShowOrderDetail();
            }
            else
            {
                object cellValue = tblShipments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                
                if (cellValue !=null)
                    Clipboard.SetText(cellValue.ToString());
            }
            
        }

        private void ShowOrderDetail()
        {
            string direction = (string)tblShipments.CurrentRow.Cells["colDirection"].Value;
            
            int? DepositorLVId = DataService.GetDictIdByName("Депозиторы", (string)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colDepositor"].Value);
            if (direction == "перем")
                return;
          
            int inOut = direction == "вход" ? 1 : 0;
            var idNakl = tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value;
            var orderId = tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colOrdLvId"].Value;
            
            if (string.IsNullOrEmpty(orderId.ToString()))
                return;

            frmOrderDetail frmOrderDetail = new frmOrderDetail(
                    (string)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colOrderId"].Value,
                    (int)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colOrdLvId"].Value, inOut, (int)DepositorLVId);
            frmOrderDetail.ShowDialog();
        }

        private void GetOrderDetailCount()
        {
            OrderDetailItem_Manager orderDetailItem_Manager = new OrderDetailItem_Manager();

            orderDetailCount = orderDetailItem_Manager.GetOrderDetailItems(1, 0, 0, true);
        }

        private DataSet GetShipment(DateTime DateFrom, DateTime? DateTill, string ShpId, string OrdId, int ShpType = -1)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_MainQueryP";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            object shpType = null;
            if (ShpType >= 0)
                shpType = ShpType;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateFrom });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTill });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = shpType });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ShpId", Value = ShpId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@OrdID", Value = OrdId });
           
            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //GetOrderDetailCount();

            return sql.DataSet;
                

        }
        private void GetOrderWight()
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_GetOrderWight";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;

           
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ShpId", Value = null });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@OrdID", Value = null });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepId", Value = null });

            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
           


        }
        private List<String> GetFilterActionList()
        {
            List<String> result = new List<string>();
            foreach (ToolStripMenuItem item in btnActionFilter.DropDownItems) 
            {
                if (item.Checked)
                    result.Add(item.Text);
            }
            return result;
        }

        private void ShipmentsUIFilter()
        {
            List<string> actionFilter = GetFilterActionList();
            var rows = shipmentsDataTable.AsEnumerable().Where(r => actionFilter.Contains(r.Field<String>("InOut")));
            if (rows.Count() >0)
            {
                DataTable dt = rows.CopyToDataTable();
                tblShipments.DataSource = dt;
                CalcRowColor();
            }
            else
            {
                tblShipments.DataSource = null;
            }

        }

        private void ShipmentsLoad()
        {
            if (mainFormAccess!=null && !mainFormAccess.IsView)
            {
                MessageBox.Show("Нет доступа на просмотр списка отгрузок", "Ошибка доступа", MessageBoxButtons.OK);
                return;
            }
            string rowShpId = "";
            string rowShpOrdId = "";
            bool restoreRow = false;
            //this.Cursor = Cursors.AppStarting;
            if (tblShipments.CurrentCell != null)
            {
                rowShpId = tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
                rowShpOrdId = tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value.ToString();
                restoreRow = true;
            }
            
            tbMain.Enabled = false;
            miDicts.Enabled = false;
            var dataSet = GetShipment(edCurrDay.Value, null, null,null);
            if (dataSet == null)
            {
                return;
            }
            tbMain.Enabled = true;
            miDicts.Enabled = true;
            
            shipmentsDataTable.Clear();
            shipmentsDataTable = dataSet.Tables[0].Clone();
            shipmentsDataTable.Load(dataSet.Tables[0].CreateDataReader());
            //shipmentsDataTable.Load(reader);
            
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
        }

        private bool SearchBy(bool FromBegin, Predicate<int> condition)
        {
            int startRow = FromBegin ? 0 : tblShipments.CurrentRow.Index + 1;
          
            for (int i = startRow; i <= tblShipments.Rows.Count - 1; i++)
                if (condition(i))
                {

                    tblShipments.CurrentRow.Selected = false;
                    DataGridViewCell cell = tblShipments.Rows[i].Cells["colOrderId"];
                    tblShipments.CurrentCell = cell;
                    tblShipments.Rows[i].Selected = true;

                    return true;
                }
            return false;

        }
        private bool SearchByOrder(bool FromBegin)
        {
           
            return SearchBy(FromBegin, i => tblShipments.Rows[i].Cells["colOrderId"].Value != null && tblShipments.Rows[i].Cells["colOrderId"].Value.ToString() == edSearch.Text);
            /*int startRow = FromBegin ? 0 : tblShipments.CurrentRow.Index+1;
            for (int i = startRow; i <= tblShipments.Rows.Count - 1; i++)
                if (tblShipments.Rows[i].Cells["colOrderId"].Value != null && tblShipments.Rows[i].Cells["colOrderId"].Value.ToString() == edSearch.Text)
                {

                    tblShipments.CurrentRow.Selected = false;
                    DataGridViewCell cell = tblShipments.Rows[i].Cells["colOrderId"];                  
                    tblShipments.CurrentCell = cell;
                    tblShipments.Rows[i].Selected = true;
                   
                    return;
                }
                   */ 
        }

        private void InitContext()
        {
            
            DataService.connectionString = DataService.BuildConnectionString(DataService.setting.ServerName,
                DataService.setting.BaseName, 
                DataService.setting.UserName, 
                DataService.setting.Password, DataService.setting.IsWnd);
            DataService.entityConnectionString = DataService.GetEntityConnectionString(DataService.connectionString);
            
            DataService.InitContext();
            
        }

        private ToolStripItem FindMenuItem(ToolStripItemCollection items, string Tag)
        {
            foreach(ToolStripMenuItem mi in items)
            {
                if ((string)mi.Tag == Tag)
                {
                    return mi;
                }
                else if (mi.DropDownItems.Count > 0)
                {
                    ToolStripItem miResult = FindMenuItem(mi.DropDownItems, Tag);
                    if (miResult !=null)
                        return miResult;
                }

            }

            return null;
        }

        private void UpdateFunctionPrvlg()
        {

            mainFormAccess = UserPrvlg.Find(i => i.FunctionId == "MainForm");
            if (mainFormAccess != null)
            {
                btnAdd.Enabled = mainFormAccess.IsAppend;
                //btnEdit.Enabled = mainFormAccess.IsEdit;
                btnDel.Enabled = mainFormAccess.IsDelete;
                btnRefresh.Enabled = mainFormAccess.IsView;
                
            }
            else
            {
                mainFormAccess = new UserAccessItem();
                mainFormAccess.IsAppend = false;
                mainFormAccess.IsEdit = false;
                mainFormAccess.IsDelete = false;
                mainFormAccess.IsView = true;
            }
            btnEdit.Image = mainFormAccess.IsEdit ? Properties.Resources.Edit : Properties.Resources.EditView;


            foreach (UserAccessItem item in UserPrvlg)
            {
                ToolStripItem mi = FindMenuItem(menuMain.Items, item.FunctionId);
                if (item.FunctionId == "Attr" || item.FunctionId == "OperType")
                {
                    mi.Visible = false;
                    continue;
                }
                    
                if ( mi != null)
                    mi.Visible = item.IsView;
            }
        }

        private void SetFormPrivalage(DictForm form, string FunctionId)
        {
            UserAccessItem accessItem = UserPrvlg.Find(i => i.FunctionId == FunctionId);
            if (accessItem !=null)
            {
                form.SetPrivilege(accessItem.IsAppend, accessItem.IsEdit, accessItem.IsDelete);
            }
        }


        private void SaveSettings()
        {
            /*
            settingsHandle.SetParamValue("Connection\\ServerName", DataService.setting.ServerName);
            settingsHandle.SetParamValue("Connection\\UserName", DataService.setting.UserName);
            settingsHandle.SetParamValue("Connection\\BaseName", DataService.setting.BaseName);
            //settingsHandle.SetParamValue("Connection\\Password", setting.Password);
            settingsHandle.SetParamValue("ReportTemplate\\ShipmentTemplate", DataService.setting.ShipmentReport);
            settingsHandle.SetParamValue("ReportTemplate\\ReceiptTemplate", DataService.setting.ReceiptReport);
            settingsHandle.SetParamValue("ReportTemplate\\PeriodTemplate", DataService.setting.PeriodReport);
            settingsHandle.SetParamValue("TaskUpdateInterval", DataService.setting.TaskUpdateInterval.ToString());
            settingsHandle.SetParamValue("TaskViewFonSize", DataService.setting.TaskViewFonSize.ToString());
            settingsHandle.SetParamList<CurrTaskColumn>("CurrentTaskColumns", "Column", DataService.setting.CurrentTaskColumns);
            settingsHandle.SetParamList<VolumeCalcConstant>("VolumeCalcTemplates", "Template", DataService.setting.VolumeCalcTemplate);
            */
            DataService.settingsHandle.Save();
        }

        private void LoginUser()
        {
            InitContext();
            UserPrvlg = DataService.GetPrvlg(DataService.setting.UserName);
            UpdateFunctionPrvlg();

            ShipmentsLoad();
            //UpdateFunctionPrvlg();
        }

       private void CloseAllTabs()
        {
           foreach(TabPage pg in tabForms.TabPages)
            {
                if (pg.Name != "tabMain")
                    tabForms.TabPages.Remove(pg);
            }
        }

        private bool TryDBConnect(bool ShowError)
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    if (ShowError)
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    return false;
                }

            }
            return true;
        }

        private bool GetLogin()
        {
            /*
            FormLogin frmLogin = new FormLogin(DataService.setting);
            if (frmLogin.ShowDialog() == DialogResult.Cancel)
            {
               
                return false;
            }
            CloseAllTabs();
            DataService.settingsHandle.SetParamValue("Connection\\UserName", DataService.setting.UserName);
            //DataService.settingsHandle.SetParamValue("Connection\\LastLogin", DataService.setting.LastLogin);
            //statusInfo.Text = $"База данных:{DataService.setting.BaseName} Пользователь: {DataService.setting.UserName}";
            */
            return true;
        }

        private string GetHideColumns()
        {

            List<string> result = new List<string>();
            foreach (DataGridViewColumn col in tblShipments.Columns)
            {
                if (!col.Visible)
                {
                    result.Add(col.Name);
                }
            }
            return String.Join(",", result);
        }

        private void CheckCorrectSettings()
        {
            bool isOk = true;
            foreach (var report in DataService.setting.Reports)
            {
                if (report.TemplatePath == "")
                {
                    isOk = false;
                    break;
                }
            }
            if (!isOk)
            {
                MessageBox.Show("Для некоторых отчетов не указаны шаблоны" + Environment.NewLine +
                    "Без указания шаблонов работа отчетов будет не возможна", "Предупреждение", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
       

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbPaint.Checked = isPaint;
            IsFormLoad = true;
            DataService.settingsHandle = new SettingsHandle("Settings.xml", DataService.setting);
            DataService.settingsHandle.Load();


            //Если нет сервера или базы, то выдадим окно настройки
            if (DataService.setting.BaseName == "" || DataService.setting.ServerName == "")
            {
                DataService.setting = new Settings();

                SettingsWizard frmSettingsWizard = new SettingsWizard(DataService.setting);



                if (frmSettingsWizard.ShowDialog() == DialogResult.OK)
                {
                    SaveSettings();
                }
                else
                    this.Close();
            }
            DataService.setting.IsWnd = true;
            DataService.setting.UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //Попробуем подключиться под текущим пользователем виндовс
            //Если не получится запросим имя пользователя и пароль
            //
            //DataService.setting.IsWnd = false;
            if (!DataService.TryDBConnect(DataService.setting.ServerName, DataService.setting.BaseName, "", "", DataService.setting.IsWnd, false))
            {
                DataService.setting.IsWnd = false;
                if (!GetLogin())
                {
                    this.Close();
                    return;
                }
            }

            InitContext();
            CheckCorrectSettings();

            List<string> action = DataService.settingsHandle.GetParamStringValue("View\\ActionFilter").Split(',').ToList();
            foreach (ToolStripMenuItem item in btnActionFilter.DropDownItems)
            {
                if (!action.Contains(item.Text))
                    item.Checked = false;
            }

            LoginUser();





            //DataService dataService = new DataService();
            DataService.Dicts.Add("Причины_задержки", new DictInfo { TableName = "delay_reasons", NameColumn = "name" });
            DataService.Dicts.Add("Типы_операций", new DictInfo { TableName = "opers_type", NameColumn = "name" });
            DataService.Dicts.Add("Ворота", new DictInfo { TableName = "gateways", NameColumn = "name" });
            DataService.Dicts.Add("Депозиторы", new DictInfo { TableName = "depositors", NameColumn = "name" });
            DataService.Dicts.Add("ТаймСлоты", new DictInfo { TableName = "time_slot", NameColumn = "name" });
            DataService.Dicts.Add("ТК", new DictInfo { TableName = "transport_company", NameColumn = "name" });
            DataService.Dicts.Add("Типы_транспорта", new DictInfo { TableName = "transport_type", NameColumn = "name" });
            DataService.Dicts.Add("Поставщики", new DictInfo { TableName = "suppliers", NameColumn = "name" });
            DataService.Dicts.Add("Склады", new DictInfo {TableName = "warehouses", NameColumn = "name" });
            DataService.Dicts.Add("Таможенные_посты", new DictInfo { TableName = "custom_posts", NameColumn = "name" });
            DataService.Dicts.Add("Виды_транспорта", new DictInfo { TableName = "transport_view", NameColumn = "name" });
            //dataService.Dicts.Add("Ворота", "gateways");



            List<string> hideCols = DataService.settingsHandle.GetParamStringValue("View\\HideColumns").Split(',').ToList();

            shipmentColumns = DataService.settingsHandle.GetParamList<ShipmentColumn>("View\\ShipmentColumns");
            if (shipmentColumns.Count == 0)
            {
                foreach (DataGridViewColumn col in tblShipments.Columns)
                {
                    shipmentColumns.Add(new ShipmentColumn() { Id = col.Name, Order = col.DisplayIndex });
                }
            }

            SetShipmentColParam();

            btnColumnVisible.DropDownItems.Clear();
            foreach (DataGridViewColumn col in tblShipments.Columns)
            {
                if (col.Visible)
                {
                    string headerText = String.IsNullOrEmpty(col.HeaderText) ? col.ToolTipText : col.HeaderText;
                    ToolStripMenuItem item = (ToolStripMenuItem)btnColumnVisible.DropDownItems.Add(headerText);
                    item.CheckOnClick = true;
                    item.CheckState = hideCols.IndexOf(col.Name) < 0 ? CheckState.Checked : CheckState.Unchecked;
                    item.Tag = col;
                    item.Click += toolStripMenuItem3_Click;
                    col.Visible = hideCols.IndexOf(col.Name) < 0;
                }


            }





            statusInfo.Text = $"База данных:[{DataService.setting.BaseName}] Пользователь: [{DataService.setting.UserName}]";
            IsFormLoad = false;
        }

        private void SetShipmentColParam()
        {

            foreach (DataGridViewColumn col in tblShipments.Columns)
            {
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
                    col.DisplayIndex = shpCol.Order;
                }
            }
            
        }

        private void miDictDelayReasons_Click(object sender, EventArgs e)
        {

            var frmDelayReasons = new DictDelayReasons();
            //SetFormPrivalage(frmDelayReasons, "DelayReasons");
            AddFormTab(frmDelayReasons, "Причины задержки");
        }

        private void miDictOpersType_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();
            dict.TableName = "opers_type";
            dict.Title = "Справочник: Типы операций";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 20 });
            /*
            SimpleDict frmOperType = new SimpleDict(dict);
            SetFormPrivalage(frmOperType, "OperType");
            AddFormTab(frmOperType, "Типы операций");
            */
        }
        
        private void AddFormTab(Form frm,String Name)
        {
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tabForms.TabPages.Add(Name);
            tabForms.TabPages[tabForms.TabPages.Count - 1].Controls.Add(frm);
            tabForms.SelectedTab = tabForms.TabPages[tabForms.TabPages.Count - 1];
        }
        private void miDictGates_Click(object sender, EventArgs e)
        {

            DictSimple dict = new DictSimple();
            dict.TableName = "gateways";
            dict.Title = "Справочник: Ворота";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "GatewayNum", IsPK = false, IsVisible = true, Title = "Номер ворот", DataField = "name", Width = 254, DataType = SqlDbType.Int });
            /*
            SimpleDict frmGate = new SimpleDict(dict);
            SetFormPrivalage(frmGate, "Gate");
            AddFormTab(frmGate, "Ворота");
            */
        }
        
        void AddShToLV(Shipment shipment)
        {
            if (shipment.ShIn == false)
            {
                DataService.AddShipmentToLV(shipment.Id);
            }

            //DataService.AddShipmentToLV(shipment.Id);
        }

        private void ShipmentRowEdit()
        {
            if (tblShipments.SelectedRows.Count <= 0)
                return;

            DataService.InitContext();
            ShipmentParam shipmentAddResult = new ShipmentParam();
            if (tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colDirection"].Value.ToString()!="перем")
            {
                

                shipmentAddResult.IsShipment = true;
                shipmentAddResult.Result = DataService.context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
                
            }
            else
            {
                shipmentAddResult.IsShipment = false;
                shipmentAddResult.Result = DataService.context.Movements.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            }
            
            ShipmentEdit(shipmentAddResult);
            ShipmentsLoad();
        }
        private void ShipmentEdit(ShipmentParam shipmentAddResult)
        {
             /*
            shipmen_edit frmShipmentEdit = new shipmen_edit();
           
            frmShipmentEdit = shipmentAddResult.IsShipment == true ? new shipmen_edit((Shipment)shipmentAddResult.Result) : new shipmen_edit((Movement)shipmentAddResult.Result);

            if (shipmentAddResult.IsShipment)
                frmShipmentEdit = new shipmen_edit((Shipment)shipmentAddResult.Result);
            else
                frmShipmentEdit = new shipmen_edit((Movement)shipmentAddResult.Result);

            

            frmShipmentEdit.ClearFields();
            frmShipmentEdit.Populate();
            frmShipmentEdit.LockField(new List<string>() {"btnOK","btnCancel" }, mainFormAccess.IsEdit);

            
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
                    if (shipment.IsAddLv == true)
                    {
                        AddShToLV(shipment);
                    }
                }

                tblShipments.Refresh();
            }
                */
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            ShipmentParam shipmentAddResult = new ShipmentParam();
           // Shipment shipment = new Shipment();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            /*
            if (tblShipments.SelectedRows.Count <= 0)
                return;

            Shipment shipment = context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            ShipmentEdit(shipment);
            ShipmentsLoad();
            */
            ShipmentRowEdit();
        }

        private void miDictUser_Click(object sender, EventArgs e)
        {
            /*
            var frmUsers = new Users();
            SetFormPrivalage(frmUsers, "Users");
            AddFormTab(frmUsers, "Пользователи");
            */
        }

        private void miDictTimeSlot_Click(object sender, EventArgs e)
        {
            /*
            var frmTimeSlot = new TimeSlots();
            SetFormPrivalage(frmTimeSlot, "TimeSlot");
            AddFormTab(frmTimeSlot, "Тайм слоты");
            */
        }

        private void miDictDepositor_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();

            dict.TableName = "depositors";
            dict.Title = "Справочник: Депозиторы";
            
            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.VarChar, Length = 20 });
            dict.Columns.Add(new DictColumn { Id = "DB", IsPK = false, IsVisible = true, Title = "База данных", DataField = "lv_base", Width = 128, DataType = SqlDbType.VarChar, Length = 128});
            dict.Columns.Add(new DictColumn { Id = "LVId", IsPK = false, IsVisible = true ,Title = "Код в LVision", DataField = "lv_id", Width = 80, DataType = SqlDbType.Int});
            
            Depositors frmDepositors = new Depositors();
            
            frmDepositors.WaitHandler = waitCur;
           // SetFormPrivalage(frmDepositors, "Depositor");       
            AddFormTab(frmDepositors, "Депозиторы");
        }

        private void CalcRowColor()
        {
            int cellShpId;
            int cellLastShpId = 0;
            int currColorIdx = 0;
            for (int i = 0; i < tblShipments.Rows.Count; i++)
            {
                cellShpId = (int)(tblShipments).Rows[i].Cells["colId"].Value;
                if (cellLastShpId != cellShpId)
                {
                    cellLastShpId = cellShpId;
                    currColorIdx = currColorIdx == 0 ? 1 : 0;
                }
                (tblShipments).Rows[i].Cells["BackgroundColor"].Value = currColorIdx;
            }
        }

        private void tblShipments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (isPaint && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["colCopmletePct"].Index)
                {


                    using (
                        Brush gridBrush = new SolidBrush(this.tblShipments.GridColor),
                        backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            // Erase the cell.
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            // Draw the grid lines (only the right and bottom lines;
                            // DataGridView takes care of the others).
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom - 1);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                                e.CellBounds.Top, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom);

                            // Draw the inset highlight box.
                            //e.Graphics.DrawRectangle(Pens.Blue, newRect);

                            // Draw the text content of the cell, ignoring alignment.
                            if (e.Value != DBNull.Value)
                            {
                                decimal doneShare = (decimal)((DataGridView)sender).Rows[e.RowIndex].Cells["colDoneShare"].Value * 100;

                                int progressWidth = (Convert.ToInt32(doneShare) * e.CellBounds.Width) / 100;

                                Rectangle newRect = new Rectangle(e.CellBounds.X + 0,
                                    e.CellBounds.Y + 0, progressWidth,
                                    e.CellBounds.Height - 1);

                                StringFormat stringFormat = new StringFormat();
                                stringFormat.Alignment = StringAlignment.Center;
                                stringFormat.LineAlignment = StringAlignment.Center;

                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), newRect);
                                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                    Brushes.Black, e.CellBounds, stringFormat);// e.CellBounds.X + 2,e.CellBounds.Y + 2 StringFormat.GenericDefault
                            }
                            e.Handled = true;
                        }
                    }
                }
               
                else 
                {
                    //e.CellStyle.ForeColor = Color.Black;
                       DataGridView dataGrid = (DataGridView)sender;
                    bool isDone = false;
                    bool isAddLv = false;
                    if (dataGrid.Rows[e.RowIndex].Cells["colStatus"].Value != DBNull.Value)
                    {
                        
                           isDone = ((string)dataGrid.Rows[e.RowIndex].Cells["colStatus"].Value).Contains("Выполнен");
                    }
                   if (dataGrid.Rows[e.RowIndex].Cells["IsAddLv"].Value != DBNull.Value )
                    {
                        isAddLv = (bool)dataGrid.Rows[e.RowIndex].Cells["IsAddLv"].Value;
                    }
                    if (isDone)
                    {
                        e.CellStyle.ForeColor = Color.DarkGray;
                    }
                    else if ((bool)dataGrid.Rows[e.RowIndex].Cells["IsAddLv"].Value != true)
                    {
                        e.CellStyle.ForeColor = Color.Blue;
                    }
                        
                }


            }
        }

        private void edCurrDay_ValueChanged(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }

        private void tblShipments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {/*
            if (e.ColumnIndex == ((DataGridView)sender).Columns["colOrderDetail"].Index)
            {
                string direction = Convert.ToString(tblShipments.Rows[e.RowIndex].Cells["colDirection"].Value);
                int inOut = Convert.ToString(tblShipments.Rows[e.RowIndex].Cells["colDirection"].Value) == "вход" ? 1 : 0;
                if (!HasOrderDetail((int)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value, inOut))
                {

                    e.Graphics.DrawImage(new Bitmap(10, 10), e.);
                    //(tblShipments.Rows[e.RowIndex].Cells["colDirection"] as DataGridViewImageCell).Image
                }
                else
                {
                    //Bitmap img = new Bitmap(Properties.Resources.view_detailed_2595);
                    e.Graphics.DrawImage(Properties.Resources.view_detailed_2595, e.CellBounds);
                    //e.Value = Properties.Resources.view_detailed_2595;

                }
            }*/
        }

        private void tblShipments_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!isPaint)
                return;
            
            var CellColor = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["BackgroundColor"].Value;
            var CellShpId = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["colId"].Value;


            if (currShpId != CellShpId)
            {
                currShpId = CellShpId;
                currColorIdx = currColorIdx == 0 ? 1 : 0;
            }
            //((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColors[currColorIdx];
           // if (CellColor >=0 )
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColors[CellColor];// Color.FromArgb(CellColor);

            CellColor = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["FontColor"].Value;
            if (CellColor != 0)
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(CellColor);// (Color)((DataGridView)sender).Rows[e.RowIndex].Cells["BackgroundColor"].Value;          

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Удалить запись?", "Подверждение", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colDirection"].Value.ToString() != "перем")
            {
                Shipment shipment = DataService.context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
                DataService.context.Shipments.Remove(shipment);
            }
            else
            {
                Movement movement = DataService.context.Movements.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
                DataService.context.Movements.Remove(movement);
                
            }
            DataService.context.SaveChanges();
            this.ShipmentsLoad();

        }

        private void tabForms_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush text_brush, //Текст во вкладке
                box_brush;   //Рамка вокруг крестика
            Pen box_pen;



            // Рисуем в tabControlTablica (tabPage) рамку
            // Потом будем использовать в событии MouseDown.
            Rectangle tab_rect = tabForms.GetTabRect(e.Index);

            // Рисуем фон
            // Подбираем соответствующие кисти и перья
            //Вкладка открыта фон изменён
            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, tab_rect);
                e.DrawFocusRectangle();
                text_brush = Brushes.Black;
                box_brush = Brushes.Black;
                box_pen = Pens.Red;  //Цвет крестика при включенной кнопке tabPage

            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightGray, tab_rect);
                text_brush = Brushes.Gray;
                box_brush = Brushes.Black;
                box_pen = Pens.Gray;  //Цвет крестика при выключенной кнопке tabPage
            }
            
            // Allow room for margins.
            Rectangle layout_rect = new Rectangle(
                tab_rect.Left + tab_margin,
                tab_rect.Y + 2 + tab_margin,  //Координаты смещения крестика
                tab_rect.Width - 1 * 5 - tab_margin, //Координаты смещения крестика
                tab_rect.Height - 2 * tab_margin);
            Rectangle layuot_text = new Rectangle(
                tab_rect.Left + tab_margin,
                tab_rect.Y + 2,
                tab_rect.Width - 1 * 5 - tab_margin, 
                tab_rect.Height
                );
            using (StringFormat string_format = new StringFormat())
            {
                /*
                // Цифры рисуем во вкладке в нижнем правом углу 
                using (Font small_font = new Font(this.Font.FontFamily, 6, FontStyle.Regular))
                {
                    string_format.Alignment = StringAlignment.Far;
                    string_format.LineAlignment = StringAlignment.Far;
                    e.Graphics.DrawString(
                        e.Index.ToString(),
                        small_font,
                        text_brush,
                        layout_rect,
                        string_format);
                }
                */
                // Рисуем текст во вкладка tabControlTablica
                Font font;
                Brush br = Brushes.Black;
                StringFormat strF = new StringFormat(StringFormat.GenericDefault);
                if (tabForms.SelectedTab == tabForms.TabPages[e.Index])
                {
                    //Формат текста во вкладках tabControl
                    //e.Graphics.DrawImage(closeImageAct, imageRec);
                    string_format.Alignment = StringAlignment.Near;
                    string_format.LineAlignment = StringAlignment.Near;
                    font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    e.Graphics.DrawString(tabForms.TabPages[e.Index].Text,
                        font, text_brush,
                        layuot_text,
                        string_format);
                }
                else
                {
                    //Формат текста во вкладках tabControl
                    string_format.Alignment = StringAlignment.Near;
                    string_format.LineAlignment = StringAlignment.Near;
                    font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    e.Graphics.DrawString(tabForms.TabPages[e.Index].Text,
                       font,
                        text_brush,
                        layuot_text,
                        string_format);
                }

                // //Рисуем рамку вокруг крестика
                //Rectangle rect = tabControlTablica.GetTabRect(e.Index);
                //e.Graphics.FillRectangle(box_brush,
                //    layout_rect.Right - Xwid,
                //    layout_rect.Top,
                //    Xwid,
                //    Xwid);

                //e.Graphics.DrawRectangle(box_pen,
                //    layout_rect.Right - Xwid,
                //    layout_rect.Top,
                //    Xwid,
                //    Xwid);

                if (e.Index > 0)
                {
                    //Рисуем крестик
                    e.Graphics.DrawLine(box_pen,
                        layout_rect.Right - Xwid,
                        layout_rect.Top,
                        layout_rect.Right,
                        layout_rect.Top + Xwid);
                    e.Graphics.DrawLine(box_pen,
                        layout_rect.Right - Xwid,
                        layout_rect.Top + Xwid,
                        layout_rect.Right,
                        layout_rect.Top);
                }
            }
        }

        private void tabForms_MouseDown(object sender, MouseEventArgs e)
        {
            // При нажатии закрыть вкладку
            for (int i = 0; i < tabForms.TabPages.Count; i++)
            {
                Rectangle tab_rect = tabForms.GetTabRect(i);
                RectangleF rect = new RectangleF(
                    tab_rect.Left - 2 + tab_margin,
                    tab_rect.Y + 2 + tab_margin,
                    tab_rect.Width - 2 * tab_margin,
                    tab_rect.Height - 2 * tab_margin);
                if (e.X >= rect.Right - Xwid &&
                    e.X <= rect.Right &&
                    e.Y >= rect.Top - 1 &&
                    e.Y <= rect.Top + Xwid && i>0)
                {
                    tabForms.TabPages.Remove(tabForms.TabPages[i]);
                    tabForms.SelectedIndex = tabForms.TabPages.Count - 1;
                }
            }
        }

        private void miDictUserGroup_Click(object sender, EventArgs e)
        {
            var frmUserGroups = new UserGroups();
            
           // SetFormPrivalage(frmUserGroups, "UserGrp");
            AddFormTab(frmUserGroups, "Группы пользователей");
        }

        private void tblShipments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblShipments.Columns[e.ColumnIndex].Name == "colOrderDetail")
                return;
            ShipmentRowEdit();
        }

        private void miSettings_Click(object sender, EventArgs e)
        {
            
            SettingsWizard frmSettingsWizard = new SettingsWizard(DataService.setting);
            if (frmSettingsWizard.ShowDialog()==DialogResult.OK)
            {
                SaveSettings();
                InitContext();
                return;
            }

            /*
            SettingsEdit frmSettingsEdit = new SettingsEdit(setting);
            if (frmSettingsEdit.ShowDialog()==DialogResult.OK)
            {
                settingsHandle.SetParamValue("Connection\\ServerName", setting.ServerName);
                settingsHandle.SetParamValue("Connection\\UserName", setting.UserName);
                settingsHandle.SetParamValue("Connection\\BaseName", setting.BaseName);
                UpdateSetting();
            }
            */
        }

        private void cbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            tmUpdate.Interval = (int)edInterval.Value*1000;
            tmUpdate.Enabled = cbUpdate.Checked;
        }

        private void edInterval_ValueChanged(object sender, EventArgs e)
        {
            tmUpdate.Interval = (int)edInterval.Value;
        }

        private void tmUpdate_Tick(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }

        private void miAttributes_Click(object sender, EventArgs e)
        {
            var frmShimentElements = new ShipmentElements();

           // SetFormPrivalage(frmShimentElements, "Attr");
            AddFormTab(frmShimentElements, "Элементы отгрузки");
        }

        private void miTransportType_Click(object sender, EventArgs e)
        {
            
            DictSimple dict = new DictSimple();

            dict.TableName = "transport_type";
            dict.Title = "Справочник: Тип транспорта";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.VarChar, Length = 20 });
            dict.Columns.Add(new DictColumn { Id = "Tonnage", IsPK = false, IsVisible = true, Title = "Тоннаж", DataField = "tonnage", Width = 80, DataType = SqlDbType.Int });
            
            /*
            var frmTransporType = new SimpleDict(dict);
            SetFormPrivalage(frmTransporType, "TransporType");
            AddFormTab(frmTransporType, "Типы транспорта");
            */
        }

        private void miDictTC_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();

            dict.TableName = "transport_company";
            dict.Title = "Справочник: Транспортные компании";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "ID", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Code", IsPK = false, IsVisible = true, Title = "Код", DataField = "code", Width = 80, DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.VarChar, Length = 254 });
            dict.Columns.Add(new DictColumn { Id = "IsActive", IsPK = false, IsVisible = true, Title = "Активная", DataField = "is_active", Width = 80, DataType = SqlDbType.Bit });
            
            /*
            var frmTransportCompany = new SimpleDict(dict);
            SetFormPrivalage(frmTransportCompany, "TC");
            AddFormTab(frmTransportCompany, "Транспортные компании");
            */
        }

        private void mciPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (tblShipments.SelectedRows.Count <= 0)
                return;

            Shipment shipment = DataService.context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            if (shipment == null)
                return;
            Excel.Range range;
            
            SettingReport settingReport = DataService.setting.Reports.Find(r => r.Name == (shipment.ShIn == false ? "Лист отгрузки" : "Лист прихода"));
            if (settingReport == null)
            {
                MessageBox.Show("Не задан шаблон печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (shipment.ShIn == false)
            {
                /*
                if (DataService.setting.ShipmentReport == "")
                {
                    MessageBox.Show("Не задан шаблон печати листа отгрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                */
                DataRow[] printRows = (tblShipments.DataSource as DataTable).Select("ShpId = "+ tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value.ToString());
                ExcelPrint excel = new ExcelPrint(settingReport.TemplatePath);
                //Код отгрузки
                excel.SetValue(1, 5, 2, "*PL"+printRows[0]["ShpId"] + "*");
                excel.SetValue(1, 5, 3, "PL"+printRows[0]["ShpId"]);
                //Прибыл по плану
                excel.SetValue(1, 3, 6, printRows[0]["ShpDate"].ToString().Substring(0,10)+" "+ printRows[0]["SlotTime"]);
                //Прибыл по факту
                excel.SetValue(1, 3, 7, printRows[0]["ShpSubmissionTime"]);
                //ФИО
                excel.SetValue(1, 3, 8, printRows[0]["ShpDriverFio"]);
                //№ машины
                string trailerNumber = printRows[0]["ShpTrailerNumber"].ToString() != "" ? "/" + printRows[0]["ShpTrailerNumber"] : "";
                excel.SetValue(1, 3, 9, printRows[0]["ShpVehicleNumber"]+ trailerNumber);
                //№ телефона
                excel.SetValue(1, 3, 10, printRows[0]["ShpDriverPhone"]);
                //№ ворот	
                excel.SetValue(1, 3, 11, printRows[0]["GateName"]);
                //Время постановки на ворота	
                excel.SetValue(1, 3, 12, printRows[0]["ShpStartTime"]);
                //№ пломбы
                excel.SetValue(1, 3, 13, printRows[0]["ShpStampNumber"]);
                //Время окончание загрузки
                excel.SetValue(1, 3, 14, printRows[0]["ShpEndTimePlan"]);
                //Убыл: дата, время
                excel.SetValue(1, 3, 15, printRows[0]["ShpEndTimeFact"]);

                for(int i = 0;i<printRows.Count();i++)
                {
                    excel.SetValue(1, 1, 17 + i+1, printRows[i]["OrdLVCode"]);
                    excel.SetValue(1, 2, 17 + i+1, printRows[i]["KlientName"]);
                }
                

                range = excel.SelectCells(1, 1, 17, 1, 17 + printRows.Count());
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                range = excel.SelectCells(1, 2, 17, 2, 17 + printRows.Count());
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                range = excel.SelectCells(1, 1, 18, 6, 18 + printRows.Count()-1);
                

                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.EntireRow.Font.Bold = false;
                range.Font.Size = 11;
                range = excel.SelectCells(1, 1, 16, 6, 18 + printRows.Count()-1);
              
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

                excel.Merge(1, 1, 17 + printRows.Count() + 2, 1, 17 + printRows.Count() + 3);
                range = excel.SelectCells(1, 1, 17 + printRows.Count() + 2, 2, 17 + printRows.Count() + 2);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                range.WrapText = true;
                excel.SetValue(1, 1, 17 + printRows.Count() + 2, "Комментарии к отгрузке:");


                int commentRow = 17 + printRows.Count() + 2;
                if (shipment.IsCourier == true)
                {
                    range = excel.SelectCells(1, 2, commentRow, 6, commentRow+1);
                    range.Merge();
                    range.Font.Bold = true;
                    range.Font.Size = 18;
                    range.Font.Color = Color.Red;
                    range.Interior.Color= Color.Yellow;
                    excel.SetValue(1, 2, commentRow, "Необходимо прикрепить комплект документов к грузу");
                    commentRow += 2;
                }

                range = excel.SelectCells(1, 2, commentRow, 6, commentRow + 2);
                range.Merge();
                range.Font.Bold = false;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                range.WrapText = true;
                excel.SetValue(1, 2, commentRow, printRows[0]["ShpComment"]);

                range = excel.SelectCells(1, 1, 17 + printRows.Count() + 2, 6, 17 + printRows.Count() + 6);
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

                range = excel.SelectCells(1, 1, 1, 1,1);
                range.Activate();

                excel.Visible = true;
            }
           else
            {
                /*
                if (DataService.setting.ReceiptReport == "")
                {
                    MessageBox.Show("Не задан шаблон печати листа отгрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                */
                if (tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value.ToString() == "")
                {
                    MessageBox.Show("Отгрузка не содержит ни одного заказа. Печать не возможна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string filter = "ShpId = " + tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
                //                +" and OrdId = "+ tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value.ToString();
                DataRow[] printRows = (tblShipments.DataSource as DataTable).Select(filter);
                ExcelPrint excel = new ExcelPrint(settingReport.TemplatePath);
                string orderLVCode = "";
                //Соберем заказы
                for (int i = 0; i < printRows.Count(); i++)
                {
                    if (orderLVCode != "")
                        orderLVCode = orderLVCode + "/";
                    orderLVCode= orderLVCode+printRows[i]["OrdLVCode"];
                    
                }
                //Прибыл по плану
                excel.SetValue(1, 2, 6, printRows[0]["ShpDate"].ToString().Substring(0, 10) + " " + printRows[0]["SlotTime"]);
                //Прибыл по факту
                excel.SetValue(1, 2, 7, printRows[0]["ShpSubmissionTime"]);
                //ФИО
                excel.SetValue(1, 2, 8, printRows[0]["ShpDriverFio"]);
                //№ машины
                string trailerNumber = printRows[0]["ShpTrailerNumber"].ToString() != "" ? "/" + printRows[0]["ShpTrailerNumber"] : "";
                excel.SetValue(1, 2, 9, printRows[0]["ShpVehicleNumber"]+ trailerNumber);
                //№ телефона
                excel.SetValue(1, 2, 10, printRows[0]["ShpDriverPhone"]);
                //№ номер накладной
                //printRows[0]["OrdLVCode"]
                excel.SetValue(1, 2, 11, orderLVCode);
                //№ ворот
                excel.SetValue(1, 2, 12, printRows[0]["GateName"]);
                //Время постановки на ворота	
                excel.SetValue(1, 2, 13, printRows[0]["ShpStartTime"]);
                //№ пломбы
                //excel.SetValue(1, 2, 12, printRows[0]["ShpStampNumber"]);
                //Количество паллет
                int? pallentsCount = DataService.SQLGetIntValue("select pallet_amount from shipment_orders where id = " + (int)printRows[0]["OrdID"]);
                excel.SetValue(1, 2, 14, pallentsCount);
                //Убыл: дата, время
                excel.SetValue(1, 2, 15, printRows[0]["ShpEndTimeFact"]);

                range = excel.SelectCells(1, 1, 1, 1, 1);
                range.Activate();

                excel.Visible = true;
                this.Cursor = Cursors.Default;
            }

            
        }

        private void miConnect_Click(object sender, EventArgs e)
        {
            if (GetLogin())
            {
                LoginUser();
            }
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            (item.Tag as DataGridViewColumn).Visible = item.CheckState == CheckState.Checked ? true : false;
            DataService.settingsHandle.SetParamValue("View\\HideColumns", GetHideColumns());
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (!SearchByOrder(true))
            {
                SqlHandle sql = new SqlHandle(DataService.connectionString);
                sql.Connect();
                sql.SqlStatement = @"select s_date 
                                    from shipments s inner join shipment_orders so on (s.id = so.shipment_id)
                                    where so.lv_order_code = '" + edSearch.Text+"'";
                sql.IsResultSet = true;
                sql.Execute();
                if (sql.HasRows())
                {
                    sql.Read();
                    DateTime? date = sql.GetNullDateTimeValue(0, true);
                    if (date !=null)
                    {
                        edCurrDay.Value = (DateTime)date;
                        SearchByOrder(true);
                    }
                }    
                sql.Disconnect();
            }
        }

        private void edSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SearchByOrder(true);
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            SearchByOrder(false);
        }

        private void miRepPeriod_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepPeriod repPeriod = new RepPeriod(reportParams);



            if (repPeriod.ShowDialog()==DialogResult.OK)
            {
                
                ShowReport(REPORT_PERIOD, reportParams);
            }
        }


        private void miRepStatistic_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepStatistic repStatistic = new RepStatistic(reportParams);
            if (repStatistic.ShowDialog() == DialogResult.OK)
            {
                ShowReport(REPORT_STATISTIC, reportParams);
            }
        }

        private void miRepTC_Click(object sender, EventArgs e)
        {
            ReportParams reportParams = new ReportParams();
            RepTC repTC = new RepTC(reportParams);
            if (repTC.ShowDialog() == DialogResult.OK)
            {
                ShowReport(REPORT_TC, reportParams);
            }
        }

        #region Reports

        private SettingReport GetReportSetting(string reportName)
        {
            return DataService.setting.Reports.Find(r => r.Name == reportName);
            
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


            SqlHandle sql = new SqlHandle(DataService.connectionString);
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
            excel.SetValue(1, 1, 2, "Данные по ТС за период с " + reportParams["PeriodBegin"] + " по " + reportParams["PeriodEnd"]+ ". Опоздание (часы, минуты), с учетом допуска +20 мин");
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
            string dateEnd = String.Format("{0}.{1}.{2}",DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(monthEnd)), monthEnd, year);

            SqlHandle sql = new SqlHandle(DataService.connectionString);
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
            int ShpType = int.Parse(reportParams["ShpType"])-1;

            DataSet dataSet = GetShipment(DateTime.Parse(reportParams["PeriodBegin"]), DateTime.Parse(reportParams["PeriodEnd"]), null, null, ShpType);
            
            //SqlDataReader dataRows = GetShipment(edCurrDay.Value, null, null, null);


            excel.SetValue(1, 6, 2, "Данные за период с "+ reportParams["PeriodBegin"]+" по "+ reportParams["PeriodEnd"]);
            /*
            DataTable dt = new DataTable();
            dt.Load(dataRows);
      */
            
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
                    printRow[0,colIdx] = cellValue;
                    
                    //excel.SetValue(1, colIdx + 1, rowIdx, cellValue);
                    // 
                    
                }
                //excel.SetValues(1, 1, rowIdx + 5, columnOrder.Count, rowIdx + 5, printRow);
                excel.SetRowValues(1, rowIdx + 5, columnOrder.Count, printRow);
                rowIdx++;
                wait.SetPosition(rowIdx);
            }

            range = excel.SelectCells(1, 1, 5, columnOrder.Count, rowIdx+4);
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
            string[] param= null;
            if (m.Groups.Count > 2)
            {
                if (m.Groups[2].Value.IndexOf(',') > 0)
                    param = m.Groups[2].Value.Split(new char[] { ',' });
                else
                    param = new string[] { m.Groups[2].Value };

            }

            for(int i = 0;i<param.Length;i++)
            {
                if (param[i].StartsWith("[") && param[i].EndsWith("]"))
                    param[i] = param[i].Trim(new char[] { '[',']'});
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
        private void tblShipments_Sorted(object sender, EventArgs e)
        {
            CalcRowColor();
        }

        private void btnCalendarCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCalendarOk_Click(object sender, EventArgs e)
        {

        }

        private void bwProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            wait.IncPosition();
        }

        

        private void bwProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            miRepPeriod.Enabled = true;
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            frmShipmentHistory frmShipment_History = new frmShipmentHistory(-1,false);
            AddFormTab(frmShipment_History, "История изменений");
            frmShipment_History.Populate();
        }

        private void miCalcOrderVolume_Click(object sender, EventArgs e)
        {
            frmVolumeCalc frmVolumeCalc = new frmVolumeCalc(DataService.setting);
            AddFormTab(frmVolumeCalc, "Расчет объема заказа");
        }

        private void miCurrentTask_Click(object sender, EventArgs e)
        {
            frmCurrentTask frmCurrentTask = new frmCurrentTask();
            frmCurrentTask.ShowDialog();
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipmentsUIFilter();
            DataService.settingsHandle.SetParamValue("View\\ActionFilter", String.Join(",", GetFilterActionList().ToArray()));
        }

        private void btnColumnVisible_ButtonClick(object sender, EventArgs e)
        {

        }

        private void tblShipments_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (IsFormLoad)
                return;
            var col = shipmentColumns.Find(c => c.Id == e.Column.Name);
            if (col == null)
            {
                col = new ShipmentColumn() { Id = e.Column.Name, Visible = true};
                shipmentColumns.Add(col);
            }
            col.Order = e.Column.DisplayIndex;
            DataService.settingsHandle.SetParamList<ShipmentColumn>("View\\ShipmentColumns", "ShipmentColumns", shipmentColumns);
            
        }

        private void btnSearchEx_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch(edCurrDay.Value);
            AddFormTab(frmSearch, "Расширенный поиск");
           
        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void miDictSupplier_Click(object sender, EventArgs e)
        {


            var frmSupplier = new Suppliers();
            //SetFormPrivalage(frmSupplier, "Supplier");
            AddFormTab(frmSupplier, "Поставщики");
        }

        private void cbPaint_CheckedChanged(object sender, EventArgs e)
        {
            isPaint = cbPaint.Checked;
            tblShipments.Invalidate();
            tblShipments.Refresh();
        }

        private void mnuContext_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mciOrderDetail_Click(object sender, EventArgs e)
        {
            ShowOrderDetail();
        }

        private bool HasOrderDetail(int OrdId, int InOut)
        {
            OrderDetailItem orderDetailItem = orderDetailCount.Find(i => i.ID == OrdId && i.DetailType == InOut );            
            return orderDetailItem !=null && orderDetailItem.Quantity>0;
        }
        private void tblShipments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*
                if (tblShipments.Columns[e.ColumnIndex].Name == "colOrderDetail")
                {
                    string direction = Convert.ToString(tblShipments.Rows[e.RowIndex].Cells["colDirection"].Value);
                int inOut = Convert.ToString(tblShipments.Rows[e.RowIndex].Cells["colDirection"].Value) == "вход" ? 1 : 0;
                    if (!HasOrderDetail((int)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value,inOut))
                    {
                    (((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell).Value
                    e.Value = null;// new Bitmap(10, 10);
                    e.FormattingApplied = true;
                    //(tblShipments.Rows[e.RowIndex].Cells["colDirection"] as DataGridViewImageCell).Image
                }  
                    else
                    {
                    //e.Value = Properties.Resources.view_detailed_2595;
                    e.FormattingApplied = true;
                }
                    
            }
            */
        }

        private void tblShipments_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {

        }



        private void miDictWarehouse_Click(object sender, EventArgs e)
        {
            var frmWarehouse = new Warehouses();
            //SetFormPrivalage(frmWarehouse, "Warehouse");
            AddFormTab(frmWarehouse, "Склады");
        }

        private void miCustomPosts_Click(object sender, EventArgs e)
        {
            var frmCustomPosts = new CustomPosts();
            //SetFormPrivalage(frmCustomPosts, "CustomPost");
            AddFormTab(frmCustomPosts, "Таможенные посты");
        }

        private void miTransportView_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();

            dict.TableName = "transport_view";
            dict.Title = "Справочник: Вид транспорта";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.VarChar, Length = 20 });

            /*
            var frmTransporView = new SimpleDict(dict);
            SetFormPrivalage(frmTransporView, "TransporView");
            AddFormTab(frmTransporView, "Виды транспорта");
            */
        }
    }
}
