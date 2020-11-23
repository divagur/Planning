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
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
namespace Planning
{
    
    public partial class frmMain : Form
    {
       private string CR = Environment.NewLine;

        //DataService dataService = new DataService();
        // = new PlanningDbContext();

        private int Xwid = 6;//координаты ширины по диагонали крестика
        private const int tab_margin = 5;//координаты по высоте крестика
        public WaitHandler waitCur;
        SettingsHandle settingsHandle = new SettingsHandle("Settings.xml");
        List<UserAccessItem> UserPrvlg = new List<UserAccessItem>();
        UserAccessItem mainFormAccess =new UserAccessItem();
        SqlConnection LVConnect;
        public frmMain()
        {
            InitializeComponent();
            SqlHandle.OnExecuteBeforeCommon += OnSqlExecureBeforeCommon;
            SqlHandle.OnExecuteAfterCommon += OnSqlExecureAfterCommon;
            waitCur = new WaitHandler(this);
        }

        public void OnSqlExecureBeforeCommon(string Param)
        {
            this.Cursor = Cursors.AppStarting;
        }

        public void OnSqlExecureAfterCommon(string Param)
        {
            this.Cursor = Cursors.Default;
        }

        private void tblShipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetText(tblShipments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private SqlDataReader GetShipment(DateTime DateFrom, DateTime? DateTill, string ShpId, string OrdId)
        {
            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "SP_PL_MainQueryP";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@From", Value = DateFrom });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Till", Value = DateTill });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@ShpId", Value = ShpId });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@OrdID", Value = OrdId });

            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return sql.Reader;
            
            
