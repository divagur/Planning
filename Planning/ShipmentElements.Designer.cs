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
            this.tblElements = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldDbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblElements)).BeginInit();
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
            this.tblElements.Size = new System.Drawing.Size(997, 394);
            this.tblElements.TabIndex = 4;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "FieldName";
            this.colFieldName.HeaderText = "Наименование";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            this.colFieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFieldName.Width = 300;
            // 
            // colFieldDbName
            // 
            this.colFieldDbName.DataPropertyName = "FieldDbName";
            this.colFieldDbName.HeaderText = "Поле БД";
            this.colFieldDbName.Name = "colFieldDbName";
            this.colFieldDbName.ReadOnly = true;
            this.colFieldDbName.Width = 300;
            // 
            // colFieldType
            // 
            this.colFieldType.DataPropertyName = "FieldTypeName";
            this.colFieldType.HeaderText = "Тип данных";
            this.colFieldType.Name = "colFieldType";
            this.colFieldType.ReadOnly = true;
            this.colFieldType.Width = 150;
            // 
            // ShipmentElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 419);
            this.Controls.Add(this.tblElements);
            this.Name = "ShipmentElements";
            this.Text = "Справочник: Элементы отгрузки";
            this.Controls.SetChildIndex(this.tblElements, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblElements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblElements;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldDbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldType;
    }
}