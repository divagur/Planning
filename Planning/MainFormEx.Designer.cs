
using Planning.Controls;

namespace Planning
{
    partial class MainFormEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormEx));
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle1 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle2 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle3 = new BrightIdeasSoftware.HeaderStateStyle();
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
            this.miDictSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.miAttributes = new System.Windows.Forms.ToolStripMenuItem();
            this.miTransportType = new System.Windows.Forms.ToolStripMenuItem();
            this.miTransportView = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.miCustomPosts = new System.Windows.Forms.ToolStripMenuItem();
            this.miReports = new System.Windows.Forms.ToolStripMenuItem();
            this.miRepPeriod = new System.Windows.Forms.ToolStripMenuItem();
            this.miRepStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.miRepTC = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdditional = new System.Windows.Forms.ToolStripMenuItem();
            this.miCalcOrderVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrentTask = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tblShipments = new BrightIdeasSoftware.ObjectListView();
            this.colOrderDetail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIdNakl = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDirection = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrderId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrdPartLVCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrderType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colKlientId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colKlientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colCopmletePct = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PrcValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDoneShare = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.barRenderer1 = new BrightIdeasSoftware.BarRenderer();
            this.colComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrderComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colGate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSpecCond = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDriverPhone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDriverName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTransComp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTransportType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTrackNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTrailerNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colAttorneyNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colAttorneyDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSubmissionTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colStartTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEndTimePlan = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEndTimeFact = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDelayReason = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDelayComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDepositor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colStampNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FontColor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BackgroundColor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IsAddLv = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colShippingPlacesNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrderWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSupplier = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsEdm = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTransportView = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colWarehouseName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colOrdLvId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRowNumberRange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMain = new System.Windows.Forms.Panel();
            this.edSearch = new System.Windows.Forms.TextBox();
            this.edCurrDay = new System.Windows.Forms.DateTimePicker();
            this.btnGetNextDay = new System.Windows.Forms.Button();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.btnGetCurrentDay = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGetLastDay = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnColumnVisible = new Planning.Controls.MenuButton();
            this.contextMenuColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.headerFormatStyle1 = new BrightIdeasSoftware.HeaderFormatStyle();
            this.imageListInOut = new System.Windows.Forms.ImageList(this.components);
            this.imageListMain16 = new System.Windows.Forms.ImageList(this.components);
            this.imageListMain32 = new System.Windows.Forms.ImageList(this.components);
            this.panelFormHeader = new System.Windows.Forms.Panel();
            this.lbMainFormCaption = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnMinimizeWindow = new System.Windows.Forms.Button();
            this.btnMaximizeWindow = new System.Windows.Forms.Button();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDict = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictTimeSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictDepositor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictOpersType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictDelayReasons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictGates = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictTC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDoctSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictAttributes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictTransportType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictTransportView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictCustomPosts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportPeriod = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportTC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictUserGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDictUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).BeginInit();
            this.panelMain.SuspendLayout();
            this.contextMenuColumns.SuspendLayout();
            this.panelFormHeader.SuspendLayout();
            this.contextMenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtiFile,
            this.miDicts,
            this.miReports,
            this.miAdditional});
            this.menuMain.Location = new System.Drawing.Point(0, 44);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1290, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            this.menuMain.Visible = false;
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
            // 
            // miConnect
            // 
            this.miConnect.Name = "miConnect";
            this.miConnect.Size = new System.Drawing.Size(152, 22);
            this.miConnect.Text = "Подключение";
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
            this.miDictSupplier,
            this.miAttributes,
            this.miTransportType,
            this.miTransportView,
            this.miDictWarehouse,
            this.miCustomPosts});
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
            // 
            // miDictUser
            // 
            this.miDictUser.Name = "miDictUser";
            this.miDictUser.Size = new System.Drawing.Size(230, 22);
            this.miDictUser.Tag = "Users";
            this.miDictUser.Text = "Пользователи";
            // 
            // miDictTimeSlot
            // 
            this.miDictTimeSlot.Name = "miDictTimeSlot";
            this.miDictTimeSlot.Size = new System.Drawing.Size(230, 22);
            this.miDictTimeSlot.Tag = "TimeSlot";
            this.miDictTimeSlot.Text = "Тайм слоты";
            // 
            // miDictDepositor
            // 
            this.miDictDepositor.Name = "miDictDepositor";
            this.miDictDepositor.Size = new System.Drawing.Size(230, 22);
            this.miDictDepositor.Tag = "Depositor";
            this.miDictDepositor.Text = "Депозиторы";
            // 
            // miDictOpersType
            // 
            this.miDictOpersType.Name = "miDictOpersType";
            this.miDictOpersType.Size = new System.Drawing.Size(230, 22);
            this.miDictOpersType.Tag = "OperType";
            this.miDictOpersType.Text = "Типы операций";
            // 
            // miDictDelayReasons
            // 
            this.miDictDelayReasons.Name = "miDictDelayReasons";
            this.miDictDelayReasons.Size = new System.Drawing.Size(230, 22);
            this.miDictDelayReasons.Tag = "DelayReasons";
            this.miDictDelayReasons.Text = "Причины задержки";
            // 
            // miDictGates
            // 
            this.miDictGates.Name = "miDictGates";
            this.miDictGates.Size = new System.Drawing.Size(230, 22);
            this.miDictGates.Tag = "Gate";
            this.miDictGates.Text = "Ворота";
            // 
            // miDictTC
            // 
            this.miDictTC.Name = "miDictTC";
            this.miDictTC.Size = new System.Drawing.Size(230, 22);
            this.miDictTC.Tag = "TC";
            this.miDictTC.Text = "Справочник ТК";
            // 
            // miDictSupplier
            // 
            this.miDictSupplier.Name = "miDictSupplier";
            this.miDictSupplier.Size = new System.Drawing.Size(230, 22);
            this.miDictSupplier.Text = "Поставщики";
            // 
            // miAttributes
            // 
            this.miAttributes.Name = "miAttributes";
            this.miAttributes.Size = new System.Drawing.Size(230, 22);
            this.miAttributes.Tag = "Attr";
            this.miAttributes.Text = "Аттрибуты";
            this.miAttributes.Visible = false;
            // 
            // miTransportType
            // 
            this.miTransportType.Name = "miTransportType";
            this.miTransportType.Size = new System.Drawing.Size(230, 22);
            this.miTransportType.Tag = "TransporType";
            this.miTransportType.Text = "Типы транспортных средств";
            // 
            // miTransportView
            // 
            this.miTransportView.Name = "miTransportView";
            this.miTransportView.Size = new System.Drawing.Size(230, 22);
            this.miTransportView.Text = "Виды транспорта";
            // 
            // miDictWarehouse
            // 
            this.miDictWarehouse.Name = "miDictWarehouse";
            this.miDictWarehouse.Size = new System.Drawing.Size(230, 22);
            this.miDictWarehouse.Text = "Склады";
            // 
            // miCustomPosts
            // 
            this.miCustomPosts.Name = "miCustomPosts";
            this.miCustomPosts.Size = new System.Drawing.Size(230, 22);
            this.miCustomPosts.Text = "Таможенные посты";
            // 
            // miReports
            // 
            this.miReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRepPeriod,
            this.miRepStatistic,
            this.miRepTC});
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(60, 20);
            this.miReports.Text = "Отчеты";
            // 
            // miRepPeriod
            // 
            this.miRepPeriod.Name = "miRepPeriod";
            this.miRepPeriod.Size = new System.Drawing.Size(192, 22);
            this.miRepPeriod.Text = "Отгрузки за период";
            // 
            // miRepStatistic
            // 
            this.miRepStatistic.Name = "miRepStatistic";
            this.miRepStatistic.Size = new System.Drawing.Size(192, 22);
            this.miRepStatistic.Text = "Статистика за период";
            // 
            // miRepTC
            // 
            this.miRepTC.Name = "miRepTC";
            this.miRepTC.Size = new System.Drawing.Size(192, 22);
            this.miRepTC.Text = "Отчёт по ТС";
            // 
            // miAdditional
            // 
            this.miAdditional.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCalcOrderVolume,
            this.miCurrentTask});
            this.miAdditional.Name = "miAdditional";
            this.miAdditional.Size = new System.Drawing.Size(107, 20);
            this.miAdditional.Text = "Дополнительно";
            // 
            // miCalcOrderVolume
            // 
            this.miCalcOrderVolume.Name = "miCalcOrderVolume";
            this.miCalcOrderVolume.Size = new System.Drawing.Size(248, 22);
            this.miCalcOrderVolume.Text = "Рассчет объема заказа";
            // 
            // miCurrentTask
            // 
            this.miCurrentTask.Name = "miCurrentTask";
            this.miCurrentTask.Size = new System.Drawing.Size(248, 22);
            this.miCurrentTask.Text = "Текущие операционные задачи";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusInfo});
            this.statusStrip2.Location = new System.Drawing.Point(0, 709);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1290, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // tabForms
            // 
            this.tabForms.Controls.Add(this.tabMain);
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForms.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabForms.ItemSize = new System.Drawing.Size(180, 18);
            this.tabForms.Location = new System.Drawing.Point(0, 44);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(1290, 665);
            this.tabForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabForms.TabIndex = 4;
            this.tabForms.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabForms_DrawItem);
            this.tabForms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDown);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tblShipments);
            this.tabMain.Controls.Add(this.panelMain);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1282, 639);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Операции";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tblShipments
            // 
            this.tblShipments.AllColumns.Add(this.colOrderDetail);
            this.tblShipments.AllColumns.Add(this.colId);
            this.tblShipments.AllColumns.Add(this.colIdNakl);
            this.tblShipments.AllColumns.Add(this.colDate);
            this.tblShipments.AllColumns.Add(this.colTime);
            this.tblShipments.AllColumns.Add(this.colDirection);
            this.tblShipments.AllColumns.Add(this.colOrderId);
            this.tblShipments.AllColumns.Add(this.colOrdPartLVCode);
            this.tblShipments.AllColumns.Add(this.colOrderType);
            this.tblShipments.AllColumns.Add(this.colKlientId);
            this.tblShipments.AllColumns.Add(this.colKlientName);
            this.tblShipments.AllColumns.Add(this.colStatus);
            this.tblShipments.AllColumns.Add(this.colCopmletePct);
            this.tblShipments.AllColumns.Add(this.PrcValue);
            this.tblShipments.AllColumns.Add(this.colDoneShare);
            this.tblShipments.AllColumns.Add(this.colComment);
            this.tblShipments.AllColumns.Add(this.colOrderComment);
            this.tblShipments.AllColumns.Add(this.colGate);
            this.tblShipments.AllColumns.Add(this.colSpecCond);
            this.tblShipments.AllColumns.Add(this.colDriverPhone);
            this.tblShipments.AllColumns.Add(this.colDriverName);
            this.tblShipments.AllColumns.Add(this.colTransComp);
            this.tblShipments.AllColumns.Add(this.colTransportType);
            this.tblShipments.AllColumns.Add(this.colTrackNumber);
            this.tblShipments.AllColumns.Add(this.colTrailerNumber);
            this.tblShipments.AllColumns.Add(this.colAttorneyNumber);
            this.tblShipments.AllColumns.Add(this.colAttorneyDate);
            this.tblShipments.AllColumns.Add(this.colSubmissionTime);
            this.tblShipments.AllColumns.Add(this.colStartTime);
            this.tblShipments.AllColumns.Add(this.colEndTimePlan);
            this.tblShipments.AllColumns.Add(this.colEndTimeFact);
            this.tblShipments.AllColumns.Add(this.colDelayReason);
            this.tblShipments.AllColumns.Add(this.colDelayComment);
            this.tblShipments.AllColumns.Add(this.colDepositor);
            this.tblShipments.AllColumns.Add(this.colStampNumber);
            this.tblShipments.AllColumns.Add(this.FontColor);
            this.tblShipments.AllColumns.Add(this.BackgroundColor);
            this.tblShipments.AllColumns.Add(this.IsAddLv);
            this.tblShipments.AllColumns.Add(this.colShippingPlacesNumber);
            this.tblShipments.AllColumns.Add(this.colOrderWeight);
            this.tblShipments.AllColumns.Add(this.colSupplier);
            this.tblShipments.AllColumns.Add(this.colIsEdm);
            this.tblShipments.AllColumns.Add(this.colTransportView);
            this.tblShipments.AllColumns.Add(this.colWarehouseName);
            this.tblShipments.AllColumns.Add(this.colOrdLvId);
            this.tblShipments.AllColumns.Add(this.olvRowNumberRange);
            this.tblShipments.AlternateRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tblShipments.CellEditUseWholeCell = false;
            this.tblShipments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderDetail,
            this.colId,
            this.colIdNakl,
            this.colDate,
            this.colTime,
            this.colDirection,
            this.colOrderId,
            this.colOrdPartLVCode,
            this.colOrderType,
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
            this.IsAddLv,
            this.colShippingPlacesNumber,
            this.colOrderWeight,
            this.colSupplier,
            this.colIsEdm,
            this.colTransportView,
            this.colWarehouseName});
            this.tblShipments.Cursor = System.Windows.Forms.Cursors.Default;
            this.tblShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShipments.FullRowSelect = true;
            this.tblShipments.GridLines = true;
            this.tblShipments.HeaderWordWrap = true;
            this.tblShipments.HideSelection = false;
            this.tblShipments.Location = new System.Drawing.Point(3, 59);
            this.tblShipments.Name = "tblShipments";
            this.tblShipments.RowHeight = 25;
            this.tblShipments.SelectColumnsOnRightClick = false;
            this.tblShipments.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.tblShipments.ShowGroups = false;
            this.tblShipments.Size = new System.Drawing.Size(1276, 577);
            this.tblShipments.TabIndex = 1;
            this.tblShipments.UseAlternatingBackColors = true;
            this.tblShipments.UseCompatibleStateImageBehavior = false;
            this.tblShipments.View = System.Windows.Forms.View.Details;
            this.tblShipments.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.tblShipments_FormatRow);
            this.tblShipments.DoubleClick += new System.EventHandler(this.tblShipments_DoubleClick);
            // 
            // colOrderDetail
            // 
            this.colOrderDetail.AspectName = "OrderDetailInit";
            this.colOrderDetail.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.colOrderDetail.CellPadding = new System.Drawing.Rectangle(0, 0, 5, 0);
            this.colOrderDetail.IsButton = true;
            this.colOrderDetail.Name = "colOrderDetail";
            this.colOrderDetail.Text = "...";
            this.colOrderDetail.Width = 31;
            // 
            // colId
            // 
            this.colId.AspectName = "ShpId";
            this.colId.Name = "colId";
            this.colId.Text = "ID погр.";
            this.colId.Width = 100;
            // 
            // colIdNakl
            // 
            this.colIdNakl.AspectName = "OrdId";
            this.colIdNakl.Name = "colIdNakl";
            this.colIdNakl.Text = "ID накл.";
            this.colIdNakl.Width = 100;
            // 
            // colDate
            // 
            this.colDate.AspectName = "ShpDate";
            this.colDate.Name = "colDate";
            this.colDate.Text = "Дата";
            this.colDate.Width = 100;
            // 
            // colTime
            // 
            this.colTime.AspectName = "SlotTime";
            this.colTime.Name = "colTime";
            this.colTime.Text = "Время";
            this.colTime.Width = 85;
            // 
            // colDirection
            // 
            this.colDirection.AspectName = "InOut";
            this.colDirection.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.colDirection.Name = "colDirection";
            this.colDirection.Text = "Напр.";
            this.colDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDirection.Width = 43;
            // 
            // colOrderId
            // 
            this.colOrderId.AspectName = "OrdLVCode";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.Text = "Код заказа";
            this.colOrderId.Width = 200;
            // 
            // colOrdPartLVCode
            // 
            this.colOrdPartLVCode.AspectName = "OrdPartLVCode";
            this.colOrdPartLVCode.Name = "colOrdPartLVCode";
            this.colOrdPartLVCode.Text = "Код расходной партии";
            this.colOrdPartLVCode.Width = 150;
            // 
            // colOrderType
            // 
            this.colOrderType.AspectName = "OrdLVType";
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.Text = "Тип заказа";
            this.colOrderType.Width = 100;
            // 
            // colKlientId
            // 
            this.colKlientId.IsVisible = false;
            this.colKlientId.Name = "colKlientId";
            this.colKlientId.Text = "Код клиента";
            // 
            // colKlientName
            // 
            this.colKlientName.AspectName = "KlientName";
            this.colKlientName.Name = "colKlientName";
            this.colKlientName.Text = "Клиент";
            this.colKlientName.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.AspectName = "OrderStatus";
            this.colStatus.Name = "colStatus";
            this.colStatus.Text = "Статус";
            this.colStatus.Width = 100;
            // 
            // colCopmletePct
            // 
            this.colCopmletePct.AspectName = "PrcReady";
            this.colCopmletePct.Name = "colCopmletePct";
            this.colCopmletePct.Text = "Собран (в %)";
            this.colCopmletePct.Width = 100;
            // 
            // PrcValue
            // 
            this.PrcValue.AspectName = "PrcReady";
            this.PrcValue.Name = "PrcValue";
            this.PrcValue.Text = "PrcValue";
            this.PrcValue.Width = 100;
            // 
            // colDoneShare
            // 
            this.colDoneShare.AspectName = "DoneShare";
            this.colDoneShare.Name = "colDoneShare";
            this.colDoneShare.Renderer = this.barRenderer1;
            this.colDoneShare.Text = "DoneShare";
            this.colDoneShare.Width = 92;
            // 
            // barRenderer1
            // 
            this.barRenderer1.MaximumValue = 1D;
            // 
            // colComment
            // 
            this.colComment.AspectName = "ShpComment";
            this.colComment.Name = "colComment";
            this.colComment.Text = "Комментарий по загрузке";
            this.colComment.Width = 100;
            // 
            // colOrderComment
            // 
            this.colOrderComment.AspectName = "OrdComment";
            this.colOrderComment.Name = "colOrderComment";
            this.colOrderComment.Text = "Комментарий по заказу";
            this.colOrderComment.Width = 100;
            // 
            // colGate
            // 
            this.colGate.AspectName = "GateName";
            this.colGate.Name = "colGate";
            this.colGate.Text = "Ворота";
            this.colGate.Width = 100;
            // 
            // colSpecCond
            // 
            this.colSpecCond.AspectName = "ShpSpecialCond";
            this.colSpecCond.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.colSpecCond.CheckBoxes = true;
            this.colSpecCond.IsEditable = false;
            this.colSpecCond.Name = "colSpecCond";
            this.colSpecCond.Text = "Спец. Условия";
            this.colSpecCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colDriverPhone
            // 
            this.colDriverPhone.AspectName = "ShpDriverPhone";
            this.colDriverPhone.Name = "colDriverPhone";
            this.colDriverPhone.Text = "Телефон водителя";
            this.colDriverPhone.Width = 100;
            // 
            // colDriverName
            // 
            this.colDriverName.AspectName = "ShpDriverFio";
            this.colDriverName.Name = "colDriverName";
            this.colDriverName.Text = "ФИО водителя";
            this.colDriverName.Width = 150;
            // 
            // colTransComp
            // 
            this.colTransComp.AspectName = "TransportCompanyName";
            this.colTransComp.Name = "colTransComp";
            this.colTransComp.Text = "Транспортная компания";
            this.colTransComp.Width = 100;
            // 
            // colTransportType
            // 
            this.colTransportType.AspectName = "TransportTypeName";
            this.colTransportType.Name = "colTransportType";
            this.colTransportType.Text = "Марка ТС";
            this.colTransportType.Width = 100;
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.AspectName = "ShpVehicleNumber";
            this.colTrackNumber.Name = "colTrackNumber";
            this.colTrackNumber.Text = "Номер ТС";
            this.colTrackNumber.Width = 100;
            // 
            // colTrailerNumber
            // 
            this.colTrailerNumber.AspectName = "ShpTrailerNumber";
            this.colTrailerNumber.Name = "colTrailerNumber";
            this.colTrailerNumber.Text = "Номер прицепа";
            this.colTrailerNumber.Width = 100;
            // 
            // colAttorneyNumber
            // 
            this.colAttorneyNumber.AspectName = "ShpAttorneyNumber";
            this.colAttorneyNumber.Name = "colAttorneyNumber";
            this.colAttorneyNumber.Text = "Номер доверенности";
            this.colAttorneyNumber.Width = 100;
            // 
            // colAttorneyDate
            // 
            this.colAttorneyDate.AspectName = "ShpAttorneyDate";
            this.colAttorneyDate.Name = "colAttorneyDate";
            this.colAttorneyDate.Text = "Дата доверенности";
            this.colAttorneyDate.Width = 100;
            // 
            // colSubmissionTime
            // 
            this.colSubmissionTime.AspectName = "ShpSubmissionTime";
            this.colSubmissionTime.Name = "colSubmissionTime";
            this.colSubmissionTime.Text = "Время подачи документов";
            this.colSubmissionTime.Width = 100;
            // 
            // colStartTime
            // 
            this.colStartTime.AspectName = "ShpStartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Text = "Время начала";
            this.colStartTime.Width = 100;
            // 
            // colEndTimePlan
            // 
            this.colEndTimePlan.AspectName = "ShpEndTimePlan";
            this.colEndTimePlan.Name = "colEndTimePlan";
            this.colEndTimePlan.Text = "Время окончания";
            this.colEndTimePlan.Width = 100;
            // 
            // colEndTimeFact
            // 
            this.colEndTimeFact.AspectName = "ShpEndTimeFact";
            this.colEndTimeFact.Name = "colEndTimeFact";
            this.colEndTimeFact.Text = "Убытие по факту";
            this.colEndTimeFact.Width = 100;
            // 
            // colDelayReason
            // 
            this.colDelayReason.AspectName = "ShpDelayReasonName";
            this.colDelayReason.Name = "colDelayReason";
            this.colDelayReason.Text = "Причина опоздания";
            this.colDelayReason.Width = 100;
            // 
            // colDelayComment
            // 
            this.colDelayComment.AspectName = "ShpDelayComment";
            this.colDelayComment.Name = "colDelayComment";
            this.colDelayComment.Text = "Комментарий по опозданию";
            this.colDelayComment.Width = 100;
            // 
            // colDepositor
            // 
            this.colDepositor.AspectName = "DepCode";
            this.colDepositor.Name = "colDepositor";
            this.colDepositor.Text = "Депозитор";
            this.colDepositor.Width = 100;
            // 
            // colStampNumber
            // 
            this.colStampNumber.AspectName = "ShpStampNumber";
            this.colStampNumber.Name = "colStampNumber";
            this.colStampNumber.Text = "№ пломбы";
            this.colStampNumber.Width = 100;
            // 
            // FontColor
            // 
            this.FontColor.AspectName = "FontColor";
            this.FontColor.IsVisible = false;
            this.FontColor.Name = "FontColor";
            this.FontColor.Text = "FontColor";
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.AspectName = "BackgroundColor";
            this.BackgroundColor.DisplayIndex = 32;
            this.BackgroundColor.IsVisible = false;
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Text = "BackgroundColor";
            // 
            // IsAddLv
            // 
            this.IsAddLv.AspectName = "IsAddLv";
            this.IsAddLv.CheckBoxes = true;
            this.IsAddLv.IsEditable = false;
            this.IsAddLv.Name = "IsAddLv";
            this.IsAddLv.Text = "Привязка к отгрузке";
            this.IsAddLv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IsAddLv.Width = 100;
            // 
            // colShippingPlacesNumber
            // 
            this.colShippingPlacesNumber.AspectName = "ShippingPlacesNumber";
            this.colShippingPlacesNumber.Name = "colShippingPlacesNumber";
            this.colShippingPlacesNumber.Text = "Кол-во отгрузочных мест";
            this.colShippingPlacesNumber.Width = 100;
            // 
            // colOrderWeight
            // 
            this.colOrderWeight.AspectName = "OrderWeight";
            this.colOrderWeight.Name = "colOrderWeight";
            this.colOrderWeight.Text = "Вес заказа";
            this.colOrderWeight.Width = 100;
            // 
            // colSupplier
            // 
            this.colSupplier.AspectName = "ShpSupplierName";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Text = "Поставщик";
            this.colSupplier.Width = 200;
            // 
            // colIsEdm
            // 
            this.colIsEdm.AspectName = "IsEdm";
            this.colIsEdm.CheckBoxes = true;
            this.colIsEdm.IsEditable = false;
            this.colIsEdm.Name = "colIsEdm";
            this.colIsEdm.Text = "ЭДО";
            this.colIsEdm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colTransportView
            // 
            this.colTransportView.AspectName = "TransportViewName";
            this.colTransportView.Name = "colTransportView";
            this.colTransportView.Text = "Вид транспорта";
            this.colTransportView.Width = 100;
            // 
            // colWarehouseName
            // 
            this.colWarehouseName.AspectName = "WarehouseName";
            this.colWarehouseName.Name = "colWarehouseName";
            this.colWarehouseName.Text = "Склад";
            this.colWarehouseName.Width = 100;
            // 
            // colOrdLvId
            // 
            this.colOrdLvId.AspectName = "OrdLVID";
            this.colOrdLvId.IsVisible = false;
            this.colOrdLvId.Name = "colOrdLvId";
            this.colOrdLvId.Text = "colOrdLvId";
            // 
            // olvRowNumberRange
            // 
            this.olvRowNumberRange.AspectName = "RowNumberRange";
            this.olvRowNumberRange.DisplayIndex = 41;
            this.olvRowNumberRange.IsVisible = false;
            this.olvRowNumberRange.Name = "olvRowNumberRange";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.edSearch);
            this.panelMain.Controls.Add(this.edCurrDay);
            this.panelMain.Controls.Add(this.btnGetNextDay);
            this.panelMain.Controls.Add(this.btnSearchNext);
            this.panelMain.Controls.Add(this.btnGetCurrentDay);
            this.panelMain.Controls.Add(this.btnSearch);
            this.panelMain.Controls.Add(this.btnGetLastDay);
            this.panelMain.Controls.Add(this.btnPrint);
            this.panelMain.Controls.Add(this.btnShowLog);
            this.panelMain.Controls.Add(this.btnRefresh);
            this.panelMain.Controls.Add(this.btnDelete);
            this.panelMain.Controls.Add(this.btnEdit);
            this.panelMain.Controls.Add(this.btnAdd);
            this.panelMain.Controls.Add(this.btnColumnVisible);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(3, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1276, 56);
            this.panelMain.TabIndex = 5;
            // 
            // edSearch
            // 
            this.edSearch.Location = new System.Drawing.Point(386, 5);
            this.edSearch.Name = "edSearch";
            this.edSearch.Size = new System.Drawing.Size(134, 20);
            this.edSearch.TabIndex = 8;
            this.edSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edSearch_KeyDown);
            // 
            // edCurrDay
            // 
            this.edCurrDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.edCurrDay.Location = new System.Drawing.Point(539, 5);
            this.edCurrDay.Name = "edCurrDay";
            this.edCurrDay.Size = new System.Drawing.Size(102, 20);
            this.edCurrDay.TabIndex = 7;
            this.edCurrDay.ValueChanged += new System.EventHandler(this.edCurrDay_ValueChanged);
            // 
            // btnGetNextDay
            // 
            this.btnGetNextDay.FlatAppearance.BorderSize = 0;
            this.btnGetNextDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetNextDay.Image = ((System.Drawing.Image)(resources.GetObject("btnGetNextDay.Image")));
            this.btnGetNextDay.Location = new System.Drawing.Point(611, 26);
            this.btnGetNextDay.Name = "btnGetNextDay";
            this.btnGetNextDay.Size = new System.Drawing.Size(30, 20);
            this.btnGetNextDay.TabIndex = 0;
            this.btnGetNextDay.UseVisualStyleBackColor = true;
            this.btnGetNextDay.Click += new System.EventHandler(this.btnGetNextDay_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.FlatAppearance.BorderSize = 0;
            this.btnSearchNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchNext.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchNext.Image")));
            this.btnSearchNext.Location = new System.Drawing.Point(422, 26);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(30, 20);
            this.btnSearchNext.TabIndex = 0;
            this.btnSearchNext.UseVisualStyleBackColor = true;
            this.btnSearchNext.Click += new System.EventHandler(this.btnSearchNext_Click);
            // 
            // btnGetCurrentDay
            // 
            this.btnGetCurrentDay.FlatAppearance.BorderSize = 0;
            this.btnGetCurrentDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetCurrentDay.Image = ((System.Drawing.Image)(resources.GetObject("btnGetCurrentDay.Image")));
            this.btnGetCurrentDay.Location = new System.Drawing.Point(575, 26);
            this.btnGetCurrentDay.Name = "btnGetCurrentDay";
            this.btnGetCurrentDay.Size = new System.Drawing.Size(30, 20);
            this.btnGetCurrentDay.TabIndex = 0;
            this.btnGetCurrentDay.UseVisualStyleBackColor = true;
            this.btnGetCurrentDay.Click += new System.EventHandler(this.btnGetCurrentDay_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(386, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 20);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGetLastDay
            // 
            this.btnGetLastDay.FlatAppearance.BorderSize = 0;
            this.btnGetLastDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetLastDay.Image = ((System.Drawing.Image)(resources.GetObject("btnGetLastDay.Image")));
            this.btnGetLastDay.Location = new System.Drawing.Point(539, 26);
            this.btnGetLastDay.Name = "btnGetLastDay";
            this.btnGetLastDay.Size = new System.Drawing.Size(30, 20);
            this.btnGetLastDay.TabIndex = 0;
            this.btnGetLastDay.UseVisualStyleBackColor = true;
            this.btnGetLastDay.Click += new System.EventHandler(this.btnGetLastDay_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(275, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(49, 49);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnShowLog
            // 
            this.btnShowLog.FlatAppearance.BorderSize = 0;
            this.btnShowLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowLog.Image = ((System.Drawing.Image)(resources.GetObject("btnShowLog.Image")));
            this.btnShowLog.Location = new System.Drawing.Point(220, 3);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(49, 49);
            this.btnShowLog.TabIndex = 0;
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(165, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(49, 49);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(110, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 49);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(55, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(49, 49);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 49);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnColumnVisible
            // 
            this.btnColumnVisible.FlatAppearance.BorderSize = 0;
            this.btnColumnVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColumnVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnColumnVisible.Image")));
            this.btnColumnVisible.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColumnVisible.Location = new System.Drawing.Point(330, 4);
            this.btnColumnVisible.Menu = this.contextMenuColumns;
            this.btnColumnVisible.Name = "btnColumnVisible";
            this.btnColumnVisible.Size = new System.Drawing.Size(50, 49);
            this.btnColumnVisible.TabIndex = 0;
            this.btnColumnVisible.UseVisualStyleBackColor = true;
            // 
            // contextMenuColumns
            // 
            this.contextMenuColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuColumns.Name = "contextMenuColumns";
            this.contextMenuColumns.Size = new System.Drawing.Size(81, 70);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "3";
            // 
            // headerFormatStyle1
            // 
            this.headerFormatStyle1.Hot = headerStateStyle1;
            headerStateStyle2.FrameWidth = 2F;
            this.headerFormatStyle1.Normal = headerStateStyle2;
            this.headerFormatStyle1.Pressed = headerStateStyle3;
            // 
            // imageListInOut
            // 
            this.imageListInOut.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListInOut.ImageStream")));
            this.imageListInOut.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListInOut.Images.SetKeyName(0, "InEx");
            this.imageListInOut.Images.SetKeyName(1, "OutEx");
            this.imageListInOut.Images.SetKeyName(2, "MoveEx");
            this.imageListInOut.Images.SetKeyName(3, "Out");
            this.imageListInOut.Images.SetKeyName(4, "Move");
            this.imageListInOut.Images.SetKeyName(5, "In");
            // 
            // imageListMain16
            // 
            this.imageListMain16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain16.ImageStream")));
            this.imageListMain16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain16.Images.SetKeyName(0, "icons8-add-16.png");
            this.imageListMain16.Images.SetKeyName(1, "icons8-analyze-16.png");
            this.imageListMain16.Images.SetKeyName(2, "icons8-delete-row-16.png");
            this.imageListMain16.Images.SetKeyName(3, "icons8-edit-16.png");
            this.imageListMain16.Images.SetKeyName(4, "icons8-filter-16.png");
            this.imageListMain16.Images.SetKeyName(5, "icons8-find-16.png");
            this.imageListMain16.Images.SetKeyName(6, "icons8-history-16.png");
            this.imageListMain16.Images.SetKeyName(7, "icons8-next-16.png");
            this.imageListMain16.Images.SetKeyName(8, "icons8-print-16.png");
            this.imageListMain16.Images.SetKeyName(9, "icons8-refresh-16.png");
            this.imageListMain16.Images.SetKeyName(10, "icons8-select-left-column-16.png");
            this.imageListMain16.Images.SetKeyName(11, "icons8-table-16.png");
            // 
            // imageListMain32
            // 
            this.imageListMain32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain32.ImageStream")));
            this.imageListMain32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain32.Images.SetKeyName(0, "icons8-add-32.png");
            this.imageListMain32.Images.SetKeyName(1, "icons8-close-32.png");
            this.imageListMain32.Images.SetKeyName(2, "icons8-edit-32.png");
            this.imageListMain32.Images.SetKeyName(3, "icons8-history-32.png");
            this.imageListMain32.Images.SetKeyName(4, "icons8-print-32.png");
            this.imageListMain32.Images.SetKeyName(5, "icons8-refresh-32_1.png");
            // 
            // panelFormHeader
            // 
            this.panelFormHeader.Controls.Add(this.lbMainFormCaption);
            this.panelFormHeader.Controls.Add(this.btnMainMenu);
            this.panelFormHeader.Controls.Add(this.btnMinimizeWindow);
            this.panelFormHeader.Controls.Add(this.btnMaximizeWindow);
            this.panelFormHeader.Controls.Add(this.btnCloseWindow);
            this.panelFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormHeader.Location = new System.Drawing.Point(0, 0);
            this.panelFormHeader.Name = "panelFormHeader";
            this.panelFormHeader.Size = new System.Drawing.Size(1290, 44);
            this.panelFormHeader.TabIndex = 6;
            this.panelFormHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelFormHeader_MouseDoubleClick);
            this.panelFormHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelFormHeader_MouseMove);
            // 
            // lbMainFormCaption
            // 
            this.lbMainFormCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMainFormCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMainFormCaption.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbMainFormCaption.Location = new System.Drawing.Point(37, 0);
            this.lbMainFormCaption.Name = "lbMainFormCaption";
            this.lbMainFormCaption.Size = new System.Drawing.Size(1136, 44);
            this.lbMainFormCaption.TabIndex = 1;
            this.lbMainFormCaption.Text = "Planning";
            this.lbMainFormCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMainFormCaption.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelFormHeader_MouseDoubleClick);
            this.lbMainFormCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelFormHeader_MouseMove);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.ContextMenuStrip = this.contextMenuMain;
            this.btnMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMainMenu.FlatAppearance.BorderSize = 0;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Image = global::Planning.Properties.Resources.icons8_menu_32;
            this.btnMainMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(37, 44);
            this.btnMainMenu.TabIndex = 0;
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMainMenu_MouseDown);
            // 
            // btnMinimizeWindow
            // 
            this.btnMinimizeWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizeWindow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizeWindow.FlatAppearance.BorderSize = 0;
            this.btnMinimizeWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeWindow.Image = global::Planning.Properties.Resources.icons8_minimize_window_32__2_;
            this.btnMinimizeWindow.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMinimizeWindow.Location = new System.Drawing.Point(1173, 0);
            this.btnMinimizeWindow.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnMinimizeWindow.Name = "btnMinimizeWindow";
            this.btnMinimizeWindow.Size = new System.Drawing.Size(43, 44);
            this.btnMinimizeWindow.TabIndex = 0;
            this.btnMinimizeWindow.UseVisualStyleBackColor = true;
            this.btnMinimizeWindow.Click += new System.EventHandler(this.btnMinimizeWindow_Click);
            // 
            // btnMaximizeWindow
            // 
            this.btnMaximizeWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximizeWindow.FlatAppearance.BorderSize = 0;
            this.btnMaximizeWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizeWindow.Image = global::Planning.Properties.Resources.icons8_maximize_window_32;
            this.btnMaximizeWindow.Location = new System.Drawing.Point(1216, 0);
            this.btnMaximizeWindow.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnMaximizeWindow.Name = "btnMaximizeWindow";
            this.btnMaximizeWindow.Size = new System.Drawing.Size(37, 44);
            this.btnMaximizeWindow.TabIndex = 0;
            this.btnMaximizeWindow.UseVisualStyleBackColor = true;
            this.btnMaximizeWindow.Click += new System.EventHandler(this.btnMaximizeWindow_Click);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseWindow.FlatAppearance.BorderSize = 0;
            this.btnCloseWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseWindow.Image = global::Planning.Properties.Resources.icons8_close_window_32;
            this.btnCloseWindow.Location = new System.Drawing.Point(1253, 0);
            this.btnCloseWindow.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(37, 44);
            this.btnCloseWindow.TabIndex = 0;
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemDict,
            this.toolStripMenuItemReport,
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemAdmin});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(190, 114);
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSettings,
            this.menuItemConnect});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemFile.Text = "Файл";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(152, 22);
            this.menuItemSettings.Text = "Настройки";
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // menuItemConnect
            // 
            this.menuItemConnect.Name = "menuItemConnect";
            this.menuItemConnect.Size = new System.Drawing.Size(152, 22);
            this.menuItemConnect.Text = "Подключение";
            this.menuItemConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // toolStripMenuItemDict
            // 
            this.toolStripMenuItemDict.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDictTimeSlot,
            this.menuItemDictDepositor,
            this.menuItemDictOpersType,
            this.menuItemDictDelayReasons,
            this.menuItemDictGates,
            this.menuItemDictTC,
            this.menuItemDoctSupplier,
            this.menuItemDictAttributes,
            this.menuItemDictTransportType,
            this.menuItemDictTransportView,
            this.menuItemDictWarehouse,
            this.menuItemDictCustomPosts});
            this.toolStripMenuItemDict.Name = "toolStripMenuItemDict";
            this.toolStripMenuItemDict.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemDict.Text = "Справочники";
            // 
            // menuItemDictTimeSlot
            // 
            this.menuItemDictTimeSlot.Name = "menuItemDictTimeSlot";
            this.menuItemDictTimeSlot.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictTimeSlot.Tag = "TimeSlot";
            this.menuItemDictTimeSlot.Text = "Тайм слоты";
            this.menuItemDictTimeSlot.Click += new System.EventHandler(this.menuItemDictTimeSlot_Click);
            // 
            // menuItemDictDepositor
            // 
            this.menuItemDictDepositor.Name = "menuItemDictDepositor";
            this.menuItemDictDepositor.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictDepositor.Tag = "Depositor";
            this.menuItemDictDepositor.Text = "Депозиторы";
            this.menuItemDictDepositor.Click += new System.EventHandler(this.menuItemDictDepositor_Click);
            // 
            // menuItemDictOpersType
            // 
            this.menuItemDictOpersType.Name = "menuItemDictOpersType";
            this.menuItemDictOpersType.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictOpersType.Tag = "OperType";
            this.menuItemDictOpersType.Text = "Типы операций";
            this.menuItemDictOpersType.Visible = false;
            this.menuItemDictOpersType.Click += new System.EventHandler(this.menuItemDictOpersType_Click);
            // 
            // menuItemDictDelayReasons
            // 
            this.menuItemDictDelayReasons.Name = "menuItemDictDelayReasons";
            this.menuItemDictDelayReasons.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictDelayReasons.Tag = "DelayReasons";
            this.menuItemDictDelayReasons.Text = "Причины задержки";
            this.menuItemDictDelayReasons.Click += new System.EventHandler(this.menuItemDictDelayReasons_Click);
            // 
            // menuItemDictGates
            // 
            this.menuItemDictGates.Name = "menuItemDictGates";
            this.menuItemDictGates.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictGates.Tag = "Gate";
            this.menuItemDictGates.Text = "Ворота";
            this.menuItemDictGates.Click += new System.EventHandler(this.menuItemDictGates_Click);
            // 
            // menuItemDictTC
            // 
            this.menuItemDictTC.Name = "menuItemDictTC";
            this.menuItemDictTC.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictTC.Tag = "TC";
            this.menuItemDictTC.Text = "Справочник ТК";
            this.menuItemDictTC.Click += new System.EventHandler(this.menuItemDictTC_Click);
            // 
            // menuItemDoctSupplier
            // 
            this.menuItemDoctSupplier.Name = "menuItemDoctSupplier";
            this.menuItemDoctSupplier.Size = new System.Drawing.Size(230, 22);
            this.menuItemDoctSupplier.Tag = "Supplier";
            this.menuItemDoctSupplier.Text = "Поставщики";
            this.menuItemDoctSupplier.Click += new System.EventHandler(this.menuItemDoctSupplier_Click);
            // 
            // menuItemDictAttributes
            // 
            this.menuItemDictAttributes.Name = "menuItemDictAttributes";
            this.menuItemDictAttributes.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictAttributes.Tag = "Attr";
            this.menuItemDictAttributes.Text = "Аттрибуты";
            this.menuItemDictAttributes.Click += new System.EventHandler(this.menuItemDictAttributes_Click);
            // 
            // menuItemDictTransportType
            // 
            this.menuItemDictTransportType.Name = "menuItemDictTransportType";
            this.menuItemDictTransportType.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictTransportType.Tag = "TransporType";
            this.menuItemDictTransportType.Text = "Типы транспортных средств";
            this.menuItemDictTransportType.Click += new System.EventHandler(this.menuItemDictTransportType_Click);
            // 
            // menuItemDictTransportView
            // 
            this.menuItemDictTransportView.Name = "menuItemDictTransportView";
            this.menuItemDictTransportView.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictTransportView.Tag = "TransporView";
            this.menuItemDictTransportView.Text = "Виды транспорта";
            this.menuItemDictTransportView.Click += new System.EventHandler(this.menuItemDictTransportView_Click);
            // 
            // menuItemDictWarehouse
            // 
            this.menuItemDictWarehouse.Name = "menuItemDictWarehouse";
            this.menuItemDictWarehouse.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictWarehouse.Tag = "Warehouse";
            this.menuItemDictWarehouse.Text = "Склады";
            this.menuItemDictWarehouse.Click += new System.EventHandler(this.menuItemDictWarehouse_Click);
            // 
            // menuItemDictCustomPosts
            // 
            this.menuItemDictCustomPosts.Name = "menuItemDictCustomPosts";
            this.menuItemDictCustomPosts.Size = new System.Drawing.Size(230, 22);
            this.menuItemDictCustomPosts.Tag = "CustomPost";
            this.menuItemDictCustomPosts.Text = "Таможенные посты";
            this.menuItemDictCustomPosts.Click += new System.EventHandler(this.menuItemDictCustomPosts_Click);
            // 
            // toolStripMenuItemReport
            // 
            this.toolStripMenuItemReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReportPeriod,
            this.menuItemReportStatistic,
            this.menuItemReportTC});
            this.toolStripMenuItemReport.Name = "toolStripMenuItemReport";
            this.toolStripMenuItemReport.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemReport.Text = "Отчеты";
            // 
            // menuItemReportPeriod
            // 
            this.menuItemReportPeriod.Name = "menuItemReportPeriod";
            this.menuItemReportPeriod.Size = new System.Drawing.Size(192, 22);
            this.menuItemReportPeriod.Text = "Отгрузки за период";
            this.menuItemReportPeriod.Click += new System.EventHandler(this.menuItemReportPeriod_Click);
            // 
            // menuItemReportStatistic
            // 
            this.menuItemReportStatistic.Name = "menuItemReportStatistic";
            this.menuItemReportStatistic.Size = new System.Drawing.Size(192, 22);
            this.menuItemReportStatistic.Text = "Статистика за период";
            // 
            // menuItemReportTC
            // 
            this.menuItemReportTC.Name = "menuItemReportTC";
            this.menuItemReportTC.Size = new System.Drawing.Size(192, 22);
            this.menuItemReportTC.Text = "Отчёт по ТС";
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemAdd.Text = "Дополнительно";
            // 
            // toolStripMenuItemAdmin
            // 
            this.toolStripMenuItemAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDictUserGroups,
            this.menuItemDictUsers});
            this.toolStripMenuItemAdmin.Name = "toolStripMenuItemAdmin";
            this.toolStripMenuItemAdmin.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemAdmin.Text = "Администрирование";
            // 
            // menuItemDictUserGroups
            // 
            this.menuItemDictUserGroups.Name = "menuItemDictUserGroups";
            this.menuItemDictUserGroups.Size = new System.Drawing.Size(201, 22);
            this.menuItemDictUserGroups.Tag = "UserGrp";
            this.menuItemDictUserGroups.Text = "Группы пользователей";
            this.menuItemDictUserGroups.Click += new System.EventHandler(this.menuItemDictUserGroups_Click);
            // 
            // menuItemDictUsers
            // 
            this.menuItemDictUsers.Name = "menuItemDictUsers";
            this.menuItemDictUsers.Size = new System.Drawing.Size(201, 22);
            this.menuItemDictUsers.Tag = "Users";
            this.menuItemDictUsers.Text = "Пользователи";
            this.menuItemDictUsers.Click += new System.EventHandler(this.menuItemDictUsers_Click);
            // 
            // MainFormEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 731);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.panelFormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormEx";
            this.Load += new System.EventHandler(this.MainFormEx_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabForms.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.contextMenuColumns.ResumeLayout(false);
            this.panelFormHeader.ResumeLayout(false);
            this.contextMenuMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mtiFile;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miConnect;
        private System.Windows.Forms.ToolStripMenuItem miDicts;
        private System.Windows.Forms.ToolStripMenuItem miDictUserGroup;
        private System.Windows.Forms.ToolStripMenuItem miDictUser;
        private System.Windows.Forms.ToolStripMenuItem miDictTimeSlot;
        private System.Windows.Forms.ToolStripMenuItem miDictDepositor;
        private System.Windows.Forms.ToolStripMenuItem miDictOpersType;
        private System.Windows.Forms.ToolStripMenuItem miDictDelayReasons;
        private System.Windows.Forms.ToolStripMenuItem miDictGates;
        private System.Windows.Forms.ToolStripMenuItem miDictTC;
        private System.Windows.Forms.ToolStripMenuItem miDictSupplier;
        private System.Windows.Forms.ToolStripMenuItem miAttributes;
        private System.Windows.Forms.ToolStripMenuItem miTransportType;
        private System.Windows.Forms.ToolStripMenuItem miTransportView;
        private System.Windows.Forms.ToolStripMenuItem miDictWarehouse;
        private System.Windows.Forms.ToolStripMenuItem miCustomPosts;
        private System.Windows.Forms.ToolStripMenuItem miReports;
        private System.Windows.Forms.ToolStripMenuItem miRepPeriod;
        private System.Windows.Forms.ToolStripMenuItem miRepStatistic;
        private System.Windows.Forms.ToolStripMenuItem miRepTC;
        private System.Windows.Forms.ToolStripMenuItem miAdditional;
        private System.Windows.Forms.ToolStripMenuItem miCalcOrderVolume;
        private System.Windows.Forms.ToolStripMenuItem miCurrentTask;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.TabPage tabMain;
        private BrightIdeasSoftware.ObjectListView tblShipments;
        private BrightIdeasSoftware.OLVColumn colOrderDetail;
        private BrightIdeasSoftware.OLVColumn colId;
        private BrightIdeasSoftware.OLVColumn colIdNakl;
        private BrightIdeasSoftware.OLVColumn colDate;
        private BrightIdeasSoftware.OLVColumn colTime;
        private BrightIdeasSoftware.OLVColumn colDirection;
        private BrightIdeasSoftware.OLVColumn colOrderId;
        private BrightIdeasSoftware.OLVColumn colOrdPartLVCode;
        private BrightIdeasSoftware.OLVColumn colOrderType;
        private BrightIdeasSoftware.OLVColumn colKlientId;
        private BrightIdeasSoftware.OLVColumn colKlientName;
        private BrightIdeasSoftware.OLVColumn colStatus;
        private BrightIdeasSoftware.OLVColumn colCopmletePct;
        private BrightIdeasSoftware.OLVColumn PrcValue;
        private BrightIdeasSoftware.OLVColumn colDoneShare;
        private BrightIdeasSoftware.OLVColumn colComment;
        private BrightIdeasSoftware.OLVColumn colOrderComment;
        private BrightIdeasSoftware.OLVColumn colGate;
        private BrightIdeasSoftware.OLVColumn colSpecCond;
        private BrightIdeasSoftware.OLVColumn colDriverPhone;
        private BrightIdeasSoftware.OLVColumn colDriverName;
        private BrightIdeasSoftware.OLVColumn colTransComp;
        private BrightIdeasSoftware.OLVColumn colTransportType;
        private BrightIdeasSoftware.OLVColumn colTrackNumber;
        private BrightIdeasSoftware.OLVColumn colTrailerNumber;
        private BrightIdeasSoftware.OLVColumn colAttorneyNumber;
        private BrightIdeasSoftware.OLVColumn colAttorneyDate;
        private BrightIdeasSoftware.OLVColumn colSubmissionTime;
        private BrightIdeasSoftware.OLVColumn colStartTime;
        private BrightIdeasSoftware.OLVColumn colEndTimePlan;
        private BrightIdeasSoftware.OLVColumn colEndTimeFact;
        private BrightIdeasSoftware.OLVColumn colDelayReason;
        private BrightIdeasSoftware.OLVColumn colDelayComment;
        private BrightIdeasSoftware.OLVColumn colDepositor;
        private BrightIdeasSoftware.OLVColumn colStampNumber;
        private BrightIdeasSoftware.OLVColumn FontColor;
        private BrightIdeasSoftware.OLVColumn BackgroundColor;
        private BrightIdeasSoftware.OLVColumn IsAddLv;
        private BrightIdeasSoftware.OLVColumn colShippingPlacesNumber;
        private BrightIdeasSoftware.OLVColumn colOrderWeight;
        private BrightIdeasSoftware.OLVColumn colSupplier;
        private BrightIdeasSoftware.OLVColumn colIsEdm;
        private BrightIdeasSoftware.OLVColumn colTransportView;
        private BrightIdeasSoftware.OLVColumn colWarehouseName;
        private BrightIdeasSoftware.OLVColumn colOrdLvId;
        private BrightIdeasSoftware.HeaderFormatStyle headerFormatStyle1;
        private BrightIdeasSoftware.BarRenderer barRenderer1;
        private System.Windows.Forms.ImageList imageListInOut;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Button btnPrint;
        private MenuButton btnColumnVisible;
        private System.Windows.Forms.DateTimePicker edCurrDay;
        private System.Windows.Forms.ImageList imageListMain16;
        private System.Windows.Forms.Button btnGetLastDay;
        private System.Windows.Forms.ImageList imageListMain32;
        private System.Windows.Forms.Button btnGetNextDay;
        private System.Windows.Forms.Button btnGetCurrentDay;
        private System.Windows.Forms.ContextMenuStrip contextMenuColumns;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.TextBox edSearch;
        private System.Windows.Forms.Button btnSearchNext;
        private System.Windows.Forms.Button btnSearch;
        private BrightIdeasSoftware.OLVColumn olvRowNumberRange;
        private System.Windows.Forms.Panel panelFormHeader;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btnMinimizeWindow;
        private System.Windows.Forms.Button btnMaximizeWindow;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDict;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictTimeSlot;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictDepositor;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictOpersType;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictDelayReasons;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictGates;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictTC;
        private System.Windows.Forms.ToolStripMenuItem menuItemDoctSupplier;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictAttributes;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictTransportType;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictTransportView;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictCustomPosts;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportPeriod;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportStatistic;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportTC;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictUserGroups;
        private System.Windows.Forms.ToolStripMenuItem menuItemDictUsers;
        private System.Windows.Forms.Label lbMainFormCaption;
    }
}