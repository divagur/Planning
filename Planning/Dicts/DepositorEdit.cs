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
    public partial class DepositorEdit : Form
    {
        DataLayer.Depositor _depositor;
        List<DataLayer.PLAttribute> pLAttributeList;
        List<DataLayer.DepositorAttribute> depositorAttributes;
        DataLayer.DepositorAttributeRepository depositorAttributeRepository;
        public DepositorEdit(DataLayer.Depositor depositor)
        {
            InitializeComponent();
            _depositor = depositor;
            depositorAttributeRepository = new DataLayer.DepositorAttributeRepository();
        }
        void UpdateTblAttrDataSource()
        {
            tblAttrShipment.DataSource = null;
            tblAttrShipment.DataSource = pLAttributeList;
            tblAttrShipment.Refresh();
        }
        void PopulateAttr()
        {
            depositorAttributes = depositorAttributeRepository.GetAll();
            try
            {
                DataLayer.PLAttributeRepository pLAttributeRepository = new DataLayer.PLAttributeRepository();
                pLAttributeList = pLAttributeRepository.GetAll(_depositor.Id);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ошибка при получении атрибутов:{ex.Message}");
            }
           

   
            UpdateTblAttrDataSource();

        }

        private DataLayer.DepositorAttribute GetSelectedObject()
        {
            return depositorAttributes.Find(t => t.Id == Int32.Parse(tblAttrShipment.Rows[tblAttrShipment.CurrentCell.RowIndex].Cells["Id"].Value.ToString()));
        }

        private void DepositorLoad()
        {
           
            edName.Text = _depositor.Name;
            edDB.Text = _depositor.LvBase;
            edLvId.Text = _depositor.LvId.ToString();
            PopulateAttr();

             

        }
        private void DepositorEdit_Load(object sender, EventArgs e)
        {
            DepositorLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _depositor.Name = edName.Text;
            _depositor.LvBase = edDB.Text;
            _depositor.LvId = Int32.Parse(edLvId.Text);
            DialogResult = DialogResult.OK;
        }

        void CreateEdtiForm(DataLayer.DepositorAttribute attr)
        {
            List<string> attrName = new List<string>(3);
            attrName.Add("");
            attrName.Add("");
            attrName.Add("");
            var frmAttrEdit = new LvAttrEdit(attr, _depositor.Id, attrName);

            
            frmAttrEdit.ShowDialog();
            if (frmAttrEdit.DialogResult == DialogResult.Cancel)
                return;

            depositorAttributeRepository.Save(attr);
            PopulateAttr();

        }

        private void tblAttr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataLayer.DepositorAttribute attr = new DataLayer.DepositorAttribute();
            CreateEdtiForm(attr);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataLayer.DepositorAttribute attr = GetSelectedObject();
            CreateEdtiForm(attr);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataLayer.DepositorAttribute attr = GetSelectedObject();

                attr?.Delete();
                depositorAttributeRepository.Save(attr);
                PopulateAttr();


            }
        }

    }
}
