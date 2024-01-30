using Microsoft.AspNetCore.Mvc;
using OpenIAApi.Bussines;
using OpenIAApi.Models.Request.DTO;
using OpenIAApi.Models.Entity;
using Microsoft.Extensions.Options;

namespace OpenIAApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{    
    private readonly MySettings _mySettings;
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<MySettings> mySettingsOptions)
    {
        _logger = logger;
        _mySettings = mySettingsOptions.Value;
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

    // [HttpPost(Name = "GetOpenIAExample")]
    // public async Task<IActionResult> GetOpenIA(MakingAskDto makingAskDto){
    //     CallOpenAPI callOpenAPI = new CallOpenAPI();
    //     AnswerDto res = callOpenAPI.CallAsk(makingAskDto, _mySettings.token_Barer_Open_Api).Result;
    //     if(res.StatusCode==System.Net.HttpStatusCode.OK){
    //         return Ok(res.message);
    //     }else{
    //         return this.StatusCode((int)res.StatusCode, res.error);
    //     }        
    // }

}
