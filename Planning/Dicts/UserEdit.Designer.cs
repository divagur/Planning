namespace Planning
{
    partial class UserEdit
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRegType = new System.Windows.Forms.ComboBox();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.edLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblGroup = new System.Windows.Forms.DataGridView();
            this.colGrp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGrpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbUserGrp = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroup)).BeginInit();
            this.tbUserGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(193, 324);
            this.btnSave.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(274, 324);
            this.btnClose.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Проверка подлинности";
            this.label2.Visible = false;
            // 
            // cbRegType
            // 
            this.cbRegType.FormattingEnabled = true;
            this.cbRegType.Items.AddRange(new object[] {
            "Windows",
            "SQL Server"});
            this.cbRegType.Location = new System.Drawing.Point(154, 10);
            this.cbRegType.Name = "cbRegType";
            this.cbRegType.Size = new System.Drawing.Size(189, 21);
            this.cbRegType.TabIndex = 0;
            this.cbRegType.Visible = false;
            this.cbRegType.SelectedIndexChanged += new System.EventHandler(this.cbRegType_SelectedIndexChanged);
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(74, 63);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(269, 20);
            this.edPassword.TabIndex = 2;
            this.edPassword.UseSystemPasswordChar = true;
            // 
            // edLogin
            // 
            this.edLogin.Location = new System.Drawing.Point(74, 37);
            this.edLogin.Name = "edLogin";
            this.edLogin.Size = new System.Drawing.Size(269, 20);
            this.edLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Логин";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblGroup);
            this.groupBox1.Controls.Add(this.tbUserGrp);
            this.groupBox1.Location = new System.Drawing.Point(15, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 201);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы";
            // 
            // tblGroup
            // 
            this.tblGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGrp,
            this.colGrpId});
            this.tblGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGroup.Location = new System.Drawing.Point(3, 41);
            this.tblGroup.Name = "tblGroup";
            this.tblGroup.Size = new System.Drawing.Size(325, 157);
            this.tblGroup.TabIndex = 1;
            this.tblGroup.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblGroup_CellValueChanged);
            // 
            // colGrp
            // 
            this.colGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colGrp.HeaderText = "Группа";
            this.colGrp.Name = "colGrp";
            this.colGrp.Width = 250;
            // 
            // colGrpId
            // 
            this.colGrpId.DataPropertyName = "Id";
            this.colGrpId.HeaderText = "Id";
            this.colGrpId.Name = "colGrpId";
            this.colGrpId.Visible = false;
            // 
            // tbUserGrp
            // 
            this.tbUserGrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDel});
            this.tbUserGrp.Location = new System.Drawing.Point(3, 16);
            this.tbUserGrp.Name = "tbUserGrp";
            this.tbUserGrp.Size = new System.Drawing.Size(325, 25);
            this.tbUserGrp.TabIndex = 0;
            this.tbUserGrp.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::Planning.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "toolStripButton1";
            this.btnAdd.ToolTipText = "Добавить в группу";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = global::Planning.Properties.Resources.Delete;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.White;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 22);
            this.btnDel.Text = "toolStripButton1";
            this.btnDel.ToolTipText = "Удалить из группы";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // UserEditEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(361, 359);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRegType);
            this.Controls.Add(this.edPassword);
            this.Controls.Add(this.edLogin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserEditEx";
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edLogin, 0);
            this.Controls.SetChildIndex(this.edPassword, 0);
            this.Controls.SetChildIndex(this.cbRegType, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblGroup)).EndInit();
            this.tbUserGrp.ResumeLayout(false);
            this.tbUserGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRegType;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tbUserGrp;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.DataGridView tblGroup;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrpId;
    }
}
