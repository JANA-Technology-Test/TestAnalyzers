using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnalyzers
{
    public class TestClass
    {
        private int _value;

        public TestClass()
        {
            _value = new Random().Next();
        }

        public int DoSomething(string value)
        {
            return _value + value.Length;
        }

        public async Task<IEnumerable<string>> DoQueryAsync(string whereClause, string connectionString)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            var result = await connection.QueryAsync<string>($"SELECT Value FROM Table " + whereClause);
            return result;
        }

        public async Task<IEnumerable<string>> DoAnotherQueryAsync(string username, string password, string connectionString)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            var result = await connection.QueryAsync<string>($"SELECT FirstName FROM Users WHERE UserName='{username}' AND PASSWORD='{password}'");
            return result;
        }
    }
}
