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
        Dictionary<int, string> LVAttr;
        Dictionary<int, string> PLAttr;
        PlanningDbContext _context;
        Depositor _depositor;

        public DepositorEdit(Depositor depositor)
        {
            InitializeComponent();
            _context = DataService.context;
            _depositor = depositor;
        }

        private void GetAttr()
        {
            if (edDB.Text == "") return;

            if (LVAttr == null)
                LVAttr = new Dictionary<int, string>();

            if (PLAttr == null)
                PLAttr = new Dictionary<int, string>();


            using (SqlConnection connection = new SqlConnection(DataService.connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string sqlText = "sp_LVAttrList";

                SqlCommand command = new SqlCommand(sqlText, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@LVBase",Value = edDB.Text});


                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    LVAttr.Clear();
                    while (reader.Read())
                    {
                        LVAttr.Add(reader.GetInt32(0), reader.GetString(1));

                    }
                }
                
            }
            PLAttr.Clear();
            foreach(ShipmentElement se in _context.ShipmentElements.ToList())
            {
                PLAttr.Add(se.Id, se.FieldName);
            }

            LVAttrId.Items.Clear();
            foreach (string value in LVAttr.Values)
                LVAttrId.Items.Add(value);
            PLField.Items.Clear();
            foreach(string value in PLAttr.Values)
                PLField.Items.Add(value);

        }

        private void DepositorLoad()
        {
           
            edName.Text = _depositor.Name;
            edDB.Text = _depositor.lv_base;
            edLvId.Text = _depositor.lv_id.ToString();
            GetAttr();

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
            _depositor.lv_base = edDB.Text;
            _depositor.lv_id = Int32.Parse(edLvId.Text);

            DialogResult = DialogResult.OK;
        }

        private void tblAttr_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
