using ValidationConstants = SoftUniBazar.Data.ValidationConstants;

namespace SoftUniBazar.Models
{
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants.Ad;
    public class AdFormModel
    {
        public AdFormModel()
        {
            this.Categories = new HashSet<AdCategoryModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(AdNameMaxLength, MinimumLength = AdNameMinLength, ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(AdDescriptionMaxLength, MinimumLength = AdDescriptionMinLength, ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<AdCategoryModel> Categories { get; set; }
    }
}
