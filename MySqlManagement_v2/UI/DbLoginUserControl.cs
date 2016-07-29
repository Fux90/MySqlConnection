using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySqlManagement_v2.ConnectionManagement;

namespace MySqlManagement_v2.UI
{
    public delegate void DbConnectionDelegate(DbConnectionEventArgs e);

    public partial class DbLoginUserControl : UserControl
    {
        public DbManager ConnectionManager
        {
            get;
            private set;
        }

        public string UserName 
        {
            get
            {
                return txtUserName.Text;
            }

            set
            {
                txtUserName.Text = value;
            }
        }

        public string Password 
        {
            get
            {
                return txtPassword.Text;
            }

            set
            {
                txtPassword.Text = value;
            }
        }

        public string Host 
        {
            get
            {
                return txtHost.Text;
            }

            set
            {
                txtHost.Text = value;
            }
        }

        public string Port 
        {
            get
            {
                return txtPort.Text;
            }

            set
            {
                txtPort.Text = value;
            }
        }

        public string DbName 
        {
            get
            {
                return txtDbName.Text;
            }

            set
            {
                txtDbName.Text = value;
            }
        }

        public event EventHandler<DbConnectionEventArgs> OpenedConnection;

        public DbLoginUserControl()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToDb(txtHost.Text,
                        txtPort.Text,
                        txtUserName.Text,
                        txtPassword.Text,
                        txtDbName.Text);
        }

        private void ConnectToDb(string host,
                                    string port,
                                    string userName,
                                    string pwd,
                                    string database)
        {
            ConnectionManager = DbManager.Connect(typeof(MySqlDbManager),
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

                OnOpenedConnection(new DbConnectionEventArgs(ConnectionManager));
            }
        }

        protected void OnOpenedConnection(DbConnectionEventArgs e)
        {
            var openedConnection = OpenedConnection;
            if (openedConnection != null)
            {
                openedConnection(this, e);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect.PerformClick();
            }
        }
    }

    public class DbConnectionEventArgs : EventArgs
    {
        public DbManager ConnectionManager { get; private set; }

        public DbConnectionEventArgs(DbManager connectionManager)
        {
            ConnectionManager = connectionManager;
        }
    }
}
