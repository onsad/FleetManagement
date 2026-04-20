using FleetManagement.AppDbContext;
using FleetManagement.Entity;
using FleetManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Service
{
    public class VehicleService(FleetManagementDbContext context)
    {
        public async Task<Result<List<Vehicle>>> GetAll()
        {
            var vehicles = await context.Vehicles.ToListAsync();
            return Result.Success(vehicles);
        }

        public async Task<Result<Vehicle>> Create(Vehicle vehicle)
        {
            var existingCar = await context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == vehicle.LicensePlate);
            if (existingCar != null)
            {
                return Result.Failure<Vehicle>("A vehicle with the same license plate already exists.");
            }

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            return Result.Success(vehicle);
        }
    }
}
