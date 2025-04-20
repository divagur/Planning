using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
    public partial class frmDelayReasonsEdit : Planning.DictEditForm
    {
        DataLayer.DelayReason _delayReason;

        public frmDelayReasonsEdit(DataLayer.DelayReason delayReason)
        {
            InitializeComponent();
            _delayReason = delayReason;
        }

        protected override bool Save()
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }    
               

            _delayReason.Name = txtName.Text;
            return true;
        }

        protected override void Populate()
        {
            txtName.Text = _delayReason.Name;
        }
    }
}
