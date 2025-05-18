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
	public partial class Users :DictFormEx<DataLayer.User, DataLayer.UserRepository>
	{

		public Users()
		{
			InitializeComponent();
            GridView = tblUsers;
		}
        protected override bool CreateEditForm(DataLayer.User item)
        {
            var frmUserEdit = new UserEdit(item);
            frmUserEdit.ShowDialog();
            return !(frmUserEdit.DialogResult == DialogResult.Cancel);
        }
        
    }
}
