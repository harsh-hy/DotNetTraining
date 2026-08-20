using System.ComponentModel.DataAnnotations;
using SmartShip.API.Models;

namespace SmartShip.API.DTOs.Tracking;

public class TrackingEntryDto
{
    [Required]
    public string TrackingNumber { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    [Required]
    public ShipmentStatus Status { get; set; }
}
