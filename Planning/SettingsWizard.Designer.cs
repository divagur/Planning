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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Соединение");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Отчеты", 1, 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWizard));
            this.tvStep = new System.Windows.Forms.TreeView();
            this.imlStep = new System.Windows.Forms.ImageList(this.components);
            this.pnRight = new System.Windows.Forms.Panel();
            this.pnReport = new System.Windows.Forms.Panel();
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
            this.btnRepPeriodTemplate = new System.Windows.Forms.Button();
            this.edRepPeriodTemplate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnRight.SuspendLayout();
            this.pnReport.SuspendLayout();
            this.pnConnect.SuspendLayout();
            this.pbFooter.SuspendLayout();
            this.pbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvStep
            // 
            this.tvStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStep.ImageIndex = 0;
            this.tvStep.ImageList = this.imlStep;
            this.tvStep.Location = new System.Drawing.Point(0, 0);
            this.tvStep.Name = "tvStep";
            treeNode3.Checked = true;
            treeNode3.Name = "NodeConnection";
            treeNode3.Tag = "0";
            treeNode3.Text = "Соединение";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "NodeReport";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Tag = "1";
            treeNode4.Text = "Отчеты";
            this.tvStep.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.tvStep.SelectedImageIndex = 0;
            this.tvStep.Size = new System.Drawing.Size(124, 458);
            this.tvStep.TabIndex = 1;
            this.tvStep.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStep_NodeMouseClick);
            // 
            // imlStep
            // 
            this.imlStep.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStep.ImageStream")));
            this.imlStep.TransparentColor = System.Drawing.Color.Transparent;
            this.imlStep.Images.SetKeyName(0, "database_connect.png");
            this.imlStep.Images.SetKeyName(1, "report_picture.png");
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.pnReport);
            this.pnRight.Controls.Add(this.pnConnect);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(0, 0);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(606, 458);
            this.pnRight.TabIndex = 2;
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
            // 
            // edUser
            // 
            this.edUser.Location = new System.Drawing.Point(84, 55);
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(177, 20);
            this.edUser.TabIndex = 16;
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Пользователь";
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
            this.pbFooter.Location = new System.Drawing.Point(0, 458);
            this.pbFooter.Name = "pbFooter";
            this.pbFooter.Size = new System.Drawing.Size(734, 34);
            this.pbFooter.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(654, 6);
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
            this.btnSave.Location = new System.Drawing.Point(570, 6);
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
            this.pbBack.Size = new System.Drawing.Size(734, 458);
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
            this.splitContainer1.Size = new System.Drawing.Size(734, 458);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "\"Excel|*.xltx| Excel macros| *xltm\"";
            this.openFileDialog.Title = "Шаблоны отчетов";
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
            // SettingsWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 492);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWizard";
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsWizard_Load);
            this.pnRight.ResumeLayout(false);
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
    }
}