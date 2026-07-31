using SmartShip.Auth.DTOs.Auth;

namespace SmartShip.Auth.Services.Interfaces;

/// <summary>
/// Defines authentication and user account operations.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Registers a new user account.
    /// </summary>
    /// <param name="request">The registration details provided by the user.</param>
    /// <returns><see langword="true"/> if the registration is successful; otherwise, <see langword="false"/>.</returns>
    Task<bool> RegisterAsync(RegisterDto request);

    /// <summary>
    /// Authenticates a user using the provided login credentials.
    /// </summary>
    /// <param name="request">The login credentials provided by the user.</param>
    /// <returns>An authentication response if the credentials are valid; otherwise, <see langword="null"/>.</returns>
    Task<AuthResponseDto?> LoginAsync(LoginDto request);

    /// <summary>
    /// Retrieves the profile of a user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>The user's authentication profile if found; otherwise, <see langword="null"/>.</returns>
    Task<AuthResponseDto?> GetProfileAsync(int userId);
}