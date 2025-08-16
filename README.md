# DotNetExtras.Testing

`DotNetExtras.Testing` is a .NET Core library that implements common assertion methods that can be used in unit tests. It is built on top of [xUnit](https://xunit.net/) assertions and uses custom code for filling the gaps in the xUnit assertion library. The library API is similar to [FluentAssertion](https://fluentassertions.com/).

## Usage
For assertion checks, add the `DotNetExtras.Testing.Assertions` namespace to your test class and use the `Must()` extension method with the appropriate assertions on any variable or property, such as:

```csharp
using DotNetExtras.Testing.Assertions;
...

user?.Must().NotBeNull();
user?.Id?.Length?.Must().Equal(8);
user?.Enabled?.Must().BeTrue();
user?.Email?.Must().NotEndWith("@example.com");
user?.SocialAccounts?.Keys?.Must().NotBeNullOrEmpty();
user?.SocialAccounts?.Values?.Must().ContainAny(["github", "twitter", "facebook"]);
"Hello, world!".Must().Match("^HELLO", true);
new int[] intArray = [100, 200, 300];
intArray.Must().NotContainAny([400, 500]);
```

## Documentation

For complete documentation, usage details, and code samples, see:

- [Documentation](https://alekdavis.github.io/dotnet-extras-testing)
- [Unit tests](https://github.com/alekdavis/dotnet-extras-testing/tree/main/TestingTests)

## Package

Install the latest version of the `DotNetExtras.Testing` NuGet package from:

- [https://www.nuget.org/packages/DotNetExtras.Testing](https://www.nuget.org/packages/DotNetExtras.Testing)

## See also

Check out other `DotNetExtras` libraries at:

- [https://github.com/alekdavis/dotnet-extras](https://github.com/alekdavis/dotnet-extras)
