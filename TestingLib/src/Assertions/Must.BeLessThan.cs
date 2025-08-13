using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is less than the expected value.
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
    /// 1.Must().BeLessThan(2);
    /// 
    /// "abc".Must().BeLessThan("xyz");
    /// 
    /// DateTime.Now.Must().BeLessThan(DateTime.Now.AddDays(1));  
    /// </code>
    /// </example>
    public Must BeLessThan<T>
    (
        T expected
    ) 
    where T : IComparable<T>
    {
        Assert.NotNull(_actual);
        Assert.NotNull(expected);

        Assert.True(((IComparable<T>)_actual).CompareTo(expected) < 0, 
            typeof(T) == typeof(string) 
                ? $"Expected '{_name}' to be less than [\"{expected}\"], but got [\"{_actual}\"]."
                : $"Expected '{_name}' to be less than [{expected}], but got [{_actual}].");

        return this;
    }
}
