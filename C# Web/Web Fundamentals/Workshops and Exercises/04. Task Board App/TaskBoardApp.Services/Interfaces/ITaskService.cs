namespace TaskBoardApp.Services.Interfaces
{
    using TaskBoardApp.Web.ViewModels.Task;
    using Task = TaskBoardApp.Models.Task;
    public interface ITaskService
    {
        Task<TaskFormModel> CreateFormAsync();

        Task<TaskViewModel> CreateTaskModelAsync(TaskFormModel taskModel, string userId);
        Task<TaskDetailsViewModel> DetailsAsync(string id);

        Task<TaskViewModel> FindViewModelAsync(string id);
        Task<TaskFormModel> FindFormModelAsync(TaskViewModel viewModel);

        Task<bool> EditTaskModelAsync(string id, TaskFormModel formModel);

        Task<bool> DeleteTaskAsync(TaskViewModel viewModel);
    }
}
