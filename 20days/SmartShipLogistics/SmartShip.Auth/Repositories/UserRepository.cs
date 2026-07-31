using Microsoft.EntityFrameworkCore;
using SmartShip.Auth.Data;
using SmartShip.Auth.Models;
using SmartShip.Auth.Repositories.Interfaces;

namespace SmartShip.Auth.Repositories;

/// <summary>
/// Provides data access operations for user accounts.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The database context used to access user data.</param>
    public UserRepository(AuthDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The user if found; otherwise, <see langword="null"/>.</returns>
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The user if found; otherwise, <see langword="null"/>.</returns>
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Email == email);
    }

    /// <summary>
    /// Checks whether a user with the specified email address exists.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns><see langword="true"/> if the email exists; otherwise, <see langword="false"/>.</returns>
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(user => user.Email == email);
    }

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list containing all users ordered by their identifier.</returns>
    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .OrderBy(user => user.Id)
            .ToListAsync();
    }

    /// <summary>
    /// Adds a new user to the database context.
    /// </summary>
    /// <param name="user">The user to add.</param>
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    /// <summary>
    /// Saves all pending changes to the database.
    /// </summary>
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}