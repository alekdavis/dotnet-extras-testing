using DotNetExtras.Testing.Assertions;
using System.Globalization;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_Equal()
    {
        string stringValue = "abc";

        stringValue.Must().Equal("abc", false);
        stringValue.Must().Equal("ABC", true);
        Assert.ThrowsAny<Exception>(() => stringValue.Must().Equal("xyz", false));
        Assert.ThrowsAny<Exception>(() => stringValue.Must().Equal("xyz", true));
        Assert.ThrowsAny<Exception>(() => stringValue.Must().Equal("ABC", false));
        Assert.ThrowsAny<Exception>(() => stringValue.Must().Equal("Abc", false));

        int intValue = 123;
        intValue.Must().Equal<int>(123);
        Assert.ThrowsAny<Exception>(() => intValue.Must().Equal<int>(456));

        short shortValue = 123;
        shortValue.Must().Equal<short>(123);
        Assert.ThrowsAny<Exception>(() => shortValue.Must().Equal<short>(456));

        long longValue = 123;
        longValue.Must().Equal<long>(123);
        Assert.ThrowsAny<Exception>(() => longValue.Must().Equal<long>(456));

        bool boolValue = true;
        boolValue.Must().Equal<bool>(true);
        Assert.ThrowsAny<Exception>(() => boolValue.Must().Equal<bool>(false));

        boolValue = false;
        boolValue.Must().Equal<bool>(false);
        Assert.ThrowsAny<Exception>(() => boolValue.Must().Equal<bool>(true));

        float floatValue = 123.45f;
        floatValue.Must().Equal<float>((float)123.45);
        Assert.ThrowsAny<Exception>(() => floatValue.Must().Equal<float>((float)456.78));

        double doubleValue = 123.45;
        doubleValue.Must().Equal<double>((double)123.45);
        Assert.ThrowsAny<Exception>(() => doubleValue.Must().Equal<double>((double)456.78));

        string ts = "2025-01-02T03:04:05.678Z";

        DateTime dateTimeValue = DateTime.Parse(ts, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        dateTimeValue.Must().Equal<DateTime>(DateTime.Parse(ts, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind));
        Assert.ThrowsAny<Exception>(() => dateTimeValue.Must().Equal<DateTime>(DateTime.Parse("2025-01-01T03:04:05.678Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind)));

        ts = "2025-01-02T03:04:05.678-03:00";
        DateTimeOffset dateTimeOffsetValue = DateTimeOffset.Parse(ts, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        dateTimeOffsetValue.Must().Equal<DateTimeOffset>(DateTimeOffset.Parse(ts, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind));
        Assert.ThrowsAny<Exception>(() => dateTimeOffsetValue.Must().Equal<DateTimeOffset>(DateTimeOffset.Parse("2025-01-01T03:04:05.678-03:00", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind)));

        string[] stringArray = ["abc", "def", "ghi"];
        stringArray.Must().Equal(["abc", "def", "ghi"], false);
        stringArray.Must().Equal(["ABC", "Def", "ghi"], true);
        Assert.ThrowsAny<Exception>(() => stringArray.Must().Equal(["xyz", "def", "ghi"], false));

        string[]? stringNullArray1 = null;
        string[]? stringNullArray2 = null;
        stringNullArray1.Must().Equal(stringNullArray2);

        string[]? stringNullArray3 = [];
        string[]? stringNullArray4 = [];
        stringNullArray3.Must().Equal(stringNullArray4);

        List<string> stringList = ["abc", "def", "ghi"];
        stringList.Must().Equal(["abc", "def", "ghi"], false);
        stringList.Must().Equal(["ABC", "Def", "ghi"], true);
        Assert.ThrowsAny<Exception>(() => stringList.Must().Equal(["xyz", "def", "ghi"], false));

        List<string>? stringNullList1 = null;
        List<string>? stringNullList2 = null;
        stringNullList1.Must().Equal(stringNullList2);

        List<string>? stringNullList3 = [];
        List<string>? stringNullList4 = [];
        stringNullList3.Must().Equal(stringNullList4);

        HashSet<string> stringHashSet = ["abc", "def", "ghi"];
        stringHashSet.Must().Equal(["abc", "def", "ghi"], false);
        stringHashSet.Must().Equal(["ABC", "Def", "ghi"], true);
        Assert.ThrowsAny<Exception>(() => stringHashSet.Must().Equal(["xyz", "def", "ghi"], false));

        HashSet<string>? stringNullHashSet1 = null;
        HashSet<string>? stringNullHashSet2 = null;
        stringNullHashSet1.Must().Equal(stringNullHashSet2);

        HashSet<string>? stringNullHashSet3 = [];
        HashSet<string>? stringNullHashSet4 = [];
        stringNullHashSet3.Must().Equal(stringNullHashSet4);

        Dictionary<string, string> stringDictionary1 = new()
        {
            ["abc"] = "def",
            ["ghi"] = "jkl",
            ["mno"] = "pqr"
        };

        Dictionary<string, string> stringDictionary2 = new()
        {
            ["abc"] = "def",
            ["ghi"] = "jkl",
            ["mno"] = "pqr"
        };

        stringDictionary1.Must().Equal(stringDictionary2);

        Assert.ThrowsAny<Exception>(() => stringDictionary1.Must().Equal(new Dictionary<string, string> { ["abc"] = "xyz", ["ghi"] = "jkl", ["mno"] = "pqr" }));

    }
}
