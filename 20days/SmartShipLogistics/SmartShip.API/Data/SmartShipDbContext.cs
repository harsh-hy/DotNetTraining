using Microsoft.EntityFrameworkCore;
using SmartShip.API.Models;

namespace SmartShip.API.Data;

public class SmartShipDbContext : DbContext
{
    public SmartShipDbContext(DbContextOptions<SmartShipDbContext> options)
        : base(options)
    {
    }

    public DbSet<Shipment> Shipments => Set<Shipment>();

    public DbSet<TrackingLog> TrackingLogs => Set<TrackingLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Shipment>()
            .HasIndex(s => s.TrackingNumber)
            .IsUnique();

        builder.Entity<Shipment>()
            .Property(s => s.Status)
            .HasConversion<string>();

        builder.Entity<Shipment>()
            .Property(s => s.Weight)
            .HasPrecision(10, 2);

        builder.Entity<TrackingLog>()
            .HasOne(t => t.Shipment)
            .WithMany(s => s.TrackingLogs)
            .HasForeignKey(t => t.ShipmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
