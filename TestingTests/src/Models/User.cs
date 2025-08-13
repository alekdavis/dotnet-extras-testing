using Newtonsoft.Json;

namespace TestingLibTests.Models;
public class User
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("mail")]
    public string? Mail { get; set; }

    [JsonProperty("otherMail")]
    public string[]? OtherMail { get; set; }

    [JsonProperty("luckyNumbers")]
    public int[]? LuckyNumbers { get; set; }

    [JsonProperty("name")]
    public Name? Name { get; set; }

    [JsonProperty("passwordExpirationDate")]
    public DateTime? PasswordExpirationDate { get; set; }

    [JsonProperty("socialAccounts")]
    public Dictionary<string, SocialAccount>? SocialAccounts { get; set; }

    [JsonProperty("phones")]
    public List<Phone>? Phones { get; set; }

    [JsonProperty("sponsor")]
    public User? Sponsor { get; set; }

    [JsonProperty("tags")]
    public Dictionary<string, string>? Tags { get; set; }
}
