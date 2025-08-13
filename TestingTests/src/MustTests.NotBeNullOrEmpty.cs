using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotBeNullOrEmpty()
    {
        string nonEmptyString = "abc";
        nonEmptyString.Must().NotBeNullOrEmpty();

        string[] stringArray = ["a", "b", "c"];
        stringArray.Must().NotBeNullOrEmpty();

        int[] intArray = [1, 2, 3];
        intArray.Must().NotBeEmpty();

        List<string>? stringList = ["a", "b", "c"];
        stringList.Must().NotBeNullOrEmpty();

        List<int>? intList = [1, 2, 3];
        intList.Must().NotBeNullOrEmpty();

        HashSet<string>? stringHashSet = ["a", "b", "c"];
        stringHashSet.Must().NotBeNullOrEmpty();

        Dictionary<string, string>? stringDictionary = new() { { "a", "b" } };
        stringDictionary.Must().NotBeNullOrEmpty();

        string? emptyString = "";
        Assert.ThrowsAny<XunitException>(() => emptyString.Must().NotBeNullOrEmpty());

        string? nullString = null;
        Assert.ThrowsAny<XunitException>(() => nullString.Must().NotBeNullOrEmpty());

        string[]? emptyStringArray = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringArray.Must().NotBeNullOrEmpty());

        string[]? nullStringArray = null;
        Assert.ThrowsAny<XunitException>(() => nullStringArray.Must().NotBeNullOrEmpty());

        List<string>? emptyStringList = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringList.Must().NotBeNullOrEmpty());

        List<string>? nullStringList = null;
        Assert.ThrowsAny<XunitException>(() => nullStringList.Must().NotBeNullOrEmpty());

        HashSet<string>? emptyStringHashSet = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringHashSet.Must().NotBeNullOrEmpty());

        HashSet<string>? nullStringHashSet = null;
        Assert.ThrowsAny<XunitException>(() => nullStringHashSet.Must().NotBeNullOrEmpty());

        Dictionary<string, string>? emptyStringDictionary = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringDictionary.Must().NotBeNullOrEmpty());

        Dictionary<string, string>? nullStringDictionary = null;
        Assert.ThrowsAny<XunitException>(() => nullStringDictionary.Must().NotBeNullOrEmpty());
    }
}
