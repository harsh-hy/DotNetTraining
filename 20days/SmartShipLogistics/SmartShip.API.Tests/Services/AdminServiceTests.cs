using Moq;
using NUnit.Framework;
using SmartShip.API.Models;
using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services;

namespace SmartShip.API.Tests.Services;

[TestFixture]
public class AdminServiceTests
{
    private Mock<IShipmentRepository> _repository = null!;
    private AdminService _service = null!;

    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IShipmentRepository>();
        _service = new AdminService(_repository.Object);
    }

    [Test]
    public async Task GetShipmentCount_ReturnsTotalCount()
    {
        _repository
            .Setup(x => x.CountAsync())
            .ReturnsAsync(10);

        var result =
            await _service.GetShipmentCountAsync();

        Assert.That(result, Is.EqualTo(10));

        _repository.Verify(
            x => x.CountAsync(),
            Times.Once);
    }

    [Test]
    public async Task GetUserShipmentCount_ReturnsCorrectCount()
    {
        var shipments = new List<Shipment>
        {
            new Shipment { Id = 1, UserId = 5 },
            new Shipment { Id = 2, UserId = 5 },
            new Shipment { Id = 3, UserId = 5 }
        };

        _repository
            .Setup(x => x.GetByUserAsync(5))
            .ReturnsAsync(shipments);

        var result =
            await _service.GetUserShipmentCountAsync(5);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public async Task GetUserShipmentCount_NoShipments_ReturnsZero()
    {
        _repository
            .Setup(x => x.GetByUserAsync(5))
            .ReturnsAsync(new List<Shipment>());

        var result =
            await _service.GetUserShipmentCountAsync(5);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public async Task GetUserShipmentCount_MultipleShipments_ReturnsCorrectCount()
    {
        var shipments = Enumerable
            .Range(1, 7)
            .Select(id => new Shipment
            {
                Id = id,
                UserId = 10
            })
            .ToList();

        _repository
            .Setup(x => x.GetByUserAsync(10))
            .ReturnsAsync(shipments);

        var result =
            await _service.GetUserShipmentCountAsync(10);

        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public async Task GetUserShipmentCount_PassesCorrectUserId()
    {
        _repository
            .Setup(x => x.GetByUserAsync(42))
            .ReturnsAsync(new List<Shipment>());

        await _service.GetUserShipmentCountAsync(42);

        _repository.Verify(
            x => x.GetByUserAsync(42),
            Times.Once);
    }

    [Test]
    public async Task GetShipmentCount_NoShipments_ReturnsZero()
    {
        _repository
            .Setup(x => x.CountAsync())
            .ReturnsAsync(0);

        var result =
            await _service.GetShipmentCountAsync();

        Assert.That(result, Is.EqualTo(0));
    }
}
