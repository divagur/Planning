using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;

namespace Planning
{
    public partial class ShipmentAdd : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        PlanningDbContext _context;
        Shipment _shipment;
        List<string> SelectedId;
        bool Locked;

        private void LockChangeType(bool Lock)
        {
            
            cmbDepositor.Enabled = !Lock;
            cmbType.Enabled = !Lock;
            
        }
        public ShipmentAdd(Shipment shipment)
        {
            InitializeComponent();
            _context = DataService.context;
            _shipment = shipment;
            SelectedId = new List<string>();
        }
        private void PopulateList()
        {
            cmbDepositor.Items.Clear();
            foreach (var d in _context.Depositors.ToList())
                cmbDepositor.Items.Add(d.Name);

            cmbDepositor.SelectedIndex = 0;
            int? depositorId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
            cmbTimeSlot.Items.Clear();
            foreach (var ts in _context.TimeSlots.Where(x=>x.DepositorId ==depositorId).OrderBy(x=>x.SlotTime).ToList())
                cmbTimeSlot.Items.Add(ts.SlotTime.ToString());

        }
        private void PopulateOrders(/*int DepositorLVId, int Type*/)
        {
            int? DepositorLVId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
            int Type = cmbType.SelectedIndex;

            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string sqlText= "sp_AddLoadingLVList";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@Split", Value = 0 });
                command.Parameters.Add(new SqlParameter {ParameterName = "@In",Value = Type });
                command.Parameters.Add(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    tblOrders.Rows.Clear();
                    while (reader.Read())
                    {
                        int Row = tblOrders.Rows.Add();
                        tblOrders.Rows[Row].Cells[0].Value = reader.GetString(1);
                        tblOrders.Rows[Row].Cells[1].Value = reader.GetString(2);

                        tblOrders.Rows[Row].Cells[2].Value = reader.GetSqlDateTime(3).ToString() != "Null" ? reader.GetSqlDateTime(3).ToString().Substring(0, 10) : "";
                        tblOrders.Rows[Row].Cells[3].Value = reader.GetString(4);
                        tblOrders.Rows[Row].Cells[4].Value = reader.GetInt32(0);
                    }
                }
                //string whereEx = ""; 
                /*
                                if (Type == 0)
                                {

                                    //whereEx = SelectedId.Count > 0 ? $" and ord_Code not in ({string.Join(",",SelectedId.ToArray())}) " : "";
                                    sqlText = @"select distinct ord_ID, ord_Code LVCode, msg_Greek LVStatus, ord_ExpShipDate ExpDate, cmp_ShortName Company
                                        from dbo.LV_Order with(nolock)
                                        left join dbo.LV_Customer with(nolock) on cus_ID = ord_CustomerID
                                        left join dbo.LV_Company with (nolock) on cmp_ID = cus_CompanyID
                                        left join dbo.LV_ProgressStatus with(nolock) on pst_ID = ord_StatusID
                                        left join dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
                                        where ord_StatusID not in (3, 4) ";
                                }
                                else if (Type == 1)
                                {

                                    //whereEx = SelectedId.Count > 0 ? $" and rct_Code not in ({string.Join(",", SelectedId.Select(n=>"'"+n+"'").ToArray())}) " : "";
                                    sqlText = @"select distinct rct_ID, rct_Code LVCode, msg_Greek LVStatus, rct_ExpectedDate ExpDate, cmp_ShortName Company
                                        from dbo.LV_Receipt with(nolock)
                                        left join dbo.LV_Supplier with(nolock) on spl_ID = rct_SupplierID
                                        left join dbo.LV_Company with (nolock) on cmp_ID = spl_CompanyID
                                        left join dbo.LV_ProgressStatus with(nolock) on pst_ID = rct_ProgressID
                                        left join dbo.LV_Messages with(nolock) on msg_code = pst_MessageCode and msg_languageID = 4
                                        where rct_ProgressID not in (3, 4) ";
                                    //and rct_DepositorID = 3
                                }
                           */
/*                
                adapter = new SqlDataAdapter(sqlText, connection);
                
                ds = new DataSet();
                ds.Tables.Add();
                ds.Tables[0].Load(reader);
                tblOrders.AutoGenerateColumns = false;
                tblOrders.DataSource = ds.Tables[0];
                */
            }
        }
        private void MoveRow(DataGridView TableSource, DataGridView TableTarged)
        {
            if (TableSource.RowCount <= 0) return;

            int CurrentRow = TableSource.CurrentCell.RowIndex;

            int tagetRow = TableTarged.Rows.Add();

            for(int i = 0; i< TableTarged.ColumnCount; i++)
            {
                TableTarged.Rows[tagetRow].Cells[i].Value = TableSource.Rows[CurrentRow].Cells[i].Value;
            }
            
            
                /*
            TableTarged.Rows.Add(TableSource.Rows[CurrentRow].Cells[ColId].Value,
                TableSource.Rows[CurrentRow].Cells["colState"].Value,
                TableSource.Rows[CurrentRow].Cells["colDate"].Value,
                TableSource.Rows[CurrentRow].Cells["colKlient"].Value);
            */
            TableSource.Rows.Remove(TableSource.CurrentRow);
        }
        private void Save()
        {
            //
            _shipment.SDate = dtSDate.Value;
            _shipment.ShIn = cmbType.Text == "Вход" ? true : false;
            _shipment.DepositorId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
            _shipment.TimeSlotId = DataService.GetDictIdByCondition("ТаймСлоты", $"depositor_id = {_shipment.DepositorId} and slot_time = '{cmbTimeSlot.Text}'");
            _shipment.IsAddLv = false;

            for (int i = 0;i<tblShipmentItem.RowCount;i++)
            {
                ShipmentOrder shipmentOrder = new ShipmentOrder();
                
                shipmentOrder.OrderId = tblShipmentItem.Rows[i].Cells["colItemId"].Value.ToString();
                shipmentOrder.LVOrderId = (int?)tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value;
                shipmentOrder.lv_order_code = tblShipmentItem.Rows[i].Cells["colItemId"].Value.ToString();
                _shipment.ShipmentOrders.Add(shipmentOrder);
            }

            //_context.SaveChanges();

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShipmentAdd_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            dtSDate.Value = DateTime.Now;
            PopulateList();
            if (cmbDepositor.Items.Count>0)
                cmbDepositor.SelectedIndex = 0;
            PopulateOrders();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOrders();


        }

        private void btnToShipment_Click(object sender, EventArgs e)
        {
            /* if (tblOrders.Rows.Count == 0)
                 return;


             int CurrentRow = tblOrders.CurrentCell.RowIndex;

             tblShipmentItem.Rows.Add(tblOrders.Rows[CurrentRow].Cells["colId"].Value,
                 tblOrders.Rows[CurrentRow].Cells["colState"].Value,
                 tblOrders.Rows[CurrentRow].Cells["colDate"].Value,
                 tblOrders.Rows[CurrentRow].Cells["colKlient"].Value);

             tblOrders.Rows.Remove(tblOrders.CurrentRow);
             */
            MoveRow(tblOrders, tblShipmentItem);
            LockChangeType(true);


        }

        private void btnFromShipmentAll_Click(object sender, EventArgs e)
        {
            LockChangeType(false);
        }

        private void btnFromShipment_Click(object sender, EventArgs e)
        {
            /*
            DataRow row = ds.Tables[0].NewRow(); 
            ds.Tables[0].Rows.Add(row);

            int currentRow = tblShipmentItem.CurrentCell.RowIndex;
            row[1] = tblShipmentItem.Rows[currentRow].Cells[0].Value;
            row[2] = tblShipmentItem.Rows[currentRow].Cells[1].Value;
            row[3] = tblShipmentItem.Rows[currentRow].Cells[2].Value;
            row[4] = tblShipmentItem.Rows[currentRow].Cells[3].Value;

            tblShipmentItem.Rows.Remove(tblShipmentItem.CurrentRow);
            */
            MoveRow(tblShipmentItem, tblOrders);
            if (tblShipmentItem.RowCount == 0)
                LockChangeType(false);
        }

        private void cmbDepositor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tblOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MoveRow(tblOrders, tblShipmentItem);
            LockChangeType(true);
        }
    }
}
