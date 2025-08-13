using DotNetExtras.Testing.Assertions;
using TestingLibTests.Models;
using Xunit.Sdk;

namespace TestingLibTests;

public partial class MustTests
{
    [Fact]
    public void MustTests_Contain_Primitive()
    {
        string helloMyWorldString = "Hello, my world!";

        helloMyWorldString.Must().Contain("my");
        helloMyWorldString.Must().Contain("my", false);
        helloMyWorldString.Must().Contain("My", true);
        helloMyWorldString.Must().Contain("MY", true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().Contain("his", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().Contain("his", true));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldString.Must().Contain("MY", false));

        string[] helloMyWorldArray = ["Hello", "my", "world"];
        List<string> helloMyWorldList = [.. helloMyWorldArray];

        helloMyWorldArray.Must().Contain("Hello", false);
        helloMyWorldArray.Must().Contain("HELLO", true);
        helloMyWorldList.Must().Contain("world", false);
        helloMyWorldList.Must().Contain("World", true);

        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().Contain("hi", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldArray.Must().Contain("hello", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().Contain("HELLO", false));
        Assert.ThrowsAny<XunitException>(() => helloMyWorldList.Must().Contain("He", false));

        int[] intArray = [100, 200, 300];
        intArray.Must().Contain(100);
        Assert.ThrowsAny<XunitException>(() => intArray.Must().Contain(400));

        List<int> intList = [.. intArray];
        intList.Must().Contain(300);
        Assert.ThrowsAny<XunitException>(() => intList.Must().Contain(400));

        long[] longArray = [1000, 2000, 3000];
        longArray.Must().Contain<long>(2000);
        Assert.ThrowsAny<XunitException>(() => longArray.Must().Contain<long>(4000));

        List<long> longList = [.. longArray];
        longList.Must().Contain<long>(3000);
        Assert.ThrowsAny<XunitException>(() => longList.Must().Contain<long>(4000));

        short[] shortArray = [10, 20, 30];
        shortArray.Must().Contain<short>(20);
        Assert.ThrowsAny<XunitException>(() => shortArray.Must().Contain<short>(40));

        List<short> shortList = [.. shortArray];
        shortList.Must().Contain<short>(30);
        Assert.ThrowsAny<XunitException>(() => shortList.Must().Contain<short>(40));

        List<User> users =
        [
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
        ]; 
    }

    [Fact]
    public void MustTests_Contain_Complex()
    {
        List<User> users =
        [
            new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
            new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
            new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
        ];

        users.Must().Contain<User>(new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" }, false); 
        users.Must().Contain<User>(new() { Name = new() { GivenName = "John", Surname = "Doe" } }, true); 
        users.Must().Contain<User>(new() { Name = new() { GivenName = "John" }, Id = "12345" }, true); 
        users.Must().Contain<User>(new() { Name = new() { Surname = "Doe" } }, true); 
        users.Must().Contain<User>(new() { Id = "12345" }, true); 

        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().Contain<User>(new() { Name = new() { GivenName = "John", Surname = "Doe" } }, false)
        ); 
        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().Contain<User>(new() { Name = new() { GivenName = "John" }, Id = "12345" }, false)
        ); 
        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().Contain<User>(new() { Name = new() { Surname = "Doe" } }, false)
        ); 
        Assert.ThrowsAny<XunitException>
        (
            () => users.Must().Contain<User>(new() { Id = "12345" }, false)
        ); 
    }
}
