using Microsoft.EntityFrameworkCore;
using SmartShip.IdentityService.Models;

namespace SmartShip.IdentityService.Data;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
}