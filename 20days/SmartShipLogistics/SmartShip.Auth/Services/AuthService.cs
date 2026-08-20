using SmartShip.Auth.DTOs.Auth;
using SmartShip.Auth.Helpers;
using SmartShip.Auth.Models;
using SmartShip.Auth.Repositories.Interfaces;
using SmartShip.Auth.Services.Interfaces;
using SmartShip.Auth.Configurations;
namespace SmartShip.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtHelper _jwtHelper;

    public AuthService(
        IUserRepository userRepository,
        JwtHelper jwtHelper)
    {
        _userRepository = userRepository;
        _jwtHelper = jwtHelper;
    }

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

    public async Task<AuthResponseDto?> GetProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        return user is null ? null : CreateResponse(user);
    }

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