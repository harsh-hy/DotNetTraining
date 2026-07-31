using SmartShip.Auth.DTOs.Auth;
using SmartShip.Auth.Helpers;
using SmartShip.Auth.Models;
using SmartShip.Auth.Repositories.Interfaces;
using SmartShip.Auth.Services.Interfaces;
using SmartShip.Auth.Configurations;

namespace SmartShip.Auth.Services;

/// <summary>
/// Provides authentication and user account management operations.
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtHelper _jwtHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="userRepository">The repository used to access user data.</param>
    /// <param name="jwtHelper">The helper used to generate authentication tokens.</param>
    public AuthService(
        IUserRepository userRepository,
        JwtHelper jwtHelper)
    {
        _userRepository = userRepository;
        _jwtHelper = jwtHelper;
    }

    /// <summary>
    /// Registers a new customer account.
    /// </summary>
    /// <param name="request">The registration details provided by the user.</param>
    /// <returns><see langword="true"/> if the account is registered successfully; otherwise, <see langword="false"/> if the email already exists.</returns>
    public async Task<bool> RegisterAsync(RegisterDto request)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        if (await _userRepository.EmailExistsAsync(email))
        {
            return false;
        }

        var user = new User
        {
            FullName = request.FullName.Trim(),
            Email = email,
            PasswordHash = PasswordHelper.Hash(request.Password),
            Role = Roles.Customer
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Authenticates a user using the provided login credentials.
    /// </summary>
    /// <param name="request">The login credentials provided by the user.</param>
    /// <returns>An authentication response containing the user details and token if authentication succeeds; otherwise, <see langword="null"/>.</returns>
    public async Task<AuthResponseDto?> LoginAsync(LoginDto request)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null)
        {
            return null;
        }

        if (!PasswordHelper.Verify(request.Password, user.PasswordHash))
        {
            return null;
        }

        return CreateResponse(user);
    }

    /// <summary>
    /// Retrieves the profile of a user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>An authentication response containing the user's profile if found; otherwise, <see langword="null"/>.</returns>
    public async Task<AuthResponseDto?> GetProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        return user is null ? null : CreateResponse(user);
    }

    /// <summary>
    /// Creates an authentication response for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the response is created.</param>
    /// <returns>An authentication response containing the user's details and generated token.</returns>
    private AuthResponseDto CreateResponse(User user)
    {
        return new AuthResponseDto
        {
            Token = _jwtHelper.GenerateToken(user),
            UserId = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role
        };
    }
}