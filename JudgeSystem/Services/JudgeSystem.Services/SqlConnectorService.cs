using JudgeSystem.Common.Settings;
using JudgeSystem.Workers.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace JudgeSystem.Executors
{
    public class SqlConnectorService : ISqlConnectorService
    {
        private readonly IOptions<TestBaseConnectionSettings> connectionString;

        public SqlConnectorService(IOptions<TestBaseConnectionSettings> connection)
        {
            connectionString = connection;
        }

        public SqlWorkerResult Check(string sql)
        {
            SqlWorkerResult result;
            var sbEx = new StringBuilder();

            using (var connection = new SqlConnection(connectionString.Value.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                try
                {
                    SqlDataReader rdr = command.ExecuteReader();                    
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        sbEx.AppendLine(ex.InnerException.Message.ToString());
                    }
                    else
                    {
                        sbEx.AppendLine(ex.Message);
                    }
                }

                result = new SqlWorkerResult(sbEx.ToString());

            }
            return result;
        }

        public SqlExecutionResult Execute(List<string> args)
        {
            string sql = args[0];

            var result = new SqlExecutionResult();
            var sbOut = new StringBuilder();
            var sbEx = new StringBuilder();
            using (var connection = new SqlConnection(connectionString.Value.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                try
                {
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            sbOut.AppendLine(rdr[i].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        sbEx.AppendLine(ex.InnerException.Message.ToString());
                    }
                    else
                    {
                        sbEx.AppendLine(ex.Message);
                    }
                    result.Error = sbEx.ToString();
                }
                result.Output = sbOut.ToString();
            }
            return result;
        }

        public SqlExecutionResult ExecuteView(List<string> args)
        {
            string sql = args[0];
            string viewName = args[1];
            string viewCommand = $"select * from {viewName}";

            var result = new SqlExecutionResult();
            var sbOut = new StringBuilder();
            var sbView = new StringBuilder();
            var sbEx = new StringBuilder();

            using (var connection = new SqlConnection(connectionString.Value.ConnectionString))
            {
                connection.Open();

                var viewSql = new SqlCommand(viewCommand, connection);
                ExecuteQuery(sbView, viewSql);

                var userSql = new SqlCommand(sql, connection);
                try
                {
                    ExecuteQuery(sbOut, userSql);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        sbEx.AppendLine(ex.InnerException.Message.ToString());
                    }
                    else
                    {
                        sbEx.AppendLine(ex.Message);
                    }
                    result.Error = sbEx.ToString();
                }
                result.Output = (sbOut.ToString() == sbView.ToString()).ToString();
            }
            return result;
        }

        private static void ExecuteQuery(StringBuilder sb, SqlCommand sql)
        {
            using (SqlDataReader rdr = sql.ExecuteReader())
            {
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        sb.AppendLine(rdr[i].ToString());
                    }
                }
            }
        }
    }
}
