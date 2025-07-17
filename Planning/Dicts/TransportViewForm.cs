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
    public partial class TransportViewForm : DictFormEx<TransportView, TransportViewRepository>
    {
        public TransportViewForm()
        {
            InitializeComponent();
            GridView = tblTransportView;
        }

        protected override bool CreateEditForm(TransportView item)
        {

            TransportViewFormEdit frmWTransportViewEdit = new TransportViewFormEdit(item);
            frmWTransportViewEdit.ShowDialog();
            return !(frmWTransportViewEdit.DialogResult == DialogResult.Cancel);
        }
    }
}
