namespace FleetManagement.Entity
{
    public class Trip
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public decimal DistanceKm { get; set; }
    }
}
