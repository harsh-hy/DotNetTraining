namespace SmartShip.API.Models;

/// <summary>
/// Defines the possible statuses of a shipment.
/// </summary>
public enum ShipmentStatus
{
    /// <summary>
    /// Indicates that the shipment has been created but not yet picked up.
    /// </summary>
    Pending,  //0

    /// <summary>
    /// Indicates that the shipment has been picked up.
    /// </summary>
    PickedUp,  //1

    /// <summary>
    /// Indicates that the shipment is currently in transit.
    /// </summary>
    InTransit, //2

    /// <summary>
    /// Indicates that the shipment is out for delivery.
    /// </summary>
    OutForDelivery, //3

    /// <summary>
    /// Indicates that the shipment has been successfully delivered.
    /// </summary>
    Delivered,  //4

    /// <summary>
    /// Indicates that the shipment has been cancelled.
    /// </summary>
    Cancelled  //5
}