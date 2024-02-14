namespace SoftUniBazar.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    using static ValidationConstants.Ad;
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(AdNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AdDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required] 
        public string OwnerId { get; set; } = null!;

        [Required] 
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

    }
}
