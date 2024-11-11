using FleetManagement.Data;
using FleetManagement.DTO;
using FleetManagement.Interface;
using FleetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly FleetContext _context;

        public VehicleRepository(FleetContext context)
        {
            _context = context;
        }

        public async Task AddVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year
            };

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.Include(v => v.Locations).ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.Locations)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);
        }
    }
}
