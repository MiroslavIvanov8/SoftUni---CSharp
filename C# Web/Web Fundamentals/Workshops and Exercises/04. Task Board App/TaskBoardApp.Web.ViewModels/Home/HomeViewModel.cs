namespace TaskBoardApp.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.BoardsWithTaskCount = new List<HomeBoardModel>();
        }
        public int AllTaskCount { get; set; }
        public List<HomeBoardModel>  BoardsWithTaskCount { get; set; }
        public int UserTaskCount { get; set; }
    }
}
