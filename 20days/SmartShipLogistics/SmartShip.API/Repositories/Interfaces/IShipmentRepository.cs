using SmartShip.API.Models;

namespace SmartShip.API.Repositories.Interfaces;

public interface IShipmentRepository
{
    Task<Shipment> AddAsync(Shipment shipment);

    Task<List<Shipment>> GetAllAsync();

    Task<List<Shipment>> GetByUserAsync(int userId);

    Task<Shipment?> GetByTrackingNumberAsync(string trackingNumber);

    Task UpdateAsync(Shipment shipment);

    Task DeleteAsync(Shipment shipment);

    Task<int> CountAsync();
}
