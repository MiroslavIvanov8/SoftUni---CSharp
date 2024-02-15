namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class IdentityUserBook
    {
        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;


        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        

    }
}