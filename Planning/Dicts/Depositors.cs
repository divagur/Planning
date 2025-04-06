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

        void CreateEdtiForm(Depositor depositor, bool isNew)
        {
            var frmDepositorEdit = new DepositorEdit(depositor);

            frmDepositorEdit.ShowDialog();
            if (frmDepositorEdit.DialogResult == DialogResult.Cancel)
                return;
            if (isNew)
                DataService.context.Depositors.Add(depositor);
            Save();
        }

        protected override void AddRow()
        {
            Depositor depositor = new Depositor();
            CreateEdtiForm(depositor, true);
           
        }

        protected override void Populate()
        {     
            //tblDict.DataSource = _context.Depositors.ToList<Depositor>();
            tblDict.AutoGenerateColumns = false;
            _depositors = _depositorRepository.GetAll();
            tblDict.DataSource = _depositors;
        }

        protected override void EditRow()
        {
            Depositor depositor = _context.Depositors.Find(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value);
            CreateEdtiForm(depositor, false);
        }

        protected override void DelRow()
        {
            if (MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Depositor depositor = _context.Depositors.Find(tblDict.Rows[tblDict.CurrentCell.RowIndex].Cells["colId"].Value);
                _context.Depositors.Remove(depositor);
                Save();
            }
        }

    }
}
