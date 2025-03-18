using AddressBook.RepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register other services (if any)

// Build and Run the Application
var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();
