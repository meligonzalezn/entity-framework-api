using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api_ef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TasksDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// code to create database
app.MapGet("/dbconnection", async ([FromServices] TaskContext dbContext) =>
{
    // Ensure database is created 
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});
app.Run();
