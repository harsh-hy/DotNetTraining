using Moq;
using NUnit.Framework;
using SmartShip.API.DTOs.Shipment;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services;

namespace SmartShip.API.Tests.Services;

[TestFixture]
public class ShipmentServiceTests
{
    private Mock<IShipmentRepository> _repository = null!;
    private ShipmentService _service = null!;

    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IShipmentRepository>();
        _service = new ShipmentService(_repository.Object);
    }

    [Test]
    public async Task Create_ValidShipment_ReturnsCreatedShipment()
    {
        var dto = new NewShipmentDto
        {
            SenderName = "Alice",
            ReceiverName = "Bob",
            PickupAddress = "Delhi",
            DeliveryAddress = "Mumbai",
            Weight = 5
        };

        _repository
            .Setup(x => x.AddAsync(It.IsAny<Shipment>()))
            .ReturnsAsync((Shipment shipment) => shipment);

        var result = await _service.CreateAsync(dto, 10);

        Assert.That(result.UserId, Is.EqualTo(10));
        Assert.That(result.SenderName, Is.EqualTo("Alice"));
        Assert.That(result.ReceiverName, Is.EqualTo("Bob"));
        Assert.That(result.PickupAddress, Is.EqualTo("Delhi"));
        Assert.That(result.DeliveryAddress, Is.EqualTo("Mumbai"));
        Assert.That(result.Weight, Is.EqualTo(5));
        Assert.That(result.Status, Is.EqualTo(ShipmentStatus.Pending));
        Assert.That(result.TrackingNumber, Does.StartWith("TRA-"));
        Assert.That(result.CreatedAt, Is.Not.EqualTo(default(DateTime)));

        _repository.Verify(
            x => x.AddAsync(It.IsAny<Shipment>()),
            Times.Once);
    }

    [Test]
    public async Task GetAll_ReturnsAllShipments()
    {
        var shipments = new List<Shipment>
        {
            new Shipment { Id = 1 },
            new Shipment { Id = 2 }
        };

        _repository
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(shipments);

        var result = await _service.GetAllAsync();

        Assert.That(result, Is.EqualTo(shipments));

        _repository.Verify(
            x => x.GetAllAsync(),
            Times.Once);
    }

    [Test]
    public async Task GetMyShipments_ReturnsCustomerShipments()
    {
        var shipments = new List<Shipment>
        {
            new Shipment { Id = 1, UserId = 5 },
            new Shipment { Id = 2, UserId = 5 }
        };

        _repository
            .Setup(x => x.GetByUserAsync(5))
            .ReturnsAsync(shipments);

        var result = await _service.GetMyShipmentsAsync(5);

        Assert.That(result.Count, Is.EqualTo(2));

        _repository.Verify(
            x => x.GetByUserAsync(5),
            Times.Once);
    }

    [Test]
    public async Task GetByTrackingNumber_ReturnsShipment()
    {
        var shipment = new Shipment
        {
            Id = 1,
            UserId = 10,
            TrackingNumber = "TRA-ABC12345"
        };

        _repository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(shipment);

        var result =
            await _service.GetByTrackingNumberAsync("TRA-ABC12345");

        Assert.That(result, Is.EqualTo(shipment));
    }

    [Test]
    public async Task GetMissingShipment_ReturnsNull()
    {
        _repository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-NOTFOUND"))
            .ReturnsAsync((Shipment?)null);

        var result =
            await _service.GetByTrackingNumberAsync("TRA-NOTFOUND");

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task Update_ValidShipment_ReturnsTrue()
    {
        var shipment = new Shipment
        {
            Id = 1,
            UserId = 10,
            TrackingNumber = "TRA-ABC12345",
            SenderName = "Old Sender",
            ReceiverName = "Old Receiver",
            PickupAddress = "Old Pickup",
            DeliveryAddress = "Old Delivery",
            Weight = 2
        };

        _repository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(shipment);

        var dto = new EditShipmentDto
        {
            SenderName = "New Sender",
            ReceiverName = "New Receiver",
            PickupAddress = "New Pickup",
            DeliveryAddress = "New Delivery",
            Weight = 10
        };

        var result = await _service.UpdateAsync(
            "TRA-ABC12345",
            dto,
            10);

        Assert.That(result, Is.True);
        Assert.That(shipment.SenderName, Is.EqualTo("New Sender"));
        Assert.That(shipment.ReceiverName, Is.EqualTo("New Receiver"));
        Assert.That(shipment.PickupAddress, Is.EqualTo("New Pickup"));
        Assert.That(shipment.DeliveryAddress, Is.EqualTo("New Delivery"));
        Assert.That(shipment.Weight, Is.EqualTo(10));

        _repository.Verify(
            x => x.UpdateAsync(shipment),
            Times.Once);
    }

    [Test]
    public async Task Update_AnotherCustomersShipment_ReturnsFalse()
    {
        var shipment = new Shipment
        {
            Id = 1,
            UserId = 20,
            TrackingNumber = "TRA-ABC12345"
        };

        _repository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(shipment);

        var dto = new EditShipmentDto
        {
            SenderName = "New Sender",
            ReceiverName = "New Receiver",
            PickupAddress = "New Pickup",
            DeliveryAddress = "New Delivery",
            Weight = 5
        };

        var result = await _service.UpdateAsync(
            "TRA-ABC12345",
            dto,
            10);

        Assert.That(result, Is.False);

        _repository.Verify(
            x => x.UpdateAsync(It.IsAny<Shipment>()),
            Times.Never);
    }
}
