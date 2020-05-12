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
                    connection.Open();

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
        private void ShipmentEdit(Shipment shipment)
        {
            shipmen_edit frmShipmentEdit = new shipmen_edit(shipment, context);
            frmShipmentEdit.ClearFields();
            frmShipmentEdit.Populate();
            if (frmShipmentEdit.ShowDialog() == DialogResult.OK)
            {
                context.SaveChanges();

                DataService.AddShipmentToLV(shipment.Id);

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

                DataService.AddShipmentToLV(shipment.Id);

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
            if (tblShipments.SelectedRows.Count <= 0)
                return;

            //Shipment shipment = DataService.Get((int)tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            Shipment shipment = context.Shipments.Find(tblShipments.Rows[tblShipments.CurrentCell.RowIndex].Cells["colId"].Value);
            ShipmentEdit(shipment);
            ShipmentsLoad();
            /* shipmen_edit frmShipmentEdit = new shipmen_edit(shipment, context);
            frmShipmentEdit.ClearFields();
            frmShipmentEdit.Populate();
            if (frmShipmentEdit.ShowDialog() == DialogResult.OK)
            {
                context.SaveChanges();
                tblShipments.Refresh();
            }
            */
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
    }
}
