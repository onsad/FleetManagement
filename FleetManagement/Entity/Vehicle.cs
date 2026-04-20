namespace FleetManagement.Entity
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = null!;

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
