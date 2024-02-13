namespace TaskBoardApp.Services
{
    using Interfaces;
    using Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;
    using Data;

    public class HomeService : IHomeService
    {
        private readonly TaskBoardDbContext dbContext;

        public HomeService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<HomeViewModel> GenerateView()
        {
            var taskBoards = await this.dbContext
                .Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

            var taskCount = new List<HomeBoardModel>();
            foreach (var boardName in taskBoards)
            {
                int tasksInBoard = this.dbContext.Tasks.Count(t => t.Board.Name == boardName);
                taskCount.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TaskCount = tasksInBoard
                });
            }

            HomeViewModel viewModel = new HomeViewModel()
            {
                AllTaskCount = this.dbContext.Tasks.Count(),
                BoardsWithTaskCount = taskCount
            };

            return viewModel;
        }
    }
}
