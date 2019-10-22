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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictUserGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictUser = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictTimeSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictDepositor = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictOpersType = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictDelayReasons = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictGates = new System.Windows.Forms.ToolStripMenuItem();
            this.miDictTC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tblShipments = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdNakl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCopmletePct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecCond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDriverPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDriverName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDictUserGroup,
            this.miDictUser,
            this.miDictTimeSlot,
            this.miDictDepositor,
            this.miDictOpersType,
            this.miDictDelayReasons,
            this.miDictGates,
            this.miDictTC});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // miDictUserGroup
            // 
            this.miDictUserGroup.Name = "miDictUserGroup";
            this.miDictUserGroup.Size = new System.Drawing.Size(201, 22);
            this.miDictUserGroup.Text = "Группы пользователей";
            // 
            // miDictUser
            // 
            this.miDictUser.Name = "miDictUser";
            this.miDictUser.Size = new System.Drawing.Size(201, 22);
            this.miDictUser.Text = "Пользователи";
            // 
            // miDictTimeSlot
            // 
            this.miDictTimeSlot.Name = "miDictTimeSlot";
            this.miDictTimeSlot.Size = new System.Drawing.Size(201, 22);
            this.miDictTimeSlot.Text = "Тайм слоты";
            // 
            // miDictDepositor
            // 
            this.miDictDepositor.Name = "miDictDepositor";
            this.miDictDepositor.Size = new System.Drawing.Size(201, 22);
            this.miDictDepositor.Text = "Депозиторы";
            // 
            // miDictOpersType
            // 
            this.miDictOpersType.Name = "miDictOpersType";
            this.miDictOpersType.Size = new System.Drawing.Size(201, 22);
            this.miDictOpersType.Text = "Типы операций";
            // 
            // miDictDelayReasons
            // 
            this.miDictDelayReasons.Name = "miDictDelayReasons";
            this.miDictDelayReasons.Size = new System.Drawing.Size(201, 22);
            this.miDictDelayReasons.Text = "Причины задержки";
            this.miDictDelayReasons.Click += new System.EventHandler(this.miDictDelayReasons_Click);
            // 
            // miDictGates
            // 
            this.miDictGates.Name = "miDictGates";
            this.miDictGates.Size = new System.Drawing.Size(201, 22);
            this.miDictGates.Text = "Ворота";
            // 
            // miDictTC
            // 
            this.miDictTC.Name = "miDictTC";
            this.miDictTC.Size = new System.Drawing.Size(201, 22);
            this.miDictTC.Text = "Справочник ТК";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1016, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tblShipments
            // 
            this.tblShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIdNakl,
            this.colDate,
            this.colTime,
            this.colDirection,
            this.colOrderId,
            this.colOrderType,
            this.colKlientId,
            this.colKlientName,
            this.colComment,
            this.colOrderComment,
            this.colStatus,
            this.colCopmletePct,
            this.colGate,
            this.colSpecCond,
            this.colDriverPhone,
            this.colDriverName,
            this.colTransComp,
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
            this.colDepositor});
            this.tblShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShipments.Location = new System.Drawing.Point(0, 49);
            this.tblShipments.Name = "tblShipments";
            this.tblShipments.RowHeadersVisible = false;
            this.tblShipments.RowHeadersWidth = 20;
            this.tblShipments.Size = new System.Drawing.Size(1016, 503);
            this.tblShipments.TabIndex = 2;
            this.tblShipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblShipments_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID погр.";
            this.colId.Name = "colId";
            // 
            // colIdNakl
            // 
            this.colIdNakl.HeaderText = "ID накл.";
            this.colIdNakl.Name = "colIdNakl";
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Время";
            this.colTime.Name = "colTime";
            // 
            // colDirection
            // 
            this.colDirection.HeaderText = "Напр.";
            this.colDirection.Name = "colDirection";
            // 
            // colOrderId
            // 
            this.colOrderId.HeaderText = "Код заказа";
            this.colOrderId.Name = "colOrderId";
            // 
            // colOrderType
            // 
            this.colOrderType.HeaderText = "Тип заказа";
            this.colOrderType.Name = "colOrderType";
            // 
            // colKlientId
            // 
            this.colKlientId.HeaderText = "Код клиента";
            this.colKlientId.Name = "colKlientId";
            // 
            // colKlientName
            // 
            this.colKlientName.HeaderText = "Клиент";
            this.colKlientName.Name = "colKlientName";
            // 
            // colComment
            // 
            this.colComment.HeaderText = "Комментарий по загрузке";
            this.colComment.Name = "colComment";
            // 
            // colOrderComment
            // 
            this.colOrderComment.HeaderText = "Комментарий по заказу";
            this.colOrderComment.Name = "colOrderComment";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            // 
            // colCopmletePct
            // 
            this.colCopmletePct.HeaderText = "Собран (в %)";
            this.colCopmletePct.Name = "colCopmletePct";
            // 
            // colGate
            // 
            this.colGate.HeaderText = "Ворота";
            this.colGate.Name = "colGate";
            // 
            // colSpecCond
            // 
            this.colSpecCond.HeaderText = "Спец. Условия";
            this.colSpecCond.Name = "colSpecCond";
            // 
            // colDriverPhone
            // 
            this.colDriverPhone.HeaderText = "Телефон водителя";
            this.colDriverPhone.Name = "colDriverPhone";
            // 
            // colDriverName
            // 
            this.colDriverName.HeaderText = "ФИО водителя";
            this.colDriverName.Name = "colDriverName";
            // 
            // colTransComp
            // 
            this.colTransComp.HeaderText = "Транспортная компания";
            this.colTransComp.Name = "colTransComp";
            // 
            // colTrackNumber
            // 
            this.colTrackNumber.HeaderText = "Номер ТС";
            this.colTrackNumber.Name = "colTrackNumber";
            // 
            // colTrailerNumber
            // 
            this.colTrailerNumber.HeaderText = "Номер прицепа";
            this.colTrailerNumber.Name = "colTrailerNumber";
            // 
            // colAttorneyNumber
            // 
            this.colAttorneyNumber.HeaderText = "Номер доверенности";
            this.colAttorneyNumber.Name = "colAttorneyNumber";
            // 
            // colAttorneyDate
            // 
            this.colAttorneyDate.HeaderText = "Дата довереннсоти";
            this.colAttorneyDate.Name = "colAttorneyDate";
            // 
            // colSubmissionTime
            // 
            this.colSubmissionTime.HeaderText = "Время подачи документов";
            this.colSubmissionTime.Name = "colSubmissionTime";
            // 
            // colStartTime
            // 
            this.colStartTime.HeaderText = "Время начала";
            this.colStartTime.Name = "colStartTime";
            // 
            // colEndTimePlan
            // 
            this.colEndTimePlan.HeaderText = "Время окончания";
            this.colEndTimePlan.Name = "colEndTimePlan";
            // 
            // colEndTimeFact
            // 
            this.colEndTimeFact.HeaderText = "Убытие по факту";
            this.colEndTimeFact.Name = "colEndTimeFact";
            // 
            // colDelayReason
            // 
            this.colDelayReason.HeaderText = "Причина опоздания";
            this.colDelayReason.Name = "colDelayReason";
            // 
            // colDelayComment
            // 
            this.colDelayComment.HeaderText = "Комментарий по опозданию";
            this.colDelayComment.Name = "colDelayComment";
            // 
            // colDepositor
            // 
            this.colDepositor.HeaderText = "Депозитор";
            this.colDepositor.Name = "colDepositor";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 552);
            this.Controls.Add(this.tblShipments);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.RightToLeftLayout = true;
            this.Text = "Planning";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShipments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView tblShipments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdNakl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopmletePct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecCond;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDriverName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransComp;
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
        private System.Windows.Forms.ToolStripMenuItem miDictUserGroup;
        private System.Windows.Forms.ToolStripMenuItem miDictUser;
        private System.Windows.Forms.ToolStripMenuItem miDictTimeSlot;
        private System.Windows.Forms.ToolStripMenuItem miDictDepositor;
        private System.Windows.Forms.ToolStripMenuItem miDictOpersType;
        private System.Windows.Forms.ToolStripMenuItem miDictDelayReasons;
        private System.Windows.Forms.ToolStripMenuItem miDictGates;
        private System.Windows.Forms.ToolStripMenuItem miDictTC;
    }
}

