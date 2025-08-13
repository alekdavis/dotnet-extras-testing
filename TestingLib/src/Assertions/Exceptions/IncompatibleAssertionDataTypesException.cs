using System.Runtime.CompilerServices;

namespace DotNetExtras.Testing.Assertions.Exceptions;

/// <summary>
/// Initializes a new instance of the <see cref="IncompatibleAssertionDataTypesException"/> class.
/// </summary>
/// <param name="expected">
/// The expected value.
/// </param>
/// <param name="actual">
/// The actual value.
/// </param>
/// <param name="expectedName">
/// The name of the expected parameter.
/// </param>
/// <param name="actualName">
/// The name of the actual parameter.
/// </param>
/// <param name="method">
/// The name of the method.
/// </param>
public class IncompatibleAssertionDataTypesException
(
    object? expected,
    object? actual,
    [CallerArgumentExpression("expected")] string? expectedName = null,
    [CallerArgumentExpression("actual")] string? actualName = null,
    [CallerMemberName] string? method = null
)
: Exception
(
    $"The '{expected?.GetType()?.FullName ?? "null"}' data type of the '{expectedName}' parameter is not compatible with the '{actual?.GetType()?.FullName ?? "null"}' data type of the '{actualName}' parameter in the '{method}' assertion method."
)
{
}
