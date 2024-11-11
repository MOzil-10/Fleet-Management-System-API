using FleetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Data
{
    public class FleetContext : DbContext
    {

        public FleetContext(DbContextOptions<FleetContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleLocation> VehicleLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleLocation>()
                .Property(v => v.Latitude)
                .HasPrecision(10, 7);

            modelBuilder.Entity<VehicleLocation>()
                .Property(v => v.Longitude)
                .HasPrecision(10, 7);

            base.OnModelCreating(modelBuilder);
        }

    }
}
