using FleetManagement.DTO;
using FleetManagement.Interface;
using FleetManagement.Model;

namespace FleetManagement.Services
{
    public class VehicleLocationService
    {
        private readonly IVehicleLocationRepository _vehicleLocationRepository;

        public VehicleLocationService(IVehicleLocationRepository vehicleLocationRepository)
        {
            _vehicleLocationRepository = vehicleLocationRepository;
        }

        public async Task AddVehicleLocationAsync(VehicleLocationDto vehicleLocationDto)
        {
            await _vehicleLocationRepository.AddVehicleLocationAsync(vehicleLocationDto);
        }

        public async Task<VehicleLocation> GetLatestLocationAsync(int vehicleId)
        {
            return await _vehicleLocationRepository.GetLatestLocationByVehicleIdAsync(vehicleId);
        }

        public async Task UpdateVehicleLocationAsync(int vehicleId, VehicleLocationDto vehicleLocationDto)
        {
            await _vehicleLocationRepository.UpdateVehicleLocationAsync(vehicleId, vehicleLocationDto);
        }
    }
}
