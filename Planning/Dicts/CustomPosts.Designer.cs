
namespace Planning
{
    partial class CustomPosts
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
            this.tblCustomPosts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomPosts)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCustomPosts
            // 
            this.tblCustomPosts.AllowUserToAddRows = false;
            this.tblCustomPosts.AllowUserToDeleteRows = false;
            this.tblCustomPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCustomPosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCode,
            this.colName,
            this.colDescr});
            this.tblCustomPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCustomPosts.Location = new System.Drawing.Point(0, 25);
            this.tblCustomPosts.Name = "tblCustomPosts";
            this.tblCustomPosts.ReadOnly = true;
            this.tblCustomPosts.Size = new System.Drawing.Size(800, 425);
            this.tblCustomPosts.TabIndex = 5;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Код";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colDescr
            // 
            this.colDescr.DataPropertyName = "Descr";
            this.colDescr.HeaderText = "Описание";
            this.colDescr.Name = "colDescr";
            this.colDescr.ReadOnly = true;
            this.colDescr.Width = 200;
            // 
            // CustomPosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblCustomPosts);
            this.Name = "CustomPosts";
            this.Text = "CustomPosts";
            this.Controls.SetChildIndex(this.tblCustomPosts, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblCustomPosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblCustomPosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescr;
    }
}