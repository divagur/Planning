namespace Planning
{
    partial class TimeSlots
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSlots));
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelRow = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tblTimeSlot = new System.Windows.Forms.DataGridView();
            this.depositorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planningDataSet1 = new Planning.PlanningDataSet1();
            this.depositorsTableAdapter = new Planning.PlanningDataSet1TableAdapters.depositorsTableAdapter();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepositor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTimeSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet1)).BeginInit();
            this.SuspendLayout();
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
            this.tbMain.Size = new System.Drawing.Size(829, 25);
            this.tbMain.TabIndex = 1;
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
            // 
            // tblTimeSlot
            // 
            this.tblTimeSlot.AllowUserToAddRows = false;
            this.tblTimeSlot.AllowUserToDeleteRows = false;
            this.tblTimeSlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTimeSlot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDepositor,
            this.colTimeSlot,
            this.depId});
            this.tblTimeSlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTimeSlot.Location = new System.Drawing.Point(0, 25);
            this.tblTimeSlot.Name = "tblTimeSlot";
            this.tblTimeSlot.ReadOnly = true;
            this.tblTimeSlot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTimeSlot.Size = new System.Drawing.Size(829, 444);
            this.tblTimeSlot.TabIndex = 2;
            // 
            // depositorsBindingSource
            // 
            this.depositorsBindingSource.DataMember = "depositors";
            this.depositorsBindingSource.DataSource = this.planningDataSet1;
            // 
            // planningDataSet1
            // 
            this.planningDataSet1.DataSetName = "PlanningDataSet1";
            this.planningDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // depositorsTableAdapter
            // 
            this.depositorsTableAdapter.ClearBeforeFill = true;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ts_id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDepositor
            // 
            this.colDepositor.DataPropertyName = "dep_name";
            this.colDepositor.HeaderText = "Депозитор";
            this.colDepositor.Name = "colDepositor";
            this.colDepositor.ReadOnly = true;
            this.colDepositor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDepositor.Width = 200;
            // 
            // colTimeSlot
            // 
            this.colTimeSlot.DataPropertyName = "slot_time";
            this.colTimeSlot.HeaderText = "Тайм слот";
            this.colTimeSlot.Name = "colTimeSlot";
            this.colTimeSlot.ReadOnly = true;
            // 
            // depId
            // 
            this.depId.DataPropertyName = "dep_id";
            this.depId.HeaderText = "depId";
            this.depId.Name = "depId";
            this.depId.ReadOnly = true;
            this.depId.Visible = false;
            // 
            // TimeSlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 469);
            this.Controls.Add(this.tblTimeSlot);
            this.Controls.Add(this.tbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeSlots";
            this.Text = "Тайм слоты";
            this.Load += new System.EventHandler(this.TimeSlots_Load);
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTimeSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelRow;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.DataGridView tblTimeSlot;
        private PlanningDataSet1 planningDataSet1;
        private System.Windows.Forms.BindingSource depositorsBindingSource;
        private PlanningDataSet1TableAdapters.depositorsTableAdapter depositorsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepositor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn depId;
    }
}