namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Book;
    public class Book
    {
        public Book()
        {
            this.IdentityUsersBooks = new HashSet<IdentityUserBook>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> IdentityUsersBooks { get; set; }
        
        //Has ApplicationUsersBooks – a collection of type ApplicationUserBook

    }
}
