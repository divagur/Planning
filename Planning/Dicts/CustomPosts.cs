using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer = Planning.DataLayer;

namespace Planning
{
    public partial class CustomPosts : DictForm
    {
        List<DataLayer.CustomPost> _customPosts = new List<DataLayer.CustomPost>();
        DataLayer.CustomPostRepository _customPostRepository = new DataLayer.CustomPostRepository();
        public CustomPosts()
        {
            InitializeComponent();
        }
        private void UpdateDataSource()
        {
            tblCustomPosts.DataSource = null;
            tblCustomPosts.DataSource = _customPosts;
            tblCustomPosts.Refresh();
        }


        protected override void Populate()
        {
            tblCustomPosts.AutoGenerateColumns = false;
            //tblCustomPosts.DataSource = _context.CustomPosts.ToList();

            
            _customPosts = _customPostRepository.GetAll();
            tblCustomPosts.DataSource = _customPosts;
        }
        protected override void AddRow()
        {
            DataLayer.CustomPost customPost = new DataLayer.CustomPost();
            CustomPostEdit frmCustomPostEdit = new CustomPostEdit(customPost);
            frmCustomPostEdit.ShowDialog();
            if (frmCustomPostEdit.DialogResult == DialogResult.Cancel)
                return;
            _customPosts.Add(customPost);
            _customPostRepository.Save(customPost);
            UpdateDataSource();
            //DataService.context.CustomPosts.Add(customPost);

            //Save();
        }

        protected override void EditRow()
        {
            if (tblCustomPosts.SelectedCells.Count <= 0) return;
            DataLayer.CustomPost customPost = _customPosts.Find(cp=>cp.Id==Int32.Parse(tblCustomPosts.Rows[tblCustomPosts.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
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
