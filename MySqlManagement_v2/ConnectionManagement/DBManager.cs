﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.Common;

namespace MySqlManagement_v2.ConnectionManagement
{
    public abstract class DbManager
    {
        protected const string sqlCommentPattern = @"(\-\-)(.*)(\n|\r|\r\n)";
        protected static readonly Regex rgxSqlComment = new Regex(sqlCommentPattern);

        public static List<string> RetrieveQueries(string queriesString)
        {
            if (queriesString != null && queriesString != string.Empty)
            {
                return queriesString.Trim()
                                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(str => rgxSqlComment.Replace(str, "").Trim()).ToList();
            }
            return new List<string>();
        }

        protected static class QueryType
        {
            public const string SelectQuery = "SELECT";
            public const string CreateTableQuery = "CREATE";
            public const string InsertQuery = "INSERT";
            public const string DeleteQuery = "DROP";
            public const string SetQuery = "SET";
        }

        public static DbManager Connect(Type dbType, string host, uint port, string userName, string pwd, string database)
        {
            var methodInfo = dbType.GetMethod("Connect");
            while (methodInfo == null)
            {
                if (dbType.BaseType != null && dbType.BaseType != typeof(object))
                {
                    return Connect(dbType.BaseType, host, port, userName, pwd, database);
                }
                else
                {
                    return null;
                }
            }

            if (methodInfo != null) // Redundant
            {
                return (DbManager)methodInfo.Invoke(null,
                                                    new object[]
                                                    {
                                                        host,
                                                        port,
                                                        userName,
                                                        pwd,
                                                        database
                                                    }); //null - means calling static method
            }

            return null;
        }

        public abstract void OpenConnection();
        public abstract void CloseConnection();

        public IQueryResult ExecureRawQuery(string query)
        {
            if (query != null && query != string.Empty)
            {
                var trimmedQuery = query.Trim();
                var queries = trimmedQuery.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var type = queries[0].ToUpper();

                switch (type)
                {
                    case QueryType.SelectQuery:
                        return ExecuteSelection(query);
                    case QueryType.CreateTableQuery:
                    case QueryType.InsertQuery:
                    case QueryType.DeleteQuery:
                    case QueryType.SetQuery:
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

        protected abstract IQueryResult ExecuteNoRowsRetrievedQuery(string query);
        protected abstract IQueryResult ExecuteSelection(string query);
    }

    public class DbManager<ConnectionType, ConnectionStrBuilderType, CommandType, DataReaderType> : DbManager 
        where ConnectionType : DbConnection
        where ConnectionStrBuilderType : DbConnectionStringBuilder
        where CommandType : DbCommand
        where DataReaderType : DbDataReader
    {
        static DbManager instance;
        public static DbManager Instance
        {
            get
            {
                return instance;
            }
        }

        ConnectionType connection;

        protected DbManager(string connectionString)
        {
            connection = (ConnectionType)Activator.CreateInstance(typeof(ConnectionType));
            connection.ConnectionString = connectionString;
        }

        public static DbManager Connect(string host, uint port, string userName, string pwd, string database)
        {
            var connectionString = CreateConnectionString(host, port, userName, pwd, database);
            if (instance == null)
            {
                instance = new DbManager<ConnectionType, ConnectionStrBuilderType, CommandType, DataReaderType>(connectionString);
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

        protected static string CreateConnectionString(string host, uint port, string userName, string pwd, string database)
        {
            dynamic connectionStringBuilder = (ConnectionStrBuilderType)Activator.CreateInstance(typeof(ConnectionStrBuilderType));
            
            try
            {
                connectionStringBuilder.Server = host;
                connectionStringBuilder.UserID = userName;
                connectionStringBuilder.Password = pwd;
                connectionStringBuilder.Port = port;
                connectionStringBuilder.Database = database;
            }
            catch
            {
                throw new Exception("Connection string doesn't implement proper interface.");
            }

            return connectionStringBuilder.ToString();
        }

        public override void OpenConnection()
        {
            connection.Open();
        }

        public override void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        protected override IQueryResult ExecuteSelection(string query)
        {
            CursorQueryResult<DataReaderType> res;

            try
            {
                var command = (DbCommand)Activator.CreateInstance(typeof(CommandType));
                command.Connection = connection;
                command.CommandText = query;

                var reader = command.ExecuteReader();

                res = new CursorQueryResult<DataReaderType>(QueryResponse.Ok, (DataReaderType)reader);
            }
            catch (Exception ex)
            {
                res = new CursorQueryResult<DataReaderType>(ex.Message);
            }

            return res;
        }

        protected override IQueryResult ExecuteNoRowsRetrievedQuery(string query)
        {
            QueryResult res;

            try
            {
                var command = (DbCommand)Activator.CreateInstance(typeof(CommandType));
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
