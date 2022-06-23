// See https://aka.ms/new-console-template for more information
using System;
using TestAnalyzers;

namespace TestAnalyzers
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            TestClass c = new TestClass();
            c.DoSomething("hellO");
            string s = null;
            c.DoSomething(s);
            var results = await c.DoQueryAsync("1=1", "connection string...");

            foreach (var result in results)
                Console.WriteLine(result);

            var results2 = await c.DoAnotherQueryAsync("ness", "pk123", "connection string");

            RSPEC3649SQLiNoncompliant r = new RSPEC3649SQLiNoncompliant(new DapperContext(new System.Data.SqlClient.SqlConnection("connection string")));
            r.Authenticate("mY User");
        }
    }
}