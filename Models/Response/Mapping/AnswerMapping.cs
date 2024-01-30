using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OpenIAApi.Models.Entity;

namespace OpenIAApi.Models.Response.mapping;

public class AnswerMapping{    
    public AnswerDto toDTO(Answer answer){
        AnswerDto answerDto = new AnswerDto();
        answerDto.ReasonPhrase = answer.ReasonPhrase;
        answerDto.StatusCode = answer.StatusCode;
        if(answer.StatusCode == System.Net.HttpStatusCode.OK){
            answerDto.message = answer.choices[0].message;
        }else{
            answerDto.error = answer.error;        
        }                
        return answerDto;
    }
}