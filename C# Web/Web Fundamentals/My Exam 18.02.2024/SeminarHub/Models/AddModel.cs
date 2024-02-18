namespace SeminarHub.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.ValidationConstants.Seminar;
    public class AddModel
    {
        public AddModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [StringLength(SeminarTopicMaxLength, MinimumLength = SeminarTopicMinLength,
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(LecturerNameMaxLength, MinimumLength = LecturerNameMinLength,
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength,
            ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Details { get; set; } = null!;

        [Required]  
        public int CategoryId { get; set; }

        [Required]
        public string DateAndTime { get; set; } = null!;
        
        [Range(DurationMinLength, DurationMaxLength)]
        public int? Duration { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
