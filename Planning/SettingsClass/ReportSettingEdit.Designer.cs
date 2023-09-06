
namespace Planning
{
    partial class ReportSettingEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSettingEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.btnGetTemplate = new System.Windows.Forms.Button();
            this.edTemplate = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
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
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Шаблон";
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(101, 6);
            this.edName.Name = "edName";
            this.edName.ReadOnly = true;
            this.edName.Size = new System.Drawing.Size(288, 20);
            this.edName.TabIndex = 1;
            // 
            // btnGetTemplate
            // 
            this.btnGetTemplate.Location = new System.Drawing.Point(357, 33);
            this.btnGetTemplate.Name = "btnGetTemplate";
            this.btnGetTemplate.Size = new System.Drawing.Size(27, 20);
            this.btnGetTemplate.TabIndex = 4;
            this.btnGetTemplate.Text = "...";
            this.btnGetTemplate.UseVisualStyleBackColor = true;
            this.btnGetTemplate.Click += new System.EventHandler(this.btnShipmentDlg_Click);
            // 
            // edTemplate
            // 
            this.edTemplate.Location = new System.Drawing.Point(64, 33);
            this.edTemplate.Name = "edTemplate";
            this.edTemplate.Size = new System.Drawing.Size(287, 20);
            this.edTemplate.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(293, 73);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(184, 73);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "\"Excel|*.xltx| Excel macros| *xltm\"";
            this.openFileDialog.Title = "Шаблоны отчетов";
            // 
            // ReportSettingEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 110);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnGetTemplate);
            this.Controls.Add(this.edTemplate);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportSettingEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки отчета";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.Button btnGetTemplate;
        private System.Windows.Forms.TextBox edTemplate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}