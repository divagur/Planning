
namespace Planning
{
    partial class CustomPostEdit
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
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblDelivery = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomPostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDeliveryDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddDelivery = new System.Windows.Forms.ToolStripButton();
            this.btnDelDelivery = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDelivery)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 328);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 328);
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(101, 64);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(295, 79);
            this.txtDescr.TabIndex = 11;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(101, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(75, 20);
            this.txtCode.TabIndex = 12;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(295, 20);
            this.txtName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Описание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Код";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Наименование";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblDelivery);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 176);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сроки доставки до складов";
            // 
            // tblDelivery
            // 
            this.tblDelivery.AllowUserToAddRows = false;
            this.tblDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDelivery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCustomPostId,
            this.colWarehouseId,
            this.colWarehouse,
            this.colDeliveryDay});
            this.tblDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDelivery.Location = new System.Drawing.Point(3, 41);
            this.tblDelivery.Name = "tblDelivery";
            this.tblDelivery.RowHeadersVisible = false;
            this.tblDelivery.Size = new System.Drawing.Size(381, 132);
            this.tblDelivery.TabIndex = 1;
            this.tblDelivery.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblDelivery_CellValueChanged);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colCustomPostId
            // 
            this.colCustomPostId.DataPropertyName = "CustomPostId";
            this.colCustomPostId.HeaderText = "ТаможняКод";
            this.colCustomPostId.Name = "colCustomPostId";
            this.colCustomPostId.Visible = false;
            // 
            // colWarehouseId
            // 
            this.colWarehouseId.DataPropertyName = "WarehouserId";
            this.colWarehouseId.HeaderText = "СкладКод";
            this.colWarehouseId.Name = "colWarehouseId";
            this.colWarehouseId.Visible = false;
            // 
            // colWarehouse
            // 
            this.colWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colWarehouse.HeaderText = "Склад";
            this.colWarehouse.Name = "colWarehouse";
            this.colWarehouse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWarehouse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colWarehouse.Width = 200;
            // 
            // colDeliveryDay
            // 
            this.colDeliveryDay.DataPropertyName = "DeliveryDay";
            this.colDeliveryDay.HeaderText = "Срок доставки (часы)";
            this.colDeliveryDay.Name = "colDeliveryDay";
            this.colDeliveryDay.Width = 135;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDelivery,
            this.btnDelDelivery});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(381, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddDelivery
            // 
            this.btnAddDelivery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDelivery.Image = global::Planning.Properties.Resources.icons8_add_16;
            this.btnAddDelivery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDelivery.Name = "btnAddDelivery";
            this.btnAddDelivery.Size = new System.Drawing.Size(23, 22);
            this.btnAddDelivery.Text = "Добавить срок доставки";
            this.btnAddDelivery.Click += new System.EventHandler(this.btnAddDelivery_Click);
            // 
            // btnDelDelivery
            // 
            this.btnDelDelivery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelDelivery.Image = global::Planning.Properties.Resources.icons8_close_16;
            this.btnDelDelivery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelDelivery.Name = "btnDelDelivery";
            this.btnDelDelivery.Size = new System.Drawing.Size(23, 22);
            this.btnDelDelivery.Text = "Удалить срок доставки";
            this.btnDelDelivery.Click += new System.EventHandler(this.btnDelDelivery_Click);
            // 
            // CustomPostEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "CustomPostEdit";
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.txtDescr, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDelivery)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddDelivery;
        private System.Windows.Forms.DataGridView tblDelivery;
        private System.Windows.Forms.ToolStripButton btnDelDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomPostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDay;
    }
}