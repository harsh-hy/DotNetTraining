namespace SmartShip.API.Models;

/// <summary>
/// Represents a tracking log entry associated with a shipment.
/// </summary>
public class TrackingLog
{
    /// <summary>
    /// Gets or sets the unique identifier of the tracking log.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated shipment.
    /// </summary>
    public int ShipmentId { get; set; }

    /// <summary>
    /// Gets or sets the location recorded for the shipment.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the shipment status recorded in the tracking log.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the tracking information was recorded.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the shipment associated with this tracking log.
    /// </summary>
    public Shipment Shipment { get; set; } = null!;
}