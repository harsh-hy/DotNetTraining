namespace SmartShip.API.DTOs.Tracking;

public class TrackingResultDto
{
    public string TrackingNumber { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }
}
