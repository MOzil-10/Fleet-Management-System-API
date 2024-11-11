using FleetManagement.DTO;
using FleetManagement.Model;
using FleetManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;
        private readonly VehicleLocationService _vehicleLocationService;

        public VehicleController(VehicleService vehicleService, VehicleLocationService vehicleLocationService)
        {
            _vehicleService = vehicleService;
            _vehicleLocationService = vehicleLocationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            await _vehicleService.AddVehicleAsync(vehicleDto);
            return Ok("Vehicle added successfully.");
        }

        [HttpPost("location")]
        public async Task<IActionResult> AddVehicleLocation([FromBody] VehicleLocationDto vehicleLocationDto)
        {
            await _vehicleLocationService.AddVehicleLocationAsync(vehicleLocationDto);
            return Ok("Vehicle location added successfully.");
        }

        [HttpGet("{vehicleId}/location")]
        public async Task<ActionResult<VehicleLocation>> GetLatestLocation(int vehicleId)
        {
            var location = await _vehicleLocationService.GetLatestLocationAsync(vehicleId);

            if (location == null)
            {
                return NotFound($"Vehicle with ID {vehicleId} not found.");
            }

            return Ok(location);
        }
    }
}
