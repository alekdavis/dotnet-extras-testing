using DotNetExtras.Testing.Assertions.Exceptions;
using System.Collections;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is not empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a string.
    /// <code>
    /// "abc".Must().NotBeEmpty();
    /// </code>
    /// Check an array or any collection.
    /// <code>
    /// string[] sa = ["a", "b", "c"];
    /// sa.Must().NotBeEmpty();
    ///
    /// int[] ia = [1, 2, 3];
    /// ia.Must().NotBeEmpty();
    ///
    /// List&lt;string&gt;? sl = ["a", "b", "c"];
    /// sl.Must().NotBeEmpty();
    ///
    /// List&lt;int&gt;? il = [1, 2, 3];
    /// il.Must().NotBeEmpty();
    ///
    /// HashSet&lt;string&gt;? hs = ["a", "b", "c"];
    /// hs.Must().NotBeEmpty();
    ///
    /// Dictionary&lt;string, string&gt;? sd = new() { { "a", "b" } };
    /// sd.Must().NotBeEmpty();        
    /// </code>
    /// </example>
    public Must NotBeEmpty()
    {
        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            Assert.NotEmpty(actualString);
            return this;
        }

        if (_actual is IEnumerable actualEnumerable)
        {
            Assert.NotEmpty(actualEnumerable);
            return this;
        }

        throw new AssertionDataTypeNotImplementedException(_actual);
    }
}
