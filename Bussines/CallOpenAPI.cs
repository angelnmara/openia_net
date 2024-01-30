using System.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using OpenIAApi.Models.Entity;
using OpenIAApi.Models.Request.DTO;
using OpenIAApi.Models.Response.mapping;


namespace OpenIAApi.Bussines;

public class CallOpenAPI{

    public static MakingAskDto? _makingAskDto{get;set;}

    public static MakingAsk cargaDatos(){
        MakingAsk makingASk = new MakingAsk();
        makingASk.model = "gpt-3.5-turbo";
        Message message = new Message();
        message.role = "user";
        message.content = _makingAskDto.content;
        List<Message> messages = new List<Message>();
        messages.Add(message);
        makingASk.messages= messages;
        makingASk.temperature = 0.7;
        return makingASk;
    }
    
    public async Task<AnswerDto> CallAsk(MakingAskDto makingAskDto){
        _makingAskDto = makingAskDto;
        HttpClient httpClient = new HttpClient();
        AnswerMapping answerMapping = new AnswerMapping();
        httpClient.BaseAddress = new Uri("https://api.openai.com");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "sk-xxxxxxx");
        var response = await PostAsJsonAsync(httpClient);        
        return answerMapping.toDTO(response);
    }

    static async Task<Answer?> PostAsJsonAsync(HttpClient httpClient){        
        using HttpResponseMessage response = await httpClient.PostAsJsonAsync("/v1/chat/completions", cargaDatos());        
        var receiveStream = response.Content.ReadAsStringAsync().Result;
        Answer? answer = JsonConvert.DeserializeObject<Answer>(receiveStream);                      
        return answer;
    }
}



