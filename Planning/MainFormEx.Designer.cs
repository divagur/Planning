
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
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle10 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle11 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle12 = new BrightIdeasSoftware.HeaderStateStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormEx));
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.headerFormatStyle1 = new BrightIdeasSoftware.HeaderFormatStyle();
            this.imageListInOut = new System.Windows.Forms.ImageList(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.edCurrDay = new System.Windows.Forms.DateTimePicker();
            this.btnGetNextDay = new System.Windows.Forms.Button();
            this.btnGetCurrentDay = new System.Windows.Forms.Button();
            this.btnGetLastDay = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnColumnVisible = new Planning.Controls.MenuButton();
            this.contextMenuColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageListMain16 = new System.Windows.Forms.ImageList(this.components);
            this.imageListMain32 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.edSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.menuMain.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).BeginInit();
            this.panelMain.SuspendLayout();
            this.contextMenuColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtiFile,
            this.miDicts,
            this.miReports,
            this.miAdditional});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(890, 24);
            this.menuMain.TabIndex = 1;
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 588);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(890, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(890, 508);
            this.tabControl1.TabIndex = 4;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tblShipments);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(882, 482);
            this.tabMain.TabIndex = 0;
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
            this.tblShipments.Location = new System.Drawing.Point(3, 3);
            this.tblShipments.Name = "tblShipments";
            this.tblShipments.RowHeight = 25;
            this.tblShipments.ShowGroups = false;
            this.tblShipments.Size = new System.Drawing.Size(876, 476);
            this.tblShipments.TabIndex = 1;
            this.tblShipments.UseAlternatingBackColors = true;
            this.tblShipments.UseCompatibleStateImageBehavior = false;
            this.tblShipments.View = System.Windows.Forms.View.Details;
            this.tblShipments.SelectedIndexChanged += new System.EventHandler(this.tblShipments_SelectedIndexChanged);
            // 
            // colOrderDetail
            // 
            this.colOrderDetail.AspectName = "OrderDetailInit";
            this.colOrderDetail.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.colOrderDetail.CellPadding = new System.Drawing.Rectangle(0, 0, 5, 0);
            this.colOrderDetail.IsButton = true;
            this.colOrderDetail.Text = "...";
            this.colOrderDetail.Width = 31;
            // 
            // colId
            // 
            this.colId.AspectName = "ShpId";
            this.colId.IsTileViewColumn = true;
            this.colId.Text = "ID погр.";
            this.colId.Width = 100;
            // 
            // colIdNakl
            // 
            this.colIdNakl.AspectName = "OrdId";
            this.colIdNakl.Text = "ID накл.";
            this.colIdNakl.Width = 100;
            // 
            // colDate
            // 
            this.colDate.AspectName = "ShpDate";
            this.colDate.Text = "Дата";
            this.colDate.Width = 100;
            // 
            // colTime
            // 
            this.colTime.AspectName = "SlotTime";
            this.colTime.Text = "Время";
            this.colTime.Width = 85;
            // 
            // colDirection
            // 
            this.colDirection.AspectName = "InOut";
            this.colDirection.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.colDirection.Text = "Напр.";
            this.colDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDirection.Width = 43;
            // 
            // colOrderId
            // 
            this.colOrderId.AspectName = "OrdLVCode";
            this.colOrderId.Text = "Код заказа";
            this.colOrderId.Width = 100;
            // 
            // colOrdPartLVCode
            // 
            this.colOrdPartLVCode.AspectName = "OrdPartLVCode";
            this.colOrdPartLVCode.Text = "Код расходной партии";
            this.colOrdPartLVCode.Width = 150;
            // 
            // colOrderType
            // 
            this.colOrderType.AspectName = "OrdLVType";
            this.colOrderType.Text = "Тип заказа";
            this.colOrderType.Width = 100;
            // 
            // colKlientId
            // 
            this.colKlientId.IsVisible = false;
            this.colKlientId.Text = "Код клиента";
            // 
            // colKlientName
            // 
            this.colKlientName.AspectName = "KlientName";
            this.colKlientName.Text = "Клиент";
            this.colKlientName.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.AspectName = "OrderStatus";
            this.colStatus.Text = "Статус";
            this.colStatus.Width = 100;
            // 
            // colCopmletePct
            // 
            this.colCopmletePct.AspectName = "PrcReady";
            this.colCopmletePct.Text = "Собран (в %)";
            this.colCopmletePct.Width = 100;
            // 
            // PrcValue
            // 
            this.PrcValue.AspectName = "PrcReady";
            this.PrcValue.Text = "PrcValue";
            this.PrcValue.Width = 100;
            // 
            // colDoneShare
            // 
            this.colDoneShare.AspectName = "DoneShare";
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
            this.colComment.Text = "Комментарий по загрузке";
            this.colComment.Width = 100;
            // 
            // colOrderComment
            // 
            this.colOrderComment.AspectName = "OrdComment";
            this.colOrderComment.Text = "Комментарий по заказу";
            this.colOrderComment.Width = 100;
            // 
            // colGate
            // 
            this.colGate.AspectName = "GateName";
            this.colGate.Text = "Ворота";
            this.colGate.Width = 100;
            // 
            // colSpecCond
            // 
            this.colSpecCond.AspectName = "ShpSpecialCond";
            this.colSpecCond.CheckBoxes = true;
            this.colSpecCond.Text = "Спец. Условия";
            // 
            // colDriverPhone
            // 
            this.colDriverPhone.AspectName = "ShpDriverPhone";
            this.colDriverPhone.Text = "Телефон водителя";
            this.colDriverPhone.Width = 100;
            // 
            // colDriverName
            // 
            this.colDriverName.AspectName = "ShpDriverFio";
            this.colDriverName.Text = "ФИО водителя";
            this.colDriverName.Width = 150;
            // 
            // colTransComp
            // 
            this.colTransComp.AspectName = "TransportCompanyName";
            this.colTransComp.Text = "Транспортная компания";
            this.colTransComp.Width = 100;
            // 
            // colTransportType
            // 
            this.colTransportType.AspectName = "TransportTypeName";
            this.colTransportType.Text = "Марка ТС";
            this.colTransportType.Width = 100;
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.AspectName = "ShpVehicleNumber";
            this.colTrackNumber.Text = "Номер ТС";
            this.colTrackNumber.Width = 100;
            // 
            // colTrailerNumber
            // 
            this.colTrailerNumber.AspectName = "ShpTrailerNumber";
            this.colTrailerNumber.Text = "Номер прицепа";
            this.colTrailerNumber.Width = 100;
            // 
            // colAttorneyNumber
            // 
            this.colAttorneyNumber.AspectName = "ShpAttorneyNumber";
            this.colAttorneyNumber.Text = "Номер доверенности";
            this.colAttorneyNumber.Width = 100;
            // 
            // colAttorneyDate
            // 
            this.colAttorneyDate.AspectName = "ShpAttorneyDate";
            this.colAttorneyDate.Text = "Дата доверенности";
            this.colAttorneyDate.Width = 100;
            // 
            // colSubmissionTime
            // 
            this.colSubmissionTime.AspectName = "ShpSubmissionTime";
            this.colSubmissionTime.Text = "Время подачи документов";
            this.colSubmissionTime.Width = 100;
            // 
            // colStartTime
            // 
            this.colStartTime.AspectName = "ShpStartTime";
            this.colStartTime.Text = "Время начала";
            this.colStartTime.Width = 100;
            // 
            // colEndTimePlan
            // 
            this.colEndTimePlan.AspectName = "ShpEndTimePlan";
            this.colEndTimePlan.Text = "Время окончания";
            this.colEndTimePlan.Width = 100;
            // 
            // colEndTimeFact
            // 
            this.colEndTimeFact.AspectName = "ShpEndTimeFact";
            this.colEndTimeFact.Text = "Убытие по факту";
            this.colEndTimeFact.Width = 100;
            // 
            // colDelayReason
            // 
            this.colDelayReason.AspectName = "ShpDelayReasonName";
            this.colDelayReason.Text = "Причина опоздания";
            this.colDelayReason.Width = 100;
            // 
            // colDelayComment
            // 
            this.colDelayComment.AspectName = "ShpDelayComment";
            this.colDelayComment.Text = "Комментарий по опозданию";
            this.colDelayComment.Width = 100;
            // 
            // colDepositor
            // 
            this.colDepositor.AspectName = "DepCode";
            this.colDepositor.Text = "Депозитор";
            this.colDepositor.Width = 100;
            // 
            // colStampNumber
            // 
            this.colStampNumber.AspectName = "ShpStampNumber";
            this.colStampNumber.Text = "№ пломбы";
            this.colStampNumber.Width = 100;
            // 
            // FontColor
            // 
            this.FontColor.AspectName = "FontColor";
            this.FontColor.IsVisible = false;
            this.FontColor.Text = "FontColor";
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.AspectName = "BackgroundColor";
            this.BackgroundColor.DisplayIndex = 32;
            this.BackgroundColor.IsVisible = false;
            this.BackgroundColor.Text = "BackgroundColor";
            // 
            // IsAddLv
            // 
            this.IsAddLv.AspectName = "IsAddLv";
            this.IsAddLv.CheckBoxes = true;
            this.IsAddLv.Text = "Привязка к отгрузке";
            this.IsAddLv.Width = 100;
            // 
            // colShippingPlacesNumber
            // 
            this.colShippingPlacesNumber.AspectName = "ShippingPlacesNumber";
            this.colShippingPlacesNumber.Text = "Кол-во отгрузочных мест";
            this.colShippingPlacesNumber.Width = 100;
            // 
            // colOrderWeight
            // 
            this.colOrderWeight.AspectName = "OrderWeight";
            this.colOrderWeight.Text = "Вес заказа";
            this.colOrderWeight.Width = 100;
            // 
            // colSupplier
            // 
            this.colSupplier.AspectName = "ShpSupplierName";
            this.colSupplier.Text = "Поставщик";
            this.colSupplier.Width = 200;
            // 
            // colIsEdm
            // 
            this.colIsEdm.AspectName = "IsEdm";
            this.colIsEdm.CheckBoxes = true;
            this.colIsEdm.Text = "ЭДО";
            // 
            // colTransportView
            // 
            this.colTransportView.AspectName = "TransportViewName";
            this.colTransportView.Text = "Вид транспорта";
            this.colTransportView.Width = 100;
            // 
            // colWarehouseName
            // 
            this.colWarehouseName.AspectName = "WarehouseName";
            this.colWarehouseName.Text = "Склад";
            this.colWarehouseName.Width = 100;
            // 
            // colOrdLvId
            // 
            this.colOrdLvId.AspectName = "OrdLVID";
            this.colOrdLvId.IsVisible = false;
            this.colOrdLvId.Text = "colOrdLvId";
            // 
            // headerFormatStyle1
            // 
            this.headerFormatStyle1.Hot = headerStateStyle10;
            headerStateStyle11.FrameWidth = 2F;
            this.headerFormatStyle1.Normal = headerStateStyle11;
            this.headerFormatStyle1.Pressed = headerStateStyle12;
            // 
            // imageListInOut
            // 
            this.imageListInOut.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListInOut.ImageStream")));
            this.imageListInOut.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListInOut.Images.SetKeyName(0, "icons8-enter-16.png");
            this.imageListInOut.Images.SetKeyName(1, "In");
            this.imageListInOut.Images.SetKeyName(2, "Out");
            this.imageListInOut.Images.SetKeyName(3, "Move");
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
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(890, 56);
            this.panelMain.TabIndex = 5;
            // 
            // edCurrDay
            // 
            this.edCurrDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.edCurrDay.Location = new System.Drawing.Point(539, 5);
            this.edCurrDay.Name = "edCurrDay";
            this.edCurrDay.Size = new System.Drawing.Size(102, 20);
            this.edCurrDay.TabIndex = 7;
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
            // edSearch
            // 
            this.edSearch.Location = new System.Drawing.Point(386, 5);
            this.edSearch.Name = "edSearch";
            this.edSearch.Size = new System.Drawing.Size(134, 20);
            this.edSearch.TabIndex = 8;
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
            // 
            // MainFormEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 610);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormEx";
            this.Text = "Planning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormEx_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.contextMenuColumns.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
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
    }
}