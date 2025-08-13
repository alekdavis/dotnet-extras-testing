using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestingLibTests.Models;
public class Phone
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public PhoneType? Type { get; set; }

    [JsonProperty("isMobile")]
    public bool? IsMobile { get; set; }

    [JsonProperty("number")]
    public string? Number { get; set; }

    [JsonProperty("isPrimary")]
    public bool? IsPrimary { get; set; }
}
