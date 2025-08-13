using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeLessThan()
    {
        int intValue = 5;
        intValue.Must().BeLessThan(10);
        Assert.Throws<TrueException>(() => intValue.Must().BeLessThan(1));

        string stringValue = "apple";
        stringValue.Must().BeLessThan("banana");

        stringValue = "banana";
        Assert.Throws<TrueException>(() => stringValue.Must().BeLessThan("apple"));

        DateTime dateTimeValue = new(2021, 1, 1);
        dateTimeValue.Must().BeLessThan(new DateTime(2021, 1, 2));
        Assert.Throws<TrueException>(() => dateTimeValue.Must().BeLessThan(new DateTime(2020, 12, 31)));

        DateTimeOffset dateTimeOffsetValue = new(new DateTime(2021, 1, 1));
        dateTimeOffsetValue.Must().BeLessThan(new DateTimeOffset(new DateTime(2021, 1, 2)));
        Assert.Throws<TrueException>(() => dateTimeOffsetValue.Must().BeLessThan(new DateTimeOffset(new DateTime(2020, 12, 31))));

        object? nullValue = null;
        Assert.Throws<NotNullException>(() => nullValue.Must().BeLessThan(5));
    }
}
