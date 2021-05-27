
namespace Planning
{
    partial class frmShipmentHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnFilter = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbShpType = new System.Windows.Forms.ComboBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbShpType = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblShipmentLog = new System.Windows.Forms.DataGridView();
            this.colDmlDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDmlType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDmlCompName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDmlUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpSlotType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpSpCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpDriverPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpDriverFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpTransportCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpTransportTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpVehicleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpTrailerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStumpNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpAttorneyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpAttorneyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpSubmissionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpLeaveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpDelayReasonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpDelayComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDmlTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackgroundColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipmentLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFilter
            // 
            this.pnFilter.Controls.Add(this.btnFind);
            this.pnFilter.Controls.Add(this.cmbUser);
            this.pnFilter.Controls.Add(this.cmbShpType);
            this.pnFilter.Controls.Add(this.lbUser);
            this.pnFilter.Controls.Add(this.lbShpType);
            this.pnFilter.Controls.Add(this.dtEnd);
            this.pnFilter.Controls.Add(this.dtBegin);
            this.pnFilter.Controls.Add(this.label2);
            this.pnFilter.Controls.Add(this.label1);
            this.pnFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFilter.Location = new System.Drawing.Point(0, 0);
            this.pnFilter.Name = "pnFilter";
            this.pnFilter.Size = new System.Drawing.Size(1284, 47);
            this.pnFilter.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(783, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Применить";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(590, 12);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(187, 21);
            this.cmbUser.TabIndex = 4;
            // 
            // cmbShpType
            // 
            this.cmbShpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShpType.FormattingEnabled = true;
            this.cmbShpType.Items.AddRange(new object[] {
            "Все",
            "Выход",
            "Вход",
            "Перемещение"});
            this.cmbShpType.Location = new System.Drawing.Point(335, 12);
            this.cmbShpType.Name = "cmbShpType";
            this.cmbShpType.Size = new System.Drawing.Size(153, 21);
            this.cmbShpType.TabIndex = 4;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(504, 15);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(80, 13);
            this.lbUser.TabIndex = 3;
            this.lbUser.Text = "Пользователь";
            // 
            // lbShpType
            // 
            this.lbShpType.AutoSize = true;
            this.lbShpType.Location = new System.Drawing.Point(255, 15);
            this.lbShpType.Name = "lbShpType";
            this.lbShpType.Size = new System.Drawing.Size(74, 13);
            this.lbShpType.TabIndex = 2;
            this.lbShpType.Text = "Тип отгрузки";
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(154, 13);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(91, 20);
            this.dtEnd.TabIndex = 1;
            // 
            // dtBegin
            // 
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBegin.Location = new System.Drawing.Point(32, 13);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(91, 20);
            this.dtBegin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "С";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblShipmentLog);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 483);
            this.panel1.TabIndex = 1;
            // 
            // tblShipmentLog
            // 
            this.tblShipmentLog.AllowUserToAddRows = false;
            this.tblShipmentLog.AllowUserToDeleteRows = false;
            this.tblShipmentLog.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblShipmentLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblShipmentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShipmentLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDmlDate,
            this.colDmlType,
            this.colDmlCompName,
            this.colDmlUserName,
            this.colShpId,
            this.colShpDate,
            this.colShpSlotType,
            this.colShpType,
            this.colShpComment,
            this.colGateName,
            this.colShpSpCondition,
            this.colShpDriverPhone,
            this.colShpDriverFIO,
            this.colShpTransportCompanyName,
            this.colShpTransportTypeName,
            this.colShpVehicleNumber,
            this.colShpTrailerNumber,
            this.colStumpNumber,
            this.colShpAttorneyNumber,
            this.colShpAttorneyDate,
            this.colShpSubmissionTime,
            this.colShpStartTime,
            this.colShpEndTime,
            this.colShpLeaveTime,
            this.colShpDelayReasonName,
            this.colShpDelayComment,
            this.colDmlTypeId,
            this.BackgroundColor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblShipmentLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblShipmentLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShipmentLog.Location = new System.Drawing.Point(0, 0);
            this.tblShipmentLog.Name = "tblShipmentLog";
            this.tblShipmentLog.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblShipmentLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblShipmentLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblShipmentLog.Size = new System.Drawing.Size(1284, 483);
            this.tblShipmentLog.TabIndex = 1;
            this.tblShipmentLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tblShipmentLog_CellPainting);
            this.tblShipmentLog.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tblShipmentLog_RowPrePaint);
            // 
            // colDmlDate
            // 
            this.colDmlDate.DataPropertyName = "dml_date";
            this.colDmlDate.HeaderText = "Дата изменения";
            this.colDmlDate.Name = "colDmlDate";
            this.colDmlDate.ReadOnly = true;
            this.colDmlDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDmlType
            // 
            this.colDmlType.DataPropertyName = "dml_type_name";
            this.colDmlType.HeaderText = "Тип изменения";
            this.colDmlType.Name = "colDmlType";
            this.colDmlType.ReadOnly = true;
            this.colDmlType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDmlCompName
            // 
            this.colDmlCompName.DataPropertyName = "dml_comp_name";
            this.colDmlCompName.HeaderText = "Имя компьютера";
            this.colDmlCompName.Name = "colDmlCompName";
            this.colDmlCompName.ReadOnly = true;
            this.colDmlCompName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDmlUserName
            // 
            this.colDmlUserName.DataPropertyName = "dml_user_name";
            this.colDmlUserName.HeaderText = "Имя пользователя";
            this.colDmlUserName.Name = "colDmlUserName";
            this.colDmlUserName.ReadOnly = true;
            this.colDmlUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShpId
            // 
            this.colShpId.DataPropertyName = "shipment_id";
            this.colShpId.HeaderText = "ID. погр";
            this.colShpId.Name = "colShpId";
            this.colShpId.ReadOnly = true;
            this.colShpId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShpDate
            // 
            this.colShpDate.DataPropertyName = "s_date";
            this.colShpDate.HeaderText = "Дата";
            this.colShpDate.Name = "colShpDate";
            this.colShpDate.ReadOnly = true;
            this.colShpDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShpSlotType
            // 
            this.colShpSlotType.DataPropertyName = "SlotTime";
            this.colShpSlotType.HeaderText = "Время";
            this.colShpSlotType.Name = "colShpSlotType";
            this.colShpSlotType.ReadOnly = true;
            this.colShpSlotType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShpType
            // 
            this.colShpType.DataPropertyName = "InOut";
            this.colShpType.HeaderText = "Напр.";
            this.colShpType.Name = "colShpType";
            this.colShpType.ReadOnly = true;
            this.colShpType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShpComment
            // 
            this.colShpComment.DataPropertyName = "s_comment";
            this.colShpComment.HeaderText = "Комментарий к отгрузке";
            this.colShpComment.Name = "colShpComment";
            this.colShpComment.ReadOnly = true;
            // 
            // colGateName
            // 
            this.colGateName.DataPropertyName = "gate_name";
            this.colGateName.HeaderText = "Ворота";
            this.colGateName.Name = "colGateName";
            this.colGateName.ReadOnly = true;
            // 
            // colShpSpCondition
            // 
            this.colShpSpCondition.DataPropertyName = "sp_condition";
            this.colShpSpCondition.HeaderText = "Спец. условия";
            this.colShpSpCondition.Name = "colShpSpCondition";
            this.colShpSpCondition.ReadOnly = true;
            // 
            // colShpDriverPhone
            // 
            this.colShpDriverPhone.DataPropertyName = "driver_phone";
            this.colShpDriverPhone.HeaderText = "Телефон водителя";
            this.colShpDriverPhone.Name = "colShpDriverPhone";
            this.colShpDriverPhone.ReadOnly = true;
            // 
            // colShpDriverFIO
            // 
            this.colShpDriverFIO.DataPropertyName = "driver_fio";
            this.colShpDriverFIO.HeaderText = "ФИО водителя";
            this.colShpDriverFIO.Name = "colShpDriverFIO";
            this.colShpDriverFIO.ReadOnly = true;
            // 
            // colShpTransportCompanyName
            // 
            this.colShpTransportCompanyName.DataPropertyName = "transport_company_name";
            this.colShpTransportCompanyName.HeaderText = "Транспортная компания";
            this.colShpTransportCompanyName.Name = "colShpTransportCompanyName";
            this.colShpTransportCompanyName.ReadOnly = true;
            // 
            // colShpTransportTypeName
            // 
            this.colShpTransportTypeName.DataPropertyName = "transport_type_name";
            this.colShpTransportTypeName.HeaderText = "Марка ТС";
            this.colShpTransportTypeName.Name = "colShpTransportTypeName";
            this.colShpTransportTypeName.ReadOnly = true;
            // 
            // colShpVehicleNumber
            // 
            this.colShpVehicleNumber.DataPropertyName = "vehicle_number";
            this.colShpVehicleNumber.HeaderText = "Номер ТС";
            this.colShpVehicleNumber.Name = "colShpVehicleNumber";
            this.colShpVehicleNumber.ReadOnly = true;
            // 
            // colShpTrailerNumber
            // 
            this.colShpTrailerNumber.DataPropertyName = "trailer_number";
            this.colShpTrailerNumber.HeaderText = "Номер прицепа";
            this.colShpTrailerNumber.Name = "colShpTrailerNumber";
            this.colShpTrailerNumber.ReadOnly = true;
            // 
            // colStumpNumber
            // 
            this.colStumpNumber.DataPropertyName = "stamp_number";
            this.colStumpNumber.HeaderText = "Номер пломбы";
            this.colStumpNumber.Name = "colStumpNumber";
            this.colStumpNumber.ReadOnly = true;
            // 
            // colShpAttorneyNumber
            // 
            this.colShpAttorneyNumber.DataPropertyName = "attorney_number";
            this.colShpAttorneyNumber.HeaderText = "Номер доверенности";
            this.colShpAttorneyNumber.Name = "colShpAttorneyNumber";
            this.colShpAttorneyNumber.ReadOnly = true;
            // 
            // colShpAttorneyDate
            // 
            this.colShpAttorneyDate.DataPropertyName = "attorney_date";
            this.colShpAttorneyDate.HeaderText = "Дата доверенности";
            this.colShpAttorneyDate.Name = "colShpAttorneyDate";
            this.colShpAttorneyDate.ReadOnly = true;
            // 
            // colShpSubmissionTime
            // 
            this.colShpSubmissionTime.DataPropertyName = "submission_time";
            this.colShpSubmissionTime.HeaderText = "Время подачи документов";
            this.colShpSubmissionTime.Name = "colShpSubmissionTime";
            this.colShpSubmissionTime.ReadOnly = true;
            // 
            // colShpStartTime
            // 
            this.colShpStartTime.DataPropertyName = "start_time";
            this.colShpStartTime.HeaderText = "Время начала";
            this.colShpStartTime.Name = "colShpStartTime";
            this.colShpStartTime.ReadOnly = true;
            // 
            // colShpEndTime
            // 
            this.colShpEndTime.DataPropertyName = "end_time";
            this.colShpEndTime.HeaderText = "Время окончания";
            this.colShpEndTime.Name = "colShpEndTime";
            this.colShpEndTime.ReadOnly = true;
            // 
            // colShpLeaveTime
            // 
            this.colShpLeaveTime.DataPropertyName = "leave_time";
            this.colShpLeaveTime.HeaderText = "Убытие по факту";
            this.colShpLeaveTime.Name = "colShpLeaveTime";
            this.colShpLeaveTime.ReadOnly = true;
            // 
            // colShpDelayReasonName
            // 
            this.colShpDelayReasonName.DataPropertyName = "delay_reason_name";
            this.colShpDelayReasonName.HeaderText = "Причина опоздания";
            this.colShpDelayReasonName.Name = "colShpDelayReasonName";
            this.colShpDelayReasonName.ReadOnly = true;
            // 
            // colShpDelayComment
            // 
            this.colShpDelayComment.DataPropertyName = "delay_comment";
            this.colShpDelayComment.HeaderText = "Комметарий по опозданию";
            this.colShpDelayComment.Name = "colShpDelayComment";
            this.colShpDelayComment.ReadOnly = true;
            // 
            // colDmlTypeId
            // 
            this.colDmlTypeId.DataPropertyName = "dml_type";
            this.colDmlTypeId.HeaderText = "colDmlTypeId";
            this.colDmlTypeId.Name = "colDmlTypeId";
            this.colDmlTypeId.ReadOnly = true;
            this.colDmlTypeId.Visible = false;
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.DataPropertyName = "BackgroundColor";
            this.BackgroundColor.HeaderText = "BackgroundColor";
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.ReadOnly = true;
            this.BackgroundColor.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(1284, 483);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmShipmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnFilter);
            this.Name = "frmShipmentHistory";
            this.Text = "История";
            this.pnFilter.ResumeLayout(false);
            this.pnFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShipmentLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbShpType;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbShpType;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView tblShipmentLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDmlDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDmlType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDmlCompName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDmlUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpSlotType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpSpCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpDriverPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpDriverFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpTransportCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpTransportTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpVehicleNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpTrailerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStumpNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpAttorneyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpAttorneyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpSubmissionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpLeaveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpDelayReasonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpDelayComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDmlTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackgroundColor;
    }
}