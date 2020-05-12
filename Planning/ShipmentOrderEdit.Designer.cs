namespace Planning
{
    partial class ShipmentOrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentOrderEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManualLoad = new System.Windows.Forms.TextBox();
            this.txtManualUnload = new System.Windows.Forms.TextBox();
            this.txtPalletAmount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код заказа";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(98, 6);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(229, 20);
            this.txtOrderId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип заказа";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Location = new System.Drawing.Point(477, 6);
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.Size = new System.Drawing.Size(163, 20);
            this.txtOrderType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Комментарий \r\nпо заказу";
            // 
            // txtOrderComment
            // 
            this.txtOrderComment.Location = new System.Drawing.Point(98, 48);
            this.txtOrderComment.Multiline = true;
            this.txtOrderComment.Name = "txtOrderComment";
            this.txtOrderComment.Size = new System.Drawing.Size(542, 71);
            this.txtOrderComment.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ручная загрузка коробов";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ручная разрузка коробов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Количество паллет";
            // 
            // txtManualLoad
            // 
            this.txtManualLoad.Location = new System.Drawing.Point(154, 138);
            this.txtManualLoad.Name = "txtManualLoad";
            this.txtManualLoad.Size = new System.Drawing.Size(100, 20);
            this.txtManualLoad.TabIndex = 7;
            // 
            // txtManualUnload
            // 
            this.txtManualUnload.Location = new System.Drawing.Point(154, 166);
            this.txtManualUnload.Name = "txtManualUnload";
            this.txtManualUnload.Size = new System.Drawing.Size(100, 20);
            this.txtManualUnload.TabIndex = 7;
            // 
            // txtPalletAmount
            // 
            this.txtPalletAmount.Location = new System.Drawing.Point(154, 191);
            this.txtPalletAmount.Name = "txtPalletAmount";
            this.txtPalletAmount.Size = new System.Drawing.Size(100, 20);
            this.txtPalletAmount.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(565, 238);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(484, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ShipmentOrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 273);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPalletAmount);
            this.Controls.Add(this.txtManualUnload);
            this.Controls.Add(this.txtManualLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOrderComment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrderType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShipmentOrderEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Редактирование заказа";
            this.Load += new System.EventHandler(this.ShipmentOrderEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrderComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtManualLoad;
        private System.Windows.Forms.TextBox txtManualUnload;
        private System.Windows.Forms.TextBox txtPalletAmount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}