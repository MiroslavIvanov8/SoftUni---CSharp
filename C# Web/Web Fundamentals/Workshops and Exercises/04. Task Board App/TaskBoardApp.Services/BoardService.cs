using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using TaskBoardApp.Data;
    using TaskBoardApp.Services.Interfaces;
    using TaskBoardApp.Web.ViewModels.Board;
    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext dbContext;

        public BoardService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public async Task<ICollection<BoardViewModel>> AllAsync()
        {
            ICollection<BoardViewModel> boards = await this.dbContext
                .Boards
                .Select(b => new BoardViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                        .Select(t => new TaskViewModel()
                        {
                            Id =t.Id.ToString(),
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        }).ToList()
                }).ToListAsync();

            return boards;
        }
    }
}
