
using CarWash_Service.Data;
using CarWash_Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarWash_Service.Repository
{
    public class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public PackageRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }



        public async void AddService(int serviceId, int quantity)
        {
            var userId = GetUserId();
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged in");
                var service = _context.Services.Find(serviceId);
                var package = await _context.Packages.FirstOrDefaultAsync(x => x.UserId == userId);
               
                    package = new Package
                    {
                        UserId = userId,
                        Price = service.Price,
                        VehicleType = service.VehicleType,
                        Quantity = quantity
                    };
                    _context.Packages.Add(package);
                
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
            }

        }

        public void RemoveService(int packageId)
        {
            var package = _context.Packages.Find(packageId);
            _context.Packages.Remove(package);
            _context.SaveChanges();
        }

        public void RemoveAllServicesByUser(string userId)
        {
            userId = GetUserId();
            var userPackages = _context.Packages.Where(p => p.UserId == userId).ToList();

            if (userPackages.Any())
            {
                _context.Packages.RemoveRange(userPackages);
                _context.SaveChanges();
            }
        }


        private string GetUserId()
        {
            var principal = _contextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);

            return userId;
        }

        //public async Task<int> GetCartItemCount(string userId = "")
        //{
        //    if (!string.IsNullOrEmpty(userId))
        //    {
        //        userId = GetUserId();
        //    }

        //    var data = await (from cart in _context.Carts
        //                      join cartDetail in _context.CartDetails
        //                      on cart.Id equals cartDetail.CartId
        //                      select new { cartDetail.Id }).ToListAsync();

        //    return data.Count;
        //}
    }
}
