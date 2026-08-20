using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Services;

public class AdminService : IAdminService
{
    private readonly IShipmentRepository _shipmentRepository;

    public AdminService(
        IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public Task<int> GetShipmentCountAsync()
    {
        return _shipmentRepository.CountAsync();
    }

    public async Task<int> GetUserShipmentCountAsync(int userId)
    {
        var shipments = await _shipmentRepository
            .GetByUserAsync(userId);

        return shipments.Count;
    }
}
