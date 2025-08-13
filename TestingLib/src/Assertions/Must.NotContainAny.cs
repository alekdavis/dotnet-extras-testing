using DotNetExtras.Common;
using DotNetExtras.Common.Extensions;
using DotNetExtras.Testing.Assertions.Exceptions;
using Xunit;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that at least one expected value does not exist in a collection. 
    /// </summary>
    /// <typeparam name="T">
    /// Type of the elements in the collections.
    /// </typeparam>
    /// <param name="expected">
    /// Collection of items expected not to be in the actual collection or string.
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
    /// (a, b, c).NotContainAny(a, b): false; 
    /// (a, b, c).NotContainAny(a, d): false; 
    /// (a, b, c).NotContainAny(d, e): true.
    /// </remarks>
    /// <example>
    /// Check collections of simple types.
    /// <code>
    /// string[] helloMyWorldArray = ["Hello", "my", "world"];
    /// helloMyWorldArray.Must().NotContainAny(["hi", "there"], false);
    /// helloMyWorldArray.Must().NotContainAny(["Hell", "wo"], false);
    /// 
    /// List&lt;string&gt; helloMyWorldList = new(helloMyWorldArray);
    /// helloMyWorldList.Must().NotContainAny(["HI", "THERE"], true);
    /// helloMyWorldList.Must().NotContainAny(["HELLOO", "WORLD!"], true);
    ///
    /// int[] intArray = [100, 200, 300];
    /// intArray.Must().NotContainAny([400, 500]);
    ///
    /// List&lt;int&gt; intList = new(intArray);
    /// intList.Must().NotContainAny([400, 500]);
    ///
    /// long[] longArray = [1000, 2000, 3000];
    /// longArray.Must().NotContainAny&lt;long&gt;([4000L, 5000L]);
    ///
    /// List&lt;long&gt; longList = new(longArray);
    /// longList.Must().NotContainAny&lt;long&gt;([4000L, 5000L]);
    ///
    /// short[] shortArray = [10, 20, 30];
    /// shortArray.Must().NotContainAny&lt;short&gt;([40, 50]);
    ///
    /// List&lt;short&gt; shortList = new(shortArray);
    /// shortList.Must().NotContainAny&lt;short&gt;([40, 50]);
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
    /// users.Must().NotContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "00000" }, 
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } , Id = "13579" }
    /// ], false);
    ///
    /// users.Must().NotContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John", Surname = "More" } },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Yellow" } }
    ///  ], true);
    ///
    /// users.Must().NotContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { GivenName = "John" }, Id = "33333" },
    ///     new() { Name = new() { GivenName = "Jack" } , Id = "99999" },
    /// ], true);
    ///
    /// users.Must().NotContainAny&lt;User&gt;
    /// ([
    ///     new() { Name = new() { Surname = "Yellow" } },
    ///     new() { Name = new() { Surname = "White" } }
    /// ], true);
    ///
    /// users.Must().NotContainAny&lt;User&gt;
    /// ([
    ///     new() { Id = "33333" },
    ///     new() { Id = "99999" }
    /// ], true); 
    /// </code>
    /// </example>
    public Must NotContainAny<T>
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
            return NotContainAny(expected.Cast<string>(), false);
        }

        if (_actual is IEnumerable<T> actualList)
        {
            if (!actualList.Any())
            {
                return this;
            }

            foreach (T expectedItem in expected)
            {
                Assert.DoesNotContain(actualList, item => expectedItem.IsEquivalentTo(item, partial));
            }
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that at least one expected string does not exist in a collection of strings. 
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
    /// (a, b, c).NotContainAny(a, b): false; 
    /// (a, b, c).NotContainAny(a, d): false; 
    /// (a, b, c).NotContainAny(d, e): true.
    /// </remarks>
    /// <example>
    /// Check that a string does not contain any of the substrings.
    /// <code>
    /// string s = "Hello, my world!";
    /// s.Must().NotContainAny(["HELLO", "MY"], false);
    /// s.Must().NotContainAny(["Hi", "THERE"], true);
    /// </code>
    /// </example>
    public Must NotContainAny
    (
        IEnumerable<string> expected,
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
            Assert.False(expected.Any(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to not contain any of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.False(expected.Any(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to not contain any of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
