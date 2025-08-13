using DotNetExtras.Testing.Assertions;
using TestingLibTests.Models;
using Xunit.Sdk;

namespace TestingLibTests;

public partial class MustTests
{
    [Fact]
    public void MustTests_NotContainAny_Primitive()
    {
        string helloMyWorldString = "Hello, my world!";
        
        helloMyWorldString.Must().NotContainAny(["HELLO", "MY"], false);
        helloMyWorldString.Must().NotContainAny(["Hi", "THERE"], true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContainAny(["Hello", "his"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContainAny(["HELLO", "his"], true));

        string[] helloMyWorldArray = ["Hello", "my", "world"];
        List<string> helloMyWorldList = new(helloMyWorldArray);

        helloMyWorldArray.Must().NotContainAny(["hi", "there"], false);
        helloMyWorldArray.Must().NotContainAny(["Hell", "wo"], false);
        helloMyWorldList.Must().NotContainAny(["HI", "THERE"], true);
        helloMyWorldList.Must().NotContainAny(["HELLOO", "WORLD!"], true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContainAny(["Hello", "his"], false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContainAny(["HELLO", "his"], true));

        int[] intArray = [100, 200, 300];
        intArray.Must().NotContainAny([400, 500]);
        Assert.ThrowsAny<XunitException>(() => intArray.Must().NotContainAny([100, 400]));

        List<int> intList = new(intArray);
        intList.Must().NotContainAny([400, 500]);
        Assert.ThrowsAny<XunitException>(() => intList.Must().NotContainAny([100, 400]));

        long[] longArray = [1000, 2000, 3000];
        longArray.Must().NotContainAny<long>([4000L, 5000L]);
        Assert.ThrowsAny<XunitException>(() => longArray.Must().NotContainAny([1000L, 4000L]));

        List<long> longList = new(longArray);
        longList.Must().NotContainAny<long>([4000L, 5000L]);
        Assert.ThrowsAny<XunitException>(() => longList.Must().NotContainAny([1000L, 4000L]));

        short[] shortArray = [10, 20, 30];
        shortArray.Must().NotContainAny<short>([40, 50]);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().NotContainAny([(short)10, (short)40]));

        List<short> shortList = new(shortArray);
        shortList.Must().NotContainAny<short>([40, 50]);
        Assert.ThrowsAny<XunitException>(() => shortList.Must().NotContainAny([(short)10, (short)40]));
    }

    [Fact]
    public void MustTests_NotContainAny_Complex()
    {
        List<User> users =
        [
            new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
            new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
        ];

        users.Must().NotContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "00000" }, 
            new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } , Id = "13579" }
        ], false);

        users.Must().NotContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "More" } },
            new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } }
         ], true);

        users.Must().NotContainAny<User>
        ([
            new() { Name = new() { GivenName = "John" }, Id = "33333" },
            new() { Name = new() { GivenName = "Jack" } , Id = "99999" },
        ], true);

        users.Must().NotContainAny<User>
        ([
            new() { Name = new() { Surname = "Yellow" } },
            new() { Name = new() { Surname = "White" } }
        ], true);

        users.Must().NotContainAny<User>
        ([
            new() { Id = "33333" },
            new() { Id = "99999" }
        ], true); 

        Assert.ThrowsAny<XunitException>(() => users.Must().NotContainAny<User>
        ([
            new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "000000" }
        ], false));

        Assert.ThrowsAny<XunitException>(() => users.Must().NotContainAny<User>
        ([
            new() { Name = new() { GivenName = "John"}, Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "White" } , Id = "13579" }
        ], true)); 
    }
}
