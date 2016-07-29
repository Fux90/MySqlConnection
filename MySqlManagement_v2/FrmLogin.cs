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
using MySqlManagement_v2.UI;

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
            dbLoginUserControl1.OpenedConnection += new EventHandler<DbConnectionEventArgs>(dbLoginUserControl1_OpenedConnection);
        }

        private void DefaultValues()
        {
#if DEBUG
            dbLoginUserControl1.UserName = "sql7128528";
            //dbLoginUserControl1.Password = "2q8qc6Nl2E";
#endif
            dbLoginUserControl1.Host = Properties.Settings.Default.Host;
            dbLoginUserControl1.Port = Properties.Settings.Default.Port.ToString();
            dbLoginUserControl1.DbName = Properties.Settings.Default.Database;
        }

        private void dbLoginUserControl1_OpenedConnection(object sender, DbConnectionEventArgs e)
        {
            ConnectionManager = e.ConnectionManager;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
