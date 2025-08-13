using DotNetExtras.Common.Extensions;
using DotNetExtras.Testing.Assertions.Exceptions;
using Xunit;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that all expected values exist in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// Type of elements in the collection.
    /// </typeparam>
    /// <param name="expected">
    /// Collection of expected values.
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
    /// (a, b, c).ContainAll(a, b): true; 
    /// (a, b, c).ContainAll(c, d): false; 
    /// (a, b, c).ContainAll(d, e): false.
    /// </remarks>
    /// <example>
    /// Check a collection of objects.
    /// <code>
    /// List&lt;User&gt; users =
    /// [
    ///     new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
    ///     new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
    /// ];
    ///
    /// users.Must().ContainAll&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "12345" }, 
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" }
    /// ], false);
    ///
    /// users.Must().ContainAll&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } }
    ///  ], true);
    /// </code>
    /// </example>
    public Must ContainAll<T>
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
            return ContainAll(expected.Cast<string>());
        }

        Assert.NotNull(_actual);

        if (_actual is IEnumerable<T> actualList)
        {
            foreach (T expectedItem in expected)
            {
                Assert.Contains(actualList, item => expectedItem.IsEquivalentTo(item, partial));
            }
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that all expected string values exist in a string or string collection.
    /// </summary>
    /// <param name="expected">
    /// Collection of expected string values.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <remarks>
    /// Expected: 
    /// (a, b, c).ContainAll(a, b): true; 
    /// (a, b, c).ContainAll(c, d): false; 
    /// (a, b, c).ContainAll(d, e): false.
    /// </remarks>
    /// <example>
    /// Check a string.
    /// <code>
    /// string s = "Hello, my world!";
    /// 
    /// s.Must().ContainAll(["Hello", "world"], false);
    /// s.Must().ContainAll(["HeLLo", "World"], true);
    /// </code>
    /// Check a collection of strings.
    /// <code>
    /// string[] a = ["Hello", "my", "world"];
    /// a.Must().ContainAll(["Hello", "world"], false);
    ///
    /// List&gt;string&lt; l = [.. a];
    /// l.Must().ContainAll(["HeLLo", "World"], true);
    /// </code>
    /// </example>
    public Must ContainAll
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
            Assert.True(expected.All(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to contain all of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.True(expected.All(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to contain all of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
