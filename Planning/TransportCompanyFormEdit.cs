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
    public partial class TransportCompanyFormEdit : DictEditForm
    {
        DataLayer.TransportCompany _transportCompany;
        public TransportCompanyFormEdit(DataLayer.TransportCompany transportCompany)
        {
            InitializeComponent();
            _transportCompany = transportCompany;
        }

        protected override void Populate()
        {
            txtCode.Text = _transportCompany.Code.ToString();
            txtName.Text = _transportCompany.Name;
            cbIsActive.Checked = (bool)_transportCompany.IsActive;
        }

        protected override bool Save()
        {
            if (txtCode.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым кодом", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _transportCompany.Code = Int32.Parse(txtCode.Text);
            _transportCompany.Name = txtName.Text;
            _transportCompany.IsActive = cbIsActive.Checked;

            return true;
        }
    }
}
