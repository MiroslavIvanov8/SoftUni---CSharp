
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskBoardApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using TaskBoardApp.Models;

    public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = GenerateBoards();

            builder.HasData(boards);

        }

        private static ICollection<Board> GenerateBoards()
        {
            ICollection<Board> boards = new List<Board>();

            Board currentBoard = new Board();
            currentBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            boards.Add(currentBoard);

            currentBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            boards.Add(currentBoard);

            currentBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            boards.Add(currentBoard);

            return boards;
        }
    }
}
