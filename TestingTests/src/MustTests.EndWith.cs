using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_EndWith()
    {
        string stringValue = "Hello, world!";

        stringValue.Must().EndWith("world!", false);
        stringValue.Must().EndWith("WORLD!", true);
        stringValue.Must().EndWith("world!", true);

        Assert.ThrowsAny<XunitException>(() => stringValue.Must().EndWith("Hello", false));
        Assert.ThrowsAny<XunitException>(() => stringValue.Must().EndWith("WORLD!", false));
     }
}
