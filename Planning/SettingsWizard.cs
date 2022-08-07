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
    public partial class SettingsWizard : Form
    {
        private List<Panel> steps = new List<Panel>();
        Settings _settings;
        List<DictColumn> CurrentTaskCols = new List<DictColumn>();
        List<string> CurrentTaskColsVisible = new List<string>();
        BindingList<VolumeCalcConstant> bindingListVolumeCalcConstant;
        BindingSource sourceVolumeCalcConstant;

        public SettingsWizard(Settings settings)
        {
            InitializeComponent();
            steps.Add(pnConnect);
            steps.Add(pnReport);
            steps.Add(pnCurrentStep);
            steps.Add(pnVolumeCalcStep);
            _settings = settings;
            ShowStep(0);
            tvStep.SelectedNode = tvStep.Nodes[0];




        }

        public void ShowStep(int Index)
        {
            foreach (Panel pn in steps)
            {
                pn.Visible = false;
            }
            Panel panel = steps[Index];

            panel.Visible = true;
            panel.Dock = DockStyle.Fill;
        }

        private void tvStep_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowStep( int.Parse(e.Node.Tag.ToString()));
        }

        private void SettingsWizard_Load(object sender, EventArgs e)
        {
            if (_settings == null)
            {
                return;
            }
            edServer.Text = _settings.ServerName;
            edBase.Text = _settings.BaseName;
            edUser.Text = _settings.UserName;
            edPassword.Text = _settings.Password;
            edShipmentTemplate.Text = _settings.ShipmentReport;
            edReceiptTemplate.Text = _settings.ReceiptReport;
            edRepPeriodTemplate.Text = _settings.PeriodReport;
            btnReceiptDlg.Tag = edReceiptTemplate;
            btnShipmentDlg.Tag = edShipmentTemplate;
            btnRepPeriodTemplate.Tag = edRepPeriodTemplate;
            edTaskUpdateInterval.Value = _settings.TaskUpdateInterval==0?10: _settings.TaskUpdateInterval;
            edFontSize.Value = _settings.TaskViewFonSize;
            LoadCurrentTask();

            tblTemplateConstant.AutoGenerateColumns = false;

            bindingListVolumeCalcConstant = new BindingList<VolumeCalcConstant>(_settings.VolumeCalcTemplate);
            sourceVolumeCalcConstant = new BindingSource(bindingListVolumeCalcConstant, null);


            //tblTemplateConstant.DataSource = sourceVolumeCalcConstant;
            tblTemplateConstant.DataSource = _settings.VolumeCalcTemplate;
        }

        private void btnShipmentDlg_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog()==DialogResult.OK)
                ((TextBox)((Button)sender).Tag).Text = openFileDialog.FileName;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ServerName = edServer.Text;
            _settings.BaseName = edBase.Text;
            _settings.UserName = edUser.Text;
            _settings.Password = edPassword.Text;
            _settings.ShipmentReport = edShipmentTemplate.Text;
            _settings.ReceiptReport = edReceiptTemplate.Text;
            _settings.PeriodReport = edRepPeriodTemplate.Text;
            _settings.TaskUpdateInterval = edTaskUpdateInterval.Value;
            _settings.TaskViewFonSize = edFontSize.Value;

            foreach (DataGridViewCheckBoxColumn column in tblCurrTaskView.Columns)
            {
                CurrTaskColumn listItem =  _settings.CurrentTaskColumns.Find(c => c.Id == column.Name);
                if (listItem == null)
                {
                    listItem = new CurrTaskColumn();
                    _settings.CurrentTaskColumns.Add(listItem);
                }

                listItem.Id = column.Name;
                listItem.Title = column.HeaderText;
                listItem.Visible = (bool)tblCurrTaskView.Rows[0].Cells[column.Index].Value;
                listItem.Width = column.Width;
                listItem.BgColor = column.DefaultCellStyle.BackColor.ToArgb();
                listItem.FontColor = column.HeaderCell.Style.ForeColor.ToArgb();
            }



            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnReceiptDlg_Click(object sender, EventArgs e)
        {

        }

        private void LoadCurrentTask()
        {

            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colDate", HeaderText = "Дата", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colTime", HeaderText = "Время", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colOrderId", HeaderText = "Код заказа", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colKlient", HeaderText = "Клиент", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colStatus", HeaderText = "Статус", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colDonePrc", HeaderText = "Собран в (%)", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colAmountLine", HeaderText = "Кол-во линий", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colAmountPallet", HeaderText = "Кол-во паллет", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colAmountBox", HeaderText = "Кол-во коробов", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colAmountPieces", HeaderText = "Кол-во штук", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colShpComment", HeaderText = "Комментарии по загрузке", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colGateName", HeaderText = "Номер ворот", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colSubmissionTime", HeaderText = "Время подачи документов", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colStartTime", HeaderText = "Время начала", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colEndTimePlan", HeaderText = "Время окончания", Width = 100 });
            tblCurrTaskView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colEndTimeFact", HeaderText = "Убытие по факту", Width = 100 });

            tblCurrTaskView.Rows.Add(true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true);

            
             foreach (CurrTaskColumn item in _settings.CurrentTaskColumns)
             {
                if (tblCurrTaskView.Columns.Contains(item.Id))
                {
                    
                    tblCurrTaskView.Columns[item.Id].Width = item.Width;
                    tblCurrTaskView.Rows[0].Cells[item.Id].Value = item.Visible;
                    //tblCurrTaskView.Columns[item.Id].DefaultCellStyle.BackColor = Color.FromArgb(item.BgColor);
                    //tblCurrTaskView.Columns[item.Id].HeaderCell.Style.ForeColor = Color.FromArgb(item.FontColor);

                }
                 
             }
            
             
        }

        private void btnBgColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog()==DialogResult.OK)
            {
                Int32 selectedColumnCount = tblCurrTaskView.Columns.GetColumnCount(DataGridViewElementStates.Selected);
                for (int i = 0; i < selectedColumnCount; i++)
                {
                    tblCurrTaskView.SelectedColumns[i].DefaultCellStyle.BackColor = colorDialog.Color;
                }
               
            }
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Int32 selectedColumnCount = tblCurrTaskView.Columns.GetColumnCount(DataGridViewElementStates.Selected);
                for (int i = 0; i < selectedColumnCount; i++)
                {
                    tblCurrTaskView.SelectedColumns[i].HeaderCell.Style.ForeColor = colorDialog.Color;
                }

            }
        }

        private void btnFontSettings_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                tblCurrTaskView.DefaultCellStyle.Font = fontDialog.Font;

            }
            
        }

        private void btnAddTmplt_Click(object sender, EventArgs e)
        {
            VolumeCalcConstant item = new VolumeCalcConstant();
            item.Name = "Набор констант "+ (_settings.VolumeCalcTemplate.Count+1).ToString();

            _settings.VolumeCalcTemplate.Add(item);

            sourceVolumeCalcConstant.ResetBindings(false);
        }

        private void btnDelTmplt_Click(object sender, EventArgs e)
        {
            VolumeCalcConstant item = _settings.VolumeCalcTemplate.Find(i => i.Name == (string)tblTemplateConstant.CurrentRow.Cells[0].Value);
            if (item != null)
            {
                try
                {

                    _settings.VolumeCalcTemplate.Remove(item);
                    /*
                    sourceVolumeCalcConstant.SuspendBinding();
                    sourceVolumeCalcConstant.DataSource = _settings.VolumeCalcTemplate;
                    sourceVolumeCalcConstant.ResumeBinding();

                    tblTemplateConstant.DataSource = sourceVolumeCalcConstant;
                    */
                    // sourceVolumeCalcConstant.ResetBindings(false);
                    tblTemplateConstant.DataSource = _settings.VolumeCalcTemplate;
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                

        }

        private void tblTemplateConstant_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
 
        }

        private void tblTemplateConstant_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && (tblTemplateConstant.CurrentCell.Value == null || (string)tblTemplateConstant.CurrentCell.Value == ""))
            {
                MessageBox.Show("Имя шаблона не может быть пустым");
                return;
            }
        }

        private void tblTemplateConstant_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tblTemplateConstant_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void tblTemplateConstant_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
