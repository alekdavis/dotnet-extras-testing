using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is greater than or equal the expected value.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value and expected value. Must implement <see cref="IComparable{T}"/>.
    /// </typeparam>
    /// <param name="expected">
    /// The value to compare against.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check any simple type, such as integer, string, DateTime, etc.
    /// <code>
    /// 2.Must().BeGreaterThanOrEqual(1);
    /// 
    /// 1.Must().BeGreaterThanOrEqual(1);
    /// 
    /// "xyz".Must().BeGreaterThanOrEqual("abc");
    /// 
    /// "abc".Must().BeGreaterThanOrEqual("abc");
    /// 
    /// DateTime now = DateTime.Now;
    /// 
    /// now.Must().BeGreaterThanOrEqual(now);  
    /// </code>
    /// </example>
    public Must BeGreaterThanOrEqual<T>
    (
        T expected
    ) 
    where T : IComparable<T>
    {
        Assert.NotNull(_actual);
        Assert.NotNull(expected);

        Assert.True(((IComparable<T>)_actual).CompareTo(expected) >= 0, 
            typeof(T) == typeof(string) 
                ? $"Expected '{_name}' to be greater than or equal [\"{expected}\"], but got [\"{_actual}\"]."
                : $"Expected '{_name}' to be greater than or equal [{expected}], but got [{_actual}].");

        return this;
    }
}
