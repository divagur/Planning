
namespace Planning.Controls
{
    partial class ButtonEdit
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CompoentTB = new System.Windows.Forms.TextBox();
            this.CompoentLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CompoentTB
            // 
            this.CompoentTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompoentTB.Location = new System.Drawing.Point(0, 0);
            this.CompoentTB.Name = "CompoentTB";
            this.CompoentTB.Size = new System.Drawing.Size(391, 20);
            this.CompoentTB.TabIndex = 0;
            // 
            // CompoentLB
            // 
            this.CompoentLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CompoentLB.AutoSize = true;
            this.CompoentLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompoentLB.Location = new System.Drawing.Point(373, 2);
            this.CompoentLB.MaximumSize = new System.Drawing.Size(0, 20);
            this.CompoentLB.MinimumSize = new System.Drawing.Size(0, 16);
            this.CompoentLB.Name = "CompoentLB";
            this.CompoentLB.Size = new System.Drawing.Size(18, 16);
            this.CompoentLB.TabIndex = 1;
            this.CompoentLB.Text = "...";
            // 
            // ButtonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CompoentLB);
            this.Controls.Add(this.CompoentTB);
            this.Name = "ButtonEdit";
            this.Size = new System.Drawing.Size(391, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompoentTB;
        private System.Windows.Forms.Label CompoentLB;
    }
}
