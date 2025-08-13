using DotNetExtras.Testing.Assertions;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_Match()
    {
        string s = "Hello, world!";

        s.Must().Match("Hello, world!", false);
        s.Must().Match("HELLO, WORLD!", true);
        s.Must().Match("world", false);
        s.Must().Match("WORLD", true);
        s.Must().Match("^Hello, world!$", false);
        s.Must().Match("^HELLO, WORLD!$", true);
        s.Must().Match("^Hello,(\\s)*world!$", false);
        s.Must().Match("^HELLO,(\\s)*WORLD!$", true);
        s.Must().Match("^HELLO", true);
        s.Must().Match("^hello", true);
        s.Must().Match("WORLD!$", true);
        s.Must().Match("world!$", true);
        
        Assert.ThrowsAny<Exception>(() => s.Must().Match("xyz", false));
        Assert.ThrowsAny<Exception>(() => s.Must().Match("xyz", true));
        Assert.ThrowsAny<Exception>(() => s.Must().Match("WORLD", false));
        Assert.ThrowsAny<Exception>(() => s.Must().Match("world$", false));
        Assert.ThrowsAny<Exception>(() => s.Must().Match("^hello", false));
        Assert.ThrowsAny<Exception>(() => s.Must().Match("^HELLO", false));
        Assert.ThrowsAny<Exception>(() => 123.Must().Match("abc", false));
        Assert.ThrowsAny<Exception>(() => true.Must().Match("abc", false));
#pragma warning disable CA1861 // Avoid constant arrays as arguments
        Assert.ThrowsAny<Exception>(() => (new int[]{1, 2, 3}).Must().Match("abc", false));
        Assert.ThrowsAny<Exception>(() => (new string[]{"a", "b", "c"}).Must().Match("abc", false));
#pragma warning restore CA1861 // Avoid constant arrays as arguments
    }
}
