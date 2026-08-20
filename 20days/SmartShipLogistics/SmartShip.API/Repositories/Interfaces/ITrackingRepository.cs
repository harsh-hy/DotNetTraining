using SmartShip.API.Models;

namespace SmartShip.API.Repositories.Interfaces;

public interface ITrackingRepository
{
    Task<TrackingLog> AddAsync(TrackingLog trackingLog);

    Task<List<TrackingLog>> GetByTrackingNumberAsync(string trackingNumber);
}
