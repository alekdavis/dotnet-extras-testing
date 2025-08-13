using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_NotBeNull()
    {
        string? string1 = "abc";
        string1.Must().NotBeNull();

        string string2 = "abc";
        string2.Must().NotBeNull();

        string string3 = "";
        string3.Must().NotBeNull();

        int? int1 = 123;
        int1.Must().NotBeNull();

        int int2 = 123;
        int2.Must().NotBeNull();

        int? int3 = 0;
        int3.Must().NotBeNull();

        long? long1 = 123;
        long1.Must().NotBeNull();

        long long2 = 123;
        long2.Must().NotBeNull();

        long? long3 = 0;
        long3.Must().NotBeNull();

        short? short1 = 123;
        short1.Must().NotBeNull();

        short short2 = 123;
        short2.Must().NotBeNull();

        short? short3 = 0;
        short3.Must().NotBeNull();

        bool bool1 = true;
        bool1.Must().NotBeNull();

        bool bool2 = false;
        bool2.Must().NotBeNull();

        bool? bool3 = true;
        bool3.Must().NotBeNull();

        bool? bool4 = false;
        bool4.Must().NotBeNull();
        
        string1 = null;
        Assert.ThrowsAny<XunitException>(() => string1.Must().NotBeNull());

        int1 = null;
        Assert.ThrowsAny<XunitException>(() => int1.Must().NotBeNull());

        long1 = null;
        Assert.ThrowsAny<XunitException>(() => long1.Must().NotBeNull());

        short1 = null;
        Assert.ThrowsAny<XunitException>(() => short1.Must().NotBeNull());

        bool3 = null;
        Assert.ThrowsAny<XunitException>(() => bool3.Must().NotBeNull());
    }
}
