using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeOfType()
    {
        string stringValue = "abc";
        stringValue.Must().BeOfType<string>();
        Assert.Throws<IsTypeException>(() => stringValue.Must().BeOfType<int>());
        Assert.Throws<IsTypeException>(() => stringValue.Must().BeOfType<bool>());

        bool boolValue = true;
        boolValue.Must().BeOfType<bool>();
        Assert.Throws<IsTypeException>(() => boolValue.Must().BeOfType<string>());

        int intValue = 1;
        intValue.Must().BeOfType<int>();
        Assert.Throws<IsTypeException>(() => intValue.Must().BeOfType<bool>());
        Assert.Throws<IsTypeException>(() => intValue.Must().BeOfType<long>());

        short shortValue = 1;
        shortValue.Must().BeOfType<short>();
        Assert.Throws<IsTypeException>(() => shortValue.Must().BeOfType<int>());
        Assert.Throws<IsTypeException>(() => shortValue.Must().BeOfType<long>());

        long longValue = 1;
        longValue.Must().BeOfType<long>();
        Assert.Throws<IsTypeException>(() => longValue.Must().BeOfType<int>());
        Assert.Throws<IsTypeException>(() => longValue.Must().BeOfType<short>());

        DateTime dateTimeValue = DateTime.Now;
        dateTimeValue.Must().BeOfType<DateTime>();
        Assert.Throws<IsTypeException>(() => dateTimeValue.Must().BeOfType<DateTimeOffset>());

        DateTimeOffset dateTimeOffsetValue = DateTimeOffset.Now;
        dateTimeOffsetValue.Must().BeOfType<DateTimeOffset>();
        Assert.Throws<IsTypeException>(() => dateTimeOffsetValue.Must().BeOfType<DateTime>());

        string[] stringArray = ["a", "b", "c"];
        stringArray.Must().BeOfType<string[]>();
        stringArray.Must().BeOfType<IEnumerable<string>>();
        Assert.Throws<IsTypeException>(() => stringArray.Must().BeOfType<int[]>());
        Assert.Throws<IsTypeException>(() => stringArray.Must().BeOfType<List<string>>());

        int[] intArray = [1, 2, 3];
        intArray.Must().BeOfType<int[]>();
        Assert.Throws<IsTypeException>(() => shortValue.Must().BeOfType<long>());
        Assert.Throws<IsTypeException>(() => intArray.Must().BeOfType<string[]>());

        List<string> stringList = ["a", "b", "c"];
        stringList.Must().BeOfType<List<string>>();
        stringList.Must().BeOfType<IEnumerable<string>>();
        Assert.Throws<IsTypeException>(() => stringList.Must().BeOfType<int[]>());
        Assert.Throws<IsTypeException>(() => stringList.Must().BeOfType<string[]>());

        List<int> intList = [1, 2, 3];
        intList.Must().BeOfType<List<int>>();
        intList.Must().BeOfType<IEnumerable<int>>();
        Assert.Throws<IsTypeException>(() => intList.Must().BeOfType<string[]>());
        Assert.Throws<IsTypeException>(() => intList.Must().BeOfType<List<string>>());

        Dictionary<string, string> stringDictionary = new() { { "a", "b" } };
        stringDictionary.Must().BeOfType<Dictionary<string, string>>();
        stringDictionary.Must().BeOfType<IDictionary<string, string>>();
        stringDictionary.Must().BeOfType<IEnumerable<KeyValuePair<string, string>>>();
        Assert.Throws<IsTypeException>(() => stringDictionary.Must().BeOfType<List<string>>());
        Assert.Throws<IsTypeException>(() => stringDictionary.Must().BeOfType<List<KeyValuePair<string, string>>>());
    }
}
