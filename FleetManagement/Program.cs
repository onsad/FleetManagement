using FleetManagement.AppDbContext;
using FleetManagement.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FleetManagementDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
    .UseSeeding((dbContext, _) => 
    { 
        dbContext.Set<Vehicle>().AddRange(
            new Vehicle { Brand = "Toyota", Model = "Corolla", Year = 2020, LicensePlate = "ABC123" },
            new Vehicle { Brand = "Honda", Model = "Civic", Year = 2019, LicensePlate = "XYZ789" },
            new Vehicle { Brand = "Ford", Model = "Focus", Year = 2018, LicensePlate = "DEF456" }
        );
        dbContext.SaveChanges();
    })
    );

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
