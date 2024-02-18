namespace SeminarHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static ValidationConstants.Seminar;
    public class Seminar
    {
        public Seminar()
        {
            this.SeminarsParticipants = new HashSet<SeminarParticipant>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(SeminarTopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(LecturerNameMaxLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(DetailsMaxLength)]
        public string Details { get; set; } = null!;

        [ForeignKey(nameof(Organizer))]
        public string OrganizerId { get; set; }
        public virtual IdentityUser Organizer { get; set; } = null!;
        
        public DateTime DateAndTime { get; set; }
        public int? Duration { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<SeminarParticipant> SeminarsParticipants { get; set; }
        

    }
}
