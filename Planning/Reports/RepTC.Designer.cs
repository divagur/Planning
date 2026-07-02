
namespace Planning
{
    partial class RepTC
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.edPeriodEnd = new System.Windows.Forms.TextBox();
            this.edPeriodBegin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPeriodEnd = new System.Windows.Forms.Button();
            this.btnPeriodBegin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbWarehouse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(151, 117);
            this.btnClose.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(49, 117);
            this.btnOk.TabIndex = 2;
            // 
            // edPeriodEnd
            // 
            this.edPeriodEnd.Location = new System.Drawing.Point(94, 40);
            this.edPeriodEnd.Name = "edPeriodEnd";
            this.edPeriodEnd.Size = new System.Drawing.Size(118, 20);
            this.edPeriodEnd.TabIndex = 1;
            // 
            // edPeriodBegin
            // 
            this.edPeriodBegin.Location = new System.Drawing.Point(94, 6);
            this.edPeriodBegin.Name = "edPeriodBegin";
            this.edPeriodBegin.Size = new System.Drawing.Size(118, 20);
            this.edPeriodBegin.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Окончание";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Начало";
            // 
            // btnPeriodEnd
            // 
            this.btnPeriodEnd.Image = global::Planning.Properties.Resources.calendar;
            this.btnPeriodEnd.Location = new System.Drawing.Point(218, 38);
            this.btnPeriodEnd.Name = "btnPeriodEnd";
            this.btnPeriodEnd.Size = new System.Drawing.Size(31, 22);
            this.btnPeriodEnd.TabIndex = 14;
            this.btnPeriodEnd.UseVisualStyleBackColor = true;
            this.btnPeriodEnd.Click += new System.EventHandler(this.btnPeriodBegin_Click);
            // 
            // btnPeriodBegin
            // 
            this.btnPeriodBegin.Image = global::Planning.Properties.Resources.calendar;
            this.btnPeriodBegin.Location = new System.Drawing.Point(218, 4);
            this.btnPeriodBegin.Name = "btnPeriodBegin";
            this.btnPeriodBegin.Size = new System.Drawing.Size(31, 22);
            this.btnPeriodBegin.TabIndex = 12;
            this.btnPeriodBegin.UseVisualStyleBackColor = true;
            this.btnPeriodBegin.Click += new System.EventHandler(this.btnPeriodBegin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Склад";
            // 
            // cbWarehouse
            // 
            this.cbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWarehouse.FormattingEnabled = true;
            this.cbWarehouse.Location = new System.Drawing.Point(93, 76);
            this.cbWarehouse.Name = "cbWarehouse";
            this.cbWarehouse.Size = new System.Drawing.Size(155, 21);
            this.cbWarehouse.TabIndex = 16;
            // 
            // RepTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(259, 152);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbWarehouse);
            this.Controls.Add(this.btnPeriodEnd);
            this.Controls.Add(this.edPeriodEnd);
            this.Controls.Add(this.btnPeriodBegin);
            this.Controls.Add(this.edPeriodBegin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RepTC";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edPeriodBegin, 0);
            this.Controls.SetChildIndex(this.btnPeriodBegin, 0);
            this.Controls.SetChildIndex(this.edPeriodEnd, 0);
            this.Controls.SetChildIndex(this.btnPeriodEnd, 0);
            this.Controls.SetChildIndex(this.cbWarehouse, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPeriodEnd;
        private System.Windows.Forms.TextBox edPeriodEnd;
        private System.Windows.Forms.Button btnPeriodBegin;
        private System.Windows.Forms.TextBox edPeriodBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbWarehouse;
    }
}
