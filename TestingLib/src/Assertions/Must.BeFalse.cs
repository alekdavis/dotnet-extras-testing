using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is false.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a boolean value.
    /// <code>
    /// false.Must().BeFalse();
    /// </code>
    /// </example>
    public Must BeFalse
    (
    )
    {
        Assert.NotNull(_actual);
        Assert.IsType<bool>(_actual, false);
        Assert.False((bool)_actual);

        return this;
    }
}
