
namespace Planning
{
    partial class RepPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepPeriod));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPeriodBegin = new System.Windows.Forms.Button();
            this.edPeriodBegin = new System.Windows.Forms.TextBox();
            this.btnPeriodEnd = new System.Windows.Forms.Button();
            this.edPeriodEnd = new System.Windows.Forms.TextBox();
            this.pnGetDateTime = new System.Windows.Forms.Panel();
            this.btnCalendarCancel = new System.Windows.Forms.Button();
            this.btnCalendarOk = new System.Windows.Forms.Button();
            this.dtSpecialTime = new System.Windows.Forms.DateTimePicker();
            this.monthCalendarSpecial = new System.Windows.Forms.MonthCalendar();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.pnGetDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начало";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Окончание";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип отгрузки";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(44, 109);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(153, 109);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPeriodBegin
            // 
            this.btnPeriodBegin.Image = global::Planning.Properties.Resources.calendar;
            this.btnPeriodBegin.Location = new System.Drawing.Point(218, 4);
            this.btnPeriodBegin.Name = "btnPeriodBegin";
            this.btnPeriodBegin.Size = new System.Drawing.Size(31, 22);
            this.btnPeriodBegin.TabIndex = 6;
            this.btnPeriodBegin.UseVisualStyleBackColor = true;
            this.btnPeriodBegin.Click += new System.EventHandler(this.btnPeriodBegin_Click);
            // 
            // edPeriodBegin
            // 
            this.edPeriodBegin.Location = new System.Drawing.Point(94, 6);
            this.edPeriodBegin.Name = "edPeriodBegin";
            this.edPeriodBegin.Size = new System.Drawing.Size(118, 20);
            this.edPeriodBegin.TabIndex = 5;
            // 
            // btnPeriodEnd
            // 
            this.btnPeriodEnd.Image = global::Planning.Properties.Resources.calendar;
            this.btnPeriodEnd.Location = new System.Drawing.Point(218, 38);
            this.btnPeriodEnd.Name = "btnPeriodEnd";
            this.btnPeriodEnd.Size = new System.Drawing.Size(31, 22);
            this.btnPeriodEnd.TabIndex = 8;
            this.btnPeriodEnd.UseVisualStyleBackColor = true;
            this.btnPeriodEnd.Click += new System.EventHandler(this.btnPeriodBegin_Click);
            // 
            // edPeriodEnd
            // 
            this.edPeriodEnd.Location = new System.Drawing.Point(94, 40);
            this.edPeriodEnd.Name = "edPeriodEnd";
            this.edPeriodEnd.Size = new System.Drawing.Size(118, 20);
            this.edPeriodEnd.TabIndex = 7;
            // 
            // pnGetDateTime
            // 
            this.pnGetDateTime.Controls.Add(this.btnCalendarCancel);
            this.pnGetDateTime.Controls.Add(this.btnCalendarOk);
            this.pnGetDateTime.Controls.Add(this.dtSpecialTime);
            this.pnGetDateTime.Controls.Add(this.monthCalendarSpecial);
            this.pnGetDateTime.Location = new System.Drawing.Point(355, 40);
            this.pnGetDateTime.Name = "pnGetDateTime";
            this.pnGetDateTime.Size = new System.Drawing.Size(163, 191);
            this.pnGetDateTime.TabIndex = 36;
            this.pnGetDateTime.Visible = false;
            // 
            // btnCalendarCancel
            // 
            this.btnCalendarCancel.Location = new System.Drawing.Point(85, 163);
            this.btnCalendarCancel.Name = "btnCalendarCancel";
            this.btnCalendarCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCalendarCancel.TabIndex = 3;
            this.btnCalendarCancel.Text = "Отмена";
            this.btnCalendarCancel.UseVisualStyleBackColor = true;
            this.btnCalendarCancel.Click += new System.EventHandler(this.btnCalendarCancel_Click);
            // 
            // btnCalendarOk
            // 
            this.btnCalendarOk.Location = new System.Drawing.Point(3, 163);
            this.btnCalendarOk.Name = "btnCalendarOk";
            this.btnCalendarOk.Size = new System.Drawing.Size(75, 23);
            this.btnCalendarOk.TabIndex = 2;
            this.btnCalendarOk.Text = "ОК";
            this.btnCalendarOk.UseVisualStyleBackColor = true;
            this.btnCalendarOk.Click += new System.EventHandler(this.btnCalendarOk_Click);
            // 
            // dtSpecialTime
            // 
            this.dtSpecialTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtSpecialTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtSpecialTime.Location = new System.Drawing.Point(0, 162);
            this.dtSpecialTime.Name = "dtSpecialTime";
            this.dtSpecialTime.ShowUpDown = true;
            this.dtSpecialTime.Size = new System.Drawing.Size(163, 20);
            this.dtSpecialTime.TabIndex = 1;
            this.dtSpecialTime.Visible = false;
            // 
            // monthCalendarSpecial
            // 
            this.monthCalendarSpecial.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthCalendarSpecial.Location = new System.Drawing.Point(0, 0);
            this.monthCalendarSpecial.MaxSelectionCount = 1;
            this.monthCalendarSpecial.Name = "monthCalendarSpecial";
            this.monthCalendarSpecial.TabIndex = 0;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Все",
            "Выход",
            "Вход",
            "Перемещение"});
            this.cbType.Location = new System.Drawing.Point(94, 73);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(155, 21);
            this.cbType.TabIndex = 37;
            // 
            // RepPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 139);
            this.Controls.Add(this.pnGetDateTime);
            this.Controls.Add(this.btnPeriodEnd);
            this.Controls.Add(this.edPeriodEnd);
            this.Controls.Add(this.btnPeriodBegin);
            this.Controls.Add(this.edPeriodBegin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RepPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры отчета";
            this.Load += new System.EventHandler(this.RepPeriod_Load);
            this.pnGetDateTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPeriodBegin;
        private System.Windows.Forms.TextBox edPeriodBegin;
        private System.Windows.Forms.Button btnPeriodEnd;
        private System.Windows.Forms.TextBox edPeriodEnd;
        private System.Windows.Forms.Panel pnGetDateTime;
        private System.Windows.Forms.Button btnCalendarCancel;
        private System.Windows.Forms.Button btnCalendarOk;
        private System.Windows.Forms.DateTimePicker dtSpecialTime;
        private System.Windows.Forms.MonthCalendar monthCalendarSpecial;
        private System.Windows.Forms.ComboBox cbType;
    }
}