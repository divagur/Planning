namespace Planning
{
    partial class shipmen_edit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTransportCompany = new System.Windows.Forms.ComboBox();
            this.edShipmentComment = new System.Windows.Forms.TextBox();
            this.cbDelayReasons = new System.Windows.Forms.ComboBox();
            this.edDelayComment = new System.Windows.Forms.TextBox();
            this.gbTransport = new System.Windows.Forms.GroupBox();
            this.cmbTimeSlot = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbGate = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.edAttorneyIssued = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dtAttorneyDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.edAttorneyNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.edStamp = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.edTrailerNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.edVehicleNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.edForwarderFIO = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.edDriverPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.edDriverFIO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtEndDateFact = new System.Windows.Forms.DateTimePicker();
            this.dtEndDatePlan = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtSubmissionTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbIsCourier = new System.Windows.Forms.CheckBox();
            this.gbTransport.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Транспортная компания";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Комментарий по погрузке";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Причина опоздания";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Комментарий по опозданию";
            // 
            // cbTransportCompany
            // 
            this.cbTransportCompany.FormattingEnabled = true;
            this.cbTransportCompany.Location = new System.Drawing.Point(150, 6);
            this.cbTransportCompany.Name = "cbTransportCompany";
            this.cbTransportCompany.Size = new System.Drawing.Size(341, 21);
            this.cbTransportCompany.TabIndex = 5;
            // 
            // edShipmentComment
            // 
            this.edShipmentComment.Location = new System.Drawing.Point(159, 33);
            this.edShipmentComment.MaxLength = 500;
            this.edShipmentComment.Multiline = true;
            this.edShipmentComment.Name = "edShipmentComment";
            this.edShipmentComment.Size = new System.Drawing.Size(680, 61);
            this.edShipmentComment.TabIndex = 6;
            // 
            // cbDelayReasons
            // 
            this.cbDelayReasons.FormattingEnabled = true;
            this.cbDelayReasons.Location = new System.Drawing.Point(125, 100);
            this.cbDelayReasons.Name = "cbDelayReasons";
            this.cbDelayReasons.Size = new System.Drawing.Size(332, 21);
            this.cbDelayReasons.TabIndex = 7;
            // 
            // edDelayComment
            // 
            this.edDelayComment.Location = new System.Drawing.Point(169, 127);
            this.edDelayComment.MaxLength = 200;
            this.edDelayComment.Name = "edDelayComment";
            this.edDelayComment.Size = new System.Drawing.Size(670, 20);
            this.edDelayComment.TabIndex = 8;
            // 
            // gbTransport
            // 
            this.gbTransport.Controls.Add(this.cmbTimeSlot);
            this.gbTransport.Controls.Add(this.label20);
            this.gbTransport.Controls.Add(this.cmbGate);
            this.gbTransport.Controls.Add(this.label19);
            this.gbTransport.Controls.Add(this.edAttorneyIssued);
            this.gbTransport.Controls.Add(this.label18);
            this.gbTransport.Controls.Add(this.dtAttorneyDate);
            this.gbTransport.Controls.Add(this.label17);
            this.gbTransport.Controls.Add(this.edAttorneyNumber);
            this.gbTransport.Controls.Add(this.label16);
            this.gbTransport.Controls.Add(this.edStamp);
            this.gbTransport.Controls.Add(this.label15);
            this.gbTransport.Controls.Add(this.edTrailerNumber);
            this.gbTransport.Controls.Add(this.label14);
            this.gbTransport.Controls.Add(this.edVehicleNumber);
            this.gbTransport.Controls.Add(this.label13);
            this.gbTransport.Controls.Add(this.edForwarderFIO);
            this.gbTransport.Controls.Add(this.label12);
            this.gbTransport.Controls.Add(this.edDriverPhone);
            this.gbTransport.Controls.Add(this.label11);
            this.gbTransport.Controls.Add(this.edDriverFIO);
            this.gbTransport.Controls.Add(this.label10);
            this.gbTransport.Controls.Add(this.dtEndDateFact);
            this.gbTransport.Controls.Add(this.dtEndDatePlan);
            this.gbTransport.Controls.Add(this.label9);
            this.gbTransport.Controls.Add(this.label8);
            this.gbTransport.Controls.Add(this.dtStartTime);
            this.gbTransport.Controls.Add(this.label7);
            this.gbTransport.Controls.Add(this.dtSubmissionTime);
            this.gbTransport.Controls.Add(this.label6);
            this.gbTransport.Location = new System.Drawing.Point(15, 180);
            this.gbTransport.Name = "gbTransport";
            this.gbTransport.Size = new System.Drawing.Size(824, 293);
            this.gbTransport.TabIndex = 10;
            this.gbTransport.TabStop = false;
            // 
            // cmbTimeSlot
            // 
            this.cmbTimeSlot.FormattingEnabled = true;
            this.cmbTimeSlot.Location = new System.Drawing.Point(231, 226);
            this.cmbTimeSlot.Name = "cmbTimeSlot";
            this.cmbTimeSlot.Size = new System.Drawing.Size(121, 21);
            this.cmbTimeSlot.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(203, 229);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Слот";
            // 
            // cmbGate
            // 
            this.cmbGate.FormattingEnabled = true;
            this.cmbGate.Location = new System.Drawing.Point(60, 226);
            this.cmbGate.Name = "cmbGate";
            this.cmbGate.Size = new System.Drawing.Size(121, 21);
            this.cmbGate.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "Ворота";
            // 
            // edAttorneyIssued
            // 
            this.edAttorneyIssued.Location = new System.Drawing.Point(128, 200);
            this.edAttorneyIssued.Name = "edAttorneyIssued";
            this.edAttorneyIssued.Size = new System.Drawing.Size(494, 20);
            this.edAttorneyIssued.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Кем выдана дов-ть";
            // 
            // dtAttorneyDate
            // 
            this.dtAttorneyDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAttorneyDate.Location = new System.Drawing.Point(422, 174);
            this.dtAttorneyDate.Name = "dtAttorneyDate";
            this.dtAttorneyDate.Size = new System.Drawing.Size(200, 20);
            this.dtAttorneyDate.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(309, 177);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Дата доверенности";
            // 
            // edAttorneyNumber
            // 
            this.edAttorneyNumber.Location = new System.Drawing.Point(128, 174);
            this.edAttorneyNumber.Name = "edAttorneyNumber";
            this.edAttorneyNumber.Size = new System.Drawing.Size(170, 20);
            this.edAttorneyNumber.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "№ доверенности";
            // 
            // edStamp
            // 
            this.edStamp.Location = new System.Drawing.Point(128, 148);
            this.edStamp.Name = "edStamp";
            this.edStamp.Size = new System.Drawing.Size(169, 20);
            this.edStamp.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Пломба";
            // 
            // edTrailerNumber
            // 
            this.edTrailerNumber.Location = new System.Drawing.Point(421, 120);
            this.edTrailerNumber.Name = "edTrailerNumber";
            this.edTrailerNumber.Size = new System.Drawing.Size(100, 20);
            this.edTrailerNumber.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(349, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = " № прицепа";
            // 
            // edVehicleNumber
            // 
            this.edVehicleNumber.Location = new System.Drawing.Point(128, 122);
            this.edVehicleNumber.Name = "edVehicleNumber";
            this.edVehicleNumber.Size = new System.Drawing.Size(170, 20);
            this.edVehicleNumber.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "№ TC";
            // 
            // edForwarderFIO
            // 
            this.edForwarderFIO.Location = new System.Drawing.Point(128, 97);
            this.edForwarderFIO.Name = "edForwarderFIO";
            this.edForwarderFIO.Size = new System.Drawing.Size(481, 20);
            this.edForwarderFIO.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Ф.И.О. экспедитора";
            // 
            // edDriverPhone
            // 
            this.edDriverPhone.Location = new System.Drawing.Point(446, 71);
            this.edDriverPhone.Name = "edDriverPhone";
            this.edDriverPhone.Size = new System.Drawing.Size(163, 20);
            this.edDriverPhone.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Тел.";
            // 
            // edDriverFIO
            // 
            this.edDriverFIO.Location = new System.Drawing.Point(128, 71);
            this.edDriverFIO.Name = "edDriverFIO";
            this.edDriverFIO.Size = new System.Drawing.Size(279, 20);
            this.edDriverFIO.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Ф.И.О. водителя";
            // 
            // dtEndDateFact
            // 
            this.dtEndDateFact.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDateFact.Location = new System.Drawing.Point(409, 45);
            this.dtEndDateFact.Name = "dtEndDateFact";
            this.dtEndDateFact.Size = new System.Drawing.Size(200, 20);
            this.dtEndDateFact.TabIndex = 7;
            // 
            // dtEndDatePlan
            // 
            this.dtEndDatePlan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndDatePlan.Location = new System.Drawing.Point(128, 44);
            this.dtEndDatePlan.Name = "dtEndDatePlan";
            this.dtEndDatePlan.Size = new System.Drawing.Size(171, 20);
            this.dtEndDatePlan.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Убытие по факту";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Время окончания";
            // 
            // dtStartTime
            // 
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartTime.Location = new System.Drawing.Point(409, 19);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(200, 20);
            this.dtStartTime.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Время начала";
            // 
            // dtSubmissionTime
            // 
            this.dtSubmissionTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSubmissionTime.Location = new System.Drawing.Point(128, 18);
            this.dtSubmissionTime.Name = "dtSubmissionTime";
            this.dtSubmissionTime.Size = new System.Drawing.Size(171, 20);
            this.dtSubmissionTime.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Время подачи док.";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(791, 613);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(872, 613);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbIsCourier
            // 
            this.cbIsCourier.AutoSize = true;
            this.cbIsCourier.Location = new System.Drawing.Point(511, 9);
            this.cbIsCourier.Name = "cbIsCourier";
            this.cbIsCourier.Size = new System.Drawing.Size(126, 17);
            this.cbIsCourier.TabIndex = 13;
            this.cbIsCourier.Text = "Курьерская служба";
            this.cbIsCourier.UseVisualStyleBackColor = true;
            // 
            // shipmen_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 648);
            this.Controls.Add(this.cbIsCourier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbTransport);
            this.Controls.Add(this.edDelayComment);
            this.Controls.Add(this.cbDelayReasons);
            this.Controls.Add(this.edShipmentComment);
            this.Controls.Add(this.cbTransportCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "shipmen_edit";
            this.Text = "Редактирование погрузки";
            this.gbTransport.ResumeLayout(false);
            this.gbTransport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTransportCompany;
        private System.Windows.Forms.TextBox edShipmentComment;
        private System.Windows.Forms.ComboBox cbDelayReasons;
        private System.Windows.Forms.TextBox edDelayComment;
        private System.Windows.Forms.GroupBox gbTransport;
        private System.Windows.Forms.TextBox edDriverPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox edDriverFIO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtEndDateFact;
        private System.Windows.Forms.DateTimePicker dtEndDatePlan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtSubmissionTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edForwarderFIO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox edVehicleNumber;
        private System.Windows.Forms.TextBox edTrailerNumber;
        private System.Windows.Forms.TextBox edStamp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox edAttorneyNumber;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtAttorneyDate;
        private System.Windows.Forms.TextBox edAttorneyIssued;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbTimeSlot;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbGate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbIsCourier;
    }
}