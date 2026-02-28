using Microsoft.EntityFrameworkCore;
using TodoAppApi.Data;
using TodoAppApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI
builder.Services.AddOpenApi();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var jwtKey = "THIS_IS_A_SUPER_SECRET_KEY_12345"; // change later in production

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


// 🔹 GET ALL
app.MapGet("/todos", async (AppDbContext db) =>
{
    return await db.TodoItems.ToListAsync();
})
.RequireAuthorization();


// 🔹 GET BY ID
app.MapGet("/todos/{id}", async (AppDbContext db, int id) =>
{
    var todo = await db.TodoItems.FindAsync(id);

    return todo is null ? Results.NotFound() : Results.Ok(todo);
})
.RequireAuthorization();


// 🔹 CREATE
app.MapPost("/todos", async (AppDbContext db, TodoItem todo) =>
{
    db.TodoItems.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
})
.RequireAuthorization();


// 🔹 UPDATE
app.MapPut("/todos/{id}", async (AppDbContext db, int id, TodoItem updatedTodo) =>
{
    var todo = await db.TodoItems.FindAsync(id);

    if (todo is null)
        return Results.NotFound();

    todo.Title = updatedTodo.Title;
    todo.IsCompleted = updatedTodo.IsCompleted;

    await db.SaveChangesAsync();

    return Results.NoContent();
})
.RequireAuthorization();


// 🔹 DELETE
app.MapDelete("/todos/{id}", async (AppDbContext db, int id) =>
{
    var todo = await db.TodoItems.FindAsync(id);

    if (todo is null)
        return Results.NotFound();

    db.TodoItems.Remove(todo);
    await db.SaveChangesAsync();

    return Results.NoContent();
})
.RequireAuthorization();

app.Run();