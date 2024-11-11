using FleetManagement.DTO;
using FleetManagement.Interface;
using FleetManagement.Model;

namespace FleetManagement.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task AddVehicleAsync(VehicleDto vehicleDto)
        {
            await _vehicleRepository.AddVehicleAsync(vehicleDto);
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

    }
}
