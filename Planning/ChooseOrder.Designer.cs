
namespace Planning
{
    partial class ChooseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseOrder));
            this.tblOrders = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOstCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsEDM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLVOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOstId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrders)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnlToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblOrders
            // 
            this.tblOrders.AllowUserToAddRows = false;
            this.tblOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colOstCode,
            this.colState,
            this.colDate,
            this.colKlient,
            this.colIsEDM,
            this.colLVOrderId,
            this.colOstId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOrders.Location = new System.Drawing.Point(0, 62);
            this.tblOrders.MultiSelect = false;
            this.tblOrders.Name = "tblOrders";
            this.tblOrders.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblOrders.RowHeadersVisible = false;
            this.tblOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblOrders.Size = new System.Drawing.Size(775, 396);
            this.tblOrders.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnFind);
            this.panel5.Controls.Add(this.txtOrderId);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(775, 62);
            this.panel5.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(236, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(27, 22);
            this.btnFind.TabIndex = 6;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(12, 21);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(218, 20);
            this.txtOrderId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Поиск по коду";
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnCancel);
            this.pnlToolBar.Controls.Add(this.btnOk);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 428);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(775, 30);
            this.pnlToolBar.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(86, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(5, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "LVCode";
            this.colId.HeaderText = "Код";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colOstCode
            // 
            this.colOstCode.DataPropertyName = "OstCode";
            this.colOstCode.HeaderText = "Расходная партия";
            this.colOstCode.Name = "colOstCode";
            this.colOstCode.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.DataPropertyName = "LVStatus";
            this.colState.HeaderText = "Статус";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "ExpDate";
            this.colDate.HeaderText = "Ожид. дата";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colKlient
            // 
            this.colKlient.DataPropertyName = "Company";
            this.colKlient.HeaderText = "Клиент";
            this.colKlient.Name = "colKlient";
            this.colKlient.ReadOnly = true;
            this.colKlient.Width = 200;
            // 
            // colIsEDM
            // 
            this.colIsEDM.DataPropertyName = "IsEdm";
            this.colIsEDM.HeaderText = "ЭДО";
            this.colIsEDM.Name = "colIsEDM";
            this.colIsEDM.ReadOnly = true;
            this.colIsEDM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsEDM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colLVOrderId
            // 
            this.colLVOrderId.DataPropertyName = "LVID";
            this.colLVOrderId.HeaderText = "LVOrderId";
            this.colLVOrderId.Name = "colLVOrderId";
            this.colLVOrderId.ReadOnly = true;
            this.colLVOrderId.Visible = false;
            // 
            // colOstId
            // 
            this.colOstId.HeaderText = "colOstId";
            this.colOstId.Name = "colOstId";
            this.colOstId.ReadOnly = true;
            this.colOstId.Visible = false;
            // 
            // ChooseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 458);
            this.Controls.Add(this.pnlToolBar);
            this.Controls.Add(this.tblOrders);
            this.Controls.Add(this.panel5);
            this.Name = "ChooseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заказы";
            ((System.ComponentModel.ISupportInitialize)(this.tblOrders)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblOrders;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOstCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlient;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsEDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLVOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOstId;
    }
}