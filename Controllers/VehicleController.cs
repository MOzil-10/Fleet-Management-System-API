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
            try
            {
                var location = await _vehicleLocationService.GetLatestLocationAsync(vehicleId);

                if (location == null)
                {
                    return NotFound($"Vehicle with ID {vehicleId} not found.");
                }

                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the vehicle location: {ex.Message}");
            }
        }

        [HttpPut("{vehicleId}/location")]
        public async Task<IActionResult> UpdateVehicleLocation(int vehicleId, [FromBody] VehicleLocationDto vehicleLocationDto)
        {
            if (vehicleLocationDto == null)
                return BadRequest("Vehicle location data is required.");

            try
            {
                await _vehicleLocationService.UpdateVehicleLocationAsync(vehicleId, vehicleLocationDto);
                return Ok("Vehicle location updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the vehicle location: {ex.Message}");
            }
        }
    }
}
