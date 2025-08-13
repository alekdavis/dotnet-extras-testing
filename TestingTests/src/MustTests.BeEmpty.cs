using DotNetExtras.Testing.Assertions;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeEmpty()
    {
        string emptyString = "";
        emptyString.Must().BeEmpty();

        string[] stringArray = [];
        stringArray.Must().BeEmpty();

        int[] intArray = [];
        intArray.Must().BeEmpty();

        List<string>? stringList = [];
        stringList.Must().BeEmpty();

        List<int>? intList = [];
        intList.Must().BeEmpty();

        HashSet<string>? stringHashSet = [];
        stringHashSet.Must().BeEmpty();

        Dictionary<string, string>? stringDictionary = [];
        stringDictionary.Must().BeEmpty();

        string nonEmptyString = "not empty";
        Assert.ThrowsAny<Exception>(() => nonEmptyString.Must().BeEmpty());

        string[] nonEmptyStringArray = ["not empty"];
        Assert.ThrowsAny<Exception>(() => nonEmptyStringArray.Must().BeEmpty());

        int[] nonEmptyIntArray = [1];
        Assert.ThrowsAny<Exception>(() => nonEmptyIntArray.Must().BeEmpty());

        List<string>? nonEmptyStringList = ["not empty"];
        Assert.ThrowsAny<Exception>(() => nonEmptyStringList.Must().BeEmpty());

        List<int>? nonEmptyIntList = [1];
        Assert.ThrowsAny<Exception>(() => nonEmptyIntList.Must().BeEmpty());

        HashSet<string>? nonEmptyStringHashSet = ["not empty"];
        Assert.ThrowsAny<Exception>(() => nonEmptyStringHashSet.Must().BeEmpty());

        Dictionary<string, string>? nonEmptyStringDictionary = new()
        { { "key", "value" } };
        Assert.ThrowsAny<Exception>(() => nonEmptyStringDictionary.Must().BeEmpty());
    }
}
