using SmartShip.Auth.DTOs.Auth;

namespace SmartShip.Auth.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto request);

    Task<AuthResponseDto?> LoginAsync(LoginDto request);

    Task<AuthResponseDto?> GetProfileAsync(int userId);

}