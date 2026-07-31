using System.ComponentModel.DataAnnotations;

namespace SmartShip.API.DTOs.Shipment;

/// <summary>
/// Represents the information required to create a new shipment.
/// </summary>
public class NewShipmentDto
{
    /// <summary>
    /// Gets or sets the name of the sender.
    /// </summary>
    [Required]
    [StringLength(100)]

    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the receiver.
    /// </summary>
    [Required]
    [StringLength(100)]

    public string ReceiverName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the pickup address of the shipment.
    /// </summary>
    [Required]
    [StringLength(500)]
    public string PickupAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the delivery address of the shipment.
    /// </summary>
    [Required]
    [StringLength(500)]
    public string DeliveryAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the weight of the shipment.
    /// </summary>
    [Range(0.1, 100000)]
    public decimal Weight { get; set; }
}