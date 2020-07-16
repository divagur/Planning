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
   
    public partial class ShipmentElements : DictForm
    {
        public ShipmentElements()
        {
            InitializeComponent();
        }

        protected override void AddRow()
        {
            ShipmentElement shipmentElement = new ShipmentElement();
            var frmShipmentElementEdit = new ShipmentElementEdit(shipmentElement);

            frmShipmentElementEdit.ShowDialog();
            if (frmShipmentElementEdit.DialogResult == DialogResult.Cancel)
                return;
            _context.ShipmentElements.Add(shipmentElement);
            Save();
        }

        protected override void EditRow()
        {
            ShipmentElement shipmentElement = _context.ShipmentElements.Find(tblElements.Rows[tblElements.CurrentCell.RowIndex].Cells["colId"].Value);
            var frmTimeSlotEdit = new ShipmentElementEdit(shipmentElement);

            frmTimeSlotEdit.ShowDialog();
            if (frmTimeSlotEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        protected override void DelRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ShipmentElement shipmentElement = _context.ShipmentElements.Find(tblElements.Rows[tblElements.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.ShipmentElements.Remove(shipmentElement);
                Save();
            }
        }

        protected override void Populate()
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
        /*
        protected override void Save()
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
        */
       
    }



}
