﻿namespace Planning
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
            this.tblTimeSlot = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepositor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planningDataSet1 = new Planning.PlanningDataSet1();
            this.depositorsTableAdapter = new Planning.PlanningDataSet1TableAdapters.depositorsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblTimeSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet1)).BeginInit();
            this.SuspendLayout();
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
            this.tblTimeSlot.Location = new System.Drawing.Point(0, 0);
            this.tblTimeSlot.Name = "tblTimeSlot";
            this.tblTimeSlot.ReadOnly = true;
            this.tblTimeSlot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTimeSlot.Size = new System.Drawing.Size(829, 469);
            this.tblTimeSlot.TabIndex = 2;
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
            // TimeSlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 469);
            this.Controls.Add(this.tblTimeSlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeSlots";
            this.Text = "Тайм слоты";
            this.Controls.SetChildIndex(this.tblTimeSlot, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblTimeSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planningDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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