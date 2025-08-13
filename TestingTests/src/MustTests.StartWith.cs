using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_StartWith()
    {
        string stringValue = "Hello, world!";

        stringValue.Must().StartWith("Hello", false);
        stringValue.Must().StartWith("HELLO", true);
        stringValue.Must().StartWith("hello", true);

        Assert.ThrowsAny<XunitException>(() => stringValue.Must().StartWith("HELLO", false));
        Assert.ThrowsAny<XunitException>(() => stringValue.Must().StartWith("WORLD!", false));
    }
}
