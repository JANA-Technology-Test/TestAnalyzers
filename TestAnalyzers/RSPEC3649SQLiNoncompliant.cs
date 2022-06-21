using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnalyzers
{
    public class RSPEC3649SQLiNoncompliant 
    {
        private readonly DapperContext _context;

        public RSPEC3649SQLiNoncompliant(DapperContext context)
        {
            _context = context;
        }

        public string Authenticate(string user)
        {
            string query = "SELECT * FROM Users WHERE Username = '" + user + "'";

            // an attacker can bypass authentication by setting user to this special value
            // user = "' or 1=1 or ''='";

            var userExists = false;
            SqlCommand command = _context.Database.CreateCommand();
            command.CommandText = query;
            if (command.ExecuteNonQuery() > 0) // Noncompliant
            {
                userExists = true;
            }

            return (userExists ? "success" : "fail");
        }
    }
}
