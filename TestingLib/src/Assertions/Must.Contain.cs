using DotNetExtras.Common;
using DotNetExtras.Common.Extensions;
using DotNetExtras.Testing.Assertions.Exceptions;
using System.Collections;
using Xunit;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that the expected value exists in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Value that is expected to be contained within the actual value.
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
    /// Check a string.
    /// <code>
    /// string s = "Hello, my world!"; 
    /// s.Must().Contain("my");
    /// s.Must().Contain("my", false);
    /// s.Must().Contain("My", true);
    /// s.Must().Contain("MY", true);
    /// </code>
    /// Check a string collection.
    /// <code>
    /// string[] sa = ["Hello", "my", "world"];
    /// sa.Must().Contain("Hello", false);
    /// sa.Must().Contain("HELLO", true);
    /// 
    /// List&lt;string&gt;> sl = [.. sa];
    /// sl.Must().Contain("world", false);
    /// sl.Must().Contain("World", true);
    /// </code>
    /// <code>
    /// int[] ia = [100, 200, 300];
    /// ia.Must().Contain(100);
    /// </code>
    /// </example>
    public Must Contain<T>
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
                expected, [nameof(Must.ContainAll), nameof(Must.ContainAny)]);
        }

        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            string? expectedString = expected is string 
                ? expected.ToString()
                : expected.GetType().IsEnum 
                    ? expected.ToString()
                    : null;

            return expectedString != null
                ? Contain(expectedString, false)
                : throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }
        else if (_actual is IEnumerable<T> actualList)
        {
            if (expected.GetType().IsAssignableFrom(typeof(T)))
            {
                Assert.Contains(actualList, item => expected.IsEquivalentTo(item, partial));
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
    /// Asserts that the expected string value exists in the actual string or collection of strings.
    /// </summary>
    /// <param name="expected">
    /// String value that is expected to be contained within the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a string.
    /// <code>
    /// string s = "Hello, my world!";
    /// s.Must().Contain("my");
    /// s.Must().Contain("my", false);
    /// s.Must().Contain("My", true);
    /// s.Must().Contain("MY", true);
    /// </code>
    /// </example>
    public Must Contain
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
            Assert.Contains(expected, actualString, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase 
                : StringComparison.Ordinal);
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.Contains(expected, actualList, ignoreCase 
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
