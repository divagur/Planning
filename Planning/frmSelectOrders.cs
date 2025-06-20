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
using Planning.DataLayer;

namespace Planning
{
    public partial class frmSelectOrders : Form
    {
        LvSelectOrderRepository LvSelectOrderRepository = new LvSelectOrderRepository();
        List<LvSelectOrder> _listSelectedOrders;
        List<LvSelectOrder> _listOrders;
        BindingList<LvSelectOrder> bindingListSelectOrder;
        BindingSource sourceSelected;

        BindingList<LvSelectOrder> bindingListOrder;
        BindingSource sourceOrder;
        public frmSelectOrders(List<LvSelectOrder> listSelectedOrders)
        {
            InitializeComponent();
            _listSelectedOrders = listSelectedOrders;
        }

        private void frmSelectOrders_Load(object sender, EventArgs e)
        {
            DepositorRepository depositorRepository = new DepositorRepository();
            List<Depositor> depositors = depositorRepository.GetAll();

            cmbDepositor.Items.Clear();
            foreach (var d in depositors)
            {
                cmbDepositor.Items.Add(d);
            }
            cmbDepositor.SelectedIndex = 0;


            if (cmbDepositor.Items.Count>0)
            {
                cmbDepositor.SelectedIndex = 0;
            }
            int? depositorId = GetSelectedDepositorId();
            Populate(depositorId);

        }
        private int? GetSelectedDepositorId()
        {
            return cmbDepositor.SelectedItem != null ? ((Depositor)cmbDepositor.SelectedItem).Id : null;
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


        private void MoveRow(DataGridView SourceTable, List<LvSelectOrder> listSource, List<LvSelectOrder> listTarged, string ColIdName)
        {

            for (int i = 0; i < SourceTable.SelectedRows.Count; i++)
            {

                LvSelectOrder order = listSource.Find(r => r.LVCode == (string)SourceTable.SelectedRows[i].Cells[0].Value);
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
            int? depositorId = GetSelectedDepositorId();
            Populate(depositorId);
        }

        private void Populate(int? DepositorId)
        {
           
            _listOrders = LvSelectOrderRepository.GetAll(0,DepositorId,0,null,0 );


            if (_listSelectedOrders != null && _listSelectedOrders.Count > 0)
            {
                List<int?> orderId = _listSelectedOrders.Select(i => i.Id).ToList();

                _listOrders = _listOrders.Where(i => !orderId.Contains(i.Id)).ToList();
            }


            tblSelectedOrders.AutoGenerateColumns = false;
            tblOrders.AutoGenerateColumns = false;


            bindingListOrder = new BindingList<LvSelectOrder>(_listOrders);
            sourceOrder = new BindingSource(bindingListOrder, null);

            bindingListSelectOrder = new BindingList<LvSelectOrder>(_listSelectedOrders);
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
