using Microsoft.EntityFrameworkCore;
using TodoAppApi.Data;
using TodoAppApi.Models;

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// 🔹 GET ALL
app.MapGet("/todos", async (AppDbContext db) =>
{
    return await db.TodoItems.ToListAsync();
});


// 🔹 GET BY ID
app.MapGet("/todos/{id}", async (AppDbContext db, int id) =>
{
    var todo = await db.TodoItems.FindAsync(id);

    return todo is null ? Results.NotFound() : Results.Ok(todo);
});


// 🔹 CREATE
app.MapPost("/todos", async (AppDbContext db, TodoItem todo) =>
{
    db.TodoItems.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});


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
});


// 🔹 DELETE
app.MapDelete("/todos/{id}", async (AppDbContext db, int id) =>
{
    var todo = await db.TodoItems.FindAsync(id);

    if (todo is null)
        return Results.NotFound();

    db.TodoItems.Remove(todo);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();