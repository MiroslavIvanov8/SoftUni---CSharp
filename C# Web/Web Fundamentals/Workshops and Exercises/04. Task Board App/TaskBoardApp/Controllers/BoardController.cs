

using Microsoft.AspNetCore.Authorization;

namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TaskBoardApp.Services.Interfaces;
    using TaskBoardApp.Web.ViewModels;

    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }
        public async Task<IActionResult> All()
        { 
            ICollection<BoardViewModel> boards =  await this.boardService.AllAsync();

            return View(boards);
        }
    }
}
