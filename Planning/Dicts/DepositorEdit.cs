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
    public partial class DepositorEdit : Form
    {
        DataLayer.Depositor _depositor;

        public DepositorEdit(DataLayer.Depositor depositor)
        {
            InitializeComponent();
            _depositor = depositor;
        }
      
        void PopulateAttr()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string sqlText = "sp_PLAttrList";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@DepId", Value = _depositor.Id });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    tblAttrShipment.Rows.Clear();
                    while (reader.Read())
                    {
                        int Row = tblAttrShipment.Rows.Add();
                        tblAttrShipment.Rows[Row].Cells["Id"].Value = reader.GetInt32(0);
                        tblAttrShipment.Rows[Row].Cells["LVAttrName"].Value = reader.GetString(2);
                        tblAttrShipment.Rows[Row].Cells["PLField"].Value = reader.GetString(4);
                        tblAttrShipment.Rows[Row].Cells["LvType"].Value = reader.GetString(6);

                    }
                }

            }
        }

        private void DepositorLoad()
        {
           
            edName.Text = _depositor.Name;
            edDB.Text = _depositor.LvBase;
            edLvId.Text = _depositor.LvId.ToString();
            PopulateAttr();

             

        }
        private void DepositorEdit_Load(object sender, EventArgs e)
        {
            DepositorLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _depositor.Name = edName.Text;
            _depositor.LvBase = edDB.Text;
            _depositor.LvId = Int32.Parse(edLvId.Text);
            DialogResult = DialogResult.OK;
        }

        void CreateEdtiForm(LvAttr attr, bool isNew)
        {
            List<string> attrName = new List<string>(3);
            attrName.Add("");
            attrName.Add("");
            attrName.Add("");
            var frmAttrEdit = new LvAttrEdit(attr, _depositor.Id, attrName);
            int rowIdx;
            
            frmAttrEdit.ShowDialog();
            if (frmAttrEdit.DialogResult == DialogResult.Cancel)
                return;
            if (isNew)
            {
                _context.LvAttrs.Add(attr);
                rowIdx = tblAttrShipment.Rows.Add();
            }
            else
            {
                rowIdx = tblAttrShipment.CurrentRow.Index;
            }

            tblAttrShipment.Rows[rowIdx].Cells["Id"].Value = attr.Id;
            tblAttrShipment.Rows[rowIdx].Cells["LVAttrName"].Value = attrName[0];
            tblAttrShipment.Rows[rowIdx].Cells["PLField"].Value = attrName[1];
            tblAttrShipment.Rows[rowIdx].Cells["LvType"].Value = attrName[2];

        }

        private void tblAttr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LvAttr attr = new LvAttr();
            CreateEdtiForm(attr, true);
            //PopulateAttr();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LvAttr attr = _context.LvAttrs.Find(tblAttrShipment.Rows[tblAttrShipment.CurrentCell.RowIndex].Cells["Id"].Value);
            CreateEdtiForm(attr, false);
           // PopulateAttr();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                LvAttr attr = _context.LvAttrs.Find(tblAttrShipment.Rows[tblAttrShipment.CurrentCell.RowIndex].Cells["Id"].Value);
                _context.LvAttrs.Remove(attr);
                PopulateAttr();


            }
        }

    }
}
