using DotNetExtras.Testing.Assertions;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotMatch()
    {
        string s = "Hello, world!";

        s.Must().NotMatch("HELLO, world!", false);
        s.Must().NotMatch("HELL O, WORLD!", true);
        s.Must().NotMatch("worldX", false);
        s.Must().NotMatch("xWORLD", true);
        s.Must().NotMatch("^HELLO, world!$", false);
        s.Must().NotMatch("^HELLO, WO RLD!$", true);
        
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("Hello, world!", false));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("HELLO, WORLD!", true));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("world", false));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("WORLD", true));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("world!$", false));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("WORLD!$", true));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("Hello", false));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("HELLO", true));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("^Hello", false));
        Assert.ThrowsAny<Exception>(() => s.Must().NotMatch("^HELLO", true));
        Assert.ThrowsAny<Exception>(() => 123.Must().NotMatch("abc", false));
        Assert.ThrowsAny<Exception>(() => true.Must().NotMatch("abc", false));
        Assert.ThrowsAny<Exception>(() => (new int[]{1, 2, 3}).Must().NotMatch("abc", false));
        Assert.ThrowsAny<Exception>(() => (new string[]{"a", "b", "c"}).Must().NotMatch("abc", false));
    }
}
