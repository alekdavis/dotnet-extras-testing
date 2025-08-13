using System.Runtime.CompilerServices;

namespace DotNetExtras.Testing.Assertions.Exceptions;

/// <summary>
/// Exception thrown when a data type is not implemented in an assertion.
/// </summary>
/// <param name="parameter">
/// The parameter that caused the exception.
/// </param>
/// <param name="name">
/// The name of the parameter.
/// </param>
/// <param name="method">
/// The name of the method.
/// </param>
public class AssertionDataTypeNotImplementedException
(
    object? parameter,
    [CallerArgumentExpression("parameter")] string? name = null,
    [CallerMemberName] string? method = null
)
: NotImplementedException
(
    $"Handling of the '{parameter?.GetType()?.Name ?? "null"}' type for the '{name}' parameter is not implemented in the '{method}' assertion method."
)
{
}
