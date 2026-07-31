using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Controllers;

/// <summary>
/// Provides administrative endpoints for viewing shipment statistics.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AdminController"/> class.
    /// </summary>
    /// <param name="adminService">The service used to retrieve administrative shipment data.</param>
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    /// <summary>
    /// Retrieves the total number of shipments in the system.
    /// </summary>
    /// <returns>The total shipment count.</returns>
    [HttpGet("shipment-count")]
    public async Task<IActionResult> ShipmentCount()
    {
        var count = await _adminService
            .GetShipmentCountAsync();

        return Ok(new { count });
    }

    /// <summary>
    /// Retrieves the total number of shipments created by a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>The number of shipments associated with the specified user.</returns>
    [HttpGet("user/{userId}/shipment-count")]
    public async Task<IActionResult> UserShipmentCount(
        int userId)
    {
        var count = await _adminService
            .GetUserShipmentCountAsync(userId);

        return Ok(new { count });
    }
}