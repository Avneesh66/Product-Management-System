using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Product_Management.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
    }
}
