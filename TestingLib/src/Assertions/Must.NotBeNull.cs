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
    /// <code>
    /// object? o = new();
    /// o.Must().NotBeNull();
    /// 
    /// string? s = "abc";
    /// s.Must().NotBeNull();
    /// 
    /// string[]? a = [];
    /// a.Must().NotBeNull();
    /// </code>
    /// </example>
    public Must NotBeNull
    (
    )
    {
        Assert.NotNull(_actual);

        return this;
    }
}
