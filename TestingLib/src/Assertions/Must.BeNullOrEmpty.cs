namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is null or empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a string.
    /// <code>
    /// "".Must().BeNulOrEmpty();
    /// 
    /// string? s= null;
    /// s.Must().BeNullOrEmpty();
    /// </code>
    /// Check an array or any collection.
    /// <code>
    /// (new string[]).Must().BeNullOrEmpty();
    /// 
    /// string[]? sa = null;
    /// sa.Must().BeNullOrEmpty();
    /// 
    /// (new int[]).Must().BeNullOrEmpty();
    /// 
    /// int[]? ia = null;
    /// ia.Must().BeNullOrEmpty();
    /// 
    /// (new List&lt;string&gt;()).Must().BeNullOrEmpty();
    /// 
    /// List&lt;string&gt;? ls = null;
    /// ls.Must().BeNullOrEmpty();
    /// 
    /// (new Dictionary&lt;string, string&gt;()).Must().BeNullOrEmpty();
    /// 
    /// Dictionary&lt;string, string&gt;? ds = null;
    /// ds.Must().BeNullOrEmpty();
    /// </code>
    /// </example>
    public Must BeNullOrEmpty()
    {
        return _actual == null ? this : BeEmpty();
    }
}
