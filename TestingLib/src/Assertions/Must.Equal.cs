using System.Collections.Specialized;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Expected value.
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
    /// string s = "abc";
    /// s.Must().Equal("abc", false);
    /// s.Must().Equal("ABC", true);
    /// </code>
    /// </example>
    public Must Equal
    (
        string? expected,
        bool ignoreCase = false
    )
    {
        Assert.IsType<string>(_actual, false);
        Assert.Equal(expected, _actual?.ToString(), ignoreCase);

        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Expected value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a string collection.
    /// <code>
    /// string[] sa = ["abc", "def", "ghi"];
    /// sa.Must().Equal(["abc", "def", "ghi"], false);
    /// sa.Must().Equal(["ABC", "Def", "ghi"], true);
    ///
    /// List&gt;string&gt; sl = ["abc", "def", "ghi"];
    /// sl.Must().Equal(["abc", "def", "ghi"], false);
    /// sl.Must().Equal(["ABC", "Def", "ghi"], true);
    /// </code>
    /// </example>
    public Must Equal
    (
        IEnumerable<string>? expected,
        bool ignoreCase = false
    )
    {
        if (expected == null && _actual == null)
        {
            return this;
        }

        Assert.IsType<IEnumerable<string>?>(_actual, false);

        Assert.NotNull(expected);
        Assert.NotNull(_actual);

        StringComparer comparer = ignoreCase ? 
            StringComparer.OrdinalIgnoreCase 
            : StringComparer.Ordinal;

        Assert.Equal(expected, (IEnumerable<string>)_actual, comparer);
        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Expected value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check simple types.
    /// <code>
    /// int i = 123;
    /// i.Must().Equal&lt;int&gt;(123);
    /// 
    /// true.Must().Equal(true);
    /// 
    /// DateTime dt = DateTime(2025, 12, 30, 24, 13, 8); 
    /// dt.Must().Equal&lt;DateTime&gt;(new DateTime(2025, 12, 30, 24, 13, 8));
    /// </code>
    /// Check string dictionary.
    /// <code>
    /// Dictionary&lt;string, string&gt; sd = new()
    /// {
    ///     ["abc"] = "def",
    ///     ["ghi"] = "jkl",
    ///     ["mno"] = "pqr"
    /// };
    ///
    /// sd.Must().Equal(new Dictionary&lt;string, string&gt;()
    /// {
    ///     ["abc"] = "def",
    ///     ["ghi"] = "jkl",
    ///     ["mno"] = "pqr"
    /// });
    /// </code>
    /// </example>
    public Must Equal<T>
    (
        T expected
    )
    {
        if (expected == null && _actual == null)
        {
            return this;
        }

        Assert.IsType<T>(_actual, false);
        Assert.Equal<T>(expected, (T)_actual);

        return this;
    }
}
