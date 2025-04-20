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
        DataLayer.DepositorAttribute _attr;
        int? _depId;
        List<string> _attrName;
        Dictionary<int?, string> LVAttr;
        Dictionary<int?, string> PLAttr;
       

        public LvAttrEdit(DataLayer.DepositorAttribute attr, int? DepId, List<string> attrName)
        {
            InitializeComponent();
            _attr = attr;
            _depId = DepId;
            _attrName = attrName;
            cmbAttrType.SelectedIndex = _attr.LvaIn == false ? 0 : 1;
        }


        private void GetAttr()
        {
            if (LVAttr == null)
                LVAttr = new Dictionary<int?, string>();

            if (PLAttr == null)
                PLAttr = new Dictionary<int?, string>();


            DataLayer.LvAttributeRepository lvAttributeRepository = new DataLayer.LvAttributeRepository();
            List<DataLayer.LvAttribute> lvAttributes = lvAttributeRepository.GetAll(_depId, _attr.LvaIn);

            foreach (var item in lvAttributes)
            {
                LVAttr.Add(item.Id, item.Name);
            }

            DataLayer.ShipmentElementRepository shipmentElementRepository = new DataLayer.ShipmentElementRepository();
            List<DataLayer.ShipmentElement> shipmentElements = shipmentElementRepository.GetAll();

            PLAttr.Clear();
            foreach (DataLayer.ShipmentElement se in shipmentElements)
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


        int? GetKeyByValue(Dictionary<int?, string> d, string value)
        {
            if (d.ContainsValue(value))
            {
                foreach (KeyValuePair<int?, string> kv in d)
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
            //_attr.LvaIn = false;
            _attr.LvaUseOrdAttr = false;
            _attr.PlDepId = _depId;

            _attrName[0] = cmbLVAttr.Text;
            _attrName[1] = cmbPLAttr.Text;
            _attrName[2] = cmbAttrType.Text;
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
            
            string value;
            if (LVAttr.TryGetValue(_attr.LvaAttrLvId ==null?0:(int)_attr.LvaAttrLvId, out value))
                cmbLVAttr.Text = value;
            if (PLAttr.TryGetValue(_attr.PlElemId == null?0:(int)_attr.PlElemId, out value))
            {
                cmbPLAttr.Text = value;
            } 
        }

        private void cmbAttrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _attr.LvaIn = cmbAttrType.SelectedIndex == 0 ? false : true;
            cmbLVAttr.Text = "";
            cmbPLAttr.Text = "";
            GetAttr();
        }
    }
}
