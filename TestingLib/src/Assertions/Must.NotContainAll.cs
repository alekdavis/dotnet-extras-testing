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
    /// Asserts that all expected values do not exist in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the collections.
    /// </typeparam>
    /// <param name="expected">
    /// The collection of items expected not to be in the actual collection or string.
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
    /// (a, b, c).NotContainAll(a, b): false; 
    /// (a, b, c).NotContainAll(c, d): true; 
    /// (a, b, c).NotContainAll(d, e): true;
    /// </remarks>
    /// <example>
    /// Check collections of simple types.
    /// <code>
    /// string[] helloMyWorldArray = ["Hello", "my", "world"];
    /// helloMyWorldArray.Must().NotContainAll(["hi", "there"], false);
    /// helloMyWorldArray.Must().NotContainAll(["Hell", "wo"], false);
    /// 
    /// List&lt;string&gt; helloMyWorldList = new(helloMyWorldArray);
    /// helloMyWorldList.Must().NotContainAll(["HI", "THERE"], true);
    /// helloMyWorldList.Must().NotContainAll(["HELLOO", "WORLD!"], true);
    ///
    /// int[] intArray = [100, 200, 300];
    /// intArray.Must().NotContainAll([400, 500]);
    ///
    /// List&lt;int&gt; intList = new(intArray);
    /// intList.Must().NotContainAll([400, 500]);
    ///
    /// long[] longArray = [1000, 2000, 3000];
    /// longArray.Must().NotContainAll&lt;long&gt;([4000L, 5000L]);
    ///
    /// List&lt;long&gt; longList = new(longArray);
    /// longList.Must().NotContainAll&lt;long&gt;([4000L, 5000L]);
    ///
    /// short[] shortArray = [10, 20, 30];
    /// shortArray.Must().NotContainAll&lt;short&gt;([40, 50]);
    ///
    /// List&lt;short&gt; shortList = new(shortArray);
    /// shortList.Must().NotContainAll&lt;short&gt;([40, 50]);
    /// </code>
    /// Check collection of complex type.
    /// <code>
    /// List&lt;User&gt; users =
    /// [
    ///     new() { Name = new() { GivenName = "Joe", Surname = "Black" } , Id = "00000" },
    ///     new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
    /// ];
    ///
    /// users.Must().NotContainAll&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "00000" }, 
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } , Id = "13579" }
    /// ], false);
    ///
    /// users.Must().NotContainAll&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } }
    ///  ], true);
    ///
    /// users.Must().NotContainAll&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John" }, Id = "12345" },
    ///     new() { Name = new() { GivenName = "Jack" } , Id = "00000" },
    /// ], true);
    ///
    /// users.Must().NotContainAll&lt;User&gt;
    /// ([
    ///     new() { Name = new() { Surname = "Doe" } },
    ///     new() { Name = new() { Surname = "White" } }
    /// ], true);
    ///
    /// users.Must().NotContainAll&lt;User&gt;
    /// ([
    ///     new() { Id = "12345" },
    ///     new() { Id = "99999" }
    /// ], true); 
    /// </code>
    /// </example>
    public Must NotContainAll<T>
    (
        IEnumerable<T>? expected,
        bool partial = false
    )
    {
        if (_actual == null || expected == null || !expected.Any())
        {
            return this;
        }

        if (typeof(T) == typeof(string))
        {
            return NotContainAll(expected.Cast<string>());
        }

        Assert.NotNull(_actual);

        if (_actual is IEnumerable<T> actualList)
        {
            foreach (T expectedItem in expected)
            {
                try
                {
                    Assert.DoesNotContain(actualList, item => expectedItem.IsEquivalentTo(item, partial));
                    return this;
                }
                catch (DoesNotContainException)
                {
                }
            }

            Assert.Fail($"Expected the '{_name}' collection to not contain all of [{(typeof(T).IsSimple() ? expected.ToCsv() : expected.ToJson())}], but got [{(typeof(T).IsSimple() ? actualList.ToCsv() : actualList.ToJson())}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that all expected string values doe not exist in a collection or string.
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
    /// (a, b, c).NotContainAll(a, b): false; 
    /// (a, b, c).NotContainAll(c, d): true; 
    /// (a, b, c).NotContainAll(d, e): true;
    /// </remarks>
    /// <example>
    /// Check that a string does not contain all of the substrings.
    /// <code>
    /// string s = "Hello, my world!";
    /// s.Must().NotContainAll(["HELLO", "MY"], false);
    /// s.Must().NotContainAll(["Hello", "MY"], false);
    /// s.Must().NotContainAll(["Hi", "THERE"], true);
    /// </code>
    /// </example>
    public Must NotContainAll
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
            Assert.False(expected.All(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to not contain all of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.False(expected.All(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to not contain all of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
