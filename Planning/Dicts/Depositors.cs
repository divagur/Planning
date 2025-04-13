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
    public partial class Depositors : DictForm
    {
        List<DataLayer.Depositor> _depositors = new List<DataLayer.Depositor>();
        DataLayer.DepositorRepository _depositorRepository = new DataLayer.DepositorRepository();
        public Depositors()
        {
            InitializeComponent();
            tblDict.AutoGenerateColumns = false;
        }
        private void UpdateDataSource()
        {
            tblDict.DataSource = null;
            tblDict.DataSource = _depositors;
            tblDict.Refresh();
        }
        void CreateEdtiForm(DataLayer.Depositor depositor, bool isNew)
        {
            var frmDepositorEdit = new DepositorEdit(depositor);

            frmDepositorEdit.ShowDialog();
            if (frmDepositorEdit.DialogResult == DialogResult.Cancel)
                return;
            if (isNew)
                _depositors.Add(depositor);
            _depositorRepository.Save(depositor);
            UpdateDataSource();
            
        }

        protected override void AddRow()
        {
            DataLayer.Depositor depositor = new DataLayer.Depositor();
            CreateEdtiForm(depositor, true);
           
        }

        protected override void Populate()
        {     
            //tblDict.DataSource = _context.Depositors.ToList<Depositor>();
            tblDict.AutoGenerateColumns = false;
            _depositors = _depositorRepository.GetAll();
            tblDict.DataSource = _depositors;
        }

        private DataLayer.Depositor GetCurrentRowObject()
        {
            return _depositors.Find(d => d.Id == Int32.Parse(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
        }
        protected override void EditRow()
        {
            DataLayer.Depositor depositor = GetCurrentRowObject();
            CreateEdtiForm(depositor, false);
        }

        protected override void DelRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DataLayer.Depositor depositor = GetCurrentRowObject();
                depositor.Delete();
                _depositorRepository.Save(depositor);
                UpdateDataSource();
            }
        }

    }
}
