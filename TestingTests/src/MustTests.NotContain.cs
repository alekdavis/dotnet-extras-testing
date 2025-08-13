using DotNetExtras.Testing.Assertions;
using TestingLibTests.Models;
using Xunit.Sdk;

namespace TestingLibTests;

public partial class MustTests
{
    [Fact]
    public void MustTests_NotContain_Primitive()
    {
        string helloMyWorldString = "Hello, my world!";

        helloMyWorldString.Must().NotContain("My", false);
        helloMyWorldString.Must().NotContain("HELLO", false);
        helloMyWorldString.Must().NotContain("his", true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContain("Hello", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContain("my", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().NotContain("WORLD", true));

        string[] helloMyWorldArray = ["hello", "my", "world"];
        helloMyWorldArray.Must().NotContain("Hell", false);
        helloMyWorldArray.Must().NotContain("MY", false);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContain("hello", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContain("my", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().NotContain("WORLD", true));

        List<string> helloMyWorldList = [.. helloMyWorldArray];
        helloMyWorldList.Must().NotContain("wo", false);
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().NotContain("hello", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().NotContain("my", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().NotContain("WORLD", true));

        int[] intArray = [100, 200, 300];
        intArray.Must().NotContain(400);
        Assert.ThrowsAny<XunitException>(() => intArray.Must().NotContain(100));

        List<int> intList = new(intArray);
        intList.Must().NotContain(500);
        Assert.ThrowsAny<XunitException>(() => intList.Must().NotContain(200));

        long[] longArray = [1000, 2000, 3000];
        longArray.Must().NotContain((long)4000);
        Assert.ThrowsAny<XunitException>(() => longArray.Must().NotContain((long)1000));

        List<long> longList = new(longArray);
        longList.Must().NotContain((long)5000);
        Assert.ThrowsAny<XunitException>(() => longList.Must().NotContain((long)2000));

        short[] shortArray = [10, 20, 30];
        shortArray.Must().NotContain((short)40);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().NotContain((short)10));

        List<short> shortList = new(shortArray);
        shortList.Must().NotContain((short)50);
        Assert.ThrowsAny<XunitException>(() => shortList.Must().NotContain((short)20));
    }

    [Fact]
    public void MustTests_NotContain_Complex()
    {
        List<User> users =
        [
            new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
        ];

        users.Must().NotContain<User>(new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "54321" }); 
        users.Must().NotContain<User>(new() { Name = new() { GivenName = "Joe", Surname = "Doe" } }, true); 
        users.Must().NotContain<User>(new() { Name = new() { GivenName = "John" }, Id = "13579" }, true); 
        users.Must().NotContain<User>(new() { Name = new() { Surname = "Do" } }, true); 
        users.Must().NotContain<User>(new() { Id = "24680" }, true); 

        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().NotContain<User>(new() { Name = new() { GivenName = "John", Surname = "Doe" } }, true)
        ); 
        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().NotContain<User>(new() { Name = new() { GivenName = "John" }, Id = "12345" }, true)
        ); 
        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().NotContain<User>(new() { Name = new() { Surname = "Doe" } }, true)
        ); 
        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().NotContain<User>(new() { Id = "12345" }, true)
        ); 
    }

}
