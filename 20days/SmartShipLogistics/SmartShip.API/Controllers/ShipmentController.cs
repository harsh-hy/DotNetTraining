using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.API.DTOs.Shipment;
using SmartShip.API.Models;
using SmartShip.API.Services.Interfaces;

namespace SmartShip.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _shipmentService;

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewShipmentDto dto)
    {
        var userId = GetUserId();

        var shipment = await _shipmentService
            .CreateAsync(dto, userId);

        return Ok(shipment);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var shipments = await _shipmentService.GetAllAsync();

        return Ok(shipments);
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyShipments()
    {
        var userId = GetUserId();

        var shipments = await _shipmentService
            .GetMyShipmentsAsync(userId);

        return Ok(shipments);
    }

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

    [HttpPut("{trackingNumber}/status")]
    public async Task<IActionResult> UpdateStatus(
        string trackingNumber,
        ShipmentStatusDto dto)
    {
        var userId = GetUserId();

        var updated = await _shipmentService.UpdateStatusAsync(
            trackingNumber,
            dto.Status,
            userId);

        if (!updated)
            return NotFound("Shipment not found.");

        return Ok("Shipment status updated.");
    }

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

    [HttpGet("count")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCount()
    {
        var count = await _shipmentService.GetCountAsync();

        return Ok(new { count });
    }

    private int GetUserId()
    {
        return int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}
