using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is of the specified type.
    /// </summary>
    /// <typeparam name="T">
    /// The expected type of the value.
    /// </typeparam>
    /// <param name="strict">
    /// Indicates whether to perform a strict type check.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check any type, including primitive types, complex types, and collections.
    /// <code>
    /// "abc".Must().BeOfType&lt;string&gt;();
    /// 
    /// int i = 123;
    /// i.Must().BeOfType&lt;int&gt;();
    /// 
    /// true.Must().BeOfType&lt;bool&gt;();
    /// 
    /// DateTime.Now.Must().BeOfType&lt;DateTime&gt;();
    /// 
    /// string[] stringArray = ["a", "b", "c"];
    /// stringArray.Must().BeOfType&lt;string[]&gt;();
    /// stringArray.Must().BeOfType&lt;IEnumerable&lt;string&gt;&gt;();
    /// </code>
    /// </example>
    public Must BeOfType<T>
    (
        bool strict = false
    )
    {
        Assert.IsType<T>(_actual, strict);

        return this;
    }
}
