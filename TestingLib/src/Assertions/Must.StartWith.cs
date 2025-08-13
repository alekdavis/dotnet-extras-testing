using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value starts with the expected value.
    /// </summary>
    /// <param name="expected">
    /// The expected starting value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// <code>
    /// string s = "Hello, world!";
    ///
    /// s.Must().StartWith("Hello", false);
    /// s.Must().StartWith("HELLO", true);
    /// s.Must().StartWith("hello", true);
    /// </code>
    /// </example>
    public Must StartWith
    (
        string expected,
        bool ignoreCase = false
    )
    {
        Assert.IsType<string>(_actual, false);
        Assert.StartsWith(expected, _actual?.ToString(), ignoreCase 
            ? StringComparison.OrdinalIgnoreCase 
            : StringComparison.Ordinal);

        return this;
    }
}
