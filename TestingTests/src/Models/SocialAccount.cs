using Newtonsoft.Json;

namespace TestingLibTests.Models;
public class SocialAccount
{
    [JsonProperty("provider")]
    public string? Provider { get; set; }

    [JsonProperty("account")]
    public string? Account { get; set; }

    [JsonProperty("enabled")]   
    public bool? Enabled { get; set; }
}
