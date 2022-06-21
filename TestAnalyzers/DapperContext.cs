using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnalyzers
{
    public class DapperContext
    {
        private readonly SqlConnection _connection;

        public DapperContext(SqlConnection connection)
        {
            _connection = connection;
        }

        public SqlConnection Database => _connection;
    }
}
