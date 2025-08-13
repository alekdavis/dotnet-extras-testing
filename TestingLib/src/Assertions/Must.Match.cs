using System.Text.RegularExpressions;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the actual string value matches the expected regular expression pattern.
    /// </summary>
    /// <param name="expected">
    /// The regular expression pattern that the actual string value is expected to match.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <remarks>
    /// If the expected pattern is null or empty, the assertion is considered successful.
    /// </remarks>
    /// <example>
    /// <code>
    ///  string s = "Hello, world!";
    ///
    ///  s.Must().Match("Hello, world!", false);
    ///  s.Must().Match("HELLO, WORLD!", true);
    ///  s.Must().Match("world", false);
    ///  s.Must().Match("WORLD", true);
    ///  s.Must().Match("^Hello, world!$", false);
    ///  s.Must().Match("^HELLO, WORLD!$", true);
    ///  s.Must().Match("^Hello,(\\s)*world!$", false);
    ///  s.Must().Match("^HELLO,(\\s)*WORLD!$", true);
    ///  s.Must().Match("^HELLO", true);
    ///  s.Must().Match("^hello", true);
    ///  s.Must().Match("WORLD!$", true);
    ///  s.Must().Match("world!$", true);
    /// </code>
    /// </example>
    public Must Match
    (
        string? expected,
        bool ignoreCase = false
    )
    {
        if (string.IsNullOrEmpty(expected))
        {
            return this;
        }

        Assert.IsType<string>(_actual);

        Regex regex = new(expected, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);

        Assert.Matches(regex, (string)_actual);

        return this;
    }
}
