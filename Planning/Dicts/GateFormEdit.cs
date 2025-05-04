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
    public partial class GateFormEdit : DictEditForm
    {
        DataLayer.Gateway _gateway;
        public GateFormEdit(DataLayer.Gateway gateway)
        {
            InitializeComponent();
            _gateway = gateway;
        }

        protected override void Populate()
        {
            txtGateNumber.Text = _gateway.Name;
        }

        protected override bool Save()
        {
            if (txtGateNumber.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым номером ворот", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _gateway.Name = txtGateNumber.Text;
            return true;
        }
    }
}
