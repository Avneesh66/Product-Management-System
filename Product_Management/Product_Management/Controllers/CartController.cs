using Microsoft.AspNetCore.Mvc;
using Product_Management.Repositories.Abstract;

namespace Product_Management.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public IActionResult GetUserCart()
        {
            return View();
        }
    }
}
