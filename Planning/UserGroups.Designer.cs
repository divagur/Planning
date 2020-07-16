namespace Planning
{
    partial class UserGroups
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
            this.tblUserGroup = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblUserGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // tblUserGroup
            // 
            this.tblUserGroup.AllowUserToAddRows = false;
            this.tblUserGroup.AllowUserToDeleteRows = false;
            this.tblUserGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblUserGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName});
            this.tblUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblUserGroup.Location = new System.Drawing.Point(0, 25);
            this.tblUserGroup.Name = "tblUserGroup";
            this.tblUserGroup.ReadOnly = true;
            this.tblUserGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tblUserGroup.Size = new System.Drawing.Size(892, 418);
            this.tblUserGroup.TabIndex = 4;
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
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.Width = 300;
            // 
            // UserGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 443);
            this.Controls.Add(this.tblUserGroup);
            this.Name = "UserGroups";
            this.Text = "UserGroups";
           
            this.Controls.SetChildIndex(this.tblUserGroup, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblUserGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblUserGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}