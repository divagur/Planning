using Planning.DataLayer;
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
    public partial class TransportTypeForm : DictFormEx<TransportType, TransportTypeRepository>
    {
        public TransportTypeForm()
        {
            InitializeComponent();
            GridView = tblTransportType;
        }

        protected override bool CreateEditForm(DataLayer.TransportType item)
        {
            
            TransportTypeFormEdit frmWTransportTypeEdit = new TransportTypeFormEdit(item);
            frmWTransportTypeEdit.ShowDialog();
            return !(frmWTransportTypeEdit.DialogResult == DialogResult.Cancel);
        }
    }
}
