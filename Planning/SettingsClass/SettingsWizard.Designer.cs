namespace Planning
{
    partial class SettingsWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Соединение");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Отчеты", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Окно текущих задач", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Рассчет объема", 3, 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWizard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvStep = new System.Windows.Forms.TreeView();
            this.imlStep = new System.Windows.Forms.ImageList(this.components);
            this.pnRight = new System.Windows.Forms.Panel();
            this.pnVolumeCalcStep = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtImportColAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtImportColName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImportColVendorCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImportRowStart = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tblTemplateConstant = new System.Windows.Forms.DataGridView();
            this.colTemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPalletWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPalletHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPalletVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPalletDementions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnCurrentStep = new System.Windows.Forms.Panel();
            this.tblCurrTaskView = new System.Windows.Forms.DataGridView();
            this.lvVisibleCol = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edFontSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.edTaskUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.pnReport = new System.Windows.Forms.Panel();
            this.btnRepPeriodTemplate = new System.Windows.Forms.Button();
            this.edRepPeriodTemplate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReceiptDlg = new System.Windows.Forms.Button();
            this.btnShipmentDlg = new System.Windows.Forms.Button();
            this.edReceiptTemplate = new System.Windows.Forms.TextBox();
            this.edShipmentTemplate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnConnect = new System.Windows.Forms.Panel();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.edUser = new System.Windows.Forms.TextBox();
            this.edBase = new System.Windows.Forms.TextBox();
            this.edServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFooter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbBack = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.tblReports = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.colRepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepTemplatePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBgColor = new System.Windows.Forms.Button();
            this.btnFontSettings = new System.Windows.Forms.Button();
            this.btnFontColor = new System.Windows.Forms.Button();
            this.tbRepAdd = new System.Windows.Forms.ToolStripButton();
            this.tbRepEdit = new System.Windows.Forms.ToolStripButton();
            this.tbRepDel = new System.Windows.Forms.ToolStripButton();
            this.btnAddTmplt = new System.Windows.Forms.ToolStripButton();
            this.btnDelTmplt = new System.Windows.Forms.ToolStripButton();
            this.pnRight.SuspendLayout();
            this.pnVolumeCalcStep.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTemplateConstant)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnCurrentStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCurrTaskView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTaskUpdateInterval)).BeginInit();
            this.pnReport.SuspendLayout();
            this.pnConnect.SuspendLayout();
            this.pbFooter.SuspendLayout();
            this.pbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblReports)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvStep
            // 
            this.tvStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStep.ImageIndex = 0;
            this.tvStep.ImageList = this.imlStep;
            this.tvStep.LineColor = System.Drawing.Color.White;
            this.tvStep.Location = new System.Drawing.Point(0, 0);
            this.tvStep.Name = "tvStep";
            treeNode1.Checked = true;
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "NodeConnection";
            treeNode1.Tag = "0";
            treeNode1.Text = "Соединение";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "NodeReport";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Tag = "1";
            treeNode2.Text = "Отчеты";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "NodeCurrentTask";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Tag = "2";
            treeNode3.Text = "Окно текущих задач";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "NodeVolumeCalc";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Tag = "3";
            treeNode4.Text = "Рассчет объема";
            this.tvStep.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.tvStep.SelectedImageIndex = 0;
            this.tvStep.ShowRootLines = false;
            this.tvStep.Size = new System.Drawing.Size(248, 519);
            this.tvStep.TabIndex = 1;
            this.tvStep.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStep_NodeMouseClick);
            // 
            // imlStep
            // 
            this.imlStep.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStep.ImageStream")));
            this.imlStep.TransparentColor = System.Drawing.Color.Transparent;
            this.imlStep.Images.SetKeyName(0, "data_network.png");
            this.imlStep.Images.SetKeyName(1, "spreadsheet_sum.png");
            this.imlStep.Images.SetKeyName(2, "clipboard_checks.png");
            this.imlStep.Images.SetKeyName(3, "wooden_pallet_box.png");
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.pnCurrentStep);
            this.pnRight.Controls.Add(this.pnReport);
            this.pnRight.Controls.Add(this.pnConnect);
            this.pnRight.Controls.Add(this.pnVolumeCalcStep);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(0, 0);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(1224, 519);
            this.pnRight.TabIndex = 2;
            // 
            // pnVolumeCalcStep
            // 
            this.pnVolumeCalcStep.Controls.Add(this.groupBox3);
            this.pnVolumeCalcStep.Controls.Add(this.groupBox2);
            this.pnVolumeCalcStep.Location = new System.Drawing.Point(22, 22);
            this.pnVolumeCalcStep.Name = "pnVolumeCalcStep";
            this.pnVolumeCalcStep.Size = new System.Drawing.Size(848, 491);
            this.pnVolumeCalcStep.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtImportColAmount);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtImportColName);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtImportColVendorCode);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtImportRowStart);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(848, 172);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры импорта";
            // 
            // txtImportColAmount
            // 
            this.txtImportColAmount.Location = new System.Drawing.Point(152, 105);
            this.txtImportColAmount.Name = "txtImportColAmount";
            this.txtImportColAmount.Size = new System.Drawing.Size(93, 20);
            this.txtImportColAmount.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Колонка с количеством";
            // 
            // txtImportColName
            // 
            this.txtImportColName.Location = new System.Drawing.Point(152, 79);
            this.txtImportColName.Name = "txtImportColName";
            this.txtImportColName.Size = new System.Drawing.Size(93, 20);
            this.txtImportColName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Колонка с наименованием";
            // 
            // txtImportColVendorCode
            // 
            this.txtImportColVendorCode.Location = new System.Drawing.Point(152, 53);
            this.txtImportColVendorCode.Name = "txtImportColVendorCode";
            this.txtImportColVendorCode.Size = new System.Drawing.Size(93, 20);
            this.txtImportColVendorCode.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Колонка с артикулом";
            // 
            // txtImportRowStart
            // 
            this.txtImportRowStart.Location = new System.Drawing.Point(152, 22);
            this.txtImportRowStart.Name = "txtImportRowStart";
            this.txtImportRowStart.Size = new System.Drawing.Size(93, 20);
            this.txtImportRowStart.TabIndex = 1;
            this.txtImportRowStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImportRowStart_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Начальная строка данных";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tblTemplateConstant);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 225);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Константы для расчета";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tblTemplateConstant
            // 
            this.tblTemplateConstant.AllowUserToAddRows = false;
            this.tblTemplateConstant.AllowUserToDeleteRows = false;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblTemplateConstant.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.tblTemplateConstant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTemplateConstant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTemplateName,
            this.colPalletWeight,
            this.colPalletHeight,
            this.colPalletVolume,
            this.colPalletDementions});
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblTemplateConstant.DefaultCellStyle = dataGridViewCellStyle41;
            this.tblTemplateConstant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTemplateConstant.Location = new System.Drawing.Point(3, 41);
            this.tblTemplateConstant.Name = "tblTemplateConstant";
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblTemplateConstant.RowHeadersDefaultCellStyle = dataGridViewCellStyle42;
            this.tblTemplateConstant.Size = new System.Drawing.Size(842, 181);
            this.tblTemplateConstant.TabIndex = 0;
            this.tblTemplateConstant.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblTemplateConstant_CellEndEdit);
            this.tblTemplateConstant.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tblTemplateConstant_CellFormatting);
            this.tblTemplateConstant.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblTemplateConstant_CellLeave);
            this.tblTemplateConstant.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tblTemplateConstant_DataError);
            this.tblTemplateConstant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tblTemplateConstant_KeyPress);
            // 
            // colTemplateName
            // 
            this.colTemplateName.DataPropertyName = "Name";
            this.colTemplateName.HeaderText = "Наименование";
            this.colTemplateName.Name = "colTemplateName";
            this.colTemplateName.Width = 300;
            // 
            // colPalletWeight
            // 
            this.colPalletWeight.DataPropertyName = "PalletWeight";
            this.colPalletWeight.HeaderText = "Вес паллета";
            this.colPalletWeight.Name = "colPalletWeight";
            // 
            // colPalletHeight
            // 
            this.colPalletHeight.DataPropertyName = "PalletHeight";
            dataGridViewCellStyle38.NullValue = null;
            this.colPalletHeight.DefaultCellStyle = dataGridViewCellStyle38;
            this.colPalletHeight.HeaderText = "Высота паллета";
            this.colPalletHeight.Name = "colPalletHeight";
            // 
            // colPalletVolume
            // 
            this.colPalletVolume.DataPropertyName = "PalletVolume";
            dataGridViewCellStyle39.NullValue = null;
            this.colPalletVolume.DefaultCellStyle = dataGridViewCellStyle39;
            this.colPalletVolume.HeaderText = "Объем паллета";
            this.colPalletVolume.Name = "colPalletVolume";
            // 
            // colPalletDementions
            // 
            this.colPalletDementions.DataPropertyName = "PalleteDimensions";
            dataGridViewCellStyle40.NullValue = null;
            this.colPalletDementions.DefaultCellStyle = dataGridViewCellStyle40;
            this.colPalletDementions.HeaderText = "Габариты паллета";
            this.colPalletDementions.Name = "colPalletDementions";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddTmplt,
            this.btnDelTmplt});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(842, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pnCurrentStep
            // 
            this.pnCurrentStep.Controls.Add(this.tblCurrTaskView);
            this.pnCurrentStep.Controls.Add(this.lvVisibleCol);
            this.pnCurrentStep.Controls.Add(this.groupBox1);
            this.pnCurrentStep.Location = new System.Drawing.Point(637, 92);
            this.pnCurrentStep.Name = "pnCurrentStep";
            this.pnCurrentStep.Size = new System.Drawing.Size(858, 389);
            this.pnCurrentStep.TabIndex = 3;
            // 
            // tblCurrTaskView
            // 
            this.tblCurrTaskView.AllowUserToAddRows = false;
            this.tblCurrTaskView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblCurrTaskView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.tblCurrTaskView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblCurrTaskView.DefaultCellStyle = dataGridViewCellStyle44;
            this.tblCurrTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCurrTaskView.Location = new System.Drawing.Point(0, 45);
            this.tblCurrTaskView.Name = "tblCurrTaskView";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblCurrTaskView.RowHeadersDefaultCellStyle = dataGridViewCellStyle45;
            this.tblCurrTaskView.RowHeadersVisible = false;
            this.tblCurrTaskView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.tblCurrTaskView.Size = new System.Drawing.Size(858, 344);
            this.tblCurrTaskView.TabIndex = 10;
            // 
            // lvVisibleCol
            // 
            this.lvVisibleCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVisibleCol.HideSelection = false;
            this.lvVisibleCol.Location = new System.Drawing.Point(0, 45);
            this.lvVisibleCol.Name = "lvVisibleCol";
            this.lvVisibleCol.Size = new System.Drawing.Size(858, 344);
            this.lvVisibleCol.TabIndex = 9;
            this.lvVisibleCol.UseCompatibleStateImageBehavior = false;
            this.lvVisibleCol.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edFontSize);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnBgColor);
            this.groupBox1.Controls.Add(this.btnFontSettings);
            this.groupBox1.Controls.Add(this.btnFontColor);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.edTaskUpdateInterval);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // edFontSize
            // 
            this.edFontSize.Location = new System.Drawing.Point(317, 14);
            this.edFontSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edFontSize.Name = "edFontSize";
            this.edFontSize.Size = new System.Drawing.Size(46, 20);
            this.edFontSize.TabIndex = 10;
            this.edFontSize.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Размер шрифта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Период автообновления, сек";
            // 
            // edTaskUpdateInterval
            // 
            this.edTaskUpdateInterval.Location = new System.Drawing.Point(167, 14);
            this.edTaskUpdateInterval.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.edTaskUpdateInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edTaskUpdateInterval.Name = "edTaskUpdateInterval";
            this.edTaskUpdateInterval.Size = new System.Drawing.Size(45, 20);
            this.edTaskUpdateInterval.TabIndex = 5;
            this.edTaskUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // pnReport
            // 
            this.pnReport.Controls.Add(this.tblReports);
            this.pnReport.Controls.Add(this.toolStrip2);
            this.pnReport.Controls.Add(this.btnRepPeriodTemplate);
            this.pnReport.Controls.Add(this.edRepPeriodTemplate);
            this.pnReport.Controls.Add(this.label7);
            this.pnReport.Controls.Add(this.btnReceiptDlg);
            this.pnReport.Controls.Add(this.btnShipmentDlg);
            this.pnReport.Controls.Add(this.edReceiptTemplate);
            this.pnReport.Controls.Add(this.edShipmentTemplate);
            this.pnReport.Controls.Add(this.label6);
            this.pnReport.Controls.Add(this.label5);
            this.pnReport.Location = new System.Drawing.Point(6, 175);
            this.pnReport.Name = "pnReport";
            this.pnReport.Size = new System.Drawing.Size(597, 306);
            this.pnReport.TabIndex = 2;
            // 
            // btnRepPeriodTemplate
            // 
            this.btnRepPeriodTemplate.Location = new System.Drawing.Point(550, 266);
            this.btnRepPeriodTemplate.Name = "btnRepPeriodTemplate";
            this.btnRepPeriodTemplate.Size = new System.Drawing.Size(27, 20);
            this.btnRepPeriodTemplate.TabIndex = 5;
            this.btnRepPeriodTemplate.Text = "...";
            this.btnRepPeriodTemplate.UseVisualStyleBackColor = true;
            this.btnRepPeriodTemplate.Visible = false;
            this.btnRepPeriodTemplate.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // edRepPeriodTemplate
            // 
            this.edRepPeriodTemplate.Location = new System.Drawing.Point(12, 267);
            this.edRepPeriodTemplate.Name = "edRepPeriodTemplate";
            this.edRepPeriodTemplate.Size = new System.Drawing.Size(532, 20);
            this.edRepPeriodTemplate.TabIndex = 4;
            this.edRepPeriodTemplate.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Отгрузки за период";
            this.label7.Visible = false;
            // 
            // btnReceiptDlg
            // 
            this.btnReceiptDlg.Location = new System.Drawing.Point(550, 215);
            this.btnReceiptDlg.Name = "btnReceiptDlg";
            this.btnReceiptDlg.Size = new System.Drawing.Size(27, 20);
            this.btnReceiptDlg.TabIndex = 2;
            this.btnReceiptDlg.Text = "...";
            this.btnReceiptDlg.UseVisualStyleBackColor = true;
            this.btnReceiptDlg.Visible = false;
            this.btnReceiptDlg.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // btnShipmentDlg
            // 
            this.btnShipmentDlg.Location = new System.Drawing.Point(550, 167);
            this.btnShipmentDlg.Name = "btnShipmentDlg";
            this.btnShipmentDlg.Size = new System.Drawing.Size(27, 20);
            this.btnShipmentDlg.TabIndex = 2;
            this.btnShipmentDlg.Text = "...";
            this.btnShipmentDlg.UseVisualStyleBackColor = true;
            this.btnShipmentDlg.Visible = false;
            this.btnShipmentDlg.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // edReceiptTemplate
            // 
            this.edReceiptTemplate.Location = new System.Drawing.Point(12, 216);
            this.edReceiptTemplate.Name = "edReceiptTemplate";
            this.edReceiptTemplate.Size = new System.Drawing.Size(532, 20);
            this.edReceiptTemplate.TabIndex = 1;
            this.edReceiptTemplate.Visible = false;
            // 
            // edShipmentTemplate
            // 
            this.edShipmentTemplate.Location = new System.Drawing.Point(12, 167);
            this.edShipmentTemplate.Name = "edShipmentTemplate";
            this.edShipmentTemplate.Size = new System.Drawing.Size(532, 20);
            this.edShipmentTemplate.TabIndex = 1;
            this.edShipmentTemplate.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Шаблон листа прихода";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Шаблон листа отгрузки ";
            this.label5.Visible = false;
            // 
            // pnConnect
            // 
            this.pnConnect.Controls.Add(this.edPassword);
            this.pnConnect.Controls.Add(this.edUser);
            this.pnConnect.Controls.Add(this.edBase);
            this.pnConnect.Controls.Add(this.edServer);
            this.pnConnect.Controls.Add(this.label4);
            this.pnConnect.Controls.Add(this.label3);
            this.pnConnect.Controls.Add(this.label2);
            this.pnConnect.Controls.Add(this.label1);
            this.pnConnect.Location = new System.Drawing.Point(6, 22);
            this.pnConnect.Name = "pnConnect";
            this.pnConnect.Size = new System.Drawing.Size(375, 127);
            this.pnConnect.TabIndex = 1;
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(84, 81);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(177, 20);
            this.edPassword.TabIndex = 18;
            this.edPassword.Visible = false;
            // 
            // edUser
            // 
            this.edUser.Location = new System.Drawing.Point(84, 55);
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(177, 20);
            this.edUser.TabIndex = 16;
            this.edUser.Visible = false;
            // 
            // edBase
            // 
            this.edBase.Location = new System.Drawing.Point(84, 30);
            this.edBase.Name = "edBase";
            this.edBase.Size = new System.Drawing.Size(256, 20);
            this.edBase.TabIndex = 14;
            // 
            // edServer
            // 
            this.edServer.Location = new System.Drawing.Point(84, 3);
            this.edServer.Name = "edServer";
            this.edServer.Size = new System.Drawing.Size(256, 20);
            this.edServer.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Пароль";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Пользователь";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "База данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Сервер";
            // 
            // pbFooter
            // 
            this.pbFooter.Controls.Add(this.btnClose);
            this.pbFooter.Controls.Add(this.btnSave);
            this.pbFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbFooter.Location = new System.Drawing.Point(0, 519);
            this.pbFooter.Name = "pbFooter";
            this.pbFooter.Size = new System.Drawing.Size(1476, 34);
            this.pbFooter.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1396, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1312, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbBack
            // 
            this.pbBack.Controls.Add(this.splitContainer1);
            this.pbBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBack.Location = new System.Drawing.Point(0, 0);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(1476, 519);
            this.pbBack.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvStep);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnRight);
            this.splitContainer1.Size = new System.Drawing.Size(1476, 519);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "\"Excel|*.xltx| Excel macros| *xltm\"";
            this.openFileDialog.Title = "Шаблоны отчетов";
            // 
            // tblReports
            // 
            this.tblReports.AllowUserToAddRows = false;
            this.tblReports.AllowUserToDeleteRows = false;
            this.tblReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRepId,
            this.colRepName,
            this.colRepTemplatePath});
            this.tblReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblReports.Location = new System.Drawing.Point(0, 25);
            this.tblReports.Name = "tblReports";
            this.tblReports.ReadOnly = true;
            this.tblReports.RowHeadersVisible = false;
            this.tblReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblReports.Size = new System.Drawing.Size(597, 281);
            this.tblReports.TabIndex = 6;
            this.tblReports.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tblReports_CellMouseDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRepAdd,
            this.tbRepEdit,
            this.tbRepDel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(597, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // colRepId
            // 
            this.colRepId.DataPropertyName = "Id";
            this.colRepId.HeaderText = "Код";
            this.colRepId.Name = "colRepId";
            this.colRepId.ReadOnly = true;
            this.colRepId.Visible = false;
            // 
            // colRepName
            // 
            this.colRepName.DataPropertyName = "Name";
            this.colRepName.HeaderText = "Наименование";
            this.colRepName.Name = "colRepName";
            this.colRepName.ReadOnly = true;
            this.colRepName.Width = 250;
            // 
            // colRepTemplatePath
            // 
            this.colRepTemplatePath.DataPropertyName = "TemplatePath";
            this.colRepTemplatePath.HeaderText = "Шаблон";
            this.colRepTemplatePath.Name = "colRepTemplatePath";
            this.colRepTemplatePath.ReadOnly = true;
            this.colRepTemplatePath.Width = 500;
            // 
            // btnBgColor
            // 
            this.btnBgColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBgColor.Image = global::Planning.Properties.Resources.paint_bucket;
            this.btnBgColor.Location = new System.Drawing.Point(534, 11);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(25, 23);
            this.btnBgColor.TabIndex = 8;
            this.btnBgColor.UseVisualStyleBackColor = true;
            this.btnBgColor.Visible = false;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            // 
            // btnFontSettings
            // 
            this.btnFontSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFontSettings.Image = global::Planning.Properties.Resources.font;
            this.btnFontSettings.Location = new System.Drawing.Point(477, 11);
            this.btnFontSettings.Name = "btnFontSettings";
            this.btnFontSettings.Size = new System.Drawing.Size(25, 23);
            this.btnFontSettings.TabIndex = 8;
            this.btnFontSettings.UseVisualStyleBackColor = true;
            this.btnFontSettings.Visible = false;
            this.btnFontSettings.Click += new System.EventHandler(this.btnFontSettings_Click);
            // 
            // btnFontColor
            // 
            this.btnFontColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFontColor.Image = global::Planning.Properties.Resources.color_font;
            this.btnFontColor.Location = new System.Drawing.Point(508, 11);
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.Size = new System.Drawing.Size(25, 23);
            this.btnFontColor.TabIndex = 8;
            this.btnFontColor.UseVisualStyleBackColor = true;
            this.btnFontColor.Visible = false;
            this.btnFontColor.Click += new System.EventHandler(this.btnFontColor_Click);
            // 
            // tbRepAdd
            // 
            this.tbRepAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRepAdd.Image = global::Planning.Properties.Resources.Add;
            this.tbRepAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRepAdd.Name = "tbRepAdd";
            this.tbRepAdd.Size = new System.Drawing.Size(23, 22);
            this.tbRepAdd.Text = "toolStripButton1";
            this.tbRepAdd.ToolTipText = "Добавить отчет";
            this.tbRepAdd.Visible = false;
            this.tbRepAdd.Click += new System.EventHandler(this.tbRepAdd_Click);
            // 
            // tbRepEdit
            // 
            this.tbRepEdit.BackColor = System.Drawing.Color.Transparent;
            this.tbRepEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRepEdit.Image = global::Planning.Properties.Resources.Edit;
            this.tbRepEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRepEdit.Name = "tbRepEdit";
            this.tbRepEdit.Size = new System.Drawing.Size(23, 22);
            this.tbRepEdit.Text = "toolStripButton2";
            this.tbRepEdit.ToolTipText = "Редактировать отчет";
            this.tbRepEdit.Click += new System.EventHandler(this.tbRepEdit_Click);
            // 
            // tbRepDel
            // 
            this.tbRepDel.BackColor = System.Drawing.Color.Transparent;
            this.tbRepDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRepDel.Image = global::Planning.Properties.Resources.Delete;
            this.tbRepDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRepDel.Name = "tbRepDel";
            this.tbRepDel.Size = new System.Drawing.Size(23, 22);
            this.tbRepDel.Text = "toolStripButton3";
            this.tbRepDel.ToolTipText = "Удалить отчет";
            this.tbRepDel.Visible = false;
            this.tbRepDel.Click += new System.EventHandler(this.tbRepDel_Click);
            // 
            // btnAddTmplt
            // 
            this.btnAddTmplt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddTmplt.Image = global::Planning.Properties.Resources.Add;
            this.btnAddTmplt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTmplt.Name = "btnAddTmplt";
            this.btnAddTmplt.Size = new System.Drawing.Size(23, 22);
            this.btnAddTmplt.Text = "toolStripButton1";
            this.btnAddTmplt.ToolTipText = "Добавить шаблон";
            this.btnAddTmplt.Click += new System.EventHandler(this.btnAddTmplt_Click);
            // 
            // btnDelTmplt
            // 
            this.btnDelTmplt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelTmplt.Image = global::Planning.Properties.Resources.Delete;
            this.btnDelTmplt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelTmplt.Name = "btnDelTmplt";
            this.btnDelTmplt.Size = new System.Drawing.Size(23, 22);
            this.btnDelTmplt.Text = "toolStripButton2";
            this.btnDelTmplt.ToolTipText = "Удалить шаблон";
            this.btnDelTmplt.Click += new System.EventHandler(this.btnDelTmplt_Click);
            // 
            // SettingsWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 553);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWizard";
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsWizard_Load);
            this.pnRight.ResumeLayout(false);
            this.pnVolumeCalcStep.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTemplateConstant)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnCurrentStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblCurrTaskView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edTaskUpdateInterval)).EndInit();
            this.pnReport.ResumeLayout(false);
            this.pnReport.PerformLayout();
            this.pnConnect.ResumeLayout(false);
            this.pnConnect.PerformLayout();
            this.pbFooter.ResumeLayout(false);
            this.pbBack.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblReports)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView tvStep;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.ImageList imlStep;
        private System.Windows.Forms.Panel pnReport;
        private System.Windows.Forms.Panel pnConnect;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.TextBox edUser;
        private System.Windows.Forms.TextBox edBase;
        private System.Windows.Forms.TextBox edServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pbFooter;
        private System.Windows.Forms.Panel pbBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnReceiptDlg;
        private System.Windows.Forms.Button btnShipmentDlg;
        private System.Windows.Forms.TextBox edReceiptTemplate;
        private System.Windows.Forms.TextBox edShipmentTemplate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnRepPeriodTemplate;
        private System.Windows.Forms.TextBox edRepPeriodTemplate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnCurrentStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown edTaskUpdateInterval;
        private System.Windows.Forms.ListView lvVisibleCol;
        private System.Windows.Forms.Button btnFontColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.DataGridView tblCurrTaskView;
        private System.Windows.Forms.Button btnFontSettings;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.NumericUpDown edFontSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnVolumeCalcStep;
        private System.Windows.Forms.DataGridView tblTemplateConstant;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton btnAddTmplt;
        private System.Windows.Forms.ToolStripButton btnDelTmplt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPalletWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPalletHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPalletVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPalletDementions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtImportRowStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtImportColAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtImportColName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtImportColVendorCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView tblReports;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tbRepAdd;
        private System.Windows.Forms.ToolStripButton tbRepEdit;
        private System.Windows.Forms.ToolStripButton tbRepDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepTemplatePath;
    }
}