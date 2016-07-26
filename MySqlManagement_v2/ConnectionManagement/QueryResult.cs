using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace MySqlManagement_v2.ConnectionManagement
{
    public enum QueryResponse
    {
        Ok,
        Error
    }

    public abstract class IQueryResult
    {
        public QueryResponse Response { get; private set; }
        public string ErrorMessage { get; private set; }

        public IQueryResult(QueryResponse response, string errorMessage)
        {
            Response = response;
            ErrorMessage = errorMessage;
        }

        public IQueryResult(QueryResponse response)
            : this(response, "")
        {
        }

        public IQueryResult(string errorMessage)
            : this(QueryResponse.Error, errorMessage)
        {
        }

        protected delegate string ContentAsStringDelegate();
        protected ContentAsStringDelegate ParseContent;

        public string ContentAsString()
        {
            return ParseContent == null ? "" : ParseContent();
        }

        public override string ToString()
        {
            var strB = new StringBuilder();
            strB.AppendFormat("[{0}]", Response);
            strB.AppendLine();

            if (Response == QueryResponse.Error)
            {
                strB.AppendLine(ErrorMessage);
            }

            return strB.ToString();
        }
    }

    public class QueryResult : IQueryResult
    {
        public int AffectedRows { get; private set; }

        public QueryResult(QueryResponse response, int affectedRow, string errorMessage)
            : base(response, errorMessage)
        {
            AffectedRows = affectedRow;
        }

        public QueryResult(QueryResponse response)
            : this(response, 0, "")
        {
        }

        public QueryResult(QueryResponse response, int affectedRows)
            : this(response, affectedRows, "")
        {
        }

        public QueryResult(QueryResponse response, string errorMessage)
            : this(response, 0, errorMessage)
        {
        }

        public QueryResult(string errorMessage)
            : this(QueryResponse.Error, 0, errorMessage)
        {
        }

        public override string ToString()
        {
            var strB = new StringBuilder(base.ToString());

            if(Response != QueryResponse.Error)
            {
                strB.AppendFormat("Affected Rows: {0}", AffectedRows);
                strB.AppendLine();
            }

            return strB.ToString();
        }
    }

    public abstract class QueryResult<T> : IQueryResult
    {
        public QueryResult(QueryResponse response, int affectedRow, T result):
            base(response, "")
        {
            Result = result;
        }

        public QueryResult(QueryResponse response, string errorMessage)
            : base(response, errorMessage)
        {
        }

        public QueryResult(string errorMessage)
            : base(errorMessage)
        {
        }

        public T Result { get; protected set; }
    }

    public class CursorQueryResult<DbDataRaderType> : QueryResult<DbDataRaderType>
        where DbDataRaderType : DbDataReader
    {
        public class ColumnInfo
        {
            public Type ColumnType { get; set; }
            public string ColumnName { get; set; }

            public ColumnInfo()
            {

            }

            public ColumnInfo(Type columnType, string columnName)
            {
                ColumnType = columnType;
                ColumnName = columnName;
            }
        }

        DataTable dt;
        public DataTable Dt
        {
            get
            {
                if (Result == null)
                {
                    return new DataTable();
                }
                if (dt == null)
                {
                    //for
                    dt = new DataTable();
                    dt.Load(Result);
                }
                return dt;
            }
        }

        ColumnInfo[] schema;
        public ColumnInfo[] Schema
        {
            get
            {
                if (schema == null)
                {
                    schema = new ColumnInfo[Dt.Columns.Count];
                    for (int i = 0; i < schema.Length; i++)
			        {
                        var currCol = Dt.Columns[i];
                        schema[i] = new ColumnInfo()
                        {
                            ColumnName = currCol.ColumnName,
                            ColumnType = currCol.DataType
                        };
			        }
                }
                return schema;
            }
        }

        public CursorQueryResult(QueryResponse response, DbDataRaderType result)
            : base(response, 0, result)
        {
            ParseContent = GetContentAsString;
        }

        public CursorQueryResult(QueryResponse response, string errorMessage)
            : base(response, errorMessage)
        {

        }

        public CursorQueryResult(string errorMessage)
            : base(errorMessage)
        {

        }

        private string GetContentAsString()
        {
            var res = new StringBuilder();

            var dt = Dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                res.AppendLine(row["D"].ToString());
            }

            return res.ToString();
        }

        public override string ToString()
        {
            var strB = new StringBuilder(base.ToString());

            if (Response != QueryResponse.Error)
            {
                strB.AppendFormat("# Fields: {0}", Result.FieldCount);
                strB.AppendLine();

                var numRows = Dt.Rows.Count;

                var s = Schema;
                var l = s.Length + 0;

                if (numRows == 0)
                {
                    strB.AppendLine("No rows detected");
                }
                else
                {
                    strB.AppendFormat("# Rows: {0}", numRows);
                    strB.AppendLine();
                }
            }

            return strB.ToString();
        }
    }
}
