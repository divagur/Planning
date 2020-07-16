namespace Planning
{
    partial class Depositors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Depositors));
            this.tblDict = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblDict)).BeginInit();
            this.SuspendLayout();
            // 
            // tblDict
            // 
            this.tblDict.AllowUserToAddRows = false;
            this.tblDict.AllowUserToDeleteRows = false;
            this.tblDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDict.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colDB,
            this.colLvId});
            this.tblDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDict.Location = new System.Drawing.Point(0, 0);
            this.tblDict.Name = "tblDict";
            this.tblDict.ReadOnly = true;
            this.tblDict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblDict.Size = new System.Drawing.Size(1116, 435);
            this.tblDict.TabIndex = 7;
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
            this.colName.Width = 200;
            // 
            // colDB
            // 
            this.colDB.DataPropertyName = "lv_base";
            this.colDB.HeaderText = "База данных";
            this.colDB.Name = "colDB";
            this.colDB.ReadOnly = true;
            this.colDB.Width = 150;
            // 
            // colLvId
            // 
            this.colLvId.DataPropertyName = "lv_id";
            this.colLvId.HeaderText = "Код в Lvision";
            this.colLvId.Name = "colLvId";
            this.colLvId.ReadOnly = true;
            // 
            // Depositors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 435);
            this.Controls.Add(this.tblDict);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Depositors";
            this.Text = "Depositors";
            this.Controls.SetChildIndex(this.tblDict, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblDict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView tblDict;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLvId;
    }
}