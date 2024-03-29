using System.Net.Http.Headers;
using Newtonsoft.Json;
using OpenIAApi.Models.Entity;
using OpenIAApi.Models.Request.DTO;
using OpenIAApi.Models.Response.mapping;

namespace OpenIAApi.Bussines;

public class CallOpenAPI{
    public static MakingAskDto? _makingAskDto{get;set;}    
    public static MySettings? _mySettings{get;set;}

    public static MakingAsk cargaDatos(){        
        MakingAsk makingASk = new MakingAsk();
        makingASk.model = _mySettings.model;
        Message message = new Message();
        message.role = _mySettings.rol;
        message.content = _makingAskDto.content;
        List<Message> messages = new List<Message>();
        messages.Add(message);
        makingASk.messages= messages;
        makingASk.temperature = _mySettings.temperature;
        return makingASk;
    }
    
    public async Task<AnswerDto> CallAsk(MakingAskDto makingAskDto, MySettings mySettings){
        _makingAskDto = makingAskDto;
        _mySettings = mySettings;
        HttpClient httpClient = new HttpClient();
        AnswerMapping answerMapping = new AnswerMapping();
        httpClient.BaseAddress = new Uri(mySettings.baseAddress);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));        
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", mySettings.token_Barer_Open_Api);
        var response = await PostAsJsonAsync(httpClient);
        return answerMapping.toDTO(response);
    }

    static async Task<Answer?> PostAsJsonAsync(HttpClient httpClient){
        Answer? answer = new Answer();
        ResponseError? responseError = new ResponseError();
        using HttpResponseMessage response = await httpClient.PostAsJsonAsync("/v1/chat/completions", cargaDatos());        
        var receiveStream = response.Content.ReadAsStringAsync().Result;        
        if(response.IsSuccessStatusCode){
            answer = JsonConvert.DeserializeObject<Answer>(receiveStream);            
        }else{
            responseError = JsonConvert.DeserializeObject<ResponseError>(receiveStream);
            answer.error = responseError.error;                              
        }
        answer.StatusCode = response.StatusCode;
        answer.ReasonPhrase = response.ReasonPhrase;
        return answer;
    }
}



