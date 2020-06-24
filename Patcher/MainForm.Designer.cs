namespace Patcher
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
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.pnPatchTree = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnPath = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tbTree = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnPatchTree.SuspendLayout();
            this.pnPath.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(1383, 25);
            this.tbMain.TabIndex = 0;
            this.tbMain.Text = "toolStrip1";
            // 
            // pnPatchTree
            // 
            this.pnPatchTree.Controls.Add(this.treeView1);
            this.pnPatchTree.Controls.Add(this.tbTree);
            this.pnPatchTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnPatchTree.Location = new System.Drawing.Point(0, 25);
            this.pnPatchTree.Name = "pnPatchTree";
            this.pnPatchTree.Size = new System.Drawing.Size(200, 579);
            this.pnPatchTree.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 579);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pnPath
            // 
            this.pnPath.Controls.Add(this.panel2);
            this.pnPath.Controls.Add(this.splitter2);
            this.pnPath.Controls.Add(this.panel1);
            this.pnPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPath.Location = new System.Drawing.Point(205, 25);
            this.pnPath.Name = "pnPath";
            this.pnPath.Size = new System.Drawing.Size(1178, 579);
            this.pnPath.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 554);
            this.treeView1.TabIndex = 0;
            // 
            // tbTree
            // 
            this.tbTree.Location = new System.Drawing.Point(0, 0);
            this.tbTree.Name = "tbTree";
            this.tbTree.Size = new System.Drawing.Size(200, 25);
            this.tbTree.TabIndex = 1;
            this.tbTree.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 343);
            this.panel1.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 343);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1178, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 233);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colStepName,
            this.colResult});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1178, 343);
            this.dataGridView1.TabIndex = 0;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "№";
            this.colNo.Name = "colNo";
            this.colNo.Width = 50;
            // 
            // colStepName
            // 
            this.colStepName.HeaderText = "Наименование ";
            this.colStepName.Name = "colStepName";
            this.colStepName.Width = 400;
            // 
            // colResult
            // 
            this.colResult.HeaderText = "Результат";
            this.colResult.Name = "colResult";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 604);
            this.Controls.Add(this.pnPath);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnPatchTree);
            this.Controls.Add(this.tbMain);
            this.Name = "frmMain";
            this.Text = "Патчер";
            this.pnPatchTree.ResumeLayout(false);
            this.pnPatchTree.PerformLayout();
            this.pnPath.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.Panel pnPatchTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnPath;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip tbTree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
    }
}

