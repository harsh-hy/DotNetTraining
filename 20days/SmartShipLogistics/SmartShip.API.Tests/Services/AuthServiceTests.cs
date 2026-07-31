using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SmartShip.Auth.Configurations;
using SmartShip.Auth.DTOs.Auth;
using SmartShip.Auth.Helpers;
using SmartShip.Auth.Models;
using SmartShip.Auth.Repositories.Interfaces;
using SmartShip.Auth.Services;

namespace SmartShip.API.Tests.Services;

[TestFixture]
public class AuthServiceTests
{
    private Mock<IUserRepository> _userRepository = null!;
    private AuthService _service = null!;

    [SetUp]
    public void Setup()
    {
        _userRepository = new Mock<IUserRepository>();

        var configuration = new ConfigurationManager();

        configuration["Jwt:Key"] =
            "this-is-a-test-secret-key-that-is-long-enough";
        configuration["Jwt:Issuer"] = "SmartShip";
        configuration["Jwt:Audience"] = "SmartShipUsers";
        configuration["Jwt:ExpiryMinutes"] = "60";

        var jwtHelper = new JwtHelper(configuration);

        _service = new AuthService(
            _userRepository.Object,
            jwtHelper);
    }

    [Test]
    public async Task Register_ValidCustomer_ReturnsTrue()
    {
        var request = new RegisterDto
        {
            FullName = "John Doe",
            Email = "john@example.com",
            Password = "password123"
        };

        _userRepository
            .Setup(x => x.EmailExistsAsync("john@example.com"))
            .ReturnsAsync(false);

        var result = await _service.RegisterAsync(request);

        Assert.That(result, Is.True);

        _userRepository.Verify(
            x => x.AddAsync(It.Is<User>(u =>
                u.FullName == "John Doe" &&
                u.Email == "john@example.com" &&
                u.Role == Roles.Customer &&
                !string.IsNullOrEmpty(u.PasswordHash))),
            Times.Once);

        _userRepository.Verify(
            x => x.SaveChangesAsync(),
            Times.Once);
    }

    [Test]
    public async Task Register_DuplicateEmail_ReturnsFalse()
    {
        var request = new RegisterDto
        {
            FullName = "John Doe",
            Email = "john@example.com",
            Password = "password123"
        };

        _userRepository
            .Setup(x => x.EmailExistsAsync("john@example.com"))
            .ReturnsAsync(true);

        var result = await _service.RegisterAsync(request);

        Assert.That(result, Is.False);

        _userRepository.Verify(
            x => x.AddAsync(It.IsAny<User>()),
            Times.Never);

        _userRepository.Verify(
            x => x.SaveChangesAsync(),
            Times.Never);
    }

    [Test]
    public async Task Register_EmailIsNormalized()
    {
        var request = new RegisterDto
        {
            FullName = "  John Doe  ",
            Email = "  JOHN@Example.COM  ",
            Password = "password123"
        };

        _userRepository
            .Setup(x => x.EmailExistsAsync("john@example.com"))
            .ReturnsAsync(false);

        await _service.RegisterAsync(request);

        _userRepository.Verify(
            x => x.AddAsync(It.Is<User>(u =>
                u.Email == "john@example.com" &&
                u.FullName == "John Doe")),
            Times.Once);
    }

    [Test]
    public async Task Login_ValidCredentials_ReturnsAuthResponse()
    {
        const string password = "password123";

        var user = new User
        {
            Id = 1,
            FullName = "John Doe",
            Email = "john@example.com",
            PasswordHash = PasswordHelper.Hash(password),
            Role = Roles.Customer
        };

        _userRepository
            .Setup(x => x.GetByEmailAsync("john@example.com"))
            .ReturnsAsync(user);

        var request = new LoginDto
        {
            Email = "john@example.com",
            Password = password
        };

        var result = await _service.LoginAsync(request);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.UserId, Is.EqualTo(1));
        Assert.That(result.FullName, Is.EqualTo("John Doe"));
        Assert.That(result.Email, Is.EqualTo("john@example.com"));
        Assert.That(result.Role, Is.EqualTo(Roles.Customer));
        Assert.That(result.Token, Is.Not.Empty);
    }

    [Test]
    public async Task Login_InvalidPassword_ReturnsNull()
    {
        var user = new User
        {
            Id = 1,
            FullName = "John Doe",
            Email = "john@example.com",
            PasswordHash = PasswordHelper.Hash("correctPassword"),
            Role = Roles.Customer
        };

        _userRepository
            .Setup(x => x.GetByEmailAsync("john@example.com"))
            .ReturnsAsync(user);

        var request = new LoginDto
        {
            Email = "john@example.com",
            Password = "wrongPassword"
        };

        var result = await _service.LoginAsync(request);

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetProfile_MissingUser_ReturnsNull()
    {
        _userRepository
            .Setup(x => x.GetByIdAsync(999))
            .ReturnsAsync((User?)null);

        var result = await _service.GetProfileAsync(999);

        Assert.That(result, Is.Null);

        _userRepository.Verify(
            x => x.GetByIdAsync(999),
            Times.Once);
    }
}
