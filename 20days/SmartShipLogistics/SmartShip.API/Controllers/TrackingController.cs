using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.API.DTOs.Tracking;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Controllers;

/// <summary>
/// Provides endpoints for managing and retrieving shipment tracking information.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TrackingController : ControllerBase
{
    private readonly ITrackingService _trackingService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TrackingController"/> class.
    /// </summary>
    /// <param name="trackingService">The service used to manage shipment tracking information.</param>
    public TrackingController(ITrackingService trackingService)
    {
        _trackingService = trackingService;
    }

    /// <summary>
    /// Adds tracking information to a shipment.
    /// </summary>
    /// <param name="dto">The tracking information to add.</param>
    /// <returns>A success response if the tracking information is added; otherwise, a not found response.</returns>
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

    /// <summary>
    /// Retrieves tracking information for a shipment using its tracking number.
    /// </summary>
    /// <param name="trackingNumber">The tracking number of the shipment.</param>
    /// <returns>The tracking information if found; otherwise, a not found response.</returns>
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