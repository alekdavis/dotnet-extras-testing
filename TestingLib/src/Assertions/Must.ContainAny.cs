using DotNetExtras.Common;
using DotNetExtras.Common.Extensions;
using DotNetExtras.Common.Extensions.Specialized;
using DotNetExtras.Common.Json;
using DotNetExtras.Testing.Assertions.Exceptions;
using Xunit;
using Xunit.Sdk;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that at least one expected value exists in a collection. 
    /// </summary>
    /// <typeparam name="T">
    /// Type of the elements in the collections.
    /// </typeparam>
    /// <param name="expected">
    /// Collection of expected items.
    /// </param>
    /// <param name="partial">
    /// For complex types, 
    /// indicates whether the missing or null properties in the expected value 
    /// must be ignored in the actual value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <remarks>
    /// Expected: 
    /// (a, b, c).ContainAny(a, b): true; 
    /// (a, b, c).ContainAny(c, d): true; 
    /// (a, b, c).ContainAny(d, e): false.
    /// </remarks>
    /// <example>
    /// <code>
    /// List&lt;User&gt; users =
    /// [
    ///     new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
    ///     new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
    /// ];
    ///
    /// users.Must().ContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" }, 
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "00000" }
    /// ], false);
    ///
    /// users.Must().ContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } }
    ///  ], true);
    ///
    /// users.Must().ContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John" }, Id = "12345" },
    ///     new() { Name = new() { GivenName = "Jack" } , Id = "13579" },
    /// ], true);
    ///
    /// users.Must().ContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { Surname = "Doe" } },
    ///     new() { Name = new() { Surname = "Green" } }
    /// ], true);
    ///
    /// users.Must().ContainAny&lt;User&gt;
    /// ([
    ///     new() { Id = "12345" },
    ///     new() { Id = "13579" }
    /// ], true); 
    /// </code>
    /// </example>
    public Must ContainAny<T>
    (
        IEnumerable<T>? expected,
        bool partial = false
    )
    {
        if (expected == null || !expected.Any())
        {
            return this;
        }

        if (typeof(T) == typeof(string))
        {
            return ContainAny(expected.Cast<string>(), false);
        }
        
        Assert.NotNull(_actual);

        if (_actual is IEnumerable<T> actualList)
        {
            foreach (T expectedItem in expected)
            {
                try
                {
                    Assert.Contains(actualList, item => expectedItem.IsEquivalentTo(item, partial));
                    return this;
                }
                catch (ContainsException)
                {
                }
            }

            Assert.Fail($"Expected the '{_name}' collection to contain any of [{(typeof(T).IsSimple() ? expected.ToCsv() : expected.ToJson())}], but got [{(typeof(T).IsSimple() ? actualList.ToCsv() : actualList.ToJson())}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that at least one expected string value exists in a collection or string.
    /// </summary>
    /// <param name="expected">
    /// Collection of expected string items.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <remarks>
    /// Expected: 
    /// (a, b, c).ContainAny(a, b): true; 
    /// (a, b, c).ContainAny(c, d): true; 
    /// (a, b, c).ContainAny(d, e): false.
    /// </remarks>
    /// <example>
    /// Check a string value.
    /// <code>
    /// string s = "Hello, my world!";
    /// s.Must().ContainAny(["Hello", "me"], false);
    /// s.Must().ContainAny(["Hi", "my"], false);
    /// s.Must().ContainAny(["HeLlo", "ME"], true);
    /// </code>
    /// Check a string collection.
    /// <code>
    /// string[] a = ["Hello", "my", "world"];
    /// a.Must().ContainAny(["Hello", "me"], false);
    /// 
    /// List&lt;string&gt; l = new(a);
    /// l.Must().ContainAny(["MY", "world"], false);
    /// l.Must().ContainAny(["HELLO", "world"], false);
    /// l.Must().ContainAny(["Hi", "WORLD"], true);
    /// </code>
    /// </example>
    public Must ContainAny
    (
        IEnumerable<string>? expected,
        bool ignoreCase = false
    )
    {
        if (expected == null || !expected.Any())
        {
            return this;
        }
        
        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            Assert.True(expected.Any(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to contain any of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.True(expected.Any(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to contain any of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
