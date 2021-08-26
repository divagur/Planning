
namespace Planning
{
    partial class frmVolumeCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVolumeCalc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCalc = new System.Windows.Forms.ToolStripButton();
            this.btnChooseOrder = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeightTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolumeTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaletWeight = new System.Windows.Forms.TextBox();
            this.txtPaletHeigth = new System.Windows.Forms.TextBox();
            this.txtPaletVolume = new System.Windows.Forms.TextBox();
            this.txtPaletDimension = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPalletAmountOrder = new System.Windows.Forms.TextBox();
            this.txtVolumeOrder = new System.Windows.Forms.TextBox();
            this.txtWeightOrder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWeightTotal = new System.Windows.Forms.TextBox();
            this.txtVolumeTotal = new System.Windows.Forms.TextBox();
            this.txtPalletAmountTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHeightTotal = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCalc,
            this.btnChooseOrder,
            this.btnImport,
            this.btnExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(948, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCalc
            // 
            this.btnCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCalc.Image = ((System.Drawing.Image)(resources.GetObject("btnCalc.Image")));
            this.btnCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(23, 22);
            this.btnCalc.Text = "toolStripButton1";
            // 
            // btnChooseOrder
            // 
            this.btnChooseOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChooseOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseOrder.Image")));
            this.btnChooseOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChooseOrder.Name = "btnChooseOrder";
            this.btnChooseOrder.Size = new System.Drawing.Size(23, 22);
            this.btnChooseOrder.Text = "toolStripButton2";
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 22);
            this.btnImport.Text = "toolStripButton3";
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Text = "toolStripButton4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 189);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colAmount,
            this.colWeight,
            this.colVolume,
            this.colWeightTotal,
            this.colVolumeTotal,
            this.colHeight,
            this.colLength,
            this.colWidth});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(948, 294);
            this.dataGridView1.TabIndex = 2;
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "Код товара";
            this.colProductId.Name = "colProductId";
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Наименование товара";
            this.colProductName.Name = "colProductName";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Кол-во, шт.";
            this.colAmount.Name = "colAmount";
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "Вес, шт.";
            this.colWeight.Name = "colWeight";
            // 
            // colVolume
            // 
            this.colVolume.HeaderText = "Объем, шт.";
            this.colVolume.Name = "colVolume";
            // 
            // colWeightTotal
            // 
            this.colWeightTotal.HeaderText = "Вес, общий";
            this.colWeightTotal.Name = "colWeightTotal";
            // 
            // colVolumeTotal
            // 
            this.colVolumeTotal.HeaderText = "Объем, общий";
            this.colVolumeTotal.Name = "colVolumeTotal";
            // 
            // colHeight
            // 
            this.colHeight.HeaderText = "Высота";
            this.colHeight.Name = "colHeight";
            // 
            // colLength
            // 
            this.colLength.HeaderText = "Длина";
            this.colLength.Name = "colLength";
            // 
            // colWidth
            // 
            this.colWidth.HeaderText = "Ширина";
            this.colWidth.Name = "colWidth";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPaletDimension);
            this.groupBox1.Controls.Add(this.txtPaletVolume);
            this.groupBox1.Controls.Add(this.txtPaletHeigth);
            this.groupBox1.Controls.Add(this.txtPaletWeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры паллеты";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Высота";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Объем";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Габариты";
            // 
            // txtPaletWeight
            // 
            this.txtPaletWeight.Location = new System.Drawing.Point(15, 32);
            this.txtPaletWeight.Name = "txtPaletWeight";
            this.txtPaletWeight.Size = new System.Drawing.Size(100, 20);
            this.txtPaletWeight.TabIndex = 1;
            // 
            // txtPaletHeigth
            // 
            this.txtPaletHeigth.Location = new System.Drawing.Point(121, 32);
            this.txtPaletHeigth.Name = "txtPaletHeigth";
            this.txtPaletHeigth.Size = new System.Drawing.Size(100, 20);
            this.txtPaletHeigth.TabIndex = 1;
            // 
            // txtPaletVolume
            // 
            this.txtPaletVolume.Location = new System.Drawing.Point(227, 32);
            this.txtPaletVolume.Name = "txtPaletVolume";
            this.txtPaletVolume.Size = new System.Drawing.Size(100, 20);
            this.txtPaletVolume.TabIndex = 1;
            // 
            // txtPaletDimension
            // 
            this.txtPaletDimension.Location = new System.Drawing.Point(331, 32);
            this.txtPaletDimension.Name = "txtPaletDimension";
            this.txtPaletDimension.Size = new System.Drawing.Size(100, 20);
            this.txtPaletDimension.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHeightTotal);
            this.groupBox2.Controls.Add(this.txtPalletAmountTotal);
            this.groupBox2.Controls.Add(this.txtVolumeTotal);
            this.groupBox2.Controls.Add(this.txtPalletAmountOrder);
            this.groupBox2.Controls.Add(this.txtWeightTotal);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtVolumeOrder);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtWeightOrder);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 125);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты рассчета";
            // 
            // txtPalletAmountOrder
            // 
            this.txtPalletAmountOrder.Location = new System.Drawing.Point(260, 37);
            this.txtPalletAmountOrder.Name = "txtPalletAmountOrder";
            this.txtPalletAmountOrder.Size = new System.Drawing.Size(124, 20);
            this.txtPalletAmountOrder.TabIndex = 5;
            // 
            // txtVolumeOrder
            // 
            this.txtVolumeOrder.Location = new System.Drawing.Point(138, 37);
            this.txtVolumeOrder.Name = "txtVolumeOrder";
            this.txtVolumeOrder.Size = new System.Drawing.Size(116, 20);
            this.txtVolumeOrder.TabIndex = 6;
            // 
            // txtWeightOrder
            // 
            this.txtWeightOrder.Location = new System.Drawing.Point(15, 37);
            this.txtWeightOrder.Name = "txtWeightOrder";
            this.txtWeightOrder.Size = new System.Drawing.Size(116, 20);
            this.txtWeightOrder.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Кол-во паллет в заказе";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Объем заказа";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Вес заказа";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Вес общий";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(132, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Объем общий";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Кол-во паллет";
            // 
            // txtWeightTotal
            // 
            this.txtWeightTotal.Location = new System.Drawing.Point(13, 92);
            this.txtWeightTotal.Name = "txtWeightTotal";
            this.txtWeightTotal.Size = new System.Drawing.Size(116, 20);
            this.txtWeightTotal.TabIndex = 7;
            // 
            // txtVolumeTotal
            // 
            this.txtVolumeTotal.Location = new System.Drawing.Point(135, 92);
            this.txtVolumeTotal.Name = "txtVolumeTotal";
            this.txtVolumeTotal.Size = new System.Drawing.Size(116, 20);
            this.txtVolumeTotal.TabIndex = 6;
            // 
            // txtPalletAmountTotal
            // 
            this.txtPalletAmountTotal.Location = new System.Drawing.Point(257, 92);
            this.txtPalletAmountTotal.Name = "txtPalletAmountTotal";
            this.txtPalletAmountTotal.Size = new System.Drawing.Size(116, 20);
            this.txtPalletAmountTotal.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(376, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Высота";
            // 
            // txtHeightTotal
            // 
            this.txtHeightTotal.Location = new System.Drawing.Point(379, 92);
            this.txtHeightTotal.Name = "txtHeightTotal";
            this.txtHeightTotal.Size = new System.Drawing.Size(116, 20);
            this.txtHeightTotal.TabIndex = 5;
            // 
            // frmVolumeCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 508);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmVolumeCalc";
            this.Text = "frmVolumeCalc";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCalc;
        private System.Windows.Forms.ToolStripButton btnChooseOrder;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPaletDimension;
        private System.Windows.Forms.TextBox txtPaletVolume;
        private System.Windows.Forms.TextBox txtPaletHeigth;
        private System.Windows.Forms.TextBox txtPaletWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeightTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolumeTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPalletAmountOrder;
        private System.Windows.Forms.TextBox txtVolumeOrder;
        private System.Windows.Forms.TextBox txtWeightOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHeightTotal;
        private System.Windows.Forms.TextBox txtPalletAmountTotal;
        private System.Windows.Forms.TextBox txtVolumeTotal;
        private System.Windows.Forms.TextBox txtWeightTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}