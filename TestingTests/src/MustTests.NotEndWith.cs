using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotEndWith()
    {
        string stringValue = "Hello, world!";

        stringValue.Must().NotEndWith("WORLD!", false);
        stringValue.Must().NotEndWith("Hello", false);

        Assert.ThrowsAny<XunitException>(() => stringValue.Must().NotEndWith("world!", false));
        Assert.ThrowsAny<XunitException>(() => stringValue.Must().NotEndWith("WORLD!", true));
    }
}
