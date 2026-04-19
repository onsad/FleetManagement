using FleetManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.AppDbContext
{
    public static class DbSeed
    {
        public static void SeedVehicles(DbContext context)
        {
            var firstVehicle = context.Set<Vehicle>().FirstOrDefault(v => v.LicensePlate == "1A11234");
            if (firstVehicle == null)
            {
                context.Set<Vehicle>().Add(new Vehicle { Brand = "Škoda", Model = "Octavia", Year = 2020, LicensePlate = "1A11234" });
                context.SaveChanges();
            }
        }
    }
}
