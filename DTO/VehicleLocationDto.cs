﻿using System.ComponentModel.DataAnnotations;

namespace FleetManagement.DTO
{
    public class VehicleLocationDto
    {
        [Required(ErrorMessage = "Vehicle ID is required.")]
        public int VehicleId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
