namespace CarWash_Service.Models
{
    public class Service
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string VehicleType { get; set; }
        public int? PackageId { get; set; } // Enable navigation back to the package if needed
        public Package? Package { get; set; }
    }

}
