namespace Library.Models.Book
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Category;
    public class BookCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength,
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Name { get; set; } = null!;
    }
}