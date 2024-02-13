namespace TaskBoardApp.Services.Interfaces
{
    using TaskBoardApp.Web.ViewModels.Board;

    public interface IBoardService
    {
        Task<ICollection<BoardViewModel>> AllAsync();
    }
}
