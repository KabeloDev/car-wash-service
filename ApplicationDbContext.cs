using CarWash_Service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWash_Service.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Service> Services { get; set; }
		public DbSet<Package> Packages { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Contact> Contacts { get; set; }
	}
}
