namespace Planning
{
    partial class SettingsWizard
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Соединение");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Отчеты", 1, 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWizard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvStep = new System.Windows.Forms.TreeView();
            this.imlStep = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pgStepView = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.edPassword = new System.Windows.Forms.TextBox();
            this.edUser = new System.Windows.Forms.TextBox();
            this.edBase = new System.Windows.Forms.TextBox();
            this.edServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pgStepView.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvStep);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 610);
            this.panel1.TabIndex = 0;
            // 
            // tvStep
            // 
            this.tvStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStep.ImageIndex = 0;
            this.tvStep.ImageList = this.imlStep;
            this.tvStep.Location = new System.Drawing.Point(0, 0);
            this.tvStep.Name = "tvStep";
            treeNode3.Name = "NodeConnection";
            treeNode3.Text = "Соединение";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "NodeReport";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "Отчеты";
            this.tvStep.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.tvStep.SelectedImageIndex = 0;
            this.tvStep.Size = new System.Drawing.Size(232, 610);
            this.tvStep.TabIndex = 1;
            this.tvStep.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvStep_NodeMouseClick);
            // 
            // imlStep
            // 
            this.imlStep.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStep.ImageStream")));
            this.imlStep.TransparentColor = System.Drawing.Color.Transparent;
            this.imlStep.Images.SetKeyName(0, "database_connect.png");
            this.imlStep.Images.SetKeyName(1, "report_picture.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(232, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 610);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pgStepView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(235, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 610);
            this.panel2.TabIndex = 2;
            // 
            // pgStepView
            // 
            this.pgStepView.Controls.Add(this.tabPage1);
            this.pgStepView.Controls.Add(this.tabPage2);
            this.pgStepView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgStepView.ItemSize = new System.Drawing.Size(10, 10);
            this.pgStepView.Location = new System.Drawing.Point(0, 0);
            this.pgStepView.Name = "pgStepView";
            this.pgStepView.SelectedIndex = 0;
            this.pgStepView.Size = new System.Drawing.Size(910, 610);
            this.pgStepView.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.edPassword);
            this.tabPage1.Controls.Add(this.edUser);
            this.tabPage1.Controls.Add(this.edBase);
            this.tabPage1.Controls.Add(this.edServer);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(902, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // edPassword
            // 
            this.edPassword.Location = new System.Drawing.Point(88, 84);
            this.edPassword.Name = "edPassword";
            this.edPassword.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(177, 20);
            this.edPassword.TabIndex = 10;
            // 
            // edUser
            // 
            this.edUser.Location = new System.Drawing.Point(88, 58);
            this.edUser.Name = "edUser";
            this.edUser.Size = new System.Drawing.Size(177, 20);
            this.edUser.TabIndex = 8;
            // 
            // edBase
            // 
            this.edBase.Location = new System.Drawing.Point(88, 33);
            this.edBase.Name = "edBase";
            this.edBase.Size = new System.Drawing.Size(256, 20);
            this.edBase.TabIndex = 6;
            // 
            // edServer
            // 
            this.edServer.Location = new System.Drawing.Point(88, 6);
            this.edServer.Name = "edServer";
            this.edServer.Size = new System.Drawing.Size(256, 20);
            this.edServer.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Пользователь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "База данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сервер";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 14);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(902, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SettingsWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 610);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "SettingsWizard";
            this.Text = "Настройки";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pgStepView.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvStep;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl pgStepView;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imlStep;
        private System.Windows.Forms.TextBox edPassword;
        private System.Windows.Forms.TextBox edUser;
        private System.Windows.Forms.TextBox edBase;
        private System.Windows.Forms.TextBox edServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}