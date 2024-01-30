using Microsoft.AspNetCore.Mvc;
using OpenIAApi.Bussines;
using OpenIAApi.Models.Request.DTO;
using OpenIAApi.Models.Entity;

namespace OpenIAApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
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
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost(Name = "GetOpenIAExample")]
    public async Task<IActionResult> GetOpenIA(MakingAskDto makingAskDto){
        CallOpenAPI callOpenAPI = new CallOpenAPI();        
        AnswerDto res = callOpenAPI.CallAsk(makingAskDto).Result;
        return Ok(res.message);
    }

}
