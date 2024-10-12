using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash_Service.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
