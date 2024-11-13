using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.DTO
{
    public class VehicleLocationHistoryDto
    {
        [Required(ErrorMessage = "Vehicle ID is required.")]
        public int VehicleId { get; set; }

        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
