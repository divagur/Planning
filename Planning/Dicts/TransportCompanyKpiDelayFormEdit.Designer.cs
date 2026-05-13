namespace Planning
{
    partial class TransportCompanyKpiDelayFormEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeDelayMask = new System.Windows.Forms.MaskedTextBox();
            this.txtKPI = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtKPI)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(95, 77);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(176, 77);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Время опоздания (чч:мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Показатель KPI (%)";
            // 
            // txtTimeDelayMask
            // 
            this.txtTimeDelayMask.Location = new System.Drawing.Point(153, 6);
            this.txtTimeDelayMask.Mask = "00:00";
            this.txtTimeDelayMask.Name = "txtTimeDelayMask";
            this.txtTimeDelayMask.Size = new System.Drawing.Size(100, 20);
            this.txtTimeDelayMask.TabIndex = 4;
            // 
            // txtKPI
            // 
            this.txtKPI.Location = new System.Drawing.Point(123, 38);
            this.txtKPI.Name = "txtKPI";
            this.txtKPI.Size = new System.Drawing.Size(58, 20);
            this.txtKPI.TabIndex = 5;
            // 
            // TransportCompanyKpiDelayFormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 106);
            this.Controls.Add(this.txtKPI);
            this.Controls.Add(this.txtTimeDelayMask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TransportCompanyKpiDelayFormEdit";
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTimeDelayMask, 0);
            this.Controls.SetChildIndex(this.txtKPI, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtKPI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTimeDelayMask;
        private System.Windows.Forms.NumericUpDown txtKPI;
    }
}