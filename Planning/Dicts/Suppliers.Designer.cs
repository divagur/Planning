
namespace Planning
{
    partial class Suppliers
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
            this.tblSuppliers = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // tblSuppliers
            // 
            this.tblSuppliers.AllowUserToAddRows = false;
            this.tblSuppliers.AllowUserToDeleteRows = false;
            this.tblSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSuppliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colIsActive});
            this.tblSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSuppliers.Location = new System.Drawing.Point(0, 25);
            this.tblSuppliers.Name = "tblSuppliers";
            this.tblSuppliers.ReadOnly = true;
            this.tblSuppliers.Size = new System.Drawing.Size(765, 496);
            this.tblSuppliers.TabIndex = 5;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Код";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 400;
            // 
            // colIsActive
            // 
            this.colIsActive.DataPropertyName = "IsActive";
            this.colIsActive.HeaderText = "Активный";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            this.colIsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(765, 521);
            this.Controls.Add(this.tblSuppliers);
            this.Name = "Suppliers";
            this.Controls.SetChildIndex(this.tblSuppliers, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblSuppliers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActive;
    }
}
