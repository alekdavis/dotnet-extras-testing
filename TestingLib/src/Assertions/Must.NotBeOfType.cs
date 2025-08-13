using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is not of the specified type.
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
    /// <code>
    /// string s = "abc";
    /// s.Must().NotBeOfType&lt;bool&gt;();
    /// s.Must().NotBeOfType&lt;int&gt;();
    /// s.Must().NotBeOfType&lt;string[]&gt;();
    ///
    /// bool b = true;
    /// b.Must().NotBeOfType&lt;string&gt;();
    /// b.Must().NotBeOfType&lt;int&gt;();
    /// b.Must().NotBeOfType&lt;bool[]&gt;();
    ///
    /// int i = 1;
    /// i.Must().NotBeOfType&lt;string&gt;();
    /// i.Must().NotBeOfType&lt;bool&gt;();
    /// i.Must().NotBeOfType&lt;int[]&gt;();
    /// 
    /// int[] ia = [1, 2, 3];
    /// ia.Must().NotBeOfType&lt;int&gt;();
    /// ia.Must().NotBeOfType&lt;List&lt;int&gt;&gt;();
    /// ia.Must().NotBeOfType&lt;string[]&gt;();
    ///
    /// List&lt;string&gt; sl = ["a", "b", "c"];
    /// sl.Must().NotBeOfType&lt;string&gt;();
    /// sl.Must().NotBeOfType&lt;string[]&gt;();
    /// sl.Must().NotBeOfType&lt;List&lt;int&gt;&gt;();
    ///
    /// List&lt;int&gt; il = [1, 2, 3];
    /// il.Must().NotBeOfType&lt;int&gt;();
    /// il.Must().NotBeOfType&lt;int[]&gt;();
    /// il.Must().NotBeOfType&lt;List&lt;string&gt;&gt;();
    ///
    /// Dictionary&lt;string, string&gt; sd = new() { { "a", "b" } };
    /// sd.Must().NotBeOfType&lt;string&gt;();
    /// sd.Must().NotBeOfType&lt;Dictionary&lt;int, string&gt;&gt;();
    /// sd.Must().NotBeOfType&lt;Dictionary&lt;string, int&gt;&gt;();
    /// sd.Must().NotBeOfType&lt;string[]&gt;();
    /// </code>
    /// </example>
    public Must NotBeOfType<T>
    (
        bool strict = false
    )
    {
        Assert.IsNotType<T>(_actual, strict);

        return this;
    }
}
