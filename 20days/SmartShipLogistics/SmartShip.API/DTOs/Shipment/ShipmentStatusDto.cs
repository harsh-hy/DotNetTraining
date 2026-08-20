using System.ComponentModel.DataAnnotations;
using SmartShip.API.Models;

namespace SmartShip.API.DTOs.Shipment;

public class ShipmentStatusDto
{
    [Required]
    public ShipmentStatus Status { get; set; }
}
