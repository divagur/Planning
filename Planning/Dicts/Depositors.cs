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
    public partial class Depositors : DictFormEx<DataLayer.Depositor, DataLayer.DepositorRepository>
    {

        public Depositors()
        {
            InitializeComponent();
            GridView = tblDict;
        }
        protected override bool CreateEditForm(DataLayer.Depositor item)
        {
            var frmDepositorEdit = new DepositorEdit(item);

            frmDepositorEdit.ShowDialog();
            return !(frmDepositorEdit.DialogResult == DialogResult.Cancel);

        }

    }
}
