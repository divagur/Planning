
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
            this.ComponentTB = new System.Windows.Forms.TextBox();
            this.ComponentLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ComponentTB
            // 
            this.ComponentTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComponentTB.Location = new System.Drawing.Point(0, 0);
            this.ComponentTB.Name = "ComponentTB";
            this.ComponentTB.Size = new System.Drawing.Size(391, 20);
            this.ComponentTB.TabIndex = 0;
            // 
            // ComponentLB
            // 
            this.ComponentLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComponentLB.AutoSize = true;
            this.ComponentLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComponentLB.Location = new System.Drawing.Point(373, 2);
            this.ComponentLB.MaximumSize = new System.Drawing.Size(0, 20);
            this.ComponentLB.MinimumSize = new System.Drawing.Size(0, 16);
            this.ComponentLB.Name = "ComponentLB";
            this.ComponentLB.Size = new System.Drawing.Size(18, 16);
            this.ComponentLB.TabIndex = 1;
            this.ComponentLB.Text = "...";
            // 
            // ButtonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComponentLB);
            this.Controls.Add(this.ComponentTB);
            this.Name = "ButtonEdit";
            this.Size = new System.Drawing.Size(391, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ComponentTB;
        private System.Windows.Forms.Label ComponentLB;
    }
}
