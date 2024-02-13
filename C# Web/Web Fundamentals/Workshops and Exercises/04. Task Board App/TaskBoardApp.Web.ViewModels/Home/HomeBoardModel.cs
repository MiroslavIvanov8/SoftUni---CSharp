using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TaskBoardApp.Web.ViewModels.Home
{
    public class HomeBoardModel
    {

        public string BoardName { get; set; } = null!;
        public int TaskCount { get; set; }
    }
}
