using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TestAnalyzers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly string _connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetUserInfo")]
        public string Get(string username)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM USERS WHERE USERNAME = '{username}'";
            var results = command.ExecuteReader();
            return "ok";
        }

        [HttpGet(Name = "Test")]
        public string Get2(string file)
        {
            Response.Headers.Add("Set-Cookie", file);  // Noncompliant
            Response.Cookies.Append("ASP.NET_SessionId", file);

            using RSPEC2930Noncompliant noncompliant = new RSPEC2930Noncompliant();
            noncompliant.OpenResource(file);
            return "Ok";
        }
    }
}