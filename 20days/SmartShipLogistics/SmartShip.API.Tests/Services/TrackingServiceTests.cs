using Moq;
using NUnit.Framework;
using SmartShip.API.DTOs.Tracking;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services;

namespace SmartShip.API.Tests.Services;

[TestFixture]
public class TrackingServiceTests
{
    private Mock<ITrackingRepository> _trackingRepository = null!;
    private Mock<IShipmentRepository> _shipmentRepository = null!;
    private TrackingService _service = null!;

    [SetUp]
    public void Setup()
    {
        _trackingRepository = new Mock<ITrackingRepository>();
        _shipmentRepository = new Mock<IShipmentRepository>();

        _service = new TrackingService(
            _trackingRepository.Object,
            _shipmentRepository.Object);
    }

    [Test]
    public async Task AddTracking_ValidShipment_ReturnsTrue()
    {
        var shipment = new Shipment
        {
            Id = 1,
            TrackingNumber = "TRA-ABC12345",
            Status = ShipmentStatus.Pending
        };

        var dto = new TrackingEntryDto
        {
            TrackingNumber = "TRA-ABC12345",
            Location = "Delhi",
            Status = ShipmentStatus.InTransit
        };

        _shipmentRepository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(shipment);

        _trackingRepository
            .Setup(x => x.AddAsync(It.IsAny<TrackingLog>()))
            .ReturnsAsync((TrackingLog log) => log);

        var result = await _service.AddTrackingAsync(dto);

        Assert.That(result, Is.True);

        _shipmentRepository.Verify(
            x => x.UpdateAsync(shipment),
            Times.Once);

        _trackingRepository.Verify(
            x => x.AddAsync(It.IsAny<TrackingLog>()),
            Times.Once);
    }

    [Test]
    public async Task AddTracking_MissingShipment_ReturnsFalse()
    {
        var dto = new TrackingEntryDto
        {
            TrackingNumber = "TRA-NOTFOUND",
            Location = "Delhi",
            Status = ShipmentStatus.InTransit
        };

        _shipmentRepository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-NOTFOUND"))
            .ReturnsAsync((Shipment?)null);

        var result = await _service.AddTrackingAsync(dto);

        Assert.That(result, Is.False);

        _trackingRepository.Verify(
            x => x.AddAsync(It.IsAny<TrackingLog>()),
            Times.Never);

        _shipmentRepository.Verify(
            x => x.UpdateAsync(It.IsAny<Shipment>()),
            Times.Never);
    }

    [Test]
    public async Task GetTracking_ReturnsTrackingHistory()
    {
        var entries = new List<TrackingLog>
        {
            new TrackingLog
            {
                Id = 1,
                ShipmentId = 10,
                Location = "Delhi",
                Status = "PickedUp",
                Timestamp = DateTime.UtcNow.AddHours(-2)
            },
            new TrackingLog
            {
                Id = 2,
                ShipmentId = 10,
                Location = "Mumbai",
                Status = "InTransit",
                Timestamp = DateTime.UtcNow
            }
        };

        _trackingRepository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(entries);

        var result =
            await _service.GetTrackingAsync("TRA-ABC12345");

        Assert.That(result.Count, Is.EqualTo(2));

        Assert.That(
            result[0].TrackingNumber,
            Is.EqualTo("TRA-ABC12345"));

        Assert.That(
            result[0].Location,
            Is.EqualTo("Delhi"));

        Assert.That(
            result[0].Status,
            Is.EqualTo("PickedUp"));

        Assert.That(
            result[1].Location,
            Is.EqualTo("Mumbai"));
    }

    [Test]
    public async Task GetTracking_NoEntries_ReturnsEmptyList()
    {
        _trackingRepository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-NOTFOUND"))
            .ReturnsAsync(new List<TrackingLog>());

        var result =
            await _service.GetTrackingAsync("TRA-NOTFOUND");

        Assert.That(result, Is.Empty);
    }

    [Test]
    public async Task AddTracking_UpdatesShipmentStatus()
    {
        var shipment = new Shipment
        {
            Id = 1,
            TrackingNumber = "TRA-ABC12345",
            Status = ShipmentStatus.Pending
        };

        var dto = new TrackingEntryDto
        {
            TrackingNumber = "TRA-ABC12345",
            Location = "Mumbai",
            Status = ShipmentStatus.OutForDelivery
        };

        _shipmentRepository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(shipment);

        var result = await _service.AddTrackingAsync(dto);

        Assert.That(result, Is.True);
        Assert.That(
            shipment.Status,
            Is.EqualTo(ShipmentStatus.OutForDelivery));
    }

    [Test]
    public async Task AddTracking_CreatesCorrectTrackingLog()
    {
        var shipment = new Shipment
        {
            Id = 25,
            TrackingNumber = "TRA-ABC12345"
        };

        var dto = new TrackingEntryDto
        {
            TrackingNumber = "TRA-ABC12345",
            Location = "Lucknow",
            Status = ShipmentStatus.Delivered
        };

        _shipmentRepository
            .Setup(x => x.GetByTrackingNumberAsync("TRA-ABC12345"))
            .ReturnsAsync(shipment);

        TrackingLog? createdLog = null;

        _trackingRepository
            .Setup(x => x.AddAsync(It.IsAny<TrackingLog>()))
            .Callback<TrackingLog>(log => createdLog = log)
            .ReturnsAsync((TrackingLog log) => log);

        await _service.AddTrackingAsync(dto);

        Assert.That(createdLog, Is.Not.Null);
        Assert.That(createdLog!.ShipmentId, Is.EqualTo(25));
        Assert.That(createdLog.Location, Is.EqualTo("Lucknow"));
        Assert.That(createdLog.Status, Is.EqualTo("Delivered"));
        Assert.That(
            createdLog.Timestamp,
            Is.Not.EqualTo(default(DateTime)));
    }
}
