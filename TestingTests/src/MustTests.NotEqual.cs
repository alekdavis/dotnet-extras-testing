using DotNetExtras.Testing.Assertions;
using System.Globalization;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotEqual()
    {
        string stringValue = "abc";
        string? nullStringValue = null;

        stringValue.Must().NotEqual("def", false);
        stringValue.Must().NotEqual("ABC", false);
        stringValue.Must().NotEqual(nullStringValue, false);
        nullStringValue.Must().NotEqual(stringValue, false);
        Assert.ThrowsAny<XunitException>(() => stringValue.Must().NotEqual("abc", false));        
        Assert.ThrowsAny<XunitException>(() => stringValue.Must().NotEqual("ABC", true));        

        int intValue = 123;
        intValue.Must().NotEqual<int>(124);
        intValue.Must().NotEqual<int?>(null);
        Assert.ThrowsAny<XunitException>(() => intValue.Must().NotEqual<int>(123));

        int? intNullValue = null;
        intNullValue.Must().NotEqual<int?>(intValue);
        intValue.Must().NotEqual<int?>(intNullValue);

        short shortValue = 123;
        shortValue.Must().NotEqual<short>(124);
        shortValue.Must().NotEqual<short?>(null);
        Assert.ThrowsAny<XunitException>(() => shortValue.Must().NotEqual<short>(123));

        short? shortNullValue = null;
        shortNullValue.Must().NotEqual<short?>(shortValue);
        shortValue.Must().NotEqual<short?>(shortNullValue);

        long longValue = 123;
        longValue.Must().Equal<long>(123);
        longValue.Must().NotEqual<long?>(null);
        Assert.ThrowsAny<XunitException>(() => longValue.Must().NotEqual<long>(123));

        long? longNullValue = null;
        longNullValue.Must().NotEqual<long?>(longValue);
        longValue.Must().NotEqual<long?>(longNullValue);

        bool boolValue = true;
        boolValue.Must().NotEqual<bool>(false);
        boolValue.Must().NotEqual<bool?>(null);
        Assert.ThrowsAny<XunitException>(() => boolValue.Must().NotEqual<bool>(true));

        bool? boolNullValue = null;
        boolNullValue.Must().NotEqual<bool?>(boolValue);
        boolValue.Must().NotEqual(boolNullValue);

        boolValue = false;
        boolValue.Must().NotEqual<bool>(true);
        boolNullValue.Must().NotEqual<bool?>(boolValue);
        boolValue.Must().NotEqual(boolNullValue);
        Assert.ThrowsAny<XunitException>(() => boolValue.Must().NotEqual<bool>(false));

        float floatValue = 123.45f;
        floatValue.Must().NotEqual<float>((float)123.46);
        floatValue.Must().NotEqual<float?>(null);
        Assert.ThrowsAny<XunitException>(() => floatValue.Must().NotEqual<float>((float)123.45));

        float? floatNullValue = null;
        floatNullValue.Must().NotEqual<float?>(floatValue);
        floatValue.Must().NotEqual<float?>(floatNullValue);

        double doubleValue = 123.45;
        doubleValue.Must().NotEqual<double>((double)123.46);
        doubleValue.Must().NotEqual<double?>(null);
        Assert.ThrowsAny<XunitException>(() => doubleValue.Must().NotEqual<double>((double)123.45));

        double? doubleNullValue = null;
        doubleNullValue.Must().NotEqual<double?>(doubleValue);
        doubleValue.Must().NotEqual<double?>(doubleNullValue);

        string ts1 = "2025-01-02T03:04:05.678Z";
        string ts2 = "2025-01-02T03:04:05.679Z";

        DateTime dateTimeValue1 = DateTime.Parse(ts1, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        DateTime dateTimeValue2 = DateTime.Parse(ts2, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        dateTimeValue1.Must().NotEqual<DateTime>(dateTimeValue2);
        dateTimeValue2.Must().NotEqual<DateTime>(dateTimeValue1);
        Assert.ThrowsAny<XunitException>(() => dateTimeValue1.Must().NotEqual<DateTime>(DateTime.Parse(ts1, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind)));

        DateTime? dateTimeNullValue = null;
        dateTimeNullValue.Must().NotEqual<DateTime?>(dateTimeValue1);
        dateTimeValue1.Must().NotEqual<DateTime?>(dateTimeNullValue);

        ts1 = "2025-01-02T03:04:05.678-03:00";
        ts2 = "2025-01-02T03:04:05.678+03:00";
        DateTimeOffset dateTimeOffsetValue1 = DateTimeOffset.Parse(ts1, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        DateTimeOffset dateTimeOffsetValue2 = DateTimeOffset.Parse(ts2, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        dateTimeOffsetValue1.Must().NotEqual<DateTimeOffset>(dateTimeOffsetValue2);
        dateTimeOffsetValue2.Must().NotEqual<DateTimeOffset>(dateTimeOffsetValue1);
        Assert.ThrowsAny<XunitException>(() => dateTimeOffsetValue1.Must().NotEqual<DateTimeOffset>(DateTimeOffset.Parse(ts1, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind)));

        DateTimeOffset? dateTimeOffsetNullValue = null;
        dateTimeOffsetNullValue.Must().NotEqual(dateTimeOffsetValue1);
        dateTimeOffsetValue1.Must().NotEqual(dateTimeOffsetNullValue);

        string[] stringArray1 = ["abc", "def", "ghi"];
        string[] stringArray1A= ["abc", "def", "ghi"];
        string[] stringArray2 = ["abc", "123", "ghi"];
        string[] stringArray3 = ["ABC", "Def", "ghi"];

        stringArray1.Must().NotEqual(stringArray2, false);
        stringArray2.Must().NotEqual(stringArray1, false);
        stringArray1.Must().NotEqual(stringArray3, false);
        stringArray3.Must().NotEqual(stringArray1, false);
        Assert.ThrowsAny<XunitException>(() => stringArray1.Must().NotEqual(stringArray1A, false));
        Assert.ThrowsAny<XunitException>(() => stringArray1.Must().NotEqual(stringArray3, true));

        string[]? stringNullArray = null;
        stringNullArray.Must().NotEqual(stringArray1, false);
        stringNullArray.Must().NotEqual(stringArray1, true);
        stringArray1.Must().NotEqual(stringNullArray, false);
        stringArray1.Must().NotEqual(stringNullArray, true);

        List<string> stringList1 = ["abc", "def", "ghi"];
        List<string> stringList1A= ["abc", "def", "ghi"];
        List<string> stringList2 = ["abc", "123", "ghi"];       
        List<string> stringList3 = ["ABC", "Def", "ghi"];
        Assert.ThrowsAny<XunitException>(() => stringList1.Must().NotEqual(stringList1A, false));
        Assert.ThrowsAny<XunitException>(() => stringList1.Must().NotEqual(stringList3, true));

        stringList1.Must().NotEqual(stringList2, false);
        stringList2.Must().NotEqual(stringList1, false);
        stringList1.Must().NotEqual(stringList3, false);
        stringList3.Must().NotEqual(stringList1, false);

        List<string>? stringNullList = null;
        stringNullList.Must().NotEqual(stringList1, false);
        stringNullList.Must().NotEqual(stringList1, true);
        stringList1.Must().NotEqual(stringNullList, false);
        stringList1.Must().NotEqual(stringNullList, true);

        HashSet<string> stringHashSet1 = ["abc", "def", "ghi"];
        HashSet<string> stringHashSet1A = ["abc", "def", "ghi"];
        HashSet<string> stringHashSet2 = ["abc", "123", "ghi"];
        HashSet<string> stringHashSet3 = ["ABC", "Def", "ghi"];
        Assert.ThrowsAny<XunitException>(() => stringHashSet1.Must().NotEqual(stringHashSet1A, false));
        Assert.ThrowsAny<XunitException>(() => stringHashSet1.Must().NotEqual(stringHashSet3, true));

        stringHashSet1.Must().NotEqual(stringHashSet2, false);
        stringHashSet2.Must().NotEqual(stringHashSet1, false);
        stringHashSet1.Must().NotEqual(stringHashSet3, false);
        stringHashSet3.Must().NotEqual(stringHashSet1, false);

        HashSet<string>? stringNullHashSet = null;
        stringNullHashSet.Must().NotEqual(stringHashSet1, false);
        stringNullHashSet.Must().NotEqual(stringHashSet1, true);
        stringList1.Must().NotEqual(stringNullHashSet, false);
        stringList1.Must().NotEqual(stringNullHashSet, true);

        Dictionary<string, string> stringDictionary1 = new()
        {
            ["abc"] = "def",
            ["ghi"] = "jkl",
            ["mno"] = "pqr"
        };
        Dictionary<string, string> stringDictionary1A = new()
        {
            ["abc"] = "def",
            ["ghi"] = "jkl",
            ["mno"] = "pqr"
        };

        Dictionary<string, string> stringDictionary2 = new()
        {
            ["abc"] = "def",
            ["123"] = "jkl",
            ["mno"] = "pqr"
        };

        stringDictionary1.Must().NotEqual(stringDictionary2);
        stringDictionary2.Must().NotEqual(stringDictionary1);
        Assert.ThrowsAny<XunitException>(() => stringDictionary1.Must().NotEqual(stringDictionary1A));

        Dictionary<string,string>? stringNullDictionary= null;
        stringNullDictionary.Must().NotEqual(stringDictionary1);
        stringDictionary1.Must().NotEqual(stringNullDictionary);
    }
}
