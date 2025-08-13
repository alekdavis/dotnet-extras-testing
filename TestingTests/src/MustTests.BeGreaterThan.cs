using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeGreaterThan()
    {
        int intValue = 10;
        intValue.Must().BeGreaterThan(5);
        Assert.Throws<TrueException>(() => intValue.Must().BeGreaterThan(100));

        string stringValue = "banana";
        stringValue.Must().BeGreaterThan("apple");

        stringValue = "apple";
        Assert.Throws<TrueException>(() => stringValue.Must().BeGreaterThan("banana"));

        DateTime dateTimeValue = new(2021, 1, 2);
        dateTimeValue.Must().BeGreaterThan(new DateTime(2021, 1, 1));
        Assert.Throws<TrueException>(() => dateTimeValue.Must().BeGreaterThan(new DateTime(2021, 12, 31)));

        DateTimeOffset dateTimeOffsetValue = new(new DateTime(2021, 1, 2));
        dateTimeOffsetValue.Must().BeGreaterThan(new DateTimeOffset(new DateTime(2021, 1, 1)));
        Assert.Throws<TrueException>(() => dateTimeOffsetValue.Must().BeGreaterThan(new DateTimeOffset(new DateTime(2021, 12, 31))));

        object? nullValue = null;
        Assert.Throws<NotNullException>(() => nullValue.Must().BeGreaterThan(5));
    }
}
