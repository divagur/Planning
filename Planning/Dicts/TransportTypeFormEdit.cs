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
    public partial class TransportTypeFormEdit : Planning.DictEditForm
    {
        DataLayer.TransportType _transportType;
        public TransportTypeFormEdit(DataLayer.TransportType transportType)
        {
            InitializeComponent();
            _transportType = transportType;
        }

        protected override void Populate()
        {
            txtName.Text = _transportType.Name;
            txtTonnage.Text = _transportType.Tonnage.ToString();
        }
        protected override bool Save()
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _transportType.Name = txtName.Text;
            _transportType.Tonnage = Int32.Parse(txtTonnage.Text);
            return true;
        }
    }
}
