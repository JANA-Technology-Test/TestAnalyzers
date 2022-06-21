// See https://aka.ms/new-console-template for more information
using TestAnalyzers;

Console.WriteLine("Hello, World!");

TestClass c = new TestClass();
c.DoSomething("hellO");
string s = null;
c.DoSomething(s);
var results = await c.DoQuery("1=1", "connection string...");

foreach (var result in results)
    Console.WriteLine(result);

RSPEC3649SQLiNoncompliant r = new RSPEC3649SQLiNoncompliant(new DapperContext(new System.Data.SqlClient.SqlConnection("connection string")));
r.Authenticate("mY User");