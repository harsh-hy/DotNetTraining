using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.API.DTOs.Tracking;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TrackingController : ControllerBase
{
    private readonly ITrackingService _trackingService;

    public TrackingController(ITrackingService trackingService)
    {
        _trackingService = trackingService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddTracking(
        TrackingEntryDto dto)
    {
        var added = await _trackingService
            .AddTrackingAsync(dto);

        if (!added)
            return NotFound("Shipment not found.");

        return Ok("Tracking information added.");
    }

    [HttpGet("{trackingNumber}")]
    public async Task<IActionResult> GetTracking(
        string trackingNumber)
    {
        var tracking = await _trackingService
            .GetTrackingAsync(trackingNumber);

        if (tracking.Count == 0)
            return NotFound("No tracking information found.");

        return Ok(tracking);
    }
}
