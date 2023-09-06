
namespace Planning
{
    partial class RepStatistic
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edYear = new System.Windows.Forms.MaskedTextBox();
            this.cmbMonthBegin = new System.Windows.Forms.ComboBox();
            this.cmbMonthEnd = new System.Windows.Forms.ComboBox();
            this.edAdmCoeff = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(131, 126);
            this.btnClose.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(22, 126);
            this.btnOk.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Месяц с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Коэф. допуска (мин.)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Месяц по";
            // 
            // edYear
            // 
            this.edYear.Location = new System.Drawing.Point(43, 6);
            this.edYear.Mask = "0000";
            this.edYear.Name = "edYear";
            this.edYear.Size = new System.Drawing.Size(100, 20);
            this.edYear.TabIndex = 0;
            this.edYear.ValidatingType = typeof(int);
            this.edYear.MouseEnter += new System.EventHandler(this.edYear_MouseEnter);
            // 
            // cmbMonthBegin
            // 
            this.cmbMonthBegin.FormattingEnabled = true;
            this.cmbMonthBegin.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.cmbMonthBegin.Location = new System.Drawing.Point(67, 32);
            this.cmbMonthBegin.Name = "cmbMonthBegin";
            this.cmbMonthBegin.Size = new System.Drawing.Size(121, 21);
            this.cmbMonthBegin.TabIndex = 1;
            // 
            // cmbMonthEnd
            // 
            this.cmbMonthEnd.FormattingEnabled = true;
            this.cmbMonthEnd.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.cmbMonthEnd.Location = new System.Drawing.Point(67, 59);
            this.cmbMonthEnd.Name = "cmbMonthEnd";
            this.cmbMonthEnd.Size = new System.Drawing.Size(121, 21);
            this.cmbMonthEnd.TabIndex = 2;
            // 
            // edAdmCoeff
            // 
            this.edAdmCoeff.Location = new System.Drawing.Point(131, 86);
            this.edAdmCoeff.Mask = "0000";
            this.edAdmCoeff.Name = "edAdmCoeff";
            this.edAdmCoeff.Size = new System.Drawing.Size(100, 20);
            this.edAdmCoeff.TabIndex = 3;
            this.edAdmCoeff.ValidatingType = typeof(int);
            this.edAdmCoeff.MouseEnter += new System.EventHandler(this.edYear_MouseEnter);
            // 
            // RepStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(241, 157);
            this.Controls.Add(this.cmbMonthEnd);
            this.Controls.Add(this.cmbMonthBegin);
            this.Controls.Add(this.edAdmCoeff);
            this.Controls.Add(this.edYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RepStatistic";
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.edYear, 0);
            this.Controls.SetChildIndex(this.edAdmCoeff, 0);
            this.Controls.SetChildIndex(this.cmbMonthBegin, 0);
            this.Controls.SetChildIndex(this.cmbMonthEnd, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox edYear;
        private System.Windows.Forms.ComboBox cmbMonthBegin;
        private System.Windows.Forms.ComboBox cmbMonthEnd;
        private System.Windows.Forms.MaskedTextBox edAdmCoeff;
    }
}
