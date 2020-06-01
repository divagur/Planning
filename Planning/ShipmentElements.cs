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
   
    public partial class ShipmentElements : Form
    {
        PlanningDbContext _context;
        public ShipmentElements()
        {
            InitializeComponent();
            _context = DataService.context;
        }

        private void ShipmentElementsLoad()
        {
            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string sqlText = @"select id,field_name, field_db_name,field_type,field_type_name
                                    from v_shipment_elements";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tblElements.AutoGenerateColumns = false;
                tblElements.DataSource = ds.Tables[0];
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

            ShipmentElementsLoad();
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            ShipmentElement shipmentElement = new ShipmentElement();
            var frmShipmentElementEdit = new ShipmentElementEdit(shipmentElement);

            frmShipmentElementEdit.ShowDialog();
            if (frmShipmentElementEdit.DialogResult == DialogResult.Cancel)
                return;
            _context.ShipmentElements.Add(shipmentElement);
            Save();
        }

        private void ShipmentElements_Load(object sender, EventArgs e)
        {
            ShipmentElementsLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShipmentElement shipmentElement = _context.ShipmentElements.Find(tblElements.Rows[tblElements.CurrentCell.RowIndex].Cells["colId"].Value);
            var frmTimeSlotEdit = new ShipmentElementEdit(shipmentElement);

            frmTimeSlotEdit.ShowDialog();
            if (frmTimeSlotEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ShipmentElement shipmentElement = _context.ShipmentElements.Find(tblElements.Rows[tblElements.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.ShipmentElements.Remove(shipmentElement);
                Save();
            }
        }
    }



}
