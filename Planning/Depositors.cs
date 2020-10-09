using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class Depositors : DictForm
    {
        public Depositors()
        {
            InitializeComponent();
            tblDict.AutoGenerateColumns = false;
        }

        void CreateEdtiForm(Depositor depositor, bool isNew)
        {
            var frmDepositorEdit = new DepositorEdit(depositor);

            frmDepositorEdit.ShowDialog();
            if (frmDepositorEdit.DialogResult == DialogResult.Cancel)
                return;
            if (isNew)
                DataService.context.Depositors.Add(depositor);
            Save();
        }

        protected override void AddRow()
        {
            Depositor depositor = new Depositor();
            CreateEdtiForm(depositor, true);
        }

        protected override void Populate()
        {

            WaitBegin();
           // Cursor = Cursors.AppStarting;
            tblDict.DataSource = _context.Depositors.ToList<Depositor>();
            WaitEnd();
            //Cursor = Cursors.Default;

            /*
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string sqlText = @"select id, name, lv_base, lv_id
                                    from depositors";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                
                tblDict.DataSource = ds.Tables[0];
            }
            */
        }

        protected override void EditRow()
        {
            Depositor depositor = _context.Depositors.Find(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value);
            CreateEdtiForm(depositor, false);
        }

        protected override void DelRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Depositor depositor = _context.Depositors.Find(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.Depositors.Remove(depositor);
                Save();
            }
        }

    }
}
