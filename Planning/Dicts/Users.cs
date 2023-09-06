using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Planning
{
	public partial class Users : Planning.DictForm
	{

		public Users()
		{
			InitializeComponent();
            
		}

        protected override void Populate()
        {
            tblUsers.AutoGenerateColumns = false;
            tblUsers.DataSource = _context.Users.ToList();
        }

        protected override void AddRow()
        {
            User user = new User();
            var frmUserEdit = new UserEditEx(user, true);

            frmUserEdit.ShowDialog();
            if (frmUserEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.Users.Add(user);


            Save();
        }

        protected override void EditRow()
        {
            if (tblUsers.SelectedCells.Count <= 0) return;
            User user = _context.Users.Find(tblUsers.Rows[tblUsers.CurrentCell.RowIndex].Cells["colId"].Value);
            var frmUserEdit = new UserEditEx(user,false);
            
            frmUserEdit.ShowDialog();
            if (frmUserEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        protected override void DelRow()
        {
            User user = _context.Users.Find(tblUsers.Rows[tblUsers.CurrentCell.RowIndex].Cells["colId"].Value);
            if (MessageBox.Show("Удалить пользователя?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (!DataService.DropUser(user.Login))
                    return;

                _context.Users.Remove(user);
                Save();
            }
        }
    }
}
