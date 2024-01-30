using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OpenIAApi.Models.Entity;

namespace OpenIAApi.Models.Response.mapping;

public class AnswerMapping{    
    public AnswerDto toDTO(Answer answer){
        AnswerDto answerDto = new AnswerDto();
        answerDto.message = answer.choices[0].message;
        return answerDto;
    }
}