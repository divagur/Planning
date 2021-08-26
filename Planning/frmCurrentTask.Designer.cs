
namespace Planning
{
    partial class frmCurrentTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentTask));
            this.tblTaks = new System.Windows.Forms.DataGridView();
            this.timerUpdateTask = new System.Windows.Forms.Timer(this.components);
            this.colInOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPalletAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBoxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiecesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShpComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmissionTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeaveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoneShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackgroundColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblTaks)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTaks
            // 
            this.tblTaks.AllowUserToAddRows = false;
            this.tblTaks.AllowUserToDeleteRows = false;
            this.tblTaks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblTaks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tblTaks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTaks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInOut,
            this.colDate,
            this.colTime,
            this.colOrderId,
            this.colKlient,
            this.colState,
            this.colDone,
            this.colLineCount,
            this.colPalletAmount,
            this.colBoxAmount,
            this.colPiecesNumber,
            this.colShpComment,
            this.colGate,
            this.colSubmissionTime,
            this.colStartTime,
            this.colEndTime,
            this.colLeaveTime,
            this.colDoneShare,
            this.FontColor,
            this.BackgroundColor});
            this.tblTaks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTaks.Location = new System.Drawing.Point(0, 0);
            this.tblTaks.Name = "tblTaks";
            this.tblTaks.ReadOnly = true;
            this.tblTaks.RowHeadersVisible = false;
            this.tblTaks.Size = new System.Drawing.Size(1098, 632);
            this.tblTaks.TabIndex = 0;
            this.tblTaks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblTaks_CellContentClick);
            this.tblTaks.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tblTaks_CellPainting);
            this.tblTaks.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tblTaks_RowPrePaint);
            this.tblTaks.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tblTaks_Scroll);
            this.tblTaks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tblTaks_KeyDown);
            this.tblTaks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tblTaks_KeyUp);
            // 
            // timerUpdateTask
            // 
            this.timerUpdateTask.Tick += new System.EventHandler(this.timerUpdateTask_Tick);
            // 
            // colInOut
            // 
            this.colInOut.DataPropertyName = "InOut";
            this.colInOut.HeaderText = "Напр.";
            this.colInOut.Name = "colInOut";
            this.colInOut.ReadOnly = true;
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
            // colOrderId
            // 
            this.colOrderId.DataPropertyName = "OrdLVCode";
            this.colOrderId.HeaderText = "Код заказа";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.ReadOnly = true;
            // 
            // colKlient
            // 
            this.colKlient.DataPropertyName = "KlientName";
            this.colKlient.HeaderText = "Клиент";
            this.colKlient.Name = "colKlient";
            this.colKlient.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.DataPropertyName = "OrderStatus";
            this.colState.HeaderText = "Статус";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // colDone
            // 
            this.colDone.DataPropertyName = "PrcReady";
            this.colDone.HeaderText = "Собран в (%)";
            this.colDone.Name = "colDone";
            this.colDone.ReadOnly = true;
            // 
            // colLineCount
            // 
            this.colLineCount.DataPropertyName = "LineAmount";
            this.colLineCount.HeaderText = "Кол-во линий";
            this.colLineCount.Name = "colLineCount";
            this.colLineCount.ReadOnly = true;
            // 
            // colPalletAmount
            // 
            this.colPalletAmount.DataPropertyName = "PalletAmount";
            this.colPalletAmount.HeaderText = "Кол-во паллет";
            this.colPalletAmount.Name = "colPalletAmount";
            this.colPalletAmount.ReadOnly = true;
            // 
            // colBoxAmount
            // 
            this.colBoxAmount.DataPropertyName = "BoxAmount";
            this.colBoxAmount.HeaderText = "Кол-во коробов";
            this.colBoxAmount.Name = "colBoxAmount";
            this.colBoxAmount.ReadOnly = true;
            // 
            // colPiecesNumber
            // 
            this.colPiecesNumber.DataPropertyName = "PieceAmount";
            this.colPiecesNumber.HeaderText = "Кол-во штук";
            this.colPiecesNumber.Name = "colPiecesNumber";
            this.colPiecesNumber.ReadOnly = true;
            // 
            // colShpComment
            // 
            this.colShpComment.DataPropertyName = "ShpComment";
            this.colShpComment.HeaderText = "Комментарии по загрузке";
            this.colShpComment.Name = "colShpComment";
            this.colShpComment.ReadOnly = true;
            // 
            // colGate
            // 
            this.colGate.DataPropertyName = "GateName";
            this.colGate.HeaderText = "Номер ворот";
            this.colGate.Name = "colGate";
            this.colGate.ReadOnly = true;
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
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "ShpEndTimePlan";
            this.colEndTime.HeaderText = "Время окончания";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            // 
            // colLeaveTime
            // 
            this.colLeaveTime.DataPropertyName = "ShpEndTimeFact";
            this.colLeaveTime.HeaderText = "Убытие по факту";
            this.colLeaveTime.Name = "colLeaveTime";
            this.colLeaveTime.ReadOnly = true;
            // 
            // colDoneShare
            // 
            this.colDoneShare.DataPropertyName = "DoneShare";
            this.colDoneShare.HeaderText = "DoneShare";
            this.colDoneShare.Name = "colDoneShare";
            this.colDoneShare.ReadOnly = true;
            this.colDoneShare.Visible = false;
            // 
            // FontColor
            // 
            this.FontColor.DataPropertyName = "FontColor";
            this.FontColor.HeaderText = "FontColor";
            this.FontColor.Name = "FontColor";
            this.FontColor.ReadOnly = true;
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.DataPropertyName = "BackgroundColor";
            this.BackgroundColor.HeaderText = "BackgroundColor";
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.ReadOnly = true;
            // 
            // frmCurrentTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1098, 632);
            this.Controls.Add(this.tblTaks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCurrentTask";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Текущие операционные задачи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCurrentTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblTaks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblTaks;
        private System.Windows.Forms.Timer timerUpdateTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPalletAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiecesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShpComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubmissionTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeaveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoneShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackgroundColor;
    }
}