namespace TaskBoardApp.Services.Interfaces
{
    using TaskBoardApp.Web.ViewModels;
    public interface IBoardService
    {
        Task<ICollection<BoardViewModel>> AllAsync();
    }
}
