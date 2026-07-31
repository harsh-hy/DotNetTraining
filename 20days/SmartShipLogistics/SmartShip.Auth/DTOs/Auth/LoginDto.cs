using System.ComponentModel.DataAnnotations;

namespace SmartShip.Auth.DTOs.Auth;

/// <summary>
/// Represents the credentials required for user authentication.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Gets or sets the email address used for authentication.
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password used for authentication.
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;
}