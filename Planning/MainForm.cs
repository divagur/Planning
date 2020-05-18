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

namespace Planning
{
    public partial class frmMain : Form
    {
       private string CR = Environment.NewLine;

        DataService dataService = new DataService();
        PlanningDbContext context = new PlanningDbContext();

        private int Xwid = 6;//координаты ширины по диагонали крестика
        private const int tab_margin = 5;//координаты по высоте крестика
        Settings setting = new Settings(); 
        public frmMain()
        {
            InitializeComponent();

        }

        private void tblShipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShipmentsLoad()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show("Ошибка подключения:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbMain.Enabled = false;
                        miDicts.Enabled = false;

                        return;
                    }

                    tbMain.Enabled = true;
                    miDicts.Enabled = true;
                }

                string sqlText = "SP_PL_MainQueryP";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@From", Value =edCurrDay.Value});
                command.Parameters.Add(new SqlParameter { ParameterName = "@Till", Value = null });
                command.Parameters.Add(new SqlParameter { ParameterName = "@ShpId", Value = null });
                command.Parameters.Add(new SqlParameter { ParameterName = "@OrdID", Value = null });
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show("Ошибка при заполнении таблицы: " + CR + ex.Message,"Ошибка", MessageBoxButtons.OK);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add();
                ds.Tables[0].Load(reader);
                tblShipments.AutoGenerateColumns = false;
                tblShipments.DataSource = ds.Tables[0];

            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            setting = SettingsHandle.Load();
            if (setting == null)
            {
                setting = new Settings();
                SettingsEdit frmSettingsEdit = new SettingsEdit(setting);
                if (frmSettingsEdit.ShowDialog() == DialogResult.OK)
                    SettingsHandle.Save(setting);
                else
                    this.Close();
            }


            DataService.connectionString = $"Data Source={setting.ServerName};Initial Catalog={setting.BaseName};User ID={setting.UserName}; Password = {setting.Password}";
            //DataService dataService = new DataService();
            DataService.Dicts.Add("Причины_задержки", new DictInfo{ TableName = "delay_reasons", NameColumn = "name" });
            DataService.Dicts.Add("Типы_операций", new DictInfo { TableName = "opers_type", NameColumn = "name" });
            DataService.Dicts.Add("Ворота",new DictInfo {TableName= "gateways", NameColumn = "name" });
            DataService.Dicts.Add("Депозиторы", new DictInfo { TableName = "depositors", NameColumn = "name" });
            DataService.Dicts.Add("ТаймСлоты", new DictInfo { TableName = "time_slot", NameColumn = "name" });
            //dataService.Dicts.Add("Ворота", "gateways");
            tblShipments.AutoGenerateColumns = false;
            ShipmentsLoad();
 
        }

        private void miDictDelayReasons_Click(object sender, EventArgs e)
        {
            
            DictSimple dict = new DictSimple();
            dict.TableName = "delay_reasons";
            dict.Title = "Справочник: Причины задержки";

            dict.Columns.Add(new DictColumn {Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int});
            dict.Columns.Add(new DictColumn { Id = "name", IsPK = false, IsVisible = true, Title = "Наименование", DataField = "name", Width = 254, DataType = SqlDbType.NVarChar, Length = 254 });

            SimpleDict frmDelayReasons = new SimpleDict(dict);
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

            SimpleDict frmOperType = new SimpleDict(dict);
            AddFormTab(frmOperType, "Ворота");
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
        }

        private void ShipmentRowEdit()
        {
            if (tblShipments.SelectedRows.Count <= 0)
                return;

            Shipment shipment = context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            ShipmentEdit(shipment);
            ShipmentsLoad();
        }
        private void ShipmentEdit(Shipment shipment)
        {
            
            shipmen_edit frmShipmentEdit = new shipmen_edit(shipment, context);
            frmShipmentEdit.ClearFields();
            frmShipmentEdit.Populate();
            if (frmShipmentEdit.ShowDialog() == DialogResult.OK)
            {
                context.SaveChanges();

               AddShToLV(shipment);

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
            
            Shipment shipment = new Shipment();
            ShipmentAdd frmShipmentAdd = new ShipmentAdd(shipment, context);
            DialogResult result = frmShipmentAdd.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {
                context.Shipments.Add(shipment);
                context.SaveChanges();
                AddShToLV(shipment);


                if (result == DialogResult.Retry)
                {
                    ShipmentEdit(shipment);
                }
                ShipmentsLoad();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tblShipments.DataSource = DataService.GetAll();
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

        }

        private void miDictTimeSlot_Click(object sender, EventArgs e)
        {
            /*
            DictSimple dict = new DictSimple();

            dict.TableName = "time_slot";
            dict.Title = "Справочник: Тайм слоты";

            dict.Columns.Add(new DictColumn { Id = "Id", IsPK = true, IsVisible = false, Title = "Код", DataField = "id", DataType = SqlDbType.Int });
            dict.Columns.Add(new DictColumn { Id = "Depositor", IsPK = false, IsVisible = true, Title = "Депозитор", DataField = "depositor_id", Width = 254, DataType = SqlDbType.Int, Length = 5 });
            dict.Columns.Add(new DictColumn { Id = "TimeSlot", IsPK = false, IsVisible = true, Title = "Слот", DataField = "slot_time", Width = 254, DataType = SqlDbType.VarChar, Length = 5 });

            SimpleDict frmDepositors = new SimpleDict(dict);
            */
            var frmTimeSlot = new TimeSlots(context);
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

            SimpleDict frmDepositors = new SimpleDict(dict);
            AddFormTab(frmDepositors, "Депозиторы");
        }

        private void tblShipments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            if (e.ColumnIndex == ((DataGridView)sender).Columns["colCopmletePct"].Index && e.RowIndex>=0)
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
                        if (e.Value !=DBNull.Value)
                        {
                            decimal doneShare =(decimal)((DataGridView)sender).Rows[e.RowIndex].Cells["colDoneShare"].Value*100;

                            int progressWidth = (Convert.ToInt32(doneShare) * e.CellBounds.Width) / 100;

                            Rectangle newRect = new Rectangle(e.CellBounds.X + 0,
                                e.CellBounds.Y + 0, progressWidth,
                                e.CellBounds.Height - 1);

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;

                            e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), newRect);
                            e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                Brushes.Black, e.CellBounds, stringFormat);// e.CellBounds.X + 2,e.CellBounds.Y + 2 StringFormat.GenericDefault
                        }
                        e.Handled = true;
                    }
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
                Shipment shipment = context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
                context.Shipments.Remove(shipment);
                context.SaveChanges();
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

        }

        private void tblShipments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShipmentRowEdit();
        }

        private void miSettings_Click(object sender, EventArgs e)
        {
            SettingsEdit frmSettingsEdit = new SettingsEdit(setting);
            if (frmSettingsEdit.ShowDialog()==DialogResult.OK)
            {
                SettingsHandle.Save(setting);
                DataService.connectionString = $"Data Source={setting.ServerName};Initial Catalog={setting.BaseName};User ID={setting.UserName}; Password = {setting.Password}";
                ShipmentsLoad();
            }
        }
    }
}
