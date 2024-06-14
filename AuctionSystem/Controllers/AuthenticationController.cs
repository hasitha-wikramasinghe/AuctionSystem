using AuctionSystem.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // TODO:: implement sign in feature with JWT
        public IActionResult SignIn(SignInDto signInDto)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
