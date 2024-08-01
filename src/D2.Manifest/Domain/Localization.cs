using System.Text.Json.Serialization;

namespace D2.Manifest.Domain;

public class Localization<T> where T : class
{
    [JsonPropertyName("en")]
    public T? En { get; set; }
    [JsonPropertyName("fr")]
    public T? Fr { get; set; }
    [JsonPropertyName("es")]
    public T? Es { get; set; }
    [JsonPropertyName("es-mx")]
    public T? EsMx { get; set; }
    [JsonPropertyName("de")]
    public T? De { get; set; }
    [JsonPropertyName("it")]
    public T? It { get; set; }
    [JsonPropertyName("ja")]
    public T? Ja { get; set; }
    [JsonPropertyName("pt-br")]
    public T? PtBr { get; set; }
    [JsonPropertyName("ru")]
    public T? Ru { get; set; }
    [JsonPropertyName("pl")]
    public T? Pl { get; set; }
    [JsonPropertyName("ko")]
    public T? Ko { get; set; }
    [JsonPropertyName("zh-cht")]
    public T? ZhCht { get; set; }
    [JsonPropertyName("zh-chs")]
    public T? ZhChs { get; set; }

}