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
        Movement _movement;
        ShipmentParam _shipmentAddResult;

        private void LockChangeType(bool Lock)
        {
            
            cmbDepositor.Enabled = !Lock;
            cmbType.Enabled = !Lock;
            btnEdit.Enabled = Lock;
                
            
        }
        public ShipmentAdd(ShipmentParam shipmentAddResult)
        {
            InitializeComponent();
            _context = DataService.context;
            //_shipment = shipment;
            _shipmentAddResult = shipmentAddResult;
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


        private void PopulateOrders()
        {
            int? DepositorLVId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
            int? Type = cmbType.SelectedIndex < 2 ? (int?)cmbType.SelectedIndex : null;

            SqlHandle sql = new SqlHandle(DataService.connectionString);
            sql.SqlStatement = "sp_AddLoadingLVList";
            sql.Connect();
            sql.TypeCommand = CommandType.StoredProcedure;
            sql.IsResultSet = true;

            sql.AddCommandParametr(new SqlParameter { ParameterName = "@Split", Value = 0 });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@In", Value = Type });
            sql.AddCommandParametr(new SqlParameter { ParameterName = "@DepID", Value = DepositorLVId });


            bool success = sql.Execute();

            if (!success)
            {
                MessageBox.Show(sql.LastError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tblOrders.Rows.Clear();
            if (sql.HasRows())
            {
                foreach (DataRow sqlRow in sql.DataSet.Tables[0].Rows)
                {
                    int Row = tblOrders.Rows.Add();
                    //object[] readerVal = new object[reader.FieldCount];
                    //reader.GetValues(readerVal);
                    tblOrders.Rows[Row].Cells[0].Value = sqlRow.Field<string>(1);
                    tblOrders.Rows[Row].Cells[1].Value = sqlRow[7];
                    tblOrders.Rows[Row].Cells[2].Value = sqlRow.Field<string>(2);
                    tblOrders.Rows[Row].Cells[3].Value = !sqlRow.IsNull(3) ? sqlRow.Field<DateTime>(3).ToString().Substring(0, 10) : "";
                    tblOrders.Rows[Row].Cells[4].Value = sqlRow.Field<string>(4);
                    tblOrders.Rows[Row].Cells[5].Value = sqlRow.Field<int>(0);

                    tblOrders.Rows[Row].Cells[6].Value = sqlRow[6];
                    tblOrders.Rows[Row].Cells[7].Value = sqlRow[8];
                } 

            }
                
        }
        /*
        private void PopulateOrders()
        {
            int? DepositorLVId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
            int? Type = cmbType.SelectedIndex<2?(int?)cmbType.SelectedIndex: null;

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

                tblOrders.Rows.Clear();


                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    tblOrders.Rows.Clear();
                    while (reader.Read())
                    {
                        int Row = tblOrders.Rows.Add();
                        //object[] readerVal = new object[reader.FieldCount];
                        //reader.GetValues(readerVal);
                        tblOrders.Rows[Row].Cells[0].Value = reader.GetString(1);
                        tblOrders.Rows[Row].Cells[1].Value = reader.GetValue(7);
                        tblOrders.Rows[Row].Cells[2].Value = reader.GetString(2);

                        tblOrders.Rows[Row].Cells[3].Value = reader.GetSqlDateTime(3).ToString() != "Null" ? reader.GetSqlDateTime(3).ToString().Substring(0, 10) : "";
                        tblOrders.Rows[Row].Cells[4].Value = reader.GetString(4);
                        tblOrders.Rows[Row].Cells[5].Value = reader.GetInt32(0);

                        tblOrders.Rows[Row].Cells[6].Value = reader.GetValue(6);
                    }
                }
                
            }
        }
                */
        private void MoveRow(DataGridView TableSource, DataGridView TableTarged)
        {
            if (TableSource.RowCount <= 0) return;

            int CurrentRow = TableSource.CurrentCell.RowIndex;

            int tagetRow = TableTarged.Rows.Add();

            for(int i = 0; i< TableTarged.ColumnCount; i++)
            {
                TableTarged.Rows[tagetRow].Cells[i].Value = TableSource.Rows[CurrentRow].Cells[i].Value;
            }
            
            
              
            TableSource.Rows.Remove(TableSource.CurrentRow);
        }
        private void Save()
        {
            /*
            if (tblShipmentItem.RowCount == 0)
            {
                return;
            }
            */
            if (cmbType.SelectedIndex < 2)
            {
                _shipmentAddResult.IsShipment = true;

                _shipment = new Shipment();
                _shipment.SDate = dtSDate.Value;
                _shipment.ShIn = cmbType.Text == "Вход" ? true : false;
                _shipment.DepositorId = DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
                _shipment.TimeSlotId = DataService.GetDictIdByCondition("ТаймСлоты", $"depositor_id = {_shipment.DepositorId} and slot_time = '{cmbTimeSlot.Text}'");
                

                for (int i = 0; i < tblShipmentItem.RowCount; i++)
                {

                   // ShipmentOrder shipmentOrder;

                    var lvOrderId = int.Parse(tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value.ToString());
                    
                    ShipmentOrder shipmentOrder = _shipment.ShipmentOrders.FirstOrDefault(o => o.LVOrderId == lvOrderId);
                    if (shipmentOrder == null)
                    {
                        shipmentOrder = new ShipmentOrder();
                        shipmentOrder.OrderId = tblShipmentItem.Rows[i].Cells["colItemId"].Value.ToString();
                        shipmentOrder.LVOrderId = (int?)tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value;
                        shipmentOrder.lv_order_code = tblShipmentItem.Rows[i].Cells["colItemId"].Value.ToString();
                        shipmentOrder.IsEdm = !String.IsNullOrEmpty(tblShipmentItem.Rows[i].Cells["colItemIsEDM"].Value.ToString()) ?
                                (bool?)tblShipmentItem.Rows[i].Cells["colItemIsEDM"].Value : null;
                        shipmentOrder.IsBinding = true;
                        _shipment.ShipmentOrders.Add(shipmentOrder);
                    }
                    if (cmbType.SelectedIndex == 0)
                    {
                        _shipment.TransportViewId = GetTransportViewId(DataService.setting.DefaultTransportViewName);
                        _shipment.WarehouseId = GetWarehouseId(DataService.setting.DefaultWarehouseCode);

                        ShipmentOrderPart shipmentOrderPart = new ShipmentOrderPart();
                        shipmentOrderPart.OsLvCode = tblShipmentItem.Rows[i].Cells["colItemOstCode"].Value.ToString();
                        shipmentOrderPart.OsLvId = (tblShipmentItem.Rows[i].Cells["colItemOstId"].Value as int?);
                        shipmentOrderPart.IsBinding = true;
                        shipmentOrder.ShipmentOrderParts.Add(shipmentOrderPart);
                    }
                   
                }
                _shipment.IsAddLv = true;
                _shipmentAddResult.Result = _shipment;
                _context.Shipments.Add(_shipment);
            }
            else if (cmbType.SelectedIndex ==2)
            {
                _shipmentAddResult.IsShipment = false;
                _movement = new Movement();
                _movement.MDate = dtSDate.Value;
                _movement.TimeSlotId = DataService.GetDictIdByCondition("ТаймСлоты", $"depositor_id = {DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text)} and slot_time = '{cmbTimeSlot.Text}'");
                for (int i = 0; i < tblShipmentItem.RowCount; i++)
                {
                    MovementItem movementItem = new MovementItem();

                    movementItem.DepositorId = (int)DataService.GetDictIdByName("Депозиторы", cmbDepositor.Text);
                    movementItem.TklLVID = int.Parse(tblShipmentItem.Rows[i].Cells["colLVOrdId"].Value.ToString());
                    _movement.MovementItems.Add(movementItem);
                }
                _shipmentAddResult.Result = _movement;
                _context.Movements.Add(_movement);
            }
            _context.SaveChanges();

        }

        private int? GetWarehouseId(string WarehouseCode)
        {

            Warehouse warehouse = _context.Warehouses.FirstOrDefault(w => w.Code == WarehouseCode);

            return warehouse == null ? null : (int?)warehouse.Id;
        }

        private int? GetTransportViewId(string TransportViewName)
        {            
            TransportView transportView = _context.TransportViews.FirstOrDefault(tv=>tv.Name == TransportViewName);
            return transportView == null? null:(int?)transportView.Id;
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
            string type = "";
            switch (cmbType.SelectedIndex)
            {
                
                case 0:
                    type = "отгрузки";
                    break;
                case 1:
                    type = "поставки";
                    break;
                case 2:
                    type = "перемещения";
                    break;
                default:
                    break;
            }
            this.Text = "Создание " + type;
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

        private bool SearchBy(bool FromBegin, Predicate<int> condition)
        {
            int startRow = FromBegin ? 0 : tblOrders.CurrentRow.Index + 1;

            for (int i = startRow; i <= tblOrders.Rows.Count - 1; i++)
               if (condition(i))
                {

                    tblOrders.CurrentRow.Selected = false;
                    DataGridViewCell cell = tblOrders.Rows[i].Cells["colId"];
                    tblOrders.CurrentCell = cell;
                    tblOrders.Rows[i].Selected = true;

                    return true;
                }
            return false;

        }

        private void btnFromShipmentAll_Click(object sender, EventArgs e)
        {

            if (tblShipmentItem.RowCount > 0)
            {
                int i = 0;
                while (tblShipmentItem.RowCount>0)
                {
                    tblShipmentItem.Rows[0].Selected = true;
                    MoveRow(tblShipmentItem, tblOrders);
                    i++;
                }

            } 


            LockChangeType(false);
            //LockChangeType(false);
        }

        private void btnFromShipment_Click(object sender, EventArgs e)
        {

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

        private void cmbTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchBy(true, r => tblOrders.Rows[r].Cells["colId"] != null && tblOrders.Rows[r].Cells["colId"].Value.ToString() == txtOrderId.Text);
        }

        private void tblOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtOrderId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }

        private void ShipmentAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
        }
    }
}
