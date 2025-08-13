using System.Runtime.Serialization;

namespace TestingLibTests.Models;
public enum PhoneType: int
{
    [EnumMember(Value = "personal")]
    Personal = 0,
    [EnumMember(Value = "business")]
    Business = 1,
    [EnumMember(Value = "other")]
    Other = 2
}
