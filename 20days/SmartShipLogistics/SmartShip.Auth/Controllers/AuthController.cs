using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartShip.Auth.DTOs.Auth;
using SmartShip.Auth.Services.Interfaces;
using System.Security.Claims;

namespace SmartShip.Auth.Controllers;

/// <summary>
/// Provides endpoints for user registration, authentication, and profile retrieval.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </summary>
    /// <param name="authService">The authentication service used to handle authentication operations.</param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Registers a new user account.
    /// </summary>
    /// <param name="request">The registration details provided by the user.</param>
    /// <returns>A success response if registration is successful; otherwise, a conflict response if the email already exists.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto request)
    {
        var registered = await _authService.RegisterAsync(request);

        if (!registered)
        {
            return Conflict(new
            {
                message = "An account with this email already exists."
            });
        }

        return Ok(new
        {
            message = "Registration successful."
        });
    }

    /// <summary>
    /// Authenticates a user and returns an authentication response.
    /// </summary>
    /// <param name="request">The login credentials provided by the user.</param>
    /// <returns>An authentication response if the credentials are valid; otherwise, an unauthorized response.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto request)
    {
        var response = await _authService.LoginAsync(request);

        if (response is null)
        {
            return Unauthorized(new
            {
                message = "Invalid email or password."
            });
        }

        return Ok(response);
    }

    /// <summary>
    /// Retrieves the profile of the currently authenticated user.
    /// </summary>
    /// <returns>The user's profile if found; otherwise, an unauthorized or not found response.</returns>
    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        var response = await _authService.GetProfileAsync(userId);

        if (response is null)
        {
            return NotFound(new
            {
                message = "User profile not found."
            });
        }

        return Ok(response);
    }
}