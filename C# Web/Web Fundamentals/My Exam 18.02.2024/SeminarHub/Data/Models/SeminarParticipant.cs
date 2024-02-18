namespace SeminarHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class SeminarParticipant
    {
        [ForeignKey(nameof(Seminar))]
        public int SeminarId { get; set; }
        public virtual Seminar Seminar { get; set; } = null!;

        [ForeignKey(nameof(Participant))] 
        public string ParticipantId { get; set; } = null!;
        public virtual IdentityUser Participant { get; set; } = null!;
        
    }
}