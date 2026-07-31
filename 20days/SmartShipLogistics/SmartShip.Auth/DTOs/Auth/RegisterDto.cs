using System.ComponentModel.DataAnnotations;

namespace SmartShip.Auth.DTOs.Auth;

/// <summary>
/// Represents the information required to register a new user account.
/// </summary>
public class RegisterDto
{
    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password used to create the user account.
    /// </summary>
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;
}