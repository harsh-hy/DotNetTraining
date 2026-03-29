using IdentityService.Models;

namespace IdentityService.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}