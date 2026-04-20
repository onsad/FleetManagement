namespace FleetManagement.Entity
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
