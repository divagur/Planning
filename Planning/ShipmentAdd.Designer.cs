﻿namespace Planning
{
    partial class ShipmentAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentAdd));
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tblShipmentItem = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTimeSlot = new System.Windows.Forms.ComboBox();
            this.dtSDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnFromShipmentAll = new System.Windows.Forms.Button();
            this.btnToShipment = new System.Windows.Forms.Button();
            this.btnFromShipment = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblOrders = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbDepositor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOstCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLVOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOstId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsEDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarehouseComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemOstCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemKlient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLVOrdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemOstId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemIsEDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemOperatorComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemWarehouseComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipmentItem)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrders)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnCancel);
            this.pnlToolBar.Controls.Add(this.btnEdit);
            this.pnlToolBar.Controls.Add(this.btnOk);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 578);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(1159, 33);
            this.pnlToolBar.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(86, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(121, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 578);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tblShipmentItem);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(634, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 578);
            this.panel4.TabIndex = 2;
            // 
            // tblShipmentItem
            // 
            this.tblShipmentItem.AllowUserToAddRows = false;
            this.tblShipmentItem.AllowUserToDeleteRows = false;
            this.tblShipmentItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShipmentItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemId,
            this.colItemOstCode,
            this.colItemStatus,
            this.colItemDate,
            this.colItemKlient,
            this.colLVOrdId,
            this.colItemOstId,
            this.colItemIsEDM,
            this.colItemOperatorComment,
            this.colItemWarehouseComment});
            this.tblShipmentItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShipmentItem.Location = new System.Drawing.Point(0, 117);
            this.tblShipmentItem.Name = "tblShipmentItem";
            this.tblShipmentItem.ReadOnly = true;
            this.tblShipmentItem.RowHeadersVisible = false;
            this.tblShipmentItem.Size = new System.Drawing.Size(525, 461);
            this.tblShipmentItem.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.cmbTimeSlot);
            this.panel6.Controls.Add(this.dtSDate);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(525, 117);
            this.panel6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Таймслот";
            // 
            // cmbTimeSlot
            // 
            this.cmbTimeSlot.FormattingEnabled = true;
            this.cmbTimeSlot.Location = new System.Drawing.Point(9, 62);
            this.cmbTimeSlot.Name = "cmbTimeSlot";
            this.cmbTimeSlot.Size = new System.Drawing.Size(153, 21);
            this.cmbTimeSlot.TabIndex = 2;
            this.cmbTimeSlot.SelectedIndexChanged += new System.EventHandler(this.cmbTimeSlot_SelectedIndexChanged);
            // 
            // dtSDate
            // 
            this.dtSDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSDate.Location = new System.Drawing.Point(9, 24);
            this.dtSDate.Name = "dtSDate";
            this.dtSDate.Size = new System.Drawing.Size(153, 20);
            this.dtSDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата и слот";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFromShipmentAll);
            this.panel3.Controls.Add(this.btnToShipment);
            this.panel3.Controls.Add(this.btnFromShipment);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(606, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(28, 578);
            this.panel3.TabIndex = 1;
            // 
            // btnFromShipmentAll
            // 
            this.btnFromShipmentAll.Location = new System.Drawing.Point(0, 289);
            this.btnFromShipmentAll.Name = "btnFromShipmentAll";
            this.btnFromShipmentAll.Size = new System.Drawing.Size(28, 23);
            this.btnFromShipmentAll.TabIndex = 0;
            this.btnFromShipmentAll.Text = "<<";
            this.btnFromShipmentAll.UseVisualStyleBackColor = true;
            this.btnFromShipmentAll.Click += new System.EventHandler(this.btnFromShipmentAll_Click);
            // 
            // btnToShipment
            // 
            this.btnToShipment.Location = new System.Drawing.Point(0, 260);
            this.btnToShipment.Name = "btnToShipment";
            this.btnToShipment.Size = new System.Drawing.Size(28, 23);
            this.btnToShipment.TabIndex = 0;
            this.btnToShipment.Text = ">";
            this.btnToShipment.UseVisualStyleBackColor = true;
            this.btnToShipment.Click += new System.EventHandler(this.btnToShipment_Click);
            // 
            // btnFromShipment
            // 
            this.btnFromShipment.Location = new System.Drawing.Point(0, 231);
            this.btnFromShipment.Name = "btnFromShipment";
            this.btnFromShipment.Size = new System.Drawing.Size(28, 23);
            this.btnFromShipment.TabIndex = 0;
            this.btnFromShipment.Text = "<";
            this.btnFromShipment.UseVisualStyleBackColor = true;
            this.btnFromShipment.Click += new System.EventHandler(this.btnFromShipment_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblOrders);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 578);
            this.panel2.TabIndex = 0;
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
            this.colLVOrderId,
            this.colOstId,
            this.colIsEDM,
            this.colOperatorComment,
            this.colWarehouseComment});
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
            this.tblOrders.Size = new System.Drawing.Size(606, 516);
            this.tblOrders.TabIndex = 1;
            this.tblOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblOrders_CellContentClick);
            this.tblOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblOrders_CellDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnFind);
            this.panel5.Controls.Add(this.txtOrderId);
            this.panel5.Controls.Add(this.cmbType);
            this.panel5.Controls.Add(this.cmbDepositor);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(606, 62);
            this.panel5.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(513, 25);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(27, 22);
            this.btnFind.TabIndex = 6;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(410, 27);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(100, 20);
            this.txtOrderId.TabIndex = 5;
            this.txtOrderId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderId_KeyDown);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Выход",
            "Вход",
            "Перемещение"});
            this.cmbType.Location = new System.Drawing.Point(228, 25);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(153, 21);
            this.cmbType.TabIndex = 4;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // cmbDepositor
            // 
            this.cmbDepositor.FormattingEnabled = true;
            this.cmbDepositor.Location = new System.Drawing.Point(5, 25);
            this.cmbDepositor.Name = "cmbDepositor";
            this.cmbDepositor.Size = new System.Drawing.Size(202, 21);
            this.cmbDepositor.TabIndex = 3;
            this.cmbDepositor.SelectedIndexChanged += new System.EventHandler(this.cmbDepositor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Поиск по коду";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Депозитор";
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
            // colIsEDM
            // 
            this.colIsEDM.HeaderText = "ЭДО";
            this.colIsEDM.Name = "colIsEDM";
            this.colIsEDM.ReadOnly = true;
            // 
            // colOperatorComment
            // 
            this.colOperatorComment.HeaderText = "Комментарий для операторов";
            this.colOperatorComment.Name = "colOperatorComment";
            this.colOperatorComment.ReadOnly = true;
            // 
            // colWarehouseComment
            // 
            this.colWarehouseComment.HeaderText = "Комментарий для склада";
            this.colWarehouseComment.Name = "colWarehouseComment";
            this.colWarehouseComment.ReadOnly = true;
            // 
            // colItemId
            // 
            this.colItemId.HeaderText = "Код заказа";
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            this.colItemId.Width = 200;
            // 
            // colItemOstCode
            // 
            this.colItemOstCode.HeaderText = "Код расходной партии";
            this.colItemOstCode.Name = "colItemOstCode";
            this.colItemOstCode.ReadOnly = true;
            this.colItemOstCode.Width = 200;
            // 
            // colItemStatus
            // 
            this.colItemStatus.HeaderText = "Status";
            this.colItemStatus.Name = "colItemStatus";
            this.colItemStatus.ReadOnly = true;
            this.colItemStatus.Visible = false;
            // 
            // colItemDate
            // 
            this.colItemDate.HeaderText = "Date";
            this.colItemDate.Name = "colItemDate";
            this.colItemDate.ReadOnly = true;
            this.colItemDate.Visible = false;
            // 
            // colItemKlient
            // 
            this.colItemKlient.HeaderText = "Klient";
            this.colItemKlient.Name = "colItemKlient";
            this.colItemKlient.ReadOnly = true;
            this.colItemKlient.Visible = false;
            // 
            // colLVOrdId
            // 
            this.colLVOrdId.HeaderText = "ID заказа";
            this.colLVOrdId.Name = "colLVOrdId";
            this.colLVOrdId.ReadOnly = true;
            // 
            // colItemOstId
            // 
            this.colItemOstId.HeaderText = "colItemOstId";
            this.colItemOstId.Name = "colItemOstId";
            this.colItemOstId.ReadOnly = true;
            this.colItemOstId.Visible = false;
            // 
            // colItemIsEDM
            // 
            this.colItemIsEDM.HeaderText = "ЭДО";
            this.colItemIsEDM.Name = "colItemIsEDM";
            this.colItemIsEDM.ReadOnly = true;
            // 
            // colItemOperatorComment
            // 
            this.colItemOperatorComment.HeaderText = "Комментарий для оператора";
            this.colItemOperatorComment.Name = "colItemOperatorComment";
            this.colItemOperatorComment.ReadOnly = true;
            // 
            // colItemWarehouseComment
            // 
            this.colItemWarehouseComment.HeaderText = "Комментарий для склада";
            this.colItemWarehouseComment.Name = "colItemWarehouseComment";
            this.colItemWarehouseComment.ReadOnly = true;
            // 
            // ShipmentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 611);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlToolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShipmentAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание погрузки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShipmentAdd_FormClosed);
            this.Load += new System.EventHandler(this.ShipmentAdd_Load);
            this.pnlToolBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShipmentItem)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOrders)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tblOrders;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepositor;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbTimeSlot;
        private System.Windows.Forms.DateTimePicker dtSDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFromShipmentAll;
        private System.Windows.Forms.Button btnToShipment;
        private System.Windows.Forms.Button btnFromShipment;
        private System.Windows.Forms.DataGridView tblShipmentItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemOstCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemKlient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLVOrdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemOstId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemIsEDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemOperatorComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemWarehouseComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOstCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLVOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOstId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsEDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarehouseComment;
    }
}