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
    public partial class CustomPosts : DictFormEx<DataLayer.CustomPost, DataLayer.CustomPostRepository>
    {
        List<DataLayer.CustomPost> _customPosts = new List<DataLayer.CustomPost>();
        DataLayer.CustomPostRepository _customPostRepository = new DataLayer.CustomPostRepository();
        public CustomPosts()
        {
            InitializeComponent();
            GridView = tblCustomPosts;
        }

        protected override bool CreateEditForm(DataLayer.CustomPost item)
        {
            CustomPostEdit frmCustomPostEdit = new CustomPostEdit(item);

            frmCustomPostEdit.ShowDialog();
            return !(frmCustomPostEdit.DialogResult == DialogResult.Cancel);

        }

    }
}
