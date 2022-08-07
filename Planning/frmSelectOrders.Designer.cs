
namespace Planning
{
    partial class frmSelectOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectOrders));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDepositor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblOrders = new System.Windows.Forms.DataGridView();
            this.colOrderLVCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderLVStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnToSelected = new System.Windows.Forms.Button();
            this.btnFromSelected = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tblSelectedOrders = new System.Windows.Forms.DataGridView();
            this.colSelOrderLVCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelOrderLVStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelOrderClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coSelOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrders)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSelectedOrders)).BeginInit();
            this.pnlToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbDepositor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtOrderId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 49);
            this.panel1.TabIndex = 0;
            // 
            // cmbDepositor
            // 
            this.cmbDepositor.FormattingEnabled = true;
            this.cmbDepositor.Location = new System.Drawing.Point(5, 22);
            this.cmbDepositor.Name = "cmbDepositor";
            this.cmbDepositor.Size = new System.Drawing.Size(259, 21);
            this.cmbDepositor.TabIndex = 11;
            this.cmbDepositor.SelectedIndexChanged += new System.EventHandler(this.cmbDepositor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Депозитор";
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(432, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(27, 20);
            this.btnFind.TabIndex = 9;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(270, 23);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(156, 20);
            this.txtOrderId.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Поиск по коду";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblOrders);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 440);
            this.panel2.TabIndex = 1;
            // 
            // tblOrders
            // 
            this.tblOrders.AllowUserToAddRows = false;
            this.tblOrders.AllowUserToDeleteRows = false;
            this.tblOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderLVCode,
            this.colOrderLVStatus,
            this.colOrderDate,
            this.colOrderClient,
            this.colOrderID});
            this.tblOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOrders.Location = new System.Drawing.Point(0, 0);
            this.tblOrders.Name = "tblOrders";
            this.tblOrders.ReadOnly = true;
            this.tblOrders.RowHeadersVisible = false;
            this.tblOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblOrders.Size = new System.Drawing.Size(446, 440);
            this.tblOrders.TabIndex = 0;
            this.tblOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tblOrders_MouseDoubleClick);
            // 
            // colOrderLVCode
            // 
            this.colOrderLVCode.DataPropertyName = "LVCode";
            this.colOrderLVCode.HeaderText = "Код";
            this.colOrderLVCode.Name = "colOrderLVCode";
            this.colOrderLVCode.ReadOnly = true;
            // 
            // colOrderLVStatus
            // 
            this.colOrderLVStatus.DataPropertyName = "LVStatus";
            this.colOrderLVStatus.HeaderText = "Статус";
            this.colOrderLVStatus.Name = "colOrderLVStatus";
            this.colOrderLVStatus.ReadOnly = true;
            // 
            // colOrderDate
            // 
            this.colOrderDate.DataPropertyName = "ExpDate";
            this.colOrderDate.HeaderText = "Ожид. дата";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            // 
            // colOrderClient
            // 
            this.colOrderClient.DataPropertyName = "Company";
            this.colOrderClient.HeaderText = "Клиент";
            this.colOrderClient.Name = "colOrderClient";
            this.colOrderClient.ReadOnly = true;
            // 
            // colOrderID
            // 
            this.colOrderID.DataPropertyName = "LVID";
            this.colOrderID.HeaderText = "OrderID";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnToSelected);
            this.panel3.Controls.Add(this.btnFromSelected);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(446, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(34, 440);
            this.panel3.TabIndex = 2;
            // 
            // btnToSelected
            // 
            this.btnToSelected.Location = new System.Drawing.Point(3, 156);
            this.btnToSelected.Name = "btnToSelected";
            this.btnToSelected.Size = new System.Drawing.Size(28, 23);
            this.btnToSelected.TabIndex = 2;
            this.btnToSelected.Text = ">";
            this.btnToSelected.UseVisualStyleBackColor = true;
            this.btnToSelected.Click += new System.EventHandler(this.btnToSelected_Click);
            // 
            // btnFromSelected
            // 
            this.btnFromSelected.Location = new System.Drawing.Point(3, 185);
            this.btnFromSelected.Name = "btnFromSelected";
            this.btnFromSelected.Size = new System.Drawing.Size(28, 23);
            this.btnFromSelected.TabIndex = 3;
            this.btnFromSelected.Text = "<";
            this.btnFromSelected.UseVisualStyleBackColor = true;
            this.btnFromSelected.Click += new System.EventHandler(this.btnFromSelected_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tblSelectedOrders);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(480, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(478, 440);
            this.panel4.TabIndex = 3;
            // 
            // tblSelectedOrders
            // 
            this.tblSelectedOrders.AllowUserToAddRows = false;
            this.tblSelectedOrders.AllowUserToDeleteRows = false;
            this.tblSelectedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSelectedOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelOrderLVCode,
            this.colSelOrderLVStatus,
            this.colSelOrderDate,
            this.colSelOrderClient,
            this.coSelOrderID});
            this.tblSelectedOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSelectedOrders.Location = new System.Drawing.Point(0, 0);
            this.tblSelectedOrders.Name = "tblSelectedOrders";
            this.tblSelectedOrders.ReadOnly = true;
            this.tblSelectedOrders.RowHeadersVisible = false;
            this.tblSelectedOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSelectedOrders.Size = new System.Drawing.Size(478, 440);
            this.tblSelectedOrders.TabIndex = 1;
            this.tblSelectedOrders.DoubleClick += new System.EventHandler(this.tblSelectedOrders_DoubleClick);
            // 
            // colSelOrderLVCode
            // 
            this.colSelOrderLVCode.DataPropertyName = "LVCode";
            this.colSelOrderLVCode.HeaderText = "Код";
            this.colSelOrderLVCode.Name = "colSelOrderLVCode";
            this.colSelOrderLVCode.ReadOnly = true;
            // 
            // colSelOrderLVStatus
            // 
            this.colSelOrderLVStatus.DataPropertyName = "LVStatus";
            this.colSelOrderLVStatus.HeaderText = "Статус";
            this.colSelOrderLVStatus.Name = "colSelOrderLVStatus";
            this.colSelOrderLVStatus.ReadOnly = true;
            // 
            // colSelOrderDate
            // 
            this.colSelOrderDate.DataPropertyName = "ExpDate";
            this.colSelOrderDate.HeaderText = "Ожид. дата";
            this.colSelOrderDate.Name = "colSelOrderDate";
            this.colSelOrderDate.ReadOnly = true;
            // 
            // colSelOrderClient
            // 
            this.colSelOrderClient.DataPropertyName = "Company";
            this.colSelOrderClient.HeaderText = "Клиент";
            this.colSelOrderClient.Name = "colSelOrderClient";
            this.colSelOrderClient.ReadOnly = true;
            // 
            // coSelOrderID
            // 
            this.coSelOrderID.DataPropertyName = "LVID";
            this.coSelOrderID.HeaderText = "coSelOrderID";
            this.coSelOrderID.Name = "coSelOrderID";
            this.coSelOrderID.ReadOnly = true;
            this.coSelOrderID.Visible = false;
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnCancel);
            this.pnlToolBar.Controls.Add(this.btnOk);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 489);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(958, 30);
            this.pnlToolBar.TabIndex = 4;
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
            // frmSelectOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 519);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "frmSelectOrders";
            this.Text = "Заказы";
            this.Load += new System.EventHandler(this.frmSelectOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOrders)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSelectedOrders)).EndInit();
            this.pnlToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tblOrders;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView tblSelectedOrders;
        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbDepositor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToSelected;
        private System.Windows.Forms.Button btnFromSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderLVCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderLVStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelOrderLVCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelOrderLVStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelOrderClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn coSelOrderID;
    }
}