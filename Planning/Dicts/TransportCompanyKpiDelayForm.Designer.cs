namespace Planning
{
    partial class TransportCompanyKpiDelayForm
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
            this.tblTransportCompanyKpiDelay = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinutesDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKpi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblTransportCompanyKpiDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTransportCompanyKpiDelay
            // 
            this.tblTransportCompanyKpiDelay.AllowUserToAddRows = false;
            this.tblTransportCompanyKpiDelay.AllowUserToDeleteRows = false;
            this.tblTransportCompanyKpiDelay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTransportCompanyKpiDelay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMinutesDelay,
            this.colKpi});
            this.tblTransportCompanyKpiDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTransportCompanyKpiDelay.Location = new System.Drawing.Point(0, 25);
            this.tblTransportCompanyKpiDelay.Name = "tblTransportCompanyKpiDelay";
            this.tblTransportCompanyKpiDelay.ReadOnly = true;
            this.tblTransportCompanyKpiDelay.Size = new System.Drawing.Size(800, 425);
            this.tblTransportCompanyKpiDelay.TabIndex = 6;
            this.tblTransportCompanyKpiDelay.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tblTransportCompanyKpiDelay_CellFormatting);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colMinutesDelay
            // 
            this.colMinutesDelay.DataPropertyName = "MinutesDelay";
            this.colMinutesDelay.HeaderText = "Время опоздания";
            this.colMinutesDelay.Name = "colMinutesDelay";
            this.colMinutesDelay.ReadOnly = true;
            // 
            // colKpi
            // 
            this.colKpi.DataPropertyName = "Kpi";
            this.colKpi.HeaderText = "Показатель KPI (%)";
            this.colKpi.Name = "colKpi";
            this.colKpi.ReadOnly = true;
            this.colKpi.Width = 254;
            // 
            // TransportCompanyKpiDelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblTransportCompanyKpiDelay);
            this.Name = "TransportCompanyKpiDelayForm";
            this.Text = "TransportCompanyKpiDelay";
            this.Controls.SetChildIndex(this.tblTransportCompanyKpiDelay, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tblTransportCompanyKpiDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblTransportCompanyKpiDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinutesDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKpi;
    }
}