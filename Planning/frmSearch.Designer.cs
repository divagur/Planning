
namespace Planning
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblSearchField = new System.Windows.Forms.DataGridView();
            this.colCondType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOper = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picWork = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblShipments = new System.Windows.Forms.DataGridView();
            this.UniqueKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdNakl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrdPartLVCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopmletePct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoneShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecCond = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDriverPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransportType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrackNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrailerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttorneyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttorneyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmissionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTimePlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTimeFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelayReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelayComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepositor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStampNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackgroundColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAddLv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colShippingPlacesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbSearch = new System.Windows.Forms.ToolStripButton();
            this.tbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tbCancelSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSearchField)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWork)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblSearchField);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 159);
            this.panel1.TabIndex = 0;
            // 
            // tblSearchField
            // 
            this.tblSearchField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSearchField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCondType,
            this.colField,
            this.colOper,
            this.colValue});
            this.tblSearchField.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tblSearchField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearchField.Location = new System.Drawing.Point(0, 35);
            this.tblSearchField.MultiSelect = false;
            this.tblSearchField.Name = "tblSearchField";
            this.tblSearchField.RowHeadersVisible = false;
            this.tblSearchField.Size = new System.Drawing.Size(1076, 124);
            this.tblSearchField.TabIndex = 6;
            this.tblSearchField.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tblSearchField_DataError);
            this.tblSearchField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tblSearchField_KeyDown);
            // 
            // colCondType
            // 
            this.colCondType.DataPropertyName = "Condition";
            this.colCondType.HeaderText = "";
            this.colCondType.Items.AddRange(new object[] {
            "И",
            "ИЛИ"});
            this.colCondType.Name = "colCondType";
            this.colCondType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCondType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCondType.Width = 50;
            // 
            // colField
            // 
            this.colField.DataPropertyName = "FieldName";
            this.colField.HeaderText = "Поле";
            this.colField.Name = "colField";
            this.colField.ReadOnly = true;
            this.colField.Width = 200;
            // 
            // colOper
            // 
            this.colOper.DataPropertyName = "Operation";
            this.colOper.HeaderText = "Оператор";
            this.colOper.Items.AddRange(new object[] {
            "=",
            "Содержит"});
            this.colOper.Name = "colOper";
            this.colOper.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colValue
            // 
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Значение";
            this.colValue.Name = "colValue";
            this.colValue.Width = 200;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.picWork);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dtEnd);
            this.panel3.Controls.Add(this.dtBegin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1076, 35);
            this.panel3.TabIndex = 4;
            // 
            // picWork
            // 
            this.picWork.BackColor = System.Drawing.Color.Transparent;
            this.picWork.Image = ((System.Drawing.Image)(resources.GetObject("picWork.Image")));
            this.picWork.Location = new System.Drawing.Point(305, 5);
            this.picWork.Name = "picWork";
            this.picWork.Size = new System.Drawing.Size(26, 26);
            this.picWork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWork.TabIndex = 3;
            this.picWork.TabStop = false;
            this.picWork.Visible = false;
            this.picWork.Click += new System.EventHandler(this.picWork_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Диапазон поиска";
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(212, 9);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(87, 20);
            this.dtEnd.TabIndex = 2;
            // 
            // dtBegin
            // 
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBegin.Location = new System.Drawing.Point(115, 9);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(91, 20);
            this.dtBegin.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblShipments);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 504);
            this.panel2.TabIndex = 1;
            // 
            // tblShipments
            // 
            this.tblShipments.AllowUserToAddRows = false;
            this.tblShipments.AllowUserToDeleteRows = false;
            this.tblShipments.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblShipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UniqueKey,
            this.colId,
            this.colIdNakl,
            this.colDate,
            this.colTime,
            this.colDirection,
            this.colOrderId,
            this.colOrdPartLVCode,
            this.colOrderType,
            this.colKlientId,
            this.colKlientName,
            this.colStatus,
            this.colCopmletePct,
            this.PrcValue,
            this.colDoneShare,
            this.colComment,
            this.colOrderComment,
            this.colGate,
            this.colSpecCond,
            this.colDriverPhone,
            this.colDriverName,
            this.colTransComp,
            this.colTransportType,
            this.colTrackNumber,
            this.colTrailerNumber,
            this.colAttorneyNumber,
            this.colAttorneyDate,
            this.colSubmissionTime,
            this.colStartTime,
            this.colEndTimePlan,
            this.colEndTimeFact,
            this.colDelayReason,
            this.colDelayComment,
            this.colDepositor,
            this.colStampNumber,
            this.FontColor,
            this.BackgroundColor,
            this.IsAddLv,
            this.colShippingPlacesNumber,
            this.colOrderWeight});
            this.tblShipments.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblShipments.DefaultCellStyle = dataGridViewCellStyle4;
            this.tblShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShipments.Location = new System.Drawing.Point(0, 0);
            this.tblShipments.Name = "tblShipments";
            this.tblShipments.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblShipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tblShipments.RowHeadersVisible = false;
            this.tblShipments.RowHeadersWidth = 20;
            this.tblShipments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblShipments.Size = new System.Drawing.Size(1076, 504);
            this.tblShipments.TabIndex = 3;
            // 
            // UniqueKey
            // 
            this.UniqueKey.HeaderText = "UniqueKey";
            this.UniqueKey.Name = "UniqueKey";
            this.UniqueKey.ReadOnly = true;
            this.UniqueKey.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ShpId";
            this.colId.HeaderText = "ID погр.";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colIdNakl
            // 
            this.colIdNakl.DataPropertyName = "OrdId";
            this.colIdNakl.HeaderText = "ID накл.";
            this.colIdNakl.Name = "colIdNakl";
            this.colIdNakl.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "ShpDate";
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "SlotTime";
            this.colTime.HeaderText = "Время";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colDirection
            // 
            this.colDirection.DataPropertyName = "InOut";
            this.colDirection.HeaderText = "Напр.";
            this.colDirection.Name = "colDirection";
            this.colDirection.ReadOnly = true;
            // 
            // colOrderId
            // 
            this.colOrderId.DataPropertyName = "OrdLVCode";
            this.colOrderId.HeaderText = "Код заказа";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.ReadOnly = true;
            // 
            // colOrdPartLVCode
            // 
            this.colOrdPartLVCode.DataPropertyName = "OrdPartLVCode";
            this.colOrdPartLVCode.HeaderText = "Код расходной партии";
            this.colOrdPartLVCode.Name = "colOrdPartLVCode";
            this.colOrdPartLVCode.ReadOnly = true;
            this.colOrdPartLVCode.Width = 150;
            // 
            // colOrderType
            // 
            this.colOrderType.DataPropertyName = "OrdLVType";
            this.colOrderType.HeaderText = "Тип заказа";
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.ReadOnly = true;
            // 
            // colKlientId
            // 
            this.colKlientId.HeaderText = "Код клиента";
            this.colKlientId.Name = "colKlientId";
            this.colKlientId.ReadOnly = true;
            this.colKlientId.Visible = false;
            // 
            // colKlientName
            // 
            this.colKlientName.DataPropertyName = "KlientName";
            this.colKlientName.HeaderText = "Клиент";
            this.colKlientName.Name = "colKlientName";
            this.colKlientName.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "OrderStatus";
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colCopmletePct
            // 
            this.colCopmletePct.DataPropertyName = "PrcReady";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCopmletePct.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCopmletePct.HeaderText = "Собран (в %)";
            this.colCopmletePct.Name = "colCopmletePct";
            this.colCopmletePct.ReadOnly = true;
            // 
            // PrcValue
            // 
            this.PrcValue.DataPropertyName = "PrcReady";
            this.PrcValue.HeaderText = "PrcValue";
            this.PrcValue.Name = "PrcValue";
            this.PrcValue.ReadOnly = true;
            this.PrcValue.Visible = false;
            // 
            // colDoneShare
            // 
            this.colDoneShare.DataPropertyName = "DoneShare";
            this.colDoneShare.HeaderText = "DoneShare";
            this.colDoneShare.Name = "colDoneShare";
            this.colDoneShare.ReadOnly = true;
            this.colDoneShare.Visible = false;
            // 
            // colComment
            // 
            this.colComment.DataPropertyName = "ShpComment";
            this.colComment.HeaderText = "Комментарий по загрузке";
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            // 
            // colOrderComment
            // 
            this.colOrderComment.DataPropertyName = "OrdComment";
            this.colOrderComment.HeaderText = "Комментарий по заказу";
            this.colOrderComment.Name = "colOrderComment";
            this.colOrderComment.ReadOnly = true;
            // 
            // colGate
            // 
            this.colGate.DataPropertyName = "GateName";
            this.colGate.HeaderText = "Ворота";
            this.colGate.Name = "colGate";
            this.colGate.ReadOnly = true;
            // 
            // colSpecCond
            // 
            this.colSpecCond.DataPropertyName = "ShpSpecialCond";
            this.colSpecCond.HeaderText = "Спец. Условия";
            this.colSpecCond.Name = "colSpecCond";
            this.colSpecCond.ReadOnly = true;
            this.colSpecCond.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSpecCond.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colDriverPhone
            // 
            this.colDriverPhone.DataPropertyName = "ShpDriverPhone";
            this.colDriverPhone.HeaderText = "Телефон водителя";
            this.colDriverPhone.Name = "colDriverPhone";
            this.colDriverPhone.ReadOnly = true;
            // 
            // colDriverName
            // 
            this.colDriverName.DataPropertyName = "ShpDriverFio";
            this.colDriverName.HeaderText = "ФИО водителя";
            this.colDriverName.Name = "colDriverName";
            this.colDriverName.ReadOnly = true;
            this.colDriverName.Width = 150;
            // 
            // colTransComp
            // 
            this.colTransComp.DataPropertyName = "TransportCompanyName";
            this.colTransComp.HeaderText = "Транспортная компания";
            this.colTransComp.Name = "colTransComp";
            this.colTransComp.ReadOnly = true;
            // 
            // colTransportType
            // 
            this.colTransportType.DataPropertyName = "TransportTypeName";
            this.colTransportType.HeaderText = "Марка ТС";
            this.colTransportType.Name = "colTransportType";
            this.colTransportType.ReadOnly = true;
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.DataPropertyName = "ShpVehicleNumber";
            this.colTrackNumber.HeaderText = "Номер ТС";
            this.colTrackNumber.Name = "colTrackNumber";
            this.colTrackNumber.ReadOnly = true;
            // 
            // colTrailerNumber
            // 
            this.colTrailerNumber.DataPropertyName = "ShpTrailerNumber";
            this.colTrailerNumber.HeaderText = "Номер прицепа";
            this.colTrailerNumber.Name = "colTrailerNumber";
            this.colTrailerNumber.ReadOnly = true;
            // 
            // colAttorneyNumber
            // 
            this.colAttorneyNumber.DataPropertyName = "ShpAttorneyNumber";
            this.colAttorneyNumber.HeaderText = "Номер доверенности";
            this.colAttorneyNumber.Name = "colAttorneyNumber";
            this.colAttorneyNumber.ReadOnly = true;
            // 
            // colAttorneyDate
            // 
            this.colAttorneyDate.DataPropertyName = "ShpAttorneyDate";
            this.colAttorneyDate.HeaderText = "Дата доверенности";
            this.colAttorneyDate.Name = "colAttorneyDate";
            this.colAttorneyDate.ReadOnly = true;
            // 
            // colSubmissionTime
            // 
            this.colSubmissionTime.DataPropertyName = "ShpSubmissionTime";
            this.colSubmissionTime.HeaderText = "Время подачи документов";
            this.colSubmissionTime.Name = "colSubmissionTime";
            this.colSubmissionTime.ReadOnly = true;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "ShpStartTime";
            this.colStartTime.HeaderText = "Время начала";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            // 
            // colEndTimePlan
            // 
            this.colEndTimePlan.DataPropertyName = "ShpEndTimePlan";
            this.colEndTimePlan.HeaderText = "Время окончания";
            this.colEndTimePlan.Name = "colEndTimePlan";
            this.colEndTimePlan.ReadOnly = true;
            // 
            // colEndTimeFact
            // 
            this.colEndTimeFact.DataPropertyName = "ShpEndTimeFact";
            this.colEndTimeFact.HeaderText = "Убытие по факту";
            this.colEndTimeFact.Name = "colEndTimeFact";
            this.colEndTimeFact.ReadOnly = true;
            // 
            // colDelayReason
            // 
            this.colDelayReason.DataPropertyName = "ShpDelayReasonName";
            this.colDelayReason.HeaderText = "Причина опоздания";
            this.colDelayReason.Name = "colDelayReason";
            this.colDelayReason.ReadOnly = true;
            // 
            // colDelayComment
            // 
            this.colDelayComment.DataPropertyName = "ShpDelayComment";
            this.colDelayComment.HeaderText = "Комментарий по опозданию";
            this.colDelayComment.Name = "colDelayComment";
            this.colDelayComment.ReadOnly = true;
            // 
            // colDepositor
            // 
            this.colDepositor.DataPropertyName = "DepCode";
            this.colDepositor.HeaderText = "Депозитор";
            this.colDepositor.Name = "colDepositor";
            this.colDepositor.ReadOnly = true;
            // 
            // colStampNumber
            // 
            this.colStampNumber.DataPropertyName = "ShpStampNumber";
            this.colStampNumber.HeaderText = "№ пломбы";
            this.colStampNumber.Name = "colStampNumber";
            this.colStampNumber.ReadOnly = true;
            // 
            // FontColor
            // 
            this.FontColor.DataPropertyName = "FontColor";
            this.FontColor.HeaderText = "FontColor";
            this.FontColor.Name = "FontColor";
            this.FontColor.ReadOnly = true;
            this.FontColor.Visible = false;
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.DataPropertyName = "BackgroundColor";
            this.BackgroundColor.HeaderText = "BackgroudColor";
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.ReadOnly = true;
            this.BackgroundColor.Visible = false;
            // 
            // IsAddLv
            // 
            this.IsAddLv.DataPropertyName = "IsAddLv";
            this.IsAddLv.HeaderText = "Привязка к отгрузке";
            this.IsAddLv.Name = "IsAddLv";
            this.IsAddLv.ReadOnly = true;
            this.IsAddLv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAddLv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colShippingPlacesNumber
            // 
            this.colShippingPlacesNumber.DataPropertyName = "ShippingPlacesNumber";
            this.colShippingPlacesNumber.HeaderText = "Кол-во отгрузочных мест";
            this.colShippingPlacesNumber.Name = "colShippingPlacesNumber";
            this.colShippingPlacesNumber.ReadOnly = true;
            // 
            // colOrderWeight
            // 
            this.colOrderWeight.DataPropertyName = "OrderWeight";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colOrderWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOrderWeight.HeaderText = "Вес заказа";
            this.colOrderWeight.Name = "colOrderWeight";
            this.colOrderWeight.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSearch,
            this.tbExportToExcel,
            this.tbCancelSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1076, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbSearch
            // 
            this.tbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSearch.Image = global::Planning.Properties.Resources.find_6617;
            this.tbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(23, 22);
            this.tbSearch.Text = "Найти";
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            // 
            // tbExportToExcel
            // 
            this.tbExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("tbExportToExcel.Image")));
            this.tbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExportToExcel.Name = "tbExportToExcel";
            this.tbExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.tbExportToExcel.Text = "Выгрузить в Excel";
            this.tbExportToExcel.Click += new System.EventHandler(this.tbExportToExcel_Click);
            // 
            // tbCancelSearch
            // 
            this.tbCancelSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCancelSearch.Image = ((System.Drawing.Image)(resources.GetObject("tbCancelSearch.Image")));
            this.tbCancelSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCancelSearch.Name = "tbCancelSearch";
            this.tbCancelSearch.Size = new System.Drawing.Size(23, 22);
            this.tbCancelSearch.Text = "toolStripButton1";
            this.tbCancelSearch.ToolTipText = "Остановить поиск";
            this.tbCancelSearch.Click += new System.EventHandler(this.tbCancelSearch_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 688);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmSearch";
            this.Text = "Поиск";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSearchField)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWork)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblShipments;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniqueKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdNakl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdPartLVCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopmletePct;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrcValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoneShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSpecCond;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrackNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrailerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttorneyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttorneyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubmissionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTimePlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTimeFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDelayReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDelayComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepositor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStampNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackgroundColor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddLv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShippingPlacesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderWeight;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView tblSearchField;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCondType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colField;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOper;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbSearch;
        private System.Windows.Forms.ToolStripButton tbExportToExcel;
        private System.Windows.Forms.PictureBox picWork;
        private System.Windows.Forms.ToolStripButton tbCancelSearch;
    }
}