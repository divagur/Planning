namespace Planning
{
    partial class SimpleDict<T,R>
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
            this.tblDataGrid = new System.Windows.Forms.DataGridView();
            this.planningDataSet = new Planning.PlanningDataSet();
            this.delayreasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.delay_reasonsTableAdapter = new Planning.PlanningDataSetTableAdapters.delay_reasonsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayreasonsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tblDataGrid
            // 
            this.tblDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDataGrid.Location = new System.Drawing.Point(0, 25);
            this.tblDataGrid.Name = "tblDataGrid";
            this.tblDataGrid.Size = new System.Drawing.Size(851, 454);
            this.tblDataGrid.TabIndex = 1;
            this.tblDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblDelayReasons_CellValueChanged);
            this.tblDataGrid.CurrentCellChanged += new System.EventHandler(this.tblDelayReasons_CurrentCellChanged);
            this.tblDataGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblDelayReasons_RowValidated);
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
            // SimpleDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 479);
            this.Controls.Add(this.tblDataGrid);
            this.Name = "SimpleDict";
            this.Text = "Справочник: Причины задержки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SimpleDict_FormClosed);
            this.Load += new System.EventHandler(this.DelayReasons_Load);
            this.Controls.SetChildIndex(this.tblDataGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayreasonsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView tblDataGrid;
        private PlanningDataSet planningDataSet;
        private System.Windows.Forms.BindingSource delayreasonsBindingSource;
        private PlanningDataSetTableAdapters.delay_reasonsTableAdapter delay_reasonsTableAdapter;
    }
}