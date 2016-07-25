using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySqlManagement_v2.ConnectionManagement;
using ScintillaNET;

namespace MySqlManagement_v2
{
    public partial class FrmMain : Form
    {
        public ConnectionManager ConnectionManager { get; set; }

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
        }

        private void InitScintillaTextBox()
        {
            scintilla1.Margins[0].Width = 20;
            
            scintilla1.Lexing.LexerLanguageMap["customSql"] = "sql";
            scintilla1.ConfigurationManager.CustomLocation = System.IO.Path.GetFullPath("ScintillaNET.xml");
            scintilla1.ConfigurationManager.Language = "customSql";
            scintilla1.ConfigurationManager.Configure();
        }

        private void FrmMain_FailureOnLoad(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            executeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            executeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
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
            var querys = RetrieveQueries(scintilla1.Text);
            var queryResults = querys.Select(q => ConnectionManager.ExecureRawQuery(q)).ToList();
            queryResults.ForEach(qR => WriteQueryResult(qR));
        }

        private List<string> RetrieveQueries(string queriesString)
        {
            if (queriesString != null && queriesString != string.Empty)
            {
                return queriesString.Trim().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToList();
            }
            return new List<string>();
        }

        private void WriteQueryResult(IQueryResult queryResult)
        {
            var outputBuilder = new StringBuilder();
            var typeResult = typeof(IQueryResult);

            outputBuilder.AppendLine(queryResult.ToString());
            outputBuilder.AppendLine(lilSep);

            var content = queryResult.ContentAsString();
            if (content != "")
            {
                outputBuilder.AppendLine(content);
            }

            txtConsoleOutput.Text += outputBuilder.ToString();
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

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConsoleOutput.Text = "";
        }

        private void selectStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Text = SelectStatement();
        }

        private void createStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void insertStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private string SelectStatement()
        {
            var strB = new StringBuilder();
            strB.AppendLine("SELECT * FROM AAA");
            strB.AppendLine("WHERE 1;");
            return strB.ToString();
        }

        
    }
}
