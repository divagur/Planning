namespace PlanningAdminSettings
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.edUser = new System.Windows.Forms.TextBox();
            this.edBase = new System.Windows.Forms.TextBox();
            this.edServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.edTransportViewDefault = new System.Windows.Forms.TextBox();
            this.edWarehouseDefault = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.edAdminLogin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.edAdminPwd = new System.Windows.Forms.TextBox();
            this.tabControlSettings.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageConnection);
            this.tabControlSettings.Controls.Add(this.tabPageCommon);
            this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(512, 266);
            this.tabControlSettings.TabIndex = 0;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.Controls.Add(this.edAdminPwd);
            this.tabPageConnection.Controls.Add(this.label8);
            this.tabPageConnection.Controls.Add(this.edAdminLogin);
            this.tabPageConnection.Controls.Add(this.label7);
            this.tabPageConnection.Controls.Add(this.edPassword);
            this.tabPageConnection.Controls.Add(this.edUser);
            this.tabPageConnection.Controls.Add(this.edBase);
            this.tabPageConnection.Controls.Add(this.edServer);
            this.tabPageConnection.Controls.Add(this.label4);
            this.tabPageConnection.Controls.Add(this.label3);
            this.tabPageConnection.Controls.Add(this.label2);
            this.tabPageConnection.Controls.Add(this.label1);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(504, 240);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Подключение";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(92, 90);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(177, 20);
            this.edPassword.TabIndex = 26;
            // 
            // edUser
            // 
            this.edUser.Location = new System.Drawing.Point(92, 64);
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(177, 20);
            this.edUser.TabIndex = 24;
            // 
            // edBase
            // 
            this.edBase.Location = new System.Drawing.Point(92, 38);
            this.edBase.Name = "edBase";
            this.edBase.Size = new System.Drawing.Size(220, 20);
            this.edBase.TabIndex = 22;
            // 
            // edServer
            // 
            this.edServer.Location = new System.Drawing.Point(56, 12);
            this.edServer.Name = "edServer";
            this.edServer.Size = new System.Drawing.Size(256, 20);
            this.edServer.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Пользователь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "База данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Сервер";
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.edTransportViewDefault);
            this.tabPageCommon.Controls.Add(this.edWarehouseDefault);
            this.tabPageCommon.Controls.Add(this.label6);
            this.tabPageCommon.Controls.Add(this.label5);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(504, 240);
            this.tabPageCommon.TabIndex = 1;
            this.tabPageCommon.Text = "Общие";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // edTransportViewDefault
            // 
            this.edTransportViewDefault.Location = new System.Drawing.Point(202, 44);
            this.edTransportViewDefault.Name = "edTransportViewDefault";
            this.edTransportViewDefault.Size = new System.Drawing.Size(100, 20);
            this.edTransportViewDefault.TabIndex = 1;
            // 
            // edWarehouseDefault
            // 
            this.edWarehouseDefault.Location = new System.Drawing.Point(153, 14);
            this.edWarehouseDefault.Name = "edWarehouseDefault";
            this.edWarehouseDefault.Size = new System.Drawing.Size(100, 20);
            this.edWarehouseDefault.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Код вида транспорта по умолчанию";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Код склада по умолчанию";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 38);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(88, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(7, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Принять";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Логин администратора";
            this.label7.Visible = false;
            // 
            // edAdminLogin
            // 
            this.edAdminLogin.Location = new System.Drawing.Point(137, 150);
            this.edAdminLogin.Name = "edAdminLogin";
            this.edAdminLogin.Size = new System.Drawing.Size(175, 20);
            this.edAdminLogin.TabIndex = 29;
            this.edAdminLogin.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Пароль администратора";
            this.label8.Visible = false;
            // 
            // edAdminPwd
            // 
            this.edAdminPwd.Location = new System.Drawing.Point(137, 176);
            this.edAdminPwd.Name = "edAdminPwd";
            this.edAdminPwd.PasswordChar = '*';
            this.edAdminPwd.Size = new System.Drawing.Size(175, 20);
            this.edAdminPwd.TabIndex = 29;
            this.edAdminPwd.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 304);
            this.Controls.Add(this.tabControlSettings);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настрока";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.TextBox edUser;
        private System.Windows.Forms.TextBox edBase;
        private System.Windows.Forms.TextBox edServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TextBox edTransportViewDefault;
        private System.Windows.Forms.TextBox edWarehouseDefault;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox edAdminLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edAdminPwd;
        private System.Windows.Forms.Label label8;
    }
}

