

namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;
    using TaskBoardApp.Web.ViewModels.Task;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel formModel = await this.taskService.CreateFormAsync();
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid || currentUserId == null)
            {
                return RedirectToAction("Create");
            }

            await this.taskService.CreateTaskModelAsync(taskModel, currentUserId);

            return RedirectToAction("All", "Board");
        }
        
        public async Task<IActionResult> Details(string id)
        {
            TaskDetailsViewModel task = await this.taskService.DetailsAsync(id);

            if (task == null)
            {
                ModelState.AddModelError("", "Table Id doesn't exist");
                return RedirectToAction("All", "Board");
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(string id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            TaskViewModel viewModel = await this.taskService.FindViewModelAsync(id);

            if (viewModel == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unexpected error occurred");
                return RedirectToAction("All", "Board");
            }

            if (currentUserId != viewModel.Owner)
            {
                return Unauthorized();
            }

            TaskFormModel formModel = await this.taskService.FindFormModelAsync(viewModel);
            
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TaskFormModel formModel)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            TaskViewModel viewModel = await this.taskService.FindViewModelAsync(id);

            if (viewModel == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unexpected error occurred");

                return View(formModel);
            }

            if (currentUserId != viewModel.Owner)
            {
                return Unauthorized();
            }

            await this.taskService.EditTaskModelAsync(id, formModel);

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(string id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            TaskViewModel viewModel = await this.taskService.FindViewModelAsync(id);

            if (viewModel == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unexpected error occurred");
                return RedirectToAction("All", "Board");
            }

            if (currentUserId != viewModel.Owner)
            {
                return Unauthorized();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel viewModel)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            viewModel = await this.taskService.FindViewModelAsync(viewModel.Id);

            if (viewModel == null)
            {
                ModelState.AddModelError("", "Unexpected error occurred");
                return RedirectToAction("All", "Board");
            }

            if (currentUserId != viewModel.Owner)
            {
                return Unauthorized();
            }

            bool result = await this.taskService.DeleteTaskAsync(viewModel);
            return RedirectToAction("All", "Board");
        }
    }
}
