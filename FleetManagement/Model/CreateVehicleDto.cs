using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Model
{
    public record CreateVehicleDto
    {
        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;
        public int Year { get; set; }

        [Required]
        public string LicensePlate { get; set; } = null!;
    }
}
