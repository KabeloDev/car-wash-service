using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash_Service.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
