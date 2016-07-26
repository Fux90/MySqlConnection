using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySqlManagement_v2.ConnectionManagement
{
    public class MySqlDbManager : DbManager<MySqlConnection, MySqlConnectionStringBuilder, MySqlCommand, MySqlDataReader>
    {
        protected MySqlDbManager(string connectionString)
            : base(connectionString)
        {

        }
    }
}
