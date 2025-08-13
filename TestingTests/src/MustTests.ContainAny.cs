using DotNetExtras.Testing.Assertions;
using TestingLibTests.Models;
using Xunit.Sdk;

namespace TestingLibTests;

public partial class MustTests
{
    [Fact]
    public void MustTests_ContainAny_Primitive()
    {
        string helloMyWorldString = "Hello, my world!";
        
        helloMyWorldString.Must().ContainAny(["Hello", "me"], false);
        helloMyWorldString.Must().ContainAny(["Hi", "my"], false);
        helloMyWorldString.Must().ContainAny(["HeLlo", "ME"], true);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().ContainAny(["Hi", "me"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().ContainAny(["HELLO", "WORLD"], false));

        string[] helloMyWorldArray = ["Hello", "my", "world"];
        helloMyWorldArray.Must().ContainAny(["Hello", "me"], false);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().ContainAny(["HELLO", "WORLD"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().ContainAny(["Hi", "there"], false));

        List<string> helloMyWorldList = new(helloMyWorldArray);
        helloMyWorldList.Must().ContainAny(["MY", "world"], false);
        helloMyWorldList.Must().ContainAny(["HELLO", "world"], false);
        helloMyWorldList.Must().ContainAny(["Hi", "WORLD"], true);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().ContainAny(["HELLO", "WORLD"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().ContainAny(["Hi", "there"], false));

        int[] intArray = [100, 200, 300];
        intArray.Must().ContainAny([100, 700]);
        Assert.ThrowsAny<XunitException>(() => intArray.Must().ContainAny([400, 500]));

        List<int> intList = new(intArray);
        intList.Must().ContainAny([200, 700]);
        Assert.ThrowsAny<XunitException>(() => intList.Must().ContainAny([400, 500]));

        long[] longArray = [1000, 2000, 3000];
        longArray.Must().ContainAny<long>([1000, 2000]);
        Assert.ThrowsAny<XunitException>(() => longArray.Must().ContainAny([4000L, 5000L]));

        List<long> longList = new(longArray);
        longList.Must().ContainAny<long>([2000, 7000]);
        Assert.ThrowsAny<XunitException>(() => longList.Must().ContainAny([4000L, 5000L]));

        short[] shortArray = [10, 20, 30];
        shortArray.Must().ContainAny<short>([10, 20]);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().ContainAny([(short)400, (short)500]));

        List<short> shortList = new(shortArray);
        shortList.Must().ContainAny<short>([20, 30]);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().ContainAny([(short)400, (short)500]));
    }

    [Fact]
    public void MustTests_ContainAny_Complex()
    {
        List<User> users =
        [
            new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
            new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
        ];

        users.Must().ContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" }, 
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "00000" }
        ], false);

        users.Must().ContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" } },
            new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } }
         ], true);

        users.Must().ContainAny<User>
        ([
            new() { Name = new() { GivenName = "John" }, Id = "12345" },
            new() { Name = new() { GivenName = "Jack" } , Id = "13579" },
        ], true);

        users.Must().ContainAny<User>
        ([
            new() { Name = new() { Surname = "Doe" } },
            new() { Name = new() { Surname = "Green" } }
        ], true);

        users.Must().ContainAny<User>
        ([
            new() { Id = "12345" },
            new() { Id = "13579" }
        ], true); 

        Assert.ThrowsAny<XunitException>(() => users.Must().ContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "99999" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" }, Id = "00000" }
        ], false));

        Assert.ThrowsAny<XunitException>(() => users.Must().ContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "White" } },
            new() { Name = new() { GivenName = "Jack", Surname = "Black" } }
        ], true)); 
    }
}
