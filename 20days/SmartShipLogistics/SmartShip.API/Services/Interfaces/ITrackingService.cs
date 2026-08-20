using SmartShip.API.DTOs.Tracking;

namespace SmartShip.API.Services.Interfaces;

public interface ITrackingService
{
    Task<bool> AddTrackingAsync(TrackingEntryDto dto);

    Task<List<TrackingResultDto>> GetTrackingAsync(
        string trackingNumber);
}