/*
            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection(DataService.connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка подключения:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        return null;
                    }


                }

                string sqlText = "SP_PL_MainQueryP";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@From", Value = DateFrom });
                command.Parameters.Add(new SqlParameter { ParameterName = "@Till", Value = DateTill });
                command.Parameters.Add(new SqlParameter { ParameterName = "@ShpId", Value = ShpId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@OrdID", Value = OrdId });
                
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при получении данных: " + CR + ex.Message, "Ошибка", MessageBoxButtons.OK);
                }
                return reader;
*/
            
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
            var reader = GetShipment(edCurrDay.Value, null, null,null);
            if (reader == null)
            {
                return;
            }
            tbMain.Enabled = true;
            miDicts.Enabled = true;
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Load(reader);

            tblShipments.AutoGenerateColumns = false;
            tblShipments.DataSource = ds.Tables[0];
            if (restoreRow)
                SearchBy(true, i => tblShipments.Rows[i].Cells["colId"].Value.ToString() == rowShpId && tblShipments.Rows[i].Cells["colIdNakl"].Value.ToString() == rowShpOrdId);
           //this.Cursor = Cursors.Default;
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

        private void UpdateSetting()
        {
            /*    SettingsEdit frmSettingsEdit = new SettingsEdit(setting);
                if (frmSettingsEdit.ShowDialog() == DialogResult.OK)
                {
                    SettingsHandle.Save(setting);
                    DataService.connectionString = $"Data Source={setting.ServerName};Initial Catalog={setting.BaseName};User ID={setting.UserName}; Password = {setting.Password}";
                    context = new PlanningDbContext(DataService.GetEntityConnectionString(DataService.connectionString));
                    ShipmentsLoad();
                }
                */
            DataService.connectionString = DataService.BuildConnectionString(DataService.setting.ServerName,
                DataService.setting.BaseName, 
                DataService.setting.UserName, 
                DataService.setting.Password, DataService.setting.IsWnd);
            DataService.entityConnectionString = DataService.GetEntityConnectionString(DataService.connectionString);
            //$"Data Source={DataService.setting.ServerName};Initial Catalog={DataService.setting.BaseName};Integrated Security=true;User ID={DataService.setting.UserName}; Password = {DataService.setting.Password}";
            //DataService.context = new PlanningDbContext(DataService.entityConnectionString);
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
                if (mi != null)
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
            settingsHandle.SetParamValue("Connection\\ServerName", DataService.setting.ServerName);
            settingsHandle.SetParamValue("Connection\\UserName", DataService.setting.UserName);
            settingsHandle.SetParamValue("Connection\\BaseName", DataService.setting.BaseName);
            //settingsHandle.SetParamValue("Connection\\Password", setting.Password);
            settingsHandle.SetParamValue("ReportTemplate\\ShipmentTemplate", DataService.setting.ShipmentReport);
            settingsHandle.SetParamValue("ReportTemplate\\ReceiptTemplate", DataService.setting.ReceiptReport);
        }

        private void LoginUser()
        {
            UpdateSetting();
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
            FormLogin frmLogin = new FormLogin(DataService.setting);
            if (frmLogin.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }
            CloseAllTabs();
            settingsHandle.SetParamValue("Connection\\UserName", DataService.setting.UserName);
            statusInfo.Text = "Пользователь: " + DataService.setting.UserName;

            return true;
        }

        private string GetHideColumns()
        {

            List<string> result = new List<string>();
            foreach (DataGridViewTextBoxColumn col in tblShipments.Columns)
            {
                if (!col.Visible)
                {
                    result.Add(col.Name);
                }
            }
            return String.Join(",", result);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

            //Получаем параметры из конфига
            DataService.setting.ServerName = settingsHandle.GetParamStringValue("Connection\\ServerName");
            DataService.setting.BaseName = settingsHandle.GetParamStringValue("Connection\\BaseName");
            DataService.setting.UserName = settingsHandle.GetParamStringValue("Connection\\UserName");
            //setting.Password = settingsHandle.GetParamStringValue("Connection\\Password");

            DataService.setting.ShipmentReport = settingsHandle.GetParamStringValue("ReportTemplate\\ShipmentTemplate");
            DataService.setting.ReceiptReport = settingsHandle.GetParamStringValue("ReportTemplate\\ReceiptTemplate");

            /*
            if(setting == null)
            {
                setting = new Settings();
                UpdateSetting();
            }
            */
            //Если нет сервера или базы, то выдадим окно настройки
            if (DataService.setting.BaseName == "" || DataService.setting.ServerName =="")
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
            if (!DataService.TryDBConnect(DataService.setting.ServerName,DataService.setting.BaseName, "","", DataService.setting.IsWnd, false))
            {
                DataService.setting.IsWnd = false;
                if (!GetLogin())
                {
                    this.Close();
                    return;
                }
            }
            /*
            //Если в настройках нет пользователя то запросим
            if (DataService.setting.UserName == "")
            {
                if (!GetLogin())
                {
                    this.Close();
                }
            }
            */
            UpdateSetting();


            //LVConnect = new SqlConnection(LVconnectionString);
            //LVConnect.Open();
            /*
            SqlHandle hSql = new SqlHandle(DataService.connectionString);
            hSql.Connect();
            hSql.IsResultSet = false;
            hSql.TypeCommand = CommandType.StoredProcedure;
            hSql.SqlStatement = "Lvision.sys.sp_setapprole";
            hSql.AddCommandParametr(new SqlParameter { ParameterName = "@rolename", Value = "pl_role" });
            hSql.AddCommandParametr(new SqlParameter { ParameterName = "@password", Value = "planning" });
            hSql.Execute();
            hSql.Disconnect();
            */


            LoginUser();


            


            //DataService dataService = new DataService();
            DataService.Dicts.Add("Причины_задержки", new DictInfo{ TableName = "delay_reasons", NameColumn = "name" });
            DataService.Dicts.Add("Типы_операций", new DictInfo { TableName = "opers_type", NameColumn = "name" });
            DataService.Dicts.Add("Ворота",new DictInfo {TableName= "gateways", NameColumn = "name" });
            DataService.Dicts.Add("Депозиторы", new DictInfo { TableName = "depositors", NameColumn = "name" });
            DataService.Dicts.Add("ТаймСлоты", new DictInfo { TableName = "time_slot", NameColumn = "name" });
            DataService.Dicts.Add("ТК", new DictInfo { TableName = "transport_company", NameColumn = "name" });
            DataService.Dicts.Add("Типы_транспорта", new DictInfo { TableName = "transport_type", NameColumn = "name" });
            //dataService.Dicts.Add("Ворота", "gateways");



            List<string> hideCols = settingsHandle.GetParamStringValue("View\\HideColumns").Split(',').ToList();
            btnColumnVisible.DropDownItems.Clear();
            foreach(DataGridViewTextBoxColumn col in tblShipments.Columns)
            {
                if (col.Visible)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)btnColumnVisible.DropDownItems.Add(col.HeaderText);
                    item.CheckOnClick = true;
                    item.CheckState = hideCols.IndexOf(col.Name) < 0?CheckState.Checked:CheckState.Unchecked;
                    item.Tag = col;
                    item.Click += toolStripMenuItem3_Click;
                    col.Visible = hideCols.IndexOf(col.Name) < 0;
                }
                
                
            }

            statusInfo.Text = "Пользователь: " + DataService.setting.UserName;

        }

        private void miDictDelayReasons_Click(object sender, EventArgs e)
        {
            
            DictSimple dict = new DictSimple();
            dict.TableName = "delay_reasons";
            dict.Title = "Справочник: Причины задержки";

            dict.Columns.Add(new DictColumn {Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int});
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 254 });

            SimpleDict frmDelayReasons = new SimpleDict(dict);
            SetFormPrivalage(frmDelayReasons, "DelayReasons");
            AddFormTab(frmDelayReasons, "Причины задержки");
        }

        private void miDictOpersType_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();
            dict.TableName = "opers_type";
            dict.Title = "Справочник: Типы операций";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 20 });

            SimpleDict frmOperType = new SimpleDict(dict);
            SetFormPrivalage(frmOperType, "OperType");
            AddFormTab(frmOperType, "Типы операций");
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

            SimpleDict frmGate = new SimpleDict(dict);
            SetFormPrivalage(frmGate, "Gate");
            AddFormTab(frmGate, "Ворота");
            /*
            frmOperType.TopLevel = false;
            frmOperType.Visible = true;
            frmOperType.FormBorderStyle = FormBorderStyle.None;
            frmOperType.Dock = DockStyle.Fill;
            tabForms.TabPages.Add("Ворота");
            tabForms.TabPages[tabForms.TabPages.Count-1].Controls.Add(frmOperType);
            //frmOperType.Show();
            */
        }
        
        void AddShToLV(Shipment shipment)
        {
            if (shipment.ShIn == false)
            {
                DataService.AddShipmentToLV(shipment.Id);
            }

            DataService.AddShipmentToLV(shipment.Id);
        }

        private void ShipmentRowEdit()
        {
            if (tblShipments.SelectedRows.Count <= 0)
                return;
            DataService.InitContext();
            ShipmentAddResult shipmentAddResult = new ShipmentAddResult();
            if (tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colDirection"].Value.ToString()!="перем")
            {
                shipmentAddResult.Result = DataService.context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            }
            else
            {
                shipmentAddResult.Result = DataService.context.Movements.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            }
            
            ShipmentEdit(shipmentAddResult);
            ShipmentsLoad();
        }
        private void ShipmentEdit(ShipmentAddResult shipmentAddResult)
        {
            shipmen_edit frmShipmentEdit;
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
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
            
            shipmen_edit frmShipmentEdit = new shipmen_edit(shipment, context);
            frmShipmentEdit.ClearFields();
            if (frmShipmentEdit.ShowDialog()==DialogResult.OK)
            {
                DataService.Add(shipment);
            }
            */
            ShipmentAddResult shipmentAddResult = new ShipmentAddResult();
           // Shipment shipment = new Shipment();
            ShipmentAdd frmShipmentAdd = new ShipmentAdd(shipmentAddResult);
            DialogResult result = frmShipmentAdd.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {
                //DataService.context.Shipments.Add(shipment);
                //DataService.context.SaveChanges();
                //AddShToLV(shipment);

                
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
            var frmUsers = new Users();
            SetFormPrivalage(frmUsers, "Users");
            AddFormTab(frmUsers, "Пользователи");
        }

        private void miDictTimeSlot_Click(object sender, EventArgs e)
        {
            var frmTimeSlot = new TimeSlots();
            SetFormPrivalage(frmTimeSlot, "TimeSlot");
            AddFormTab(frmTimeSlot, "Тайм слоты");
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
            SetFormPrivalage(frmDepositors, "Depositor");       
            AddFormTab(frmDepositors, "Депозиторы");
        }

        private void tblShipments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
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
                else if ((bool)((DataGridView)sender).Rows[e.RowIndex].Cells["IsAddLv"].Value != true)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
             }
        }

        private void edCurrDay_ValueChanged(object sender, EventArgs e)
        {
            ShipmentsLoad();
        }

        private void tblShipments_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
      
        }

        private void tblShipments_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var CellColor = (int)((DataGridView)sender).Rows[e.RowIndex].Cells["BackgroundColor"].Value;
     
            ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(CellColor);// (Color)((DataGridView)sender).Rows[e.RowIndex].Cells["BackgroundColor"].Value;


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?","Подверждение",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                Shipment shipment = DataService.context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
                DataService.context.Shipments.Remove(shipment);
                DataService.context.SaveChanges();
                ShipmentsLoad();
            }
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
            
            SetFormPrivalage(frmUserGroups, "UserGrp");
            AddFormTab(frmUserGroups, "Группы пользователей");
        }

        private void tblShipments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShipmentRowEdit();
        }

        private void miSettings_Click(object sender, EventArgs e)
        {
            
            SettingsWizard frmSettingsWizard = new SettingsWizard(DataService.setting);
            if (frmSettingsWizard.ShowDialog()==DialogResult.OK)
            {
                SaveSettings();
                UpdateSetting();
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

            SetFormPrivalage(frmShimentElements, "Attr");
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

            var frmTypeTransport = new SimpleDict(dict);
            SetFormPrivalage(frmTypeTransport, "TransporType");
            AddFormTab(frmTypeTransport, "Типы транспорта");
        }

        private void miDictTC_Click(object sender, EventArgs e)
        {
            DictSimple dict = new DictSimple();

            dict.TableName = "transport_company";
            dict.Title = "Справочник: Транспортные компании";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.VarChar, Length = 254 });
            dict.Columns.Add(new DictColumn { Id = "IsActive", IsPK = false, IsVisible = true, Title = "Активная", DataField = "is_active", Width = 80, DataType = SqlDbType.Bit });
            

            var frmTransportCompany = new SimpleDict(dict);
            SetFormPrivalage(frmTransportCompany, "TC");
            AddFormTab(frmTransportCompany, "Транспортные компании");
        }

        private void mciPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            if (tblShipments.SelectedRows.Count <= 0)
                return;

            Shipment shipment = DataService.context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            Excel.Range range;
            if (shipment.ShIn == false)
            {
                if (DataService.setting.ShipmentReport == "")
                {
                    MessageBox.Show("Не задан шаблон печати листа отгрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataRow[] printRows = (tblShipments.DataSource as DataTable).Select("ShpId = "+ tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value.ToString());
                ExcelPrint excel = new ExcelPrint(DataService.setting.ShipmentReport);
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
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

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
                if (DataService.setting.ReceiptReport == "")
                {
                    MessageBox.Show("Не задан шаблон печати листа отгрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value.ToString() == "")
                {
                    MessageBox.Show("Отгрузка не содержит ни одного заказа. Печать не возможна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string filter = "ShpId = " + tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value.ToString();
                //                +" and OrdId = "+ tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colIdNakl"].Value.ToString();
                DataRow[] printRows = (tblShipments.DataSource as DataTable).Select(filter);
                ExcelPrint excel = new ExcelPrint(DataService.setting.ReceiptReport);
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
            (item.Tag as DataGridViewTextBoxColumn).Visible = item.CheckState == CheckState.Checked ? true : false;
            settingsHandle.SetParamValue("View\\HideColumns", GetHideColumns());
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
                if (sql.Reader.HasRows)
                {
                    sql.Reader.Read();
                    edCurrDay.Value = sql.Reader.GetDateTime(0).Date;
                    SearchByOrder(true);
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
    }
}
