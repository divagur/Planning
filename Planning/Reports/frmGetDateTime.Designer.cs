
namespace Planning
{
    partial class frmGetDateTime
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
            this.pnGetDateTime = new System.Windows.Forms.Panel();
            this.btnCalendarCancel = new System.Windows.Forms.Button();
            this.btnCalendarOk = new System.Windows.Forms.Button();
            this.dtSpecialTime = new System.Windows.Forms.DateTimePicker();
            this.monthCalendarSpecial = new System.Windows.Forms.MonthCalendar();
            this.pnGetDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnGetDateTime
            // 
            this.pnGetDateTime.Controls.Add(this.btnCalendarCancel);
            this.pnGetDateTime.Controls.Add(this.btnCalendarOk);
            this.pnGetDateTime.Controls.Add(this.dtSpecialTime);
            this.pnGetDateTime.Controls.Add(this.monthCalendarSpecial);
            this.pnGetDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGetDateTime.Location = new System.Drawing.Point(0, 0);
            this.pnGetDateTime.Name = "pnGetDateTime";
            this.pnGetDateTime.Size = new System.Drawing.Size(166, 191);
            this.pnGetDateTime.TabIndex = 38;
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
            this.btnCalendarOk.Location = new System.Drawing.Point(9, 163);
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
            this.dtSpecialTime.Size = new System.Drawing.Size(166, 20);
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
            // frmGetDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 191);
            this.Controls.Add(this.pnGetDateTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGetDateTime";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.frmGetDateTime_Shown);
            this.pnGetDateTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnGetDateTime;
        private System.Windows.Forms.Button btnCalendarCancel;
        private System.Windows.Forms.Button btnCalendarOk;
        private System.Windows.Forms.DateTimePicker dtSpecialTime;
        private System.Windows.Forms.MonthCalendar monthCalendarSpecial;
    }
}