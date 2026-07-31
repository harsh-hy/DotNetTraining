namespace SmartShip.API.Models;

/// <summary>
/// Represents a shipment and its associated tracking information.
/// </summary>
public class Shipment
{
    /// <summary>
    /// Gets or sets the unique identifier of the shipment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user who created the shipment.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the tracking number assigned to the shipment.
    /// </summary>
    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the sender.
    /// </summary>
    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the receiver.
    /// </summary>
    public string ReceiverName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the pickup address of the shipment.
    /// </summary>
    public string PickupAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the delivery address of the shipment.
    /// </summary>
    public string DeliveryAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the weight of the shipment.
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the current status of the shipment.
    /// </summary>
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;

    /// <summary>
    /// Gets or sets the date and time when the shipment was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the collection of tracking logs associated with the shipment.
    /// </summary>
    public ICollection<TrackingLog> TrackingLogs { get; set; } = new List<TrackingLog>();
}