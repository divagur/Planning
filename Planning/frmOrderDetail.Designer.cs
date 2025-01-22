
namespace Planning
{
    partial class frmOrderDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblOrderDetail = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonExportExcel = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrimaryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderDetail)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblOrderDetail
            // 
            this.tblOrderDetail.AllowUserToAddRows = false;
            this.tblOrderDetail.AllowUserToDeleteRows = false;
            this.tblOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colPrimaryCode,
            this.colShortDescription,
            this.colQuantity});
            this.tblOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOrderDetail.Location = new System.Drawing.Point(0, 25);
            this.tblOrderDetail.Name = "tblOrderDetail";
            this.tblOrderDetail.ReadOnly = true;
            this.tblOrderDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblOrderDetail.Size = new System.Drawing.Size(745, 370);
            this.tblOrderDetail.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExportExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonExportExcel
            // 
            this.toolStripButtonExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportExcel.Image = global::Planning.Properties.Resources.disk_4117;
            this.toolStripButtonExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportExcel.Name = "toolStripButtonExportExcel";
            this.toolStripButtonExportExcel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportExcel.Text = "toolStripButtonExportExcel";
            this.toolStripButtonExportExcel.Click += new System.EventHandler(this.toolStripButtonExportExcel_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Column1";
            this.dataGridViewImageColumn1.Image = global::Planning.Properties.Resources.Add;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 33);
            this.panel1.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(667, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelRowCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabelRowCount
            // 
            this.toolStripLabelRowCount.Name = "toolStripLabelRowCount";
            this.toolStripLabelRowCount.Size = new System.Drawing.Size(0, 17);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colPrimaryCode
            // 
            this.colPrimaryCode.DataPropertyName = "PrimaryCode";
            this.colPrimaryCode.FillWeight = 150F;
            this.colPrimaryCode.HeaderText = "Код артикула";
            this.colPrimaryCode.Name = "colPrimaryCode";
            this.colPrimaryCode.ReadOnly = true;
            this.colPrimaryCode.Width = 150;
            // 
            // colShortDescription
            // 
            this.colShortDescription.DataPropertyName = "ShortDescription";
            this.colShortDescription.FillWeight = 300F;
            this.colShortDescription.HeaderText = "Описание";
            this.colShortDescription.Name = "colShortDescription";
            this.colShortDescription.ReadOnly = true;
            this.colShortDescription.Width = 450;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQuantity.FillWeight = 80F;
            this.colQuantity.HeaderText = "Количество";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // frmOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.tblOrderDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrderDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Детализация для входов и заказов на отгрузку";
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderDetail)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblOrderDetail;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportExcel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelRowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrimaryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
    }
}