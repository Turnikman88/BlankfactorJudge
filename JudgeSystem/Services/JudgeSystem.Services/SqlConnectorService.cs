using JudgeSystem.Common.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace JudgeSystem.Executors
{
    public class SqlConnectorService : ISqlConnectorService
    {
        /*private readonly IOptions<TestBaseConnectionSettings> connectionString;

        public SqlConnectorService(IOptions<TestBaseConnectionSettings> connection)
        {
            connectionString = connection;
        }*/

        public bool Execute(string sql)
        {
           /* using (var connection = new SqlConnection(connectionString.Value.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.WriteLine(rdr[i].ToString());
                        }
                        Console.WriteLine("----------------------");
                    }
                }
            }
*/            return false;
        }
    }
}
