using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services.Interfaces
{
    public interface IHomeService
    {
        Task<HomeViewModel> GenerateView();
    }
}
