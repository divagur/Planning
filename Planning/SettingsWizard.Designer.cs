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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Соединение");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Отчеты", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Окно текущих задач", 2, 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWizard));
            this.tvStep = new System.Windows.Forms.TreeView();
            this.imlStep = new System.Windows.Forms.ImageList(this.components);
            this.pnRight = new System.Windows.Forms.Panel();
            this.pnCurrentStep = new System.Windows.Forms.Panel();
            this.tblCurrTaskView = new System.Windows.Forms.DataGridView();
            this.lvVisibleCol = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.btnBgColor = new System.Windows.Forms.Button();
            this.btnFontSettings = new System.Windows.Forms.Button();
            this.btnFontColor = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.edFontSize = new System.Windows.Forms.NumericUpDown();
            this.pnRight.SuspendLayout();
            this.pnCurrentStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCurrTaskView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edTaskUpdateInterval)).BeginInit();
            this.pnReport.SuspendLayout();
            this.pnConnect.SuspendLayout();
            this.pbFooter.SuspendLayout();
            this.pbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFontSize)).BeginInit();
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
            treeNode4.Checked = true;
            treeNode4.ImageIndex = 0;
            treeNode4.Name = "NodeConnection";
            treeNode4.Tag = "0";
            treeNode4.Text = "Соединение";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "NodeReport";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Tag = "1";
            treeNode5.Text = "Отчеты";
            treeNode6.ImageIndex = 2;
            treeNode6.Name = "NodeCurrentTask";
            treeNode6.SelectedImageIndex = 2;
            treeNode6.Tag = "2";
            treeNode6.Text = "Окно текущих задач";
            this.tvStep.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
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
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.pnCurrentStep);
            this.pnRight.Controls.Add(this.pnReport);
            this.pnRight.Controls.Add(this.pnConnect);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(0, 0);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(1224, 519);
            this.pnRight.TabIndex = 2;
            // 
            // pnCurrentStep
            // 
            this.pnCurrentStep.Controls.Add(this.tblCurrTaskView);
            this.pnCurrentStep.Controls.Add(this.lvVisibleCol);
            this.pnCurrentStep.Controls.Add(this.groupBox1);
            this.pnCurrentStep.Location = new System.Drawing.Point(334, 29);
            this.pnCurrentStep.Name = "pnCurrentStep";
            this.pnCurrentStep.Size = new System.Drawing.Size(858, 389);
            this.pnCurrentStep.TabIndex = 3;
            // 
            // tblCurrTaskView
            // 
            this.tblCurrTaskView.AllowUserToAddRows = false;
            this.tblCurrTaskView.AllowUserToDeleteRows = false;
            this.tblCurrTaskView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCurrTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCurrTaskView.Location = new System.Drawing.Point(0, 45);
            this.tblCurrTaskView.Name = "tblCurrTaskView";
            this.tblCurrTaskView.ReadOnly = true;
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
            this.pnReport.Size = new System.Drawing.Size(597, 226);
            this.pnReport.TabIndex = 2;
            // 
            // btnRepPeriodTemplate
            // 
            this.btnRepPeriodTemplate.Location = new System.Drawing.Point(554, 125);
            this.btnRepPeriodTemplate.Name = "btnRepPeriodTemplate";
            this.btnRepPeriodTemplate.Size = new System.Drawing.Size(27, 20);
            this.btnRepPeriodTemplate.TabIndex = 5;
            this.btnRepPeriodTemplate.Text = "...";
            this.btnRepPeriodTemplate.UseVisualStyleBackColor = true;
            this.btnRepPeriodTemplate.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // edRepPeriodTemplate
            // 
            this.edRepPeriodTemplate.Location = new System.Drawing.Point(16, 126);
            this.edRepPeriodTemplate.Name = "edRepPeriodTemplate";
            this.edRepPeriodTemplate.Size = new System.Drawing.Size(532, 20);
            this.edRepPeriodTemplate.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Отгрузки за период";
            // 
            // btnReceiptDlg
            // 
            this.btnReceiptDlg.Location = new System.Drawing.Point(554, 74);
            this.btnReceiptDlg.Name = "btnReceiptDlg";
            this.btnReceiptDlg.Size = new System.Drawing.Size(27, 20);
            this.btnReceiptDlg.TabIndex = 2;
            this.btnReceiptDlg.Text = "...";
            this.btnReceiptDlg.UseVisualStyleBackColor = true;
            this.btnReceiptDlg.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // btnShipmentDlg
            // 
            this.btnShipmentDlg.Location = new System.Drawing.Point(554, 26);
            this.btnShipmentDlg.Name = "btnShipmentDlg";
            this.btnShipmentDlg.Size = new System.Drawing.Size(27, 20);
            this.btnShipmentDlg.TabIndex = 2;
            this.btnShipmentDlg.Text = "...";
            this.btnShipmentDlg.UseVisualStyleBackColor = true;
            this.btnShipmentDlg.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // edReceiptTemplate
            // 
            this.edReceiptTemplate.Location = new System.Drawing.Point(16, 75);
            this.edReceiptTemplate.Name = "edReceiptTemplate";
            this.edReceiptTemplate.Size = new System.Drawing.Size(532, 20);
            this.edReceiptTemplate.TabIndex = 1;
            // 
            // edShipmentTemplate
            // 
            this.edShipmentTemplate.Location = new System.Drawing.Point(16, 26);
            this.edShipmentTemplate.Name = "edShipmentTemplate";
            this.edShipmentTemplate.Size = new System.Drawing.Size(532, 20);
            this.edShipmentTemplate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Шаблон листа прихода";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Шаблон листа отгрузки ";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Размер шрифта";
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
            this.pnCurrentStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblCurrTaskView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.edFontSize)).EndInit();
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
    }
}