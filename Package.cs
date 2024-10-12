using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash_Service.Models
{
    public class Package
    {
        public int Id { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public double Price { get; set; }
        public string VehicleType { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }

}
