using SmartShip.API.DTOs.Tracking;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Services;

public class TrackingService : ITrackingService
{
    private readonly ITrackingRepository _trackingRepository;
    private readonly IShipmentRepository _shipmentRepository;

    public TrackingService(
        ITrackingRepository trackingRepository,
        IShipmentRepository shipmentRepository)
    {
        _trackingRepository = trackingRepository;
        _shipmentRepository = shipmentRepository;
    }

    public async Task<bool> AddTrackingAsync(
        TrackingEntryDto dto)
    {
        var shipment = await _shipmentRepository
            .GetByTrackingNumberAsync(dto.TrackingNumber);

        if (shipment == null)
            return false;

        shipment.Status = dto.Status;

        await _shipmentRepository.UpdateAsync(shipment);

        var tracking = new TrackingLog
        {
            ShipmentId = shipment.Id,
            Location = dto.Location,
            Status = dto.Status.ToString(),
            Timestamp = DateTime.UtcNow
        };

        await _trackingRepository.AddAsync(tracking);

        return true;
    }

    public async Task<List<TrackingResultDto>> GetTrackingAsync(
        string trackingNumber)
    {
        var entries = await _trackingRepository
            .GetByTrackingNumberAsync(trackingNumber);

        return entries.Select(x => new TrackingResultDto
        {
            TrackingNumber = trackingNumber,
            Location = x.Location,
            Status = x.Status,
            Timestamp = x.Timestamp
        }).ToList();
    }
}
