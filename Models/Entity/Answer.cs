using System.Net;

namespace OpenIAApi.Models.Entity;
public class Answer{
    public string? id{get;set;}    
    public int created{get;set;}
    public string? model{get;set;}
    public List<Choice>? choices{
        get;set;
    } 
    public Usage? usage{get;set;}
    public string? system_fingerprint{get;set;}
    public string? ReasonPhrase{get;set;}
    public HttpStatusCode StatusCode{get;set;}
    public Error? error{get;set;}
}