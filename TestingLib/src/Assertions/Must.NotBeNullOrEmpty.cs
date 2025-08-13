namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is not null and not empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// <code>
    /// "abc".Must().NotBeNullOrEmpty();
    /// </code>
    /// Check an array or any collection.
    /// <code>
    /// string[] sa = ["a", "b", "c"];
    /// sa.Must().NotBeNullOrEmpty();
    ///
    /// int[] ia = [1, 2, 3];
    /// ia.Must().NotBeNullOrEmpty();
    ///
    /// List&lt;string&gt;? sl = ["a", "b", "c"];
    /// sl.Must().NotBeNullOrEmpty();
    ///
    /// List&lt;int&gt;? il = [1, 2, 3];
    /// il.Must().NotBeNullOrEmpty();
    ///
    /// HashSet&lt;string&gt;? hs = ["a", "b", "c"];
    /// hs.Must().NotBeNullOrEmpty();
    ///
    /// Dictionary&lt;string, string&gt;? sd = new() { { "a", "b" } };
    /// sd.Must().NotBeNullOrEmpty();        
    /// </code>
    /// </example>
    public Must NotBeNullOrEmpty()
    {
        return NotBeEmpty();
    }
}
