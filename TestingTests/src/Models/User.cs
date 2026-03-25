namespace TestingLibTests.Models;
public class User
{
    public string? Id { get; set; }

    public string? Mail { get; set; }

    public string[]? OtherMail { get; set; }

    public int[]? LuckyNumbers { get; set; }

    public Name? Name { get; set; }

    public DateTime? PasswordExpirationDate { get; set; }

    public Dictionary<string, SocialAccount>? SocialAccounts { get; set; }

    public List<Phone>? Phones { get; set; }

    public User? Sponsor { get; set; }

    public Dictionary<string, string>? Tags { get; set; }
}
