using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is greater than the expected value.
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
    /// 2.Must().BeGreaterThan(1);
    /// 
    /// "xyz".Must().BeGreaterThan("abc");
    /// 
    /// DateTime.Now.AddDays(1).Must().BeGreaterThan(DateTime.Now);  
    /// </code>
    /// </example>
    public Must BeGreaterThan<T>
    (
        T expected
    ) 
    where T : IComparable<T>
    {
        Assert.NotNull(_actual);
        Assert.NotNull(expected);

        Assert.True(((IComparable<T>)_actual).CompareTo(expected) > 0, 
            typeof(T) == typeof(string) 
                ? $"Expected '{_name}' to be greater than [\"{expected}\"], but got [\"{_actual}\"]."
                : $"Expected '{_name}' to be greater than [{expected}], but got [{_actual}].");

        return this;
    }
}
