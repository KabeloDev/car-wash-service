using Microsoft.AspNetCore.Mvc;

namespace CarWash_Service.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
