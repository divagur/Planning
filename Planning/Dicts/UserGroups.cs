using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class UserGroups : DictFormEx<DataLayer.UsersGroup, DataLayer.UsersGroupRepository>
    {
        
        public UserGroups()
        {
            InitializeComponent();
            GridView = tblUserGroup;
        }

        protected override bool CreateEditForm(DataLayer.UsersGroup item)
        {
            var frmUserGroupEdit = new UserGroupEdit(item);

            frmUserGroupEdit.ShowDialog();
            return !(frmUserGroupEdit.DialogResult == DialogResult.Cancel);

        }
       

    }
}
