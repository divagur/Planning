namespace Planning
{
    partial class UserGroupEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.edGrpName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblGrpPrvlg = new System.Windows.Forms.DataGridView();
            this.colFuncId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblGrpPrvlg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(235, 332);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(316, 332);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // edGrpName
            // 
            this.edGrpName.Location = new System.Drawing.Point(101, 6);
            this.edGrpName.Name = "edGrpName";
            this.edGrpName.Size = new System.Drawing.Size(290, 20);
            this.edGrpName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblGrpPrvlg);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 287);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доступ";
            // 
            // tblGrpPrvlg
            // 
            this.tblGrpPrvlg.AllowUserToAddRows = false;
            this.tblGrpPrvlg.AllowUserToDeleteRows = false;
            this.tblGrpPrvlg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblGrpPrvlg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFuncId,
            this.colGrpId,
            this.colFuncName,
            this.colIsView,
            this.colIsAdd,
            this.colIsEdit,
            this.colIsDelete});
            this.tblGrpPrvlg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGrpPrvlg.Location = new System.Drawing.Point(3, 16);
            this.tblGrpPrvlg.Name = "tblGrpPrvlg";
            this.tblGrpPrvlg.RowHeadersVisible = false;
            this.tblGrpPrvlg.Size = new System.Drawing.Size(373, 268);
            this.tblGrpPrvlg.TabIndex = 0;
            // 
            // colFuncId
            // 
            this.colFuncId.DataPropertyName = "FuncId";
            this.colFuncId.HeaderText = "colFuncId";
            this.colFuncId.Name = "colFuncId";
            this.colFuncId.Visible = false;
            // 
            // colGrpId
            // 
            this.colGrpId.DataPropertyName = "GrpId";
            this.colGrpId.HeaderText = "colGrpId";
            this.colGrpId.Name = "colGrpId";
            this.colGrpId.Visible = false;
            // 
            // colFuncName
            // 
            this.colFuncName.DataPropertyName = "FuncName";
            this.colFuncName.HeaderText = "Функция";
            this.colFuncName.Name = "colFuncName";
            this.colFuncName.ReadOnly = true;
            this.colFuncName.Width = 250;
            // 
            // colIsView
            // 
            this.colIsView.DataPropertyName = "IsView";
            this.colIsView.HeaderText = "П";
            this.colIsView.Name = "colIsView";
            this.colIsView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsView.ToolTipText = "Право на просмотр";
            this.colIsView.Width = 20;
            // 
            // colIsAdd
            // 
            this.colIsAdd.DataPropertyName = "IsAppend";
            this.colIsAdd.HeaderText = "Д";
            this.colIsAdd.Name = "colIsAdd";
            this.colIsAdd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsAdd.ToolTipText = "Право на добавление";
            this.colIsAdd.Width = 20;
            // 
            // colIsEdit
            // 
            this.colIsEdit.DataPropertyName = "IsEdit";
            this.colIsEdit.HeaderText = "И";
            this.colIsEdit.Name = "colIsEdit";
            this.colIsEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsEdit.ToolTipText = "Право на изменение";
            this.colIsEdit.Width = 20;
            // 
            // colIsDelete
            // 
            this.colIsDelete.DataPropertyName = "IsDelete";
            this.colIsDelete.HeaderText = "У";
            this.colIsDelete.Name = "colIsDelete";
            this.colIsDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsDelete.ToolTipText = "Право на удаление";
            this.colIsDelete.Width = 20;
            // 
            // UserGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edGrpName);
            this.Controls.Add(this.label1);
            this.Name = "UserGroupEdit";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edGrpName, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblGrpPrvlg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edGrpName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tblGrpPrvlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsDelete;
    }
}