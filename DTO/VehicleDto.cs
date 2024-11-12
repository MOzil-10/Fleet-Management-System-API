using FleetManagement.Model;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.DTO
{
    public class VehicleDto
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }
    }
}
