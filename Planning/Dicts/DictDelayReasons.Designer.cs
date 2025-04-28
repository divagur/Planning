namespace Planning
{
    partial class DictDelayReasons
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblDelayReasons = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblDelayReasons)).BeginInit();
            this.SuspendLayout();
            // 
            // tblDelayReasons
            // 
            this.tblDelayReasons.AllowUserToAddRows = false;
            this.tblDelayReasons.AllowUserToDeleteRows = false;
            this.tblDelayReasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDelayReasons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName});
            this.tblDelayReasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDelayReasons.Location = new System.Drawing.Point(0, 25);
            this.tblDelayReasons.Name = "tblDelayReasons";
            this.tblDelayReasons.ReadOnly = true;
            this.tblDelayReasons.Size = new System.Drawing.Size(765, 496);
            this.tblDelayReasons.TabIndex = 5;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "name";
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 250;
            // 
            // DictDelayReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(765, 521);
            this.Controls.Add(this.tblDelayReasons);
            this.Name = "DictDelayReasons";
            this.Controls.SetChildIndex(this.tblDelayReasons, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblDelayReasons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblDelayReasons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}
