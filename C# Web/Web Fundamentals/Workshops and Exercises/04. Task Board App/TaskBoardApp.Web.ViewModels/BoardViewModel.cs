namespace TaskBoardApp.Web.ViewModels
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            this.Tasks = new List<TaskViewModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<TaskViewModel> Tasks { get; set; }
    }
}
