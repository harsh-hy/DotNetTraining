using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.API.DTOs.Shipment;
using SmartShip.API.Models;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Controllers;

/// <summary>
/// Provides endpoints for creating, retrieving, updating, and deleting shipments.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _shipmentService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShipmentController"/> class.
    /// </summary>
    /// <param name="shipmentService">The service used to manage shipment operations.</param>
    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    /// <summary>
    /// Creates a new shipment for the authenticated user.
    /// </summary>
    /// <param name="dto">The shipment details provided by the user.</param>
    /// <returns>The newly created shipment.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(NewShipmentDto dto)
    {
        var userId = GetUserId();

        var shipment = await _shipmentService
            .CreateAsync(dto, userId);

        return Ok(shipment);
    }

    /// <summary>
    /// Retrieves all shipments in the system.
    /// </summary>
    /// <returns>A collection of all shipments.</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var shipments = await _shipmentService.GetAllAsync();

        return Ok(shipments);
    }

    /// <summary>
    /// Retrieves all shipments belonging to the authenticated user.
    /// </summary>
    /// <returns>A collection of the user's shipments.</returns>
    [HttpGet("my")]
    public async Task<IActionResult> GetMyShipments()
    {
        var userId = GetUserId();

        var shipments = await _shipmentService
            .GetMyShipmentsAsync(userId);

        return Ok(shipments);
    }

    /// <summary>
    /// Retrieves a shipment using its tracking number.
    /// </summary>
    /// <param name="trackingNumber">The tracking number of the shipment.</param>
    /// <returns>The shipment if found; otherwise, a not found response.</returns>
    [HttpGet("{trackingNumber}")]
    public async Task<IActionResult> GetByTrackingNumber(
        string trackingNumber)
    {
        var shipment = await _shipmentService
            .GetByTrackingNumberAsync(trackingNumber);

        if (shipment == null)
            return NotFound("Shipment not found.");

        return Ok(shipment);
    }

    /// <summary>
    /// Updates the details of an existing shipment.
    /// </summary>
    /// <param name="trackingNumber">The tracking number of the shipment to update.</param>
    /// <param name="dto">The updated shipment details.</param>
    /// <returns>A success response if the shipment is updated; otherwise, a not found response.</returns>
    [HttpPut("{trackingNumber}")]
    public async Task<IActionResult> Update(
        string trackingNumber,
        EditShipmentDto dto)
    {
        var userId = GetUserId();

        var updated = await _shipmentService.UpdateAsync(
            trackingNumber,
            dto,
            userId);

        if (!updated)
            return NotFound("Shipment not found.");

        return Ok("Shipment updated successfully.");
    }

    

    /// <summary>
    /// Deletes an existing shipment.
    /// </summary>
    /// <param name="trackingNumber">The tracking number of the shipment to delete.</param>
    /// <returns>A success response if the shipment is deleted; otherwise, a not found response.</returns>
    [HttpDelete("{trackingNumber}")]
    public async Task<IActionResult> Delete(
        string trackingNumber)
    {
        var userId = GetUserId();

        var deleted = await _shipmentService.DeleteAsync(
            trackingNumber,
            userId);

        if (!deleted)
            return NotFound("Shipment not found.");

        return Ok("Shipment deleted successfully.");
    }

    /// <summary>
    /// Retrieves the total number of shipments in the system.
    /// </summary>
    /// <returns>The total shipment count.</returns>
    [HttpGet("count")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCount()
    {
        var count = await _shipmentService.GetCountAsync();

        return Ok(new { count });
    }

    /// <summary>
    /// Retrieves the unique identifier of the currently authenticated user.
    /// </summary>
    /// <returns>The authenticated user's unique identifier.</returns>
    private int GetUserId()
    {
        return int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}