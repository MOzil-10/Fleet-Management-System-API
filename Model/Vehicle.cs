using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FleetManagement.Model
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }

        [JsonIgnore]
        public ICollection<VehicleLocation> Locations { get; set; } = new List<VehicleLocation>();
    }
}
