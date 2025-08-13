using DotNetExtras.Common.Extensions;
using DotNetExtras.Testing.Assertions.Exceptions;
using System.Collections;
using Xunit;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that the expected value does not exist in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Value that is expected to not be contained within the actual value.
    /// </param>
    /// <param name="partial">
    /// For complex types, 
    /// indicates whether the missing or null properties in the expected value 
    /// must be ignored in the actual value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check collections of simple types.
    /// <code>
    /// string[] helloMyWorldArray = ["hello", "my", "world"];
    /// helloMyWorldArray.Must().NotContain("Hell", false);
    /// helloMyWorldArray.Must().NotContain("MY", false);
    ///
    /// List&lt;string&gt; helloMyWorldList = [.. helloMyWorldArray];
    /// helloMyWorldList.Must().NotContain("wo", false);
    ///
    /// int[] intArray = [100, 200, 300];
    /// intArray.Must().NotContain(400);
    ///
    /// List&lt;int&gt; intList = new(intArray);
    /// intList.Must().NotContain(500);
    ///
    /// long[] longArray = [1000, 2000, 3000];
    /// longArray.Must().NotContain((long)4000);
    ///
    /// List&lt;long&gt; longList = new(longArray);
    /// longList.Must().NotContain((long)5000);
    ///
    /// short[] shortArray = [10, 20, 30];
    /// shortArray.Must().NotContain((short)40);
    ///
    /// List&lt;short&gt; shortList = new(shortArray);
    /// shortList.Must().NotContain((short)50);
    /// </code>
    /// Check collection of complex type.
    /// <code>
    /// List&lt;User&gt; users =
    /// [
    ///     new() { Name = new() { GivenName = "Mary", Surname = "Beth" } , Id = "54321" },
    ///     new() { Name = new() { GivenName = "John", Surname = "Doe" } , Id = "12345" },
    ///     new() { Name = new() { GivenName = "Jack", Surname = "Green" } , Id = "13579" },
    /// ];
    /// users.Must().NotContain&lt;User&gt;(new() { Name = new() { GivenName = "John", Surname = "Doe" }, Id = "54321" }); 
    /// users.Must().NotContain&lt;User&gt;(new() { Name = new() { GivenName = "Joe", Surname = "Doe" } }, true); 
    /// users.Must().NotContain&lt;User&gt;(new() { Name = new() { GivenName = "John" }, Id = "13579" }, true); 
    /// users.Must().NotContain&lt;User&gt;(new() { Name = new() { Surname = "Do" } }, true); 
    /// users.Must().NotContain&lt;User&gt;(new() { Id = "24680" }, true); 
    /// </code>
    /// </example>
    public Must NotContain<T>
    (
        T? expected,
        bool partial = false
    )
    {
        if (expected == null)
        {
            return this;
        }

        if (expected is IEnumerable and not string)
        {
            throw new WrongAssertionForDataTypeException(
                expected, [nameof(Must.NotContainAll), nameof(Must.NotContainAny)]);
        }

        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            return expected is string expectedString
                ? NotContain(expectedString, false)
                : throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }
        else if (_actual is IEnumerable<T> actualList)
        {
            if (expected.GetType().IsAssignableFrom(typeof(T)))
            {
                Assert.DoesNotContain(actualList, item => expected.IsEquivalentTo(item, partial));
            }
            else
            {
                throw new IncompatibleAssertionDataTypesException(expected, _actual);
            }
        }
        else
        {
            throw new AssertionDataTypeNotImplementedException(_actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that the expected string value does not exist in the actual string or collection of strings.
    /// </summary>
    /// <param name="expected">
    /// String value that is expected to not be contained within the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check that a string does not contain certain substrings.
    /// <code>
    /// string s = "Hello, my world!";
    /// s.Must().NotContain("My", false);
    /// s.Must().NotContain("HELLO", false);
    /// s.Must().NotContain("his", true);
    /// </code>
    /// </example>
    public Must NotContain
    (
        string? expected,
        bool ignoreCase = false
    )
    {
        if (string.IsNullOrEmpty(expected))
        {
            return this;
        }
        
        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            Assert.DoesNotContain(expected, actualString, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase 
                : StringComparison.Ordinal);
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.DoesNotContain(expected, actualList, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase 
                : StringComparer.Ordinal);
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
