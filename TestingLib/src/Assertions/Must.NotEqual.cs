using System.Collections.Specialized;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Value expected not to equal the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a string.
    /// <code>
    /// string s = "abc";
    /// 
    /// s.Must().NotEqual("def");
    /// s.Must().NotEqual("ABC");
    /// </code>
    /// </example>
    public Must NotEqual
    (
        string? expected,
        bool ignoreCase = false
    )
    {
        if (_actual != null)
        {
            Assert.IsType<string?>(_actual, false);
        }

        Assert.NotEqual(expected?.ToString(), _actual?.ToString(),
            ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);

        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Value expected not to equal the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a string collection.
    /// <code>
    /// string[] stringArray1 = ["abc", "def", "ghi"];
    /// string[] stringArray1A= ["abc", "def", "ghi"];
    /// string[] stringArray2 = ["abc", "123", "ghi"];
    /// string[] stringArray3 = ["ABC", "Def", "ghi"];
    ///
    /// stringArray1.Must().NotEqual(stringArray2, false);
    /// stringArray2.Must().NotEqual(stringArray1, false);
    /// stringArray1.Must().NotEqual(stringArray3, false);
    /// stringArray3.Must().NotEqual(stringArray1, false);
    ///
    /// string[]? stringNullArray = null;
    /// stringNullArray.Must().NotEqual(stringArray1, false);
    /// stringNullArray.Must().NotEqual(stringArray1, true);
    /// stringArray1.Must().NotEqual(stringNullArray, false);
    /// stringArray1.Must().NotEqual(stringNullArray, true);
    ///
    /// List&lt;string&gt; stringList1 = ["abc", "def", "ghi"];
    /// List&lt;string&gt; stringList1A= ["abc", "def", "ghi"];
    /// List&lt;string&gt; stringList2 = ["abc", "123", "ghi"];       
    /// List&lt;string&gt; stringList3 = ["ABC", "Def", "ghi"];
    ///
    /// stringList1.Must().NotEqual(stringList2, false);
    /// stringList2.Must().NotEqual(stringList1, false);
    /// stringList1.Must().NotEqual(stringList3, false);
    /// stringList3.Must().NotEqual(stringList1, false);
    ///
    /// List&lt;string&gt;? stringNullList = null;
    /// stringNullList.Must().NotEqual(stringList1, false);
    /// stringNullList.Must().NotEqual(stringList1, true);
    /// stringList1.Must().NotEqual(stringNullList, false);
    /// stringList1.Must().NotEqual(stringNullList, true);
    ///
    /// HashSet&lt;string&gt; stringHashSet1 = ["abc", "def", "ghi"];
    /// HashSet&lt;string&gt; stringHashSet1A = ["abc", "def", "ghi"];
    /// HashSet&lt;string&gt; stringHashSet2 = ["abc", "123", "ghi"];
    /// HashSet&lt;string&gt; stringHashSet3 = ["ABC", "Def", "ghi"];
    ///
    /// stringHashSet1.Must().NotEqual(stringHashSet2, false);
    /// stringHashSet2.Must().NotEqual(stringHashSet1, false);
    /// stringHashSet1.Must().NotEqual(stringHashSet3, false);
    /// stringHashSet3.Must().NotEqual(stringHashSet1, false);
    ///
    /// HashSet&lt;string&gt;? stringNullHashSet = null;
    /// stringNullHashSet.Must().NotEqual(stringHashSet1, false);
    /// stringNullHashSet.Must().NotEqual(stringHashSet1, true);
    /// stringList1.Must().NotEqual(stringNullHashSet, false);
    /// stringList1.Must().NotEqual(stringNullHashSet, true);
    ///
    /// Dictionary&lt;string, string&gt; stringDictionary1 = new()
    /// {
    ///     ["abc"] = "def",
    ///     ["ghi"] = "jkl",
    ///     ["mno"] = "pqr"
    /// };
    /// Dictionary&lt;string, string&gt; stringDictionary1A = new()
    /// {
    ///     ["abc"] = "def",
    ///     ["ghi"] = "jkl",
    ///     ["mno"] = "pqr"
    /// };
    ///
    /// Dictionary&lt;string, string&gt; stringDictionary2 = new()
    /// {
    ///     ["abc"] = "def",
    ///     ["123"] = "jkl",
    ///     ["mno"] = "pqr"
    /// };
    ///
    /// stringDictionary1.Must().NotEqual(stringDictionary2);
    /// stringDictionary2.Must().NotEqual(stringDictionary1);
    ///
    /// Dictionary&lt;string,string&gt;? stringNullDictionary= null;
    /// stringNullDictionary.Must().NotEqual(stringDictionary1);
    /// stringDictionary1.Must().NotEqual(stringNullDictionary);
    /// </code>
    /// </example>
    public Must NotEqual
    (
        IEnumerable<string>? expected,
        bool ignoreCase = false
    )
    {
        if (_actual != null)
        {
            Assert.IsType<IEnumerable<string>?>(_actual, false);
        }

        StringComparer comparer = ignoreCase ?
            StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal;

        Assert.NotEqual(expected, _actual as IEnumerable<string?>, comparer);

        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Value expected not to equal the actual value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <example>
    /// Check a value.
    /// <code>
    /// 1.Must().NotEqual(2);
    /// true.Must().NotEqual(false);
    /// DateTime.Now.Must().NotEqual(DateTime.Now.AddDays(1));  
    /// </code>
    /// </example>
    public Must NotEqual<T>
    (
        T expected
    )
    {
        if ((_actual != null && expected == null) || (_actual == null && expected != null))
        {
            return this;
        }

        if (_actual != null)
        {
            Assert.IsType<T>(_actual, false);
            Assert.NotEqual<T>(expected, (T)_actual);
        }

        return this;
    }
}
