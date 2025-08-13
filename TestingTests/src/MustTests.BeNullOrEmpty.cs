using DotNetExtras.Testing.Assertions;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_BeNullOrEmpty()
    {
        string? nullString = null;
        nullString.Must().BeNullOrEmpty();

        string emptyString = "";
        emptyString.Must().BeNullOrEmpty();

        string[]? nullStringArray = null;
        nullStringArray.Must().BeNullOrEmpty();

        string[] emptyStringArray = [];
        emptyStringArray.Must().BeNullOrEmpty();

        int[]? nullIntArray = null;
        nullIntArray.Must().BeNullOrEmpty();

        int[] emptyIntArray = [];
        emptyIntArray.Must().BeNullOrEmpty();

        List<string>? nullStringList = null;
        nullStringList.Must().BeNullOrEmpty();

        List<string>? emptyStringList = null;
        emptyStringList.Must().BeNullOrEmpty();

        List<int>? nullIntList = null;
        nullIntList.Must().BeNullOrEmpty();

        List<int>? emptyIntList = [];
        emptyStringArray.Must().BeNullOrEmpty();

        HashSet<string>? nullStringHashSet = null;
        nullStringHashSet.Must().BeNullOrEmpty();

        HashSet<string>? emptyStringHashSet = [];
        emptyStringArray.Must().BeNullOrEmpty();

        Dictionary<string, string>? nullStringDictionary = null;
        nullStringDictionary.Must().BeNullOrEmpty();

        Dictionary<string, string>? emptyStringDictionary = [];
        emptyStringArray.Must().BeNullOrEmpty();

        string notNullString = "test";
        Assert.ThrowsAny<Exception>(() => notNullString.Must().BeNullOrEmpty());

        string[] notNullArray = ["test"];
        Assert.ThrowsAny<Exception>(() => notNullArray.Must().BeNullOrEmpty());

        bool notNullBool = true;
        Assert.ThrowsAny<Exception>(() => notNullBool.Must().BeNullOrEmpty());

        int notNullInt = 1;
        Assert.ThrowsAny<Exception>(() => notNullInt.Must().BeNullOrEmpty());

        long notNullLong = 1L;
        Assert.ThrowsAny<Exception>(() => notNullLong.Must().BeNullOrEmpty());

        short notNullShort = 1;
        Assert.ThrowsAny<Exception>(() => notNullShort.Must().BeNullOrEmpty());

        List<string> notNullList = ["test"];
        Assert.ThrowsAny<Exception>(() => notNullList.Must().BeNullOrEmpty());

    }
}
