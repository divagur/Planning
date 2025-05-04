using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class GateForm : DictFormEx<DataLayer.Gateway, DataLayer.GatewayRepository>
    {
        public GateForm()
        {
            InitializeComponent();
            GridView = tblGates;
        }

        protected override bool CreateEditForm(DataLayer.Gateway item)
        {
            GateFormEdit frmGateFormEdit = new GateFormEdit(item);
            frmGateFormEdit.ShowDialog();
            return !(frmGateFormEdit.DialogResult == DialogResult.Cancel);
        }
    }
}
