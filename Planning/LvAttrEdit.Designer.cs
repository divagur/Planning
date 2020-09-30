namespace Planning
{
    partial class LvAttrEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LvAttrEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLVAttr = new System.Windows.Forms.ComboBox();
            this.cmbPLAttr = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAttrType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Аттрибут Lvision";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Аттрибут Planning";
            // 
            // cmbLVAttr
            // 
            this.cmbLVAttr.FormattingEnabled = true;
            this.cmbLVAttr.Location = new System.Drawing.Point(105, 33);
            this.cmbLVAttr.Name = "cmbLVAttr";
            this.cmbLVAttr.Size = new System.Drawing.Size(262, 21);
            this.cmbLVAttr.TabIndex = 1;
            // 
            // cmbPLAttr
            // 
            this.cmbPLAttr.FormattingEnabled = true;
            this.cmbPLAttr.Location = new System.Drawing.Point(105, 60);
            this.cmbPLAttr.Name = "cmbPLAttr";
            this.cmbPLAttr.Size = new System.Drawing.Size(262, 21);
            this.cmbPLAttr.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(215, 87);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Тип аттрибута";
            // 
            // cmbAttrType
            // 
            this.cmbAttrType.FormattingEnabled = true;
            this.cmbAttrType.Items.AddRange(new object[] {
            "Отгрузка",
            "Приход"});
            this.cmbAttrType.Location = new System.Drawing.Point(105, 6);
            this.cmbAttrType.Name = "cmbAttrType";
            this.cmbAttrType.Size = new System.Drawing.Size(185, 21);
            this.cmbAttrType.TabIndex = 16;
            this.cmbAttrType.SelectedIndexChanged += new System.EventHandler(this.cmbAttrType_SelectedIndexChanged);
            // 
            // LvAttrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 115);
            this.Controls.Add(this.cmbAttrType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbPLAttr);
            this.Controls.Add(this.cmbLVAttr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LvAttrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование аттрибута";
            this.Load += new System.EventHandler(this.LvAttrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLVAttr;
        private System.Windows.Forms.ComboBox cmbPLAttr;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAttrType;
    }
}