using SmartShip.API.DTOs.Shipment;
using SmartShip.API.Models;

namespace SmartShip.API.Services.Interfaces;

public interface IShipmentService
{
    Task<Shipment> CreateAsync(NewShipmentDto dto, int userId);

    Task<List<Shipment>> GetAllAsync();

    Task<List<Shipment>> GetMyShipmentsAsync(int userId);

    Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber);

    Task<bool> UpdateAsync(
        string trackingNumber,
        EditShipmentDto dto,
        int userId);

    Task<bool> UpdateStatusAsync(
        string trackingNumber,
        ShipmentStatus status,
        int userId);

    Task<bool> DeleteAsync(
        string trackingNumber,
        int userId);

    Task<int> GetCountAsync();
}
