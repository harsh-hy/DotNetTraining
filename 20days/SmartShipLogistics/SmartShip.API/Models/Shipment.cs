namespace SmartShip.API.Models;

public class Shipment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TrackingNumber { get; set; } = string.Empty;

    public string SenderName { get; set; } = string.Empty;

    public string ReceiverName { get; set; } = string.Empty;

    public string PickupAddress { get; set; } = string.Empty;

    public string DeliveryAddress { get; set; } = string.Empty;

    public decimal Weight { get; set; }

    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TrackingLog> TrackingLogs { get; set; } = new List<TrackingLog>();
}
