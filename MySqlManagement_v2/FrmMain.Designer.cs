namespace MySqlManagement_v2
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pagMain = new System.Windows.Forms.TabPage();
            this.pagSql = new System.Windows.Forms.TabPage();
            this.tblSqlPage = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConsoleOutput = new System.Windows.Forms.TextBox();
            this.scintilla1 = new ScintillaNET.Scintilla();
            this.userPictureItem1 = new MySqlManagement_v2.UI.UserPictureItem();
            this.casePictureItem1 = new MySqlManagement_v2.UI.CasePictureItem();
            this.lcdMonitorPictureItem1 = new MySqlManagement_v2.UI.LcdMonitorPictureItem();
            this.pictureItemContainer1 = new MySqlManagement_v2.UI.PictureItemContainer();
            this.tabControl1.SuspendLayout();
            this.pagMain.SuspendLayout();
            this.pagSql.SuspendLayout();
            this.tblSqlPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casePictureItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcdMonitorPictureItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pagMain);
            this.tabControl1.Controls.Add(this.pagSql);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // pagMain
            // 
            this.pagMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pagMain.Controls.Add(this.pictureItemContainer1);
            this.pagMain.Controls.Add(this.userPictureItem1);
            this.pagMain.Controls.Add(this.casePictureItem1);
            this.pagMain.Controls.Add(this.lcdMonitorPictureItem1);
            this.pagMain.Location = new System.Drawing.Point(4, 22);
            this.pagMain.Name = "pagMain";
            this.pagMain.Padding = new System.Windows.Forms.Padding(3);
            this.pagMain.Size = new System.Drawing.Size(738, 398);
            this.pagMain.TabIndex = 0;
            this.pagMain.Text = "Main";
            // 
            // pagSql
            // 
            this.pagSql.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pagSql.Controls.Add(this.tblSqlPage);
            this.pagSql.Location = new System.Drawing.Point(4, 22);
            this.pagSql.Name = "pagSql";
            this.pagSql.Padding = new System.Windows.Forms.Padding(3);
            this.pagSql.Size = new System.Drawing.Size(738, 398);
            this.pagSql.TabIndex = 1;
            this.pagSql.Text = "Sql";
            this.pagSql.ToolTipText = "Execute raw sql statements";
            // 
            // tblSqlPage
            // 
            this.tblSqlPage.ColumnCount = 1;
            this.tblSqlPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSqlPage.Controls.Add(this.menuStrip1, 0, 0);
            this.tblSqlPage.Controls.Add(this.groupBox1, 0, 2);
            this.tblSqlPage.Controls.Add(this.scintilla1, 0, 1);
            this.tblSqlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSqlPage.Location = new System.Drawing.Point(3, 3);
            this.tblSqlPage.Name = "tblSqlPage";
            this.tblSqlPage.RowCount = 3;
            this.tblSqlPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblSqlPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSqlPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tblSqlPage.Size = new System.Drawing.Size(732, 392);
            this.tblSqlPage.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.executeToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.outputToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.loadFileToolStripMenuItem.Text = "&Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 6);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.executeToolStripMenuItem.Text = "&Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createStatementToolStripMenuItem,
            this.deleteStatementToolStripMenuItem,
            this.insertStatementToolStripMenuItem,
            this.selectStatementToolStripMenuItem,
            this.setPasswordToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.insertToolStripMenuItem.Text = "&Insert";
            // 
            // createStatementToolStripMenuItem
            // 
            this.createStatementToolStripMenuItem.Name = "createStatementToolStripMenuItem";
            this.createStatementToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.createStatementToolStripMenuItem.Text = "&Create statement";
            this.createStatementToolStripMenuItem.Click += new System.EventHandler(this.createStatementToolStripMenuItem_Click);
            // 
            // deleteStatementToolStripMenuItem
            // 
            this.deleteStatementToolStripMenuItem.Name = "deleteStatementToolStripMenuItem";
            this.deleteStatementToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteStatementToolStripMenuItem.Text = "&Delete statement";
            this.deleteStatementToolStripMenuItem.Click += new System.EventHandler(this.deleteStatementToolStripMenuItem_Click);
            // 
            // insertStatementToolStripMenuItem
            // 
            this.insertStatementToolStripMenuItem.Name = "insertStatementToolStripMenuItem";
            this.insertStatementToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.insertStatementToolStripMenuItem.Text = "&Insert statement";
            this.insertStatementToolStripMenuItem.Click += new System.EventHandler(this.insertStatementToolStripMenuItem_Click);
            // 
            // selectStatementToolStripMenuItem
            // 
            this.selectStatementToolStripMenuItem.Name = "selectStatementToolStripMenuItem";
            this.selectStatementToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectStatementToolStripMenuItem.Text = "&Select statement";
            this.selectStatementToolStripMenuItem.Click += new System.EventHandler(this.selectStatementToolStripMenuItem_Click);
            // 
            // setPasswordToolStripMenuItem
            // 
            this.setPasswordToolStripMenuItem.Name = "setPasswordToolStripMenuItem";
            this.setPasswordToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setPasswordToolStripMenuItem.Text = "Set &Password";
            this.setPasswordToolStripMenuItem.Click += new System.EventHandler(this.setPasswordToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Checked = true;
            this.outputToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.outputToolStripMenuItem.Text = "&Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.outputToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConsoleOutput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 124);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // txtConsoleOutput
            // 
            this.txtConsoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsoleOutput.Location = new System.Drawing.Point(3, 16);
            this.txtConsoleOutput.Multiline = true;
            this.txtConsoleOutput.Name = "txtConsoleOutput";
            this.txtConsoleOutput.ReadOnly = true;
            this.txtConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsoleOutput.Size = new System.Drawing.Size(720, 105);
            this.txtConsoleOutput.TabIndex = 0;
            // 
            // scintilla1
            // 
            this.scintilla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla1.Location = new System.Drawing.Point(3, 32);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(726, 227);
            this.scintilla1.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla1.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla1.TabIndex = 3;
            // 
            // userPictureItem1
            // 
            this.userPictureItem1.CenterPosition = new System.Drawing.Point(50, 85);
            this.userPictureItem1.ID = "???";
            this.userPictureItem1.Image = ((System.Drawing.Image)(resources.GetObject("userPictureItem1.Image")));
            this.userPictureItem1.Location = new System.Drawing.Point(108, 63);
            this.userPictureItem1.Name = "userPictureItem1";
            this.userPictureItem1.Size = new System.Drawing.Size(201, 121);
            this.userPictureItem1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPictureItem1.TabIndex = 3;
            this.userPictureItem1.TabStop = false;
            // 
            // casePictureItem1
            // 
            this.casePictureItem1.CenterPosition = new System.Drawing.Point(50, 50);
            this.casePictureItem1.ID = "???";
            this.casePictureItem1.Image = ((System.Drawing.Image)(resources.GetObject("casePictureItem1.Image")));
            this.casePictureItem1.Location = new System.Drawing.Point(462, 6);
            this.casePictureItem1.Name = "casePictureItem1";
            this.casePictureItem1.Size = new System.Drawing.Size(80, 178);
            this.casePictureItem1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.casePictureItem1.TabIndex = 2;
            this.casePictureItem1.TabStop = false;
            // 
            // lcdMonitorPictureItem1
            // 
            this.lcdMonitorPictureItem1.CenterPosition = new System.Drawing.Point(50, 50);
            this.lcdMonitorPictureItem1.ID = "???";
            this.lcdMonitorPictureItem1.Image = ((System.Drawing.Image)(resources.GetObject("lcdMonitorPictureItem1.Image")));
            this.lcdMonitorPictureItem1.Location = new System.Drawing.Point(353, 91);
            this.lcdMonitorPictureItem1.Name = "lcdMonitorPictureItem1";
            this.lcdMonitorPictureItem1.Size = new System.Drawing.Size(103, 93);
            this.lcdMonitorPictureItem1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lcdMonitorPictureItem1.TabIndex = 1;
            this.lcdMonitorPictureItem1.TabStop = false;
            // 
            // pictureItemContainer1
            // 
            this.pictureItemContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureItemContainer1.Columns = 1;
            this.pictureItemContainer1.Location = new System.Drawing.Point(234, 229);
            this.pictureItemContainer1.Name = "pictureItemContainer1";
            this.pictureItemContainer1.Rows = 1;
            this.pictureItemContainer1.Size = new System.Drawing.Size(196, 148);
            this.pictureItemContainer1.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 424);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMain";
            this.Text = "Main Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.pagMain.ResumeLayout(false);
            this.pagSql.ResumeLayout(false);
            this.tblSqlPage.ResumeLayout(false);
            this.tblSqlPage.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casePictureItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcdMonitorPictureItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pagMain;
        private System.Windows.Forms.TabPage pagSql;
        private System.Windows.Forms.TableLayoutPanel tblSqlPage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectStatementToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConsoleOutput;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private ScintillaNET.Scintilla scintilla1;
        private System.Windows.Forms.ToolStripMenuItem createStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setPasswordToolStripMenuItem;
        private UI.LcdMonitorPictureItem lcdMonitorPictureItem1;
        private UI.CasePictureItem casePictureItem1;
        private UI.UserPictureItem userPictureItem1;
        private UI.PictureItemContainer pictureItemContainer1;
    }
}

