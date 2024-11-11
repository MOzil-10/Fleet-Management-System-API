namespace FleetManagement.DTO
{
    public class VehicleLocationDto
    {
        public int VehicleId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
