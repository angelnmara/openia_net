using Microsoft.AspNetCore.Mvc;
using OpenIAApi.Bussines;
using OpenIAApi.Models.Request.DTO;
using OpenIAApi.Models.Entity;
using Microsoft.Extensions.Options;

namespace OpenIAApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAPIController : ControllerBase
{
    private readonly MySettings _mySettings;
    private readonly ILogger<OpenAPIController> _logger;

    public OpenAPIController(ILogger<OpenAPIController> logger, IOptions<MySettings> mySettingsOptions)
    {
        _logger = logger;
        _mySettings = mySettingsOptions.Value;
    }

    [HttpPost(Name = "GetOpenIAExample")]
    public async Task<IActionResult> GetOpenIA(MakingAskDto makingAskDto){
        CallOpenAPI callOpenAPI = new CallOpenAPI();
        AnswerDto res = callOpenAPI.CallAsk(makingAskDto, _mySettings).Result;
        if(res.StatusCode==System.Net.HttpStatusCode.OK){
            return Ok(res.message);
        }else{
            return this.StatusCode((int)res.StatusCode, res.error);
        }        
    }
}