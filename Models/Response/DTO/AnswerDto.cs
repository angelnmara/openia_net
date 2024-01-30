namespace OpenIAApi.Models.Entity;
using System.Net;
public class AnswerDto{
    public Message? message;
    public string? ReasonPhrase{get;set;}
    public HttpStatusCode StatusCode{get;set;}
    public Error? error{get;set;}
}