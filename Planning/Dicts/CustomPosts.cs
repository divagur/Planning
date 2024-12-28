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
    public partial class CustomPosts : DictForm
    {
        public CustomPosts()
        {
            InitializeComponent();
        }
        protected override void Populate()
        {
            tblCustomPosts.AutoGenerateColumns = false;
            tblCustomPosts.DataSource = _context.CustomPosts.ToList();
        }
        protected override void AddRow()
        {
            CustomPost customPost = new CustomPost();
            CustomPostEdit frmCustomPostEdit = new CustomPostEdit(customPost);
            frmCustomPostEdit.ShowDialog();
            if (frmCustomPostEdit.DialogResult == DialogResult.Cancel)
                return;
            DataService.context.CustomPosts.Add(customPost);

            Save();
        }

        protected override void EditRow()
        {
            if (tblCustomPosts.SelectedCells.Count <= 0) return;
            CustomPost customPost = _context.CustomPosts.Find(tblCustomPosts.Rows[tblCustomPosts.CurrentCell.RowIndex].Cells["colId"].Value);
            CustomPostEdit frmCustomPostEdit = new CustomPostEdit(customPost);
            frmCustomPostEdit.ShowDialog();
            if (frmCustomPostEdit.DialogResult == DialogResult.Cancel)
                return;

            Save();
        }
        protected override void DelRow()
        {
            CustomPost customPost = _context.CustomPosts.Find(tblCustomPosts.Rows[tblCustomPosts.CurrentCell.RowIndex].Cells["colId"].Value);
            if (MessageBox.Show("Удалить склад?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _context.CustomPosts.Remove(customPost);
                Save();
            }
        }
    }
}
