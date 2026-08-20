namespace SmartShip.API.Models;

public class TrackingLog
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public string Location { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Shipment Shipment { get; set; } = null!;
}
