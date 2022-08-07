
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCalc = new System.Windows.Forms.ToolStripButton();
            this.btnChooseOrder = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHeightTotal = new System.Windows.Forms.TextBox();
            this.txtPalletAmountTotal = new System.Windows.Forms.TextBox();
            this.txtVolumeTotal = new System.Windows.Forms.TextBox();
            this.txtPalletAmountOrder = new System.Windows.Forms.TextBox();
            this.txtWeightTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVolumeOrder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWeightOrder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbConstantTemplate = new System.Windows.Forms.ComboBox();
            this.txtPalletDimension = new System.Windows.Forms.TextBox();
            this.txtPalletVolume = new System.Windows.Forms.TextBox();
            this.txtPalletHeigth = new System.Windows.Forms.TextBox();
            this.txtPalletWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblProducts = new System.Windows.Forms.DataGridView();
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
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblProducts)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1057, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCalc
            // 
            this.btnCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCalc.Enabled = false;
            this.btnCalc.Image = ((System.Drawing.Image)(resources.GetObject("btnCalc.Image")));
            this.btnCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(23, 22);
            this.btnCalc.Text = "Запустить расчет";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnChooseOrder
            // 
            this.btnChooseOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChooseOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseOrder.Image")));
            this.btnChooseOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChooseOrder.Name = "btnChooseOrder";
            this.btnChooseOrder.Size = new System.Drawing.Size(23, 22);
            this.btnChooseOrder.Text = "Выбрать заказы для расчета";
            this.btnChooseOrder.Click += new System.EventHandler(this.btnChooseOrder_Click);
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(23, 22);
            this.btnImport.Text = "Импорт";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Text = "Экспорт";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 226);
            this.panel1.TabIndex = 1;
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
            this.groupBox2.Location = new System.Drawing.Point(0, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1057, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты рассчета";
            // 
            // txtHeightTotal
            // 
            this.txtHeightTotal.Location = new System.Drawing.Point(379, 92);
            this.txtHeightTotal.Name = "txtHeightTotal";
            this.txtHeightTotal.ReadOnly = true;
            this.txtHeightTotal.Size = new System.Drawing.Size(116, 20);
            this.txtHeightTotal.TabIndex = 6;
            // 
            // txtPalletAmountTotal
            // 
            this.txtPalletAmountTotal.Location = new System.Drawing.Point(257, 92);
            this.txtPalletAmountTotal.Name = "txtPalletAmountTotal";
            this.txtPalletAmountTotal.ReadOnly = true;
            this.txtPalletAmountTotal.Size = new System.Drawing.Size(116, 20);
            this.txtPalletAmountTotal.TabIndex = 5;
            // 
            // txtVolumeTotal
            // 
            this.txtVolumeTotal.Location = new System.Drawing.Point(135, 92);
            this.txtVolumeTotal.Name = "txtVolumeTotal";
            this.txtVolumeTotal.ReadOnly = true;
            this.txtVolumeTotal.Size = new System.Drawing.Size(116, 20);
            this.txtVolumeTotal.TabIndex = 4;
            // 
            // txtPalletAmountOrder
            // 
            this.txtPalletAmountOrder.Location = new System.Drawing.Point(260, 37);
            this.txtPalletAmountOrder.Name = "txtPalletAmountOrder";
            this.txtPalletAmountOrder.ReadOnly = true;
            this.txtPalletAmountOrder.Size = new System.Drawing.Size(124, 20);
            this.txtPalletAmountOrder.TabIndex = 2;
            // 
            // txtWeightTotal
            // 
            this.txtWeightTotal.Location = new System.Drawing.Point(13, 92);
            this.txtWeightTotal.Name = "txtWeightTotal";
            this.txtWeightTotal.ReadOnly = true;
            this.txtWeightTotal.Size = new System.Drawing.Size(116, 20);
            this.txtWeightTotal.TabIndex = 3;
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
            // txtVolumeOrder
            // 
            this.txtVolumeOrder.Location = new System.Drawing.Point(138, 37);
            this.txtVolumeOrder.Name = "txtVolumeOrder";
            this.txtVolumeOrder.ReadOnly = true;
            this.txtVolumeOrder.Size = new System.Drawing.Size(116, 20);
            this.txtVolumeOrder.TabIndex = 1;
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
            // txtWeightOrder
            // 
            this.txtWeightOrder.Location = new System.Drawing.Point(15, 37);
            this.txtWeightOrder.Name = "txtWeightOrder";
            this.txtWeightOrder.ReadOnly = true;
            this.txtWeightOrder.Size = new System.Drawing.Size(116, 20);
            this.txtWeightOrder.TabIndex = 0;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Кол-во паллет в заказе";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveTemplate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbConstantTemplate);
            this.groupBox1.Controls.Add(this.txtPalletDimension);
            this.groupBox1.Controls.Add(this.txtPalletVolume);
            this.groupBox1.Controls.Add(this.txtPalletHeigth);
            this.groupBox1.Controls.Add(this.txtPalletWeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1057, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры паллеты";
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveTemplate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveTemplate.BackgroundImage")));
            this.btnSaveTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveTemplate.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveTemplate.Location = new System.Drawing.Point(409, 17);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnSaveTemplate.TabIndex = 6;
            this.btnSaveTemplate.UseVisualStyleBackColor = false;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Шаблон";
            // 
            // cmbConstantTemplate
            // 
            this.cmbConstantTemplate.FormattingEnabled = true;
            this.cmbConstantTemplate.Location = new System.Drawing.Point(63, 19);
            this.cmbConstantTemplate.Name = "cmbConstantTemplate";
            this.cmbConstantTemplate.Size = new System.Drawing.Size(341, 21);
            this.cmbConstantTemplate.TabIndex = 4;
            this.cmbConstantTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbConstantTemplate_SelectedIndexChanged);
            // 
            // txtPalletDimension
            // 
            this.txtPalletDimension.Location = new System.Drawing.Point(331, 67);
            this.txtPalletDimension.Name = "txtPalletDimension";
            this.txtPalletDimension.Size = new System.Drawing.Size(100, 20);
            this.txtPalletDimension.TabIndex = 3;
            this.txtPalletDimension.Text = "0.0";
            this.txtPalletDimension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalletWeight_KeyPress);
            // 
            // txtPalletVolume
            // 
            this.txtPalletVolume.Location = new System.Drawing.Point(227, 67);
            this.txtPalletVolume.Name = "txtPalletVolume";
            this.txtPalletVolume.Size = new System.Drawing.Size(100, 20);
            this.txtPalletVolume.TabIndex = 2;
            this.txtPalletVolume.Text = "0.0";
            this.txtPalletVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalletWeight_KeyPress);
            // 
            // txtPalletHeigth
            // 
            this.txtPalletHeigth.Location = new System.Drawing.Point(121, 67);
            this.txtPalletHeigth.Name = "txtPalletHeigth";
            this.txtPalletHeigth.Size = new System.Drawing.Size(100, 20);
            this.txtPalletHeigth.TabIndex = 1;
            this.txtPalletHeigth.Text = "0.0";
            this.txtPalletHeigth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalletWeight_KeyPress);
            // 
            // txtPalletWeight
            // 
            this.txtPalletWeight.Location = new System.Drawing.Point(15, 67);
            this.txtPalletWeight.Name = "txtPalletWeight";
            this.txtPalletWeight.Size = new System.Drawing.Size(100, 20);
            this.txtPalletWeight.TabIndex = 0;
            this.txtPalletWeight.Text = "0.0";
            this.txtPalletWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPalletWeight_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Габариты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Объем";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Высота";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вес";
            // 
            // tblProducts
            // 
            this.tblProducts.AllowUserToAddRows = false;
            this.tblProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblProducts.Location = new System.Drawing.Point(0, 251);
            this.tblProducts.Name = "tblProducts";
            this.tblProducts.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblProducts.Size = new System.Drawing.Size(1057, 311);
            this.tblProducts.TabIndex = 2;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "prdCode";
            this.colProductId.HeaderText = "Код товара";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "prdName";
            this.colProductName.HeaderText = "Наименование товара";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Qty";
            this.colAmount.HeaderText = "Кол-во, шт.";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            this.colWeight.HeaderText = "Вес, шт.";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colVolume
            // 
            this.colVolume.DataPropertyName = "Volume";
            this.colVolume.HeaderText = "Объем, шт.";
            this.colVolume.Name = "colVolume";
            this.colVolume.ReadOnly = true;
            // 
            // colWeightTotal
            // 
            this.colWeightTotal.DataPropertyName = "TotalWeight";
            this.colWeightTotal.HeaderText = "Вес, общий";
            this.colWeightTotal.Name = "colWeightTotal";
            this.colWeightTotal.ReadOnly = true;
            // 
            // colVolumeTotal
            // 
            this.colVolumeTotal.DataPropertyName = "TotalVolume";
            this.colVolumeTotal.HeaderText = "Объем, общий";
            this.colVolumeTotal.Name = "colVolumeTotal";
            this.colVolumeTotal.ReadOnly = true;
            // 
            // colHeight
            // 
            this.colHeight.DataPropertyName = "Height";
            this.colHeight.HeaderText = "Высота";
            this.colHeight.Name = "colHeight";
            this.colHeight.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Длина";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "Width";
            this.colWidth.HeaderText = "Ширина";
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            // 
            // frmVolumeCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 562);
            this.Controls.Add(this.tblProducts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmVolumeCalc";
            this.Text = "Расчет объема заказа";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblProducts)).EndInit();
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
        private System.Windows.Forms.TextBox txtPalletDimension;
        private System.Windows.Forms.TextBox txtPalletVolume;
        private System.Windows.Forms.TextBox txtPalletHeigth;
        private System.Windows.Forms.TextBox txtPalletWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblProducts;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbConstantTemplate;
        private System.Windows.Forms.Button btnSaveTemplate;
    }
}