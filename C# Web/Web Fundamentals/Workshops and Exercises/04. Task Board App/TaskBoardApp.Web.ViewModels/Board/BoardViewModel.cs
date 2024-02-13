using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Web.ViewModels.Board
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<TaskViewModel> Tasks { get; set; }
    }
}
