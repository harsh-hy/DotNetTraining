using System.ComponentModel.DataAnnotations;
using SmartShip.API.Models;

namespace SmartShip.API.DTOs.Tracking;

/// <summary>
/// Represents tracking information to be added to a shipment.
/// </summary>
public class TrackingEntryDto
{
    /// <summary>
    /// Gets or sets the tracking number of the shipment.
    /// </summary>
    [Required]
    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current location of the shipment.
    /// </summary>
    [Required]
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current status of the shipment.
    /// </summary>
    [Required]
    public ShipmentStatus Status { get; set; }
}