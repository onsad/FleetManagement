using FleetManagement.AppDbContext;
using FleetManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Service
{
    public class VehicleService(FleetManagementDbContext context)
    {
        public async Task<List<Vehicle>> GetAll()
        {
            return await context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            return vehicle;
        }
    }
}
