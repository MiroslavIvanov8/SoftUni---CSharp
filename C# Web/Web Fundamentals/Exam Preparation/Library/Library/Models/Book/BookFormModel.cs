namespace Library.Models.Book
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Book;
    public class BookFormModel 
    {
        public BookFormModel()
        {
            this.Categories = new HashSet<BookCategory>();
        }

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength, 
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength,
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength,
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(BookMinRating, BookMaxRating)]
        public decimal Rating { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; } 

        public ICollection<BookCategory> Categories { get; set; }
    }
}
