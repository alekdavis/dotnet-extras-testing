using DotNetExtras.Testing.Assertions;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeFalse()
    {
        false.Must().BeFalse();
        (!true).Must().BeFalse();

        bool value1 = false;
        value1.Must().BeFalse();

        value1 = true;
        Assert.Throws<FalseException>(() => value1.Must().BeFalse());

        bool? value2 = false;
        value2.Must().BeFalse();

        value2 = true;
        Assert.Throws<FalseException>(() => value2.Must().BeFalse());
        
        Assert.Throws<FalseException>(() => true.Must().BeFalse());
        Assert.Throws<FalseException>(() => (!false).Must().BeFalse());
    }
}
