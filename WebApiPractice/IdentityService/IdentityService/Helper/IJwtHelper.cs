using IdentityService.Models;

namespace IdentityService.Helper
{
    public interface IJwtHelper
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}