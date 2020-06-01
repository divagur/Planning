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
            this.tblAttr = new System.Windows.Forms.DataGridView();
            this.LVAttrId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PLField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LVIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbAttr = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAttr)).BeginInit();
            this.tbAttr.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "База данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Код в Lvision";
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(101, 6);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(226, 20);
            this.edName.TabIndex = 1;
            // 
            // edLvId
            // 
            this.edLvId.Location = new System.Drawing.Point(101, 79);
            this.edLvId.Name = "edLvId";
            this.edLvId.Size = new System.Drawing.Size(226, 20);
            this.edLvId.TabIndex = 1;
            // 
            // edDB
            // 
            this.edDB.Location = new System.Drawing.Point(101, 43);
            this.edDB.Name = "edDB";
            this.edDB.Size = new System.Drawing.Size(226, 20);
            this.edDB.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(377, 431);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(458, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblAttr);
            this.groupBox1.Controls.Add(this.tbAttr);
            this.groupBox1.Location = new System.Drawing.Point(15, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 307);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Аттрибуты";
            // 
            // tblAttr
            // 
            this.tblAttr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAttr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LVAttrId,
            this.PLField,
            this.LVIn});
            this.tblAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAttr.Location = new System.Drawing.Point(3, 41);
            this.tblAttr.Name = "tblAttr";
            this.tblAttr.Size = new System.Drawing.Size(512, 263);
            this.tblAttr.TabIndex = 0;
            this.tblAttr.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblAttr_CellValidated);
            // 
            // LVAttrId
            // 
            this.LVAttrId.HeaderText = "Аттрибут Lvision";
            this.LVAttrId.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.LVAttrId.Name = "LVAttrId";
            this.LVAttrId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LVAttrId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LVAttrId.Width = 200;
            // 
            // PLField
            // 
            this.PLField.HeaderText = "Аттрибут планинга";
            this.PLField.Items.AddRange(new object[] {
            "4",
            "5",
            "6"});
            this.PLField.Name = "PLField";
            this.PLField.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PLField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PLField.Width = 200;
            // 
            // LVIn
            // 
            this.LVIn.HeaderText = "LvIn";
            this.LVIn.Name = "LVIn";
            this.LVIn.Visible = false;
            // 
            // tbAttr
            // 
            this.tbAttr.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbAttr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDel});
            this.tbAttr.Location = new System.Drawing.Point(3, 16);
            this.tbAttr.Name = "tbAttr";
            this.tbAttr.Size = new System.Drawing.Size(512, 25);
            this.tbAttr.TabIndex = 1;
            this.tbAttr.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::Planning.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "toolStripButton1";
            this.btnAdd.ToolTipText = "Добавить аттрибут";
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = global::Planning.Properties.Resources.Delete;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 22);
            this.btnDel.Text = "toolStripButton2";
            this.btnDel.ToolTipText = "Удалить аттрибут";
            // 
            // DepositorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 460);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.edDB);
            this.Controls.Add(this.edLvId);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DepositorEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DepositorEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAttr)).EndInit();
            this.tbAttr.ResumeLayout(false);
            this.tbAttr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridView tblAttr;
        private System.Windows.Forms.ToolStrip tbAttr;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.DataGridViewComboBoxColumn LVAttrId;
        private System.Windows.Forms.DataGridViewComboBoxColumn PLField;
        private System.Windows.Forms.DataGridViewTextBoxColumn LVIn;
    }
}