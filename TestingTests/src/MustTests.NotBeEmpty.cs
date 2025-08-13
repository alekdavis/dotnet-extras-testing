using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotBeEmpty()
    {
        string nonEmptyString = "abc";
        nonEmptyString.Must().NotBeEmpty();

        string[] stringArray = ["a", "b", "c"];
        stringArray.Must().NotBeEmpty();

        int[] intArray = [1, 2, 3];
        intArray.Must().NotBeEmpty();

        List<string>? stringList = ["a", "b", "c"];
        stringList.Must().NotBeEmpty();

        List<int>? intList = [1, 2, 3];
        intList.Must().NotBeEmpty();

        HashSet<string>? stringHashSet = ["a", "b", "c"];
        stringHashSet.Must().NotBeEmpty();

        Dictionary<string, string>? stringDictionary = new() { { "a", "b" } };
        stringDictionary.Must().NotBeEmpty();        
        
        string emptyString = "";
        Assert.ThrowsAny<XunitException>(() => emptyString.Must().NotBeEmpty());

        string[] emptyStringArray = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringArray.Must().NotBeEmpty());

        int[] emptyIntArray = [];
        Assert.ThrowsAny<XunitException>(() => emptyIntArray.Must().NotBeEmpty());

        List<string>? emptyStringList = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringList.Must().NotBeEmpty());

        List<int>? emptyIntList = [];
        Assert.ThrowsAny<XunitException>(() => emptyIntList.Must().NotBeEmpty());

        HashSet<string>? emptyStringHashSet = [];
        Assert.ThrowsAny<XunitException>(() => emptyStringHashSet.Must().NotBeEmpty());

        Dictionary<string, string>? emptyStringDictionary = new();
        Assert.ThrowsAny<XunitException>(() => emptyStringDictionary.Must().NotBeEmpty());
    }
}
