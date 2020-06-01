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

namespace Planning
{
    public partial class DictForm : Form
    {
        PlanningDbContext _context;

        public DictForm()
        {
            InitializeComponent();
            _context = DataService.context;
        }


        public virtual void AddRow()
        {}

        public virtual void Populate()
        { }

        public virtual void EditRow()
        { }

        public virtual void DeleteRow()
        { }

        private void Save()
        {
            try
            {
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
            DeleteRow();
        }

        private void DictForm_Load(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
