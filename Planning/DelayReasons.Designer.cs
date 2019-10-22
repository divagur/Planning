namespace Planning
{
    partial class DelayReasons
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelayReasons));
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.btnDelRow = new System.Windows.Forms.ToolStripButton();
            this.tblDelayReasons = new System.Windows.Forms.DataGridView();
            this.planningDataSet = new Planning.PlanningDataSet();
            this.delayreasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delay_reasonsTableAdapter = new Planning.PlanningDataSetTableAdapters.delay_reasonsTableAdapter();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDelayReasons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayreasonsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRow,
            this.btnDelRow,
            this.btnSave});
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(851, 25);
            this.tbMain.TabIndex = 0;
            this.tbMain.Text = "toolStrip1";
            // 
            // btnAddRow
            // 
            this.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(23, 22);
            this.btnAddRow.Text = "toolStripButton1";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRow.Image")));
            this.btnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(23, 22);
            this.btnDelRow.Text = "toolStripButton2";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // tblDelayReasons
            // 
            this.tblDelayReasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDelayReasons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName});
            this.tblDelayReasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDelayReasons.Location = new System.Drawing.Point(0, 25);
            this.tblDelayReasons.Name = "tblDelayReasons";
            this.tblDelayReasons.Size = new System.Drawing.Size(851, 454);
            this.tblDelayReasons.TabIndex = 1;
            // 
            // planningDataSet
            // 
            this.planningDataSet.DataSetName = "PlanningDataSet";
            this.planningDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // delayreasonsBindingSource
            // 
            this.delayreasonsBindingSource.DataMember = "delay_reasons";
            this.delayreasonsBindingSource.DataSource = this.planningDataSet;
            // 
            // delay_reasonsTableAdapter
            // 
            this.delay_reasonsTableAdapter.ClearBeforeFill = true;
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // colId
            // 
            this.colId.HeaderText = "Код";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.Width = 300;
            // 
            // DelayReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 479);
            this.Controls.Add(this.tblDelayReasons);
            this.Controls.Add(this.tbMain);
            this.Name = "DelayReasons";
            this.Text = "Справочник: Причины задержки";
            this.Load += new System.EventHandler(this.DelayReasons_Load);
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDelayReasons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayreasonsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripButton btnDelRow;
        private System.Windows.Forms.DataGridView tblDelayReasons;
        private PlanningDataSet planningDataSet;
        private System.Windows.Forms.BindingSource delayreasonsBindingSource;
        private PlanningDataSetTableAdapters.delay_reasonsTableAdapter delay_reasonsTableAdapter;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    }
}