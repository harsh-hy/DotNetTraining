using SmartShip.API.DTOs.Shipment;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Services;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentService(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<Shipment> CreateAsync(
        NewShipmentDto dto,
        int userId)
    {
        var shipment = new Shipment
        {
            UserId = userId,
            TrackingNumber = GenerateTrackingNumber(),

            SenderName = dto.SenderName,
            ReceiverName = dto.ReceiverName,
            PickupAddress = dto.PickupAddress,
            DeliveryAddress = dto.DeliveryAddress,
            Weight = dto.Weight,

            Status = ShipmentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        return await _shipmentRepository.AddAsync(shipment);
    }

    public Task<List<Shipment>> GetAllAsync()
    {
        return _shipmentRepository.GetAllAsync();
    }

    public Task<List<Shipment>> GetMyShipmentsAsync(int userId)
    {
        return _shipmentRepository.GetByUserAsync(userId);
    }

    public Task<Shipment?> GetByTrackingNumberAsync(
        string trackingNumber)
    {
        return _shipmentRepository
            .GetByTrackingNumberAsync(trackingNumber);
    }

    public async Task<bool> UpdateAsync(
        string trackingNumber,
        EditShipmentDto dto,
        int userId)
    {
        var shipment = await _shipmentRepository
            .GetByTrackingNumberAsync(trackingNumber);

        if (shipment == null || shipment.UserId != userId)
            return false;

        shipment.SenderName = dto.SenderName;
        shipment.ReceiverName = dto.ReceiverName;
        shipment.PickupAddress = dto.PickupAddress;
        shipment.DeliveryAddress = dto.DeliveryAddress;
        shipment.Weight = dto.Weight;

        await _shipmentRepository.UpdateAsync(shipment);

        return true;
    }

    public async Task<bool> UpdateStatusAsync(
        string trackingNumber,
        ShipmentStatus status,
        int userId)
    {
        var shipment = await _shipmentRepository
            .GetByTrackingNumberAsync(trackingNumber);

        if (shipment == null || shipment.UserId != userId)
            return false;

        shipment.Status = status;

        await _shipmentRepository.UpdateAsync(shipment);

        return true;
    }

    public async Task<bool> DeleteAsync(
        string trackingNumber,
        int userId)
    {
        var shipment = await _shipmentRepository
            .GetByTrackingNumberAsync(trackingNumber);

        if (shipment == null || shipment.UserId != userId)
            return false;

        await _shipmentRepository.DeleteAsync(shipment);

        return true;
    }

    public Task<int> GetCountAsync()
    {
        return _shipmentRepository.CountAsync();
    }

    private string GenerateTrackingNumber()
    {
        const string chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        var random = new Random();

        var code = new string(
            Enumerable.Repeat(chars, 8)
                .Select(x => x[random.Next(x.Length)])
                .ToArray());

        return $"TRA-{code}";
    }
}
