using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using SmartShip.API.Data;
using SmartShip.API.Middleware;
using SmartShip.API.Repositories;
using SmartShip.API.Repositories.Interfaces;
using SmartShip.API.Services;
using SmartShip.API.Services.Interfaces;

// Configure Serilog before creating the application.
// Logs are written to both the console and a daily rolling log file.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/smartship-.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting SmartShip.API");

    var builder = WebApplication.CreateBuilder(args);

    // Replace the default ASP.NET Core logger with Serilog.
    builder.Host.UseSerilog();

    // ---------------------------------------------------------
    // JWT Configuration
    // ---------------------------------------------------------

    var jwtSettings = builder.Configuration.GetSection("Jwt");

    var jwtKey = jwtSettings["Key"]
        ?? throw new InvalidOperationException(
            "JWT key is not configured.");

    var jwtIssuer = jwtSettings["Issuer"]
        ?? throw new InvalidOperationException(
            "JWT issuer is not configured.");

    var jwtAudience = jwtSettings["Audience"]
        ?? throw new InvalidOperationException(
            "JWT audience is not configured.");

    // ---------------------------------------------------------
    // Database Configuration
    // ---------------------------------------------------------

    builder.Services.AddDbContext<SmartShipDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection")));

    // ---------------------------------------------------------
    // Repository Registration
    // ---------------------------------------------------------

    builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
    builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();

    // ---------------------------------------------------------
    // Service Registration
    // ---------------------------------------------------------

    builder.Services.AddScoped<IShipmentService, ShipmentService>();
    builder.Services.AddScoped<ITrackingService, TrackingService>();
    builder.Services.AddScoped<IAdminService, AdminService>();

    // ---------------------------------------------------------
    // JWT Authentication
    // ---------------------------------------------------------

    builder.Services.AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtKey))
                };
        });

    // ---------------------------------------------------------
    // Controllers
    // ---------------------------------------------------------

    builder.Services.AddControllers();

    // ---------------------------------------------------------
    // Swagger Configuration
    // ---------------------------------------------------------

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        // Add JWT Bearer authentication to Swagger.
        options.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token."
            });

        // Allow Swagger requests to use the JWT token.
        options.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
    });

    // ---------------------------------------------------------
    // Build Application
    // ---------------------------------------------------------

    var app = builder.Build();

    // Log every HTTP request and its response status.
    app.UseSerilogRequestLogging();

    // Global exception handling middleware.
    app.UseMiddleware<ExceptionMiddleware>();

    // Enable Swagger only in development.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Redirect HTTP requests to HTTPS.
    app.UseHttpsRedirection();

    // Enable JWT authentication.
    app.UseAuthentication();

    // Enable authorization.
    app.UseAuthorization();

    // Map controller endpoints.
    app.MapControllers();

    // Start the application.
    app.Run();
}
catch (Exception exception)
{
    // Log any unexpected startup/application-level exception.
    Log.Fatal(
        exception,
        "SmartShip.API terminated unexpectedly.");
}
finally
{
    // Make sure all pending log messages are written before shutdown.
    Log.CloseAndFlush();
}