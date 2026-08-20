using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("shipment-count")]
    public async Task<IActionResult> ShipmentCount()
    {
        var count = await _adminService
            .GetShipmentCountAsync();

        return Ok(new { count });
    }

    [HttpGet("user/{userId}/shipment-count")]
    public async Task<IActionResult> UserShipmentCount(
        int userId)
    {
        var count = await _adminService
            .GetUserShipmentCountAsync(userId);

        return Ok(new { count });
    }
}
