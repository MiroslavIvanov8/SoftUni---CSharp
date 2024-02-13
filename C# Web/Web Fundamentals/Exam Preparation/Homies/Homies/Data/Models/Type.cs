namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Type;

    public class Type
    {
        public Type()
        {
            this.Events = new List<Event>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TypeNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }

    }
}
