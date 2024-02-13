using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskBoardApp.Services
{
    using TaskBoardApp.Data;
    using TaskBoardApp.Web.ViewModels.Task;

    using TaskBoardApp.Services.Interfaces;
    using Task = TaskBoardApp.Models.Task;
    using static Common.EntityValidationConstants.CreatedOn;
    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext dbContext;

        public TaskService(TaskBoardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TaskFormModel> CreateFormAsync()
        {
            TaskFormModel taskFormModel = new TaskFormModel
            {
                Boards = GetBoards()
            };

            return taskFormModel;
        }


        public async Task<TaskViewModel> CreateTaskModelAsync(TaskFormModel taskModel, string userId)
        {
            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = userId
            };
            
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();

            TaskViewModel viewModel = new TaskViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                Owner = task.OwnerId,
            };

            return viewModel;
        }

        public async Task<TaskDetailsViewModel> DetailsAsync(string id)
        {
            TaskDetailsViewModel? task = await this.dbContext
                .Tasks
                .Where(t => t.Id.ToString() == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString(CreatedOnForm),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                }).FirstOrDefaultAsync();

            return task;
        }

        public async Task<TaskViewModel> FindViewModelAsync(string id)
        {
            TaskViewModel? viewModel = await this.dbContext
                .Tasks
                .Where(t => t.Id.ToString() == id)
                .Select(t => new TaskViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.OwnerId
                }).FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<TaskFormModel> FindFormModelAsync(TaskViewModel viewModel)
        {
            Task? task = await this.dbContext.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == viewModel.Id);

            TaskFormModel formModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return formModel;
        }

        public async Task<bool> EditTaskModelAsync(string id, TaskFormModel formModel)
        {
            Task? task = await this.dbContext.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == id);

            if (task == null)
            {
                return false;
            }

            task.Title = formModel.Title;
            task.Description = formModel.Description;
            task.BoardId = formModel.BoardId;

            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskAsync(TaskViewModel viewModel)
        {
            Task? task = await this.dbContext.Tasks.FirstOrDefaultAsync(t => t.Id.ToString() == viewModel.Id);

            if (task == null)
            {
                return false;
            }

            this.dbContext.Tasks.Remove(task);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        private List<TaskBoardModel> GetBoards()
        {
            return this.dbContext.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }

    }

}