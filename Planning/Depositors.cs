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
    public partial class Depositors : Form
    {
        PlanningDbContext _context;
        public Depositors()
        {
            InitializeComponent();
            _context = DataService.context;
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

        public void AddRow()
        {
            Depositor depositor = new Depositor();
            CreateEdtiForm(depositor, true);
        }

        public void Populate()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string sqlText = @"select id, name, lv_base, lv_id
                                    from depositors";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tblDict.AutoGenerateColumns = false;
                tblDict.DataSource = ds.Tables[0];
            }
        }

        public void EditRow()
        {
            Depositor depositor = _context.Depositors.Find(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value);
            CreateEdtiForm(depositor, false);
        }

        public void DeleteRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Depositor depositor = _context.Depositors.Find(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.Depositors.Remove(depositor);
                Save();
            }
        }

        private void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorText = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    errorText = errorText + "Object: " + validationError.Entry.Entity.ToString() + "\n\r";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        errorText = errorText + err.ErrorMessage + "\n\r";

                    }
                }
                MessageBox.Show(errorText);
            }

            Populate();
        }

        private void Depositors_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRow();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }
    }
}
