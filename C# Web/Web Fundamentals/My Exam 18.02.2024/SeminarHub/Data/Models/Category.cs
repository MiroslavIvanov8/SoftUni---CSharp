namespace SeminarHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static ValidationConstants.Category;
    public class Category
    {
        public Category()
        {
            this.Seminars  = new HashSet<Seminar>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Seminar> Seminars { get; set; }
    }
}