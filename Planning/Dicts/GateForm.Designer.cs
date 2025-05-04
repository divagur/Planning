
namespace Planning
{
    partial class GateForm
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
            this.tblGates = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblGates)).BeginInit();
            this.SuspendLayout();
            // 
            // tblGates
            // 
            this.tblGates.AllowUserToAddRows = false;
            this.tblGates.AllowUserToDeleteRows = false;
            this.tblGates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblGates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName});
            this.tblGates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGates.Location = new System.Drawing.Point(0, 25);
            this.tblGates.Name = "tblGates";
            this.tblGates.ReadOnly = true;
            this.tblGates.Size = new System.Drawing.Size(800, 425);
            this.tblGates.TabIndex = 5;
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
            this.colName.HeaderText = "Номер ворот";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 254;
            // 
            // GateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblGates);
            this.Name = "GateForm";
            this.Text = "Ворота";
            this.Controls.SetChildIndex(this.tblGates, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblGates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblGates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}