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
        PlanningDbContext _context;
        Depositor _depositor;

        public DepositorEdit(Depositor depositor)
        {
            InitializeComponent();
            _context = DataService.context;
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

                /*
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tblAttr.AutoGenerateColumns = false;
                tblAttr.DataSource = ds.Tables[0];
                */
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    tblAttr.Rows.Clear();
                    while (reader.Read())
                    {
                        int Row = tblAttr.Rows.Add();
                        tblAttr.Rows[Row].Cells["Id"].Value = reader.GetInt32(0);
                        tblAttr.Rows[Row].Cells["LVAttrName"].Value = reader.GetString(2);
                        tblAttr.Rows[Row].Cells["PLField"].Value = reader.GetString(4);

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
            List<string> attrName = new List<string>(2);
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
                rowIdx = tblAttr.Rows.Add();
            }
            else
            {
                rowIdx = tblAttr.CurrentRow.Index;
            }

            tblAttr.Rows[rowIdx].Cells["Id"].Value = attr.Id;
            tblAttr.Rows[rowIdx].Cells["LVAttrName"].Value = attrName[0];
            tblAttr.Rows[rowIdx].Cells["PLField"].Value = attrName[1];

            
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
            LvAttr attr = _context.LvAttrs.Find(tblAttr.Rows[tblAttr.CurrentCell.RowIndex].Cells["Id"].Value);
            CreateEdtiForm(attr, false);
           // PopulateAttr();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                LvAttr attr = _context.LvAttrs.Find(tblAttr.Rows[tblAttr.CurrentCell.RowIndex].Cells["Id"].Value);
                _context.LvAttrs.Remove(attr);
                PopulateAttr();


            }
        }

        private void tblAttr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
