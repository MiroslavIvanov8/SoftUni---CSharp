using MVCIntroDemo.ViewModels;

namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Greetings = "Hello World from ViewBag";
            ViewData["Message"] = "Hello World from ViewData";
            return View();
        }

        public IActionResult Numbers(int count = 50)
        {
            ViewBag.Count = count;
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewBag.Count = -1;
            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = -1)
        {
            ViewBag.Count = count;
            return View(count);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "This is an ASP.Net Core MVC App.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
