namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Event;
    public class Event
    {
        public Event()
        {
            this.EventsParticipants = new List<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] 
        public string OrganizerId { get; set; } = null!;

        [Required]
        public virtual IdentityUser Organizer { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required] 
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }


        [Required]
        [ForeignKey(nameof(Models.Type))]
        public int TypeId { get; set; }

        [Required] 
        public Type Type { get; set; } = null!;

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
