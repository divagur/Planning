
namespace Planning
{
    partial class frmLog
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
            this.edLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // edLog
            // 
            this.edLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edLog.Location = new System.Drawing.Point(0, 0);
            this.edLog.Multiline = true;
            this.edLog.Name = "edLog";
            this.edLog.ReadOnly = true;
            this.edLog.Size = new System.Drawing.Size(1037, 609);
            this.edLog.TabIndex = 0;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 609);
            this.Controls.Add(this.edLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLog";
            this.Text = "Лог";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edLog;
    }
}