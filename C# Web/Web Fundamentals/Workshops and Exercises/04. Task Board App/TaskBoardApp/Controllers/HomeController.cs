using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Interfaces;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using TaskBoardApp.Web.ViewModels;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly TaskBoardDbContext dbContext;

        public HomeController(IHomeService homeService, TaskBoardDbContext dbContext)
        {
            this.homeService = homeService;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult>Index()
        {
            HomeViewModel viewModel= await this.homeService.GenerateView();

            if (User.Identity.IsAuthenticated)
            {
                string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                int userTaskCount = this.dbContext.Tasks.Count(t => t.OwnerId == currentUserId);

                viewModel.UserTaskCount = userTaskCount;
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
