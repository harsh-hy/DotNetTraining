using SmartShip.Auth.Models;

namespace SmartShip.Auth.Repositories.Interfaces;

/// <summary>
/// Defines repository operations for managing user data.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The user if found; otherwise, <see langword="null"/>.</returns>
    Task<User?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The user if found; otherwise, <see langword="null"/>.</returns>
    Task<User?> GetByEmailAsync(string email);

    /// <summary>
    /// Checks whether a user with the specified email address exists.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns><see langword="true"/> if the email exists; otherwise, <see langword="false"/>.</returns>
    Task<bool> EmailExistsAsync(string email);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list containing all users.</returns>
    Task<List<User>> GetAllAsync();

    /// <summary>
    /// Adds a new user to the database.
    /// </summary>
    /// <param name="user">The user to add.</param>
    Task AddAsync(User user);

    /// <summary>
    /// Saves all pending changes to the database.
    /// </summary>
    Task SaveChangesAsync();
}