using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotBeOfType()
    {
        string stringValue = "abc";
        stringValue.Must().NotBeOfType<bool>();
        stringValue.Must().NotBeOfType<int>();
        stringValue.Must().NotBeOfType<string[]>();

        bool boolValue = true;
        boolValue.Must().NotBeOfType<string>();
        boolValue.Must().NotBeOfType<int>();
        boolValue.Must().NotBeOfType<bool[]>();

        int intValue = 1;
        intValue.Must().NotBeOfType<string>();
        intValue.Must().NotBeOfType<bool>();
        intValue.Must().NotBeOfType<int[]>();

        short shortValue = 1;
        shortValue.Must().NotBeOfType<string>();
        shortValue.Must().NotBeOfType<bool>();
        shortValue.Must().NotBeOfType<int>();
        shortValue.Must().NotBeOfType<short[]>();

        long longValue = 1;
        longValue.Must().NotBeOfType<string>();
        longValue.Must().NotBeOfType<bool>();
        longValue.Must().NotBeOfType<int>();
        longValue.Must().NotBeOfType<long[]>();

        DateTime dateTimeValue = DateTime.Now;
        dateTimeValue.Must().NotBeOfType<string>();
        dateTimeValue.Must().NotBeOfType<int>();
        dateTimeValue.Must().NotBeOfType<DateTimeOffset>();

        DateTimeOffset dateTimeOffsetValue = DateTimeOffset.Now;
        dateTimeOffsetValue.Must().NotBeOfType<string>();
        dateTimeOffsetValue.Must().NotBeOfType<int>();
        dateTimeOffsetValue.Must().NotBeOfType<DateTime>();

        string[] stringArray = ["a", "b", "c"];
        stringArray.Must().NotBeOfType<string>();
        stringArray.Must().NotBeOfType<List<string>>();
        stringArray.Must().NotBeOfType<int[]>();

        int[] intArray = [1, 2, 3];
        intArray.Must().NotBeOfType<int>();
        intArray.Must().NotBeOfType<List<int>>();
        intArray.Must().NotBeOfType<string[]>();

        List<string> stringList = ["a", "b", "c"];
        stringList.Must().NotBeOfType<string>();
        stringList.Must().NotBeOfType<string[]>();
        stringList.Must().NotBeOfType<List<int>>();

        List<int> intList = [1, 2, 3];
        intList.Must().NotBeOfType<int>();
        intList.Must().NotBeOfType<int[]>();
        intList.Must().NotBeOfType<List<string>>();

        Dictionary<string, string> stringDictionary = new() { { "a", "b" } };
        stringDictionary.Must().NotBeOfType<string>();
        stringDictionary.Must().NotBeOfType<Dictionary<int, string>>();
        stringDictionary.Must().NotBeOfType<Dictionary<string, int>>();
        stringDictionary.Must().NotBeOfType<string[]>();

        Assert.ThrowsAny<XunitException>(() => "abc".Must().NotBeOfType<string>());
        Assert.ThrowsAny<XunitException>(() => true.Must().NotBeOfType<bool>());
        Assert.ThrowsAny<XunitException>(() => 1.Must().NotBeOfType<int>());
        Assert.ThrowsAny<XunitException>(() => ((short)1).Must().NotBeOfType<short>());
        Assert.ThrowsAny<XunitException>(() => 1L.Must().NotBeOfType<long>());
        Assert.ThrowsAny<XunitException>(() => DateTime.Now.Must().NotBeOfType<DateTime>());
        Assert.ThrowsAny<XunitException>(() => DateTimeOffset.Now.Must().NotBeOfType<DateTimeOffset>());
        Assert.ThrowsAny<XunitException>(() => new string[] { "a", "b", "c" }.Must().NotBeOfType<string[]>());
        Assert.ThrowsAny<XunitException>(() => new int[] { 1, 2, 3 }.Must().NotBeOfType<int[]>());
        Assert.ThrowsAny<XunitException>(() => new List<string> { "a", "b", "c" }.Must().NotBeOfType<List<string>>());
        Assert.ThrowsAny<XunitException>(() => new List<int> { 1, 2, 3 }.Must().NotBeOfType<List<int>>());
        Assert.ThrowsAny<XunitException>(() => new Dictionary<string, string> { { "a", "b" } }.Must().NotBeOfType<Dictionary<string, string>>());
    }
}
