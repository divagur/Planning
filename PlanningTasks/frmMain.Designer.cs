
namespace PlanningTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tblTaks = new System.Windows.Forms.DataGridView();
            this.timerUpdateTask = new System.Windows.Forms.Timer(this.components);
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKlient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonePrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShippingPlacesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssemblyPicking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssemblyPallet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssemblyMezzanine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsEDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoneShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackgroundColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackgroundColorRGB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontColorRGB = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colDate,
            this.colTime,
            this.colInOut,
            this.colOrderId,
            this.colKlient,
            this.colDonePrc,
            this.colGateName,
            this.colShippingPlacesNumber,
            this.colAmountDeposit,
            this.colAssemblyPicking,
            this.colAssemblyPallet,
            this.colAssemblyMezzanine,
            this.colIsEDM,
            this.colDoneShare,
            this.FontColor,
            this.BackgroundColor,
            this.BackgroundColorRGB,
            this.FontColorRGB});
            this.tblTaks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTaks.Location = new System.Drawing.Point(0, 0);
            this.tblTaks.MultiSelect = false;
            this.tblTaks.Name = "tblTaks";
            this.tblTaks.ReadOnly = true;
            this.tblTaks.RowHeadersVisible = false;
            this.tblTaks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTaks.Size = new System.Drawing.Size(1098, 632);
            this.tblTaks.TabIndex = 0;
            this.tblTaks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblTaks_CellContentClick);
            this.tblTaks.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tblTaks_CellPainting);
            this.tblTaks.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tblTaks_ColumnHeaderMouseDoubleClick);
            this.tblTaks.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tblTaks_RowPrePaint);
            this.tblTaks.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tblTaks_Scroll);
            this.tblTaks.SelectionChanged += new System.EventHandler(this.tblTaks_SelectionChanged);
            this.tblTaks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tblTaks_KeyDown);
            this.tblTaks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tblTaks_KeyUp);
            // 
            // timerUpdateTask
            // 
            this.timerUpdateTask.Tick += new System.EventHandler(this.timerUpdateTask_Tick);
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
            // colInOut
            // 
            this.colInOut.DataPropertyName = "InOut";
            this.colInOut.HeaderText = "Напр.";
            this.colInOut.Name = "colInOut";
            this.colInOut.ReadOnly = true;
            // 
            // colOrderId
            // 
            this.colOrderId.DataPropertyName = "LvOrderCode";
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
            // colDonePrc
            // 
            this.colDonePrc.DataPropertyName = "PrcReady";
            this.colDonePrc.HeaderText = "Собран в (%)";
            this.colDonePrc.Name = "colDonePrc";
            this.colDonePrc.ReadOnly = true;
            // 
            // colGateName
            // 
            this.colGateName.DataPropertyName = "GateName";
            this.colGateName.HeaderText = "Ворота";
            this.colGateName.Name = "colGateName";
            this.colGateName.ReadOnly = true;
            // 
            // colShippingPlacesNumber
            // 
            this.colShippingPlacesNumber.DataPropertyName = "ShippingPlacesNumber";
            this.colShippingPlacesNumber.HeaderText = "Кол-во отгрузочных мест";
            this.colShippingPlacesNumber.Name = "colShippingPlacesNumber";
            this.colShippingPlacesNumber.ReadOnly = true;
            // 
            // colAmountDeposit
            // 
            this.colAmountDeposit.DataPropertyName = "DepositCount";
            this.colAmountDeposit.HeaderText = "Кол-во пополнений";
            this.colAmountDeposit.Name = "colAmountDeposit";
            this.colAmountDeposit.ReadOnly = true;
            // 
            // colAssemblyPicking
            // 
            this.colAssemblyPicking.DataPropertyName = "AssemblyPicking";
            this.colAssemblyPicking.HeaderText = "Сборка пикинга";
            this.colAssemblyPicking.Name = "colAssemblyPicking";
            this.colAssemblyPicking.ReadOnly = true;
            // 
            // colAssemblyPallet
            // 
            this.colAssemblyPallet.DataPropertyName = "AssemblyPallet";
            this.colAssemblyPallet.HeaderText = "Сборка паллет";
            this.colAssemblyPallet.Name = "colAssemblyPallet";
            this.colAssemblyPallet.ReadOnly = true;
            // 
            // colAssemblyMezzanine
            // 
            this.colAssemblyMezzanine.DataPropertyName = "AssemblyMezzanine";
            this.colAssemblyMezzanine.HeaderText = "Сборка мезонин";
            this.colAssemblyMezzanine.Name = "colAssemblyMezzanine";
            this.colAssemblyMezzanine.ReadOnly = true;
            // 
            // colIsEDM
            // 
            this.colIsEDM.HeaderText = "ЭДО";
            this.colIsEDM.Name = "colIsEDM";
            this.colIsEDM.ReadOnly = true;
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
            this.FontColor.Visible = false;
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.DataPropertyName = "BackgroundColor";
            this.BackgroundColor.HeaderText = "BackgroundColor";
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.ReadOnly = true;
            this.BackgroundColor.Visible = false;
            // 
            // BackgroundColorRGB
            // 
            this.BackgroundColorRGB.DataPropertyName = "BackgroundColorRGB";
            this.BackgroundColorRGB.HeaderText = "BackgroundColorRGB";
            this.BackgroundColorRGB.Name = "BackgroundColorRGB";
            this.BackgroundColorRGB.ReadOnly = true;
            this.BackgroundColorRGB.Visible = false;
            // 
            // FontColorRGB
            // 
            this.FontColorRGB.DataPropertyName = "FontColorRGB";
            this.FontColorRGB.HeaderText = "CellFontColorRGB";
            this.FontColorRGB.Name = "FontColorRGB";
            this.FontColorRGB.ReadOnly = true;
            this.FontColorRGB.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1098, 632);
            this.Controls.Add(this.tblTaks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Текущие операционные задачи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmCurrentTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblTaks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblTaks;
        private System.Windows.Forms.Timer timerUpdateTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKlient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonePrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShippingPlacesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssemblyPicking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssemblyPallet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssemblyMezzanine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsEDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoneShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackgroundColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackgroundColorRGB;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontColorRGB;
    }
}