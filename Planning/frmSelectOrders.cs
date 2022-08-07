using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class frmSelectOrders : Form
    {
        LVOrder_Manager Order_Manager = new LVOrder_Manager();
        PlanningDbContext _context;
        List<LVOrder> _listSelectedOrders;
        List<LVOrder> _listOrders;
        BindingList<LVOrder> bindingListSelectOrder;
        BindingSource sourceSelected;

        BindingList<LVOrder> bindingListOrder;
        BindingSource sourceOrder;
        public frmSelectOrders(List<LVOrder> listSelectedOrders)
        {
            InitializeComponent();
            _listSelectedOrders = listSelectedOrders;
            _context = DataService.context;
        }

        private void frmSelectOrders_Load(object sender, EventArgs e)
        {
            cmbDepositor.Items.Clear();
            foreach (var d in _context.Depositors.ToList())
                cmbDepositor.Items.Add(d.Name);


            if (cmbDepositor.Items.Count>0)
            {
                cmbDepositor.SelectedIndex = 0;
            }

            Populate(cmbDepositor.Text);

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchBy(true, r => tblOrders.Rows[r].Cells["colId"] != null && tblOrders.Rows[r].Cells["colId"].Value.ToString() == txtOrderId.Text);
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



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void MoveRow(DataGridView SourceTable, List<LVOrder> listSource, List<LVOrder> listTarged, string ColIdName)
        {

            for (int i = 0; i < SourceTable.SelectedRows.Count; i++)
            {

                LVOrder order = listSource.Find(r => r.LVCode == (string)SourceTable.SelectedRows[i].Cells[0].Value);
                listTarged.Add(order);

                listSource.Remove(order);

            }
            sourceSelected.ResetBindings(false);
            sourceOrder.ResetBindings(false);

        }

        private void btnToShipment_Click(object sender, EventArgs e)
        {
            


         
        }

        private void btnFromSelected_Click(object sender, EventArgs e)
        {
            MoveRow(tblSelectedOrders, _listSelectedOrders, _listOrders, "colSelOrderLVCode");
        }

        private void btnToSelected_Click(object sender, EventArgs e)
        {
            MoveRow(tblOrders, _listOrders, _listSelectedOrders, "colOrderLVCode");
        }

        private void cmbDepositor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Populate(cmbDepositor.Text);
        }

        private void Populate(string DepName)
        {
            int? DepositorLVId = DataService.GetDictIdByName("Депозиторы", DepName);
            _listOrders = Order_Manager.GetList(DepositorLVId, 0);

            if (_listSelectedOrders != null && _listSelectedOrders.Count > 0)
            {
                List<int> orderId = _listSelectedOrders.Select(i => i.LVID).ToList();

                _listOrders = _listOrders.Where(i => !orderId.Contains(i.LVID)).ToList();
            }


            tblSelectedOrders.AutoGenerateColumns = false;
            tblOrders.AutoGenerateColumns = false;


            bindingListOrder = new BindingList<LVOrder>(_listOrders);
            sourceOrder = new BindingSource(bindingListOrder, null);

            bindingListSelectOrder = new BindingList<LVOrder>(_listSelectedOrders);
            sourceSelected = new BindingSource(bindingListSelectOrder, null);


            tblOrders.DataSource = sourceOrder;
            tblSelectedOrders.DataSource = sourceSelected;
        }

        private void tblOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MoveRow(tblOrders, _listOrders, _listSelectedOrders, "colOrderLVCode");
        }

        private void tblSelectedOrders_DoubleClick(object sender, EventArgs e)
        {
            MoveRow(tblSelectedOrders, _listSelectedOrders, _listOrders, "colSelOrderLVCode");
        }
    }

   

}
