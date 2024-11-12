using FleetManagement.DTO;
using FleetManagement.Model;

namespace FleetManagement.Interface
{
    public interface IVehicleLocationRepository
    {
        Task AddVehicleLocationAsync(VehicleLocationDto vehicleLocationDto);
        Task<VehicleLocation> GetLatestLocationByVehicleIdAsync(int vehicleId);
        Task UpdateVehicleLocationAsync(int vehicleId, VehicleLocationDto vehicleLocationDto);
        Task AddLocationHistoryAsync(VehicleLocationHistoryDto vehicleLocationHistoryDto);
        Task<List<VehicleLocationHistory>> GetLocationHistoryByVehicleIdAsync(int vehicleId);
    }
}
