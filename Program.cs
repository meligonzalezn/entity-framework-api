using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api_ef;
using Task = minimal_api_ef.Models.Task;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebDatabase")));
var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.MapGet("/", () => "Hello World!");

// Code to create database
app.MapGet("/dbconnection", async ([FromServices] TaskContext dbContext) =>
{
    try
    {
        // Ensure database is created
        await dbContext.Database.EnsureCreatedAsync();
        return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while creating the database.");
        return Results.Problem("An error occurred while creating the database.");
    }
});
app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks);
});
app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] Task task)=>
{
    task.TaskId = Guid.NewGuid();
    await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();   
});
app.Run();