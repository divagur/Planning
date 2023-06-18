
namespace Planning
{
    partial class ShipmentOrderPartsEdit
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
            this.edOrderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPalletAmount = new System.Windows.Forms.TextBox();
            this.txtManualUnload = new System.Windows.Forms.TextBox();
            this.txtManualLoad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGetOrderParts = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edOrderId
            // 
            this.edOrderId.Location = new System.Drawing.Point(96, 12);
            this.edOrderId.Name = "edOrderId";
            this.edOrderId.ReadOnly = true;
            this.edOrderId.Size = new System.Drawing.Size(229, 20);
            this.edOrderId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Код заказа";
            // 
            // txtPalletAmount
            // 
            this.txtPalletAmount.Location = new System.Drawing.Point(154, 152);
            this.txtPalletAmount.Name = "txtPalletAmount";
            this.txtPalletAmount.Size = new System.Drawing.Size(171, 20);
            this.txtPalletAmount.TabIndex = 9;
            // 
            // txtManualUnload
            // 
            this.txtManualUnload.Location = new System.Drawing.Point(154, 127);
            this.txtManualUnload.Name = "txtManualUnload";
            this.txtManualUnload.Size = new System.Drawing.Size(171, 20);
            this.txtManualUnload.TabIndex = 8;
            // 
            // txtManualLoad
            // 
            this.txtManualLoad.Location = new System.Drawing.Point(154, 99);
            this.txtManualLoad.Name = "txtManualLoad";
            this.txtManualLoad.Size = new System.Drawing.Size(171, 20);
            this.txtManualLoad.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Количество паллет";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ручная разрузка коробов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ручная загрузка коробов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Код расходной партии";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 13;
            // 
            // btnGetOrderParts
            // 
            this.btnGetOrderParts.Location = new System.Drawing.Point(301, 49);
            this.btnGetOrderParts.Name = "btnGetOrderParts";
            this.btnGetOrderParts.Size = new System.Drawing.Size(24, 20);
            this.btnGetOrderParts.TabIndex = 14;
            this.btnGetOrderParts.Text = "...";
            this.btnGetOrderParts.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(169, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(250, 187);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ShipmentOrderPartsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 224);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGetOrderParts);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPalletAmount);
            this.Controls.Add(this.txtManualUnload);
            this.Controls.Add(this.txtManualLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edOrderId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShipmentOrderPartsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование расходной партии";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edOrderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPalletAmount;
        private System.Windows.Forms.TextBox txtManualUnload;
        private System.Windows.Forms.TextBox txtManualLoad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGetOrderParts;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}