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
    public partial class TransportViewFormEdit : DictEditForm
    {
        TransportView _transportView;
        public TransportViewFormEdit(TransportView transportView)
        {
            InitializeComponent();
            _transportView = transportView;
        }

        protected override void Populate()
        {
            txtName.Text = _transportView.Name;
        }
        protected override bool Save()
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Невозможно сохранить строку с пустым наименованием", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _transportView.Name = txtName.Text;
            return true;
        }
    }
}
