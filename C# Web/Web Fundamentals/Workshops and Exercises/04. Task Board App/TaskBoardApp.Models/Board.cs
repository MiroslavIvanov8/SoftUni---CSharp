namespace TaskBoardApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using static TaskBoardApp.Common.EntityValidationConstants.Board;
    public class Board
    {
        public Board()
        {
            this.Tasks = new List<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BoardNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Task> Tasks { get; set; }

    }
}
