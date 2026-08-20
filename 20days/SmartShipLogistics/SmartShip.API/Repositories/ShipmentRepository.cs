using Microsoft.EntityFrameworkCore;
using SmartShip.API.Data;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;

namespace SmartShip.API.Repositories;

public class ShipmentRepository : IShipmentRepository
{
    private readonly SmartShipDbContext _db;

    public ShipmentRepository(SmartShipDbContext db)
    {
        _db = db;
    }

    public async Task<Shipment> AddAsync(Shipment shipment)
    {
        _db.Shipments.Add(shipment);
        await _db.SaveChangesAsync();

        return shipment;
    }

    public async Task<List<Shipment>> GetAllAsync()
    {
        return await _db.Shipments
            .AsNoTracking()
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Shipment>> GetByUserAsync(int userId)
    {
        return await _db.Shipments
            .AsNoTracking()
            .Where(s => s.UserId == userId)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
    }

    public async Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber)
    {
        return await _db.Shipments
            .FirstOrDefaultAsync(s => s.TrackingNumber == trackingNumber);
    }

    public async Task UpdateAsync(Shipment shipment)
    {
        _db.Shipments.Update(shipment);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Shipment shipment)
    {
        _db.Shipments.Remove(shipment);
        await _db.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _db.Shipments.CountAsync();
    }
}
