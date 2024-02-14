using Homies.Data;
namespace Homies.Models.Event
{
    using System.ComponentModel.DataAnnotations;
    
    using static DataConstants.Event;
    public class EventFormModel
    {
        public EventFormModel()
        {
            this.Types = new List<EventTypeModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = "{0} should be at least {2} characters long.")]
        public string Description { get; set; }
        
        [Required]
        public string Start { get; set; }
        
        [Required]
        public string End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public ICollection<EventTypeModel> Types { get; set; }
    }
}
