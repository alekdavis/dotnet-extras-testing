# DotNetExtras.Testing

`DotNetExtras.Testing` is a .NET Core library that implements common assertion methods that can be used in unit tests. It uses the existing [xUnit](https://xunit.net/) assertions and custom code trying to fill the gaps in the xUnit assertion library. The library API is similar to [FluentAssertion](https://fluentassertions.com/).

For assertion checks, just add the `DotNetExtras.Testing.Assertions` namespace to your test class and use the `Must()` extension method with the appropriate assertions on any variable or property, such as:

```csharp
user?.Must().NotBeNull();
user?.Id?.Length?.Must().Equal(8);
user?.Enabled?.Must().BeTrue();
user?.Email?.Must().NotEndWith("@example.com");
user?.SocialAccounts?.Keys?.Must().NotBeNullOrEmpty();
user?.SocialAccounts?.Values?.Must().ContainAny(["github", "twitter", "facebook"]);
```

## Documentation

For complete documentation, usage details, and code samples, see:

- [Documentation](https://alekdavis.github.io/dotnet-extras-testing)
- [Unit tests](https://github.com/alekdavis/dotnet-extras-testing/tree/main/TestingTests)

## Package

Install the latest version of the `DotNetExtras.Testing` Nuget package from:

- [https://www.nuget.org/packages/DotNetExtras.Testing](https://www.nuget.org/packages/DotNetExtras.Testing)

## See also

Check out other `DotNetExtras` libraries at:

- [https://github.com/alekdavis/dotnet-extras](https://github.com/alekdavis/dotnet-extras)
