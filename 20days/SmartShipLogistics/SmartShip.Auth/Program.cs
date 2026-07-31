using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SmartShip.Auth.Data;
using SmartShip.Auth.Helpers;
using SmartShip.Auth.Repositories;
using SmartShip.Auth.Repositories.Interfaces;
using SmartShip.Auth.Services;
using SmartShip.Auth.Services.Interfaces;
using SmartShip.Auth.Middleware;

// Configure Serilog before creating the application.
// Logs are written to the console and to a daily rolling log file.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/smartship-auth-.log",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting SmartShip.Auth");

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

    builder.Services.AddDbContext<AuthDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection")));

    // ---------------------------------------------------------
    // Repository Registration
    // ---------------------------------------------------------

    builder.Services.AddScoped<IUserRepository, UserRepository>();

    // ---------------------------------------------------------
    // Service Registration
    // ---------------------------------------------------------

    builder.Services.AddScoped<IAuthService, AuthService>();

    // ---------------------------------------------------------
    // Helper Registration
    // ---------------------------------------------------------

    builder.Services.AddScoped<JwtHelper>();

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
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header
            });

        // Allow Swagger requests to use the JWT token.
        options.AddSecurityRequirement(
            new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference =
                            new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type =
                                    Microsoft.OpenApi.Models.ReferenceType
                                        .SecurityScheme,
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

    // Enable Swagger only in development.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Redirect HTTP requests to HTTPS.
    app.UseHttpsRedirection();

    // Global exception handling middleware.
    app.UseMiddleware<ExceptionMiddleware>();

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
        "SmartShip.Auth terminated unexpectedly.");
}
finally
{
    // Make sure all pending log messages are written before shutdown.
    Log.CloseAndFlush();
}