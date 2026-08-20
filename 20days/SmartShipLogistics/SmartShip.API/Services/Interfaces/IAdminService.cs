namespace SmartShip.API.Services.Interfaces;

public interface IAdminService
{
    Task<int> GetShipmentCountAsync();

    Task<int> GetUserShipmentCountAsync(int userId);
}
