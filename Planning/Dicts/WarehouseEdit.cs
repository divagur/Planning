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
    public partial class WarehouseEdit : DictEditForm
    {
        Warehouse _warehouse;
        public WarehouseEdit(Warehouse warehouse)
        {
            InitializeComponent();
            _warehouse = warehouse;
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

            _warehouse.Code = txtCode.Text;
            _warehouse.Name = txtName.Text;
            _warehouse.Descr = txtDescr.Text;
            return true;
        }

        protected override void Populate()
        {
            txtCode.Text = _warehouse.Code;
            txtName.Text = _warehouse.Name;
            txtDescr.Text = _warehouse.Descr;
        }
    }
}
