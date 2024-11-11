using FleetManagement.DTO;
using FleetManagement.Model;

namespace FleetManagement.Interface
{
    public interface IVehicleRepository
    {
        Task AddVehicleAsync(VehicleDto vehicleDto);
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
        Task<List<Vehicle>> GetAllVehiclesAsync();
    }
}
