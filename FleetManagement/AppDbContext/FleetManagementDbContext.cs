using FleetManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.AppDbContext
{
    public class FleetManagementDbContext : DbContext
    {
        public FleetManagementDbContext(DbContextOptions<FleetManagementDbContext> options)
        : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.LicensePlate)
                .IsUnique();

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Brand = "Škoda",
                    Model = "Octavia",
                    Year = 2020,
                    LicensePlate = "ABC123"
                },
                new Vehicle
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Brand = "Toyota",
                    Model = "Corolla",
                    Year = 2019,
                    LicensePlate = "XYZ789"
                }
            );
        }
    }
}
