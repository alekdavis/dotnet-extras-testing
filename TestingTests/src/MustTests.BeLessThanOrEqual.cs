using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeLessThanOrEqual()
    {
        int intValue = 5;
        intValue.Must().BeLessThanOrEqual(5);
        intValue.Must().BeLessThanOrEqual(10);

        Assert.Throws<TrueException>(() => intValue.Must().BeLessThanOrEqual(1));

        string stringValue = "apple";
        stringValue.Must().BeLessThanOrEqual("banana");
        stringValue.Must().BeLessThanOrEqual("apple");

        stringValue = "banana";
        Assert.Throws<TrueException>(() => stringValue.Must().BeLessThanOrEqual("apple"));

        DateTime dateTimeValue = new(2021, 1, 1);
        dateTimeValue.Must().BeLessThanOrEqual(new DateTime(2021, 1, 2));
        dateTimeValue.Must().BeLessThanOrEqual(new DateTime(2021, 1, 1));
        Assert.Throws<TrueException>(() => dateTimeValue.Must().BeLessThanOrEqual(new DateTime(2020, 12, 31)));

        DateTimeOffset dateTimeOffsetValue = new(new DateTime(2021, 1, 1));
        dateTimeOffsetValue.Must().BeLessThanOrEqual(new DateTimeOffset(new DateTime(2021, 1, 2)));
        dateTimeOffsetValue.Must().BeLessThanOrEqual(new DateTimeOffset(new DateTime(2021, 1, 1)));
        Assert.Throws<TrueException>(() => dateTimeOffsetValue.Must().BeLessThanOrEqual(new DateTimeOffset(new DateTime(2020, 12, 31))));

        object? nullValue = null;
        Assert.Throws<NotNullException>(() => nullValue.Must().BeLessThanOrEqual(5));
    }
}
