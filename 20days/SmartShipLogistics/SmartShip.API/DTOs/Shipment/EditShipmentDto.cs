using System.ComponentModel.DataAnnotations;

namespace SmartShip.API.DTOs.Shipment;

public class EditShipmentDto
{
    [Required]
    public string SenderName { get; set; } = string.Empty;

    [Required]
    public string ReceiverName { get; set; } = string.Empty;

    [Required]
    public string PickupAddress { get; set; } = string.Empty;

    [Required]
    public string DeliveryAddress { get; set; } = string.Empty;

    [Range(0.1, 100000)]
    public decimal Weight { get; set; }
}
