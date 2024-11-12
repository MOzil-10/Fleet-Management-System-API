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

        public async Task<List<VehicleLocationHistoryDto>> GetLocationHistoryByVehicleIdAsync(int vehicleId)
        {
            var locationHistory = await _vehicleLocationRepository.GetLocationHistoryByVehicleIdAsync(vehicleId);

            if (locationHistory == null || locationHistory.Count == 0)
            {
                return null;
            }

            var locationHistoryDtos = locationHistory.Select(v => new VehicleLocationHistoryDto
            {
                VehicleId = v.VehicleId,
                Latitude = Math.Round(v.Latitude, 5),
                Longitude = Math.Round(v.Longitude, 5),
                Timestamp = v.Timestamp
            }).ToList();

            return locationHistoryDtos;
        }

    }
}
