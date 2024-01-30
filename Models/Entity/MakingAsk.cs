namespace OpenIAApi.Models.Entity;

public class MakingAsk{
    public string? model{get;set;}
    public List<Message>? messages{get;set;}
    public double temperature{get;set;}
}