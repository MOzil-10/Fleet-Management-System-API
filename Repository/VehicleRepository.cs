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

        /// <summary>
        /// Adds a new vehicle to the database.
        /// </summary>
        /// <param name="vehicleDto">The data transfer object containing vehicle information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Retrieves all vehicles from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the list of vehicles.</returns>
        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.Include(v => v.Locations).ToListAsync();
        }

        /// <summary>
        /// Retrieves a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the vehicle.</returns>
        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return await _context.Vehicles
                .Include(v => v.Locations)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);
        }
    }
}
