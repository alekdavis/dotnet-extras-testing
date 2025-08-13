using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeGreaterThanOrEqual()
    {
        int intValue = 10;
        intValue.Must().BeGreaterThanOrEqual(5);
        intValue.Must().BeGreaterThanOrEqual(10);

        Assert.Throws<TrueException>(() => intValue.Must().BeGreaterThanOrEqual(100));

        string stringValue = "banana";
        stringValue.Must().BeGreaterThanOrEqual("apple");
        stringValue.Must().BeGreaterThanOrEqual("banana");

        stringValue = "apple";
        Assert.Throws<TrueException>(() => stringValue.Must().BeGreaterThanOrEqual("banana"));

        DateTime dateTimeValue = new(2021, 1, 2);
        dateTimeValue.Must().BeGreaterThanOrEqual(new DateTime(2021, 1, 1));
        dateTimeValue.Must().BeGreaterThanOrEqual(new DateTime(2021, 1, 2));
        Assert.Throws<TrueException>(() => dateTimeValue.Must().BeGreaterThanOrEqual(new DateTime(2021, 12, 31)));

        DateTimeOffset dateTimeOffsetValue = new(new DateTime(2021, 1, 2));
        dateTimeOffsetValue.Must().BeGreaterThanOrEqual(new DateTimeOffset(new DateTime(2021, 1, 1)));
        dateTimeOffsetValue.Must().BeGreaterThanOrEqual(new DateTimeOffset(new DateTime(2021, 1, 2)));
        Assert.Throws<TrueException>(() => dateTimeOffsetValue.Must().BeGreaterThanOrEqual(new DateTimeOffset(new DateTime(2021, 12, 31))));

        object? nullValue = null;
        Assert.Throws<NotNullException>(() => nullValue.Must().BeGreaterThanOrEqual(5));
    }
}
