using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskBoardApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using static TaskBoardApp.Common.EntityValidationConstants.Task;
    public class Task
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Task()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual IdentityUser Owner { get; set; } = null!;
    }
}
