using DotNetExtras.Testing.Assertions;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeNull()
    {
        string? nullString = null;
        nullString.Must().BeNull();

        string[]? nullArray = null;
        nullArray.Must().BeNull();

        bool? nullBool = null;
        nullBool.Must().BeNull();

        int? nullInt = null;
        nullInt.Must().BeNull();

        long? nullLong = null;
        nullLong.Must().BeNull();

        short? nullShort = null;
        nullShort.Must().BeNull();

        List<string>? nullList = null;
        nullList.Must().BeNull();

        string notNullString = "test";
        Assert.ThrowsAny<Exception>(() => notNullString.Must().BeNull());

        string[] notNullArray = ["test"];
        Assert.ThrowsAny<Exception>(() => notNullArray.Must().BeNull());

        bool notNullBool = true;
        Assert.ThrowsAny<Exception>(() => notNullBool.Must().BeNull());

        int notNullInt = 1;
        Assert.ThrowsAny<Exception>(() => notNullInt.Must().BeNull());

        long notNullLong = 1L;
        Assert.ThrowsAny<Exception>(() => notNullLong.Must().BeNull());

        short notNullShort = 1;
        Assert.ThrowsAny<Exception>(() => notNullShort.Must().BeNull());

        List<string> notNullList = ["test"];
        Assert.ThrowsAny<Exception>(() => notNullList.Must().BeNull());
    }
}
