namespace SmartShip.API.DTOs.Tracking;

/// <summary>
/// Represents tracking information returned for a shipment.
/// </summary>
public class TrackingResultDto
{
    /// <summary>
    /// Gets or sets the tracking number of the shipment.
    /// </summary>
    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current location of the shipment.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current status of the shipment.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the tracking information was recorded.
    /// </summary>
    public DateTime Timestamp { get; set; }
}