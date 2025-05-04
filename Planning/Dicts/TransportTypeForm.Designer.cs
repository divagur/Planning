
namespace Planning
{
    partial class TransportTypeForm
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
            this.tblTransportType = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonnage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblTransportType)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTransportType
            // 
            this.tblTransportType.AllowUserToAddRows = false;
            this.tblTransportType.AllowUserToDeleteRows = false;
            this.tblTransportType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTransportType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colTonnage});
            this.tblTransportType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTransportType.Location = new System.Drawing.Point(0, 25);
            this.tblTransportType.Name = "tblTransportType";
            this.tblTransportType.ReadOnly = true;
            this.tblTransportType.Size = new System.Drawing.Size(800, 425);
            this.tblTransportType.TabIndex = 5;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
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
            this.colName.Width = 254;
            // 
            // colTonnage
            // 
            this.colTonnage.DataPropertyName = "Tonnage";
            this.colTonnage.HeaderText = "Тоннаж";
            this.colTonnage.Name = "colTonnage";
            this.colTonnage.ReadOnly = true;
            this.colTonnage.Width = 80;
            // 
            // TransportType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblTransportType);
            this.Name = "TransportType";
            this.Text = "Тип транспорта";
            this.Controls.SetChildIndex(this.tblTransportType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblTransportType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblTransportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonnage;
    }
}