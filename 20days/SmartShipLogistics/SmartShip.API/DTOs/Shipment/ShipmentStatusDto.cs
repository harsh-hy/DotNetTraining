using System.ComponentModel.DataAnnotations;
using SmartShip.API.Models;

namespace SmartShip.API.DTOs.Shipment;

/// <summary>
/// Represents the shipment status information used to update a shipment's status.
/// </summary>
public class ShipmentStatusDto
{
    /// <summary>
    /// Gets or sets the status of the shipment.
    /// </summary>
    [Required]
    public ShipmentStatus Status { get; set; }
}