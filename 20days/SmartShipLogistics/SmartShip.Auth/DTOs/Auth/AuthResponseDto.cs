namespace SmartShip.Auth.DTOs.Auth;

/// <summary>
/// Represents the authentication response returned after a successful login.
/// </summary>
public class AuthResponseDto
{
    /// <summary>
    /// Gets or sets the JWT authentication token.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the authenticated user.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the authenticated user.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the authenticated user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the role assigned to the authenticated user.
    /// </summary>
    public string Role { get; set; } = string.Empty;
}