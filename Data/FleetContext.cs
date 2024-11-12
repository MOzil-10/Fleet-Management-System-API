using FleetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Data
{
    public class FleetContext : DbContext
    {

        public FleetContext(DbContextOptions<FleetContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleLocation> VehicleLocations { get; set; }
        public DbSet<VehicleLocationHistory> VehicleLocationHistories { get; set; }

    }
}
