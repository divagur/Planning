using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planning
{
    public partial class UserGroups : DictForm
    {
        
        public UserGroups()
        {
            InitializeComponent();
            
        }


        protected override void Populate()
        {
            tblUserGroup.AutoGenerateColumns = false;
            tblUserGroup.DataSource=  _context.UserGroups.ToList();
        }

        protected override void AddRow()
        {
            UserGroup userGroup = new UserGroup();
            var frmUserGroupEdit = new UserGroupEdit(userGroup);

            frmUserGroupEdit.ShowDialog();
            if (frmUserGroupEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.UserGroups.Add(userGroup);


            Save();
        }

        protected override void EditRow()
        {
            UserGroup userGroup = _context.UserGroups.Find(tblUserGroup.Rows[tblUserGroup.CurrentCell.RowIndex].Cells["colId"].Value);
            var frmUserGroupEdit = new UserGroupEdit(userGroup);

            frmUserGroupEdit.ShowDialog();
            if (frmUserGroupEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }

        protected override void DelRow()
        {
            UserGroup userGroup = _context.UserGroups.Find(tblUserGroup.Rows[tblUserGroup.CurrentCell.RowIndex].Cells["colId"].Value);
            if (MessageBox.Show("Удалить группу?", "Подтверждение",MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
            {
                _context.UserGroups.Remove(userGroup);
                Save();
            }
        }

    }
}
