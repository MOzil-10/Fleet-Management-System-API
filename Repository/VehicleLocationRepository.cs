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
                VehicleId = vehicleLocationDto.VehicleId,
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

        public async Task UpdateVehicleLocationAsync(int vehicleId, VehicleLocationDto vehicleLocationDto)
        {
            var existingLocation = await _context.VehicleLocations
                .Where(vl => vl.VehicleId == vehicleId)
                .OrderByDescending(vl => vl.Timestamp)
                .FirstOrDefaultAsync();

            if (existingLocation == null)
                throw new KeyNotFoundException($"Location for vehicle ID {vehicleId} not found.");

            existingLocation.Latitude = vehicleLocationDto.Latitude;
            existingLocation.Longitude = vehicleLocationDto.Longitude;
            existingLocation.Timestamp = vehicleLocationDto.Timestamp;

            _context.VehicleLocations.Update(existingLocation);

            var locationHistory = new VehicleLocationHistory
            {
                VehicleId = vehicleId,
                Latitude = vehicleLocationDto.Latitude,
                Longitude = vehicleLocationDto.Longitude,
                Timestamp = vehicleLocationDto.Timestamp
            };

            await _context.VehicleLocationHistories.AddAsync(locationHistory);
            await _context.SaveChangesAsync();
        }

        public async Task AddLocationHistoryAsync(VehicleLocationHistoryDto vehicleLocationHistoryDto)
        {
            var locationHistory = new VehicleLocationHistory
            {
                VehicleId = vehicleLocationHistoryDto.VehicleId,
                Latitude = vehicleLocationHistoryDto.Latitude,
                Longitude = vehicleLocationHistoryDto.Longitude,
                Timestamp = vehicleLocationHistoryDto.Timestamp
            };

            await _context.VehicleLocationHistories.AddAsync(locationHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VehicleLocationHistory>> GetLocationHistoryByVehicleIdAsync(int vehicleId)
        {
            return await _context.VehicleLocationHistories
                .Where(v => v.VehicleId == vehicleId)
                .OrderByDescending(v => v.Timestamp)
                .ToListAsync();
        }
    }
}
