using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MySqlManagement_v2.ConnectionManagement
{
    public class ConnectionManager
    {
        private static class QueryType
        {
            public const string SelectQuery = "SELECT";
            public const string CreateTableQuery = "CREATE";
            public const string InsertQuery = "INSERT";
            public const string DeleteQuery = "DELETE";
        }

        static ConnectionManager instance;
        public static ConnectionManager Instance
        {
            get
            {
                return instance;
            }
        }

        MySqlConnection connection;

        private ConnectionManager(string connectionString)
        {
            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
        }

        public static ConnectionManager Connect(string host, uint port, string userName, string pwd, string database)
        {
            var connectionString = CreateConnectionString(host, port, userName, pwd, database);
            if (instance == null)
            {
                instance = new ConnectionManager(connectionString);
            }

            try
            {
                instance.OpenConnection();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                instance = null;
            }

            return instance;
        }

        private static string CreateConnectionString(string host, uint port, string userName, string pwd, string database)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder();

            connectionStringBuilder.Server = host;
            connectionStringBuilder.UserID = userName;
            connectionStringBuilder.Password = pwd;
            connectionStringBuilder.Port = port;
            connectionStringBuilder.Database = database;

            return connectionStringBuilder.ToString();
        }

        private void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public IQueryResult ExecureRawQuery(string query)
        {
            if (query != null && query != string.Empty)
            {
                var trimmedQuery = query.Trim();
                var type = trimmedQuery.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0].ToUpper();
                switch (type)
                {
                    case QueryType.SelectQuery:
                        return ExecuteSelection(query);
                    case QueryType.CreateTableQuery:
                    case QueryType.InsertQuery:
                    case QueryType.DeleteQuery: 
                        return ExecuteNoRowsRetrievedQuery(query);
                    default:
                        throw new Exception("");
                }
            }
            else
            {
                return new QueryResult(QueryResponse.Error);
            }
        }

        private CursorQueryResult ExecuteSelection(string query)
        {
            CursorQueryResult res;

            try
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                var reader = command.ExecuteReader();

                res = new CursorQueryResult(QueryResponse.Ok, reader);
            }
            catch (Exception ex)
            {
                res = new CursorQueryResult(ex.Message);
            }

            return res;
        }

        private QueryResult ExecuteNoRowsRetrievedQuery(string query)
        {
            QueryResult res;

            try
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                var affectedRows = command.ExecuteNonQuery();

                res = new QueryResult(QueryResponse.Ok, affectedRows);
            }
            catch (Exception ex)
            {
                res = new QueryResult(QueryResponse.Error, ex.Message);
            }

            return res;
        }
    }
}
