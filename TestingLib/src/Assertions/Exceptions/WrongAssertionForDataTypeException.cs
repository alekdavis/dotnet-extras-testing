using DotNetExtras.Common.Extensions;
using System.Runtime.CompilerServices;

namespace DotNetExtras.Testing.Assertions.Exceptions;

/// <summary>
/// Exception thrown when the handling of a specific data type for a parameter is not implemented in the assertion method.
/// </summary>
/// <param name="parameter">
/// The parameter whose type handling is not implemented.
/// </param>
/// <param name="supportedAssertions">
/// The supported assertions for the parameter type.
/// </param>
/// <param name="name">
/// The name of the parameter.
/// </param>
/// <param name="method">
/// The name of the assertion method.
/// </param>

public class WrongAssertionForDataTypeException
(
    object? parameter,
    IEnumerable<string> supportedAssertions,
    [CallerArgumentExpression("parameter")] string? name = null,
    [CallerMemberName] string? method = null
)
: Exception
(
    $"Handling of the '{parameter?.GetType()?.Name ?? "null"}' type for the '{name}' parameter is not implemented in the '{method}' assertion method; use an alternative method: {((supportedAssertions == null || !supportedAssertions.Any()) ? "NO ALTERNATIVE METHOD IS AVAILABLE" : supportedAssertions?.ToCsv())}."
)
{
}
