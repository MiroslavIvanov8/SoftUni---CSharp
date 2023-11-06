using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(Configuration.PerformerNameMaxLength)]
        public string FirstName { get; set; }
        [MaxLength(Configuration.PerformerNameMaxLength)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
