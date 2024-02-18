namespace SeminarHub.Models
{
    public class JoinedModel
    {
        public int Id { get; set; }

        public string Organizer { get; set; } = null!;
        public string Topic { get; set; } = null!;
        public string Lecturer { get; set; } = null!;
        public string DateAndTime { get; set; } = null!;
    }
}
