using System.Text.Json.Serialization;

namespace D2.Domain.Manifest;

public class Localization<T> where T : class
{
    [JsonPropertyName("en")]
    public T? En;
    
    [JsonPropertyName("fr")]
    public T? Fr;
    
    [JsonPropertyName("es")]
    public T? Es;
    
    [JsonPropertyName("es-mx")]
    public T? EsMx;
    
    [JsonPropertyName("de")]
    public T? De;
    
    [JsonPropertyName("it")]
    public T? It;
    
    [JsonPropertyName("ja")]
    public T? Ja;
    
    [JsonPropertyName("pt-br")]
    public T? PtBr;
    
    [JsonPropertyName("ru")]
    public T? Ru;
    
    [JsonPropertyName("pl")]
    public T? Pl;
    
    [JsonPropertyName("ko")]
    public T? Ko;
    
    [JsonPropertyName("zh-cht")]
    public T? ZhCht;
    
    [JsonPropertyName("zh-chs")]
    public T? ZhChs;
    
}