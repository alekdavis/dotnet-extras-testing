using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeTrue()
    {
        true.Must().BeTrue();
        (!false).Must().BeTrue();

        bool value1 = true;
        value1.Must().BeTrue();

        value1 = false;
        Assert.Throws<TrueException>(() => value1.Must().BeTrue());

        bool? value2 = true;
        value2.Must().BeTrue();

        value2 = false;
        Assert.Throws<TrueException>(() => value2.Must().BeTrue());
       
        Assert.Throws<TrueException>(() => false.Must().BeTrue());
        Assert.Throws<TrueException>(() => (!true).Must().BeTrue());
    }
}
