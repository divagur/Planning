using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Planning.Kernel;

namespace Planning
{
    public partial class DictForm : Form
    {
        protected PlanningDbContext _context;
        protected List<BaseDataItem> _dataSource;     

        private IWait waitHandler;

        internal IWait WaitHandler { get => waitHandler; set => waitHandler = value; }
        
        public DictForm()
        {
            InitializeComponent();
            DataService.InitContext();
            _context = DataService.context;
        }

        public void SetPrivilege(bool IsAppend, bool IsEdit, bool IsDelete)
        {
            btnAddRow.Enabled = IsAppend;
            btnEdit.Enabled = IsEdit;
            btnDelRow.Enabled = IsDelete;
            btnSave.Enabled = IsAppend || IsEdit || IsDelete;
        }

        protected virtual void AddRow()
        {

        }

        protected virtual void EditRow()
        {

        }

        protected virtual void DelRow()
        {

        }

        protected virtual void SaveRow()
        {

        }
        protected virtual void Populate()
        {

        }

        protected void WaitBegin()
        {
            if (waitHandler != null)
                waitHandler.WaitBegin();
        }

        protected void WaitEnd()
        {
            if (waitHandler != null)
                waitHandler.WaitEnd();
        }

        protected virtual void Save()
        {
            try
            {
                Cursor = Cursors.AppStarting;
                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string errorText = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    errorText = errorText + "Object: " + validationError.Entry.Entity.ToString() + "\n\r";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        errorText = errorText + err.ErrorMessage + "\n\r";

                    }
                }
                MessageBox.Show(errorText);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            Populate();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRow();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            DelRow();
        }

        private void DictForm_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRow();
        }
    }
}
