#define DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySqlManagement_v2.ConnectionManagement;
using MySql.Data.MySqlClient;

namespace MySqlManagement_v2
{
    public partial class FrmLogin : Form
    {
        public DbManager ConnectionManager
        {
            get;
            private set;
        }

        public FrmLogin()
        {
            InitializeComponent();
            DefaultValues();

            this.DialogResult = DialogResult.Abort;
        }

        private void DefaultValues()
        {
#if DEBUG
            txtUserName.Text = "sql7128528";
            txtPassword.Text = "2q8qc6Nl2E";
#endif
            txtHost.Text = Properties.Settings.Default.Host;
            txtPort.Text = Properties.Settings.Default.Port.ToString();
            txtDbName.Text = Properties.Settings.Default.Database;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToDb(txtHost.Text,
                        txtPort.Text,
                        txtUserName.Text,
                        txtPassword.Text,
                        txtDbName.Text);
        }

        private void ConnectToDb(   string host, 
                                    string port, 
                                    string userName, 
                                    string pwd, 
                                    string database)
        {
            ConnectionManager = DbManager.Connect(      typeof(MySqlDbManager),
                                                        host,
                                                        UInt32.Parse(port),
                                                        userName,
                                                        pwd,
                                                        database);

            if (ConnectionManager != null)
            {
                MessageBox.Show(String.Format("Correctly connected to DB[{0}]", database),
                                "Connected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
