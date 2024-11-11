using FleetManagement.Data;
using FleetManagement.DTO;
using FleetManagement.Interface;
using FleetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Repository
{
    public class VehicleLocationRepository : IVehicleLocationRepository
    {
        private readonly FleetContext _context;

        public VehicleLocationRepository(FleetContext context)
        {
            _context = context;
        }

        public async Task AddVehicleLocationAsync(VehicleLocationDto vehicleLocationDto)
        {
            var location = new VehicleLocation
            {
                VehicleId = vehicleLocationDto.VehicleId ,
                Latitude = vehicleLocationDto.Latitude,
                Longitude = vehicleLocationDto.Longitude,
                Timestamp = vehicleLocationDto.Timestamp
            };

            await _context.VehicleLocations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task<VehicleLocation> GetLatestLocationByVehicleIdAsync(int vehicleId)
        {
            return await _context.VehicleLocations
                .Where(vl => vl.VehicleId == vehicleId)
                .OrderByDescending(vl => vl.Timestamp)
                .Include(vl => vl.Vehicle)
                .FirstOrDefaultAsync();
        }
    }
}
