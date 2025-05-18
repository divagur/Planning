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
    public partial class DictFormEx<T, R> : Form, IItemPrivilege
        where T : BaseDataItem, new()
        where R : IRepository<T>, new()
    {
        BindingList<T> _listDataItemBinding;
        List<T> _listDataItem;
        R _repository;
        DataGridView _gridView;
        Form _editForm;
        private IWait waitHandler;

        internal IWait WaitHandler { get => waitHandler; set => waitHandler = value; }

        public DictFormEx()
        {
            InitializeComponent();
            DataService.InitContext();
        }

        public void SetPrivilege(bool IsAppend, bool IsEdit, bool IsDelete)
        {
            btnAddRow.Enabled = IsAppend;
            btnEdit.Enabled = IsEdit;
            btnDelRow.Enabled = IsDelete;
            btnSave.Enabled = IsAppend || IsEdit || IsDelete;
        }
        private void UpdateDataSource()
        {
            if (!CanChange())
                return;

            _gridView.DataSource = null;
            _gridView.DataSource = _listDataItem;
            _gridView?.Refresh();
        }

        private T GetCurrentRowObject()
        {
            if (!CanChange() || !_gridView.Columns.Contains("colId"))
                return null;

            return _listDataItem.Find(d => d.Id == Int32.Parse(_gridView.Rows[_gridView.CurrentCell.RowIndex].Cells["colId"].Value.ToString()));
        }

        private bool CanChange()
        {
            return _gridView != null;
        }

        protected virtual bool CreateEditForm(T item)
        {
            return true;
        }
        protected virtual void AddRow()
        {
            if (!CanChange())
                return;
            T item = new T();
            if (!CreateEditForm(item))
                return;

            if (_repository.Save(item))
            {
                _listDataItem.Add(item);
                UpdateDataSource();
            }
            else
            {
                //, _repository.LastError
                MessageBox.Show(GetError("Ошибка при добавлении строки",_repository.GetLastError()));
            }
        }

        protected virtual void EditRow()
        {
            if (!CanChange()|| _gridView.SelectedCells.Count<=0)
                return;

            T item = GetCurrentRowObject();

            if (!CreateEditForm(item))
                return;

            if (_repository.Save(item))
            {
                UpdateDataSource();
            }
            else
            {
                MessageBox.Show(GetError("Ошибка при редактировании строки", _repository.GetLastError()));
            }
        }

        protected virtual void DelRow()
        {
            T item = GetCurrentRowObject();
            if (MessageBox.Show("Удалить строку?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                item.Delete();
                if (_repository.Save(item))
                {
                    _listDataItem.Remove(item);
                    UpdateDataSource();
                }
                else
                {
                    MessageBox.Show(GetError("Ошибка при удалении строки", _repository.GetLastError()));
                }
            }
        }

        protected virtual void SaveRow()
        {

        }
        protected virtual void Populate()
        {
            if (_gridView == null)
                return;
            _listDataItem = new List<T>();
            _repository = new R();
            _gridView.AutoGenerateColumns = false;
            _listDataItem = _repository.GetAll();
            UpdateDataSource();
        }
        protected string GetError(string ErrorHeader, string ErrorText)
        {
            return String.Format("{0}:{1}", ErrorHeader, ErrorText);
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
                // _context.SaveChanges();

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

        public DataGridView GridView
        {
            get => _gridView;
            set
            {
                _gridView = value;
            }
        }
        public Form EditForm
        {
            get => _editForm;
            set
            {
                _editForm = value;
            }
        }
    }
}
