using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class SupplierEdit : Planning.DictEditForm
    {
        Supplier _supplier;
        public SupplierEdit(Supplier supplier)
        {
            InitializeComponent();
            _supplier = supplier;
        }


        protected override bool Save()
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            _supplier.Name = txtName.Text;
            _supplier.IsActive = cbIsActive.Checked;
            _supplier.Code = txtCode.Text;
            return true;
        }

        protected override void Populate()
        {
            txtName.Text = _supplier.Name;
            txtCode.Text = _supplier.Code;
            cbIsActive.Checked = _supplier.IsActive == null?true:(bool)_supplier.IsActive;
        }
    }

}

