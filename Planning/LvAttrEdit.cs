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
    public partial class LvAttrEdit : Form
    {
        LvAttr _attr;
        int _depId;
        List<string> _attrName;
        PlanningDbContext _context;
        Dictionary<int, string> LVAttr;
        Dictionary<int, string> PLAttr;
       

        public LvAttrEdit(LvAttr attr, int DepId, List<string> attrName)
        {
            InitializeComponent();
            _attr = attr;
            _depId = DepId;
            _context = DataService.context;
            _attrName = attrName;
        }


        private void GetAttr()
        {
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

                command.Parameters.Add(new SqlParameter { ParameterName = "@DepId", Value = _depId });


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
            foreach (ShipmentElement se in _context.ShipmentElements.ToList())
            {
                PLAttr.Add(se.Id, se.FieldName);
            }

            cmbLVAttr.Items.Clear();
            foreach (string value in LVAttr.Values)
                cmbLVAttr.Items.Add(value);
            cmbPLAttr.Items.Clear();
            foreach (string value in PLAttr.Values)
                cmbPLAttr.Items.Add(value);

        }


        int? GetKeyByValue(Dictionary<int, string> d, string value)
        {
            if (d.ContainsValue(value))
            {
                foreach (KeyValuePair<int, string> kv in d)
                {
                    if (kv.Value == value)
                    {
                        return kv.Key;
                    }
                }
            }
            return null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _attr.LvaAttrLvId = GetKeyByValue(LVAttr, cmbLVAttr.Text);
            _attr.PlElemId = GetKeyByValue(PLAttr, cmbPLAttr.Text);
            _attr.LvaIn = false;
            _attr.LvaUseOrdAttr = false;
            _attr.PlDepId = _depId;

            _attrName[0] = cmbLVAttr.Text;
            _attrName[1] = cmbPLAttr.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LvAttrEdit_Load(object sender, EventArgs e)
        {
            GetAttr();
            string value;
            if (LVAttr.TryGetValue(_attr.LvaAttrLvId ==null?0:(int)_attr.LvaAttrLvId, out value))
                cmbLVAttr.Text = value;
            if (PLAttr.TryGetValue(_attr.PlElemId == null?0:(int)_attr.PlElemId, out value))
            {
                cmbPLAttr.Text = value;
            } 
        }
    }
}
