using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Management.Models.DTO;
using Product_Management.Repositories.Abstract;

namespace Product_Management.Controllers
{
    public class UserAuthentication : Controller
    {
        private readonly IUserAuthenticationService _service;

        public UserAuthentication(IUserAuthenticationService service)
        {
            _service = service;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result= await _service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =await _service.loginAsync(model);
            if (result.StatusCode==1)
            {
                return RedirectToAction("Display","Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
           await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> reg()
        {
            var model = new RegistrationModel
            {
                UserName = "admin1",
                Name = "Roky",
                Email = "roky@gmail.com",
                Password = "Admin@123"

            };

            model.Role = "admin";
            var result = await _service.RegistrationAsync(model);
            return Ok(result);
        }
    }
}
