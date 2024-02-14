namespace Homies.Controllers
{
    using Homies.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Identity;
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (this.signInManager.IsSignedIn(User))
            {
                return RedirectToAction("All", "Event");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}