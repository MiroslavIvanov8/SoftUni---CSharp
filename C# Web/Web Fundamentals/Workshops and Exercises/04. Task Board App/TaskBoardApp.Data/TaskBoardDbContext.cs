

using System.Reflection;
using TaskBoardApp.Models;

namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Task = TaskBoardApp.Models.Task;

    public class TaskBoardDbContext : IdentityDbContext<IdentityUser>
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } = null!;

        public DbSet<Board> Boards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //to load all configuration that are in config data folder
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TaskBoardDbContext)));

            
            
            base.OnModelCreating(builder);
        }
    }
}
