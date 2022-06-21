// See https://aka.ms/new-console-template for more information
using TestAnalyzers;

Console.WriteLine("Hello, World!");

TestClass c = new TestClass();
c.DoSomething("hellO");
string s = null;
c.DoSomething(s);
var result = await c.DoQuery("1=1", "connection string...");

foreach (var r in result)
    Console.WriteLine(r);

RSPEC3649SQLiNoncompliant r = new RSPEC3649SQLiNoncompliant(new DapperContext(new System.Data.SqlClient.SqlConnection("connection string")));
r.Authenticate("mY User");