using Microsoft.EntityFrameworkCore;
using SmartShip.API.Data;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;

namespace SmartShip.API.Repositories;

public class TrackingRepository : ITrackingRepository
{
    private readonly SmartShipDbContext _db;

    public TrackingRepository(SmartShipDbContext db)
    {
        _db = db;
    }

    public async Task<TrackingLog> AddAsync(TrackingLog trackingLog)
    {
        _db.TrackingLogs.Add(trackingLog);
        await _db.SaveChangesAsync();

        return trackingLog;
    }

    public async Task<List<TrackingLog>> GetByTrackingNumberAsync(
        string trackingNumber)
    {
        return await _db.TrackingLogs
            .AsNoTracking()
            .Where(t => t.Shipment.TrackingNumber == trackingNumber)
            .OrderBy(t => t.Timestamp)
            .ToListAsync();
    }
}
