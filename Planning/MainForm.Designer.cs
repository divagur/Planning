namespace Planning
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mtiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.miDicts = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictUser = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictTimeSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictDepositor = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictOpersType = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictDelayReasons = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictGates = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictTC = new System.Windows.Forms.ToolStripMenuItem();
            this.miAttributes = new System.Windows.Forms.ToolStripMenuItem();
            this.miTransportType = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblShipments = new System.Windows.Forms.DataGridView();
            this.UniqueKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdNakl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopmletePct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoneShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecCond = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.IsAddLv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbUpdate = new System.Windows.Forms.CheckBox();
            this.edInterval = new System.Windows.Forms.NumericUpDown();
            this.edCurrDay = new System.Windows.Forms.DateTimePicker();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.tmUpdate = new System.Windows.Forms.Timer(this.components);
            this.delay_reasonsTableAdapter1 = new Planning.PlanningDataSetTableAdapters.delay_reasonsTableAdapter();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.edSearch = new System.Windows.Forms.ToolStripTextBox();
            this.mciPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnColumnVisible = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnSearchNext = new System.Windows.Forms.ToolStripButton();
            this.shipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).BeginInit();
            this.mnuContext.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edInterval)).BeginInit();
            this.tbMain.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtiFile,
            this.miDicts});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1276, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // mtiFile
            // 
            this.mtiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSettings,
            this.miConnect});
            this.mtiFile.Name = "mtiFile";
            this.mtiFile.Size = new System.Drawing.Size(48, 20);
            this.mtiFile.Text = "Файл";
            // 
            // miSettings
            // 
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(152, 22);
            this.miSettings.Tag = "Settings";
            this.miSettings.Text = "Настройки";
            this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
            // 
            // miConnect
            // 
            this.miConnect.Name = "miConnect";
            this.miConnect.Size = new System.Drawing.Size(152, 22);
            this.miConnect.Text = "Подключение";
            this.miConnect.Click += new System.EventHandler(this.miConnect_Click);
            // 
            // miDicts
            // 
            this.miDicts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDictUserGroup,
            this.miDictUser,
            this.miDictTimeSlot,
            this.miDictDepositor,
            this.miDictOpersType,
            this.miDictDelayReasons,
            this.miDictGates,
            this.miDictTC,
            this.miAttributes,
            this.miTransportType});
            this.miDicts.Name = "miDicts";
            this.miDicts.Size = new System.Drawing.Size(94, 20);
            this.miDicts.Text = "Справочники";
            // 
            // miDictUserGroup
            // 
            this.miDictUserGroup.Name = "miDictUserGroup";
            this.miDictUserGroup.Size = new System.Drawing.Size(230, 22);
            this.miDictUserGroup.Tag = "UserGrp";
            this.miDictUserGroup.Text = "Группы пользователей";
            this.miDictUserGroup.Click += new System.EventHandler(this.miDictUserGroup_Click);
            // 
            // miDictUser
            // 
            this.miDictUser.Name = "miDictUser";
            this.miDictUser.Size = new System.Drawing.Size(230, 22);
            this.miDictUser.Tag = "Users";
            this.miDictUser.Text = "Пользователи";
            this.miDictUser.Click += new System.EventHandler(this.miDictUser_Click);
            // 
            // miDictTimeSlot
            // 
            this.miDictTimeSlot.Name = "miDictTimeSlot";
            this.miDictTimeSlot.Size = new System.Drawing.Size(230, 22);
            this.miDictTimeSlot.Tag = "TimeSlot";
            this.miDictTimeSlot.Text = "Тайм слоты";
            this.miDictTimeSlot.Click += new System.EventHandler(this.miDictTimeSlot_Click);
            // 
            // miDictDepositor
            // 
            this.miDictDepositor.Name = "miDictDepositor";
            this.miDictDepositor.Size = new System.Drawing.Size(230, 22);
            this.miDictDepositor.Tag = "Depositor";
            this.miDictDepositor.Text = "Депозиторы";
            this.miDictDepositor.Click += new System.EventHandler(this.miDictDepositor_Click);
            // 
            // miDictOpersType
            // 
            this.miDictOpersType.Name = "miDictOpersType";
            this.miDictOpersType.Size = new System.Drawing.Size(230, 22);
            this.miDictOpersType.Tag = "OperType";
            this.miDictOpersType.Text = "Типы операций";
            this.miDictOpersType.Click += new System.EventHandler(this.miDictOpersType_Click);
            // 
            // miDictDelayReasons
            // 
            this.miDictDelayReasons.Name = "miDictDelayReasons";
            this.miDictDelayReasons.Size = new System.Drawing.Size(230, 22);
            this.miDictDelayReasons.Tag = "DelayReasons";
            this.miDictDelayReasons.Text = "Причины задержки";
            this.miDictDelayReasons.Click += new System.EventHandler(this.miDictDelayReasons_Click);
            // 
            // miDictGates
            // 
            this.miDictGates.Name = "miDictGates";
            this.miDictGates.Size = new System.Drawing.Size(230, 22);
            this.miDictGates.Tag = "Gate";
            this.miDictGates.Text = "Ворота";
            this.miDictGates.Click += new System.EventHandler(this.miDictGates_Click);
            // 
            // miDictTC
            // 
            this.miDictTC.Name = "miDictTC";
            this.miDictTC.Size = new System.Drawing.Size(230, 22);
            this.miDictTC.Tag = "TC";
            this.miDictTC.Text = "Справочник ТК";
            this.miDictTC.Click += new System.EventHandler(this.miDictTC_Click);
            // 
            // miAttributes
            // 
            this.miAttributes.Name = "miAttributes";
            this.miAttributes.Size = new System.Drawing.Size(230, 22);
            this.miAttributes.Tag = "Attr";
            this.miAttributes.Text = "Аттрибуты";
            this.miAttributes.Click += new System.EventHandler(this.miAttributes_Click);
            // 
            // miTransportType
            // 
            this.miTransportType.Name = "miTransportType";
            this.miTransportType.Size = new System.Drawing.Size(230, 22);
            this.miTransportType.Tag = "TransporType";
            this.miTransportType.Text = "Типы транспортных средств";
            this.miTransportType.Click += new System.EventHandler(this.miTransportType_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.panel2);
            this.tabMain.Controls.Add(this.panel1);
            this.tabMain.Location = new System.Drawing.Point(4, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1268, 557);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Отгрузки";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblShipments);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1262, 523);
            this.panel2.TabIndex = 5;
            // 
            // tblShipments
            // 
            this.tblShipments.AllowUserToAddRows = false;
            this.tblShipments.AllowUserToDeleteRows = false;
            this.tblShipments.AllowUserToOrderColumns = true;
            this.tblShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UniqueKey,
            this.colId,
            this.colIdNakl,
            this.colDate,
            this.colTime,
            this.colDirection,
            this.colOrderId,
            this.colOrderType,
            this.colKlientId,
            this.colKlientName,
            this.colStatus,
            this.colCopmletePct,
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
            this.IsAddLv});
            this.tblShipments.ContextMenuStrip = this.mnuContext;
            this.tblShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShipments.Location = new System.Drawing.Point(0, 0);
            this.tblShipments.Name = "tblShipments";
            this.tblShipments.ReadOnly = true;
            this.tblShipments.RowHeadersVisible = false;
            this.tblShipments.RowHeadersWidth = 20;
            this.tblShipments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblShipments.Size = new System.Drawing.Size(1262, 523);
            this.tblShipments.TabIndex = 2;
            this.tblShipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblShipments_CellContentClick);
            this.tblShipments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblShipments_CellDoubleClick);
            this.tblShipments.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tblShipments_CellPainting);
            this.tblShipments.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.tblShipments_RowPostPaint);
            this.tblShipments.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tblShipments_RowPrePaint);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCopmletePct.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCopmletePct.HeaderText = "Собран (в %)";
            this.colCopmletePct.Name = "colCopmletePct";
            this.colCopmletePct.ReadOnly = true;
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
            this.colSpecCond.DataPropertyName = "ShpSpecialCon";
            this.colSpecCond.HeaderText = "Спец. Условия";
            this.colSpecCond.Name = "colSpecCond";
            this.colSpecCond.ReadOnly = true;
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
            this.colDepositor.DataPropertyName = "DepName";
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
            this.IsAddLv.HeaderText = "IsAddLv";
            this.IsAddLv.Name = "IsAddLv";
            this.IsAddLv.ReadOnly = true;
            this.IsAddLv.Visible = false;
            // 
            // mnuContext
            // 
            this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mciPrint});
            this.mnuContext.Name = "mnuContext";
            this.mnuContext.Size = new System.Drawing.Size(114, 26);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbUpdate);
            this.panel1.Controls.Add(this.edInterval);
            this.panel1.Controls.Add(this.edCurrDay);
            this.panel1.Controls.Add(this.tbMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 28);
            this.panel1.TabIndex = 4;
            // 
            // cbUpdate
            // 
            this.cbUpdate.AutoSize = true;
            this.cbUpdate.Location = new System.Drawing.Point(515, 4);
            this.cbUpdate.Name = "cbUpdate";
            this.cbUpdate.Size = new System.Drawing.Size(110, 17);
            this.cbUpdate.TabIndex = 5;
            this.cbUpdate.Text = "Автообновление";
            this.cbUpdate.UseVisualStyleBackColor = true;
            this.cbUpdate.CheckedChanged += new System.EventHandler(this.cbUpdate_CheckedChanged);
            // 
            // edInterval
            // 
            this.edInterval.Location = new System.Drawing.Point(464, 3);
            this.edInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edInterval.Name = "edInterval";
            this.edInterval.Size = new System.Drawing.Size(45, 20);
            this.edInterval.TabIndex = 4;
            this.edInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edInterval.ValueChanged += new System.EventHandler(this.edInterval_ValueChanged);
            // 
            // edCurrDay
            // 
            this.edCurrDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.edCurrDay.Location = new System.Drawing.Point(363, 2);
            this.edCurrDay.Name = "edCurrDay";
            this.edCurrDay.Size = new System.Drawing.Size(95, 20);
            this.edCurrDay.TabIndex = 3;
            this.edCurrDay.ValueChanged += new System.EventHandler(this.edCurrDay_ValueChanged);
            // 
            // tbMain
            // 
            this.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDel,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint,
            this.toolStripSeparator2,
            this.btnColumnVisible,
            this.toolStripSeparator3,
            this.edSearch,
            this.btnSearch,
            this.btnSearchNext});
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(1262, 25);
            this.tbMain.TabIndex = 1;
            this.tbMain.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabForms
            // 
            this.tabForms.Controls.Add(this.tabMain);
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForms.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabForms.ItemSize = new System.Drawing.Size(180, 20);
            this.tabForms.Location = new System.Drawing.Point(0, 24);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(1276, 585);
            this.tabForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabForms.TabIndex = 0;
            this.tabForms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabForms_DrawItem);
            this.tabForms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDown);
            // 
            // tmUpdate
            // 
            this.tmUpdate.Tick += new System.EventHandler(this.tmUpdate_Tick);
            // 
            // delay_reasonsTableAdapter1
            // 
            this.delay_reasonsTableAdapter1.ClearBeforeFill = true;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusInfo});
            this.statusStrip2.Location = new System.Drawing.Point(0, 609);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1276, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(118, 17);
            this.statusInfo.Text = "toolStripStatusLabel1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // edSearch
            // 
            this.edSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.edSearch.Name = "edSearch";
            this.edSearch.Size = new System.Drawing.Size(150, 25);
            this.edSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edSearch_KeyDown);
            // 
            // mciPrint
            // 
            this.mciPrint.Image = global::Planning.Properties.Resources.printer;
            this.mciPrint.Name = "mciPrint";
            this.mciPrint.Size = new System.Drawing.Size(113, 22);
            this.mciPrint.Text = "Печать";
            this.mciPrint.Click += new System.EventHandler(this.mciPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::Planning.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.White;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = global::Planning.Properties.Resources.Delete;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.White;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 22);
            this.btnDel.Text = "Удалить";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::Planning.Properties.Resources.arrow_refresh_8563;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.White;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "toolStripButton1";
            this.btnRefresh.ToolTipText = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::Planning.Properties.Resources.printer;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 22);
            this.btnPrint.Text = "toolStripButton1";
            this.btnPrint.ToolTipText = "Печать";
            this.btnPrint.Click += new System.EventHandler(this.mciPrint_Click);
            // 
            // btnColumnVisible
            // 
            this.btnColumnVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColumnVisible.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.btnColumnVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnColumnVisible.Image")));
            this.btnColumnVisible.ImageTransparentColor = System.Drawing.Color.White;
            this.btnColumnVisible.Name = "btnColumnVisible";
            this.btnColumnVisible.Size = new System.Drawing.Size(32, 22);
            this.btnColumnVisible.Text = "toolStripSplitButton1";
            this.btnColumnVisible.ToolTipText = "Видимость колонок";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Checked = true;
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem1.Text = "1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "3";
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::Planning.Properties.Resources.find_6617;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.White;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 22);
            this.btnSearch.Text = "toolStripButton1";
            this.btnSearch.ToolTipText = "Найти";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchNext.Image = global::Planning.Properties.Resources.find_next;
            this.btnSearchNext.ImageTransparentColor = System.Drawing.Color.White;
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(23, 22);
            this.btnSearchNext.Text = "toolStripButton1";
            this.btnSearchNext.ToolTipText = "Найти далее";
            this.btnSearchNext.Click += new System.EventHandler(this.btnSearchNext_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 631);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.statusStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmMain";
            this.RightToLeftLayout = true;
            this.Text = "Planning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).EndInit();
            this.mnuContext.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edInterval)).EndInit();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.tabForms.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mtiFile;
        private System.Windows.Forms.ToolStripMenuItem miDicts;
        private System.Windows.Forms.ToolStripMenuItem miDictUserGroup;
        private System.Windows.Forms.ToolStripMenuItem miDictUser;
        private System.Windows.Forms.ToolStripMenuItem miDictTimeSlot;
        private System.Windows.Forms.ToolStripMenuItem miDictDepositor;
        private System.Windows.Forms.ToolStripMenuItem miDictOpersType;
        private System.Windows.Forms.ToolStripMenuItem miDictDelayReasons;
        private System.Windows.Forms.ToolStripMenuItem miDictGates;
        private System.Windows.Forms.ToolStripMenuItem miDictTC;
        private System.Windows.Forms.BindingSource shipmentBindingSource;
        private PlanningDataSetTableAdapters.delay_reasonsTableAdapter delay_reasonsTableAdapter1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.DataGridView tblShipments;
        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.DateTimePicker edCurrDay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.CheckBox cbUpdate;
        private System.Windows.Forms.NumericUpDown edInterval;
        private System.Windows.Forms.Timer tmUpdate;
        private System.Windows.Forms.ToolStripMenuItem miAttributes;
        private System.Windows.Forms.ToolStripMenuItem miTransportType;
        private System.Windows.Forms.ContextMenuStrip mnuContext;
        private System.Windows.Forms.ToolStripMenuItem mciPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniqueKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdNakl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopmletePct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoneShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecCond;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAddLv;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem miConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton btnColumnVisible;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox edSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnSearchNext;
    }
}

