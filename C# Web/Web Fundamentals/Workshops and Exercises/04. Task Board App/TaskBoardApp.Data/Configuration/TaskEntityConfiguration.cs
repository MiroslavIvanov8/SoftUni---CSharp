
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskBoardApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using TaskBoardApp.Models;
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private static ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Title = "Improve CSS",
                    Description = "Implement better styling for the pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "89f5eb8c-e95a-47c1-8990-f4eae71cbdbd",
                    BoardId = 1
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Android Client App",
                    Description = "Create Android Client App for the TaskBoard RESTful Api",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    OwnerId = "89f5eb8c-e95a-47c1-8990-f4eae71cbdbd",
                    BoardId = 1
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Desktop Client App",
                    Description = "Create Desktop Client App for the TaskBoard RESTful Api",
                    CreatedOn = DateTime.UtcNow.AddMonths(-1),
                    OwnerId = "f38b3838-25da-49a2-9b80-9dad1bcb50f7",
                    BoardId = 2
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.UtcNow.AddYears(-1),
                    OwnerId = "f38b3838-25da-49a2-9b80-9dad1bcb50f7",
                    BoardId = 3
                },
            };

            return tasks;
        }
    }
}
