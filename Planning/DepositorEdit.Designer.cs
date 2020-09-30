namespace Planning
{
    partial class DepositorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositorEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.edLvId = new System.Windows.Forms.TextBox();
            this.edDB = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblAttrShipment = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LVAttrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LVAttrId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLFieldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LVIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbAttr = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAttrShipment)).BeginInit();
            this.tbAttr.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "База данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID в Lvision";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(102, 22);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(226, 20);
            this.edName.TabIndex = 1;
            // 
            // edLvId
            // 
            this.edLvId.Location = new System.Drawing.Point(102, 74);
            this.edLvId.Name = "edLvId";
            this.edLvId.Size = new System.Drawing.Size(226, 20);
            this.edLvId.TabIndex = 1;
            // 
            // edDB
            // 
            this.edDB.Location = new System.Drawing.Point(102, 48);
            this.edDB.Name = "edDB";
            this.edDB.Size = new System.Drawing.Size(226, 20);
            this.edDB.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(397, 432);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(478, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblAttrShipment);
            this.groupBox1.Controls.Add(this.tbAttr);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 307);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Аттрибуты";
            // 
            // tblAttrShipment
            // 
            this.tblAttrShipment.AllowUserToAddRows = false;
            this.tblAttrShipment.AllowUserToDeleteRows = false;
            this.tblAttrShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAttrShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.LVAttrName,
            this.PLField,
            this.LVAttrId,
            this.PLFieldId,
            this.LVIn,
            this.LvType});
            this.tblAttrShipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAttrShipment.Location = new System.Drawing.Point(3, 41);
            this.tblAttrShipment.Name = "tblAttrShipment";
            this.tblAttrShipment.ReadOnly = true;
            this.tblAttrShipment.RowHeadersVisible = false;
            this.tblAttrShipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAttrShipment.Size = new System.Drawing.Size(538, 263);
            this.tblAttrShipment.TabIndex = 0;
            this.tblAttrShipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblAttr_CellContentClick);
            this.tblAttrShipment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblAttr_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // LVAttrName
            // 
            this.LVAttrName.DataPropertyName = "spa_Name";
            this.LVAttrName.HeaderText = "Аттрибут Lvision";
            this.LVAttrName.Name = "LVAttrName";
            this.LVAttrName.ReadOnly = true;
            this.LVAttrName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LVAttrName.Width = 200;
            // 
            // PLField
            // 
            this.PLField.DataPropertyName = "PLField";
            this.PLField.HeaderText = "Аттрибут планинга";
            this.PLField.Name = "PLField";
            this.PLField.ReadOnly = true;
            this.PLField.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PLField.Width = 200;
            // 
            // LVAttrId
            // 
            this.LVAttrId.DataPropertyName = "spa_ID";
            this.LVAttrId.HeaderText = "LVAttrId";
            this.LVAttrId.Name = "LVAttrId";
            this.LVAttrId.ReadOnly = true;
            this.LVAttrId.Visible = false;
            // 
            // PLFieldId
            // 
            this.PLFieldId.DataPropertyName = "PLFieldId";
            this.PLFieldId.HeaderText = "PLFieldId";
            this.PLFieldId.Name = "PLFieldId";
            this.PLFieldId.ReadOnly = true;
            this.PLFieldId.Visible = false;
            // 
            // LVIn
            // 
            this.LVIn.DataPropertyName = "lva_in";
            this.LVIn.HeaderText = "LvIn";
            this.LVIn.Name = "LVIn";
            this.LVIn.ReadOnly = true;
            this.LVIn.Visible = false;
            // 
            // LvType
            // 
            this.LvType.DataPropertyName = "lva_type";
            this.LvType.HeaderText = "Тип аттрибута";
            this.LvType.Name = "LvType";
            this.LvType.ReadOnly = true;
            // 
            // tbAttr
            // 
            this.tbAttr.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDel});
            this.tbAttr.Location = new System.Drawing.Point(3, 16);
            this.tbAttr.Name = "tbAttr";
            this.tbAttr.Size = new System.Drawing.Size(538, 25);
            this.tbAttr.TabIndex = 1;
            this.tbAttr.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::Planning.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "toolStripButton1";
            this.btnAdd.ToolTipText = "Добавить аттрибут";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::Planning.Properties.Resources.Edit;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "toolStripButton1";
            this.btnEdit.ToolTipText = "Редактировать аттрибут";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = global::Planning.Properties.Resources.Delete;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.White;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 22);
            this.btnDel.Text = "toolStripButton2";
            this.btnDel.ToolTipText = "Удалить аттрибут";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.edName);
            this.groupBox2.Controls.Add(this.edDB);
            this.groupBox2.Controls.Add(this.edLvId);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 104);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные депозитора";
            // 
            // DepositorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DepositorEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DepositorEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAttrShipment)).EndInit();
            this.tbAttr.ResumeLayout(false);
            this.tbAttr.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.TextBox edLvId;
        private System.Windows.Forms.TextBox edDB;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tblAttrShipment;
        private System.Windows.Forms.ToolStrip tbAttr;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn LVAttrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLField;
        private System.Windows.Forms.DataGridViewTextBoxColumn LVAttrId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLFieldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LVIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LvType;
    }
}