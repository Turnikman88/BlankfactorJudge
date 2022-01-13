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
                        sbOut.AppendLine("-----");
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

        public SqlExecutionResult ExecuteView(List<string> args) => throw new NotImplementedException();
    }
}
