using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotStartWith()
    {
        string stringValue = "Hello, world!";

        stringValue.Must().NotStartWith("world!", false);
        stringValue.Must().NotStartWith("HELLO", false);
        stringValue.Must().NotStartWith("hello", false);

        Assert.ThrowsAny<XunitException>(() => stringValue.Must().NotStartWith("Hello", false));
        Assert.ThrowsAny<XunitException>(() => stringValue.Must().NotStartWith("HELLO", true));
    }
}
