namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("All", "Book");
            }

            return View();
        }
    }
}