using Microsoft.EntityFrameworkCore;
using SmartShip.Auth.Models;

namespace SmartShip.Auth.Data;

/// <summary>
/// Represents the database context for the authentication service.
/// </summary>
public class AuthDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthDbContext"/> class.
    /// </summary>
    /// <param name="options">The options used to configure the database context.</param>
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the collection of users stored in the database.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Configures the entity relationships, constraints, and database properties for the authentication service.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure the database model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(user => user.Id);

            entity.Property(user => user.FullName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.HasIndex(user => user.Email)
                .IsUnique();

            entity.Property(user => user.PasswordHash)
                .IsRequired();

            entity.Property(user => user.Role)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(user => user.CreatedAt)
                .IsRequired();
        });
    }
}