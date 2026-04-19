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
        }
    }
}
