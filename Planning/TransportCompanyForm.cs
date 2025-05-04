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
    public partial class TransportCompanyForm : DictFormEx<DataLayer.TransportCompany, DataLayer.TransportCompanyRepository>
    {
        public TransportCompanyForm()
        {
            InitializeComponent();
            GridView = tblTransportCompany;
        }

        protected override bool CreateEditForm(DataLayer.TransportCompany item)
        {
            TransportCompanyFormEdit frmTransportCompanyEdit = new TransportCompanyFormEdit(item);
            frmTransportCompanyEdit.ShowDialog();
            return !(frmTransportCompanyEdit.DialogResult == DialogResult.Cancel);

        }
    }
}
