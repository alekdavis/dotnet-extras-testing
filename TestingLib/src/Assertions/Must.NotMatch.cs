using System.Text.RegularExpressions;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the actual string value does not match the expected regular expression pattern.
    /// </summary>
    /// <param name="expected">
    /// The regular expression pattern that the actual string value is expected to not match.
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
    /// string s = "Hello, world!";
    ///
    /// s.Must().NotMatch("HELLO, world!", false);
    /// s.Must().NotMatch("HELL O, WORLD!", true);
    /// s.Must().NotMatch("worldX", false);
    /// s.Must().NotMatch("xWORLD", true);
    /// s.Must().NotMatch("^HELLO, world!$", false);
    /// s.Must().NotMatch("^HELLO, WO RLD!$", true);
    /// </code>
    /// </example>
    public Must NotMatch
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

        Assert.DoesNotMatch(regex, (string)_actual);

        return this;
    }
}
