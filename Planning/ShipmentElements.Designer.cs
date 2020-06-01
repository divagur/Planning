namespace Planning
{
    partial class ShipmentElements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentElements));
            this.tblElements = new System.Windows.Forms.DataGridView();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelRow = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldDbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblElements)).BeginInit();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblElements
            // 
            this.tblElements.AllowUserToAddRows = false;
            this.tblElements.AllowUserToDeleteRows = false;
            this.tblElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFieldName,
            this.colFieldDbName,
            this.colFieldType});
            this.tblElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblElements.Location = new System.Drawing.Point(0, 25);
            this.tblElements.Name = "tblElements";
            this.tblElements.ReadOnly = true;
            this.tblElements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblElements.Size = new System.Drawing.Size(766, 394);
            this.tblElements.TabIndex = 4;
            // 
            // tbMain
            // 
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRow,
            this.btnEdit,
            this.btnDelRow,
            this.btnSave});
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(766, 25);
            this.tbMain.TabIndex = 3;
            this.tbMain.Text = "toolStrip1";
            // 
            // btnAddRow
            // 
            this.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(23, 22);
            this.btnAddRow.Text = "toolStripButton1";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.ToolTipText = "Добавить";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::Planning.Properties.Resources.Edit;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "toolStripButton1";
            this.btnEdit.ToolTipText = "Изменить";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRow.Image")));
            this.btnDelRow.ImageTransparentColor = System.Drawing.Color.White;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(23, 22);
            this.btnDelRow.Text = "toolStripButton2";
            this.btnDelRow.ToolTipText = "Удалить";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.ToolTipText = "Сохранить";
            this.btnSave.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "field_name";
            this.colFieldName.HeaderText = "Наименование";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            this.colFieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFieldName.Width = 300;
            // 
            // colFieldDbName
            // 
            this.colFieldDbName.DataPropertyName = "field_db_name";
            this.colFieldDbName.HeaderText = "Поле БД";
            this.colFieldDbName.Name = "colFieldDbName";
            this.colFieldDbName.ReadOnly = true;
            this.colFieldDbName.Width = 300;
            // 
            // colFieldType
            // 
            this.colFieldType.DataPropertyName = "field_type_name";
            this.colFieldType.HeaderText = "Тип данных";
            this.colFieldType.Name = "colFieldType";
            this.colFieldType.ReadOnly = true;
            this.colFieldType.Width = 150;
            // 
            // ShipmentElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 419);
            this.Controls.Add(this.tblElements);
            this.Controls.Add(this.tbMain);
            this.Name = "ShipmentElements";
            this.Text = "Справочник: Элементы отгрузки";
            this.Load += new System.EventHandler(this.ShipmentElements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblElements)).EndInit();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblElements;
        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelRow;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldDbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldType;
    }
}