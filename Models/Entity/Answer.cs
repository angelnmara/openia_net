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
}