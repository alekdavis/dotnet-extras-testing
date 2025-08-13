using DotNetExtras.Testing.Assertions;
using TestingLibTests.Models;
using Xunit.Sdk;

namespace TestingLibTests;
public partial class MustTests
{
    [Fact]
    public void MustTests_ContainAll_Primitive()
    {
        string helloMyWorldString = "Hello, my world!";
        
        helloMyWorldString.Must().ContainAll(["Hello", "world"], false);
        helloMyWorldString.Must().ContainAll(["HeLLo", "World"], true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().ContainAll(["Hello", "universe"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().ContainAll(["HeLLo", "Universe"], true));

        string[] helloMyWorldArray = ["Hello", "my", "world"];
        helloMyWorldArray.Must().ContainAll(["Hello", "world"], false);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().ContainAll(["Hello", "universe"], false));

        List<string> helloMyWorldList = [.. helloMyWorldArray];
        helloMyWorldList.Must().ContainAll(["HeLLo", "World"], true);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().ContainAll(["HeLLo", "Universe"], true));

        int[] intArray = [100, 200, 300];
        Assert.ThrowsAny<XunitException>(() => intArray.Must().ContainAll([100, 400]));
        intArray.Must().ContainAll([100, 200, 300]);

        List<int> intList = [.. intArray];
        intList.Must().ContainAll([200, 300]);
        Assert.ThrowsAny<XunitException>(() => intList.Must().ContainAll([400, 500]));

        long[] longArray = [1000, 2000, 3000];
        longArray.Must().ContainAll<long>([1000, 2000, 3000]);
        Assert.ThrowsAny<XunitException>(() => longArray.Must().ContainAll<long>([1000L, 4000L ]));

        List<long> longList = [.. longArray];
        longList.Must().ContainAll<long>([2000, 3000]);
        Assert.ThrowsAny<XunitException>(() => longList.Must().ContainAll<long>([4000L, 5000L]));

        short[] shortArray = [10, 20, 30];
        shortArray.Must().ContainAll<short>([10, 20, 30]);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().ContainAll<short>([10, 40]));

        List<short> shortList = [.. shortArray];
        shortList.Must().ContainAll<short>([20, 30]);
        Assert.ThrowsAny<XunitException>(() => shortList.Must().ContainAll<short>([40, 50]));
    }

    [Fact]
    public void MustTests_ContainAll_Complex()
    {
        List<User> users =
        [
            new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
            new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
        ];

        users.Must().ContainAll<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" }, 
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" }
        ], false);

        users.Must().ContainAll<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" } },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } }
         ], true);

        users.Must().ContainAll<User>
        ([
            new() { Name = new() { GivenName = "John" }, Id = "12345" },
            new() { Name = new() { GivenName = "Jack" } , Id = "13579" },
        ], true);

        users.Must().ContainAll<User>
        ([
            new() { Name = new() { Surname = "Doe" } },
            new() { Name = new() { Surname = "Green" } }
        ], true);

        users.Must().ContainAll<User>
        ([
            new() { Id = "12345" },
            new() { Id = "13579" }
        ], true); 

        Assert.ThrowsAny<XunitException>(() => users.Must().ContainAll<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" } },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" }
        ], false));

        Assert.ThrowsAny<XunitException>(() => users.Must().ContainAll<User>
        ([
            new() { Name = new() { GivenName = "John" }, Id = "12345" }
        ], false)); 
    }
}
