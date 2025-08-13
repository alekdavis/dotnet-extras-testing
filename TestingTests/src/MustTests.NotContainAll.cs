using DotNetExtras.Testing.Assertions;
using TestingLibTests.Models;
using Xunit.Sdk;

namespace TestingLibTests;

public partial class MustTests
{
    [Fact]
    public void MustTests_NotContainAll_Primitive()
    {
        string helloMyWorldString = "Hello, my world!";
        
        helloMyWorldString.Must().NotContainAll(["HELLO", "MY"], false);
        helloMyWorldString.Must().NotContainAll(["Hello", "MY"], false);
        helloMyWorldString.Must().NotContainAll(["Hi", "THERE"], true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContainAll(["Hello", "my"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContainAll(["HELLO", "MY"], true));

        string[] helloMyWorldArray = ["Hello", "my", "world"];
        List<string> helloMyWorldList = new(helloMyWorldArray);

        helloMyWorldArray.Must().NotContainAll(["hi", "there"], false);
        helloMyWorldArray.Must().NotContainAll(["Hell", "wo"], false);
        helloMyWorldList.Must().NotContainAll(["HI", "THERE"], true);
        helloMyWorldList.Must().NotContainAll(["HELLOO", "WORLD!"], true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContainAll(["Hello", "my"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContainAll(["HELLO", "MY"], true));

        int[] intArray = [100, 200, 300];
        intArray.Must().NotContainAll([400, 500]);
        Assert.ThrowsAny<XunitException>(() => intArray.Must().NotContainAll([100, 200]));

        List<int> intList = new(intArray);
        intList.Must().NotContainAll([400, 500]);
        Assert.ThrowsAny<XunitException>(() => intList.Must().NotContainAll([100, 200]));

        long[] longArray = [1000, 2000, 3000];
        longArray.Must().NotContainAll<long>([4000L, 5000L]);
        Assert.ThrowsAny<XunitException>(() => longArray.Must().NotContainAll([1000L, 2000L]));

        List<long> longList = new(longArray);
        longList.Must().NotContainAll<long>([4000L, 5000L]);
        Assert.ThrowsAny<XunitException>(() => longList.Must().NotContainAll([1000L, 2000L]));

        short[] shortArray = [10, 20, 30];
        shortArray.Must().NotContainAll<short>([40, 50]);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().NotContainAll([(short)10, (short)20]));

        List<short> shortList = new(shortArray);
        shortList.Must().NotContainAll<short>([40, 50]);
        Assert.ThrowsAny<XunitException>(() => shortList.Must().NotContainAll([(short)10, (short)20]));
    }

    [Fact]
    public void MustTests_NotContainAll_Complex()
    {
        List<User> users =
        [
            new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
            new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
        ];

        users.Must().NotContainAll<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "00000" }, 
            new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } , Id = "13579" }
        ], false);

        users.Must().NotContainAll<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" } },
            new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } }
         ], true);

        users.Must().NotContainAll<User>
        ([
            new() { Name = new() { GivenName = "John" }, Id = "12345" },
            new() { Name = new() { GivenName = "Jack" } , Id = "00000" },
        ], true);

        users.Must().NotContainAll<User>
        ([
            new() { Name = new() { Surname = "Doe" } },
            new() { Name = new() { Surname = "White" } }
        ], true);

        users.Must().NotContainAll<User>
        ([
            new() { Id = "12345" },
            new() { Id = "99999" }
        ], true); 

        Assert.ThrowsAny<XunitException>(() => users.Must().NotContainAll<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" }
        ], false));

        Assert.ThrowsAny<XunitException>(() => users.Must().NotContainAll<User>
        ([
            new() { Name = new() { GivenName = "John"}, Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" }
        ], true)); 
    }
}
