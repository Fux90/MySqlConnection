﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySqlManagement_v2.ConnectionManagement;
using ScintillaNET;
using System.IO;
using MySqlManagement_v2.UI;

namespace MySqlManagement_v2
{
    public partial class FrmMain : Form
    {
        public DbManager ConnectionManager { get; set; }
        
        public FrmMain()
        {
            InitializeComponent();

            this.Hide();

            var login = new FrmLogin();
            var result = login.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Load += (s, e) => FrmMain_FailureOnLoad(s, e);
            }
            else
            {
                ConnectionManager = login.ConnectionManager;
            }

            InitScintillaTextBox();

#if DEBUG
            FillUsers();
            FillCases();
            FillMonitors();
#endif
        }

#if DEBUG
        private void FillMonitors()
        {
            createIn(50, monitorContainer, () => new LcdMonitorPictureItem());
        }

        private void FillCases()
        {
            createIn(30, caseContainer, () => new CasePictureItem());
        }

        private void FillUsers()
        {
            createIn(12, userContainer, () => new UserPictureItem());
        }

        private delegate PictureItem PictureItemCreationMethod();
        private void createIn(int howMany, PictureItemContainer container, PictureItemCreationMethod creation)
        {
            for (int i = 0; i < howMany; i++)
            {
                var pI = creation();
                pI.ID = String.Format("#{0}", i);
                container.Add(pI);
            }
        }
#endif

        private void InitScintillaTextBox()
        {
            scintilla1.Margins[0].Width = 20;
            
            scintilla1.Lexing.LexerLanguageMap["customSql"] = "sql";
            scintilla1.ConfigurationManager.CustomLocation = System.IO.Path.GetFullPath("sqlStyle.xml");
            scintilla1.ConfigurationManager.Language = "customSql";
            scintilla1.ConfigurationManager.Configure();
        }

        private void FrmMain_FailureOnLoad(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RegisterShortcut(executeToolStripMenuItem, Keys.Control | Keys.E, "Ctrl+E");

            RegisterShortcut(createStatementToolStripMenuItem, Keys.Control | Keys.D1, "Ctrl+1");
            RegisterShortcut(deleteStatementToolStripMenuItem, Keys.Control | Keys.D2, "Ctrl+2");
            RegisterShortcut(insertStatementToolStripMenuItem, Keys.Control | Keys.D3, "Ctrl+3");
            RegisterShortcut(selectStatementToolStripMenuItem, Keys.Control | Keys.D4, "Ctrl+4");
            RegisterShortcut(setPasswordToolStripMenuItem, Keys.Control | Keys.D5, "Ctrl+5");
        }

        private void RegisterShortcut(ToolStripMenuItem stripMenuItem, Keys keys, string label)
        {
            stripMenuItem.ShortcutKeys = keys;
            stripMenuItem.ShortcutKeyDisplayString = label;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConnectionManager != null)
            {
                ConnectionManager.CloseConnection();
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var querys = DbManager.RetrieveQueries(scintilla1.Text);
            var queryResults = querys.Select(q => ConnectionManager.ExecureRawQuery(q)).ToList();
            queryResults.ForEach(qR => WriteQueryResult(qR));
        }

        private void WriteQueryResult(IQueryResult queryResult)
        {
            var outputBuilder = new StringBuilder();
            var typeResult = typeof(IQueryResult);

            // Response
            outputBuilder.AppendLine(queryResult.ToString());
            
            // Content of select, if any
            var content = queryResult.ContentAsString();
            if (content != "")
            {
                outputBuilder.AppendLine(queryResult.SchemaAsString());
                outputBuilder.AppendLine(content);
            }

            outputBuilder.AppendLine(lilSep);

            txtConsoleOutput.AppendText(outputBuilder.ToString());
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (outputToolStripMenuItem.Checked)
            {
                outputToolStripMenuItem.Checked = false;
                HideOutputConsole();
            }
            else
            {
                outputToolStripMenuItem.Checked = true;
                ShowOutputConsole();
            }
        }

        private void HideOutputConsole()
        {
            tblSqlPage.RowStyles[2].Height = 0;
        }

        private void ShowOutputConsole()
        {
            tblSqlPage.RowStyles[2].Height = 130;
        }

        const string lilSep = "-------------------------";

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string loadedFile;
            string errorMsg;
            var strB = new StringBuilder();

            if (loadSqlFile(scintilla1, out loadedFile, out errorMsg))
            {
                var msg = "Succesfully loaded";
                if (errorMsg != null && errorMsg != string.Empty)
                {
                    msg = "Error in loading";
                }
                
                strB.AppendFormat(  "{0} [{1}]{2}", 
                                    msg, 
                                    loadedFile, 
                                    errorMsg == null ? string.Empty : errorMsg);

                strB.AppendLine(lilSep);
                txtConsoleOutput.Text = strB.ToString();
            }
        }

        private bool loadSqlFile(   Scintilla scintilla1, 
                                    out string loadedFile, 
                                    out string errorMsg)
        {
            var res = false;
            loadedFile = string.Empty;
            errorMsg = string.Empty;

            using (var oDlg = new OpenFileDialog())
            {
                oDlg.Multiselect = false;
                oDlg.Filter = "Sql Files|*.sql|Text Files|*.txt|All Files|*.*";
                if (oDlg.ShowDialog() == DialogResult.OK)
                {
                    res = true;
                    loadedFile = Path.GetFileName(oDlg.FileName);

                    try
                    {
                        scintilla1.Text = File.ReadAllText(oDlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        errorMsg = ex.Message;
                        res = false;
                    }
                }
            }

            return res;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConsoleOutput.Text = string.Empty;
        }

        #region MENU AUTOMATIC SQL INSERTION

        private void createStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Text += CreateStatement();
        }

        private void deleteStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Text += DeleteStatement();
        }

        private void insertStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Text += InsertStatement();
        }
        
        private void selectStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Text += SelectStatement();
        }

        private void setPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Text += SetPasswordStatement();
        }

        #endregion

        #region AUTOMATIC SQL INSERTION

        private string CreateStatement()
        {
            var strB = new StringBuilder();
            strB.AppendLine("-- Creation example");
            strB.AppendLine("CREATE TABLE IF NOT EXISTS AAA(");
            strB.AppendLine("\taKey INT NOT NULL,");
            strB.AppendLine("\tPRIMARY KEY (aKey)");
            strB.AppendLine(");");
            return strB.ToString();
        }

        private string DeleteStatement()
        {
            var strB = new StringBuilder();
            strB.AppendLine("-- Table deletion example");
            strB.AppendLine("DROP TABLE AAA;");
            return strB.ToString();
        }

        private string InsertStatement()
        {
            var strB = new StringBuilder();
            strB.AppendLine("-- Insertion example");
            strB.AppendLine("INSERT INTO AAA");
            strB.AppendLine("VALUES(9);");
            return strB.ToString();
        }

        private string SelectStatement()
        {
            var strB = new StringBuilder();
            strB.AppendLine("-- Selection example");
            strB.AppendLine("SELECT * FROM AAA");
            strB.AppendLine("WHERE 1;");
            return strB.ToString();
        }

        private string SetPasswordStatement()
        {
            var strB = new StringBuilder();
            strB.AppendLine("-- Set password");
            strB.AppendLine("SET PASSWORD = PASSWORD('yourNewPassword');");
            return strB.ToString();
        }

        #endregion

        private void pictureItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
