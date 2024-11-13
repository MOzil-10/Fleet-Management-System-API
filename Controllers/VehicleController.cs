using FleetManagement.DTO;
using FleetManagement.Model;
using FleetManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Adds a new vehicle to the system.
        /// </summary>
        /// <param name="vehicleDto">The data transfer object containing the vehicle information.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            await _vehicleService.AddVehicleAsync(vehicleDto);
            return Ok("Vehicle added successfully.");
        }

        /// <summary>
        /// Adds a new vehicle location to the system.
        /// </summary>
        /// <param name="vehicleLocationDto">The data transfer object containing the vehicle location information.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost("location")]
        public async Task<IActionResult> AddVehicleLocation([FromBody] VehicleLocationDto vehicleLocationDto)
        {
            await _vehicleLocationService.AddVehicleLocationAsync(vehicleLocationDto);
            return Ok("Vehicle location added successfully.");
        }

        /// <summary>
        /// Retrieves the latest location of a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing the latest vehicle location.</returns>
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

        /// <summary>
        /// Updates the location of an existing vehicle.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle.</param>
        /// <param name="vehicleLocationDto">The data transfer object containing the updated vehicle location information.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPut("{vehicleId}/location")]
        public async Task<IActionResult> UpdateVehicleLocation(int vehicleId, [FromBody] VehicleLocationDto vehicleLocationDto)
        {
            if (vehicleLocationDto == null)
                return BadRequest("Vehicle location data is required.");

            try
            {
                await _vehicleLocationService.UpdateVehicleLocationAsync(vehicleId, vehicleLocationDto);
                return Ok("Vehicle location updated and history recorded successfully.");
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

        /// <summary>
        /// Retrieves the location history of a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle.</param>
        /// <returns>An <see cref="ActionResult{T}"/> containing a list of vehicle location history.</returns>
        [HttpGet("{vehicleId}/location/history")]
        public async Task<ActionResult<IEnumerable<VehicleLocationHistoryDto>>> GetLocationHistoryByVehicleId(int vehicleId)
        {
            try
            {
                var locationHistoryDtos = await _vehicleLocationService.GetLocationHistoryByVehicleIdAsync(vehicleId);

                if (locationHistoryDtos == null || locationHistoryDtos.Count == 0)
                {
                    return NotFound($"No location history found for vehicle with ID {vehicleId}.");
                }

                return Ok(locationHistoryDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the location history: {ex.Message}");
            }
        }
    }
}
