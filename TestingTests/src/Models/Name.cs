using Newtonsoft.Json;

namespace TestingLibTests.Models;

public class Name
{
    [JsonProperty("surname")]
    public string? Surname { get; set; }

    [JsonProperty("givenName")]
    public string? GivenName { get; set; }

    [JsonProperty("middleName")]
    public string? MiddleName { get; set; }
}
