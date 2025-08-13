using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is null.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check any nullable type, such as object, string, array, etc.
    /// <code>
    /// object? o = null;
    /// o.Must().BeNull();
    /// 
    /// string? s = null;
    /// s.Must().BeNull();
    /// 
    /// string[]? a = null;
    /// a.Must().BeNull();
    /// </code>
    /// </example>
    public Must BeNull
    (
    )
    {
        Assert.Null(_actual);

        return this;
    }
}
