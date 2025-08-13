using System.Runtime.CompilerServices;

namespace DotNetExtras.Testing.Assertions;
/// <summary>
/// Provides a single extension method to invoke a <see cref="Must(object?, string?)"/> 
/// assertion on any object, variable, or property.
/// </summary>
public static class MustExtensions
{
    /// <summary>
    /// Starts the <see cref="Must"/> assertion chain on the specified object, variable, or property.
    /// </summary>
    /// <param name="value">
    /// The value to be asserted.
    /// </param>
    /// <param name="name">
    /// The name of the value parameter which is automatically captured by the compiler.
    /// </param>
    /// <returns>A new <see cref="Must"/> instance.</returns>
    /// <example>
    /// <code>
    /// user?.Must().NotBeNull();
    /// user?.Id?.Length?.Must().Equal(8);
    /// user?.Enabled?.Must().BeTrue();
    /// user?.Email?.Must().NotEndWith("example.com");
    /// user?.SocialAccounts?.Keys?.Must().NotBeNullOrEmpty().ContainAny(["github", "twitter", "facebook"]);
    /// </code>
    /// </example>
    public static Must Must
    (
        this object? value,
        [CallerArgumentExpression(nameof(value))] string? name = null
    )
    {
        return new(value, name!);
    }
}
